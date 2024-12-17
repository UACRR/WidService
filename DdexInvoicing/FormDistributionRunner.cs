using InvoicingLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.Styles;

namespace DdexInvoicing
{
    public partial class FormDistributionRunner : Form
    {
        public const string MESSAGE_BOX_TITLE = "Розподіл і оплата";
        private enum DistributionStepStatusImageIndex
        {
            Pending = -1,
            InProgress = 1,
            Completed = 0,
            Failed = 2,
        }
        private delegate bool Step(UcRoyaltyDistribution.DdexReportInfo ddexReportInfo);

        private readonly Step[] _steps = new Step[]
        {
            ClearPayments,
            ClearDistribution,
            CalcRoyalty,
            PassRoyalty,
            ApplyExchangeRate,
            BindGooglePayment,
            ImportFromWid,
            CreateDistribution,
            CreatePayment,
        };

        private UcRoyaltyDistribution.DdexReportInfo _ddexReportInfo;
        private int _curStepIndex;
        
        public FormDistributionRunner(UcRoyaltyDistribution.DdexReportInfo ddexReportInfo)
        {
            InitializeComponent();
            _ddexReportInfo = ddexReportInfo;
        }

        private void FormDistributionRunner_Load(object sender, EventArgs e)
        {
            Configure();

            btnClose.Enabled = false;
            _curStepIndex = 0;
            lvDistributionProgress.Items[_curStepIndex].ImageIndex = (int)DistributionStepStatusImageIndex.InProgress;
            timerDistributionStep.Enabled = true;
        }

        private void Configure()
        {
            lvDistributionProgress.View = View.Details;
            lvDistributionProgress.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvDistributionProgress.FullRowSelect = true;
            lvDistributionProgress.GridLines = true;
            lvDistributionProgress.SmallImageList = ilMain;
            lvDistributionProgress.Columns.Add("Крок розподілу і оплати", 300);
            lvDistributionProgress.Columns.Add("Стан", 60);

            lvDistributionProgress.Items.Add("Видалення попередніх даних (оплата)");
            lvDistributionProgress.Items.Add("Видалення попередніх даних (розподіл)");
            lvDistributionProgress.Items.Add("Перерахунок роялті");
            lvDistributionProgress.Items.Add("Передача роялті в СМАРТ");
            lvDistributionProgress.Items.Add("Перерахунок роялті в гривні");
            lvDistributionProgress.Items.Add("Створення інформації із платіжу");
            lvDistributionProgress.Items.Add("Імпорт інформації з міжнародної БД");
            lvDistributionProgress.Items.Add("Розрахування розподілу");
            lvDistributionProgress.Items.Add("Розрахування оплати");

            foreach(ListViewItem item in lvDistributionProgress.Items)
            {
                item.ImageIndex = 3;
                item.SubItems.Add("");
            }
        }

        private static bool ClearPayments(UcRoyaltyDistribution.DdexReportInfo ddexReportInfo)
        {
            var res = 0;
            try
            {
                if(ddexReportInfo.RegId == null)
                {
                    return true;
                }

                Helpers.RunSqlOperationMs(cmd =>
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "MPay_Pay_A_rollback_regId";
                    cmd.Parameters.AddWithValue("@regId", ddexReportInfo.RegId);
                    SqlParameter retVal = cmd.Parameters.Add("@retVal", SqlDbType.Int);
                    retVal.Direction = ParameterDirection.ReturnValue;
                    cmd.ExecuteNonQuery();
                    res = (int)retVal.Value;
                });
                if(res != 0)
                {
                    MessageBox.Show("Прпоцедура MPay_Pay_A_rollback_regId повернула помилку", MESSAGE_BOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MESSAGE_BOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private static  bool ClearDistribution(UcRoyaltyDistribution.DdexReportInfo ddexReportInfo)
        {
            var res = 0;
            try
            {
                if(ddexReportInfo.PeriodId == null)
                {
                    return true;
                }

                Helpers.RunSqlOperationMs(cmd =>
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SYS_DelPaidPeriod";
                    cmd.Parameters.AddWithValue("@periodId", ddexReportInfo.PeriodId);
                    SqlParameter retVal = cmd.Parameters.Add("@retVal", SqlDbType.Int);
                    retVal.Direction = ParameterDirection.ReturnValue;
                    cmd.ExecuteNonQuery();
                    res = (int)retVal.Value;
                });
                if(res != 0)
                {
                    MessageBox.Show("Прпоцедура SYS_DelPaidPeriod повернула помилку", MESSAGE_BOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MESSAGE_BOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private static  bool CalcRoyalty(UcRoyaltyDistribution.DdexReportInfo ddexReportInfo)
        {
            try
            {
                Helpers.RunSqlOperationDdex(cmd =>
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spDdexAdjConsolidatedCalcRoyalty";
                    cmd.Parameters.AddWithValue("@ddexReportId", ddexReportInfo.DdexReportId);
                    cmd.ExecuteNonQuery();
                });
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MESSAGE_BOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private static bool PassRoyalty(UcRoyaltyDistribution.DdexReportInfo ddexReportInfo)
        {
            try
            {
                Helpers.RunSqlOperationDdex(cmd =>
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spDdexAdjConsolidatedDistRoyalty";
                    cmd.Parameters.AddWithValue("@ddexReportId", ddexReportInfo.DdexReportId);
                    SqlParameter result = cmd.Parameters.Add("@result", SqlDbType.VarChar, 100);
                    result.Direction = ParameterDirection.Output;
                    SqlParameter retCode = cmd.Parameters.Add("@retCode", SqlDbType.Int);
                    retCode.Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                });

                Helpers.RunSqlOperationMs(cmd =>
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select RegId from RegisterCCID where DdexReportId = @ddexReportId";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ddexReportId", ddexReportInfo.DdexReportId);
                    ddexReportInfo.RegId = Convert.ToInt32(cmd.ExecuteScalar());
                });

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MESSAGE_BOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private static  bool ApplyExchangeRate(UcRoyaltyDistribution.DdexReportInfo ddexReportInfo)
        {
            var res = 0;
            try
            {
                if(ddexReportInfo.RegId == null)
                {
                    MessageBox.Show("Не вказаний код реєстру в СМАРТ", MESSAGE_BOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if(ddexReportInfo.ExchangeRate == null)
                {
                    MessageBox.Show("Не вказаний курс обміну", MESSAGE_BOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                Helpers.RunSqlOperationMs(cmd =>
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"
                        update t1
                        set t1.RegRoyalty = t2.AmountCur * @exchangeRate
                        from Register t1
	                        join RegisterCCID t2 on t1.RegId = t2.RegId
                        where t1.RegId = @regId

                        update RegisterCCID
                        set ExchangeRate = @exchangeRate
	                                    , R030 = 840
                        where RegId = @regId
                    ";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@regId", ddexReportInfo.RegId);
                    cmd.Parameters.AddWithValue("@exchangeRate", ddexReportInfo.ExchangeRate);
                    cmd.ExecuteNonQuery();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "p_CreateDistribution_DDEX_valuation1";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@regId", ddexReportInfo.RegId);
                    SqlParameter retVal = cmd.Parameters.Add("@retVal", SqlDbType.Int);
                    retVal.Direction = ParameterDirection.ReturnValue;
                    cmd.ExecuteNonQuery();
                    res = (int)retVal.Value;

                    if(res != 0)
                    {
                        return;
                    }

                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select PeriodId from Register where RegId = @regId";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@regId", ddexReportInfo.RegId);
                    cmd.ExecuteNonQuery();

                    ddexReportInfo.PeriodId = Convert.ToInt32(cmd.ExecuteScalar());

                });
                if(res != 0)
                {
                    MessageBox.Show("Прпоцедура p_CreateDistribution_DDEX_valuation1 повернула помилку", MESSAGE_BOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MESSAGE_BOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private static  bool BindGooglePayment(UcRoyaltyDistribution.DdexReportInfo ddexReportInfo)
        {
            try
            {
                if(ddexReportInfo.PeriodId == null)
                {
                    MessageBox.Show("Не вказаний період оплати", MESSAGE_BOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                Helpers.RunSqlOperationMs(cmd =>
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "update PaidPeriod set undistribamount = amount where PeriodId = @periodId";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@periodId", ddexReportInfo.PeriodId);
                    cmd.ExecuteNonQuery();
                });
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MESSAGE_BOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private static  bool ImportFromWid(UcRoyaltyDistribution.DdexReportInfo ddexReportInfo)
        {
            var res = 0;
            try
            {
                if(ddexReportInfo.RegId == null)
                {
                    MessageBox.Show("Не вказаний код неєстру", MESSAGE_BOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                Helpers.RunSqlOperationMs(cmd =>
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spWidLoadRegister";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@regId", ddexReportInfo.RegId);
                    SqlParameter retVal = cmd.Parameters.Add("@retVal", SqlDbType.Int);
                    retVal.Direction = ParameterDirection.ReturnValue;
                    cmd.ExecuteNonQuery();
                    res = (int)retVal.Value;
                });
               if(res != 0)
                {
                    MessageBox.Show("Прпоцедура spWidLoadRegister повернула помилку", MESSAGE_BOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MESSAGE_BOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private static  bool CreateDistribution(UcRoyaltyDistribution.DdexReportInfo ddexReportInfo)
        {
            var res = 0;
            try
            {
                if(ddexReportInfo.RegId == null)
                {
                    MessageBox.Show("Не вказаний код неєстру", MESSAGE_BOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                Helpers.RunSqlOperationMs(cmd =>
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spCreateDistributionDdex";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@regId", ddexReportInfo.RegId);
                    SqlParameter retVal = cmd.Parameters.Add("@retVal", SqlDbType.Int);
                    retVal.Direction = ParameterDirection.ReturnValue;
                    cmd.ExecuteNonQuery();
                    res = (int)retVal.Value;
                });
                if(res != 0)
                {
                    MessageBox.Show("Процедура spCreateDistributionDdex повернула помилку", MESSAGE_BOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MESSAGE_BOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private static  bool CreatePayment(UcRoyaltyDistribution.DdexReportInfo ddexReportInfo)
        {
            var res = 0;
            try
            {
                if(ddexReportInfo.RegId == null)
                {
                    MessageBox.Show("Не вказаний код неєстру", MESSAGE_BOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                Helpers.RunSqlOperationMs(cmd =>
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "MPPay_#DDEX";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@regId", ddexReportInfo.RegId);
                    SqlParameter retVal = cmd.Parameters.Add("@retVal", SqlDbType.Int);
                    retVal.Direction = ParameterDirection.ReturnValue;
                    cmd.ExecuteNonQuery();
                    res = (int)retVal.Value;
                });
                if(res != 0)
                {
                    MessageBox.Show("Процедура MPPay_#DDEX повернула помилку", MESSAGE_BOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MESSAGE_BOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        
        private void timerDistributionStep_Tick(object sender, EventArgs e)
        {
            timerDistributionStep.Enabled = false;
            var res = _steps[_curStepIndex](_ddexReportInfo);
            if(!res)
            {
                lvDistributionProgress.Items[_curStepIndex].ImageIndex = (int)DistributionStepStatusImageIndex.Failed;
                btnClose.Enabled = true;
            }
            else if(_curStepIndex < lvDistributionProgress.Items.Count - 1)
            {
                lvDistributionProgress.Items[_curStepIndex].ImageIndex = (int)DistributionStepStatusImageIndex.Completed;
                _curStepIndex++;
                lvDistributionProgress.Items[_curStepIndex].ImageIndex = (int)DistributionStepStatusImageIndex.InProgress;
                timerDistributionStep.Enabled = true;
            }
            else
            {
                lvDistributionProgress.Items[_curStepIndex].ImageIndex = (int)DistributionStepStatusImageIndex.Completed;
                btnClose.Enabled = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
