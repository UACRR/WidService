USE AppleMusic
GO

/****** Object:  View [dbo].[vMSCommunity]    Script Date: 25.09.2025 13:23:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE view [dbo].[vMSCommunity] as
--Не должно быть дублей и нулов в interCOde -> свалится программа Олега (19-11-2019) по вводу исключений
with TabCmt as 
(select t1.custid, t4.name, t4.shortName, t1.innerCode, t1.interCode, t4.jaCountry, t6.countryName, t3.agrDate, t3.agrNumber, t3.dateBegin, t3.dateEnd, t2.agrStatus, 
 t3.isPER, t3.isMEC, t3.dateBeginPER, t3.dateEndPER, t3.dateBeginMEC, t3.dateEndMEC, 2 as RHolderType
 from  mediaservice..Community t1 
  join MediaService..AgreementMaster t2 on t2.custId = t1.custId
  join MediaService..AgreementAddCommunity t3 on t3.agrid = t2.agrId and t3.version = t2.version
  join MediaService..AnketaCompany t4 on t4.custId = t1.custId
  left join MediaService..AccountStatus t5 on t5.codeI = t2.agrStatus
  left join MediaService..Country t6 on t6.countryCode = t4.jaCountry
union 
 select NULL, 'AUTODIA', 'AUTODIA', NULL, '275', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, NULL, NULL, NULL, NULL, 2
  where not exists (select  1 from mediaservice..Community t2 where t2.interCode = '275')
union 
 select NULL, 'SSA', 'SSA', NULL, '328', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, NULL, NULL, NULL, NULL, 2
  where not exists (select  1 from mediaservice..Community t2 where t2.interCode = '328')
)
select  max(custid) as custId, max(name) as name, max(shortName) as shortName, max(innerCode) as innerCode, 
 interCode, max(jaCountry) as jaCountry, max(countryName) as countryName, 
 max(agrDate) as agrDate, max(agrNumber) as agrNumber, 
 max(dateBegin) as dateBegin, max(dateEnd) as dateEnd, max(agrStatus) as agrStatus, 
 max(isPER) as isPER, max(isMEC) as isMEC, max(dateBeginPER) as dateBeginPER, max(dateEndPER) as dateEndPER, max(dateBeginMEC) as dateBeginMEC, 
 max(dateEndMEC) as dateEndMEC, 2 as RHolderType 
 from TabCmt 
 where intercode is not NULL
 group by interCode 
GO


