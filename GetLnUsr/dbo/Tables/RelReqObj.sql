CREATE TABLE [dbo].[RelReqObj] (
    [categoryCode] INT NOT NULL,
    [reqType]      INT NOT NULL,
    [kindGroupId]  INT NOT NULL,
    [CRKindCode]   INT NULL,
    PRIMARY KEY CLUSTERED ([categoryCode] ASC, [reqType] ASC, [kindGroupId] ASC),
    CONSTRAINT [FK_RELREQOB_REFERENCE_REQUESTT] FOREIGN KEY ([reqType]) REFERENCES [dbo].[RequestType] ([codeI])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Таблица связи Типов Заявок с видом и типом права', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RelReqObj';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код категории объекта автоского права', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RelReqObj', @level2type = N'COLUMN', @level2name = N'categoryCode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код типа заявки', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RelReqObj', @level2type = N'COLUMN', @level2name = N'reqType';

