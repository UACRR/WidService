using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace RadioStationReports
{
    public partial class FormSelectCustomer : Form
    {
        public class CustomerItem
        {
            public int CustId { get; set; }
            public string Name { get; set; }
            public string ShortName { get; set; }
        }

        public class PlaceItem
        {
            public int PlaceId { get; set; }
            public string PlaceName { get; set; }
            public string PlaceCity { get; set; }
            public string PlaceAddress { get; set; }
        }

        private List<CustomerItem> _foundCustomers = new List<CustomerItem>();
        private List<PlaceItem> _places = new List<PlaceItem>();

        public CustomerItem SelectedCustomer { get; set; }

        public FormSelectCustomer()
        {
            InitializeComponent();
        }
        private void FormSelectCustomer_Load(object sender, EventArgs e)
        {
            Configure();
        }

        private void Configure()
        {
            lvFoundCustomers.FullRowSelect = true;
            lvFoundCustomers.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvFoundCustomers.MultiSelect = false;
            lvFoundCustomers.View = View.Details;
            lvFoundCustomers.Columns.Add("Код", 60);
            lvFoundCustomers.Columns.Add("Коротка назва", 200);
            lvFoundCustomers.Columns.Add("Повна назва", 600);

            lvPlaces.FullRowSelect = true;
            lvPlaces.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvPlaces.MultiSelect = false;
            lvPlaces.View = View.Details;
            lvPlaces.Columns.Add("Код", 60);
            lvPlaces.Columns.Add("Назва", 200);
            lvPlaces.Columns.Add("Місто", 200);
            lvPlaces.Columns.Add("Адреса", 200);

            btnApply.Enabled = false;
        }

        private void FillCustomers()
        {
            Helpers.RunSql(cmd =>
            {
                cmd.CommandText = @"
                    select distinct t1.CustId, isnull(t1.Name, ''), isnull(t1.ShortName, '')
                    from MediaService..vCustomerNamesFull t1
                        join MediaService..ClnBusinessPlace t2 on t1.CustId = t2.CustId
	                    join MediaService..LicenseAgreement t3 on t1.CustId = t3.CustId
                        --join MediaService..LicenseAgrParam t4 on t3.LicId = t4.LicId
                    where
                        t3.licStatus = 2 -- Active
                        --and getdate() between t4.dateBegin and t4.dateEnd
                        and 
                        (
                               t1.Name like @Text
                            or t1.ShortName like @Text
	                        or t2.PlaceName like @Text
                        )
                    ";
                cmd.Parameters.AddWithValue("@Text", $"%{tbSearchFilter.Text}%");
                using (var r = cmd.ExecuteReader())
                {
                    _foundCustomers.Clear();
                    while (r.Read())
                    {
                        _foundCustomers.Add(new CustomerItem
                        {
                            CustId = r.GetInt32(0),
                            Name = r.GetString(1),
                            ShortName = r.GetString(2),
                        });
                    }
                }
            });

            lvFoundCustomers.Items.Clear();
            _foundCustomers.ForEach(x =>
            {
                var item = lvFoundCustomers.Items.Add(x.CustId.ToString());
                item.SubItems.Add(x.ShortName);
                item.SubItems.Add(x.Name);
                item.Tag = x;
            });
        }

        private void FillPlaces()
        {
            if(SelectedCustomer == null)
            {
                _places.Clear();
                lvPlaces.Items.Clear();
                return;
            }

            Helpers.RunSql(cmd =>
            {
                cmd.CommandText = @"
                    select 
	                      PlaceId
	                    , isnull(PlaceName, '')
	                    , isnull(PlaceCity, '')
	                    , isnull(PlaceAddress, '')
                    from MediaService..ClnBusinessPlace
                    where CustId = @CustId
                ";
                cmd.Parameters.AddWithValue("@CustId", SelectedCustomer.CustId);
                using (var r = cmd.ExecuteReader())
                {
                    _places.Clear();
                    while (r.Read())
                    {
                        _places.Add(new PlaceItem
                        {
                            PlaceId = r.GetInt32(0),
                            PlaceName = r.GetString(1),
                            PlaceCity = r.GetString(2),
                            PlaceAddress = r.GetString(2),
                        });
                    }
                }
            });

            lvPlaces.Items.Clear();
            _places.ForEach(x =>
            {
                var item = lvPlaces.Items.Add(x.PlaceId.ToString());
                item.SubItems.Add(x.PlaceName);
                item.SubItems.Add(x.PlaceCity);
                item.SubItems.Add(x.PlaceAddress);
                item.Tag = x;
            });
        }

        private void btnSearchCustomer_Click(object sender, EventArgs e)
        {

            lvFoundCustomers.Items.Clear();
            _foundCustomers.Clear();

            var text = tbSearchFilter.Text;
            if (string.IsNullOrEmpty(text))
            {
                return;
            }

            FillCustomers();
        }

        private void UpdateControls()
        {
            if (SelectedCustomer == null)
            {
                btnApply.Enabled = false;
            }
            else
            {
                btnApply.Enabled = true;
            }

            btnSearchCustomer.Enabled = !string.IsNullOrEmpty(tbSearchFilter.Text.Trim());
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            SelectedCustomer = lvFoundCustomers.SelectedItems[0].Tag as CustomerItem;
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            SelectedCustomer = null;
            Close();
        }

        private void tbSearchFilter_TextChanged(object sender, EventArgs e)
        {
            SelectedCustomer = null;
            UpdateControls();
        }

        private void lvFoundCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedCustomer = lvFoundCustomers.SelectedItems.Count == 0 ?
                null : (CustomerItem)lvFoundCustomers.SelectedItems[0].Tag;

            FillPlaces();
            UpdateControls();
        }
    }
}
