using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WidSubmit.UcSubmProcessControl;
using System.Windows.Forms;

namespace WidSubmit
{
    public class SubmActionRunner
    {
        public static bool SubmHasReadyWorks()
        {
            var res = false;
            Helpers.RunSqlSocWidSubmitEx(cmd =>
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select dbo.fnSubmHasReadyWorks()";
                res = (bool)cmd.ExecuteScalar();
            });
            return res;
        } 
        
        public static bool SubmFileExists()
        {
            var res = false;
            Helpers.RunSqlSocWidSubmitEx(cmd =>
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select dbo.fnSubmFileExists()";
                res = (bool)cmd.ExecuteScalar();
            });
            return res;
        } 

        private static void CreateSubmFile()
        {
            var hasReadyWorks = SubmHasReadyWorks();

            if (!hasReadyWorks)
            {
                if (DialogResult.Yes !=
                    MessageBox.Show("Відсутні твори для передачі, файл не буде створений.",
                        "Публікація творів",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning))
                {
                    return;
                }
            }

            var submFileExists = SubmFileExists();
            if (submFileExists)
            {
                if (DialogResult.Yes !=
                    MessageBox.Show("Підготовлений до передачі в WID файл вже створений. Замінити його на новий?",
                        "Публікація творів",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    return;
                }
            }

            //var builder = new WidTransBuilder();
            //builder.CreateSubmFile((int)_selectedGroup.Id);
        }   //
    }

 

}
