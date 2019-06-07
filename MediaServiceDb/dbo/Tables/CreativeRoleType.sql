CREATE TABLE [dbo].[CreativeRoleType] (
    [codeI]        INT           NOT NULL,
    [CategoryCode] INT           NOT NULL,
    [name]         VARCHAR (128) NULL,
    [CRType]       INT           NOT NULL,
    CONSTRAINT [PK_CREATIVEROLETYPE] PRIMARY KEY CLUSTERED ([codeI] ASC),
    CONSTRAINT [FK_CREATIVE_REFERENCE_CATEGORY] FOREIGN KEY ([CategoryCode]) REFERENCES [dbo].[Category] ([codeI]),
    CONSTRAINT [FK_CREATIVE_REFERENCE_COPYRIGH] FOREIGN KEY ([CRType]) REFERENCES [dbo].[CopyrightType] ([codeI])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код категории объекта автоского права', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CreativeRoleType', @level2type = N'COLUMN', @level2name = N'CategoryCode';

