CREATE TABLE [dbo].[RegisterRatedList] (
    [periodId]   INT           NOT NULL,
    [rmId]       INT           IDENTITY (1, 1) NOT NULL,
    [amount]     MONEY         NULL,
    [royalty]    MONEY         NULL,
    [createDate] DATE          NULL,
    [userId]     NVARCHAR (48) NULL,
    [status]     INT           NULL,
    [cntReport]  INT           NULL,
    [paidAmount] MONEY         NULL,
    CONSTRAINT [PK_REGISTERRATEDLIST] PRIMARY KEY CLUSTERED ([rmId] ASC),
    CONSTRAINT [FK_REGISTER_REF_REGISTERList] FOREIGN KEY ([status]) REFERENCES [dbo].[RegisterListStatus] ([codeI]),
    CONSTRAINT [FK_REGRATEDLIST_REF_PAIDPER] FOREIGN KEY ([periodId]) REFERENCES [dbo].[PaidPeriod] ([periodId])
);


GO
CREATE trigger tu_regRatedList on [dbo].[RegisterRatedList] for update as
--alter trigger [%QUALIFIER%]%TRIGGER% on RegisterRatedList for update as
begin
   declare
      @numrows  int,
      @numnull  int,
      @errno    int,
      @errmsg   varchar(255)

      select  @numrows = @@rowcount
      if @numrows = 0
         return
	  
	  --if UPDATE( status )
	  --begin
   -- 	  select @numrows = count(*) from Register t1 
   -- 	  join inserted t2 on t1.rmId = t2.rmId
   -- 	  where 
   -- 	  t2.status = 1 -- Погодженні
   -- 	  and t1.rgStatus < 2
	  
   -- 	  if(@numrows > 0)
   -- 	  begin
   -- 		set @errmsg = 'Є звіти зі статусом Новий або На погодженні'
   -- 		goto error
   -- 	  end 
	  --end

	  if UPDATE( royalty ) -- Зміна суми вимоги по періоду
	  begin
		update PaidPeriod 
		set amount = t1.amount - isnull(t3.royalty,0) + isnull(t2.royalty,0)
		from PaidPeriod t1
		join inserted t2 on t2.periodId = t1.periodId
		join deleted t3 on t3.rmId = t2.rmId
		where
		isnull(t3.royalty,0) != isnull(t2.royalty,0)
	  end



      return

/*  Errors handling  */
error:
    raiserror( @errmsg, 11, 1 ) 
    rollback  transaction
end

GO
create trigger ti_regRatedList on [dbo].[RegisterRatedList] for insert as
--create trigger [%QUALIFIER%]%TRIGGER% on [%TABLQUALIFIER%]%TABLE% for insert as
begin
    declare
       @numrows  int,
       @numnull  int,
       @errno    int,
       @errmsg   varchar(255)

    select  @numrows = @@rowcount
    if @numrows = 0
       return

	update PaidPeriod set amount = t1.amount + t2.royalty
	from PaidPeriod t1
	join inserted t2 on t2.periodId = t1.periodId
	where
	t2.royalty > 0

    return

/*  Errors handling  */
error:
    raiserror( @errmsg, 11,1)
    rollback  transaction
end

GO
CREATE trigger [dbo].[td_regRatedList] on [dbo].[RegisterRatedList] for delete as
--alter trigger [%QUALIFIER%]%TRIGGER% on RegisterRatedList for delete as
begin
   declare
      @numrows  int,
      @numnull  int,
      @errno    int,
      @errmsg   varchar(255)

      select  @numrows = @@rowcount
      if @numrows = 0
         return
	  
	  begin
		update PaidPeriod 
		set amount = (Case When isnull(t2.royalty,0) <= isnull(t1.amount,0) Then isnull(t1.amount,0) - isnull(t2.royalty,0)  
						   else 0 end)
		from PaidPeriod t1
		join deleted t2 on t2.periodId = t1.periodId
	  end



      return

/*  Errors handling  */
error:
    raiserror( @errmsg, 11, 1 ) 
    rollback  transaction
end

GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Розрахунковий лист', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RegisterRatedList';

