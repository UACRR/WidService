CREATE TABLE [dbo].[ExternalPay] (
    [paidId]      INT             IDENTITY (1, 1) NOT NULL,
    [inputDate]   DATETIME        NULL,
    [mfo]         CHAR (10)       NULL,
    [okpol]       VARCHAR (15)    NULL,
    [account]     VARCHAR (32)    NULL,
    [r030]        CHAR (3)        NULL,
    [codeOper]    CHAR (10)       NULL,
    [mfoCorr]     VARCHAR (256)   NULL,
    [nameMfoCorr] VARCHAR (200)   NULL,
    [accountCorr] VARCHAR (32)    NULL,
    [okpoCorr]    VARCHAR (15)    NULL,
    [nameCorr]    VARCHAR (200)   NULL,
    [docNum]      VARCHAR (50)    NULL,
    [docDate]     DATE            NULL,
    [sDebet]      NUMERIC (20, 2) NULL,
    [sCredit]     NUMERIC (20, 2) NULL,
    [nplat]       VARCHAR (512)   NULL,
    [sNcCur]      NUMERIC (20, 2) NULL,
    [status]      INT             NULL,
    [dateOper]    DATE            NULL,
    [inputFileId] INT             NULL,
    [custId]      INT             NULL,
    CONSTRAINT [PK_EXTERNALPAY] PRIMARY KEY CLUSTERED ([paidId] ASC),
    CONSTRAINT [FK_EXTERNAL_REFERENCE_CLIENT] FOREIGN KEY ([custId]) REFERENCES [dbo].[Client] ([custId]),
    CONSTRAINT [FK_EXTERNAL_REFERENCE_INPUTFIL] FOREIGN KEY ([inputFileId]) REFERENCES [dbo].[inputFile] ([fileId])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Документы 1С ExternalPay
   ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ExternalPay';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Номер документа оплаты', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ExternalPay', @level2type = N'COLUMN', @level2name = N'account';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Валюта платежа', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ExternalPay', @level2type = N'COLUMN', @level2name = N'r030';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Статус обработки оплатой 0-на обработан, 1-обработан', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ExternalPay', @level2type = N'COLUMN', @level2name = N'nameMfoCorr';

