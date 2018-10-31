---------------------
CREATE PROCEDURE dbo.OpenAccountFound   
AS   
declare @Cur_NC char(3), @RetCode integer
set @Cur_NC = (select r030 from currency where prnc = 1)                                                             
set @RetCode = 0

create table #TmpMask 
(MaskN varchar(20)   collate Ukrainian_100_CI_AS not null,
 primary key (MaskN)) 

BEGIN
begin Transaction OpenAccount 
    BEGIN TRY

--Открываю счета для правообладателей
delete #TmpMask
insert into #TmpMask (MaskN) 
select '20000' 
union 
select '21000' 

--Основной счет
insert into Account   (AccStatus, BalsCode, CustID, R030, AccNls, DateOpen, AccDk, AccName)
select 0, t7.BalsCode,  t.CustId, @Cur_NC, 
     MaskN + rtrim(right(convert(char(8),CustId),8)), getdate(), t7.BalsType, t.name
from AccountBals t7, #TmpMask t77, 
     (select t1.CustId, isnull(t22.name, t33.lastname) as name from RightHolder t1 
           join Customer t11 on t1.custId = t11.CustId 
           left outer join AnketaCompany t22 on t11.custId = t22.CustId and t11.ankversion = t22.version
           left outer join AnketaPerson t33 on t11.custId = t33.CustId and t11.ankversion = t33.version
  where  t11.status = 2 and 
         not exists ( select 1 from Account t2, #TmpMask tm  
                         where  t1.CustId = t2.CustId and left(AccNls,5) = tm.MaskN) ) t
 where t7.BalsCode = convert(integer, left(t77.MaskN,2))

--АВТVVNNNNNNNN, счет объекта права по видам права
insert into Account (AccStatus, BalsCode, ObjId, R030, AccNLS, DateOpen, AccDK, AccName) 
select distinct 0, t7.BalsCode, t1.objid, 980, 
   convert(char(2),t7.BalsCode)+convert(char(1), t3.CRType)+
   right(convert(char(3),100+t3.CRKindCode),2)+rtrim(convert(char(8),t1.objid)), 
   getdate(), t7.BalsType, t1.name + tk.CRKindNameUk  
   from AccountBals t7, 
        ObjectRight t1, 
       CprtKindGroup t3  
          join RelReqObj t11 on t11.kindGroupId = t3.kindGroupId
          join CopyrightKind tk on t3.CRKindCode = tk.CRKindCode 
where   
    not exists (select 1 from Account t0  where t1.objid = t0.objid  
    and  convert(char(2),t7.BalsCode)+convert(char(1), t3.CRType)+right(convert(char(3),100+t3.CRKindCode),2)+rtrim(convert(char(8),objid)) = t0.AccNls)
    and t7.BalsCode = 30


 IF @@TRANCOUNT > 0 commit tran
END TRY

BEGIN CATCH
  IF @@TRANCOUNT > 0 rollback tran
    DECLARE @ErrorMessage NVARCHAR(4000);
    DECLARE @ErrorSeverity INT;
    DECLARE @ErrorState INT;
    SELECT @ErrorMessage = ERROR_MESSAGE(),
           @ErrorSeverity = ERROR_SEVERITY(),
           @ErrorState = ERROR_STATE();

    -- Use RAISERROR inside the CATCH block to return 
    -- error information about the original error that 
    -- caused execution to jump to the CATCH block.
    RAISERROR (@ErrorMessage, -- Message text.
               @ErrorSeverity, -- Severity.
               @ErrorState -- State.
               );
 set @Retcode = 1

END CATCH

Return @Retcode
END

/*
select * from Account order by custid, ObjId, CRightID
exec dbo.OpenAccount  31, NULL
--delete Account  where custid=37 or objid = 10 or accid in (150,151,152)
*/