CREATE TABLE [dbo].[RightHolder] (
    [custId]      INT            NOT NULL,
    [signP]       TINYINT        NULL,
    [aroundWord]  BIT            NULL,
    [interCode]   VARCHAR (25)   NULL,
    [innerCode]   VARCHAR (25)   NULL,
    [rHolderType] INT            DEFAULT ((1)) NULL,
    [IPIBase]     VARCHAR (25)   NULL,
    [comment]     VARCHAR (1024) NULL,
    [datePassed]  DATE           NULL,
    CONSTRAINT [PK_RIGHTHOLDER] PRIMARY KEY CLUSTERED ([custId] ASC),
    CONSTRAINT [FK_RIGHTHOL_REFERENCE_CUSTOMER] FOREIGN KEY ([custId]) REFERENCES [dbo].[Customer] ([custId])
);


GO

CREATE TRIGGER [dbo].[ti_RightHolder]
   ON  [dbo].[RightHolder] 
   AFTER INSERT
 AS BEGIN

	SET NOCOUNT ON;
   update RightHolder set innerCode = t1.custId 
      from inserted t1 where RightHolder.custId = t1.custId and (t1.innerCode is NULL or t1.innerCode = '') -- може бути null або string.Empty
END
GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Правообладатели', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RightHolder';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор клиента (правообладателя или покупателя)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RightHolder', @level2type = N'COLUMN', @level2name = N'custId';

