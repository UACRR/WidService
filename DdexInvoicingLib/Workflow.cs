using InvoicingLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvoicingLib
{
    public class ActionInfo
    {
        public Workflow.Status statusCode;
        public string notAllowedText;
        public string alreadyDoneText;
        public string buttonText;
        public Button button;
        public ActionRunner runner;
    }

    public class Workflow
    {
        public enum Status
        {
            ERROR_DETECTED, FIELD_SIZES_CHECKED, RAW_DATA_LOADED, SUBSCRIPTION_DATA_LOADED, IDENT_DATA_PREPARED, INITIAL_IDENT_DONE, IDENT_BY_ISWC_DONE
                , AUTHORS_REGISTERED
            , INITIAL_INVOICE_CREATED, INITIAL_INVOICE_FILE_CREATED, INITIAL_INVOICE_FILE_SENT
            , RESPONCE_UPLOADED
            , FINAL_INVOICE_CREATED, FINAL_INVOICE_FILE_CREATED, FINAL_INVOICE_FILE_SENT
            , AMOUNT_DISTRIBUTED
        }
        public enum SubStatus
        {
            IDLE, IN_PROGRESS, FAILED, SUCCEEDED
        }

        public enum StateImage
        {
            FUTURE_ACTION = -1
            , COMPLETED_ACTION = 0
            , CURRENT_ACTION = 1
            , FAILED_ACTION = 2
            , INPROGRESS_ACTION = 3
        }

        public const int reportActionsCount = 6;

        public static ActionInfo[] actions = 
        {
            new ActionInfo()
            {
                statusCode = Status.ERROR_DETECTED,
                notAllowedText = "",
                alreadyDoneText = "Перевірку вхідної інформації на наявніть помилок вже було виконано.",
                buttonText = "Зарейеструвати помилки вхідного файла",
                runner = new CheckErrorsRunner()
            },
            new ActionInfo()
            {
                statusCode = Status.FIELD_SIZES_CHECKED,
                notAllowedText = "Не було виконано перевірку вхідної інформації на наявніть помилок. Виконайте перевірку достатності розміну колонок.",
                alreadyDoneText = "Перевірку достатності розміну колонок таблиць вже було виконано. Повторити перевірку?",
                buttonText = "Перевірити достатність розміру колонок таблиць",
                runner = new CheckFileSizesRunner()
            },
            /*
            {
                statusCode = Status.RAW_DATA_LOADED,
                notAllowedText = "Не було виконано перевірку достатністі розміру колонок таблиць. Виконайте перевірку і повторіть завантаження необробленої інформації.",
                alreadyDoneText = "Необроблені дані вже завантажені в базу даних. Повторити завантаження?",
                buttonText = "Завантажити необроблені дані",
                runner = new LoadRawDataRunner()
            }*/
            new ActionInfo()
            {
                statusCode = Status.RAW_DATA_LOADED,
                notAllowedText = "Не було виконано перевірку достатністі розміру колонок таблиць. Виконайте перевірку і повторіть завантаження необробленої інформації.",
                alreadyDoneText = "Дані вже завантажені в базу даних. Повторити завантаження?",
                buttonText = "Завантажити дані із звіту",
                runner = new LoadIdentDataRunner()
            },

            new ActionInfo()
            {
                statusCode = Status.SUBSCRIPTION_DATA_LOADED,
                notAllowedText = "Не було виконано перевірку достатністі розміру колонок таблиць. Виконайте перевірку і повторіть завантаження необробленої інформації.",
                alreadyDoneText = "Дані вже завантажені в базу даних. Повторити завантаження?",
                buttonText = "Завантажити дані для звіту про підписку",
                runner = new LoadSubscriptionDataRunner()
            },

            new ActionInfo()
            {
                statusCode = Status.IDENT_DATA_PREPARED,
                notAllowedText = "Не завантажені дані із звіту. Завантажте дані і повторіть операцию.",
                alreadyDoneText = "Дані вже підготовані",
                buttonText = "Підготувати дані для ідентифікацїї творів",
                runner = new PrepareDataForIdentificationRunner()
            },

            new ActionInfo()
            {
                statusCode = Status.INITIAL_IDENT_DONE,
                notAllowedText = "Дані для ідентифікації творів не створені. Створіть дані і повторіть операцию.",
                alreadyDoneText = "Попередня ідентифікація вже виконана.",
                buttonText = "Виконати попередню ідентифікацію творів",
                runner = new DoInitialIdentificationRunner()
            },

            new ActionInfo()
            {
                statusCode = Status.IDENT_BY_ISWC_DONE,
                notAllowedText = "Попередня ідентифікація ще не виконана. Виконайте попередню ідентифікацію творів і повторіть операцию.",
                alreadyDoneText = "Ідентифікація творов за кодом ISWC вже виконана.",
                buttonText = "Виконати ідентифікацію творов за кодом ISWC",
                runner = new IdentifyByIswcRunner()
            },

            
            /*new ActionInfo()
            {
                statusCode = Status.AUTHORS_REGISTERED,
                notAllowedText = "Не завантажені необроблені дані. Виконайте завантаження і повторіть ідентифікацію авторів.",
                alreadyDoneText = "Ідентифікацію авторів вже було виконано.",
                buttonText = "Ідентифікувати авторів",
                runner = new RegisterAuthorsRunner()
            },*/
            new ActionInfo()
            {
                statusCode = Status.INITIAL_INVOICE_CREATED,
                notAllowedText = "Не було виконано ідентифікацію авторів. Виконайте ідентицікацію і повторіть створення початкового рахунку-фактури.",
                alreadyDoneText = "Початковий рахунок-фактура вже створений.",
                buttonText = "Створити початковий рахунок-фактуру",
                runner = new CreateInitialInvoiceRunner()
            },
            new ActionInfo()
            {
                statusCode = Status.INITIAL_INVOICE_FILE_CREATED,
                notAllowedText = "Початковий рахунок-фактура не створений або створений с помилками. Створіть початкового рахунк-фактуру і повторіть дану дію.",
                alreadyDoneText = "Файл початкового рахунку-фактури вже створено.",
                buttonText = "Занести початковий рахунок-фактуру в файл",
                runner = new CreateInitialInvoiceFileRunner()
            },
            new ActionInfo()
            {
                statusCode = Status.INITIAL_INVOICE_FILE_SENT,
                notAllowedText = "Файл початкового рахунку-фактури не існує. Створіть файл і повторіть дану дію.",
                alreadyDoneText = "Початковий рахунок-фактуру вже надіслано клієнту.",
                buttonText = "Відіслати початковий рахунок-фактуру",
                runner = new SendInitialInvoiceRunner()
            },
            new ActionInfo()
            {
                statusCode = Status.RESPONCE_UPLOADED,
                notAllowedText = "Файл початкового рахунку-фактури ще не надіслано клієнту. Повторіть дану дію після отримання відповіді від клієнта.",
                alreadyDoneText = "Відповідь від клієнта вже завантажено в базу даних.",
                buttonText = "Занести відповідь від клієнта в базу даних",
                runner = new UploadResponceRunner()
            },
            new ActionInfo()
            {
                statusCode = Status.FINAL_INVOICE_CREATED,
                notAllowedText = "Не завантажена відповідь від клієнта. Повторіть дію, коли відповідь буде завантажено.",
                alreadyDoneText = "Підсумковий рахунок-фактура вже створений.",
                buttonText = "Створити підсумковий рахунок-фактуру",
                runner = new CreateFinalInvoiceRunner()
            },
            new ActionInfo()
            {
                statusCode = Status.FINAL_INVOICE_FILE_CREATED,
                notAllowedText = "Підсумковий рахунок-фактура не створений або створений с помилками. Створіть підсумковий рахунк-фактуру і повторіть дану дію.",
                alreadyDoneText = "Файл підсумкового рахунку-фактури вже створено.",
                buttonText = "Занести підсумковий рахунок-фактуру в файл",
                runner = new CreateFinalInvoiceFileRunner()
            },
            new ActionInfo()
            {
                statusCode = Status.FINAL_INVOICE_FILE_SENT,
                notAllowedText = "Файл підсумкового рахунку-фактури не існує. Створіть файл і повторіть дану дію.",
                alreadyDoneText = "Підсумковий рахунок-фактуру вже надіслано клієнту.",
                buttonText = "Відіслати підсумковий рахунок-фактуру",
                runner = new SendFinalInvoiceRunner()
            },
            new ActionInfo()
            {
                statusCode = Status.AMOUNT_DISTRIBUTED,
                notAllowedText = "Файл підсумкового рахунку-фактури ще не надіслано клієнту. Надійшліть файл і повторіть дану дію після отримання відповіді від клієнта.",
                alreadyDoneText = "Кошти вже передані до розподілу.",
                buttonText = "Розподілити отримані кошти",
                runner = new DistributeAmountsRunner()
            }
        };

        public string ConnectionString { get; set; }
        public int DdexReportingPeriodId { get; set; }
        public int DdexReportId { get; set; }
        public bool AllowOverwrite { get; set; }

        public class PreRunEventArgs : EventArgs
        {
            public string ConnectionString { get; set; }
            public int DdexReportingPeriodId { get; set; }
            public int DdexReportId { get; set; }
            public bool Cancel { get; set; }
        }; 
        public delegate void PreRunEventHandler(object sender, PreRunEventArgs e);
        public event PreRunEventHandler PreRun;

        public static Workflow CreateInstance(string connectString, int ddexReportingPeriodId, int ddexReportId)
        {
            Workflow wf = new Workflow()
            {
                ConnectionString = connectString,
                DdexReportingPeriodId = ddexReportingPeriodId,
                DdexReportId = ddexReportId,
            };
            return wf;
        }

        public int GetReportStatus()
        {
            try
            {
                return (int)SqlHelpers.GetSingleValue(ConnectionString
                    , "select status from DdexReport where Id = @p0"
                    , DdexReportId);
            }
            catch (Exception ex)
            {
                Logger.WriteLine(ex.Message);
                throw;
            }
        }
        public int GetReportSubStatus()
        {
            try
            {
                return (int)SqlHelpers.GetSingleValue(ConnectionString
                    , "select substatus from DdexReport where Id = @p0"
                    , DdexReportId);
            }
            catch (Exception ex)
            {
                Logger.WriteLine(ex.Message);
                throw;
            }
        }

        public int GetPeriodStatus()
        {
            try
            {
                return (int)SqlHelpers.GetSingleValue(ConnectionString
                    , "select t1.status from DdexReportingPeriod t1 join DdexReport t2 on t2.ddexReportingPeriodId = t1.Id where t2.Id = @p0"
                    , DdexReportId);
            }
            catch (Exception ex)
            {
                Logger.WriteLine(ex.Message);
                throw;
            }
        }
        public int GetPeriodSubStatus()
        {
            try
            {
                return (int)SqlHelpers.GetSingleValue(ConnectionString
                    , "select t1.substatus from DdexReportingPeriod t1 join DdexReport t2 on t2.ddexReportingPeriodId = t1.Id where t2.Id = @p0"
                    , DdexReportId);
            }
            catch (Exception ex)
            {
                Logger.WriteLine(ex.Message);
                throw;
            }
        }

        public bool IsPeriodProcessingStarted()
        {
            try
            {
                int cnt = (int)SqlHelpers.GetSingleValue(ConnectionString
                    , @"select isnull(count(*), 0) from DdexReport where ddexReportingPeriodId = @p0
                            and (status > @p1 or status = @p1 and substatus > @p2)"
                    , DdexReportingPeriodId, Status.RAW_DATA_LOADED, SubStatus.IDLE);
                return cnt > 0;
            }
            catch (Exception ex)
            {
                Logger.WriteLine(ex.Message);
                throw;
            }
        }

        public bool CheckActionValid(ActionInfo action)
        {
            int status = (int)action.statusCode < Workflow.reportActionsCount 
                ? GetReportStatus() : GetPeriodStatus();
            int subStatus = (int)action.statusCode < Workflow.reportActionsCount
                ? GetReportSubStatus() : GetPeriodSubStatus();
            int statusForAction = (int)action.statusCode;
            if (status < statusForAction - 1 || status == statusForAction - 1 && subStatus != (int)SubStatus.SUCCEEDED)
            {
                MessageBox.Show(actions[statusForAction].notAllowedText
                    , "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (status > statusForAction || status == statusForAction && subStatus == (int)SubStatus.SUCCEEDED)
            {
                if (!AllowOverwrite)
                {
                    MessageBox.Show(actions[statusForAction].alreadyDoneText
                      , "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                else
                {
                    return DialogResult.Yes == MessageBox.Show(actions[statusForAction].alreadyDoneText
                      , "Попередження", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                }
            }
            return true;
        }

        public int GetImageIndex(int statusForAction)
        {
            int reportStatus = statusForAction < Workflow.reportActionsCount
                ? GetReportStatus() : GetPeriodStatus();
            int reportSubStatus = statusForAction < Workflow.reportActionsCount
                ? GetReportSubStatus() : GetPeriodSubStatus();

            if (statusForAction > reportStatus + 1 || statusForAction == reportStatus + 1 && reportSubStatus != (int)SubStatus.SUCCEEDED)
            {
                return (int)StateImage.FUTURE_ACTION;
            }
            else if (statusForAction < reportStatus || statusForAction == reportStatus && reportSubStatus == (int)SubStatus.SUCCEEDED)
            {
                return (int)StateImage.COMPLETED_ACTION;
            }
            else if (statusForAction == reportStatus + 1 && reportSubStatus == (int)SubStatus.SUCCEEDED)
            {
                return (int)StateImage.CURRENT_ACTION;
            }
            else
            {
                if (reportSubStatus == (int)SubStatus.IDLE)
                    return (int)StateImage.CURRENT_ACTION;
                else if (reportSubStatus == (int)SubStatus.IN_PROGRESS)
                    return (int)StateImage.INPROGRESS_ACTION;
                else // if (reportSubStatus == (int)SubStatus.FAILED)
                    return (int)StateImage.FAILED_ACTION;
            }
        }

        public void UpdateButtonStates()
        {
            foreach(var actionData in actions)
            {
                if(actionData.button != null)
                    actionData.button.ImageIndex = GetImageIndex((int)actionData.statusCode);
            }
        }

        private void UpdateStatus(int actionIndex, SubStatus subStatus)
        {
            ActionInfo action = Workflow.actions[actionIndex];
            if (actionIndex < reportActionsCount)
            {
                SqlHelpers.UpdateValues(ConnectionString
                    , "update DdexReport set status = @p1, substatus = @p2 where Id = @p0"
                    , DdexReportId, action.statusCode, subStatus);
            }
            else
            {
                SqlHelpers.UpdateValues(ConnectionString
                    , "update DdexReportingPeriod set status = @p1, substatus = @p2 where Id = @p0"
                    , DdexReportingPeriodId, action.statusCode, subStatus);
            }
        }

        public void RunAction(int actionIndex)
        {
            ActionInfo action = Workflow.actions[actionIndex];
            PreRunEventArgs args = new PreRunEventArgs()
            {
                ConnectionString = ConnectionString,
                DdexReportingPeriodId = DdexReportingPeriodId,
                DdexReportId = DdexReportId,
                Cancel = false
            };
            PreRun.Invoke(action, args);
            if (args.Cancel)
                return;
            Logger.OpenFile(action.runner);
            action.runner.Init(ConnectionString, DdexReportingPeriodId, DdexReportId);
            try
            {
                UpdateStatus(actionIndex, SubStatus.IN_PROGRESS);
                action.runner.Run();
                if (actionIndex < reportActionsCount - 1)
                    UpdateStatus(actionIndex + 1, SubStatus.IDLE);
                else if (actionIndex == reportActionsCount - 1)
                {
                    UpdateStatus(actionIndex, SubStatus.SUCCEEDED);
                    int cnt = (int)SqlHelpers.GetSingleValue(ConnectionString
                            , @"select count(*) from DdexReport 
                                where ddexReportingPeriodId = (select ddexReportingPeriodId from DdexReport where Id = @p0) 
                                    and (status < @p1 or substatus < @p2)"
                            , DdexReportId, action.statusCode, SubStatus.SUCCEEDED);
                    if (cnt == 0)
                        UpdateStatus(actionIndex + 1, SubStatus.IDLE);
                }
                else if(actionIndex == Workflow.actions.Length - 1)
                    UpdateStatus(actionIndex + 1, SubStatus.IDLE);
                else
                    UpdateStatus(actionIndex, SubStatus.SUCCEEDED);
                Logger.WriteLine("Операція закінчилась успішно.");
            }
            catch(Exception)
            {
                UpdateStatus(actionIndex, SubStatus.FAILED);
                Logger.WriteLine("Операція закінчилась з помилками.");
                throw;
            }
            finally
            {
                Logger.CloseFile();
            }
        }
    }

}
