using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WidExport.Entities;

namespace WidExport
{
    public static class Tests
    {
        const string ConnectionStringSocWid = @"Persist Security Info=False;User=OlegM;Password=111111;Server=89.184.65.168\IPSDATA,60675";
        const string ConnectionStringSocWidSubmit = @"Persist Security Info=False;Trusted_Connection=yes;Initial Catalog = SocWidSubmit; Server=localhost";
        const string ConnectionStringMediaService = @"Persist Security Info=False;User=OlegM;Password=111111;Server=89.184.65.168\IPSDATA,60675";
        public static int AddEntityInDb(string ConnectionString, object entity)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    return Helpers.InsertEntityInDb(cmd, entity);
                }
            };
        }
        public static int AddSubmFileInDb()
        {
            var entity = new SubmFile
            {
                Name = "asdasdasddd",
                Year = 2022,
                Month = 11,
                Day = 19,
            };
            return AddEntityInDb(ConnectionStringSocWidSubmit, entity);
        }

        public static void CreateInDb()
        {
            var objIdList = new List<int>()
            {
                9857, // маленьке слоненя
                8078, // метро
                8058, // так мало тут тебе
                //56887, // без бою 
                //56575, // наодинці
                2540, // атятя
                49221, // аеліта софія ротару
                717230, // бажай нк
            };
            objIdList.ForEach(objId =>
            {
                var widTransBuilder = new WidTransBuilder(ConnectionStringSocWid, ConnectionStringSocWidSubmit);
                //widTransBuilder.CreateInDb(objId);
            });
        }

        public static void ReadWiaFromDb()
        {
            var widTransBuilder = new WidTransBuilder(ConnectionStringSocWid, ConnectionStringSocWidSubmit);
            //idTransBuilder.ReadWiaFromDb(wiaId);
        }

        public static void CreateSubmFile()
        {
            var widTransBuilder = new WidTransBuilder(ConnectionStringSocWid, ConnectionStringSocWidSubmit);
           // widTransBuilder.CreateSubmFile();
        }

        public static void FillWidSubmWorkState()
        {
            var widSubmWorkState = new WidSubmWorkState(ConnectionStringMediaService, ConnectionStringSocWidSubmit);
            widSubmWorkState.FillWidSubmWorkState();
        }
    }

}
