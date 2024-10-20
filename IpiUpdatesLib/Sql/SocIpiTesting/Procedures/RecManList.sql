use SocIpiTesting
go

create or alter procedure spCreateRecManList
as
begin
	drop table if exists RecManList
	select
		  t1.FileId
		, t1.TransSeqNr
		, t1.RecSeqNr
		, ( 
			select isnull(min(t2.RecSeqNr), '99999999')
			from RecMan t2 
			where t2.FileId = t1.FileId
				and t2.TransSeqNr = t1.TransSeqNr
				and t2.RecSeqNr > t1.RecSeqNr
		  ) as NextRecSeqNr
	into RecManList
	from RecMan t1
--		join RecIpa t0 on t0.FileId = t1.FileId
--			and t0.TransSeqNr = t1.TransSeqNr
--	where t0.IpBaseNr = 'I-003712137-0'
--		and t1.RolCde ='MC'
--		and t1.RgtCde = 'PR'
/*select *
from RecManList t1
		join RecIpa t0 on t0.FileId = t1.FileId
			and t0.TransSeqNr = t1.TransSeqNr
where t0.IpBaseNr = 'I-003712137-0'

		select *
		from FullDumpFileRecords
		where FileId = 23
			 and substring(text, 4, 8) = '00082658'

216879194	13	IPA000826580000000020020313212121080SUISA               I-001808813-4100166555448PAI-001808813-4100166555448PA
216879195	13	BDN0008265800000001N                                                                                                                     20020313212121
216879196	13	STN0008265800000002I-001808813-41200203132121219999123123595920020313212121
216879197	13	NCN000826580000000300166555448KIMURA                                                                                    MAKI                                         PA2002031321212120020313212121

		select *
		from FullDumpFileRecords
		where fileid = 23 and substring(Text, 57, 13) = 'I-003712137-0'
*/

end

-- exec spCreateRecManList