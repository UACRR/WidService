using ipsmedserviceapp.Controllers.Resources;
using ipsmedserviceapp.Model;
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
        private class TransferData
        {
            public List<RightHolder> NewRightholderList { get; set; } = new List<RightHolder>();
        }

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

        // TODO: maybe TransferedObjectData
        // public
        private List<CopyRight> _oldCopyrights;
        private decimal _rateTotal;
        private decimal _rateTransfer;
        private decimal _kDecrTotal;
        // private
        private DateTime _maxDate = new DateTime(3000, 1, 1);
        private List<CopyrightData> _intermidiateCopyrightData = new List<CopyrightData>();
        // TODO: maybe TransferedObjectData

        //public List<CopyRight> ResultCopyrightList { get; } = new List<CopyRight>();
        //public List<CopyRightHistory> ResultCopyrightHistoryList { get; } = new List<CopyRightHistory>();
        //public List<Authors> ResultAuthorList { get; } = new List<Authors>();

        public ObjectTransferProcessor(MediaServiceContext dbContext, RightholderRepository rightholderRepository, TransferParametersResource transferParams)
        {
            _dbContext = dbContext;
            _rightholderRepository = rightholderRepository;
            _transferParams = transferParams;
        }

        public bool Process()
        {
            PrepareDataForTransfering();
            
            // TODO: extract ValidateTransferParams() method, use ModelState.AddModelError()
            // Dates, LegalBasis, NewRightholderList is not empty for each object,
            // new total Rate in NewRightholderList is less or equal to 100 persent, etc.
            // ValidateTransferedParams();

            // TODO: return error
            if (_oldRightholder == null)
                // return BadRequest($"Правовласник з ідентифікатором '{_transferParams.OldRightholderId}' не знайдений.");
                return false;

            foreach (var transferedObject in _transferParams.ObjectsRightList)
            {
                _oldCopyrights = _oldRightholder.CopyRight.Where(c => c.ObjId == transferedObject.ObjId).ToList();

                _rateTotal = _oldCopyrights.Sum(c => c.Rate ?? 0);

                //if (rateTotal == 0.0)
                //    AddError()

                _rateTransfer = transferedObject.NewRightholderList.Sum(r => r.Rate);

                //if (rateTransfer > rateTotal)
                //    AddError()

                _kDecrTotal = _rateTransfer / _rateTotal;

                CloseExistingCopyrightsForOldRightholder();

                CreateNewCopyrights(transferedObject);
            }

            _dbContext.SaveChanges();

            return true; // TODO: return errors
        }

        private void PrepareDataForTransfering()
        {
            _oldRightholder = _rightholderRepository.GetRightholderById(
                _transferParams.OldRightholderId,
                includeCopyrightsOnDate: _transferParams.DateFrom);

            var newRightholderIds = _transferParams.ObjectsRightList
                .SelectMany(o => o.NewRightholderList)
                .Select(r => r.CustId);
            _newRightholders = _rightholderRepository.GetRightholders(newRightholderIds);
        }

        private void CreateNewCopyrights(TransferedObjectResource transferedObject)
        {
            _intermidiateCopyrightData.Clear();

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
                        CustId = newRightholderParams.CustId, // TODO: check for rightholder existing
                        ObjId = oldCopyright.ObjId,
                        RoleCode = 8, // Правовласник
                        LBasis = _transferParams.LegalBasis,
                        BeginDate = _transferParams.DateFrom,
                        EndDate = _transferParams.DateTill,
                        Rate = newRate,
                        // to think: I can get all params from old copyright to create a new copyright, except KDecr and custId for new rightholder
                    };

                    _intermidiateCopyrightData.Add(new CopyrightData // TODO: extract to method
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

            // final copyright's list
            var groupedCopyrightData = _intermidiateCopyrightData
                .GroupBy(cd => new { cd.Copyright.CustId, cd.Copyright.ObjId, cd.Copyright.LBasis, cd.Copyright.BeginDate, cd.Copyright.EndDate, cd.Copyright.RoleCode });

            var copyrightList = new List<CopyRight>();
            var copyrightHistoryList = new List<CopyRightHistory>();

            foreach (var group in groupedCopyrightData)
            {
                var newCopyright = new CopyRight
                {
                    ParentId = 101, // TODO: only for debug
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
            groupedCopyrightData = _intermidiateCopyrightData
                .Where(cd => cd.IsNewRightholder)
                .GroupBy(cd => new { cd.Copyright.CustId, cd.Copyright.ObjId, cd.Copyright.LBasis, cd.Copyright.BeginDate, cd.Copyright.EndDate, cd.Copyright.RoleCode });

            foreach (var group in groupedCopyrightData)
            {
                _dbContext.Authors.Add(new Authors
                {
                    IsFolkOrUnknown = 1, // TODO: only for debug
                    ObjId = group.Key.ObjId.Value,
                    RoleCode = group.Key.RoleCode.Value,
                    CustId = group.Key.CustId,
                    AuthorName = _newRightholders.FirstOrDefault(r => r.CustId == group.Key.CustId).Name,
                    FolkType = 1,
                });
            }

            _dbContext.CopyRight.AddRange(copyrightList); // TODO: switch to async method
            _dbContext.CopyRightHistory.AddRange(copyrightHistoryList);

            // 3. create new copyrights for old rightholder if object is transfered for a certain time
            if (_transferParams.DateTill < _maxDate)
            {
                foreach (var oldCopyright in _oldCopyrights)
                {
                    var restoredCopyright = new CopyRight
                    {
                        ParentId = 202, // TODO: only for debug
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
            if (_transferParams.DateTill == _maxDate)
            {
                var authors = _dbContext.Authors
                    .Where(a => _transferParams.ObjectsRightList.Any(o => o.ObjId == a.ObjId))
                    .ToList();

                foreach (var author in authors)
                {
                    author.CustId = null;
                }
            }
        }
    }
}
