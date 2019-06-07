CREATE TABLE [dbo].[TypePlace] (
    [codeI]     INT           NOT NULL,
    [name]      VARCHAR (100) NULL,
    [isHoll]    BIT           NULL,
    [paramType] INT           NULL,
    CONSTRAINT [PK_TYPEPLACE] PRIMARY KEY CLUSTERED ([codeI] ASC),
    CONSTRAINT [FK_TYPEPLAC_REF_TYPEPLAC] FOREIGN KEY ([paramType]) REFERENCES [dbo].[TypePlaceParam] ([codeI])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Количество мест', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TypePlace', @level2type = N'COLUMN', @level2name = N'name';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'тип площадки - отели, рестораны, кафе', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TypePlace';

