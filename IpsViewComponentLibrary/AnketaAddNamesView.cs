using ipsFormsDesign.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace IpsViewComponentLibrary
{
    public partial class AnketaAddNamesView : Telerik.WinControls.UI.RadForm
    {
        private List<AnketaAddName> _names = new List<AnketaAddName> {
            new AnketaAddName { Lang = "Ru" },
            new AnketaAddName { Lang = "En" },
        };

        private ICollection<AnketaAddName> _inputAddNames;

        public AnketaAddNamesView(ICollection<AnketaAddName> anketaAddNames)
        {
            InitializeComponent();

            InitializeBindings();

            _inputAddNames = anketaAddNames;

            UpdateNamesTable();
        }

        private void InitializeBindings()
        {
            anketaAddNameBindingSource.DataSource = _names;
            gvNames.DataSource = anketaAddNameBindingSource;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            foreach (var n in _names)
            {
                if (string.IsNullOrEmpty(n.LastName) && string.IsNullOrEmpty(n.FirstName) && string.IsNullOrEmpty(n.SurName))
                {
                    var addNameToRemove = _inputAddNames.ToList().Where(x => x.Lang == n.Lang);

                    foreach(var item in addNameToRemove)
                    {
                        _inputAddNames.Remove(item);
                    }
                }
                else
                {
                    var editedName = _inputAddNames.FirstOrDefault(x => x.Lang == n.Lang);

                    if (editedName == null)
                    {
                        _inputAddNames.Add(n);
                    }
                    else
                    {
                        editedName.LastName = n.LastName;
                        editedName.FirstName = n.FirstName;
                        editedName.SurName = n.SurName;
                    }
                }
            }
        }

        private void UpdateNamesTable()
        {
            foreach (var n in _names)
            {
                var foundedName = _inputAddNames.FirstOrDefault(x => x.Lang == n.Lang);

                if (foundedName != null)
                {
                    n.LastName = foundedName.LastName;
                    n.FirstName = foundedName.FirstName;
                    n.SurName = foundedName.SurName;
                }
            }
        }
    }
}
