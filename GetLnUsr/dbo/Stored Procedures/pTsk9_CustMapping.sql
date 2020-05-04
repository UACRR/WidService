--------------------
CREATE procedure [dbo].[pTsk9_CustMapping] ( @id varchar(48) )
  AS   
  SET NOCOUNT ON;   --отключение вывода кол-ва строк для оптимизации
--@id - ид. пользователя
--Прив'язка до CustId зареєстрованого користувача (по email)
BEGIN
   declare @RetCode integer
   declare @msg varchar(100) 
   set @RetCode = 0

begin tran 
	BEGIN TRY

  --Если уже установлена связь, но поменялся email. С записью в журнал. Не обрабатываю пока нет подтверждения по email
  /*  
  update AnketaPerson set email = t3.email
  output getdate(), 'Portal', 'RegisterUser', deleted.custId, 'Зміна email - '+deleted.email+' '+ inserted.email, 'pTsk7_CustMapping', deleted.custId
  into systemMessage (modifydate, nameMain, name, keyObj, text, sysname, custId) 
               from AnketaPerson t1 
	             join Customer t2 on t1.custId = t2.custId 
				 join AspNetUsers t3 on t2.userId = t3.id and t3.id = '8f43dba0-f22d-488c-a2b1-25658c110c9b'--@id
	           where t1.email <> t3.email 
  */

	 --Если еще не установлена связь (customer.id)
	 --Сначала ищу как физ.лицо.
      update customer set userId = t1.id
  output getdate(), 'Mapping', 'Portal Mapping ', deleted.custId, 'Встановлено відповідність по email ФО '+t2.email+' Шифр-'+convert(varchar(100),deleted.custId),
         'pTsk9_CustMapping', deleted.custId
  into systemMessage (modifydate, nameMain, name, keyObj, text, sysname, custId) 
	     from customer  t0 
		   join AnketaPerson t2 on t0.custId = t2.custId 
		   join AspNetUsers t1 on t1.id=@id
		         and t1.email = t2.eMail
		  where t0.userId is NULL

 if @@ROWCOUNT = 0 
  begin 

  --Если не нашла - ищу как юр.лицо. Виконавець.
    update employee set userId = t1.id
  output getdate(), 'Mapping', 'Portal Mapping ', deleted.emplid, 'Встановлено відповідність по email Empl- '+ t1.eMail --+' '+t4.lastName+' '+t4.firstName +' '+t4.surname
         +' Шифр-'+convert(varchar(100)
		 ,deleted.emplid)
		 ,'pTsk9_CustMapping', deleted.emplid
  into systemMessage (modifydate, nameMain, name, keyObj, text, sysname, custId) 
	    from Employee t4 
		   join AspNetUsers t1 on t1.id = @id 
		        and t1.email = t4.eMail
		  where t4.userId is NULL

     update customer set userId = t1.id
  output getdate(), 'Mapping', 'Portal Mapping ', deleted.custId, 'Встановлено відповідність по email ЮО- '+ t4.email+' '+t2.name 
         +' ('+isnull(t4.lastName,'')+' '+isnull(t4.firstName,'') +' '+isnull(t4.surname,'')+')'
         +' Шифр-'+convert(varchar(100),deleted.custId),
         'pTsk9_CustMapping', deleted.custId
  into systemMessage (modifydate, nameMain, name, keyObj, text, sysname, custId) 
	     from customer  t0 
		   join AnketaCompany t2 on t0.custId = t2.custId 
		   join RelEmployee t3 on t2.custId = t3.custId and t3.positionCode = 3
		   join Employee t4 on t4.emplid = t3.emplid 
		   join AspNetUsers t1 on t1.id = @id 
		        and t1.email = t4.eMail
		  where t0.userId is NULL
  end 
 
      set @msg = 'Користувачів-'+ isnull((select convert(varchar(10), count(*)) + ' '+ max(userName)
	     from vCustomer 
		 where userId = @id 
		 group by userId ), '0')

   PRINT isnull(@msg,'-')
   IF @@TRANCOUNT > 0 commit tran
	END TRY

BEGIN CATCH
  IF @@TRANCOUNT > 0 rollback tran
    set @RetCode = 1
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
END CATCH

  return @RetCode
END

--select * from SystemMessage
--exec pTsk9_CustMapping '2733ab28-eb37-4f61-b5db-920bd0408b2d'
--update employee set userId = NULL where userId = '2733ab28-eb37-4f61-b5db-920bd0408b2d'
--update customer set userId = NULL where userId = '2733ab28-eb37-4f61-b5db-920bd0408b2d'
--dbcc checkident (systemmessage, reseed, 807)




GO
GRANT EXECUTE
    ON OBJECT::[dbo].[pTsk9_CustMapping] TO [ReportUser]
    AS [dbo];

