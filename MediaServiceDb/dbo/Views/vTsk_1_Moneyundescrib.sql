

/*==============================================================*/
/* View: vTsk_1_Moneyundescrib                                  */
/*==============================================================*/
CREATE view [dbo].[vTsk_1_Moneyundescrib] as
select paidId, custId, moneyType,  t1.dateInvoice, t1.numberInvoice, t1.amount, isnull(t1.destribAmount,0) as destribAmount, 
isnull(t1.destribPrepay,0) as destribPrepay,
t1.amount - (isnull(t1.destribAmount,0) + isnull(t1.destribPrepay,0) ) as undescribAmount, 
t1.goalInvoice
from MoneyReceived t1
where t1.amount - (isnull(t1.destribAmount,0) + isnull(t1.destribPrepay,0) ) <> 0
GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Список нераспределенных платежей', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vTsk_1_Moneyundescrib';

