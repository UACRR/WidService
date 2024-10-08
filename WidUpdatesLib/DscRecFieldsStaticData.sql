select 'new DscRecField { '
	+ 'RecTypeCode = "' + RecTypeCode + '", '
	+ 'SeqNr = ' + convert(varchar(1000), SeqNr) + ', '
	+ 'Field = "' + convert(varchar(1000), Field) + '", '
	+ 'Start = ' + convert(varchar(1000), Start) + ', '
	+ 'Size = ' + convert(varchar(1000), Size) + ', '
	+ 'Fmt = ''' + convert(varchar(1000), Fmt) + ''', '
	+ 'Req = ''' + convert(varchar(1000), Req) + ''', '
	+ 'Rules = "' + convert(varchar(1000), Rules) + '", '
	+ 'Dsc = "' + convert(varchar(1000), Dsc) + '", '
	+ ' },'
from DscRecFields
order by rectypecode, seqnr

;with FieldNames as (
	select distinct Field
	from  DscRecFields
)
select 'new DscFieldColName { '
	+ 'FieldName = "' + Field + '", '
	+ 'ColName = "' + Field + '", '
	+ ' },'
from FieldNames

select *
from DscRecType
