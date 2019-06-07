
/*==============================================================*/
/* View: myAnketa                                               */
/*==============================================================*/
create view [myAnketaParam] as
select t1.custID, t1.name as myName, InnOKPO as myInnOKPO,  
( select max(r030) as r030 from Currency where prNc=1 ) as myR030, 
( select max(a3) as A3 from Currency where prNc=1 ) as myCurrencyLit, 
( select max(kod_lit) as kod_lit from country where countryCode = t1.countryCode ) as myCountryLit, 
 t1.countryCode,  
 isnull(isnull(a1.jaAddress, a2.reAddress),'No Address!') as myAddress, 
 ltrim(isnull(y1.firstName,'') + ' '+isnull(y1.surName,'') + ' '+isnull(y1.lastName,'')) as myDirector
from vcustomer t1 
  left join AnketaCompany a1 on t1.custId = a1.custId and a1.version = isnull(t1.ankVersion,0)
  left join AnketaPerson a2 on t1.custId = a2.custId and a1.version = isnull(t1.ankVersion,0)
  left join RelEmployee e1 on t1.custID = e1.custId and e1.positionCode = 1
  left join Employee y1 on y1.emplid = e1.emplid 
where ankMy = 1
GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Данные анкеты владельца сайта', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'myAnketaParam';

