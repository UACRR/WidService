USE [SocWidSubmit]
GO

/****** Object:  Table [dbo].[WidSubmGroupWorkHash]    Script Date: 4/24/2024 6:55:10 PM ******/
SET ANSI_NULLS ON
GO

drop table if exists [WidSubmGroupWorkHash]
go

CREATE TABLE [dbo].[WidSubmGroupWorkHash](
	[WidSubmGroupId] [int] NOT NULL,
	[ObjId] [int] NOT NULL,
	[HashString] [nvarchar](max) NULL,
 CONSTRAINT [PK_WidSubmGroupWorkHash] PRIMARY KEY CLUSTERED 
(
	[WidSubmGroupId] ASC,
	[ObjId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

go
