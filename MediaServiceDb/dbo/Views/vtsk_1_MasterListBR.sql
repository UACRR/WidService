


/*==============================================================*/
/* View: vtsk_1_MasterList                                      */
/*==============================================================*/
CREATE view [dbo].[vtsk_1_MasterListBR] as
--Текщее состояние мастера, если есть новая версия - она указывается и ее статус
with MasterInfo as 
(
select t1.agrid, t1.version, t1.agrStatus 
 from AgreementAddBR t1
 -- where agrStatus <> 4
), 
--Лицензии больших прав технические
LicenseInfo as 
(
select custId, licId 
 from LicenseAgreement t2 
  join vAgrLicenseType t3 on t2.licCode = t3.licCode and t3.usesType = 1
  where licClass = 1 and licStatus <> 4 
)
,
--Нерозподілені кошти по великих правах
PaidInfo as 
(
select max(t2.custId) as custId, t1.licId, sum(t1.amount) as amount, sum(t1.distribAmount) as distribAmount, sum(t1.undistribAmount) as undistribAmount, 
 sum((case  t1.status When 3 Then 1 else 0 end)*isnull(t1.undistribAmount,0)) as borg
 from PaidPeriod t1 
  join LicenseInfo t2 on t1.licId = t2.licId 
  group by t1.licId 
),
--Непривязані кошти Клієнтів
MoneyInfo as (
select t0.custId, sum( amount - isnull(destribAmount,0) ) as unattachAmount 
from 
  LicenseInfo t0 
  join MoneyReceived t2 on t2.custId = t0.custId
WHERE (amount - isnull(destribAmount,0)) > 0
group by t0.custId
)
,
--Подсчеты количества
CountInfo as 
(
select agrId,  
       sum((Case When t1.licType = 1 and t3.licStatus = 2 then 1 else 0 end)) as countLic1Active, --к-ть активних ліцензій
       sum((Case When t1.licType = 1 and  t3.licStatus not in (2, 4) then 1 else 0 end)) as countLic1NoActive, --к-ть не активних ліцензий
       sum((Case When t1.licType = 1 and getdate()<= dateadd(day,60,t3.dateEnd) then 1 else 0 end)) as countLic1ToProlong, --к-ть ліцензій для пролонгації

       max((Case When t1.licType = 1 and  t1.licStatus = 2 then 1 else 0 end)) as StatusLic1Active, --к-ть активних ліцензій
       max((Case When t1.licType = 1 and  t3.licStatus not in (2, 4) then 1 else 0 end)) as StatusLic1NoActive, --к-ть не активних ліцензий
       max((Case When t1.licType = 1 and getdate()<= dateadd(day,60,t3.dateEnd) then 1 else 0 end)) as StatusLic1ToProlong, --к-ть ліцензій для пролонгації

       sum((Case When t1.licType = 2 and t3.licStatus = 2 then 1 else 0 end)) as countLic2Active, --к-ть активних заявок
       sum((Case When t1.licType = 2 and  t3.licStatus not in (2, 4) then 1 else 0 end)) as countLic2NoActive, --к-ть не активних заявок

       max((Case When t1.licType = 2 and t3.licStatus = 2 then 1 else 0 end)) as StatusLic2Active, --к-ть активних заявок
       max((Case When t1.licType = 2 and  t3.licStatus not in (2, 4) then 1 else 0 end)) as statusLic2NoActive, --к-ть не активних заявок

       sum((Case When t1.licType = 3 and t3.licStatus = 2 then 1 else 0 end)) as countLic3Active, --к-ть активних заявок
       sum((Case When t1.licType = 3 and  t3.licStatus not in (2, 4) then 1 else 0 end)) as countLic3NoActive, --к-ть не активних заявок

       max((Case When t1.licType = 3 and t3.licStatus = 2 then 1 else 0 end)) as statusLic3Active, --к-ть активних заявок
       max((Case When t1.licType = 3 and  t3.licStatus not in (2, 4) then 1 else 0 end)) as statusLic3NoActive --к-ть не активних заявок
  
  from licenseAgreement t1 
       join licenseAgrParam t3 on t1.licId = t3.licId and t3.licVersion = t1.licVersion and isnull(t3.licStatus,0) <> 4 --не закритий
       join vAgrLicenseType t2 on t1.licCode = t2.licCode and t2.usesType = 1
  where t1.licStatus <> 4 and licClass = 2
  group by agrId 
), 
--Дата последнего платежа
payLast as 
(select custId, max(dateInvoice) as maxDateInvoice 
from MoneyReceived group by custId
), 
--остаток аванса
infoAuthorBR as 
(select  t2.custId, sum(isnull(t1.prepayRest,0)) as prepayRest
from licAuthorBr t1 
join CopyRight cr on cr.cRightId = t1.cRightId
join LicenseBigR br on br.objId = cr.objId
join licenseAgreement t2 on t2.licId = br.licId
group by t2.custId)

select t2.agrType, t3.name as agrTypeName, t1.custId, t1.INNOKPO, 
t2.agrId, t4.agrNumber , t4.agrDate, 
t4.dateBegin, t4.dateEnd,
t1.name, t1.jaCity, 
t2.agrStatus, t5.name as statusName,
t7.agrStatus as addStatus, t6.name as addStatusName
, isnull(t12.countLic1Active,0) as countLic1Active            --к-ть ліцензій
, isnull(t12.countLic1NoActive,0) as countLic1NoActive        --к-ть ліц.не акцептованих
, isnull(t12.countLic1ToProlong, 0) as countLic1ToProlong     --к-ть ліцензій для пролонгації
--к-ть заявок
, isnull(t12.countLic2Active, 0) as countLic2Active --к-ть заявок
, isnull(t12.countLic2NoActive,0) as countLic2NoActive --к-ть заявок не акцептованих
--к-ть довідок
, isnull(t12.countLic3Active,0) as countLic3Active --к-ть довідок активних
, isnull(t12.countLic3NoActive,0) as countLic3NoActive --к-ть довідок не акцептованих
, isnull(t9.undistribAmount,0) as undistribAmount,  --нерозподілені кошти
  isnull(t9.borg,0) as borg, --Борг
t13.unattachAmount,  --не привязанные средства
t14.prePayRest,  --залишок авансу
t15.maxDateInvoice as datePayLast,
t10.clcustId, t11.name as partnerName,  --інспектор
t1.jaCity+' '+t1.jaAddress as jaAddress,  -- адрес Клиента
--Статусы для закладок. Можно убрать и селектить иначе. 
(Case when t2.agrStatus = 2 Then 1 Else 0 end) as statusMasterActive,
(Case when t7.agrStatus = 1 Then 1 Else 0 end) as statusMasterNoactive,
(Case when isnull(t4.dateEnd,'3000-01-01')<=dateadd(day, 60,getdate()) Then 1 Else 0 end) as statusMasterProlong,
(Case when (isnull(t9.amount,0) > isnull(t9.distribAmount,0)+isnull(t9.undistribAmount,0)) 
   or (isnull(t13.unattachAmount,0) <> 0 ) Then 1 Else 0 end) as statusUndistribute, 
isnull(t12.statusLic1Active,0) as statusLic1Active, 
isnull(t12.statusLic1NoActive,0) as statusLic1NoActive, 
isnull(t12.statusLic1ToProlong,0) as statusLic1ToProlong, 
isnull(t12.statusLic2Active,0) as statusLic2Active, 
isnull(t12.statusLic2NoActive, 0) as statusLic2NoActive, 
isnull(t12.statusLic3Active,0) as statusLic3Active, 
isnull(t12.statusLic3NoActive,0) as statusLic3NoActive
--
from AgreementMaster t2 
join AgreementAddBR t4 on t4.agrId = t2.agrId and t4.version = t2.version 
left join  MasterInfo t7 on t7.agrId = t2.agrId and t2.version = t7.version
join vCustomer t1  on t1.custId = t2.custId
join AgreementType t3 on t3.codeI = t2.agrType
join agreementStatus t5 on t5.codeI = t2.agrStatus
join agreementStatus t6 on t6.codeI = t7.agrStatus
join LicenseAgreement t8 on t2.agrId = t8.agrId and licClass = 1
left join PaidInfo t9 on t8.licId = t9.licId 
left join PartnerClient t10 on t2.custId = t10.clCustId
left join vCustomer t11 on t10.custId = t11.custId 
left join CountInfo t12 on t12.agrId = t2.agrId
left join MoneyInfo t13 on t2.custId = t13.custId
left join infoAuthorBR t14 on t14.custId = t2.custId 
left join payLast t15 on t15.custId = t2.custId 
--select * from vtsk_1_MasterListBR