using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary.Utilities;
using IpsCommonTypes.Types.ObjectRightInfoWID;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.ObjectRightControls
{
    public partial class ObjectRightWIDView : RadForm
    {
        private readonly RegisterWIDService _service;
        private List<WIDObjectAuthorsCommunities> _objectAuthorsCommunitieses = new List<WIDObjectAuthorsCommunities>();

        public ObjectRightWIDView()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            gvWIDObjectAuthors.SubscribeToolTipTextNeeded();
            gvWIDObjectAuthorsCommunities.SubscribeToolTipTextNeeded();
            gvWIDObjectAlternativeNames.SubscribeToolTipTextNeeded();
            gvWIDObjectPerformers.SubscribeToolTipTextNeeded();

            _service = RegisterWIDService.GetInstance();
        }

        public void LoadData(int wic)
        {
            WrapWIDObjectRightInfo objectRightWrap = _service.GetObjectRightWIDByWIC(wic);
            bsWIDiswc.DataSource = objectRightWrap.WIDiswc;
            bsWIDObjectRight.DataSource = objectRightWrap.WIDObjectRight;
            // ініціалізація спільнот автора до присвоєння bs авторів
            _objectAuthorsCommunitieses = objectRightWrap.WIDObjectAuthorsCommunities ?? new List<WIDObjectAuthorsCommunities>();
            bsWIDObjectAuthors.DataSource = objectRightWrap.WIDObjectAuthors;
            bsWIDObjectAlternativeNames.DataSource = objectRightWrap.WIDObjectAlternativeNames;
            bsWIDObjectPerformers.DataSource = objectRightWrap.WIDObjectPerformers;
        }

        private void gvWIDObjectAuthors_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            if(!(e.CurrentRow?.DataBoundItem is WIDObjectAuthors item))
                return;

            var filteredList = _objectAuthorsCommunitieses.Where(rec => rec.IP_BASE_NR == item.IP_BASE_NR).ToList();
            bsWIDObjectAuthorsCommunities.DataSource = filteredList;
        }
    }
}
