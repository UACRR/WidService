
CREATE view [dbo].[vAgrLicenseType] as 
select t1.codeI as licCode, t1.name as licName, 
replace(replace(t1.name, 'Ліцензійний договір ',''),'договір ','') as licNmaeSh, 
t1.kindCode, t2.name as kindName, t2.crGroupCode, t3.name as crGroupName, 
t1.usesKind, t4.name as usesKindName, t4.usesType, t5.name as usesTypeName, t1.schemaId, t1.algorithmId, t1.series
from AgrLicenseType t1 
join CopyrightKind t2 on t1.kindCode = t2.codeI 
join CRKindGroup t3 on t2.crGroupCode = t3.codeI 
join usesKind t4 on t1.usesKind = t4.codeI 
join usestype t5 on t4.usesType = t5.codeI