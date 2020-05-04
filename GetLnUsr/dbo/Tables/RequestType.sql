CREATE TABLE [dbo].[RequestType] (
    [codeI]        INT           NOT NULL,
    [categoryCode] INT           NOT NULL,
    [name]         VARCHAR (200) NULL,
    CONSTRAINT [PK_REQUESTTYPE] PRIMARY KEY CLUSTERED ([codeI] ASC),
    CONSTRAINT [FK_REQUESTT_REFERENCE_CATEGORY] FOREIGN KEY ([categoryCode]) REFERENCES [dbo].[Category] ([codeI])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Справочник типов заявок 
   в т.ч.: формирование плейлиста, синхронизаяция, адаптация, покупка лицензии', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RequestType';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код типа заявки', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RequestType', @level2type = N'COLUMN', @level2name = N'codeI';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код категории объекта автоского права', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RequestType', @level2type = N'COLUMN', @level2name = N'categoryCode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Название типа заявки', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RequestType', @level2type = N'COLUMN', @level2name = N'name';

