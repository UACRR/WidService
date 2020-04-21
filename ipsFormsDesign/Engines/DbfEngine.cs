using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using ipsFormsDesign.Model;

namespace ipsFormsDesign.Engines
{
    public class DbfEngine
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetShortPathName(String pathName, StringBuilder shortName, int cbShortName);

        private string normalizeDbfName( string name )
        {
            StringBuilder sb = new StringBuilder(300);
            var inputName = name;
            int n = GetShortPathName(inputName, sb, sb.Capacity );
            if (n == 0)
                return string.Empty;
            return sb.ToString();
        }
        
        /// <summary>
        /// Прочитати DBF файл в структуру InputFile
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public InputFile ReadDbfFile(string fileName)
        {
            // Копіюємо файл в тимчасову копію

            string tempFile = Path.Combine(Path.GetTempPath(), "loadpay.dbf");

            if ( File.Exists(tempFile) )
            {
                File.Delete(tempFile);
            }

            File.Copy(fileName, tempFile);


            InputFile dest = new InputFile {FileName = Path.GetFileName(fileName), InputTime = DateTime.Now};
            string path = Path.GetDirectoryName(tempFile);
            string tableName = Path.GetFileNameWithoutExtension(tempFile);

            DataTable data = new DataTable();
            //using (OleDbConnection dbfConnection = new OleDbConnection($"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={path};Extended Properties=dBASE IV"))
            //using (OleDbConnection dbfConnection = new OleDbConnection($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={path};Extended Properties=dBASE IV"))
            using (OleDbConnection dbfConnection = new OleDbConnection($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={path};Extended Properties=dBASE IV;"))
            {
                try
                {
                    dbfConnection.Open();
                    OleDbCommand readCom = new OleDbCommand($"select * from [{tableName}]", dbfConnection);
                    data.Load(readCom.ExecuteReader());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                finally
                {
                    if (dbfConnection.State == ConnectionState.Open)
                        dbfConnection.Close();
                }
            }

            File.Delete(tempFile);

            // Перевіряємо структуру переданих даних
            if (СheckFields(data) == false)
                throw new ArgumentException("В файлі відсутні необхідні колонки!");

            // Завантажити дані
            LoadData(dest, data);     

            return dest;
        }

        private void LoadData(InputFile dest, DataTable data)
        {
            int index = 1;
            for( int i = 0, cnt=data.Rows.Count; i < cnt; i++  )
            {
                var item = data.Rows[i];
                if (item.RowState == DataRowState.Deleted)
                    continue;
                try
                {
                    dest.CheckParamPays.Add(new CheckParamPays
                    {
                        CheckId = index++,
                        AccountCorr = item["ACCCOR"].ToString(),
                        OkpoCorr = item["OKPOCOR"].ToString(),
                        MfoCorr = item["MFOCOR"].ToString(),
                        DocNum = item["NDOC"].ToString(),
                        DocDate = item.Field<DateTime>("DT"),
                        SCredit = Convert.ToDecimal(item["SUMMA"]) / 100,
                        Nplat = item.Field<string>("NAZN")
                    });
                    dest.ExternalPay.Add(new ExternalPay
                    {
                        InputDate = DateTime.Today,
                        Mfo = item["MFOCLI"].ToString(),
                        Okpol = item["OKPOCLI"].ToString(),
                        Account = item["ACCCLI"].ToString(),
                        DateOper = item.Field<DateTime?>("DT"),
                        R030 = "980",
                        CodeOper = "1",
                        MfoCorr = item["MFOCOR"].ToString(),
                        NameMfoCorr = item["BANKCOR"].ToString(),
                        AccountCorr = item["ACCCOR"].ToString(),
                        OkpoCorr = item["OKPOCOR"].ToString(),
                        NameCorr = item["NAMECOR"].ToString(),
                        DocNum = item["NDOC"].ToString(),
                        DocDate = item.Field<DateTime?>("DT"),
                        SDebet = 0,
                        SCredit = Convert.ToDecimal(item["SUMMA"]) / 100,
                        SNcCur = Convert.ToDecimal(item["SUMMA"]) / 100,
                        Nplat = item.Field<string>("NAZN"),
                        Status = 1
                    });
                }
                catch(Exception)
                {
                    throw;
                }
            }

        }

        /// <summary>
        /// Перевірити на наявність всіх необхідних полів
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private bool СheckFields(DataTable data)
        {
            string[] validField =  {
                "ACCCLI",
                "MFOCLI",
                "OKPOCLI",
                "NAMECLI",
                "BANKCLI",
                "ACCCOR",
                "MFOCOR",
                "OKPOCOR",
                "NAMECOR",
                "BANKCOR",
                "NDOC",
                "SUMMA",
                "NAZN",
                "DT",
                "DK",
                "TDOC",
                "DV",
                "IMPFLG" };

            foreach (var item in validField)
                if (data.Columns.Contains(item) == false)
                    return false;

            return true;
        }
    }
}
