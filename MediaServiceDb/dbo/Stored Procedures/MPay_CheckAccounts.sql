CREATE procedure [dbo].[MPay_CheckAccounts]
as
begin
if ( object_id('tempdb..#doc1') is null)

CREATE TABLE #doc1(
	id	int identity,
	regIItemId int  NULL,
	distId int  NULL,
	regId int  NULL,
	--periodId int  NULL,
	distribDate date NOT NULL,
	amount money NOT NULL,
	kindCode int NOT NULL,
	objid int NULL,
	ItemName varchar(100) NULL,
	categoryCode int NULL,
	AccIdDebet int NULL,
	AccIdCredit int NULL,
	AccDebet				varchar(25)			NULL,
	AccCredit				varchar(25)			NULL,
	name varchar(254) NULL,
	author varchar(254) NULL,
	performer varchar(254) NULL,
	custId int NULL,
	rate decimal(5, 2) NULL,
	amountMy		money null,
	amountBalans	money null,
	amountPay	money null,
	cRType int NULL,
	disttype		int,
	paynote varchar	(100)		null,
	custIdRh integer NULL,  --!T
	primary key (id)
	)
	
--проверка/открытие 301/302 счетов плательщика

    declare cur cursor for   select   regIItemId,KindCode,ObjId,AccCredit,AccDebet,ItemName,custId from #Doc1                                   
    declare     @regIItemId		integer
	declare		@KindCode		int                                            
    declare     @ObjId         integer
	declare     @AccCredit		varchar(14)
    declare     @AccDebet		varchar(14)
	declare		@AccID		integer
	declare		@KindCodeCH  varchar(2)  
	declare		@AccName	varchar(30)                                          
	declare		@ItemName		varchar(100)
	declare		@custid1		int
	declare @custname varchar(100)
    open cur                                                   
    fetch cur into  @regIItemId,@KindCode,@ObjId,@AccCredit,@AccDebet,@ItemName,@custid1
                                                   
    while @@fetch_status =0                                                   
	    BEGIN 

           if not exists  (select  1 from Account 
                                        where
												   AccNls=@AccCredit
												   )
                 begin
                                      Exec  dbo.OpenAccNLS Null, @Objid,  '980', @AccCredit,@ItemName	
                 end
	if (SUBSTRING(@AccDebet,1,2)='21'	)		
	begin
	        if not exists  (select  1 from Account 
                                        where accNls=@AccDebet
												   )
                 begin
						select @custname=name from vCustomer
						where custid=@custid1

                         Exec  dbo.OpenAccNLS  @custid1, Null,  '980', @AccDebet,@custname
                 end
      end 
                                                   
	if (SUBSTRING(@AccDebet,1,2)='31'	)		
	begin
	        if not exists  (select  1 from Account 
                                        where accNls=@AccDebet
												   )
                 begin
                         Exec  dbo.OpenAccNLS  null, @objid,  '980', @AccDebet,@ItemName
                 end
      end 
                                                                   
   	fetch cur into  @regIItemId,@KindCode,@ObjId,@AccCredit,@AccDebet,@ItemName,@custid1
END                                                   
close cur   
deallocate cur      

update t1
set AccIdDebet=t2.accid
from  #doc1 t1,Account t2
where
t1.AccDebet=t2.accNls

update t1
set AccIdCredit=t2.accid
from  #doc1 t1,Account t2
where
t1.AccCredit=t2.accNls

return

end