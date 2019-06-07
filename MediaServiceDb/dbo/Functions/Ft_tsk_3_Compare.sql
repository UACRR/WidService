CREATE FUNCTION [dbo].[Ft_tsk_3_Compare]
(@sors NVARCHAR (MAX) NULL, @dest NVARCHAR (MAX) NULL, @accuracy REAL NULL)
RETURNS BIT
AS
 EXTERNAL NAME [MediaServiceDb].[UserDefinedFunctions].[Ft_tsk_3_Compare]

