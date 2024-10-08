
/*
WITH cte (lvl, object_id, name, schema_Name) AS
  (SELECT 1, object_id, sys.tables.name, sys.schemas.name as schema_Name
   FROM sys.tables Inner Join sys.schemas on sys.tables.schema_id = sys.schemas.schema_id
   WHERE type_desc = 'USER_TABLE'
     AND is_ms_shipped = 0
   UNION ALL SELECT cte.lvl + 1, t.object_id, t.name, S.name as schema_Name
   FROM cte
   JOIN sys.tables AS t ON EXISTS
     (SELECT NULL FROM sys.foreign_keys AS fk
      WHERE fk.parent_object_id = t.object_id
        AND fk.referenced_object_id = cte.object_id )
   JOIN sys.schemas as S on t.schema_id = S.schema_id
   AND t.object_id <> cte.object_id
   AND cte.lvl < 30
   WHERE t.type_desc = 'USER_TABLE'
     AND t.is_ms_shipped = 0 )
SELECT schema_Name, name, MAX (lvl) AS dependency_level
FROM cte
GROUP BY schema_Name, name
ORDER BY dependency_level desc,schema_Name, name;
*/

delete from WidSubmGroupWork
delete from WidSubmGroupWorkName
delete from WidSubmGroupWorkPerformer
delete from WidSubmGroupWorkShare
delete from RecAlt
delete from RecGrh
delete from RecGrt
delete from RecHdr
delete from RecOip
delete from RecOsr
delete from RecPer
delete from RecSip
delete from RecSsr
delete from RecTrl
delete from RecWia
delete from RecWiu
delete from SubmFile
delete from WidSubmGroupParty
delete from WidSubmGroupPartyWork
delete from WidSubmGroupWorkCheckList
delete from RecAck
delete from RecGrhRsp
delete from RecGrtRsp
delete from RecHdrRsp
delete from RecMsg
delete from RecTrlRsp
delete from RespFileErr
delete from WidSubmGroup
delete from RespFile
