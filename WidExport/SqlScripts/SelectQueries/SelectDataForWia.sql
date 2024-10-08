declare @objId int  = 8058

select 
	name as WrkTtl
	, null as LngCode
	, ObjId as SubmWrkNr
	, null as Iswc
	, null as CprDate
	, null as CprNr
	, 'UNC' as MwDistrCat
	, null as Dur
	, '???' as RecInd -- was recorded or not Y/N
	, null as TxtMusicRel
	, null as CmpType
	, '???' as VerType -- MOD/ORI
	, null as ExcType
	, '???' as MusicArr
	, '???' as LyrAdapt
	, null as WicCode
	, null as UpdDate
	, null as FstSendDateToCis
	, null as LstSendDateToCis
	, null as SocWrkType
from MediaService..ObjectRight
where objId = @objId

