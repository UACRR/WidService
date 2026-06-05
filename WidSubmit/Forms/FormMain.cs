using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WidSubmit.Properties;

namespace WidSubmit
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            if (Helpers.IsDesignMode()) return;

            this.Size = Settings.Default.FormMainSize;
            this.Location = Settings.Default.FormMainLocation;
            this.WindowState = FormWindowState.Normal;
            UpdateContent();
        }

        private void UpdateContent()
        {
            Helpers.RunProtected(() =>
            {
                switch(panelMiddle.SelectedIndex)
                {
                    case 0: ucSubmission.UpdateContent()    ; break;
                    case 1: ucRightHolders.UpdateContent()  ; break;
                    case 2: ucSubmWorksHist.UpdateContent() ; break;
                }
            });
        }

        private void btnUpdateFromMs_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                Helpers.RunSqlSocWidSubmitExT(cmd =>
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spRightHoldersUpdate";
                    cmd.ExecuteNonQuery();
                });
                ucRightHolders.UpdateContent();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
            
        }

        private void panelMiddle_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateContent();
         }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            ucSubmission    .UpdateProperties();
            //ucRightHolders  .UpdateProperties();
            ucSubmWorksHist .UpdateProperties();

            //Settings.Default.FormMainSize = this.Size;
            //Settings.Default.FormMainLocation = this.Location;

            Settings.Default.Save();
        }

        private void FormMain_SizeChanged(object sender, EventArgs e)
        {
            Settings.Default.FormMainSize = this.Size;
            Settings.Default.FormMainLocation = this.Location;
        }

        private void FormMain_Move(object sender, EventArgs e)
        {
            Settings.Default.FormMainSize = this.Size;
            Settings.Default.FormMainLocation = this.Location;
        }
    }
}
