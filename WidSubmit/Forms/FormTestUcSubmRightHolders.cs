using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WidSubmit.UcSubmRightHolders;

namespace WidSubmit
{
    public partial class FormTestUcSubmRightHolders : Form
    {
        private bool _isSuscribedToEvents;

        public FormTestUcSubmRightHolders()
        {
            InitializeComponent();
        }

        private void FormTest_Load(object sender, EventArgs e)
        {
            //ucSubmRightHolders.Init(PresentationMode.CUR_SUBM);
            //SuscribeToEvents();
            //
            //ucSubmRightHolders.UpdateContent(2);
        }

        private void SuscribeToEvents()
        {
            if(_isSuscribedToEvents) { return; }
            ucSubmRightHolders.RightHolderSelected += OnRightHolderSelected;
            ucSubmRightHolders.RightHolderUnselected += OnRightHolderUnselected;
            ucSubmRightHolders.EditRightHoldersClicked += OnEditRightHoldersClicked;

            _isSuscribedToEvents = true;
        }

        public void OnRightHolderSelected(object sender, RightHolderSelectedEventArgs e)
        {
           MessageBox.Show(e.RightHolder == null ? "<ALL RIGHT HOLDERS>" : e.RightHolder.Name);
        }

        public void OnRightHolderUnselected(object sender, EventArgs e)
        {
           MessageBox.Show("UNSELECTED");
        }

        public void OnEditRightHoldersClicked(object sender, EventArgs e)
        {
           MessageBox.Show("CLICKED");
        }

        private void btnCurSubm_Click(object sender, EventArgs e)
        {
            ucSubmRightHolders.Init(PresentationMode.CUR_SUBM);
            SuscribeToEvents();
            
            ucSubmRightHolders.UpdateContent(2);
        }

        private void btnPrevSubm_Click(object sender, EventArgs e)
        {
            ucSubmRightHolders.Init(PresentationMode.PREV_SUBM);
            SuscribeToEvents();
            
            ucSubmRightHolders.UpdateContent(2);
        }

        private void btnSelectRightHolders_Click(object sender, EventArgs e)
        {
            ucSubmRightHolders.Init(PresentationMode.RIGHTHOLDER_SELECT);
            SuscribeToEvents();
            
            ucSubmRightHolders.UpdateContent(2);
        }
    }
}
