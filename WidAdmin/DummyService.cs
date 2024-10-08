using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WidAdminLib
{
    public class DummyService
    {
        public delegate void ActionStarted();
        public delegate void ActionInProgress(int percentDone);
        public delegate void ActionCompleted();
        public delegate void ActionFailed(string errMsg);

        public void RunFileDownload(
            ActionStarted actionStarteHandler,
            ActionInProgress actionInProgressHandler,
            ActionCompleted actionCompletedHandler,
            ActionFailed actionFailedHandler
        )
        {
            actionStarteHandler();
            for(int i = 0; i < 1000; i += 100)
            {
                Task.Delay(2000).Wait();
                actionInProgressHandler(i / 10);
            }
            actionCompletedHandler();

        }
        public void RunFileUnzip(
            ActionStarted actionStarteHandler,
            ActionInProgress actionInProgressHandler,
            ActionCompleted actionCompletedHandler,
            ActionFailed actionFailedHandler
        )
        {
            actionStarteHandler();
            for (int i = 0; i < 1000; i += 100)
            {
                Task.Delay(2000).Wait();
                if(i > 500)
                {
                    actionFailedHandler("Some strange error occured");
                    return;
                }
                actionInProgressHandler(i / 10);
            }
            //actionFailedHandler("Some error message");
            actionCompletedHandler();
        }
        public void RunFileZipDelete(
            ActionStarted actionStarteHandler,
            ActionInProgress actionInProgressHandler,
            ActionCompleted actionCompletedHandler,
            ActionCompleted actionFailedHandler
        )
        {
            actionStarteHandler();
            for (int i = 0; i < 1000; i += 100)
            {
                Task.Delay(2000).Wait();
                actionInProgressHandler(i / 10);
            }
            actionCompletedHandler();

        }
        public void RunDumpFileApplyToDb(
            ActionStarted actionStarteHandler,
            ActionInProgress actionInProgressHandler,
            ActionCompleted actionCompletedHandler,
            ActionCompleted actionFailedHandler
        )
        {
            actionStarteHandler();
            for (int i = 0; i < 1000; i += 100)
            {
                Task.Delay(2000).Wait();
                actionInProgressHandler(i / 10);
            }
            actionCompletedHandler();

        }

        public void RunUpdateFileApplyToDb(
            ActionStarted actionStarteHandler,
            ActionInProgress actionInProgressHandler,
            ActionCompleted actionCompletedHandler,
            ActionCompleted actionFailedHandler
        )
        {
            actionStarteHandler();
            for (int i = 0; i < 1000; i += 100)
            {
                Task.Delay(2000).Wait();
                actionInProgressHandler(i / 10);
            }
            actionCompletedHandler();

        }
        public void RunFileDelete(
            ActionStarted actionStarteHandler,
            ActionInProgress actionInProgressHandler,
            ActionCompleted actionCompletedHandler,
            ActionCompleted actionFailedHandler
        )
        {
            actionStarteHandler();
            for (int i = 0; i < 1000; i += 100)
            {
                Task.Delay(2000).Wait();
                actionInProgressHandler(i / 10);
            }
            actionCompletedHandler();
        }

        public void RunCalcWidDumpTs(
            ActionStarted actionStarteHandler,
            ActionInProgress actionInProgressHandler,
            ActionCompleted actionCompletedHandler,
            ActionCompleted actionFailedHandler
        )
        {
            actionStarteHandler();
            for (int i = 0; i < 1000; i += 100)
            {
                Task.Delay(2000).Wait();
                actionInProgressHandler(i / 10);
            }
            actionCompletedHandler();
        }

        public void RunTableApplyToDb(
            ActionStarted actionStarteHandler,
            ActionInProgress actionInProgressHandler,
            ActionCompleted actionCompletedHandler,
            ActionCompleted actionFailedHandler
        )
        {
            actionStarteHandler();
            for (int i = 0; i < 1000; i += 100)
            {
                Task.Delay(2000).Wait();
                actionInProgressHandler(i / 10);
            }
            actionCompletedHandler();
        }

    }
}
