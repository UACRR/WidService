CREATE procedure [dbo].[PayTurnExtra_form]
as
begin
create table #PayTurnExtra(
turnid	int not null,
datework date,
custid   int null,
payturntype int null,
primary key (datework,turnid)
)

declare @maxturnid int 
	select @maxturnid = isnull( max(turnid),0) from PayTurnExtra

	insert #PayTurnExtra (turnid,datework) select distinct turnid ,datework from payturn
		delete  t1
		from PayTurnExtra t2,#PayTurnExtra t1
		where
		t1.datework=t2.datework	and
		t1.turnid=t2.turnid


--		if (@@ROWCOUNT <>0)
		begin
				update t1
					set t1.custid=t2.custid
					from #PayTurnExtra t1,Distribution t2,PayTurn t3
					where
						t1.turnid=t3.turnId and
						t2.distId=t3.distid and
						t1.datework=t3.dateWork

						update t1
							set payturntype=t3.codei
							from #PayTurnExtra t1,PayTurn t2, PayTurnType t3
							where
								t1.turnid=t2.turnId and
								convert(int,substring(accdebet,1,2))=balsDbt and
								convert(int,substring(acccredit,1,2))=balsCrdt and
														t1.datework=t2.dateWork
				insert PayTurnExtra(turnid,datework,custid,payturntype)
					select turnid,datework,custid,payturntype from #PayTurnExtra


		end
	
end