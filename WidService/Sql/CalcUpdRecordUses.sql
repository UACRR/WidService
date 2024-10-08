
drop table if exists UpdRecUses;
create table UpdRecUses (
	UpdFileId int,
	RecAck int,
	RecAlt int,
	RecCom int,
	RecCon int,
	RecDel int,
	RecEwt int,
	RecInd int,
	RecIns int,
	RecIsw int,
	RecLnk int,
	RecMsg int,
	RecOip int,
	RecOrn int,
	RecOsr int,
	RecPer int,
	RecRes int,
	RecSip int,
	RecSoc int,
	RecSsr int,
	RecTtu int,
	RecVer int,
	RecWia int,
	RecWiu int,
	RecWpl int
)

insert SocWidUpdates..UpdRecUses( UpdFileID)  select Id from SocWidUpdates..UpdFiles;

;with counts as (select t1.Id, count(*) cnt from SocWidUpdates..UpdFiles t1 join SocWidUpdates..RecAck t2 on t1.Id = t2.UpdFileId group by t1.Id) update t1 set t1.RecAck = t2.cnt from SocWidUpdates..UpdRecUses t1 join counts t2 on t1.UpdFileId = t2.Id
;with counts as (select t1.Id, count(*) cnt from SocWidUpdates..UpdFiles t1 join SocWidUpdates..RecAlt t2 on t1.Id = t2.UpdFileId group by t1.Id) update t1 set t1.RecAlt = t2.cnt from SocWidUpdates..UpdRecUses t1 join counts t2 on t1.UpdFileId = t2.Id
;with counts as (select t1.Id, count(*) cnt from SocWidUpdates..UpdFiles t1 join SocWidUpdates..RecCom t2 on t1.Id = t2.UpdFileId group by t1.Id) update t1 set t1.RecCom = t2.cnt from SocWidUpdates..UpdRecUses t1 join counts t2 on t1.UpdFileId = t2.Id
;with counts as (select t1.Id, count(*) cnt from SocWidUpdates..UpdFiles t1 join SocWidUpdates..RecCon t2 on t1.Id = t2.UpdFileId group by t1.Id) update t1 set t1.RecCon = t2.cnt from SocWidUpdates..UpdRecUses t1 join counts t2 on t1.UpdFileId = t2.Id
;with counts as (select t1.Id, count(*) cnt from SocWidUpdates..UpdFiles t1 join SocWidUpdates..RecDel t2 on t1.Id = t2.UpdFileId group by t1.Id) update t1 set t1.RecDel = t2.cnt from SocWidUpdates..UpdRecUses t1 join counts t2 on t1.UpdFileId = t2.Id
;with counts as (select t1.Id, count(*) cnt from SocWidUpdates..UpdFiles t1 join SocWidUpdates..RecEwt t2 on t1.Id = t2.UpdFileId group by t1.Id) update t1 set t1.RecEwt = t2.cnt from SocWidUpdates..UpdRecUses t1 join counts t2 on t1.UpdFileId = t2.Id
;with counts as (select t1.Id, count(*) cnt from SocWidUpdates..UpdFiles t1 join SocWidUpdates..RecInd t2 on t1.Id = t2.UpdFileId group by t1.Id) update t1 set t1.RecInd = t2.cnt from SocWidUpdates..UpdRecUses t1 join counts t2 on t1.UpdFileId = t2.Id
;with counts as (select t1.Id, count(*) cnt from SocWidUpdates..UpdFiles t1 join SocWidUpdates..RecIns t2 on t1.Id = t2.UpdFileId group by t1.Id) update t1 set t1.RecIns = t2.cnt from SocWidUpdates..UpdRecUses t1 join counts t2 on t1.UpdFileId = t2.Id
;with counts as (select t1.Id, count(*) cnt from SocWidUpdates..UpdFiles t1 join SocWidUpdates..RecIsw t2 on t1.Id = t2.UpdFileId group by t1.Id) update t1 set t1.RecIsw = t2.cnt from SocWidUpdates..UpdRecUses t1 join counts t2 on t1.UpdFileId = t2.Id
;with counts as (select t1.Id, count(*) cnt from SocWidUpdates..UpdFiles t1 join SocWidUpdates..RecLnk t2 on t1.Id = t2.UpdFileId group by t1.Id) update t1 set t1.RecLnk = t2.cnt from SocWidUpdates..UpdRecUses t1 join counts t2 on t1.UpdFileId = t2.Id
;with counts as (select t1.Id, count(*) cnt from SocWidUpdates..UpdFiles t1 join SocWidUpdates..RecMsg t2 on t1.Id = t2.UpdFileId group by t1.Id) update t1 set t1.RecMsg = t2.cnt from SocWidUpdates..UpdRecUses t1 join counts t2 on t1.UpdFileId = t2.Id
;with counts as (select t1.Id, count(*) cnt from SocWidUpdates..UpdFiles t1 join SocWidUpdates..RecOip t2 on t1.Id = t2.UpdFileId group by t1.Id) update t1 set t1.RecOip = t2.cnt from SocWidUpdates..UpdRecUses t1 join counts t2 on t1.UpdFileId = t2.Id
;with counts as (select t1.Id, count(*) cnt from SocWidUpdates..UpdFiles t1 join SocWidUpdates..RecOrn t2 on t1.Id = t2.UpdFileId group by t1.Id) update t1 set t1.RecOrn = t2.cnt from SocWidUpdates..UpdRecUses t1 join counts t2 on t1.UpdFileId = t2.Id
;with counts as (select t1.Id, count(*) cnt from SocWidUpdates..UpdFiles t1 join SocWidUpdates..RecOsr t2 on t1.Id = t2.UpdFileId group by t1.Id) update t1 set t1.RecOsr = t2.cnt from SocWidUpdates..UpdRecUses t1 join counts t2 on t1.UpdFileId = t2.Id
;with counts as (select t1.Id, count(*) cnt from SocWidUpdates..UpdFiles t1 join SocWidUpdates..RecPer t2 on t1.Id = t2.UpdFileId group by t1.Id) update t1 set t1.RecPer = t2.cnt from SocWidUpdates..UpdRecUses t1 join counts t2 on t1.UpdFileId = t2.Id
;with counts as (select t1.Id, count(*) cnt from SocWidUpdates..UpdFiles t1 join SocWidUpdates..RecRes t2 on t1.Id = t2.UpdFileId group by t1.Id) update t1 set t1.RecRes = t2.cnt from SocWidUpdates..UpdRecUses t1 join counts t2 on t1.UpdFileId = t2.Id
;with counts as (select t1.Id, count(*) cnt from SocWidUpdates..UpdFiles t1 join SocWidUpdates..RecSip t2 on t1.Id = t2.UpdFileId group by t1.Id) update t1 set t1.RecSip = t2.cnt from SocWidUpdates..UpdRecUses t1 join counts t2 on t1.UpdFileId = t2.Id
;with counts as (select t1.Id, count(*) cnt from SocWidUpdates..UpdFiles t1 join SocWidUpdates..RecSoc t2 on t1.Id = t2.UpdFileId group by t1.Id) update t1 set t1.RecSoc = t2.cnt from SocWidUpdates..UpdRecUses t1 join counts t2 on t1.UpdFileId = t2.Id
;with counts as (select t1.Id, count(*) cnt from SocWidUpdates..UpdFiles t1 join SocWidUpdates..RecSsr t2 on t1.Id = t2.UpdFileId group by t1.Id) update t1 set t1.RecSsr = t2.cnt from SocWidUpdates..UpdRecUses t1 join counts t2 on t1.UpdFileId = t2.Id
;with counts as (select t1.Id, count(*) cnt from SocWidUpdates..UpdFiles t1 join SocWidUpdates..RecTtu t2 on t1.Id = t2.UpdFileId group by t1.Id) update t1 set t1.RecTtu = t2.cnt from SocWidUpdates..UpdRecUses t1 join counts t2 on t1.UpdFileId = t2.Id
;with counts as (select t1.Id, count(*) cnt from SocWidUpdates..UpdFiles t1 join SocWidUpdates..RecVer t2 on t1.Id = t2.UpdFileId group by t1.Id) update t1 set t1.RecVer = t2.cnt from SocWidUpdates..UpdRecUses t1 join counts t2 on t1.UpdFileId = t2.Id
;with counts as (select t1.Id, count(*) cnt from SocWidUpdates..UpdFiles t1 join SocWidUpdates..RecWia t2 on t1.Id = t2.UpdFileId group by t1.Id) update t1 set t1.RecWia = t2.cnt from SocWidUpdates..UpdRecUses t1 join counts t2 on t1.UpdFileId = t2.Id
;with counts as (select t1.Id, count(*) cnt from SocWidUpdates..UpdFiles t1 join SocWidUpdates..RecWiu t2 on t1.Id = t2.UpdFileId group by t1.Id) update t1 set t1.RecWiu = t2.cnt from SocWidUpdates..UpdRecUses t1 join counts t2 on t1.UpdFileId = t2.Id
;with counts as (select t1.Id, count(*) cnt from SocWidUpdates..UpdFiles t1 join SocWidUpdates..RecWpl t2 on t1.Id = t2.UpdFileId group by t1.Id) update t1 set t1.RecWpl = t2.cnt from SocWidUpdates..UpdRecUses t1 join counts t2 on t1.UpdFileId = t2.Id

select t2.name, t1.*
from SocWidUpdates..UpdRecUses t1
	join SocWidUpdates..[UpdFiles] t2 on t1.UpdFileId = t2.Id
where RecCom is not null
order by t2.name













