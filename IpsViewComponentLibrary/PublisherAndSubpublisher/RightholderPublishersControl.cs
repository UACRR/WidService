using System.Windows.Forms;
using ipsFormsDesign.Services;

namespace IpsViewComponentLibrary.PublisherAndSubpublisher
{
    public partial class RightholderPublishersControl : UserControl
    {
        public RightholderPublishersControl()
        {
            InitializeComponent();
            ctrlGridRowCountPublishers.RadGridViewDataSource = gvPublishers;
        }

        public void LoadData(int custId)
        {
            var publishersList = PublisherAndSubpublisherSevice.GetInstance().GetPublisherAndSubpublisherList(custId);
            bsPublisherAndSubpublisherView.DataSource = publishersList;
        }
    }
}
