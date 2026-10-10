using InvoicingLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Styles;
using static DdexInvoicing.UcRoyaltyDistribution;

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
        private delegate bool Step();

        private Step[] _steps;

        private string _inputFileName;
        private UcRoyaltyDistribution.DdexReportInfo _ddexReportInfo;
        private bool _handlePayment;
        private bool _createPayment;
        private int _curStepIndex;
        
        public FormDistributionRunner(
            string inputFileName,
            UcRoyaltyDistribution.DdexReportInfo ddexReportInfo,
            bool handlePayment, bool createPayment)
        {
            InitializeComponent();
            _inputFileName = inputFileName;
            _ddexReportInfo = ddexReportInfo;
            _handlePayment = handlePayment;
            _createPayment = createPayment;

            _steps = new Step[]
            {
                LoadFile,
                ClearPayments,
                ClearDistribution,
                CalcRoyalty,
                PassRoyalty,
                ApplyExchangeRate,
                BindPayment,
                ImportFromWid,
                CreateDistribution,
                CreatePayment,
            };
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

            lvDistributionProgress.Items.Add("Завантаження даних про оплату роялті з файлу");
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

        private bool LoadFile()
        {
            try
            {
                var reportStatus = DdexReport.GetReportStatus(_ddexReportInfo.DdexReportId);
                if(reportStatus != Meta.DdexReportStatus.INVOICING &&
                    reportStatus != Meta.DdexReportStatus.DISTRIBUTION_STARTED)
                {
                    return true;
                }

                DdexReport.SetReportStatus(_ddexReportInfo.DdexReportId, Meta.DdexReportStatus.DISTRIBUTION_STARTED);

                DdexReport ddexReport = new DdexReport(
                        ConfigurationManager.AppSettings["ConnectionStringDdex"], 
                        _ddexReportInfo.DdexReportId);

                var reportTypeEnum = DdexReport.GetReportTypeEnum(_ddexReportInfo.DdexReportId);

                Cursor.Current = Cursors.WaitCursor;
                if (reportTypeEnum == DdexReport.ReportTypeEnum.YOUTUBE_ADSUPPORT_MUSIC)
                {
                    ddexReport.ProcessAdjustment(new DdexReportActionLoadAdjAvod(), _inputFileName);
                }
                else if (reportTypeEnum == DdexReport.ReportTypeEnum.YOUTUBE_SUBSCRIPTION_MUSIC ||
                    reportTypeEnum == DdexReport.ReportTypeEnum.YOUTUBE_SUBSCRIPTION_PREMIUM)
                {
                    ddexReport.ProcessAdjustment(new DdexReportActionLoadAdjSvod(), _inputFileName);
                }
                else if (reportTypeEnum == DdexReport.ReportTypeEnum.SPOTIFY_FREE ||
                    reportTypeEnum == DdexReport.ReportTypeEnum.SPOTIFY_PREMIUM ||
                    reportTypeEnum == DdexReport.ReportTypeEnum.SPOTIFY_MULTIUSER ||
                    reportTypeEnum == DdexReport.ReportTypeEnum.SPOTIFY_STUDENT)
                {
                    Helpers.RunSqlOperationDdexT(cmd =>
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@ddexReportId", _ddexReportInfo.DdexReportId);
                        cmd.CommandText = $@"spCreateAdjConsolidatedDetailForSpotify";
                        cmd.ExecuteNonQuery();
                    }, true);
                }
 
                DdexReport.SetReportStatus(_ddexReportInfo.DdexReportId, Meta.DdexReportStatus.DISTRIBUTION_DATA_LOADED);

                Cursor.Current = Cursors.Default;

                return true;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message, MESSAGE_BOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private  bool ClearPayments()
        {
            var res = 0;
            try
            {
                if(_ddexReportInfo.RegId == null)
                {
                    return true;
                }

                Helpers.RunSqlOperationMsUnsafe(cmd =>
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "MPay_Pay_A_rollback_regId";
                    cmd.Parameters.AddWithValue("@regId", _ddexReportInfo.RegId);
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
                    DdexReport.SetReportStatus(_ddexReportInfo.DdexReportId, Meta.DdexReportStatus.DISTRIBUTION_IN_PROGRESS);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MESSAGE_BOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private   bool ClearDistribution()
        {
            var res = 0;
            try
            {
                if(_ddexReportInfo.PeriodId == null)
                {
                    return true;
                }

                Helpers.RunSqlOperationMsUnsafe(cmd =>
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SYS_DelPaidPeriod";
                    cmd.Parameters.AddWithValue("@periodId", _ddexReportInfo.PeriodId);
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
                    DdexReport.SetReportStatus(_ddexReportInfo.DdexReportId, Meta.DdexReportStatus.DISTRIBUTION_IN_PROGRESS);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MESSAGE_BOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private   bool CalcRoyalty()
        {
            var reportTypeEnum = DdexReport.GetReportTypeEnum(_ddexReportInfo.DdexReportId);

            Cursor.Current = Cursors.WaitCursor;
            if (reportTypeEnum == DdexReport.ReportTypeEnum.SPOTIFY_FREE ||
                reportTypeEnum == DdexReport.ReportTypeEnum.SPOTIFY_PREMIUM  ||
                reportTypeEnum == DdexReport.ReportTypeEnum.SPOTIFY_MULTIUSER  ||
                reportTypeEnum == DdexReport.ReportTypeEnum.SPOTIFY_STUDENT  ||
                reportTypeEnum == DdexReport.ReportTypeEnum.TIKTOK)
            {
                return true;
            }

            try
            {
                Helpers.RunSqlOperationDdexUnsafe(cmd =>
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spDdexAdjConsolidatedCalcRoyalty";
                    cmd.Parameters.AddWithValue("@ddexReportId", _ddexReportInfo.DdexReportId);
                    cmd.ExecuteNonQuery();
                });
                DdexReport.SetReportStatus(_ddexReportInfo.DdexReportId, Meta.DdexReportStatus.DISTRIBUTION_IN_PROGRESS);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MESSAGE_BOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private  bool PassRoyalty()
        {
            try
            {
                Helpers.RunSqlOperationDdexUnsafe(cmd =>
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spDdexAdjConsolidatedDistRoyalty";
                    cmd.Parameters.AddWithValue("@ddexReportId", _ddexReportInfo.DdexReportId);
                    SqlParameter result = cmd.Parameters.Add("@result", SqlDbType.VarChar, 100);
                    result.Direction = ParameterDirection.Output;
                    SqlParameter retCode = cmd.Parameters.Add("@retCode", SqlDbType.Int);
                    retCode.Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                });

                Helpers.RunSqlOperationMsUnsafe(cmd =>
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select RegId from RegisterCCID where DdexReportId = @ddexReportId";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ddexReportId", _ddexReportInfo.DdexReportId);
                    _ddexReportInfo.RegId = Convert.ToInt32(cmd.ExecuteScalar());
                });

                DdexReport.SetReportStatus(_ddexReportInfo.DdexReportId, Meta.DdexReportStatus.DISTRIBUTION_IN_PROGRESS);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MESSAGE_BOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private   bool ApplyExchangeRate()
        {
            var res = 0;
            try
            {
                if(_ddexReportInfo.RegId == null)
                {
                    MessageBox.Show("Не вказаний код реєстру в СМАРТ", MESSAGE_BOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if(_ddexReportInfo.ExchangeRate == null)
                {
                    MessageBox.Show("Не вказаний курс обміну", MESSAGE_BOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                Helpers.RunSqlOperationMsUnsafe(cmd =>
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
                    cmd.Parameters.AddWithValue("@regId", _ddexReportInfo.RegId);
                    cmd.Parameters.AddWithValue("@exchangeRate", _ddexReportInfo.ExchangeRate);
                    cmd.ExecuteNonQuery();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "p_CreateDistribution_DDEX_valuation1";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@regId", _ddexReportInfo.RegId);
                    SqlParameter retVal = cmd.Parameters.Add("@retVal", SqlDbType.Int);
                    retVal.Direction = ParameterDirection.ReturnValue;
                    cmd.ExecuteNonQuery();
                    res = (int)retVal.Value;

                    if(res != 0)
                    {
                        DdexReport.SetReportStatus(_ddexReportInfo.DdexReportId, Meta.DdexReportStatus.DISTRIBUTION_IN_PROGRESS);
                        return;
                    }

                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select PeriodId from Register where RegId = @regId";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@regId", _ddexReportInfo.RegId);
                    cmd.ExecuteNonQuery();

                    _ddexReportInfo.PeriodId = Convert.ToInt32(cmd.ExecuteScalar());

                });
                if(res != 0)
                {
                    MessageBox.Show("Прпоцедура p_CreateDistribution_DDEX_valuation1 повернула помилку", MESSAGE_BOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    DdexReport.SetReportStatus(_ddexReportInfo.DdexReportId, Meta.DdexReportStatus.DISTRIBUTION_IN_PROGRESS);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MESSAGE_BOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private static object GetDbNullableValue(object value)
        {
            return value ?? DBNull.Value;
        }

        private   bool BindPayment()
        {
            var res = 0;
            try
            {
                if(_ddexReportInfo.PeriodId == null)
                {
                    MessageBox.Show("Не вказаний період оплати", MESSAGE_BOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                Helpers.RunSqlOperationMsUnsafe(cmd =>
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spDdexReportBindGooglePaiment";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ddexReportId"         , _ddexReportInfo.DdexReportId);
                    cmd.Parameters.AddWithValue("@handlePayment"        , _handlePayment);
                    cmd.Parameters.AddWithValue("@createPayment"        , _createPayment);
                    cmd.Parameters.AddWithValue("@paidId"               , GetDbNullableValue(_ddexReportInfo.PaidId));
                    cmd.Parameters.AddWithValue("@numberInvoice"        , GetDbNullableValue(_ddexReportInfo.NumberInvoice));
                    cmd.Parameters.AddWithValue("@goalInvoice"          , GetDbNullableValue(_ddexReportInfo.GoalInvoice));
                    cmd.Parameters.AddWithValue("@dateInvoice"          , GetDbNullableValue(_ddexReportInfo.DateInvoice));
                    cmd.Parameters.AddWithValue("@amountReceivedTotal"  , GetDbNullableValue(_ddexReportInfo.AmountReceivedTotal));
                    cmd.Parameters.AddWithValue("@amountReceivedPeriod" , GetDbNullableValue(_ddexReportInfo.AmountReceivedPeriod));
                    SqlParameter retVal = cmd.Parameters.Add("@retVal", SqlDbType.Int);
                    retVal.Direction = ParameterDirection.ReturnValue;
                    cmd.ExecuteNonQuery();
                    res = (int)retVal.Value;
                });
                if (res != 0)
                {
                    MessageBox.Show("Процедура spDdexReportBindGooglePaiment повернула помилку", MESSAGE_BOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    DdexReport.SetReportStatus(_ddexReportInfo.DdexReportId, Meta.DdexReportStatus.DISTRIBUTION_IN_PROGRESS);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MESSAGE_BOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
       }
        private   bool ImportFromWid()
        {
            var res = 0;
            try
            {
                if(_ddexReportInfo.RegId == null)
                {
                    MessageBox.Show("Не вказаний код неєстру", MESSAGE_BOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                Helpers.RunSqlOperationMsUnsafe(cmd =>
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spWidLoadRegister";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@regId", _ddexReportInfo.RegId);
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
                    DdexReport.SetReportStatus(_ddexReportInfo.DdexReportId, Meta.DdexReportStatus.DISTRIBUTION_IN_PROGRESS);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MESSAGE_BOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private   bool CreateDistribution()
        {
            var res = 0;
            try
            {
                if(_ddexReportInfo.RegId == null)
                {
                    MessageBox.Show("Не вказаний код неєстру", MESSAGE_BOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                Helpers.RunSqlOperationMsUnsafe(cmd =>
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spCreateDistributionDdex";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@regId", _ddexReportInfo.RegId);
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
                    DdexReport.SetReportStatus(_ddexReportInfo.DdexReportId, Meta.DdexReportStatus.DISTRIBUTION_IN_PROGRESS);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MESSAGE_BOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private   bool CreatePayment()
        {
            var res = 0;
            try
            {
                if(_ddexReportInfo.RegId == null)
                {
                    MessageBox.Show("Не вказаний код неєстру", MESSAGE_BOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                Helpers.RunSqlOperationMsUnsafe(cmd =>
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "MPPay_#DDEX";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@regId", _ddexReportInfo.RegId);
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
                    DdexReport.SetReportStatus(_ddexReportInfo.DdexReportId, Meta.DdexReportStatus.DISTIBUTION_COMPLETED);
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
            var res = _steps[_curStepIndex]();
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
