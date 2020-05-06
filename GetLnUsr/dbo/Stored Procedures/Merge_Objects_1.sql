CREATE procedure [dbo].[Merge_Objects_1] @accId_save int,@accId_delete int
as

begin
CREATE TABLE #SaldoDay_src(
	accId int NOT NULL,
	dateBegin date NOT NULL,
	dateEnd date NOT NULL,
	r030 char(3) NULL,
	rest numeric(20, 2) NULL,
	restCourt numeric(20, 2) NULL,
	deboborot numeric(20, 2) NULL,
	krdOborot numeric(20, 2) NULL,
	deboborotCourt numeric(20, 2) NULL,
	krdOborotCourt numeric(20, 2) NULL,
	restBegin numeric(20, 2) NULL,
	restBeginCourt numeric(20, 2) NULL,
 PRIMARY KEY CLUSTERED 
(
	accId ASC,
	dateBegin ASC,
	dateEnd ASC
)
)
CREATE TABLE #SaldoDay_dst(
	accId int NOT NULL,
	dateBegin date NOT NULL,
	dateEnd date NOT NULL,
	r030 char(3) NULL,
	rest numeric(20, 2) NULL,
	restCourt numeric(20, 2) NULL,
	deboborot numeric(20, 2) NULL,
	krdOborot numeric(20, 2) NULL,
	deboborotCourt numeric(20, 2) NULL,
	krdOborotCourt numeric(20, 2) NULL,
	restBegin numeric(20, 2) NULL,
	restBeginCourt numeric(20, 2) NULL,
 PRIMARY KEY CLUSTERED 
(
	accId ASC,
	dateBegin ASC,
	dateEnd ASC
)
)

insert #SaldoDay_dst select * from SaldoDay 
where accid=@accId_save
--42
 	if @@error	<> 0	goto __retErr

insert #SaldoDay_src select * from SaldoDay 
where accid= @accId_delete

 	if @@error	<> 0	goto __retErr


Merge  #saldoday_dst as dst
Using (select 	accId,dateBegin,dateEnd,r030,rest,restCourt,
	deboborot,	krdOborot,	deboborotCourt,	krdOborotCourt,
	restBegin,	restBeginCourt from #SaldoDay_src
	) src
			on (
				dst.DateBegin=src.DateBegin
						)
		When MATCHED then
		update 
			set 
			deboborot=src.deboborot + dst.deboborot,
			krdOborot=src.krdOborot + dst.krdOborot,
			deboborotCourt=src.deboborotCourt + dst.deboborotCourt,
			krdOborotCourt=src.krdOborotCourt + dst.krdOborotCourt
		when not matched then
		insert values(accId,dateBegin,dateEnd,r030,rest,restCourt,
	deboborot,	krdOborot,	deboborotCourt,	krdOborotCourt,
	restBegin,	restBeginCourt
	);

 	if @@error	<> 0	goto __retErr

	update #SaldoDay_dst set accId=@accId_save
 	
 	if @@error	<> 0	goto __retErr

	delete #SaldoDay_dst
	where deboborot =0 
		and krdOborot =0

 	if @@error	<> 0	goto __retErr

Merge  #saldoday_dst as dst
Using (select t1.AccId,t1.DateBegin,min(t2.DateBegin) DateEnd from #saldoday_dst t1,
			 #saldoday_dst t2
			where 
					t2.AccId=t1.AccId	and
					t2.DateBegin>t1.DateBegin
					group by t1.AccId,t1.DateBegin
					) src
				on (
						dst.AccId=src.AccId	and
						dst.DateBegin=src.DateBegin
						)
		When MATCHED then
		update 
			set DateEnd=dateadd(day,-1,src.DateEnd);
 	
 	if @@error	<> 0	goto __retErr

Merge  #saldoday_dst as dst
Using (select a1.accid,a1.datebegin,sum(a2.deboborot-a2.krdoborot) rest,
		sum(a2.deboborotCourt - a2.krdOborotCourt) restCourt
	 from  
        (select t1.AccId,min(t2.DateBegin) Datebegin from #saldoday_dst t1,
			 #saldoday_dst t2
			where 
					t2.AccId=t1.AccId	and
					t2.DateBegin>t1.DateBegin
					group by t1.AccId,t1.DateBegin
					)  a1    ,  #saldoday_dst a2
			where 
					a2.AccId=a1.AccId	and
					a2.DateBegin<a1.DateBegin
					group by a1.datebegin,a1.accid
					
										)					src
				on (
						dst.AccId=src.AccId	and
						dst.DateBegin=src.DateBegin
						)
		When MATCHED then
		update 
			set   restbegin=src.rest,
				  restBeginCourt=src.restCourt	;

 	if @@error	<> 0	goto __retErr

	update #SaldoDay_dst
	set rest =restBegin + deboborot - krdOborot,
	    restCourt =restBeginCourt + deboborotCourt - krdOborotCourt

 	if @@error	<> 0	goto __retErr

delete SaldoDay where
accId =@accId_save

 	if @@error	<> 0	goto __retErr

delete SaldoDay where
accId =@accId_delete

 	if @@error	<> 0	goto __retErr

insert SaldoDay( accId,dateBegin,dateEnd,r030,rest,restCourt,deboborot,krdOborot,deboborotCourt,
				krdOborotCourt,restBegin,restBeginCourt  )
select  accId,dateBegin,dateEnd,r030,rest,restCourt,deboborot,krdOborot,deboborotCourt,
				krdOborotCourt,restBegin,restBeginCourt
from #SaldoDay_dst

 	if @@error	<> 0	goto __retErr

return 0

__retErr:

return 1


end