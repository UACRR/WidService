CREATE view vTermsOfService as 
(
select t1.custId as rhCustId, t1.innerCode, t1.interCode, t1.rHolderType, 
        t7.CRKindCode, t7.ourService, isnull(t6.cmCustId, t5.custId) as cmCustId, t6.dateBegin, t6.dateEnd, 
		isnull(t4.name, t5.name) as cmName
		 from rightHolder t1 
   join TermsOfService t7 on t7.custId = t1.custId --and t3.CRKindCode = t1.kindCode 
   left join CustCmRight t6 on t6.custId = t7.custId and t6.cRKindCode = t7.CRKindCode
   left join vMyAnk t5 on t5.custId = t5.custId
   left join vCustomer t4 on t6.cmCustId = t4.custId
 union 
  select -1 as rhCustId, NULL as innerCode, NULL as integrCode, NULL as rHolderType, t1.codei, 0 as ourService, -1 as cmCustId, 
         NULL as dateBegin, NULL as dateEnd, 'НЕ ВИЗНАЧЕНО' as cmName
    from CopyRightKind t1
   )

--select * from vTermsOfService