using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace IpsViewComponentLibrary
{
    public partial class ExpandedFormForAnketaPersonRightHolder : Telerik.WinControls.UI.RadForm
    {
        public ExpandedFormForAnketaPersonRightHolder()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Тип форми
        /// </summary>
        /// <param name="type"></param>
        public ExpandedFormForAnketaPersonRightHolder(string type)
        {
            InitializeComponent();
            switch (type)
            {
                case "firstname":
                {
                    lblTextRu.Text = "Имя (Ru):";
                    lblTextEn.Text = "Lastname (En):";
                }break;

                case "lastname":
                {
                    lblTextRu.Text = "Фамилия (Ru):";
                    lblTextEn.Text = "Lastname (En):";
                }break;

                case "surname":
                {
                    lblTextRu.Text = "Отчество (Ru):";
                    lblTextEn.Text = "Surname (En):";
                }break;

                case "pseudonym":
                {
                    lblTextRu.Text = "Псевдоним (сценическое имя) (Ru):";
                    lblTextEn.Text = "Nickname (En):";
                }break;
            }
        }

        private void rBtnSave_Click(object sender, EventArgs e)
        {

        }

        private void rBtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
