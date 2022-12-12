using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using InvoicingLib;
using DdexInvoicingLib;
using System.Configuration;

namespace DdexInvoicing
{
    public partial class UcMwSearch : UserControl
    {
        private class FilterControlSet
        {
            public int idx { get; set; }
            public RadCheckBox chk { get; set; }
            public Label lab { get; set; }
            public FlowLayoutPanel panel { get; set; }
            public RadDropDownButton oper { get; set; }
            public RadDropDownList value { get; set; }
            public RadDropDownButton altNames { get; set; }
            public RadDropDownButton variants { get; set; }
            public LinkLabel showVariants { get; set; }
            public string operItemName { get; set; }
            public string altNamesItemName { get; set; }
            public string variantsItemName { get; set; }

            private string GetMenuItemName(RadDropDownButton btn)
            {
                return btn.Items.Single(x => ((RadMenuItemInfo)x.Tag).isCurrent == true).Name;
            }

            public bool IsExactSelected()
            {
                if (oper == null) return false;
                return GetMenuItemName(oper).Equals("Exact", StringComparison.OrdinalIgnoreCase);
            }
            public bool IsStartsWithSelected()
            {
                if (oper == null) return false;
                return GetMenuItemName(oper).Equals("StartsWith", StringComparison.OrdinalIgnoreCase);
            }
            public bool IsContainsSelected()
            {
                if (oper == null) return false;
                return GetMenuItemName(oper).Equals("Contains", StringComparison.OrdinalIgnoreCase);
            }
            public bool IsContainsWordSelected()
            {
                if (oper == null) return false;
                return GetMenuItemName(oper).Equals("ContainsWord", StringComparison.OrdinalIgnoreCase);
            }
            public bool IsPatternSelected()
            {
                if (oper == null) return false;
                return GetMenuItemName(oper).Equals("Pattern", StringComparison.OrdinalIgnoreCase);
            }
            public bool IsUseAltNamesSelected()
            {
                if (altNames == null) return false;
                return GetMenuItemName(altNames).Equals("Use", StringComparison.OrdinalIgnoreCase);
            }
            public bool IsUseVariantsSelected()
            {
                if (variants == null) return false;
                return GetMenuItemName(variants).StartsWith("Use", StringComparison.OrdinalIgnoreCase);
            }
            public bool IsShowVariantsSelected()
            {
                if (variants == null) return false;
                return GetMenuItemName(variants).StartsWith("Show", StringComparison.OrdinalIgnoreCase) ||
                    GetMenuItemName(variants).StartsWith("UseAndShow", StringComparison.OrdinalIgnoreCase);
            }
       }
        private class RadMenuItemInfo
        {
            public FilterControlSet filterControlSet { get; set; }
            public bool isCurrent { get; set; }
        }
        public class ObjIdSelectedEventArgs : EventArgs
        {
            public int ObjId { get; set; }
        }
        public class WicSelectedEventArgs : EventArgs
        {
            public int Wic { get; set; }
        }

        private bool _showDetails;
        private List<FilterControlSet> _filterControls;

        public event EventHandler<ObjIdSelectedEventArgs> ObjIdSelectedEvent;
        public event EventHandler<WicSelectedEventArgs> WicSelectedEvent;

        public UcMwSearch()
        {
            InitializeComponent();

            gridSearchResults.MasterView.TableSearchRow.ShowCloseButton = false;
            gridSearchResults.MasterTemplate.DataView.BypassSort = true;

            _filterControls = new List<FilterControlSet>
            {
                new FilterControlSet
                {
                    idx = 0,
                    chk = chkName,
                    lab = labName,
                    panel = panelName,
                    oper = ddbNameFilterOper,
                    value = cbNameValue,
                    altNames = ddbAltNames,
                    variants = ddbNameVariants,
                },
                new FilterControlSet
                {
                    idx = 1,
                    chk = chkAuthors,
                    lab = labAuthors,
                    panel = panelAuthors,
                    oper = ddbAuthorFilterOper,
                    value = cbAuthorValue,
                    variants = ddbAuthorVariants,
                },
                new FilterControlSet
                {
                    idx = 2,
                    chk = chkPerformers,
                    lab = labPerformers,
                    panel = panelPerformers,
                    oper = ddbPerformerFilterOper,
                    value = cbPerformerValue,
                    variants = ddbPerformerVariants,
                 },
                new FilterControlSet
                {
                    idx = 3,
                    chk = chkIswc,
                    lab = labIswc,
                    panel = panelIswc,
                    value = cbIswcValue,
                },
            };

            _filterControls.ForEach(x =>
            {
                if (x.chk != null) x.chk.Tag  = x;
                if (x.lab != null) x.lab.Tag = x;
                if (x.panel != null) x.panel.Tag = x;
                if (x.oper != null) x.oper.Tag = x;
                if (x.value != null)
                {
                    x.value.Tag = x;
                    x.value.TextChanged += (object sender, EventArgs e) => RefreshVariants((FilterControlSet)((RadDropDownList)sender).Tag);
                }
                if (x.altNames != null) x.altNames.Tag = x;
                if (x.variants != null) x.variants.Tag = x;
            });

            labTitle.Text = "Пошук творів в БД товариства (WID/MediService)";
            labInfo.Text = "Користовуючись налаштуваннями пошуку знизу знайдіть потрібний музични твір і натисніть Застосувати для його пов'язання з селектованим рядком звіта";
            labPrompt.Text = "Вимоги до творів:";
            labStatus.Text = "Пощук не розпочато";

            ConfigureSearchPanels();

            _showDetails = false;
            chkName.Checked = true;
            RefreshControls();
        }

        public void AdviseSearchInfo(string resourceTitle, string title, string authors, string performers, string iswc)
        {
            cbNameValue.Items.Clear();
            cbNameValue.Items.Add(resourceTitle);
            if (!title.Equals(resourceTitle, StringComparison.OrdinalIgnoreCase))
            {
                cbNameValue.Items.Add(title);
            }
            cbNameValue.Text = string.IsNullOrEmpty(title) ? resourceTitle : title;

            cbAuthorValue.Items.Clear();
            var authorParts = authors.Split('|', '/').ToList();
            authorParts.ForEach(x =>
            {
                cbAuthorValue.Items.Add(x);
            });
            cbAuthorValue.Text = authorParts[0];

            cbPerformerValue.Items.Clear();
            var performerParts = performers.Split('|', '/').ToList();
            performerParts.ForEach(x =>
            {
                cbPerformerValue.Items.Add(x);
            });
            cbPerformerValue.Text = performerParts[0];

            cbIswcValue.Text = iswc;

            gridSearchResults.DataSource = null;
            labStatus.Text = "Пощук не розпочато";
        }

        private void ConfigureSearchPanels()
        {
            _filterControls.ForEach(x =>
            {
                x.chk.ToggleStateChanged += (object sender, StateChangedEventArgs args) => ProcessCheckToggle(x.chk);

                if (x.oper != null)
                {
                    var isNameRow = x.lab.Name.Equals("labName", StringComparison.OrdinalIgnoreCase);
                    x.oper.Items.Clear();
                    AddMenuItem(x.oper, "Exact", isNameRow ? "Співпадає з" : "співпадає з", new RadMenuItemInfo { filterControlSet = x, isCurrent = true,});
                    AddMenuItem(x.oper, "StartsWith", isNameRow ? "Починається з" : "починається з", new RadMenuItemInfo { filterControlSet = x, isCurrent = false, });
                    AddMenuItem(x.oper, "Contains", isNameRow ? "Містить текст" : "містить текст", new RadMenuItemInfo { filterControlSet = x, isCurrent = false, });
                    AddMenuItem(x.oper, "ContainsWord", isNameRow ? "Містить слово" : "містить слово", new RadMenuItemInfo { filterControlSet = x, isCurrent = false, });
                    AddMenuItem(x.oper, "Pattern", isNameRow ? "Відповідає шаблону" : "відповідає шаблону", new RadMenuItemInfo { filterControlSet = x, isCurrent = false, });
                    x.oper.Text = isNameRow ? "Співпадає з" : "співпадає з";
                }

                if(x.altNames != null)
                {
                    x.altNames.Items.Clear();
                    AddMenuItem(x.altNames, "Use", "враховуючи", new RadMenuItemInfo { filterControlSet = x, isCurrent = true, });
                    AddMenuItem(x.altNames, "Ignore", "не врахувуючи", new RadMenuItemInfo { filterControlSet = x, isCurrent = false, });
                    x.altNames.Text = "враховуючи";
                }

                if (x.variants != null)
                {
                    x.variants.Items.Clear();
                    AddMenuItem(x.variants, "Show", "показати для довідки", new RadMenuItemInfo { filterControlSet = x, isCurrent = false, });
                    AddMenuItem(x.variants, "UseAndShow", "показати і врахувати в пошуку", new RadMenuItemInfo { filterControlSet = x, isCurrent = false, });
                    AddMenuItem(x.variants, "UseNotShow", "врахувати в пошуку без показу", new RadMenuItemInfo { filterControlSet = x, isCurrent = false, });
                    AddMenuItem(x.variants, "Ignore", "ігнорувати", new RadMenuItemInfo { filterControlSet = x, isCurrent = true, });
                    x.variants.Text = "ігнорувати";
                }
            });
        }

        private void RefreshControls()
        {
            pictExpand.Image = ilExpandCollapse.Images[_showDetails ? 1 : 0];
            if (_showDetails)
            {
                _filterControls.ForEach(x =>
                {
                    x.chk.Visible = true;
                    x.lab.Visible = true;
                    x.panel.Visible = x.chk.Checked;
                });
            }
            else
            {
                _filterControls.ForEach(x =>
                {
                    x.chk.Visible = false;
                    x.lab.Visible = x.chk.Checked;
                    x.panel.Visible = x.chk.Checked;
                });
            }
        }

        private void ProcessCheckToggle(RadCheckBox chk)
        {
            var checkedExist = _filterControls.Any(x => x.chk.Checked);

            if (!checkedExist)
            {
                chk.Checked = true;
                return;
            }

            // Checked exiists here
            if (chk.Checked)
            {
                if (!ModifierKeys.HasFlag(Keys.Control) || chk == chkIswc)
                {
                    _filterControls.Where(x => x.chk != chk).ToList().ForEach(x => x.chk.Checked = false);
                }
                else if (chk != chkIswc)
                {
                    chkIswc.Checked = false;
                }
            }
            RefreshControls();
        }

        private void pictExpand_Click(object sender, EventArgs e)
        {
            _showDetails = !_showDetails;
            RefreshControls();
        }

        private void pictExpand_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show(_showDetails ? "Згорути умови пошуку" : "Розгорнути умови пошуку", pictExpand);
        }

        private void AddMenuItem(RadDropDownButton btn, string name, string text, RadMenuItemInfo info)
        {
            var item = new RadMenuItem
            {
                Name = name,
                Text = text,
                Tag = info,
            };
            item.Click += new System.EventHandler(OnDropDownButtonClick);
            btn.Items.Add(item);
        }

        private void OnDropDownButtonClick(object sender, EventArgs e)
        {
            var item = sender as RadMenuItem;
            var btn = item.Owner as RadDropDownButtonElement;
            btn.Text = item.Text;
            foreach(var curItem in btn.Items)
            {
                ((RadMenuItemInfo)curItem.Tag).isCurrent = (curItem == item);
            }
            timerRefreshVariants.Enabled = true;
            timerRefreshVariants.Tick += (object s, EventArgs a) =>
            {
                timerRefreshVariants.Enabled = false;
                RefreshVariants(((RadMenuItemInfo)item.Tag).filterControlSet);
            };
        }

        private void TimerRefreshVariants_Tick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void RefreshVariants(FilterControlSet filterControlSet)
        {
            if(filterControlSet.variants == null)
            {
                return;
            }
            var variantTexts = TransLiterator.BuildVariants(filterControlSet.value.Text);
            var panel = filterControlSet.panel;
            var variants = filterControlSet.variants;
            while (true)
            {
                var idx = panel.Controls.Count - 1;
                var ctrl = panel.Controls[idx];
                if (ctrl.Tag != null)
                {
                    break;
                }
                panel.Controls.RemoveAt(idx);
            }

            var currenMenuItemName = variants.Items.Single(x => ((RadMenuItemInfo)x.Tag).isCurrent == true).Name;
            if (!filterControlSet.IsShowVariantsSelected())
            {
                return;
            }

            variantTexts.Where(x => !x.Equals(filterControlSet.value.Text, StringComparison.OrdinalIgnoreCase)).ToList().ForEach(x =>
            {
                var label = new Label
                {
                    Text = x,
                    AutoSize = true,
                    Margin = new Padding(3, 3, 3, 0),
                    Padding = new Padding(3, 3, 3, 3),
                    BackColor = Color.LightBlue,
                    Cursor = Cursors.Hand,
                };
                label.Click += (object sender, EventArgs e) =>
                {
                    var lab = (Label)sender;
                    var text = lab.Text;
                    var fcs = (FilterControlSet)lab.Parent.Tag;
                    fcs.value.Text = text;
                };

                panel.Controls.Add(label);
            });
        }

        private List<MwSearchBase.TitleAuthorsPerformersAggr> Search(MwSearchBase search)
        {
            search.CrearSearchConditions();
            _filterControls.Where(x => x.chk.Checked).ToList().ForEach(x =>
            {
                var searchValue = x.value.Text;
                var searchField = (MwSearchBase.SearchField)x.idx;
                var searchMethod = x.IsExactSelected() ? MwSearchBase.SearchMethod.Exact :
                    x.IsStartsWithSelected() ? MwSearchBase.SearchMethod.StartsWith :
                    x.IsContainsSelected() ? MwSearchBase.SearchMethod.Contains :
                    x.IsContainsWordSelected() ? MwSearchBase.SearchMethod.ContainsWord :
                    x.IsPatternSelected() ? MwSearchBase.SearchMethod.Pattern :
                    MwSearchBase.SearchMethod.Exact;
                var searchVariants = new List<string> { searchValue };
                if(x.IsUseVariantsSelected())
                {
                    var variantTexts = TransLiterator.BuildVariants(searchValue);
                    searchVariants = searchVariants.Union(variantTexts).ToList();
                }
                if (!string.IsNullOrEmpty(searchValue))
                {
                    search.AddSearchCondition(searchField,
                        searchMethod,
                        searchVariants,
                        x.IsUseAltNamesSelected());
                }
            });
           
            return search.SearchTitleAuthorsPerformers();
        }

        private List<MwSearchBase.TitleAuthorsPerformersAggr> SearchWid()
        {
            var search = new WidMwSearch(ConfigurationManager.AppSettings["ConnectionStringWid"]);
            return Search(search);
        }

        private List<MwSearchBase.TitleAuthorsPerformersAggr> SearchMs()
        {
            if (_filterControls[3].chk.Checked) // Do not processs ISWC search
            {
                return new List<MwSearchBase.TitleAuthorsPerformersAggr>();
            }
            var search = new MsMwSearch(ConfigurationManager.AppSettings["ConnectionStringMs"]);
            return Search(search);
        }

        private void BeforeSearch()
        {
            Cursor.Current = Cursors.WaitCursor;
            labStatus.Text = "Виконується пошук";
            gridSearchResults.DataSource = null;
            labStatus.Refresh();
            gridSearchResults.Refresh();
        }

        private void AfterSearch()
        {
            labStatus.Text = "Пошук завершено";
            Cursor.Current = Cursors.Default;
        }

        private void btnSearchWid_Click(object sender, EventArgs e)
        {
            BeforeSearch();
            gridSearchResults.DataSource = SearchWid();
            AfterSearch();
        }

        private void btnSearchMs_Click(object sender, EventArgs e)
        {
            BeforeSearch();
            gridSearchResults.DataSource = SearchMs();
            AfterSearch();
        }

        private void btnSearchBoth_Click(object sender, EventArgs e)
        {
            BeforeSearch();
            var widResult = SearchWid();
            var msResult = SearchMs();
            var result = widResult != null ? widResult.Union(msResult).ToList() : msResult;
            if (result != null)
            {
                int seqNr = 1;
                result.ForEach(x => x.SeqNr = seqNr++);
            }
            gridSearchResults.DataSource = result;
            AfterSearch();
        }

        private void gridSearchResults_CellClick(object sender, GridViewCellEventArgs e)
        {
            if (e.Column != null && e.Column.Name == "Action")
            {
                var row = (MwSearchBase.TitleAuthorsPerformersAggr)gridSearchResults.CurrentRow.DataBoundItem;
                var wic = row.Wic;
                var objId = row.ObjId;
                if(WicSelectedEvent != null && wic != null)
                {
                    WicSelectedEvent(sender, new WicSelectedEventArgs { Wic = (int)wic, });
                }
                if (ObjIdSelectedEvent != null && objId != null)
                {
                    ObjIdSelectedEvent(sender, new ObjIdSelectedEventArgs { ObjId = (int)objId, });
                }
            }
        }
    }
}
