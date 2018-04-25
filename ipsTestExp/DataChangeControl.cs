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
        public bool VisibleDropBox { get; set; }
        private int IdItem { get; set; }
        private int IdItemChild { get; set; }
        private const sbyte code = 0;
        private bool isNewGroup = false;
        private ApiConnector _connector;
        private string _url;
        private List<CrkindGroup> temp;
        private Dictionary<string, string> dropList;
        public DataChangeControl()
        {
            InitializeComponent();
            //rPanelKindName.Enabled = false;
            //rPanelGroupName.Enabled = false;
            
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
            dropList.Add("-1", "Нова група");

            foreach (var item in temp)
            {
                dropList.Add(item.CodeI.ToString(),item.Name);
            }
            rDropDownListGroup.DataSource = dropList.Values;
        }

        
        /// <summary>
        /// Включеність компонентів; 0 - додавання нового елемента; 1 - редагування існуючого
        /// </summary>
        /// <param name="visible"></param>
        /// <param name="type"></param>
        public void SetVisible(byte type)
        {
            switch (type)
            {
                case 0:
                {
                    rDropDownListGroup.Enabled = true;
                    rPanelKindName.Enabled = false;
                    rPanelGroupName.Enabled = false;

                } break;

                case 1:
                {
                    rDropDownListGroup.Enabled = false;
                    rPanelKindName.Enabled = true;
                    rPanelGroupName.Enabled = true;

                } break;
            }
            

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
            int codeP;
            if (isNewGroup)
            {
                tempCrkindGroupTr[0] = new CrkindGroupTr() { CodeI = code, Lang = "En", Name = rTxtBoxNameEn.Text };
                tempCrkindGroupTr[1] = new CrkindGroupTr() { CodeI = code, Lang = "Uk", Name = rTxtBoxNameUk.Text };
                tempCrkindGroupTr[2] = new CrkindGroupTr() { CodeI = code, Lang = "Ru", Name = rTxtBoxNameRu.Text };
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


            

            tempCopyrightKindTr[0] = new CopyrightKindTr() { CodeI = code, Lang = "En", Name = rTxtBoxKindEn.Text};
            tempCopyrightKindTr[1] = new CopyrightKindTr() { CodeI = code, Lang = "Uk", Name = rTxtBoxKindUk.Text};
            tempCopyrightKindTr[2] = new CopyrightKindTr() { CodeI = code, Lang = "Ru", Name = rTxtBoxKindRu.Text};

            tempCopyrightKind.CodeI = code;
            tempCopyrightKind.Name = rTxtBoxKindUk.Text;
            tempCopyrightKind.CrGroupCode = tempCrkindGroupTr[0].CodeI;
            tempCopyrightKind.AgrLicenseType = null;
            tempCopyrightKind.CopyrightKindTr = new List<CopyrightKindTr>
            {
                tempCopyrightKindTr[0], tempCopyrightKindTr[1], tempCopyrightKindTr[2]
            };

            crkindGroup.CodeI = tempCrkindGroupTr[1].CodeI;
            crkindGroup.Name = tempCrkindGroupTr[1].Name;
            crkindGroup.CopyrightKind.Add(tempCopyrightKind);
            crkindGroup.CrkindGroupTr = new List<CrkindGroupTr>
            {
                tempCrkindGroupTr[0], tempCrkindGroupTr[1], tempCrkindGroupTr[2]
            };
            return crkindGroup;
        }

        private CrkindGroup PackageDataForUpdate()
        {
            CrkindGroup crkindGroup = new CrkindGroup();
            CopyrightKind tempCopyrightKind = new CopyrightKind();
            CopyrightKindTr[] tempCopyrightKindTr = new CopyrightKindTr[3];
            CrkindGroupTr[] tempCrkindGroupTr = new CrkindGroupTr[3];
            
            
            
            tempCrkindGroupTr[0] = new CrkindGroupTr() { CodeI = IdItem, Lang = "En", Name = rTxtBoxNameEn.Text };
            tempCrkindGroupTr[1] = new CrkindGroupTr() { CodeI = IdItem, Lang = "Uk", Name = rTxtBoxNameUk.Text };
            tempCrkindGroupTr[2] = new CrkindGroupTr() { CodeI = IdItem, Lang = "Ru", Name = rTxtBoxNameRu.Text };
            
            tempCopyrightKindTr[0] = new CopyrightKindTr() { CodeI = IdItem, Lang = "En", Name = rTxtBoxKindEn.Text };
            tempCopyrightKindTr[1] = new CopyrightKindTr() { CodeI = IdItem, Lang = "Uk", Name = rTxtBoxKindUk.Text };
            tempCopyrightKindTr[2] = new CopyrightKindTr() { CodeI = IdItem, Lang = "Ru", Name = rTxtBoxKindRu.Text };

            tempCopyrightKind.CodeI = IdItemChild;
            tempCopyrightKind.Name = rTxtBoxKindUk.Text;
            tempCopyrightKind.CrGroupCode = tempCrkindGroupTr[0].CodeI;
            tempCopyrightKind.AgrLicenseType = null;
            tempCopyrightKind.CopyrightKindTr = new List<CopyrightKindTr>
            {
                tempCopyrightKindTr[0], tempCopyrightKindTr[1], tempCopyrightKindTr[2]
            };

            crkindGroup.CodeI = IdItem;
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

        public void SetEditData(DataChangeCtrlClass change)
        {
            IdItem = change.CodeParent;
            IdItemChild = change.CodeChild;
            rDropDownListGroup.SelectedValueChanged -= rDropDownListGroup_SelectedValueChanged;
            rDropDownListGroup.Items[change.CodeParent + 1].Selected = true;
            rDropDownListGroup.SelectedValueChanged += rDropDownListGroup_SelectedValueChanged;

            rTxtBoxNameEn.Text = change.NameGroupEn;
            rTxtBoxNameRu.Text = change.NameGroupRu;
            rTxtBoxNameUk.Text = change.NameGroupUk;

            rTxtBoxKindEn.Text = change.NameKindEn;
            rTxtBoxKindRu.Text = change.NameKindRu;
            rTxtBoxKindUk.Text = change.NameKindUk;
        }

        public void SaveEditItem()
        {
            bool act = _connector.UpdateItem(_url, IdItem.ToString(), PackageDataForUpdate());
        }

        public void DeleteItem()
        {
            bool act = _connector.DeleteItem(_url, "0");
        }
    }
}

