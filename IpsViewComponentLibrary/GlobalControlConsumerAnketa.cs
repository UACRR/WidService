using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IpsViewComponentLibrary
{
    public partial class GlobalControlConsumerAnketa : UserControl
    {
        private int _visiblePage;
        private readonly Dictionary<int,string[]> buttonNames = new Dictionary<int, string[]>
        {
            {1, new []{"","Адреса >"} },
            {2, new []{"< Назва","Керівники >"} },
            {3, new []{"< Адреса","Майданчики >"} },
            {4, new []{"< Керівники","Реквізити >"} },
            {5, new []{"< Майданчики","Договір >"} },
            {6, new []{"< Реквізити","Друк >"} },
            {7, new []{"< Договір","Зберегти"} },
            {11, new []{ "< Адреса", "Реквізити >" } },
            {12, new []{ "< Керівники", "Договір >" } }
        };

        private ButtonType _btnType = ButtonType.None;

        public bool IsContainPlaces { get; set; }

        public GlobalControlConsumerAnketa()
        {
            InitializeComponent();

            pageAnketaConsumer.SelectedPage = pvClientName;
            _visiblePage = 1;
            ChangeButtonsName(_visiblePage);
            btnBack.Visible = false;
            SetColorTabs();

            IsContainPlaces = false;
        }

        private bool Validator()
        {
            return true;
        }

        #region BUTTONS NAVIGATION
        // * * * BUTTON NEXT
        private void btnNext_Click(object sender, EventArgs e)
        {
            _btnType = ButtonType.Next;
            switch (_visiblePage)
            {
                case 1:
                    {
                        pageAnketaConsumer.SelectedPage = pvAddress;
                    }
                    break;
                case 2:
                    {
                        pageAnketaConsumer.SelectedPage = pvManagers;
                    }
                    break;
                case 3:
                    {
                        pageAnketaConsumer.SelectedPage = pvPlaces;
                    }
                    break;
                case 4:
                    {
                        pageAnketaConsumer.SelectedPage = pvBankRequisites;
                    }
                    break;
                case 5:
                    {
                        pageAnketaConsumer.SelectedPage = pvAgreement;
                    }
                    break;
                case 6:
                    {
                        pageAnketaConsumer.SelectedPage = pvPrint;
                    }
                    break;
                case 7:
                {
                    _btnType = ButtonType.None;
                        MessageBox.Show("bingo!");
                    
                }
                    break;
            }
        }

        // * * * BUTTON BACK
        private void btnBack_Click(object sender, EventArgs e)
        {
            _btnType = ButtonType.Previos;
            switch (_visiblePage)
            {
                case 1:
                    {
                        //nothing action
                    }
                    break;
                case 2:
                    {
                        pageAnketaConsumer.SelectedPage = pvClientName;
                    }
                    break;
                case 3:
                    {
                        pageAnketaConsumer.SelectedPage = pvAddress;
                    }
                    break;
                case 4:
                    {
                        pageAnketaConsumer.SelectedPage = pvManagers;
                    }
                    break;
                case 5:
                    {
                        pageAnketaConsumer.SelectedPage = pvPlaces;
                    }
                    break;
                case 6:
                    {
                        pageAnketaConsumer.SelectedPage = pvBankRequisites;
                    }
                    break;
                case 7:
                    {
                        pageAnketaConsumer.SelectedPage = pvAgreement;
                    }
                    break;
            }
        }

        // * * * Зміна написів на кнопках при здійсненні навігації
        private void ChangeButtonsName(int key)
        {

            string[] names = buttonNames[key];
            btnBack.Text = names[0];
            btnNext.Text = names[1];
            
            if(!IsContainPlaces)
            {
                if (key == 3)
                {
                    string[] namess = buttonNames[11];
                    btnBack.Text = namess[0];
                    btnNext.Text = namess[1];
                }
                else if (key == 5)
                {
                    string[] namess = buttonNames[12];
                    btnBack.Text = namess[0];
                    btnNext.Text = namess[1];
                }
            }
        }


        /// <summary>
        /// Set color page view tabs
        /// </summary>
        /// <param name="isNew">If new item set 'true' - set gray color, else 'false' - set default color</param>
        private void SetColorTabs(bool isNew = false)
        {
            switch (isNew)
            {
                case true:
                {
                    foreach (var page in pageAnketaConsumer.Pages)
                    {
                        page.Item.ForeColor = Color.DarkGray;
                    }
                    pageAnketaConsumer.Pages[0].Item.ForeColor = DefaultForeColor;

                }
                    break;

                case false:
                {
                    foreach (var page in pageAnketaConsumer.Pages)
                    {
                        page.Item.ForeColor = DefaultForeColor;
                    }
                }
                    break;
            }
        }

        #endregion

        private void pageAnketaConsumer_SelectedPageChanging(object sender, Telerik.WinControls.UI.RadPageViewCancelEventArgs e)
        {
            //перехід на вкладку майданчиків за умови що їх немає

            switch (_btnType)
            {
                case ButtonType.Next:
                {
                    if (e.Page.TabIndex == 3 && !IsContainPlaces)
                    {
                        _visiblePage++;
                        pageAnketaConsumer.SelectedPage = pvBankRequisites;
                        e.Cancel = true;
                    }
                    else
                    {
                        ChangeButtonsName(_visiblePage + 1);
                        if (_visiblePage == 1)
                            btnBack.Visible = true;
                        if (_visiblePage != 7)
                            _visiblePage++;
                        _btnType = ButtonType.None;

                    }
                }
                    break;

                case ButtonType.Previos:
                {
                    if (e.Page.TabIndex == 3 && !IsContainPlaces)
                    {
                        _visiblePage--;
                        pageAnketaConsumer.SelectedPage = pvManagers;
                        e.Cancel = true;
                    }
                    else
                    {
                        ChangeButtonsName(_visiblePage - 1);
                        if (_visiblePage == 2)
                            btnBack.Visible = false;
                        _visiblePage--;
                        _btnType = ButtonType.None;
                    }
                }
                    break;

                case ButtonType.None:
                {
                    if (e.Page.TabIndex == 3 && !IsContainPlaces)
                    {
                        e.Cancel = true;
                        return;
                    }
                        _visiblePage = e.Page.TabIndex + 1;
                    ChangeButtonsName(_visiblePage);
                    btnBack.Visible = e.Page.TabIndex > 0;
                }
                    break;
            }
        }
    }

    internal enum ButtonType
    {
        None,
        Next,
        Previos
    };

}
