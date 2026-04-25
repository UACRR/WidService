using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidSubmit
{
	public enum SubmStatusEnum
	{
		  INITIAL
		, SUBM_FILE_CREATED
		, SUBM_FILE_UPLOADED
		, RESP_FILE_DOWNLOADED
		, RESP_WRONG_SUBM_FILE
		, RESP_FILE_PROCESSED
		, ISWC_CODES_PASSED_TO_MS
		, COMPLETED
	}

	public enum SubmWorkStatusEnum
    {
	      NOT_READY
	    , READY
	    , SUBMITTED
	    , ACCEPTED
	    , ACCEPTED_WARNINGS
        , REJECTED
	    , APPLIED
	    , COMPLETED
    }

	public enum PubStatusEnum
	{
		NOT_SENT,
		ACCEPTED,
		REJECTED,
	}
}
