--Ф-я возвращает максимальную сумму от правообладателя и от клиента
--С использованием статуса 9

--drop function dbo.ft_TradeAmount
CREATE function dbo.ft_TradeAmount ( @reqId int )
RETURNS @RT TABLE
(
 tradeIdCl integer  primary key not null, 
 AmountCl  money   null, 
 rAgrIdCl  integer null, 
 tradeIdRh integer null,
 AmountRh  money   null, 
 rAgrIdRh  integer null 
 )
AS
BEGIN
--declare @reqId integer
--set @reqId = 47
declare @tradeIdCl integer, @tradeIdRh integer, @rAgrIdRh integer, @rAgrIdCl integer
declare @AmountCl money, @AmountRh money
--AmountRH = Мах сумма от правообладателя, его rAgrId = rAgrIdRH, 
--AmountCl = последняя сумма клиента, TradeIdCl = его tradeId, custIdCl 

  set @AmountCl = (select max(isnull(costOffer,0))  from reqAgreement 
                    where reqId = @reqId and isnull(custIdRh,0) = 0 )
  set @rAgrIdCl = (select max(rAgrId)  from reqAgreement 
                    where reqId = @reqId and isnull(custIdRh,0) = 0 )
--Предложение клиента
  set @tradeIdCl = (select max(t1.tradeId) 
                    from reqTrade t1   
                    where t1.reqId = @reqId and t1.rAgrId = @rAgrIdCl and t1.costClient = @AmountCl)

--Предложение Правообладателя
set @AmountRh = 
( select  max(Case When isnull(r1.costOffer,0) <> 0 Then r1.costOffer else isnull(r1.amount,0) end)  
                           from reqAgreement r1 
                           where reqId = @reqId and r1.status not in (8,9)  --!9 
                             and isnull(custIdRh,0) <> 0 )

--Последние торги правообладателя
set @tradeIdRh = 
(isnull((isnull((select max(tradeId) from reqTrade where reqId = @reqId and  costRHolder= @AmountRh and status in (4)), 
        (select max(tradeId) from reqTrade where reqId = @reqId and  costRHolder= @AmountRh and status in (6)))), 
		 (select max(tradeId) from reqTrade where reqId = @reqId and  costRHolder= @AmountRh)))

--Чье предложение - Преимущество если уже выставлял предложение 
set @rAgrIdRh = isnull((select t1.rAgrId 
                       from ReqTrade t1 
                       join reqAgreement t2 on t1.reqId = t2.reqId and t1.rAgrid = t2.rAgrId 
                          where  t2.status <> 9 and   --!9
                                 t1.tradeId = @tradeIdRh and isnull(custIdRh,0) <> 0), 
                isnull((select max(rAgrId)  
                          from reqAgreement r1 
                          where reqId = @reqId and r1.status <> 9 and --!9
                                isnull(custIdRh,0)<>0 and  @AmountRh = isnull(r1.costOffer,0)), 
            	 (select max(rAgrId) from reqAgreement r1 
                                     where reqId = @reqId and r1.status <> 9 and   --!9
                                           isnull(custIdRh,0)<>0 and  @AmountRh = isnull(r1.amount,0)) ) )
	 
insert into @RT
select isnull(@tradeIdCl,0) as tradeIdCl, @AmountCl as AmountCl, @rAgrIdCl as rAgrIdCl, 
       @tradeIdRh as tradeIdRh, @AmountRh as AmountRh, @rAgrIdRh as rAgrIdRh;
  
RETURN;
END;


GO
GRANT SELECT
    ON OBJECT::[dbo].[ft_TradeAmount] TO [ReportUser]
    AS [dbo];

