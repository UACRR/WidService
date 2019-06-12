using System;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.Extensions;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.ConsumerControls.SmallRight.Reports
{
    public partial class CompositionOfReport : RadForm
    {
        private const string EmptyRowDeletedMsg = "Записи в яких незаповнена \"Творча роль\" або \"ПІБ автора\" не будуть збережені! Продовжити?";
        private const string EmptyItemNameWarningMsg = "Назва твору не може бути пустою!";
        private const string NotSelectedGenreWarningMsg = "Оберіть жанр твору!";
        private const string DeleteItemConfirmMsg = "Видалити автора?";

        public CompositionOfReport(RegisterItem registerItem)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            ctrlSaveCancelButtons.ButtonSaveDialogResult = DialogResult.None;
            ctrlSaveCancelButtons.SaveClck += btnSave_Click;
            bsDictCreativeRole.DataSource = IpsGlobal.AnketaDictionaties.creativeRoleType.Where(rec => rec.CategoryCode == 5 && rec.Crtype == 1);
            bsDictGenreType.DataSource = IpsGlobal.AnketaDictionaties.genreType.Where(rec => rec.CategoryCode == 5);
            bsRegisterItem.DataSource = registerItem;
            bsRegisterExtra.DataSource = registerItem.RegisterExtra;
        }

        private void gvAuthRole_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            if (!(e.Row.DataBoundItem is RegisterExtra item))
                return;

            if (MessageShow.ConfirmAction(DeleteItemConfirmMsg) == DialogResult.Yes)
            {
                bsRegisterExtra.Remove(item);
                bsRegisterExtra.ResetBindings(false);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            gvAuthRole.Rows.AddNew();
            gvAuthRole.CurrentRow.Cells[0].BeginEdit();

            if (gvAuthRole.CurrentRow.DataBoundItem is RegisterExtra row)
                row.RegId = (bsRegisterItem.DataSource as RegisterItem)?.RegId ?? 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var item = bsRegisterItem.DataSource as RegisterItem;

            if (string.IsNullOrEmpty(item?.ItemName))
            {
                MessageShow.ShowWarning(EmptyItemNameWarningMsg);
                return;
            }

            if ((item.GenreType ?? 0) == 0)
            {
                MessageShow.ShowWarning(NotSelectedGenreWarningMsg);
                return;
            }

            item.Ticks = 1;

            var list = GetEmptyRowData();
            if (list != null && list.Any())
            {
                if (MessageShow.ConfirmAction(EmptyRowDeletedMsg) == DialogResult.Yes)
                {
                    var items = bsRegisterExtra.DataSource as ObservableListSource<RegisterExtra>;
                    foreach (var registerExtra in list)
                        items.Remove(registerExtra);
                }
                else
                    return;
            }

            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Отримати елементи з пустими найменуваннями автора або творчою роллю
        /// </summary>
        private ObservableListSource<RegisterExtra> GetEmptyRowData()
        {
            if (!(bsRegisterExtra.DataSource is ObservableListSource<RegisterExtra> list) || !list.Any())
                return null;

            var removeList = new ObservableListSource<RegisterExtra>();
            foreach (var registerExtra in list)
            {
                if (string.IsNullOrEmpty(registerExtra.Name) || registerExtra.RoleCode == 0)
                removeList.Add(registerExtra);
            }

            return removeList.Any() ? removeList : null;
        }

        private void bsRegisterItem_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            if (!(bsRegisterItem.DataSource is RegisterItem item))
                return;

            var source = IpsGlobal.AnketaDictionaties.relGenrePercent.SingleOrDefault(rec => rec.GenreType == item.GenreType);
            if (bsDictRelGenrePercent.DataSource != source)
                bsDictRelGenrePercent.DataSource = source;
        }
    }
}
