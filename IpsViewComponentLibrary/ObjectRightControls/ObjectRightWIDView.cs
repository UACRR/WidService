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
            bsWIDObjectRight.DataSource = objectRightWrap.WIDObjectRight;
            bsWIDObjectAuthors.DataSource = objectRightWrap.WIDObjectAuthors;
            bsWIDObjectAuthorsCommunities.DataSource = objectRightWrap.WIDObjectAuthorsCommunities;
            bsWIDObjectAlternativeNames.DataSource = objectRightWrap.WIDObjectAlternativeNames;
            bsWIDObjectPerformers.DataSource = objectRightWrap.WIDObjectPerformers;
        }
    }
}
