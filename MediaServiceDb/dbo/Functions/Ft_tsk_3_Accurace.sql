CREATE FUNCTION [dbo].[Ft_tsk_3_Accurace]
(@sors NVARCHAR (MAX) NULL, @dest NVARCHAR (MAX) NULL, @accuracy REAL NULL)
RETURNS FLOAT (53)
AS
 EXTERNAL NAME [MediaServiceDb].[UserDefinedFunctions].[Ft_tsk_3_Accurace]

