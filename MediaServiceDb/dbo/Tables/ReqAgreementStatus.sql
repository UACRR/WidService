CREATE TABLE [dbo].[ReqAgreementStatus] (
    [statusCode]   INT           NOT NULL,
    [statusNameUk] VARCHAR (100) NULL,
    [statusNameRu] VARCHAR (100) NULL,
    [statusNameEn] VARCHAR (100) NULL,
    CONSTRAINT [PK_REQAGREEMENTSTATUS] PRIMARY KEY CLUSTERED ([statusCode] ASC)
);

