using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ipsmedserviceapp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
                .Include( rec => rec.CopyRight)
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
        /// Публічний меиод -- Отримати об'єкт бази даних по ідентифікатору
        /// </summary>
        /// <param name="objid">Ідентифікатор об'єкту</param>
        /// <returns>Структура даних обїекту</returns>
        [HttpGet("detail/{objid}")]
        public async Task<IActionResult> GetObjectById( int objid )
        {
            return Json( await getObjectRightById(objid) );
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

        private void updateObjectRight( ObjectRight sors, ObjectRight dest )
        {
            dest.SetFields(sors);

        }
        [HttpPost("newobject")]
        public IActionResult createObjectRight([FromBody] ObjectRight body )
        {
            ObjectRight addObject = new ObjectRight { CategoryCode = body.CategoryCode };
            _dbContext.ObjectRight.Add(addObject);

            updateObjectRight(body, addObject);


            return Json(addObject);
        }
    }


}