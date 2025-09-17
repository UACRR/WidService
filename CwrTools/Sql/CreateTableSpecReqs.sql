use CWR
go

drop table if exists SpecReqs
create table SpecReqs (
	  Code char(1) primary key
	, Description varchar(max)
)

insert SpecReqs (
	  Code
	, Description
)
values
	  ('M', 'Mandatory, meaning this field must be filled out. If it is not filled out, this record will be rejected and, depending on the record type, the entire transaction may be rejected. Note that not all record types are mandatory; however, there are mandatory fields within optional records.')
	, ('C', 'Conditional, meaning this field may be Mandatory depending on other conditions that exist in either the current record or the transaction. If the condition results in a mandatory field and this field is not present, this record will be rejected and, depending on the record type, the entire transaction may be rejected.')
	, ('O', 'Optional, meaning this field may or may not be entered.')