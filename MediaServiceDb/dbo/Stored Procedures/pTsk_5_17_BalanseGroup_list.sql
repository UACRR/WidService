CREATE procedure pTsk_5_17_BalanseGroup_list
as

begin

declare @result table(
	id			int identity,
	msk		varchar(10),	
	name	varchar(40),
	primary key (id)
	)
	insert @result (msk,name) select '0','Всі'
	insert @result (msk,name)
select distinct case when accnls like '10%'  then '10'
							when accnls like '11%'  then substring(accnls,1,6)
								when accnls like '20%' then '20'
								when accnls like '21%' then '21'
								when accNls like  '3%'  then substring (accnls,1,5)
								when accnls like   '4%' then '40'
						end  msk,
						case when accnls like '10%'  then 'Рахунок компанії'
							when accnls like '11%'  then accName
								when accnls like '20%' then  'Рахунки клієнтів'
								when accnls like '21%' then  'Технічні рахунки клієнтів'
								when accNls like  '30%'  then  'Об''єкти по виду '+ SUBSTRING(accnls,4,2)
								when accNls like  '31%'  then  ' Нерозподіл. об''єкти по виду '+ SUBSTRING(accnls,4,2)
								when accnls like   '4%' then ' Комісії партнерів'
						end  name
from Account
select id,	msk, rtrim(Ltrim(msk))+ replicate('_',8- Len(rtrim(ltrim(msk))))	+ltrim(name) name	 from @result
end

-- exec pTsk_5_17_BalanseGroup_list