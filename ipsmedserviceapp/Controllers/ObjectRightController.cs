using System;
using System.Collections.Generic;
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
        private async Task<ObjectRight> getObjectRightById( int objid )
        {
            var objectRight = await _dbContext.ObjectRight.Where(rec => rec.ObjId == objid)
                .Include(rec => rec.Authors)
                .Include(rec => rec.CopyRight)
                .Include(rec => rec.SeekObject)
                .Include(rec => rec.MediaTrack)
                .SingleOrDefaultAsync();

            foreach( var right in objectRight.CopyRight )
            {
                await _dbContext.Entry(right).Reference(item => item.Cust).LoadAsync();
            }

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
            _dbContext.UpdateList(sors.CopyRight, dest.CopyRight, i => { }, (l, r) => l.CRightId == r.CRightId);
            _dbContext.UpdateList(sors.Authors, dest.Authors, i => { }, (l, r) => l.AuthId == r.AuthId);

        }

        /// <summary>
        /// Публічний меиод -- Отримати об'єкт бази даних по ідентифікатору
        /// </summary>
        /// <param name="objid">Ідентифікатор об'єкту</param>
        /// <returns>Структура даних обїекту</returns>
        [HttpGet("detail/{objid}")]
        public async Task<IActionResult> GetObjectById(int objid)
        {
            return Json(await getObjectRightById(objid));
        }

        /// <summary>
        /// Публічний меиод -- Отримати об'єкт бази даних по ідентифікатору
        /// </summary>
        /// <param name="objid">Ідентифікатор об'єкту</param>
        /// <returns>Структура даних обїекту</returns>
        [HttpPut("detail/{objid}")]
        public async Task<IActionResult> UpdateObjectRightById(int objid, [FromBody] ObjectRight body )
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
            catch( Exception ex )
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
        public  IActionResult getObjectRightWildCard( int CategoryCode )
        {
            ObjectRight addObject = new ObjectRight { CategoryCode = CategoryCode };
            switch( CategoryCode )
            {
                case 5:
                    {
                        addObject.MediaTrack = new MediaTrack();
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
        public async Task<IActionResult> createObjectRight([FromBody] ObjectRight body )
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
            catch( Exception ex )
            {
                tran?.Rollback();
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Получити  список об'єктів права для основного єкрану інтерфейсу користувача
        /// </summary>
        /// <returns></returns>
        [HttpGet("listObjectRight")]
        public async Task<IActionResult> getListObjectRight()
        {
            var list = await _dbContext.getViewData("select * from vTsk_1_ListObjectRight01", null);
            return Json(list);
        }
    }


}