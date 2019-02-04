using ipsmedserviceapp.Controllers.Resources;
using ipsmedserviceapp.Model;
using ipsmedserviceapp.Model.AppModels;
using ipsmedserviceapp.Model.SQLViewsData;
using ipsmedserviceapp.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ipsmedserviceapp.Utilities
{
    public class ObjectTransferProcessor
    {
        private class CopyrightData
        {
            public CopyRight Copyright { get; set; }
            public CopyRight ParentCopyright { get; set; }
            public bool IsNewRightholder { get; set; }
            // new copyright which is derived from this intermidiate copyright
            // and will be persist in the database
            public CopyRight CopyrightToDb { get; set; }
        }

        private readonly MediaServiceContext _dbContext;
        private readonly RightholderRepository _rightholderRepository;
        private readonly TransferParametersResource _transferParams;
        private RightHolder _oldRightholder;
        private List<RightholderMainView> _newRightholders;
        private List<Authors> _allAuthors;

        private List<CopyRight> _oldCopyrights;
        private decimal _rateTotal;
        private decimal _rateTransfer;
        private decimal _kDecrTotal;
        private DateTime _maxDate = new DateTime(3000, 1, 1);
        private List<CopyrightData> _intermidiateCopyrightData = new List<CopyrightData>();

        public ValidationResult Result { get; } = new ValidationResult();

        public ObjectTransferProcessor(MediaServiceContext dbContext, RightholderRepository rightholderRepository, TransferParametersResource transferParams)
        {
            _dbContext = dbContext;
            _rightholderRepository = rightholderRepository;
            _transferParams = transferParams;
        }

        public void Process()
        {
            if (!ValidateTransferedParams())
                return;

            PrepareDataForTransfering();

            if (!ValidateDataForTransfering())
                return;

            foreach (var transferedObject in _transferParams.ObjectsRightList)
            {
                _oldCopyrights = _oldRightholder.CopyRight.Where(c => c.ObjId == transferedObject.ObjId).ToList();

                _rateTotal = _oldCopyrights.Sum(c => c.Rate ?? 0);

                if (_rateTotal == 0m)
                {
                    Result.AddError($"Для об'єкта з ідентифікатором {transferedObject.ObjId} загальний відсоток володіння дорівнює нулю. Передача не виконана.");
                    continue;
                }

                _rateTransfer = transferedObject.NewRightholderList.Sum(r => r.Rate);

                if (_rateTransfer > _rateTotal)
                {
                    Result.AddError($"Для об'єкта з ідентифікатором {transferedObject.ObjId} загальний відсоток до передачі {_rateTransfer} перевищує загальний відсоток володіння {_rateTotal}. Передача не виконана.");
                    continue;
                }

                _kDecrTotal = _rateTransfer / _rateTotal;

                CloseExistingCopyrightsForOldRightholder();

                CreateNewCopyrights(transferedObject);
            }

            _dbContext.SaveChanges();
        }

        private bool ValidateTransferedParams()
        {
            if (_transferParams.DateFrom == DateTime.MinValue)
                Result.AddError(nameof(_transferParams.DateFrom), "Не вказана дата з якої передаються об'єкти.");

            if (_transferParams.LegalBasis == 5 && _transferParams.DateTill == DateTime.MinValue)
                Result.AddError(nameof(_transferParams.DateTill), "Для типу передачі 'Передача прав' обов'язково вказується дата по яку передаються об'єкти.");

            if (!new[] { 3, 5 }.Contains(_transferParams.LegalBasis))
                Result.AddError(nameof(_transferParams.LegalBasis), "Не вірний тип передачі.");

            if (_transferParams.OldRightholderId == 0)
                Result.AddError(nameof(_transferParams.OldRightholderId), "Не вказаний ідентифікатор правовласника з якого передаються об'єкти.");

            if (!_transferParams.ObjectsRightList.Any())
                Result.AddError(nameof(_transferParams.ObjectsRightList), "Список об'єктів до передачі не може бути пустий.");

            return !Result.AreErrorsExist;
        }

        private void PrepareDataForTransfering()
        {
            _oldRightholder = _rightholderRepository.GetRightholderById(
                _transferParams.OldRightholderId,
                includeCopyrightsOnDate: _transferParams.DateFrom);

            var newRightholderIds = _transferParams.ObjectsRightList
                .SelectMany(o => o.NewRightholderList)
                .Select(r => r.CustId)
                .ToList();

            _newRightholders = _rightholderRepository.GetRightholders(newRightholderIds);

            _allAuthors = _dbContext.Authors.Where(a => newRightholderIds.Contains((int)a.CustId)).ToList();
        }

        private bool ValidateDataForTransfering()
        {
            if (_oldRightholder == null)
                Result.AddError(nameof(_transferParams.OldRightholderId), $"Правовласник з ідентифікатором {_transferParams.OldRightholderId} не знайдений.");

            var newRightholderIds = _transferParams.ObjectsRightList
                .SelectMany(o => o.NewRightholderList)
                .Select(r => r.CustId);

            foreach (var id in newRightholderIds)
            {
                if (!_newRightholders.Any())
                    Result.AddError("custId", $"Правовласник з ідентифікатором {id} не знайдений.");
            }

            return !Result.AreErrorsExist;
        }

        private void CreateNewCopyrights(TransferedObjectResource transferedObject)
        {
            _intermidiateCopyrightData.Clear();

            PrepareNewIntermidiateCopyrights(transferedObject);

            CreateFinalNewCopyright();

            CreateNewCopyrightsForOldrightholder();
        }

        private void PrepareNewIntermidiateCopyrights(TransferedObjectResource transferedObject)
        {
            // for each old copyright:
            foreach (var oldCopyright in _oldCopyrights)
            {
                var totalTransferedRate = 0m;

                // 1. create new copyrights for each of new rightholders
                foreach (var newRightholderParams in transferedObject.NewRightholderList)
                {
                    var newRate = Math.Round(oldCopyright.Rate.Value * newRightholderParams.Rate / _rateTotal, 2);

                    totalTransferedRate += newRate;

                    var newCopyright = new CopyRight
                    {
                        CustId = newRightholderParams.CustId,
                        ObjId = oldCopyright.ObjId,
                        RoleCode = 8, // Правовласник
                        LBasis = _transferParams.LegalBasis,
                        BeginDate = _transferParams.DateFrom,
                        EndDate = _transferParams.DateTill,
                        Rate = newRate,
                    };

                    _intermidiateCopyrightData.Add(new CopyrightData
                    {
                        Copyright = newCopyright,
                        IsNewRightholder = true,
                        ParentCopyright = oldCopyright,
                    });
                }

                // 2. create copyrights for old rightholder if rate isn't transfered completely
                if (_kDecrTotal < 1)
                {
                    var restCopyright = new CopyRight
                    {
                        ObjId = oldCopyright.ObjId,
                        CustId = oldCopyright.CustId,
                        RoleCode = oldCopyright.RoleCode,
                        LBasis = oldCopyright.LBasis,
                        BeginDate = _transferParams.DateFrom,
                        EndDate = _transferParams.DateTill,
                        Rate = oldCopyright.Rate - totalTransferedRate,
                    };

                    _intermidiateCopyrightData.Add(new CopyrightData
                    {
                        Copyright = restCopyright,
                        IsNewRightholder = false,
                        ParentCopyright = oldCopyright,
                    });
                }
            }
        }

        private void CreateFinalNewCopyright()
        {
            // final copyright's list
            var groupedCopyrightData = _intermidiateCopyrightData
                .GroupBy(cd => new { cd.Copyright.CustId, cd.Copyright.ObjId, cd.Copyright.LBasis, cd.Copyright.BeginDate, cd.Copyright.EndDate, cd.Copyright.RoleCode });

            var copyrightList = new List<CopyRight>();
            var copyrightHistoryList = new List<CopyRightHistory>();

            foreach (var group in groupedCopyrightData)
            {
                var newCopyright = new CopyRight
                {
                    //ParentId = 101, // TODO: only for debug
                    CustId = group.Key.CustId,
                    ObjId = group.Key.ObjId,
                    RoleCode = group.Key.RoleCode,
                    LBasis = group.Key.LBasis,
                    BeginDate = group.Key.BeginDate,
                    EndDate = group.Key.EndDate,
                    Rate = group.Sum(c => c.Copyright.Rate ?? 0),
                };

                copyrightList.Add(newCopyright);

                // graph of copyright's hierarchy
                foreach (var copyrightData in group)
                {
                    copyrightData.CopyrightToDb = newCopyright;
                }
            }

            foreach (var copyrightData in _intermidiateCopyrightData)
            {
                copyrightHistoryList.Add(new CopyRightHistory
                {
                    Child = copyrightData.CopyrightToDb,
                    Parent = copyrightData.ParentCopyright,
                    Rate = copyrightData.Copyright.Rate,
                });
            }

            // add new rightholders to authors table
            var groupedCopyrightData1 = _intermidiateCopyrightData
                .Where(cd => cd.IsNewRightholder)
                .GroupBy(cd => new { cd.Copyright.CustId, cd.Copyright.ObjId, cd.Copyright.LBasis, cd.Copyright.BeginDate, cd.Copyright.EndDate, cd.Copyright.RoleCode });

            foreach (var group in groupedCopyrightData1)
            {
                var authorExists = _allAuthors.Any(a => a.CustId == group.Key.CustId && a.ObjId == group.Key.ObjId.Value);

                if (!authorExists)
                {
                    _dbContext.Authors.Add(new Authors
                    {
                        //IsFolkOrUnknown = 1, // TODO: only for debug
                        ObjId = group.Key.ObjId.Value,
                        RoleCode = group.Key.RoleCode.Value,
                        CustId = group.Key.CustId,
                        AuthorName = _newRightholders.FirstOrDefault(r => r.CustId == group.Key.CustId).Name,
                        FolkType = 1,
                    });
                }
            }

            _dbContext.CopyRight.AddRange(copyrightList);
            _dbContext.CopyRightHistory.AddRange(copyrightHistoryList);
        }

        private void CreateNewCopyrightsForOldrightholder()
        {
            // create new copyrights for old rightholder if object is transfered for a certain time
            if (_transferParams.DateTill < _maxDate)
            {
                foreach (var oldCopyright in _oldCopyrights)
                {
                    var restoredCopyright = new CopyRight
                    {
                        //ParentId = 202, // TODO: only for debug
                        CustId = oldCopyright.CustId,
                        ObjId = oldCopyright.ObjId,
                        RoleCode = oldCopyright.RoleCode,
                        LBasis = oldCopyright.LBasis,
                        BeginDate = _transferParams.DateTill.AddDays(1),
                        EndDate = _maxDate,
                        Rate = oldCopyright.Rate,
                    };

                    _dbContext.CopyRight.Add(restoredCopyright);

                    var copyrightDataList = _intermidiateCopyrightData.Where(c => c.ParentCopyright.CRightId == oldCopyright.CRightId);

                    foreach (var copyrightData in copyrightDataList)
                    {
                        _dbContext.CopyRightHistory.Add(new CopyRightHistory
                        {
                            Child = restoredCopyright,
                            Parent = copyrightData.CopyrightToDb,
                            Rate = copyrightData.Copyright.Rate,
                        });
                    }
                }
            }
        }

        private void CloseExistingCopyrightsForOldRightholder()
        {
            var endDate = _transferParams.DateFrom.AddDays(-1);

            foreach (var copyright in _oldCopyrights)
            {
                copyright.EndDate = endDate;
            }

            // clear custId in authors table for old rightholder if rights are transfered at all
            // Патлякевич Зберігаємо custId
            //if (_transferParams.DateTill == _maxDate)
            //{
            //    var authors = _dbContext.Authors
            //        .Where(a => _transferParams.ObjectsRightList.Any(o => o.ObjId == a.ObjId))
            //        .ToList();

            //    foreach (var author in authors)
            //    {
            //        author.CustId = null;
            //    }
            //}
        }
    }
}
