using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShareCalc
{
    public partial class FormIpiRhSearch : Form
    {
        public class RhMs
        {
            public int    CustId      {  get; set; }
            public string Name        {  get; set; }
            public string FstName     {  get; set; }
            public string SurName     {  get; set; }
            public string AggrDate    {  get; set; }
            public string AgrStatus   {  get; set; }
            public bool   AroundWorld {  get; set; }
            public string DateBegin   {  get; set; }
            public string DateEnd     {  get; set; }
            public string ChangeDate  {  get; set; }
            public bool   IsProcessed {  get; set; }
        }

        public class RhIpi
        {
            public string IpBaseNr    {  get; set; }
            public string IpNameNr    {  get; set; }
            public string Name        {  get; set; }
            public string FstName     {  get; set; }
            public string BirthDate   {  get; set; }
            public string ChangeDate  {  get; set; }
        }

        private List<RhMs>  _rhMsList;
        private List<RhIpi> _rhIpiList;

        public FormIpiRhSearch()
        {
            InitializeComponent();
        }

        private void FormIpiRhSearch_Load(object sender, EventArgs e)
        {
            Configure();
            LoadRhMsList();
            FillRhMsView();
        }

        private void Configure()
        {
            Helpers.ConfigureListView(lvRhMs
                , "CustId"        
                , "Прізвище"  
                , "Імя"       
                , "Побатькові"
                , "Дата договору"
                , "Статус"
                , "На весь світ"
                , "Початок"
                , "Завершення"
                , "Дата зміни"
            );

            Helpers.ConfigureListView(lvRhIpi
                , "IpBaseNr"
                , "IpNameNr"   
                , "Прізвище"  
                , "Імя" 
                , "Дата народження"
                , "Дата зміни"
            );
        }

        private void LoadRhMsList()
        {
            Helpers.RunSqlShareCalc(cmd =>
            {
                cmd.CommandText = "select * from UacrrLostRhIpiCodes order by Name";
                _rhMsList = Helpers.CreateListFromCmd<RhMs>(cmd);
            });
        }

        private void FillRhMsView()
        {
            Helpers.FillListView(_rhMsList, lvRhMs);
        }

        private void LoadRhIpiList()
        {
            Helpers.RunSqlShareCalc(cmd =>
            {
                cmd.CommandText = $@"
                    select top 100 
                          t1.IpBaseNr
                        , cast(t1.IpNameNr as char(16))
                        , t1.Name
                        , t1.FstName
                        , case when t2.BirthD is null then '' else format(t2.BirthD, 'yyyy-MM-dd') end
                        , case when t2.AmdDt is null then '' else format(t2.AmdDt, 'yyyy-MM-dd') end
                    from SocIpi..IpiName t1
                        join SocIpi..IpiBase t2 on t1.IpBaseNr = t2.IpBaseNr
                    where Name = @name
                    order by t1.Name, t1.FstName
                ";
                cmd.Parameters.AddWithValue("@name", $"{tbRhIpiFilterName.Text}");
                _rhIpiList = Helpers.CreateListFromCmd<RhIpi>(cmd);
            });
        }

        private void FillRhIpiView()
        {
            Helpers.FillListView(_rhIpiList, lvRhIpi);
        }

        private void lvRhMs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lvRhMs.SelectedItems.Count == 0)
            {
                tbRhIpiFilterName.Text = "";
                tbRhIpiFilterFstName.Text = "";
                tbRhIpiFilterSurName.Text = "";
                return;
            }

            var item = lvRhMs.SelectedItems[0];
            var rhIpi = (RhMs)item.Tag;
            tbRhIpiFilterName.Text = Translit.FromUkr(rhIpi.Name);
            tbRhIpiFilterFstName.Text = "";
            tbRhIpiFilterSurName.Text = "";

            var fstName = Translit.FromUkr(rhIpi.FstName).Trim();
            if( fstName.Length > 0 )
                tbRhIpiFilterFstName.Text = fstName.Substring(0, 1);
            //tbRhIpiFilterSurName.Text = "";
            //tbRhIpiFilterFstName.Text = Translit.FromUkr(rhIpi.FstName).Trim();
            //tbRhIpiFilterSurName.Text = Translit.FromUkr(rhIpi.SurName).Trim();

            Helpers.RunProtected(() =>
            {
                LoadRhIpiList();
                FillRhIpiView();
            });
        }

        private void btnRhIpiSearch_Click(object sender, EventArgs e)
        {
            LoadRhIpiList();
            FillRhIpiView();
        }
    }
}
