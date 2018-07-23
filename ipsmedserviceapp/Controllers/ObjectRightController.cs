using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ipsmedserviceapp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace ipsmedserviceapp.Controllers
{
    /// <summary>
    /// Об'єкти права
    /// </summary>
    [Produces("application/json")]
    [Route("api/ObjectRight")]
    public class ObjectRightController : Controller
    {
        private MediaServiceContext _dbContext;
        public ObjectRightController(MediaServiceContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// приватний метод -- Отримати об'єкт бази даних по ідентифікатору
        /// </summary>
        /// <param name="objid"></param>
        /// <returns></returns>
        private async Task<ObjectRight> getObjectRightById(int objid)
        {
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
            {
                var dicCopyRight = sors.CopyRight.ToDictionary(rec => rec.CRightId);
                foreach ( var item in dest.CopyRight )
                {
                    var sorsItem = dicCopyRight[item.CRightId];
                    item.WorkRh.SetFields(sorsItem.WorkRh);
                }
            }

            if (dest.CategoryCode == 5)
            {
                // update authors or lyrics, composers from Authors
                var lyrics = dest.Authors.Where(a => a.RoleCode == 1).Select(a => a.AuthorName).ToList();
                var composers = dest.Authors.Where(a => a.RoleCode == 2).Select(a => a.AuthorName).ToList();

                dest.MediaTrack.Lyrics = string.Join(", ", lyrics);
                dest.MediaTrack.Composers = string.Join(", ", composers);
                dest.Author = string.Join(", ", dest.MediaTrack.Lyrics, dest.MediaTrack.Composers);

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
            var or = await getObjectRightById(objid);
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
                ObjectRight dest = await getObjectRightById(objid);
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
        /// Сформувати каркас для нового об'єкту права
        /// </summary>
        /// <param name="CategoryCode"></param>
        /// <returns></returns>
        [HttpGet("new/{CategoryCode}")]
        public IActionResult getObjectRightWildCard(int CategoryCode)
        {
            ObjectRight addObject = new ObjectRight { CategoryCode = CategoryCode };
            switch (CategoryCode)
            {
                case 5:
                    {
                        addObject.MediaTrack = new MediaTrack { Duration = new TimeSpan(0, 0, 0) };
                    }
                    break;
            }

            return Json(addObject);
        }

        /// <summary>
        /// Створення нового об'єкту права
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost("newobject")]
        public async Task<IActionResult> createObjectRight([FromBody] ObjectRight body)
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

        #region Big right

        private async Task<ObjectRight> getObjectRightBrById(int objId)
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

        [HttpGet("br/detail/{objid}")]
        public async Task<IActionResult> GetObjectBrById(int objId)
        {
            var or = await getObjectRightBrById(objId);
            var rhList = await _dbContext.getViewData($"select * from ft_ObjectRightCustomerForm01({objId})", null);

            return Json(new { objectRight = or, rhList });
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
        [HttpGet("view/list_0302/{id}")]
        public async Task<IActionResult> vtsk_3_OR_03_V2(int id)
        {
            var list = await _dbContext.getViewData($"select * from vtsk_3_OR_03_V2  where custId = {id}", null);
            return Json(list);
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

    }


}