using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using IpsCommonTypes.Types;
using ipsmedserviceapp.Controllers.Resources;
using ipsmedserviceapp.Extensions;
using ipsmedserviceapp.Model;
using ipsmedserviceapp.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace ipsmedserviceapp.Controllers
{
    /// <summary>
    /// Контролер роботи з Об'єктами права
    /// </summary>
    [Produces("application/json")]
    [Route("api/ObjectRight")]
    public class ObjectRightController : Controller
    {
        private readonly MediaServiceContext _dbContext;

        public ObjectRightController(MediaServiceContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// приватний метод -- Отримати об'єкт бази даних по ідентифікатору
        /// </summary>
        /// <param name="objid"></param>
        /// <returns></returns>
        private async Task<ObjectRight> GetObjectRightById(int objid, bool includeRelated = false)
        {
            if (!includeRelated)
                return _dbContext.ObjectRight.FirstOrDefault(o => o.ObjId == objid);

            var objectRight = await _dbContext.ObjectRight.Where(rec => rec.ObjId == objid)
                .Include(rec => rec.Authors)
                .Include(rec => rec.SeekObject)
                .Include(rec => rec.MediaTrack)
                .SingleOrDefaultAsync();

            await _dbContext.Entry(objectRight).Collection(item => item.CopyRight)
                .Query()
                .Where(rec => rec.BeginDate <= DateTime.Today && DateTime.Today <= rec.EndDate)
                .Include(rec => rec.Cust)
                .Include(rec => rec.WorkRh)
                .LoadAsync();


            return objectRight;
        }

        /// <summary>
        /// Сінхронізація інформації по Об'єктам права
        /// </summary>
        /// <param name="sors"></param>
        /// <param name="dest"></param>
        private void updateObjectRight(ObjectRight sors, ObjectRight dest)
        {
            dest.SetFields(sors);
            if (sors.MediaTrack != null && dest.MediaTrack == null)
            {
                dest.MediaTrack = new MediaTrack();
            }
            dest.MediaTrack.SetFields(sors.MediaTrack);
            dest.MediaTrack.Duration = sors.MediaTrack.Duration;
            dest.MediaTrack.Name = sors.Name;
            _dbContext.UpdateList(sors.CopyRight, dest.CopyRight, i => { }, (l, r) => l.CRightId == r.CRightId);
            _dbContext.UpdateList(sors.Authors, dest.Authors, i => { }, (l, r) => l.AuthId == r.AuthId);
            _dbContext.UpdateList(sors.SeekObject, dest.SeekObject, i => { }, (l, r) => l.Id == r.Id);

            // Update WorkRh
            //{
            //    var dicCopyRight = sors.CopyRight.ToDictionary(rec => rec.CRightId);
            //    foreach ( var item in dest.CopyRight )
            //    {
            //        var sorsItem = dicCopyRight[item.CRightId];
            //        item.WorkRh.SetFields(sorsItem.WorkRh);
            //    }
            //}

            if (dest.CategoryCode == 5)
            {
                // update authors or lyrics, composers from Authors
                var creativeRoleTypes = _dbContext.CreativeRoleType.ToList();

                // автори всі коди окрім 0
                var authorsId = creativeRoleTypes.Where(rec => rec.IsAuthorType != 0).Select(rec => rec.CodeI).ToList();
                var authors = dest.Authors.Where(a => authorsId.Contains(a.RoleCode)).Select(a => a.AuthorName).ToList();
                dest.Author = string.Join(", ", authors);

                // автор тексту або автор тексту/композитор
                var lyricsId = creativeRoleTypes.Where(rec => rec.IsAuthorType == 1 || rec.IsAuthorType == 3).Select(rec => rec.CodeI).ToList();
                var lyrics = dest.Authors.Where(a => lyricsId.Contains(a.RoleCode)).Select(a => a.AuthorName).ToList();
                dest.MediaTrack.Lyrics = string.Join(", ", lyrics);

                // композитор або автор тексту/композитор
                var composersId = creativeRoleTypes.Where(rec => rec.IsAuthorType == 2 || rec.IsAuthorType == 3).Select(rec => rec.CodeI).ToList();
                var composers = dest.Authors.Where(a => composersId.Contains(a.RoleCode)).Select(a => a.AuthorName).ToList();
                dest.MediaTrack.Composers = string.Join(", ", composers);

                // update performers from SeekObject
                var performers = dest.SeekObject.Where(so => so.CodeI == 2).Select(so => so.Name).ToList();
                dest.Performer = string.Join(", ", performers);
                dest.MediaTrack.Performers = dest.Performer;
            }
        }

        /// <summary>
        /// Публічний меиод -- Отримати об'єкт бази даних по ідентифікатору
        /// </summary>
        /// <param name="objid">Ідентифікатор об'єкту</param>
        /// <returns>Структура даних обїекту</returns>
        [HttpGet("detail/{objid}")]
        public async Task<IActionResult> GetObjectById(int objid)
        {
            var or = await GetObjectRightById(objid, includeRelated: true);
            var rhList = await _dbContext.getViewData($"select * from ft_ObjectRightCustomerForm01({objid})", null);

            return Json(new { objectRight = or, rhList });
        }

        /// <summary>
        /// Публічний меиод -- Отримати об'єкт бази даних по ідентифікатору
        /// </summary>
        /// <param name="objid">Ідентифікатор об'єкту</param>
        /// <returns>Структура даних обїекту</returns>
        [HttpPut("detail/{objid}")]
        public async Task<IActionResult> UpdateObjectRightById(int objid, [FromBody] ObjectRight body)
        {
            IDbContextTransaction tran = null;
            try
            {
                ObjectRight dest = await GetObjectRightById(objid, includeRelated: true);
                updateObjectRight(body, dest);
                tran = _dbContext.Database.BeginTransaction();
                await _dbContext.SaveChangesAsync();
                tran.Commit();
                tran = null;
                return Json(dest);

            }
            catch (Exception ex)
            {
                tran?.Rollback();
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Створення нового об'єкту права
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost("newobject")]
        public async Task<IActionResult> Create([FromBody] ObjectRight body)
        {
            ObjectRight addObject = new ObjectRight { CategoryCode = body.CategoryCode };
            IDbContextTransaction tran = null;
            try
            {

                _dbContext.ObjectRight.Add(addObject);

                updateObjectRight(body, addObject);

                tran = _dbContext.Database.BeginTransaction();
                await _dbContext.SaveChangesAsync();
                tran.Commit();

                return Json(addObject);

            }
            catch (Exception ex)
            {
                tran?.Rollback();
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("newobjects")]
        public async Task<IActionResult> Create([FromBody] List<ObjectRight> objectList)
        {
            var list = new List<ObjectRight>();

            foreach(var obj in objectList)
            {
                var addObject = new ObjectRight { CategoryCode = obj.CategoryCode };

                updateObjectRight(obj, addObject);

                _dbContext.ObjectRight.Add(addObject);

                list.Add(addObject);
            }

            await _dbContext.SaveChangesAsync();

            return Ok(list);
        }

        private string normalizeName( string Name )
        {
            var retName = Name.ToUpper();

            retName = retName.Replace("'", "''");

            return retName;

        }
        [HttpPost("validate")]
        public async Task<IActionResult> ValidateObjectsRight([FromBody] List<ObjectRightValidateResource> objectRightList)
        {
            var objNames = objectRightList.Select(obj => obj.Name.ToUpper());
            var genres = objectRightList.Select(obj => obj.Genre.ToUpper()).Distinct();
            var roles = objectRightList.SelectMany(obj => obj.Rightholders).Select(r => r.CreativeRole.ToUpper()).Distinct();
            var rightholders = objectRightList.SelectMany(obj => obj.Rightholders).Select(r => normalizeName(r.Name)).Distinct();


            var foundedObjects = _dbContext.ObjectRight.Where(obj => objNames.Contains(obj.Name.ToUpper())).ToList();
            var foundedGenres = _dbContext.GenreType.Where(g => genres.Contains(g.Name.ToUpper())).ToList();
            var foundedRoles = _dbContext.CreativeRoleType.Where(r => r.CategoryCode == 5 && roles.Contains(r.Name.ToUpper())).ToList();
            var rhNames = "'" + string.Join("', '", rightholders) + "'";
            var foundedRightholders = await _dbContext.getViewData($"select * from vTsk_1_ListRightHolder01 where Upper(name) in ({rhNames})", null);

            foreach (var obj in objectRightList)
            {
                obj.ObjId = foundedObjects.FirstOrDefault(o => o.Name.ToUpper() == obj.Name.ToUpper())?.ObjId;
                obj.GenreId = foundedGenres.FirstOrDefault(g => g.Name.ToUpper() == obj.Genre.ToUpper())?.CodeI;

                foreach (var rh in obj.Rightholders)
                {
                    rh.RoleId = foundedRoles.FirstOrDefault(r => r.Name.ToUpper() == rh.CreativeRole.ToUpper())?.CodeI;
                    var rhdict = foundedRightholders.FirstOrDefault(dict => dict["name"].ToString().Trim().ToUpper() == rh.Name.ToUpper());
                    if (rhdict != null)
                    {
                        rh.CustId = (int)rhdict["custId"];
                        rh.Name = rhdict["name"].ToString().Trim();
                    }
                }
            }

            return Ok(objectRightList);
        }

        [HttpGet]
        public async Task<IActionResult> GetObjectRights([FromQuery] ObjectRightQueryResource query)
        {
            //var queryText = "select * from vtsk_3_OR_01";
            var queryText = "select t1.* from vtsk_3_OR_01 t1 join ft_tsk_3_OR_01_SEEK(@searchText) t2 on t1.objid = t2.objid";

            //queryText = ApplyFiltering(queryText, query);

            if (query?.State == 0) // Not active
                queryText += " where statusNoActive = 1";
            if (query?.State == 1) // Not linked
                queryText += " where statusNoRelate = 1";
            if (query?.State == 2) // Undistributed
                queryText += " where statusUnDistrib = 1";

            //var totalItems = (await _dbContext.getViewData(queryText.Replace("*", "count(*)"), null)).FirstOrDefault()?.Values.FirstOrDefault();

            //queryText = ApplyPaging(queryText, query);

            //queryText += $" ORDER BY ObjId OFFSET {(page - 1) * pageSize} ROWS FETCH NEXT {pageSize} ROWS ONLY";
            // 
            int skip = (query.Page.Value - 1) * query.PageSize.Value;
            int take = query.PageSize.Value;

            var list = await _dbContext.getViewData(queryText, new[]{new SqlParameter("@searchText", query.SearchText) });
            
            return Ok(new
            {
                List = list.Skip(skip).Take(take), 
                TotalItems = list.Count
            });
        }

        private string ApplyFiltering(string queryText, ObjectRightQueryResource query)
        {
            var conditions = new Collection<string>();
            if (query != null)
            {
                if (query.State.HasValue)
                {
                    if (query.State == 0) // Not active
                        conditions.Add($"statusNoActive = 1");
                    if (query.State == 1) // Not linked
                        conditions.Add($"statusNoRelate = 1");
                    if (query.State == 2) // Undistributed
                        conditions.Add($"statusUnDistrib = 1");
                }

                if (query.Category.HasValue)
                    conditions.Add($"categoryCode = {query.Category.Value}");

                if (query.Genre.HasValue)
                    conditions.Add($"genreType = {query.Genre.Value}");

                if (query.SearchText != null)
                {
                    query.SearchText = query.SearchText.Replace("'", "_");
                    conditions.Add($"(name like '%{query.SearchText}%' or author like '%{query.SearchText}%' or performer like '%{query.SearchText}%')");
                }

                if (conditions.Any())
                    queryText = queryText + " where " + string.Join(" and ", conditions);
            }

            return queryText;
        }

        private static string ApplyPaging(string queryText, ObjectRightQueryResource query)
        {
            int page = 0;
            int pageSize = 0;

            if (query != null)
            {
                if (query.Page.HasValue)
                    page = query.Page.Value;

                if (query.PageSize.HasValue)
                    pageSize = query.PageSize.Value;
            }

            if (page <= 0)
                page = 1;

            if (pageSize <= 0)
                pageSize = 100;

            queryText += $" ORDER BY ObjId OFFSET {(page - 1) * pageSize} ROWS FETCH NEXT {pageSize} ROWS ONLY";
            return queryText;
        }

        [HttpGet("{objId}/rightholders")]
        public async Task<IActionResult> GetObjectRightholders(int? objId)
        {
            if (objId == null)
                BadRequest("Object Id can not be null.");

            var obj = await GetObjectRightById(objId.Value);

            if (obj == null)
                NotFound($"Object with Id '{objId}' not found.");

            var rightholders = await _dbContext.getViewData("select * from ft_Tsk_7_ObjectRightholders( @objId )", new[] {
                new SqlParameter("@objId", objId)
            });

            return Ok(rightholders);
        }

        #region * * * Big right * * * 

        private async Task<ObjectRight> GetObjectRightBrById(int objId)
        {
            var objectRight = await _dbContext.ObjectRight
                .Include(rec => rec.Authors)
                .Include(rec => rec.CopyRight)
                    .ThenInclude(cr => cr.LicAuthorBr)
                .Include(rec => rec.CopyRight)
                    .ThenInclude(cr => cr.WorkRh)
                .Include(rec => rec.LicenseBigR)
                .FirstOrDefaultAsync(rec => rec.ObjId == objId);

            return objectRight;
        }

        private void UpdateObjectRightBr(ObjectRight source, ObjectRight dest)
        {
            dest.SetFields(source);

            _dbContext.UpdateList(source.LicenseBigR, dest.LicenseBigR, i => { }, (l, r) => l.LicId == r.LicId );

            _dbContext.UpdateList(source.Authors, dest.Authors, newItem =>
                {
                    newItem.FolkType = 1;
                },
                (l, r) => l.AuthId == r.AuthId
            );
            
            _dbContext.UpdateList(source.CopyRight, dest.CopyRight, newItem =>
                {
                    // set default data for new CopyRight item
                    newItem.BeginDate = new DateTime(1900, 1, 1);
                    newItem.EndDate = new DateTime(3000, 1, 1);
                    newItem.LBasis = 1;
                },
                (l, r) => l.CRightId == r.CRightId
            );

            // Update LicAuthorBr, WorkRh
            var destCopyRightsDict = dest.CopyRight.ToDictionary(cr => cr.CRightId);

            foreach (var sourceCopyRight in source.CopyRight)
            {
                var destCopyRight = destCopyRightsDict[sourceCopyRight.CRightId];

                // WorkRH
                if (destCopyRight.WorkRh == null)
                    destCopyRight.WorkRh = new WorkRh();

                if (destCopyRight.WorkRh.WorkTypeCl != sourceCopyRight.WorkRh.WorkTypeCl)
                {
                    destCopyRight.WorkRh.WorkTypeCl = sourceCopyRight.WorkRh.WorkTypeCl;
                    destCopyRight.WorkRh.WorkDateCl = DateTime.Now;
                }

                if (destCopyRight.WorkRh.WorkTypeRh != sourceCopyRight.WorkRh.WorkTypeRh)
                {
                    destCopyRight.WorkRh.WorkTypeRh = sourceCopyRight.WorkRh.WorkTypeRh;
                    destCopyRight.WorkRh.WorkDateRh = DateTime.Now;
                }

                if (destCopyRight.LicAuthorBr == null)
                    destCopyRight.LicAuthorBr = new List<LicAuthorBr>();

                destCopyRight.LicAuthorBr.SetFields(sourceCopyRight.LicAuthorBr);
            }
        }

        [HttpGet("br/detail/{objId}")]
        public async Task<IActionResult> GetObjectBrById(int objId)
        {
            var or = await GetObjectRightBrById(objId);
            var rhList = await _dbContext.getViewData($"select * from ft_ObjectRightCustomerForm01({objId})", null);

            return Json(new { objectRight = or, rhList });
        }

        [HttpPost("br/detail")]
        public async Task<IActionResult> CreateObjectRightBrById([FromBody] ObjectRight objectRight)
        {
            IDbContextTransaction tran = null;
            try
            {
                var createdObjectRight = new ObjectRight();
                _dbContext.ObjectRight.Add(createdObjectRight);

                UpdateObjectRightBr(objectRight, createdObjectRight);

                tran = _dbContext.Database.BeginTransaction();
                await _dbContext.SaveChangesAsync();
                tran.Commit();
                tran = null;

                return Json(createdObjectRight);
            }
            catch (Exception ex)
            {
                tran?.Rollback();
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("br/detail/{objId}")]
        public async Task<IActionResult> UpdateObjectRightBrById(int objId, [FromBody] ObjectRight objectRight)
        {
            IDbContextTransaction tran = null;
            try
            {
                var foundedObjectRight = await GetObjectRightBrById(objId);

                UpdateObjectRightBr(objectRight, foundedObjectRight);

                tran = _dbContext.Database.BeginTransaction();
                await _dbContext.SaveChangesAsync();
                tran.Commit();
                tran = null;

                return Json(foundedObjectRight);
            }
            catch (Exception ex)
            {
                tran?.Rollback();
                return BadRequest(ex.Message);
            }
        }

        #endregion

        #region Views
        /// <summary>
        /// Получити  список об'єктів права для основного єкрану інтерфейсу користувача
        /// </summary>
        /// <returns></returns>
        [HttpGet("listObjectRight")]
        public async Task<IActionResult> getListObjectRight()
        {
            var list = await _dbContext.getViewData("select * from vTsk_3_ListObjectRight01", null);
            return Json(list);
        }

        /// <summary>
        /// Получити  список об'єктів права autocomlete
        /// </summary>
        /// <returns></returns>
        [HttpGet("filteredObjectRights/{filter}")]
        public async Task<IActionResult> getListObjectRightForAutocomplete(string filter)
        {
            // string sqlFilter1 = string.Concat("%", filter, "%");
            string sqlFilter2 = string.Concat(filter, "%");

            var list = await _dbContext.getViewData("select * from vTsk_3_ListObjectRight01 where name like @filter2 order by name", new[] {
                new SqlParameter("@filter2", sqlFilter2)
            });
            return Json(list);
        }

        /// <summary>
        /// Список всіх об'єктів Єкран "Об'єкти (ВСІ)"
        /// </summary>
        /// <returns></returns>
        [HttpGet("view/list_01")]
        public async Task<IActionResult> getvtsk_3_OR_01()
        {
            var list = await _dbContext.getViewData("select * from vtsk_3_OR_01", null);
            return Json(list);
        }

        /// <summary>
        /// Список правовласників
        /// </summary>
        /// <returns></returns>
        [HttpGet("view/list_02")]
        public async Task<IActionResult> getvtsk_3_OR_02()
        {
            var list = await _dbContext.getViewData("select * from vtsk_3_OR_02", null);
            return Json(list);
        }

        /// <summary>
        /// Об'єкти (ВСІ)-от правообл
        /// </summary>
        /// <returns></returns>
        [HttpGet("view/list_0301/{id}")]
        public async Task<IActionResult> getvtsk_3_OR_03(int id)
        {
            var list = await _dbContext.getViewData($"select * from vtsk_3_OR_03 where custId = {id}", null);
            return Json(list);
        }

        /// <summary>
        /// Об'єкти (ВСІ)-от правообл Grid 2
        /// </summary>
        /// <returns></returns>
        [HttpGet("view/list_0302/{skip}/{take}/{id}")]
        public async Task<IActionResult> vtsk_3_OR_03_V2(int skip, int take, int id)
        {
            var count = await _dbContext.getViewData($"select count(*) from vtsk_3_OR_03_V2 where custId = {id}", null);

            string query = $"select * from vtsk_3_OR_03_V2 where custId = {id}";
            query = DBQueryHelper.ApplySqlOrderByAndPaging(query, "objid", skip, take);

            var list = await _dbContext.getViewData(query, null);

            var responce = new
            {
                TotalItems = count?.FirstOrDefault()?.Values.FirstOrDefault(),
                List = list,
            };

            return Ok(responce);
        }

        /// <summary>
        /// Об'єкти (ВСІ)-от правовласники Grid 2 з додатковим правовласником
        /// </summary>
        /// <returns></returns>
        [HttpGet("view/list_0302/{skip}/{take}/{custId}/{custIdSecondary}")]
        public async Task<IActionResult> vtsk_3_OR_03_V2(int skip, int take, int custId, int custIdSecondary)
        {
            string queryCount = $"select count(*) from vtsk_3_OR_03_V4 t1 where parentid is not null and custId = {custId} and exists (select 1 from vtsk_3_OR_03_V4 t2 where t2.objid = t1.objid and custId = {custIdSecondary})";
            var count = await _dbContext.getViewData(queryCount, null);

            string query = $"select * from vtsk_3_OR_03_V4 t1 where parentid is not null and custId = {custId} and exists (select 1 from vtsk_3_OR_03_V4 t2 where t2.objid = t1.objid and custId = {custIdSecondary})";
            query = DBQueryHelper.ApplySqlOrderByAndPaging(query, "objid", skip, take);

            var list = await _dbContext.getViewData(query, null);

            var responce = new
            {
                TotalItems = count?.FirstOrDefault()?.Values.FirstOrDefault(),
                List = list,
            };

            return Ok(responce);
        }

        /// <summary>
        /// Об'єкти (ВСІ)-от правообл Grid 3
        /// </summary>
        /// <returns></returns>
        [HttpGet("view/list_0303")]
        public async Task<IActionResult> vtsk_3_OR_03_V3()
        {
            var list = await _dbContext.getViewData("select * from vtsk_3_OR_03_V3", null);
            return Json(list);
        }

        #endregion

        /// <summary>
        /// Get object right list
        /// </summary>
        /// <param name="searchResource"></param>
        /// <returns></returns>
        [HttpPost("list")]
        public async Task<IActionResult> GetObjectsRightList([FromBody] ObjectRightSearchResource searchResource)
        {
            ResponseOfRequest<DataTable> response;
            try
            {
                DataTable data = null;
                var frameParam = await _dbContext.FrameParam.Where(rec => rec.FrameCode == 1).ToListAsync();

                string query = $"select t0.* from vtsk_3_OR_01_wpf t0";

                using (var sqlConnection = (SqlConnection)_dbContext.Database.GetDbConnection())
                {
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    if (searchResource.SimpleSearch != null)
                    {
                        query = SearchQueryHelper.CreateSearchQuery(query, frameParam, searchResource.SimpleSearch, out SqlParameter sqlParameter);
                        parameters.Add(sqlParameter);
                    }
                    if (searchResource.MultiplySearch != null)
                    {
                        query = SearchQueryHelper.CreateSearchQuery(query, frameParam, searchResource.MultiplySearch, out List<SqlParameter> sqlParameters);
                        parameters = sqlParameters;
                    }

                    await Task.Factory.StartNew(() => data = ExecuteQuery.GetDataFromSqlServer(sqlConnection, query, parameters));

                    response = new ResponseOfRequest<DataTable>(data);

                    return Ok(response);
                }
            }
            catch (Exception e)
            {
                response = new ResponseOfRequest<DataTable>(e);
                return Ok(response);
            }
        }

        [HttpPost("CheckUniqueObject")]
        public async Task<IActionResult> CheckUniqueObject([FromBody] string itemName)
        {
            var objects = await _dbContext.ObjectRight
                .Where(rec => rec.Name == itemName)
                .ToListAsync();

            bool isUnique = objects.Count == 0;

            var responseOfRequest = new ResponseOfRequest<bool>(isUnique);

            return Ok(responseOfRequest);
        }

        /// <summary>
        /// Перевірка наявності об'єктів права по назвам
        /// </summary>
        /// <param name="itemNames"></param>
        /// <returns>список об'єків права які були знайдені за назвами</returns>
        [HttpPost("CheckUniqueObjectList")]
        public async Task<IActionResult> CheckUniqueObjectList([FromBody] List<string> itemNames)
        {
            var list = new List<string>();

            foreach (var itemName in itemNames)
            {
                var objects = await _dbContext.ObjectRight
                    .Where(rec => rec.Name == itemName)
                    .ToListAsync();

                if (objects.Any())
                    list.Add(itemName);
            }

            var responseOfRequest = new ResponseOfRequest<List<string>>(list);

            return Ok(responseOfRequest);
        }
    }
}