using ipsFormsDesign.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.CatalogControls
{
    public partial class ChangeCommentForm : RadForm
    {
        private const string Title = "Змінити коментар файлу ";

        public ChangeCommentForm(CatalogFile catalogFile)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            Text = string.Concat(Title, catalogFile.FileName);
            ctrlComment.DataSource = catalogFile;
        }

        public sealed override string Text
        {
            get => base.Text;
            set => base.Text = value;
        }
    }
}
