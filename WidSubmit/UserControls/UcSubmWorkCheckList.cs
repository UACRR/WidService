using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WidSubmit
{
    public partial class UcSubmWorkCheckList : UserControl
    {
        public class CheckList
        {
            public bool SubmWorkId          { get; set; }
            public bool HasOwnAuthor        { get; set; }
            public bool RolesDefined        { get; set; }
            public bool HasNonPublisher     { get; set; }
            public bool AllInIpi            { get; set; }
            public bool PubShare0or100      { get; set; }
            public bool MecShare0or100      { get; set; }
            public bool HasShare            { get; set; }
            public bool AllIpiCodesValid    { get; set; }

        }

        private int _submWorkId;
        private CheckList _checkList;
        
        public UcSubmWorkCheckList()
        {
            InitializeComponent();
        }

        private void UcSubmWorkCheckList_Load(object sender, EventArgs e)
        {
            Configure();
        }

        private void Configure()
        {
            lvCheckList.FullRowSelect = true;
            lvCheckList.GridLines = true;
            lvCheckList.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvCheckList.MultiSelect = false;
            lvCheckList.View = View.Details;

            lvCheckList.Columns.Add("Умова", 500);
            lvCheckList.Columns.Add("Так", 40);
            lvCheckList.Columns.Add("Ні", 40);
        }
        
        public void ClearContent()
        {
            _submWorkId = 0;
            lvCheckList.Items.Clear()   ;
        }

        public void UpdateContent(int submWorkId)
        {
            _submWorkId = submWorkId;
            LoadCheckList();
            FillLvCheckList();
        }

        private void LoadCheckList()
        {
            Helpers.RunSqlSocWidSubmitEx(cmd =>
            {
                cmd.CommandText = @"
                    select
	                      HasOwnRightHolder
	                    , RolesDefined
	                    , HasNonPublisher
	                    , AllInIpi
	                    , PubShare0or100
	                    , MecShare0or100
	                    , HasShare
	                    , AllIpiCodesValid
                    from SubmCheckList
                    where SubmWorkId = @submWorkId
                ";
                cmd.Parameters.AddWithValue("@submWorkId", _submWorkId);

                _checkList = new CheckList();
                using (var r = cmd.ExecuteReader())
                {
                    r.Read();
                    int idx = 0;
                    _checkList.HasOwnAuthor        = r.GetBoolean(idx++);
                    _checkList.RolesDefined        = r.GetBoolean(idx++);
                    _checkList.HasNonPublisher     = r.GetBoolean(idx++);
                    _checkList.AllInIpi            = r.GetBoolean(idx++);
                    _checkList.PubShare0or100      = r.GetBoolean(idx++);
                    _checkList.MecShare0or100      = r.GetBoolean(idx++);
                    _checkList.HasShare            = r.GetBoolean(idx++);
                    _checkList.AllIpiCodesValid    = r.GetBoolean(idx++);
                }
            });
         }

        private void FillLvCheckList()
        {
            lvCheckList.Items.Clear();

            if(_checkList == null)
            {
                return;
            }

            AddItem("Є правовласник, що має договори з УААСП"                   , _checkList.HasOwnAuthor        );
            AddItem("Для всіх автрів/видавців визначені ролі"                       , _checkList.RolesDefined        );
            AddItem("Є правовласник, відмінний від видавця"                         , _checkList.HasNonPublisher     );
            AddItem("Всі автори/видавці зареєстровані в IPI"                        , _checkList.AllInIpi            );
            AddItem("Сума процентів Пуб нуль або 100"                               , _checkList.PubShare0or100      );
            AddItem("Сума процентів Мех нуль або 100"                               , _checkList.MecShare0or100      );
            AddItem("Є автори/видавці з ненульвоими процентами"                     , _checkList.HasShare            );
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
            if( _checkList == null )
            {
                return false;
            }
            else
            {
                return !(
                       _checkList.HasOwnAuthor 
                    && _checkList.RolesDefined 
                    && _checkList.AllInIpi 
                    && _checkList.HasNonPublisher 
                    && _checkList.HasShare 
                    && _checkList.MecShare0or100 
                    && _checkList.PubShare0or100 
                    && _checkList.AllIpiCodesValid
                );
            }
        }

        private void lvCheckList_MouseDown(object sender, MouseEventArgs e)
        {
            Helpers.CopyCellValue(e, lvCheckList);
        }
    }
}
