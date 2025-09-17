use CWR
go

drop table if exists SpecRecords
create table SpecRecords (
	  RecordType char(3) primary key
	, SeqNr int
	, IsTran bit
	, IsDetail bit
	, TableName varchar(6)
	, Description varchar(64)

)

insert SpecRecords
values
	  ('HDR', 01, 0, 0, 'RecHdr', 'Transmission Header')
	, ('GRH', 02, 0, 0, 'RecGrh', 'Group Header')
	, ('GRT', 03, 0, 0, 'RecGrt', 'Group Trailer')
	, ('TRL', 04, 0, 0, 'RecTrl', 'Transmission Trailer')
	, ('AGR', 05, 1, 0, 'RecAgr', 'Agreement Supporting Work Registration')
	, ('NWR', 06, 1, 0, 'RecNwr', 'New Work Registration')
	, ('REV', 07, 1, 0, 'RecRev', 'Revised Registration')
	, ('ISW', 08, 1, 0, 'RecIsw', 'Notification of ISWC assign to a work')
	, ('EXC', 09, 1, 0, 'RecExc', 'Existing work which is in Conflict with a Work Registration')
	, ('ACK', 10, 1, 0, 'RecAck', 'Acknowledgement of Transaction')
	, ('TER', 11, 0, 1, 'RecTer', 'Territory in Agreement')
	, ('IPA', 12, 0, 1, 'RecIpa', 'Interested Party of Agreement')
	, ('NPA', 13, 0, 1, 'RecNpa', 'Non-Roman Alphabet Agreement Party Name')
	, ('SPU', 14, 0, 1, 'RecSpu', 'Publisher Controlled By Submitter')
	, ('OPU', 15, 0, 1, 'RecOpu', 'Other Publisher')
	, ('NPN', 16, 0, 1, 'RecNpn', 'Non-Roman Alphabet Publisher Name')
	, ('SPT', 17, 0, 1, 'RecSpt', 'Publisher Territory of Control')
	, ('OPT', 18, 0, 1, 'RecOpt', 'Publisher Non-Controlled Collection')
	, ('SWR', 19, 0, 1, 'RecSwr', 'Writer Controlled By Submitter')
	, ('OWR', 20, 0, 1, 'RecOwr', 'Other Writer')
	, ('NWN', 21, 0, 1, 'RecNwn', 'Non-Roman Alphabet Writer Name')
	, ('SWT', 22, 0, 1, 'RecSwt', 'Writer Territory of Control')
	, ('OWT', 23, 0, 1, 'RecOwt', 'Other Writer Collection')
	, ('PWR', 24, 0, 1, 'RecPwr', 'Publisher For Writer')
	, ('ALT', 25, 0, 1, 'RecAlt', 'Alternate Title')
	, ('NAT', 26, 0, 1, 'RecNat', 'Non-Roman Alphabet Title')
	, ('EWT', 27, 0, 1, 'RecEwt', 'Entire Work Title for Excerpts')
	, ('VER', 28, 0, 1, 'RecVer', 'Original Work Title for Versions')
	, ('PER', 29, 0, 1, 'RecPer', 'Performing Artist')
	, ('NPR', 30, 0, 1, 'RecNpr', 'Performance Data in non-roman alphabet')
	, ('REC', 31, 0, 1, 'RecRec', 'Recording Detail')
	, ('ORN', 32, 0, 1, 'RecOrn', 'Work Origin')
	, ('INS', 33, 0, 1, 'RecIns', 'Instrumentation Summary')
	, ('IND', 34, 0, 1, 'RecInd', 'Instrumentation Detail')
	, ('COM', 35, 0, 1, 'RecCom', 'Component')
	, ('MSG', 36, 0, 1, 'RecMsg', 'Message')
	, ('NET', 37, 0, 1, 'RecNet', 'Non-Roman Alphabet Entire Work Title for Excerpts')
	, ('NCT', 38, 0, 1, 'RecNct', 'Non-Roman Alphabet Title for Components')
	, ('NVT', 39, 0, 1, 'RecNvt', 'Non-Roman Alphabet Original Title for Version')
	, ('NOW', 40, 0, 1, 'RecNow', 'Non-Roman Alphabet Other Writer Name')
	, ('ARI', 41, 0, 1, 'RecAri', 'Additional Related Information')
	, ('XRF', 42, 0, 1, 'RecXrf', 'Work ID Cross Reference')
