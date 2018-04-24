using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Dictionary;
using Telerik.WinControls.UI;
using WebAPIConnector;
using ipsmedserviceapp.Model;

namespace ipsTestExp
{
    public partial class DataChangeControl : UserControl
    {
        private bool isNewGroup = false;
        private ApiConnector _connector;
        private string _url;
        private List<CrkindGroup> temp;
        private Dictionary<string, string> dropList;
        public DataChangeControl()
        {
            InitializeComponent();
            rPanelKindName.Enabled = false;
            rPanelGroupName.Enabled = false;
        }

        public void InitializeConnectorAndUrl(ApiConnector aConn, string url)
        {
            _connector = aConn;
            _url = url;
        }

        internal void SetGroupDropList()
        {
            
            temp = _connector.GetList<CrkindGroup>(_url);
            dropList = new Dictionary<string, string>();
            dropList.Add(string.Empty, string.Empty);
            dropList.Add("0", "Нова група");

            foreach (var item in temp)
            {
                dropList.Add(item.CodeI.ToString(),item.Name);
            }
            rDropDownListGroup.DataSource = dropList.Values;
        }

        private void rDropDownListGroup_SelectedValueChanged(object sender, EventArgs e)
        {
            var v = rDropDownListGroup.SelectedItem.Value.ToString();
            foreach (var item in temp)
            {
                if (v == "Нова група")
                {
                    isNewGroup = true;
                    rPanelGroupName.Enabled = true;
                    rPanelKindName.Enabled = true;
                    return;
                }

                    isNewGroup = false;
                    rPanelGroupName.Enabled = false;

                if (v==item.Name)
                {

                    rPanelKindName.Enabled = true;
                    return;
                }
                    rPanelKindName.Enabled = false;

                
            }
        }

        private CrkindGroup PackageData()
        {
            CrkindGroup crkindGroup = new CrkindGroup();
            CopyrightKind tempCopyrightKind = new CopyrightKind();
            CopyrightKindTr[] tempCopyrightKindTr = new CopyrightKindTr[3];
            CrkindGroupTr[] tempCrkindGroupTr = new CrkindGroupTr[3];
            int codeP, codeChild = 0;
            if (isNewGroup)
            {
                codeP = Convert.ToInt32(dropList.Keys.Last()) + 1;
                tempCrkindGroupTr[0] = new CrkindGroupTr() { CodeI = codeP, Lang = "En", Name = rTxtBoxNameEn.Text };
                tempCrkindGroupTr[1] = new CrkindGroupTr() { CodeI = codeP, Lang = "Uk", Name = rTxtBoxNameUk.Text };
                tempCrkindGroupTr[2] = new CrkindGroupTr() { CodeI = codeP, Lang = "Ru", Name = rTxtBoxNameRu.Text };
            }
            else
            {
                codeP = Convert.ToInt32(dropList
                    .FirstOrDefault(x => x.Value == rDropDownListGroup.SelectedItem.Value.ToString()).Key);

                foreach (var itemsTr in temp)
                {
                    foreach (var tr in itemsTr.CrkindGroupTr)
                    {
                        if (tr.CodeI == codeP && tr.Lang == "En")
                            tempCrkindGroupTr[0] = new CrkindGroupTr() { CodeI = codeP, Lang = "En", Name = tr.Name };

                        if (tr.CodeI == codeP && tr.Lang == "Uk")
                            tempCrkindGroupTr[1] = new CrkindGroupTr() { CodeI = codeP, Lang = "Uk", Name = tr.Name };

                        if (tr.CodeI == codeP && tr.Lang == "Ru")
                            tempCrkindGroupTr[2] = new CrkindGroupTr() { CodeI = codeP, Lang = "Ru", Name = tr.Name };
                    }
                }
            }

            foreach (var items in temp)
            {
                if (items.CodeI == codeP)
                {
                    codeChild = items.CopyrightKind.Count + 1;
                }
            }
            

            tempCopyrightKindTr[0] = new CopyrightKindTr() { CodeI = codeChild, Lang = "En", Name = rTxtBoxKindEn.Text};
            tempCopyrightKindTr[1] = new CopyrightKindTr() { CodeI = codeChild, Lang = "Uk", Name = rTxtBoxKindUk.Text};
            tempCopyrightKindTr[2] = new CopyrightKindTr() { CodeI = codeChild, Lang = "Ru", Name = rTxtBoxKindRu.Text};

            tempCopyrightKind.CodeI = codeChild;
            tempCopyrightKind.Name = rTxtBoxKindUk.Text;
            tempCopyrightKind.CrGroupCode = codeP;
            tempCopyrightKind.AgrLicenseType = null;
            tempCopyrightKind.CopyrightKindTr = new List<CopyrightKindTr>
            {
                tempCopyrightKindTr[0], tempCopyrightKindTr[1], tempCopyrightKindTr[2]
            };

            crkindGroup.CodeI = codeP;
            crkindGroup.Name = tempCrkindGroupTr[1].Name;
            crkindGroup.CopyrightKind.Add(tempCopyrightKind);
            crkindGroup.CrkindGroupTr = new List<CrkindGroupTr>
            {
                tempCrkindGroupTr[0], tempCrkindGroupTr[1], tempCrkindGroupTr[2]
            };
            return crkindGroup;
        }

        public void AddNewItem()
        {
            bool act = _connector.NewItem(_url, PackageData());
            if (!act)
            {
                //MessageBox.Show("NO");
            }
        }
    }
}
