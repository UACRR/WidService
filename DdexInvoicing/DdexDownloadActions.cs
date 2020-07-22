using InvoicingLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DdexInvoicing
{
    public enum StatusImage
    {
          FUTURE_ACTION = -1
        , COMPLETED_ACTION = 0
        , CURRENT_ACTION = 1
        , FAILED_ACTION = 2
        , INPROGRESS_ACTION = 3
    }

    public static class DdexDownloadActions
    {
        public static Dictionary<string, ActionRunner> actionRunners;

        public static void Init()
        {
            if (actionRunners == null)
            {
                actionRunners = new Dictionary<string, ActionRunner>();
                actionRunners.Add("DetectErrorsRunner", new DetectErrorsRunner());
                actionRunners.Add("LoadIntoDbRunner", new LoadIntoDbRunner());
                actionRunners.Add("MergeMusicWorksRunner", new MergeMusicWorksRunner());
                actionRunners.Add("CreateIdentBacklogRunner", new CreateIdentBacklogRunner());
                actionRunners.Add("CreateIdentBacklogToMwLinkRunner", new CreateIdentBacklogToMwLinkRunner());
                actionRunners.Add("CreatePseudoNetRevenueRunner", new CreatePseudoNetRevenueRunner());
                actionRunners.Add("CalcNetRevenuePerMusicWorkRunner", new CalcNetRevenuePerMusicWorkRunner());
                actionRunners.Add("AutoIdentByIswcRunner", new AutoIdentByIswcRunner());
                actionRunners.Add("CalcMwPrioritiesRunner", new CalcMwPrioritiesRunner());
                actionRunners.Add("CalcBasicReportStatisticsRunner", new CalcBasicReportStatisticsRunner());
                actionRunners.Add("CalcDetailedReportStatisticsRunner", new CalcDetailedReportStatisticsRunner());
                actionRunners.Add("CalcPriorityBlocksStatisticsRunner", new CalcPriorityBlocksStatisticsRunner());
                actionRunners.Add("IdentMwAuthorsRunner", new IdentMwAuthorsRunner());
                actionRunners.Add("ProcessExclusionsRunner", new ProcessExclusionsRunner());
                actionRunners.Add("CalcMarketShareRunner", new CalcMarketShareRunner());
            }
        }

        public static bool IsDownloadState(int status)
        {
            return Meta.DdexReportStatus.Action(status) != "";
        }

        /*
        public void RunAction(int actionIndex)
        {
            ActionInfo_old action = actions[actionIndex];
            Logger.OpenFile(action.runner);
            action.runner.Init(ConnectionString, DdexReportingPeriodId, DdexReportId);
            try
            {
                action.runner.Run();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Logger.CloseFile();
            }
        }
        */
    }

}
