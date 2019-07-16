CREATE TABLE [dbo].[ParametersListBox] (
    [repId]     INT          NOT NULL,
    [pId]       INT          NOT NULL,
    [valuePar]  VARCHAR (20) NULL,
    [valueType] VARCHAR (20) NULL,
    [valueName] VARCHAR (20) NULL,
    PRIMARY KEY CLUSTERED ([repId] ASC, [pId] ASC)
);




GO
GRANT SELECT
    ON OBJECT::[dbo].[ParametersListBox] TO [ReportUser]
    AS [dbo];

