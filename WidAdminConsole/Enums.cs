using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLib
{
    public enum WidTaskTypeCodeEnum
    {
        FileDownload = 1,
        FileUnzip = 2,
        FileZipDelete = 3,
        FileApplyToDb = 4,
        FileDelete = 5,
        CalcWidDumpTs = 6,
        TableApplyToDb = 7,
        FileApplyToSocDb = 8,
        CreateHistRecords = 9,
    }
    public enum WidTaskStatusCodeEnum
    {
        Pending = 1,
        InProgress = 2,
        Completed = 3,
        Failed = 4,
    }
    public enum WidTaskSubjectTypeCodeEnum
    {
        InitFromDump = 1,
        CalcInitDumpTs = 2,
        UpdateFromTranFiles = 3,
        InitNewDump = 4,
        CalcNewDumpTs = 5,
        UpdateFromNewDump = 6,
    }
}
