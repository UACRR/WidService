using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLib
{
    internal enum WidTaskTypeCodeEnum
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
        RenSocWidToSocWid_= 10,
        RenSocWidInitialToSocWid = 11,
        RenSocWid_ToSocWidInitial = 12,
    }
    internal enum WidTaskStatusCodeEnum
    {
        Pending = 1,
        InProgress = 2,
        Completed = 3,
        Failed = 4,
    }
    internal enum  WidTaskSubjectTypeCodeEnum
    {
        InitFromDump = 1,
        CalcInitDumpTs = 2,
        UpdateFromTranFiles = 3,
        InitNewDump = 4,
        CalcNewDumpTs = 5,
        UpdateFromNewDump = 6,
    }
}
