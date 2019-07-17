CREATE  procedure pTsk4_GetRHNdog @agrId integer
as
begin
 declare @RetCode integer, @typeAlg smallint, @custId integer
 set @RetCode = 0

 set @typeAlg  = (select max(typeAlg) from MyAnketa)

-- Номер договора с правообладателем (agrType = 1 )
  update AgreementAddRH set agrNumber = t3.innerCode 
   from AgreementAddRH t1 
    join AgreementMaster t2 on t2.custId = t1.custId and t2.agrType = 1 
	join RightHolder t3 on t3.custId = t2.custId
  where t2.agrId = @agrId and  @typeAlg = 1 and isnull(agrNumber, '') = '' 

RETURN @RetCode
end

--exec  pTsk4_GetRHNdog 3
--select * from AgreementAddRH t1 join AgreementMaster t2 on t2.custId = t1.custId and t2.agrType = 1 
--update MyAnketa set typealg = 1