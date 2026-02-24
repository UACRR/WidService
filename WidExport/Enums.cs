using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidExport
{
    public enum WidSubmGroupWorkStatusEnum
    {
        Unprocessed = 0,
        InWork = 1,
        Postponed = 2,
        Accepted = 3,
        Sent = 4,
        Approved = 5,
        Rejected = 6,
        PartApproved = 7,
        AlreadyInWid = 8,
        ReSent = 9,
        Completed = 10,
        Uploaded = 11,
    }

    public enum WidSubmGroupStatus
    {
        Active = 0,
        Closed = 1,
    }
    public enum ExchangeFileStatus
    {
        Created = 0,
        Submitted = 1,
        Responded = 2,
        Declined = 3,
        Uploaded = 4,
    }

}
