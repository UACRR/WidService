using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WidExport
{
    public partial class UcWidSubmWorkCheckList : UserControl
    {
        WidSubmWorkCheckList _checkList;
        private WidSubmGroup _group;
        private int? _objId;

        public UcWidSubmWorkCheckList()
        {
            InitializeComponent();
        }

        private void UcCheckList_Load(object sender, EventArgs e)
        {
            lvCheckList.Columns.Add("Умова", 500);
            lvCheckList.Columns.Add("Так", 40);
            lvCheckList.Columns.Add("Ні", 40);
        }
        public void SetGroupAndObjId(WidSubmGroup group, int? objId)
        {
            _group = group;
            _objId = objId;
            LoadData();
        }

        private void LoadData()
        {
            lvCheckList.Items.Clear();
            if (_objId == null)
            {
                return;
            }
            _checkList = new WidSubmWorkCheckList();
            _checkList.Refresh(_group.Id, (int)_objId);
            SetCheckList();
         }

        private void SetCheckList()
        {
            if(_checkList == null)
            {
                return;
            }

            AddItem("Є правовласник, що має договори з УААСП", _checkList.HasOwnAuthor        );
            AddItem("Для всіх автрів/видавців визначені ролі"                       , _checkList.RolesDefined        );
            AddItem("Є правовласник, відмінний від видавця"                         , _checkList.HasNonPublisher     );
            AddItem("Всі автори/видавці зареєстровані в IPI"                        , _checkList.AllInIpi            );
            AddItem("Сума процентів Пуб нуль або 100"                               , _checkList.PubShare0or100      );
            AddItem("Сума процентів Мех нуль або 100"                               , _checkList.MecShare0or100      );
            AddItem("Є автори/видавці з ненульвоими процентами"                     , _checkList.HasShare            );
            //AddItem("Транслітерацію назв твору затверджено"                         , _checkList.NamesApproved       );
            //AddItem("Транслітерація імен виконавців затверджено"                    , _checkList.PerformersApproved  );
            AddItem("Коди всіх авторів знайдені в IPI і мають вірний статус (1)"    , _checkList.AllIpiCodesValid    );
        }

        private void AddItem(string name, bool value)
        {
            var item = lvCheckList.Items.Add(name);
            item.SubItems.Add(value ? "X" : "");
            item.SubItems.Add(value ? "" : "X");
        }

        public bool HasErrors()
        {
            return _checkList == null ? false : _checkList.HasErrors();
        }

        public bool HasShareErrors()
        {
            return _checkList == null ? false : _checkList.HasShareErrors();
        }

        public bool HasNameErrors()
        {
            return _checkList == null ? false : _checkList.HasNameErrors();
        }

        public bool HasPerformerErrors()
        {
            return _checkList == null ? false : _checkList.HasPerformerErrors();
        }
    }
}
