using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartViewer
{
    public partial class UcSearchIpiCodes : UserControl
    {
        public UcSearchIpiCodes()
        {
            InitializeComponent();
        }

        private void UcSearchIpiCodes_Load(object sender, EventArgs e)
        {
            Configure();
        }

        private void Configure()
        {
            ucRightHolders.ItemSelected += UcRightHolders_ItemSelected;
        }

        private void FillRightHolderDetails(int custId)
        {
            Helpers.RunSqlMediaService( cmd =>
            {
                cmd.CommandText = @"
                    select
                          isnull(t2.FullName, '')																		        as FullName
                        , upper(dbo.TransliterateUkrToEng(isnull(t2.FullName, '')))										        as FullNameTr
                        , trim(isnull(t1.interCode, ''))																        as IpBaseNr
                        , trim(isnull(t1.IPIBase, ''))																	        as IpNameNr
                        , upper(trim(dbo.TransliterateUkrToEng(isnull(t2.Name, ''))))											as SearchName
                        , upper(trim(dbo.TransliterateUkrToEng(concat(isnull(t2.FirstName, ''), ' ', isnull(t2.SurName, ''))))) as SearchFirstName
                    from RightHolder t1
                        join vCustomerNameDetailed t2 on t1.CustId = t2.CustId
                    where t1.CustId = @custId
                ";
                cmd.Parameters.AddWithValue("@custId", custId);
                using(var r = cmd.ExecuteReader())
                {
                    r.Read();
                    var idx = 0;
                    tbMsName.Text          = r.GetString(idx); idx++;
                    tbMsNameTr.Text        = r.GetString(idx); idx++;
                    tbIpBaseNr.Text        = r.GetString(idx); idx++;
                    tbIpNameNr.Text        = r.GetString(idx); idx++;
                    tbSearchName.Text      = r.GetString(idx); idx++;
                    tbSearchFirstName.Text = r.GetString(idx); idx++;

                    if(tbSearchFirstName.Text == "")
                    {
                        var splitted = tbSearchName.Text.Split(' ');
                        if(splitted.Length > 1)
                        {
                            tbSearchName.Text = splitted[0];
                            tbSearchFirstName.Text = splitted[1];
                        }
                    }
                    
                }
            });
        }

        private void ClearRightHolderDetails()
        {
            tbMsName.Text          = "";
            tbMsNameTr.Text        = "";
            tbIpBaseNr.Text        = "";
            tbIpNameNr.Text        = "";
            tbSearchName.Text      = "";
            tbSearchFirstName.Text = "";
            ucFoundCodes.ClearContent();
        }

        private string CreateSearchSql()
        {
            var sql = "";

            var name = tbSearchName.Text;
            var firstName = tbSearchFirstName.Text;

            if(name == "" &&  firstName == "") return "";

            var filterName = "";
            if(name != "" && !rbIgnore1.Checked)
            {
                if(rbEqual1.Checked) filterName = "t1.Name = @name";
                else filterName = "t1.Name like @name";
            }

            var filterFirstName = "";
            if(firstName != "" && !rbIgnore2.Checked)
            {
                if(rbEqual2.Checked) filterFirstName = "t1.FstName = @fstName";
                else filterFirstName = "t1.FstName like @fstName";
            }

            var filter = filterName;
            if(filter != "" && filterFirstName != "") filter += " and ";
            if(filterFirstName != "") filter += filterFirstName;

            sql = $@"
                select distinct
                      t2.IpBaseNr as [Базовий код]
                    , trim(concat(trim(t2.Name), ' ', trim(t2.FstName))) as [Партонім]
                    , t2.IpNameNr as [Код патроніму]
	                , trim(concat(trim(t1.Name), ' ', trim(t1.FstName))) as [Знайдена назва]
                    , t1.IpNameNr as [Код знайденої]
	                , t1.NameType as [Тип]
                from SocIpi..IpiName t1
	                join SocIpi..IpiName t2 on t1.IpBaseNr = t2.IpBaseNr
		                and t2.NameType = 'PA'
                where {filter}
                order by trim(concat(trim(t2.Name), ' ', trim(t2.FstName)))

            ";

            return sql;
        }

        private void SearchRightHolder()
        {
            ucFoundCodes.ClearContent();
            var sql = CreateSearchSql();
            if(sql == "") return;

            Helpers.RunSqlMediaService( cmd =>
            {
                cmd.CommandText = sql;
                var name = rbEqual1.Checked ? tbSearchName.Text        :
                    rbStarts1.Checked       ? $"{tbSearchName.Text}%"  :
                    rbContains1.Checked     ? $"%{tbSearchName.Text}%" :
                                              "";
                cmd.Parameters.AddWithValue("@name", name);

                var firstName = rbEqual2.Checked ? tbSearchFirstName.Text        :
                    rbStarts2.Checked       ? $"{tbSearchFirstName.Text}%"  :
                    rbContains2.Checked     ? $"%{tbSearchFirstName.Text}%" :
                                              "";
                cmd.Parameters.AddWithValue("@fstName", firstName);

                ucFoundCodes.UpdateContent(cmd);
            });

        }

        private void btnShowRightHolders_Click_1(object sender, EventArgs e)
        {
            Helpers.RunProtected(() =>
            {
                ucRightHolders.SqlSelect = @"
                    select
	                      row_number() over (order by t2.ShortName) as [№пп]
	                    , t1.CustId as [Код СМАРТ]
	                    , t2.ShortName as [Назва СМАРТ]
	                    --, isnull(t1.interCode, '') as [Базовий код IPI]
	                    --, isnull( t1.IPIBase, '') as [Код назви IPI]
                    from RightHolder t1
	                    join vCustomerNamesShort t2 on t1.CustId = t2.CustId
                    where isnull(InterCode, '') = ''
                    order by t2.ShortName
                ";

                ucRightHolders.UpdateContent();
            });

        }
        
        private void UcRightHolders_ItemSelected(object sender, UcListViewBase.ItemSelectedEventArgs e)
        {
            if(e.Item == null)
                ClearRightHolderDetails();
            else
                FillRightHolderDetails(int.Parse(e.Item.SubItems[1].Text));
        }

        private void btnDoSearch_Click(object sender, EventArgs e)
        {
            Helpers.RunProtected(() =>
            {
                SearchRightHolder();
            });
        }

        private void btnSwapSearchParameters_Click(object sender, EventArgs e)
        {
            var text1 = tbSearchName.Text;
            var text2 = tbSearchFirstName.Text;
            tbSearchName.Text = text2;
            tbSearchFirstName.Text = text1;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
