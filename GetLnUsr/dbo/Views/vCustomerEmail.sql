
create view vCustomerEmail as 
select t1.custid, t1.custType, t1.userId, t2.eMail, t2.phoneMobileMain
  from customer t1 
   join AnketaPerson t2 on t2.custId = t1.custId 
 union 
 select t0.custId, t0.custType, t0.userId, email, phoneNumber
    from customer t0 
	 join RelEmployee t1 on t1.custId = t0.custId
	 join Employee t2 on t1.emplid = t2.emplid and t1.positionCode = 3

