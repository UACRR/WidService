CREATE view vBORG as 
select custId, sum(isnull(amount,0) - isnull(undistribamount,0) - isnull(distribamount,0)) as amountBorg
  from PaidPeriod 
  where status = 3
  group by custId