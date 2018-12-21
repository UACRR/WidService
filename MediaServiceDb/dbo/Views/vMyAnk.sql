create view vMyAnk AS 
 select t1.*, t4.name as positionNmae, t3.lastName +' '+t3.firstName+' '+ t3.surName as bossName, t3.lastName+' '+substring(t3.firstName,1,1)+'. '+substring(t3.surName,1,1)+'.' as bossShortName
 from vCustomer t1 
 join RelEmployee t2 on t1.custId = t2.custId
 join Employee t3 on t2.custId = t3.custId and t3.emplid = t2.emplid
 join PositionType t4 on t2.positionCode = t4.codeI
 where t1.ankMy = 1 and t2.positionCode = 1