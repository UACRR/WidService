CREATE TABLE [dbo].[CopyRight] (
    [cRightId]      INT            IDENTITY (1, 1) NOT NULL,
    [custId]        INT            NOT NULL,
    [objId]         INT            NULL,
    [lBasis]        INT            NULL,
    [rate]          DECIMAL (5, 2) NULL,
    [roleRate]      DECIMAL (5, 2) NULL,
    [beginDate]     DATE           CONSTRAINT [col_beginDate_def] DEFAULT ('1900-01-01') NULL,
    [endDate]       DATE           CONSTRAINT [col_endDate_def] DEFAULT ('3000-01-01') NULL,
    [lBasisComment] VARCHAR (254)  NULL,
    [createDate]    DATETIME       NULL,
    [modifyDate]    DATETIME       NULL,
    [modifyLogin]   VARCHAR (48)   NULL,
    [permCode]      BIT            NULL,
    [parentId]      INT            NULL,
    [roleCode]      INT            NULL,
    [status]        INT            NULL,
    CONSTRAINT [PK_COPYRIGHT] PRIMARY KEY CLUSTERED ([cRightId] ASC),
    CONSTRAINT [FK_COPYRIGH_ASSOCIATI_RIGHTHOL] FOREIGN KEY ([custId]) REFERENCES [dbo].[RightHolder] ([custId]),
    CONSTRAINT [FK_COPYRIGH_REFERENCE_CREATIVE] FOREIGN KEY ([roleCode]) REFERENCES [dbo].[CreativeRoleType] ([codeI]),
    CONSTRAINT [FK_COPYRIGH_REFERENCE_CRIGHTST] FOREIGN KEY ([status]) REFERENCES [dbo].[CRightStatus] ([codeI]),
    CONSTRAINT [FK_COPYRIGH_REFERENCE_OBJECTRI] FOREIGN KEY ([objId]) REFERENCES [dbo].[ObjectRight] ([objId])
);






GO
CREATE NONCLUSTERED INDEX [Association10_FK]
    ON [dbo].[CopyRight]([custId] ASC);


GO

GO

GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор в таблице правообладания авторским правом', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CopyRight', @level2type = N'COLUMN', @level2name = N'parentId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Признак разрешения или запрета на выставление своих прав на использование
   1 - запрет', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CopyRight', @level2type = N'COLUMN', @level2name = N'permCode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Пользователь, кто модифицировал запись', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CopyRight', @level2type = N'COLUMN', @level2name = N'modifyLogin';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Дата модификации записи', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CopyRight', @level2type = N'COLUMN', @level2name = N'modifyDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Правовое основание нвледение авторским правом комментарий (номер, дата)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CopyRight', @level2type = N'COLUMN', @level2name = N'lBasisComment';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Конец периода владения авторским правом', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CopyRight', @level2type = N'COLUMN', @level2name = N'endDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Начало периода владения авторским правом', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CopyRight', @level2type = N'COLUMN', @level2name = N'beginDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'доля правовладения для бюольших прав ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CopyRight', @level2type = N'COLUMN', @level2name = N'roleRate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = '% правообладания объектов права
   Нужно удалить в следующей версии портала - берется из MainCopyright', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CopyRight', @level2type = N'COLUMN', @level2name = N'rate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Правовое основание нвледение авторским правом', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CopyRight', @level2type = N'COLUMN', @level2name = N'lBasis';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор объекта права', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CopyRight', @level2type = N'COLUMN', @level2name = N'objId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор клиента (правообладателя или покупателя)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CopyRight', @level2type = N'COLUMN', @level2name = N'custId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор в таблице правообладания авторским правом', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CopyRight', @level2type = N'COLUMN', @level2name = N'cRightId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Права Правообладателя в разрезе видов права', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CopyRight';


GO
CREATE trigger [dbo].[tu_CopyRight] on [dbo].[CopyRight] for update as
begin
SET NOCOUNT ON;
   declare
	  @copyRt   CopyRightParam,
      @numrows  int,
      @numnull  int,
      @errno    int,
      @errmsg   varchar(255)

   
      update CopyRight set modifyDate = getdate() 
      from INSERTED t1 where CopyRight.CRightId = t1.CRightId;

	  if( UPDATE( status ) )
	  begin
	  -- Перевірка правильності зміни статусу 
		select @numrows = count(*) from inserted t1
		join deleted t2 on t2.cRightId = t1.cRightId
		where
		t1.status < t2.status;

		if @numrows > 0 
		begin
			set @errmsg = 'Помилка зміни статусу з "Підтверженого" на "Непідтвержений"';
			goto error;
		end
	  end

	  insert into @copyRt(cRightId, objid )
	  select t1.cRightId, t1.objid from inserted t1 
	  join deleted t2 on t2.cRightId = t1.cRightId and isnull(t2.status,0) = 0
	  where t1.status = 1

	  if (select count(*) from @copyRt ) = 0
		return;

	  exec p_DistribForNewRHolder @copyRt

      return

/*  Errors handling  */
error:
    raiserror( @errmsg, 10, 1 )
    rollback  transaction
end
GO
CREATE TRIGGER ti_CopyRight
   ON  CopyRight 
   AFTER INSERT
 AS BEGIN

	SET NOCOUNT ON;
   update CopyRight set createDate = getdate() 
      from inserted t1 where CopyRight.cRightId = t1.cRightId
END