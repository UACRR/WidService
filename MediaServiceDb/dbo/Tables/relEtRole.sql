CREATE TABLE [dbo].[relEtRole] (
    [roleCode]   INT NOT NULL,
    [etRoleCode] INT NOT NULL,
    CONSTRAINT [PK_RELETROLE] PRIMARY KEY CLUSTERED ([roleCode] ASC, [etRoleCode] ASC),
    CONSTRAINT [FK_RELETROL_REFERENCE_CREATIVE] FOREIGN KEY ([roleCode]) REFERENCES [dbo].[CreativeRoleType] ([codeI]),
    CONSTRAINT [FK_RELETROL_REFERENCE_ETROLE] FOREIGN KEY ([etRoleCode]) REFERENCES [dbo].[EtRole] ([codeI])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Соответсвие ролей Системі постанове 72 (эталону)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'relEtRole';

