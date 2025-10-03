USE AppleMusic
GO

/****** Object:  View [dbo].[vMSCustomerRHolder]    Script Date: 25.09.2025 13:21:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create view [dbo].[vMSCustomerRHolder]
 as 
 (select * from mediaservice..vCustomerRHolder) 
GO


