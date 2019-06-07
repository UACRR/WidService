

/*==============================================================*/
/* View: vSD                                                    */
/*==============================================================*/
CREATE view [dbo].[vSD] as
  select t1.accnls,t2.accId,dateBegin,dateEnd,
  t2.r030,deboborot,krdOborot,restBegin,rest,deboborotCourt,krdOborotCourt,restBeginCourt,restCourt from account t1,SaldoDay t2
  where t2.accid=t1.accid
GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Автор - Пасхалов Сережа
   Использует при формирования отчетов по оплате
   ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vSD';

