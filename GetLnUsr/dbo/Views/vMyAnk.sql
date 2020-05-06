CREATE view [dbo].[vMyAnk] AS 
 select t1.*, t4.name as positionNmae, 
 t3.lastName +' '+t3.firstName+' '+ t3.surName as bossName, 
 isnull(t3.lastName,'')+isnull(' '+substring(t3.firstName,1,1),'')+isnull('. '+substring(t3.surName,1,1)+'.','') as bossShortName, 
 t5.interCode,
 t0.typeAlg
 from myAnketa t0 
 join vCustomer t1 on t1.custId = t0.custId
 join RelEmployee t2 on t1.custId = t2.custId
 --join Employee t3 on t2.custId = t3.custId and t3.emplid = t2.emplid
 left join Employee t3 on t3.emplid = t2.emplid
 left join PositionType t4 on t2.positionCode = t4.codeI
 left join community t5 on t5.custId = t1.custId 
 where t1.ankMy = 1 and t2.positionCode = 1

GO
GRANT SELECT
    ON OBJECT::[dbo].[vMyAnk] TO [ReportUser]
    AS [dbo];

