using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidExport
{
    public class WidSubmWorkState
    {
        public class Author
        {
            public string IpBaseNr { get; set; }
            public int CustId { get; set; }
            public int? IpNameNr { get; set; }
            public int RightHolderType { get; set; }
            public int RoleCode { get; set; }
            public int HasAgreement { get; set; }
            public decimal? PerShr { get; set; }
            public decimal? MecShr { get; set; }
            public string PerSoc { get; set; }
            public string MecSoc { get; set; }
            public decimal? PerSocShr { get; set; }
            public decimal? MecSocShr { get; set; }
        }

        public class ErrorCheck
        {
            public bool NoOwnAuthor { get; set; }
            public bool NoAuthors { get; set; }
            public bool NoShares { get; set; }
            public bool MecSumNot100 { get; set; }
            public bool PerSumNot100 { get; set; }
            public List<int> CustNoIpNameNr { get; set; }
            public List<int> CustZeroMec { get; set; }
            public List<int> CustZeroPer { get; set; }
            public List<int> CustUndefRole { get; set; }

            public bool HasErrors()
            {
                return NoOwnAuthor || NoAuthors || NoShares
                    || MecSumNot100 || PerSumNot100 || CustNoIpNameNr != null
                    || CustZeroMec != null || CustZeroPer != null || CustUndefRole != null;
            }

            public void Reset()
            {
                NoOwnAuthor = false;
                NoAuthors = false;
                NoShares = false;
                MecSumNot100 = false;
                PerSumNot100 = false;
                CustNoIpNameNr = null;
                CustZeroMec = null;
                CustZeroPer = null;
                CustUndefRole = null;
            }
        }

        private List<Author> _authors;
        private ErrorCheck _errorCheck;

        private readonly string _connectStringMediaService;
        private readonly string _connectStringSocWidSubmit;

        private List<int> _objIds;

        public WidSubmWorkState(string connectStringMediaService, string connectStringSocWidSubmit)
        {
            _connectStringMediaService = connectStringMediaService;
            _connectStringSocWidSubmit = connectStringSocWidSubmit;
        }

        public void FillWidSubmWorkState()
        {
            _objIds = new List<int>();
            using (var conn = new SqlConnection(_connectStringMediaService))
            {
                conn.Open();
                using(var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select objId from MediaService..ObjectRight";
                    using(var r = cmd.ExecuteReader())
                    {
                        while(r.Read())
                        {
                            _objIds.Add(r.GetInt32(0));
                        }
                    }
                }
            }

            using (var conn = new SqlConnection(_connectStringSocWidSubmit))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "truncate table SocWidSubmit..WidSubmWorkState";
                    cmd.ExecuteNonQuery();
                }

                int cntProcessed = 0;
                foreach(var objId in _objIds)
                {
                    FillAuthors(objId);
                    CheckErrors();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"insert SocWidSubmit..WidSubmWorkState (
                              ObjId			
                            , IsValid		
                            , IsReady		
                            , IsScheduled	
                            , IsSent		
                            , NoOwnAuthor	
                            , NoAuthors		
                            , NoShares		
                            , MecSumNot100	
                            , PerSumNot100	
                            , CustNoIpNameNr
                            , CustZeroMec	
                            , CustZeroPer	
                            , CustUndefRole	
                        )
                        values (
                              @ObjId			
                            , @IsValid		
                            , @IsReady		
                            , @IsScheduled	
                            , @IsSent		
                            , @NoOwnAuthor	
                            , @NoAuthors		
                            , @NoShares		
                            , @MecSumNot100	
                            , @PerSumNot100	
                            , @CustNoIpNameNr
                            , @CustZeroMec	
                            , @CustZeroPer	
                            , @CustUndefRole	
                        )";

                        cmd.Parameters.AddWithValue("@ObjId", objId);
                        cmd.Parameters.AddWithValue("@IsValid", !_errorCheck.HasErrors());
                        cmd.Parameters.AddWithValue("@IsReady", 0);
                        cmd.Parameters.AddWithValue("@IsScheduled", 0);
                        cmd.Parameters.AddWithValue("@IsSent", 0);
                        cmd.Parameters.AddWithValue("@NoOwnAuthor", _errorCheck.NoOwnAuthor);
                        cmd.Parameters.AddWithValue("@NoAuthors", _errorCheck.NoAuthors);
                        cmd.Parameters.AddWithValue("@NoShares", _errorCheck.NoShares);
                        cmd.Parameters.AddWithValue("@MecSumNot100", _errorCheck.MecSumNot100);
                        cmd.Parameters.AddWithValue("@PerSumNot100", _errorCheck.PerSumNot100);
                        cmd.Parameters.AddWithValue("@CustNoIpNameNr", _errorCheck.CustNoIpNameNr != null);
                        cmd.Parameters.AddWithValue("@CustZeroMec", _errorCheck.CustZeroMec != null);
                        cmd.Parameters.AddWithValue("@CustZeroPer", _errorCheck.CustZeroPer != null);
                        cmd.Parameters.AddWithValue("@CustUndefRole", _errorCheck.CustUndefRole != null);

                        cmd.ExecuteNonQuery();
                    }

                    cntProcessed++;
                    if (cntProcessed > 50000)
                    {
                        break;
                    }
                }
            }
        }

        private void FillAuthors(int objId)
        {
            using (var conn = new SqlConnection(_connectStringMediaService))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = Constants.SqlSelectAuthors;
                    cmd.Parameters.AddWithValue("@objId", objId);
                    using (var r = cmd.ExecuteReader())
                    {
                        _authors = new List<Author>();
                        while (r.Read())
                        {
                            _authors.Add(new Author
                            {
                                IpBaseNr = r.IsDBNull(0) ? "" : r.GetString(0),
                                CustId = r.GetInt32(1),
                                IpNameNr = r.IsDBNull(2) ? (int?)null : int.Parse(r.GetString(2)),
                                RightHolderType = r.GetInt32(3),
                                RoleCode = r.GetInt32(4),
                                HasAgreement = r.GetInt32(5),
                                PerShr = r.IsDBNull(6) ? (decimal?)null : r.GetDecimal(6),
                                MecShr = r.IsDBNull(7) ? (decimal?)null : r.GetDecimal(7),
                                PerSoc = r.IsDBNull(8) ? "" : r.GetString(8),
                                MecSoc = r.IsDBNull(9) ? "" : r.GetString(9),
                                PerSocShr = r.IsDBNull(10) ? (decimal?)null : r.GetDecimal(10),
                                MecSocShr = r.IsDBNull(11) ? (decimal?)null : r.GetDecimal(11),
                            });
                        }
                    }
                }
            };
        }

        private void CheckErrors()
        {
            _errorCheck = new ErrorCheck();
            _errorCheck.Reset();

            _errorCheck.NoOwnAuthor = !_authors.Any(x => x.HasAgreement == 1);

            if (_authors.Count == 0)
            {
                _errorCheck.NoAuthors = true;
                return;
            }

            var sumMec = _authors.Sum(x => x.MecShr);
            _errorCheck.MecSumNot100 = sumMec > 0 && sumMec != 100;

            var sumPer = _authors.Sum(x => x.PerShr);
            _errorCheck.PerSumNot100 = sumPer > 0 && sumPer != 100;

            _errorCheck.NoShares = sumMec + sumPer == 0;

            if (_authors.Any(x => x.IpNameNr == null))
            {
                _errorCheck.CustNoIpNameNr = new List<int>();
                _authors.Where(x => x.IpNameNr == null).ToList().ForEach(x => _errorCheck.CustNoIpNameNr.Add(x.CustId));
            }

            if (sumMec > 0 && _authors.Any(x => x.MecShr == 0))
            {
                _errorCheck.CustZeroMec = new List<int>();
                _authors.Where(x => x.MecShr == 0).ToList().ForEach(x => _errorCheck.CustZeroMec.Add(x.CustId));
            }

            if (sumPer > 0 && _authors.Any(x => x.PerShr == 0))
            {
                _errorCheck.CustZeroPer = new List<int>();
                _authors.Where(x => x.PerShr == 0).ToList().ForEach(x => _errorCheck.CustZeroPer.Add(x.CustId));
            }

            if (_authors.Any(x => x.RightHolderType != 3 && x.RoleCode == 8))
            {
                _errorCheck.CustUndefRole = new List<int>();
                _authors.Where(x => x.RightHolderType == 8 && x.RoleCode == 8).ToList().ForEach(x => _errorCheck.CustUndefRole.Add(x.CustId));
            }
        }
    }
}
