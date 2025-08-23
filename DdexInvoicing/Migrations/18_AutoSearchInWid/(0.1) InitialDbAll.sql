USE [AutoSearch]
GO
/****** Object:  UserDefinedFunction [dbo].[ClrTranslitFromUkrToLat]    Script Date: 09.08.2025 13:22:24 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE FUNCTION [dbo].[ClrTranslitFromUkrToLat](@source [nvarchar](256))
RETURNS [nvarchar](1000) WITH EXECUTE AS CALLER
AS 
EXTERNAL NAME [MsSqlClrExt].[MsSqlClrExt.ClrTranslit].[ClrTranslitFromUkrToLat]
GO
/****** Object:  UserDefinedFunction [dbo].[TransLitCharFromUkrToLat]    Script Date: 09.08.2025 13:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create   function [dbo].[TransLitCharFromUkrToLat] (
	@char char
) returns varchar(4)
as 
begin
	return case
            when @char = 'Ь'   then  ''   
			when @char = 'ь'   then  ''   
            when @char = ''''  then  ''   
            when @char = 'А'   then  'A'  
            when @char = 'Б'   then  'B'  
            when @char = 'В'   then  'V'  
            when @char = 'Г'   then  'H'  
            when @char = 'Д'   then  'D'  
            when @char = 'Е'   then  'E'  
            when @char = 'Є'   then  ''   
            when @char = 'Ж'   then  'ZH' 
            when @char = 'З'   then  'Z'  
            when @char = 'И'   then  'Y'  
            when @char = 'І'   then  'I'  
            when @char = 'Ї'   then  ''   
            when @char = 'Й'   then  ''   
            when @char = 'К'   then  'K'  
            when @char = 'Л'   then  'L'  
            when @char = 'М'   then  'M'  
            when @char = 'Н'   then  'N'  
            when @char = 'О'   then  'O'  
            when @char = 'П'   then  'P'  
            when @char = 'Р'   then  'R'  
            when @char = 'С'   then  'S'  
            when @char = 'Т'   then  'T'  
            when @char = 'У'   then  'U'  
            when @char = 'Ф'   then  'F'  
            when @char = 'Х'   then  'KH' 
            when @char = 'Ц'   then  'TS' 
            when @char = 'Ч'   then  'CH' 
            when @char = 'Ш'   then  'SH' 
            when @char = 'Щ'   then  'SHCH'
            when @char = 'Ё'   then  'IO' 
            when @char = 'Ъ'   then  ''   
            when @char = 'Ы'   then  'Y'  
            when @char = 'Э'   then  'E'  
            when @char = '№'   then  '#'  
            when @char = '…'   then  '...'
            when @char = '«'   then  '''' 
            when @char = '»'   then  '''' 
            when @char = '’'   then  ''''  
            when @char = '‘'   then  ''''  
            when @char = '–'   then  '-'  
            when @char = '—'   then  '-'  
            when @char = ' '   then  ' '  
		else @char
	end
end
GO
/****** Object:  UserDefinedFunction [dbo].[TransLitFromUkrToLat]    Script Date: 09.08.2025 13:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create   function [dbo].[TransLitFromUkrToLat] (
	@string	varchar(max)
)
returns varchar(max) 
as 
begin
	set @string = Replace(@string, 'ЗГ', 'ZGH');
	
	declare @idx int = 1
	declare @curChar char = substring(@string, @idx, 1)

	declare	@result	varchar(max)
	if      @curChar = 'Є' set @result = 'YE'
	else if @curChar = 'Ї' set @result = 'YI'
	else if @curChar = 'Й' set @result = 'Y'
	else if @curChar = 'Ю' set @result = 'YU'
	else if @curChar = 'Я' set @result = 'YA'
	else                   set @result = dbo.TransLitCharFromUkrToLat(@curChar)

	set @idx = @idx + 1
	while @idx <= len(@string)
	begin
		set @curChar = substring(@string, @idx, 1)
		if      @curChar = 'Є' set @result = @result + 'IE'
		else if @curChar = 'Ї' set @result = @result + 'I'
		else if @curChar = 'Й' set @result = @result + 'I'
		else if @curChar = 'Ю' set @result = @result + 'IU'
		else if @curChar = 'Я' set @result = @result + 'IA'
		else                   set @result = @result + dbo.TransLitCharFromUkrToLat(@curChar)
		set @idx = @idx + 1
	end
	
	return	@Result
end

-- select dbo.transLitFromUkrToLat('батьківська хата')
GO
/****** Object:  Table [dbo].[ExtraTargetAuthorParts]    Script Date: 09.08.2025 13:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExtraTargetAuthorParts](
	[TargetAuthorPartId] [int] NOT NULL,
	[Name] [nvarchar](64) NULL,
PRIMARY KEY CLUSTERED 
(
	[TargetAuthorPartId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExtraTargetAuthorPartWorks]    Script Date: 09.08.2025 13:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExtraTargetAuthorPartWorks](
	[TargetAuthorPartId] [int] NULL,
	[WorkId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExtraTargetNames]    Script Date: 09.08.2025 13:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExtraTargetNames](
	[TargetNameId] [int] NOT NULL,
	[Name] [nvarchar](261) NULL,
PRIMARY KEY CLUSTERED 
(
	[TargetNameId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExtraTargetNamesT]    Script Date: 09.08.2025 13:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExtraTargetNamesT](
	[TargetNameId] [int] NOT NULL,
	[Name] [nvarchar](261) NULL,
PRIMARY KEY CLUSTERED 
(
	[TargetNameId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExtraTargetNameWorks]    Script Date: 09.08.2025 13:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExtraTargetNameWorks](
	[TargetNameId] [int] NULL,
	[WorkId] [int] NULL,
	[ObjId] [int] NULL,
	[Wic] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExtraTargetPerformerParts]    Script Date: 09.08.2025 13:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExtraTargetPerformerParts](
	[TargetPerformerPartId] [int] NOT NULL,
	[Name] [nvarchar](64) NULL,
PRIMARY KEY CLUSTERED 
(
	[TargetPerformerPartId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExtraTargetPerformerPartWorks]    Script Date: 09.08.2025 13:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExtraTargetPerformerPartWorks](
	[TargetPerformerPartId] [int] NULL,
	[WorkId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExtraTargetWorks]    Script Date: 09.08.2025 13:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExtraTargetWorks](
	[TargetWorkId] [int] NOT NULL,
	[WorkId] [int] NULL,
	[Name] [nvarchar](261) NULL,
	[Authors] [nvarchar](2054) NULL,
	[Performers] [nvarchar](2054) NULL,
PRIMARY KEY CLUSTERED 
(
	[TargetWorkId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FoundNamesInIdentMw]    Script Date: 09.08.2025 13:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FoundNamesInIdentMw](
	[SourceNameId] [int] NULL,
	[TargetNameId] [int] NULL,
	[SearchType] [varchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FoundNamesInMs]    Script Date: 09.08.2025 13:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FoundNamesInMs](
	[SourceNameId] [int] NULL,
	[TargetNameId] [int] NULL,
	[SearchType] [varchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FoundNamesInWid]    Script Date: 09.08.2025 13:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FoundNamesInWid](
	[SourceNameId] [int] NULL,
	[TargetNameId] [int] NULL,
	[SearchType] [varchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FoundWorksInIdentMw]    Script Date: 09.08.2025 13:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FoundWorksInIdentMw](
	[SourceWorkId] [int] NULL,
	[TargetWorkId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FoundWorksInMs]    Script Date: 09.08.2025 13:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FoundWorksInMs](
	[SourceWorkId] [int] NULL,
	[TargetObjId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FoundWorksInWid]    Script Date: 09.08.2025 13:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FoundWorksInWid](
	[SourceWorkId] [int] NULL,
	[TargetWic] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SearchSteps]    Script Date: 09.08.2025 13:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SearchSteps](
	[Id] [int] NOT NULL,
	[Name] [varchar](100) NULL,
	[Status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SearchStepsIdentMw]    Script Date: 09.08.2025 13:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SearchStepsIdentMw](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[Status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SearchStepsMs]    Script Date: 09.08.2025 13:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SearchStepsMs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[Status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SearchStepsWid]    Script Date: 09.08.2025 13:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SearchStepsWid](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[Status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SourceAuthorParts]    Script Date: 09.08.2025 13:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SourceAuthorParts](
	[SourceAuthorPartId] [int] IDENTITY(1,1) NOT NULL,
	[WorkId] [int] NULL,
	[Name] [nvarchar](64) NULL,
PRIMARY KEY CLUSTERED 
(
	[SourceAuthorPartId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SourceNames]    Script Date: 09.08.2025 13:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SourceNames](
	[SourceNameId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](261) NULL,
PRIMARY KEY CLUSTERED 
(
	[SourceNameId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SourceNamesT]    Script Date: 09.08.2025 13:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SourceNamesT](
	[SourceNameId] [int] NOT NULL,
	[Name] [nvarchar](261) NULL,
PRIMARY KEY CLUSTERED 
(
	[SourceNameId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SourceNameWorks]    Script Date: 09.08.2025 13:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SourceNameWorks](
	[SourceNameId] [int] NOT NULL,
	[WorkId] [int] NOT NULL,
	[ObjId] [int] NULL,
	[Wic] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[SourceNameId] ASC,
	[WorkId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SourcePerformerParts]    Script Date: 09.08.2025 13:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SourcePerformerParts](
	[SourcePerformerPartId] [int] IDENTITY(1,1) NOT NULL,
	[WorkId] [int] NULL,
	[Name] [nvarchar](64) NULL,
PRIMARY KEY CLUSTERED 
(
	[SourcePerformerPartId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SourceWorks]    Script Date: 09.08.2025 13:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SourceWorks](
	[SourceWorkId] [int] IDENTITY(1,1) NOT NULL,
	[WorkId] [int] NULL,
	[Name] [nvarchar](261) NULL,
	[Authors] [nvarchar](2054) NULL,
	[Performers] [nvarchar](2054) NULL,
PRIMARY KEY CLUSTERED 
(
	[SourceWorkId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TargetAuthorParts]    Script Date: 09.08.2025 13:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TargetAuthorParts](
	[TargetAuthorPartId] [int] NOT NULL,
	[Name] [nvarchar](64) NULL,
PRIMARY KEY CLUSTERED 
(
	[TargetAuthorPartId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TargetAuthorPartsMs]    Script Date: 09.08.2025 13:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TargetAuthorPartsMs](
	[TargetAuthorPartId] [int] NOT NULL,
	[Name] [nvarchar](64) NULL,
PRIMARY KEY CLUSTERED 
(
	[TargetAuthorPartId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TargetAuthorPartsWid]    Script Date: 09.08.2025 13:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TargetAuthorPartsWid](
	[TargetAuthorPartId] [int] NOT NULL,
	[Name] [nvarchar](64) NULL,
PRIMARY KEY CLUSTERED 
(
	[TargetAuthorPartId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TargetAuthorPartWorks]    Script Date: 09.08.2025 13:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TargetAuthorPartWorks](
	[TargetAuthorPartId] [int] NULL,
	[WorkId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TargetAuthorPartWorksMs]    Script Date: 09.08.2025 13:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TargetAuthorPartWorksMs](
	[TargetAuthorPartId] [int] NULL,
	[WorkId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TargetAuthorPartWorksWid]    Script Date: 09.08.2025 13:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TargetAuthorPartWorksWid](
	[TargetAuthorPartId] [int] NULL,
	[WorkId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TargetNames]    Script Date: 09.08.2025 13:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TargetNames](
	[TargetNameId] [int] NOT NULL,
	[Name] [nvarchar](261) NULL,
PRIMARY KEY CLUSTERED 
(
	[TargetNameId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TargetNamesMs]    Script Date: 09.08.2025 13:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TargetNamesMs](
	[TargetNameId] [int] NOT NULL,
	[Name] [nvarchar](261) NULL,
PRIMARY KEY CLUSTERED 
(
	[TargetNameId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TargetNamesMsT]    Script Date: 09.08.2025 13:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TargetNamesMsT](
	[TargetNameId] [int] NOT NULL,
	[Name] [nvarchar](261) NULL,
PRIMARY KEY CLUSTERED 
(
	[TargetNameId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TargetNamesT]    Script Date: 09.08.2025 13:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TargetNamesT](
	[TargetNameId] [int] NOT NULL,
	[Name] [nvarchar](261) NULL,
PRIMARY KEY CLUSTERED 
(
	[TargetNameId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TargetNamesWid]    Script Date: 09.08.2025 13:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TargetNamesWid](
	[TargetNameId] [int] NOT NULL,
	[Name] [nvarchar](261) NULL,
PRIMARY KEY CLUSTERED 
(
	[TargetNameId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TargetNamesWidT]    Script Date: 09.08.2025 13:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TargetNamesWidT](
	[TargetNameId] [int] NOT NULL,
	[Name] [nvarchar](261) NULL,
PRIMARY KEY CLUSTERED 
(
	[TargetNameId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TargetNameWorks]    Script Date: 09.08.2025 13:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TargetNameWorks](
	[TargetNameId] [int] NULL,
	[WorkId] [int] NULL,
	[ObjId] [int] NULL,
	[Wic] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TargetNameWorksMs]    Script Date: 09.08.2025 13:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TargetNameWorksMs](
	[TargetNameId] [int] NULL,
	[WorkId] [int] NULL,
	[ObjId] [int] NULL,
	[Wic] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TargetNameWorksWid]    Script Date: 09.08.2025 13:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TargetNameWorksWid](
	[TargetNameId] [int] NULL,
	[WorkId] [int] NULL,
	[ObjId] [int] NULL,
	[Wic] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TargetPerformerParts]    Script Date: 09.08.2025 13:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TargetPerformerParts](
	[TargetPerformerPartId] [int] NOT NULL,
	[Name] [nvarchar](64) NULL,
PRIMARY KEY CLUSTERED 
(
	[TargetPerformerPartId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TargetPerformerPartsMs]    Script Date: 09.08.2025 13:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TargetPerformerPartsMs](
	[TargetPerformerPartId] [int] NOT NULL,
	[Name] [nvarchar](64) NULL,
PRIMARY KEY CLUSTERED 
(
	[TargetPerformerPartId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TargetPerformerPartsWid]    Script Date: 09.08.2025 13:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TargetPerformerPartsWid](
	[TargetPerformerPartId] [int] NOT NULL,
	[Name] [nvarchar](64) NULL,
PRIMARY KEY CLUSTERED 
(
	[TargetPerformerPartId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TargetPerformerPartWorks]    Script Date: 09.08.2025 13:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TargetPerformerPartWorks](
	[TargetPerformerPartId] [int] NULL,
	[WorkId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TargetPerformerPartWorksMs]    Script Date: 09.08.2025 13:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TargetPerformerPartWorksMs](
	[TargetPerformerPartId] [int] NULL,
	[WorkId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TargetPerformerPartWorksWid]    Script Date: 09.08.2025 13:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TargetPerformerPartWorksWid](
	[TargetPerformerPartId] [int] NULL,
	[WorkId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TargetWorks]    Script Date: 09.08.2025 13:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TargetWorks](
	[TargetWorkId] [int] NOT NULL,
	[WorkId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[TargetWorkId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TargetWorksMs]    Script Date: 09.08.2025 13:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TargetWorksMs](
	[TargetWorkId] [int] NOT NULL,
	[ObjId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[TargetWorkId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TargetWorksWid]    Script Date: 09.08.2025 13:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TargetWorksWid](
	[TargetWorkId] [int] NOT NULL,
	[Wic] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[TargetWorkId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TargetNameWorks]  WITH CHECK ADD  CONSTRAINT [fk_TargetNameWorks_TargetNameId] FOREIGN KEY([TargetNameId])
REFERENCES [dbo].[TargetNames] ([TargetNameId])
GO
ALTER TABLE [dbo].[TargetNameWorks] CHECK CONSTRAINT [fk_TargetNameWorks_TargetNameId]
GO
ALTER TABLE [dbo].[TargetNameWorksMs]  WITH CHECK ADD  CONSTRAINT [fk_TargetNameWorksMs_TargetNameId] FOREIGN KEY([TargetNameId])
REFERENCES [dbo].[TargetNamesMs] ([TargetNameId])
GO
ALTER TABLE [dbo].[TargetNameWorksMs] CHECK CONSTRAINT [fk_TargetNameWorksMs_TargetNameId]
GO
ALTER TABLE [dbo].[TargetNameWorksWid]  WITH CHECK ADD  CONSTRAINT [fk_TargetNameWorksWid_TargetNameId] FOREIGN KEY([TargetNameId])
REFERENCES [dbo].[TargetNamesWid] ([TargetNameId])
GO
ALTER TABLE [dbo].[TargetNameWorksWid] CHECK CONSTRAINT [fk_TargetNameWorksWid_TargetNameId]
GO
/****** Object:  StoredProcedure [dbo].[spCreateSourceInfo]    Script Date: 09.08.2025 13:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create   procedure [dbo].[spCreateSourceInfo]
	@ddexReportId int
as
begin

/*
update t2
set t2.ObjId = null, t2.Wic = null, Status = 0
from Ddex..IdentBacklog t1
	join Ddex..IdentMw t2 on t1.mwId = t2.Id
where t1.DdexReportId = 1496
*/

/*
select *
from Ddex..IdentBacklog t1
	join Ddex..IdentMw t2 on t1.mwId = t2.Id
where t1.DdexReportId = 1496
	and t2.Status= 2
--	and Title = 'I Loved You - Denis First Extended Mix'
*/

-- =================================== ВХІДНА ІНФОРМАЦІЯ ІЗ ЗВІТУ
-- Інформація робоча, після завершення пошуку інформація з таблиць видаляється
begin
-- SourceWorks
	exec spSetSearchStepStarted 1
	truncate table SourceWorks
	insert SourceWorks(WorkId, Name, Authors, Performers)
	select 
		t2.Id
		, t2.Title
		, translate(t2.ComposerAuthor, '.|,()&:;\/', '          ')
		, translate(t2.DisplayArtistName, '.|,()&:;\/', '          ')
	from Ddex..IdentBacklog t1
		join Ddex..IdentMw t2 on t1.mwId = t2.Id
	--where t1.DdexReportId in (select Id from Ddex..ft_AgreementReportIds(1496))
	where t1.DdexReportId = @ddexReportId --1496--
		and isnull(t2.objId, 0) = 0
		and isnull(t2.Wic, 0) = 0
	exec spSetSearchStepEnded 1
	
		-- select count(*) from SourceWorks

-- SourceNames
	exec spSetSearchStepStarted 2
	truncate table SourceNames
	insert SourceNames(Name)
	select distinct Name
	from SourceWorks
	exec spSetSearchStepEnded 2

-- SourceNamesT
	exec spSetSearchStepStarted 3
	truncate table SourceNamesT
	insert SourceNamesT(SourceNameId, Name)
	select SourceNameId, AutoSearch.dbo.ClrTranslitFromUkrToLat(Name)
	from SourceNames
	exec spSetSearchStepEnded 3

-- SourceNameWorks
	exec spSetSearchStepStarted 4
	truncate table SourceNameWorks
	insert SourceNameWorks(SourceNameId, WorkId, ObjId, Wic)
	select distinct t1.SourceNameId, t2.WorkId, null, null
	from SourceNames t1
		join SourceWorks t2 on t1.Name = t2.Name
	exec spSetSearchStepEnded 4

-- SourcePerformerParts
	exec spSetSearchStepStarted 5
	truncate table SourcePerformerParts
	insert SourcePerformerParts(WorkId, Name)
	select distinct WorkId, AutoSearch.dbo.ClrTranslitFromUkrToLat(value)
	from SourceWorks
		cross apply string_split(Performers, ' ')
	where len(value) > 2
	exec spSetSearchStepEnded 5

-- SourceAuthorParts
	exec spSetSearchStepStarted 6
	truncate table SourceAuthorParts
	insert SourceAuthorParts(WorkId, Name)
	select distinct WorkId, AutoSearch.dbo.ClrTranslitFromUkrToLat(value)
	from SourceWorks
		cross apply string_split(Authors, ' ')
	where len(value) > 2
	exec spSetSearchStepEnded 6

end

end -- Процедури
GO
/****** Object:  StoredProcedure [dbo].[spResetSearchSteps]    Script Date: 09.08.2025 13:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create   procedure [dbo].[spResetSearchSteps]
	@searchType int
as
begin
	delete from SearchSteps
	if @searchType = 0	insert SearchSteps select * from SearchStepsIdentMw
	else if @searchType = 1	insert SearchSteps select * from SearchStepsMs
	else				insert SearchSteps select * from SearchStepsWid
end
GO
/****** Object:  StoredProcedure [dbo].[spSearchInIdentMw]    Script Date: 09.08.2025 13:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create   procedure [dbo].[spSearchInIdentMw]
	@ddexReportId int
as
begin

	exec spCreateSourceInfo @ddexReportId
	exec spUpdateTargetInfo

	delete from FoundNamesInIdentMw

	exec spSetSearchStepStarted 30
-- St~Tt
	insert FoundNamesInIdentMw(SourceNameId, TargetNameId, SearchType)
	select t1.SourceNameId, t2.TargetNameId, 'St~Tt' as SearchType
	from SourceNamesT t1
		join TargetNamesT t2 on t2.Name like concat( t1.Name, '%')
		left join FoundNamesInIdentMw t3 on t1.SourceNameId = t3.SourceNameId and t2.TargetNameId = t3.TargetNameId
	where t3.SourceNameId is null

-- Tt~St
	insert FoundNamesInIdentMw(SourceNameId, TargetNameId, SearchType)
	select t1.SourceNameId, t2.TargetNameId, 'Tt~St' as SearchType
	from SourceNamesT t1
		join TargetNamesT t2 on t1.Name like concat( t2.Name, '%')
		left join FoundNamesInIdentMw t3 on t1.SourceNameId = t3.SourceNameId and t2.TargetNameId = t3.TargetNameId
	where t3.SourceNameId is null

-- S=T
	insert FoundNamesInIdentMw(SourceNameId, TargetNameId, SearchType)
	select t1.SourceNameId, t2.TargetNameId, 'S=T' as SearchType
	from SourceNames t1
		join TargetNames t2 on t2.Name = t1.Name
		left join FoundNamesInIdentMw t3 on t1.SourceNameId = t3.SourceNameId and t2.TargetNameId = t3.TargetNameId
	where t3.SourceNameId is null

-- St=Tt
	insert FoundNamesInIdentMw(SourceNameId, TargetNameId, SearchType)
	select t1.SourceNameId, t2.TargetNameId, 'St=Tt' as SearchType
	from SourceNamesT t1
		join TargetNamesT t2 on t2.Name = t1.Name
		left join FoundNamesInIdentMw t3 on t1.SourceNameId = t3.SourceNameId and t2.TargetNameId = t3.TargetNameId
	where t3.SourceNameId is null

-- S~T
	insert FoundNamesInIdentMw(SourceNameId, TargetNameId, SearchType)
	select t1.SourceNameId, t2.TargetNameId, 'S~T' as SearchType
	from SourceNames t1
		join TargetNames t2 on t2.Name like concat( t1.Name, '%')
		left join FoundNamesInIdentMw t3 on t1.SourceNameId = t3.SourceNameId and t2.TargetNameId = t3.TargetNameId
	where t3.SourceNameId is null

-- T~S
	insert FoundNamesInIdentMw(SourceNameId, TargetNameId, SearchType)
	select t1.SourceNameId, t2.TargetNameId, 'T~S' as SearchType
	from SourceNames t1
		join TargetNames t2 on t1.Name like concat( t2.Name, '%')
		left join FoundNamesInIdentMw t3 on t1.SourceNameId = t3.SourceNameId and t2.TargetNameId = t3.TargetNameId
	where t3.SourceNameId is null

-- St=T
	insert FoundNamesInIdentMw(SourceNameId, TargetNameId, SearchType)
	select t1.SourceNameId, t2.TargetNameId, 'St=T' as SearchType
	from SourceNamesT t1
		join TargetNames t2 on t2.Name = t1.Name
		left join FoundNamesInIdentMw t3 on t1.SourceNameId = t3.SourceNameId and t2.TargetNameId = t3.TargetNameId
	where t3.SourceNameId is null

-- S=Tt
	insert FoundNamesInIdentMw(SourceNameId, TargetNameId, SearchType)
	select t1.SourceNameId, t2.TargetNameId, 'S=Tt' as SearchType
	from SourceNames t1
		join TargetNamesT t2 on t2.Name = t1.Name
		left join FoundNamesInIdentMw t3 on t1.SourceNameId = t3.SourceNameId and t2.TargetNameId = t3.TargetNameId
	where t3.SourceNameId is null

-- St~T
	insert FoundNamesInIdentMw(SourceNameId, TargetNameId, SearchType)
	select t1.SourceNameId, t2.TargetNameId, 'St~T' as SearchType
	from SourceNamesT t1
		join TargetNames t2 on t2.Name like concat( t1.Name, '%')
		left join FoundNamesInIdentMw t3 on t1.SourceNameId = t3.SourceNameId and t2.TargetNameId = t3.TargetNameId
	where t3.SourceNameId is null

-- S~Tt
	insert FoundNamesInIdentMw(SourceNameId, TargetNameId, SearchType)
	select t1.SourceNameId, t2.TargetNameId, 'S~Tt' as SearchType
	from SourceNames t1
		join TargetNamesT t2 on t2.Name like concat( t1.Name, '%')
		left join FoundNamesInIdentMw t3 on t1.SourceNameId = t3.SourceNameId and t2.TargetNameId = t3.TargetNameId
	where t3.SourceNameId is null

-- T~St
	insert FoundNamesInIdentMw(SourceNameId, TargetNameId, SearchType)
	select t1.SourceNameId, t2.TargetNameId, 'T~St' as SearchType
	from SourceNames t1
		join TargetNamesT t2 on t1.Name like concat( t2.Name, '%')
		left join FoundNamesInIdentMw t3 on t1.SourceNameId = t3.SourceNameId and t2.TargetNameId = t3.TargetNameId
	where t3.SourceNameId is null

exec spSetSearchStepEnded 30
--==================================================================
exec spSetSearchStepStarted 31
	delete from FoundWorksInIdentMw
	insert FoundWorksInIdentMw(SourceWorkId, TargetWorkId)
	select t2.WorkId as SourceWorkId, max(t4.WorkId) as TargetWorkId
	from FoundNamesInIdentMw t1
		join SourceNameWorks t2 on t1.SourceNameId = t2.SourceNameId
		join SourcePerformerParts t3 on t2.WorkId = t3.WorkId
		join TargetNameWorks t4 on t1.TargetNameId = t4.TargetNameId
		join TargetPerformerPartWorks t5 on t4.WorkId = t5.WorkId
		join TargetPerformerParts t51 on t51.TargetPerformerPartId = t5.TargetPerformerPartId
		join SourceAuthorParts t6 on t2.WorkId = t6.WorkId
		join TargetAuthorPartWorks t7 on t4.WorkId = t7.WorkId
		join TargetAuthorParts t71 on t71.TargetAuthorPartId = t7.TargetAuthorPartId
	where t3.Name = t51.Name
		and t6.Name = t71.Name
	group by t2.WorkId

	update t2
	set t2.ObjId = t3.ObjId, t2.WIc = t3.Wic, t2.Status = t3.Status
	from FoundWorksInIdentMw t1
		join Ddex..IdentMw t2 on t1.SourceWorkId = t2.Id
		join Ddex..IdentMw t3 on t1.TargetWorkId = t3.Id
exec spSetSearchStepEnded 31
/*
	select t2.Title, t2.ComposerAuthor, t2.DisplayArtistName, t3.Title, t3.ComposerAuthor, t3.DisplayArtistName
	from FoundWorksInIdentMw t1
		join Ddex..IdentMw t2 on t1.SourceWorkId = t2.Id
		join Ddex..IdentMw t3 on t1.TargetWorkId = t3.Id
*/
end

-- spSearchNameInIdentMw 1496
GO
/****** Object:  StoredProcedure [dbo].[spSearchInMs]    Script Date: 09.08.2025 13:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create   procedure [dbo].[spSearchInMs]
	@ddexReportId int
as
begin

	exec spCreateSourceInfo @ddexReportId
	exec spUpdateTargetInfoMs

	delete from FoundNamesInMs

	exec spSetSearchStepStarted 30

-- ПОВНЕ СПІВПАДІННЯ
-- St=Tt
	insert FoundNamesInMs(SourceNameId, TargetNameId, SearchType)
	select t1.SourceNameId, t2.TargetNameId, 'St=Tt' as SearchType
	from SourceNamesT t1
		join TargetNamesMsT t2 on t2.Name = t1.Name
		left join FoundNamesInMs t3 on t1.SourceNameId = t3.SourceNameId and t2.TargetNameId = t3.TargetNameId
	where t3.SourceNameId is null

-- S=T (на практиці нічого не додасть)
	insert FoundNamesInMs(SourceNameId, TargetNameId, SearchType)
	select t1.SourceNameId, t2.TargetNameId, 'S=T' as SearchType
	from SourceNames t1
		join TargetNamesMs t2 on t2.Name = t1.Name
		left join FoundNamesInMs t3 on t1.SourceNameId = t3.SourceNameId and t2.TargetNameId = t3.TargetNameId
	where t3.SourceNameId is null

-- St=T
	insert FoundNamesInMs(SourceNameId, TargetNameId, SearchType)
	select t1.SourceNameId, t2.TargetNameId, 'St=T' as SearchType
	from SourceNamesT t1
		join TargetNamesMs t2 on t2.Name = t1.Name
		left join FoundNamesInMs t3 on t1.SourceNameId = t3.SourceNameId and t2.TargetNameId = t3.TargetNameId
	where t3.SourceNameId is null

-- S=Tt
	insert FoundNamesInMs(SourceNameId, TargetNameId, SearchType)
	select t1.SourceNameId, t2.TargetNameId, 'S=Tt' as SearchType
	from SourceNames t1
		join TargetNamesMsT t2 on t2.Name = t1.Name
		left join FoundNamesInMs t3 on t1.SourceNameId = t3.SourceNameId and t2.TargetNameId = t3.TargetNameId
	where t3.SourceNameId is null

-- ПОДІБНІ ПОЧАТКИ НАЗВИ
-- ЗАУВАЖЕННЯ - текст, який шукається, слід супроводжувати пробілом, інакше буде знаходиться не потрібне
drop table if exists #SourceNames
select SourceNameId, concat(Name, ' ') as Name 
into #SourceNames
from SourceNames

drop table if exists #SourceNamesT
select SourceNameId, concat(Name, ' ') as Name 
into #SourceNamesT
from SourceNamesT

drop table if exists #TargetNamesMs
select TargetNameId, concat(Name, ' ') as Name 
into #TargetNamesMs
from TargetNamesMs

drop table if exists #TargetNamesMsT
select TargetNameId, concat(Name, ' ') as Name 
into #TargetNamesMsT
from TargetNamesMsT

-- St~Tt
	insert FoundNamesInMs(SourceNameId, TargetNameId, SearchType)
	select t1.SourceNameId, t2.TargetNameId, 'St~Tt' as SearchType
	from #SourceNamesT t1
		join TargetNamesMsT t2 on t2.Name like concat( t1.Name, '%')
		left join FoundNamesInMs t3 on t1.SourceNameId = t3.SourceNameId and t2.TargetNameId = t3.TargetNameId
	where t3.SourceNameId is null

-- Tt~St
	insert FoundNamesInMs(SourceNameId, TargetNameId, SearchType)
	select t1.SourceNameId, t2.TargetNameId, 'Tt~St' as SearchType
	from SourceNamesT t1
		join #TargetNamesMsT t2 on t1.Name like concat( t2.Name, '%')
		left join FoundNamesInMs t3 on t1.SourceNameId = t3.SourceNameId and t2.TargetNameId = t3.TargetNameId
	where t3.SourceNameId is null


-- S~T
	insert FoundNamesInMs(SourceNameId, TargetNameId, SearchType)
	select t1.SourceNameId, t2.TargetNameId, 'S~T' as SearchType
	from #SourceNames t1
		join TargetNamesMs t2 on t2.Name like concat( t1.Name, '%')
		left join FoundNamesInMs t3 on t1.SourceNameId = t3.SourceNameId and t2.TargetNameId = t3.TargetNameId
	where t3.SourceNameId is null

-- T~S
	insert FoundNamesInMs(SourceNameId, TargetNameId, SearchType)
	select t1.SourceNameId, t2.TargetNameId, 'T~S' as SearchType
	from SourceNames t1
		join #TargetNamesMs t2 on t1.Name like concat( t2.Name, '%')
		left join FoundNamesInMs t3 on t1.SourceNameId = t3.SourceNameId and t2.TargetNameId = t3.TargetNameId
	where t3.SourceNameId is null


-- St~T
	insert FoundNamesInMs(SourceNameId, TargetNameId, SearchType)
	select t1.SourceNameId, t2.TargetNameId, 'St~T' as SearchType
	from #SourceNamesT t1
		join TargetNamesMs t2 on t2.Name like concat( t1.Name, '%')
		left join FoundNamesInMs t3 on t1.SourceNameId = t3.SourceNameId and t2.TargetNameId = t3.TargetNameId
	where t3.SourceNameId is null

-- S~Tt
	insert FoundNamesInMs(SourceNameId, TargetNameId, SearchType)
	select t1.SourceNameId, t2.TargetNameId, 'S~Tt' as SearchType
	from #SourceNames t1
		join TargetNamesMsT t2 on t2.Name like concat( t1.Name, '%')
		left join FoundNamesInMs t3 on t1.SourceNameId = t3.SourceNameId and t2.TargetNameId = t3.TargetNameId
	where t3.SourceNameId is null

-- T~St
	insert FoundNamesInMs(SourceNameId, TargetNameId, SearchType)
	select t1.SourceNameId, t2.TargetNameId, 'T~St' as SearchType
	from SourceNames t1
		join #TargetNamesMsT t2 on t1.Name like concat( t2.Name, '%')
		left join FoundNamesInMs t3 on t1.SourceNameId = t3.SourceNameId and t2.TargetNameId = t3.TargetNameId
	where t3.SourceNameId is null

exec spSetSearchStepEnded 30

--==================================================================
exec spSetSearchStepStarted 31
	delete from FoundWorksInMs
	insert FoundWorksInMs(SourceWorkId, TargetObjId)
	select t2.WorkId as SourceWorkId, max(t4.WorkId) as TargetWorkId
	from FoundNamesInMs t1
		join SourceNameWorks t2 on t1.SourceNameId = t2.SourceNameId
		join SourcePerformerParts t3 on t2.WorkId = t3.WorkId
		join TargetNameWorksMs t4 on t1.TargetNameId = t4.TargetNameId
		join TargetPerformerPartWorksMs t5 on t4.WorkId = t5.WorkId
		join TargetPerformerPartsMs t51 on t51.TargetPerformerPartId = t5.TargetPerformerPartId
		join SourceAuthorParts t6 on t2.WorkId = t6.WorkId
		join TargetAuthorPartWorksMs t7 on t4.WorkId = t7.WorkId
		join TargetAuthorPartsMs t71 on t71.TargetAuthorPartId = t7.TargetAuthorPartId
	where t3.Name = t51.Name
		and t6.Name = t71.Name
	group by t2.WorkId

	update t2
	set t2.ObjId = t1.TargetObjId, t2.Wic = null, t2.Status = 2
	from FoundWorksInMs t1
		join Ddex..IdentMw t2 on t1.SourceWorkId = t2.Id
	exec spSetSearchStepEnded 31

/*
	select t2.Title, t2.ComposerAuthor, t2.DisplayArtistName, t3.Name, t3.Author, t3.Performer
	from FoundWorksInMs t1
		join Ddex..IdentMw t2 on t1.SourceWorkId = t2.Id
		join MediaService..ObjectRight t3 on t1.TargetObjId = t3.ObjId
*/
end

-- spSearchNameInMs 1496
GO
/****** Object:  StoredProcedure [dbo].[spSearchInWid]    Script Date: 09.08.2025 13:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create   procedure [dbo].[spSearchInWid]
	@ddexReportId int
as
begin

	delete from FoundNamesInWid

	update SearchStepsWid set Status = 1 where Id = 30
-- St~Tt

	insert FoundNamesInWid(SourceNameId, TargetNameId, SearchType)
	select t1.SourceNameId, t2.Wic, 'St~Tt' as SearchType
	from SourceNamesT t1
		join SocWid..WidTitle t2 on t2.WrkTtl = t1.Name
		left join FoundNamesInWid t3 on t1.SourceNameId = t3.SourceNameId and t2.Wic = t3.TargetNameId
	where t3.SourceNameId is null
	union
	select t1.SourceNameId, t2.Wic, 'St~Tt' as SearchType
	from SourceNamesT t1
		join SocWid..widAltTtl t2 on t2.AltTtl = t1.Name
		left join FoundNamesInWid t3 on t1.SourceNameId = t3.SourceNameId and t2.Wic = t3.TargetNameId
	where t3.SourceNameId is null

drop table if exists #FoundNamesInWidByPerformer
select *
into #FoundNamesInWidByPerformer
from FoundNamesInWid t1
	join SocWid..widArtist t2 on t1.TargetNameId = t2.Wic
	join SourcePerformerParts t3 on t2.PerfArtistLstName = t3.Name

select *
from #FoundNamesInWidByPerformer t1
	join SourceWorks t2 on t1.WorkId = t2.WorkId



update SearchStepsWid set Status = 2 where Id = 30


--==================================================================
update SearchStepsWid set Status = 1 where Id = 31
	delete from FoundWorksInWid
	insert FoundWorksInWid(SourceWorkId, TargetWic)
	select t2.WorkId as SourceWorkId, max(t4.WorkId) as TargetWorkId
	from FoundNamesInWid t1
		join SourceNameWorks t2 on t1.SourceNameId = t2.SourceNameId
		join SourcePerformerParts t3 on t2.WorkId = t3.WorkId
		join TargetNameWorksMs t4 on t1.TargetNameId = t4.TargetNameId
		join TargetPerformerPartWorksMs t5 on t4.WorkId = t5.WorkId
		join TargetPerformerPartsMs t51 on t51.TargetPerformerPartId = t5.TargetPerformerPartId
		join SourceAuthorParts t6 on t2.WorkId = t6.WorkId
		join TargetAuthorPartWorksMs t7 on t4.WorkId = t7.WorkId
		join TargetAuthorPartsMs t71 on t71.TargetAuthorPartId = t7.TargetAuthorPartId
	where t3.Name = t51.Name
		and t6.Name = t71.Name
	group by t2.WorkId

	update t2
	set t2.ObjId = t1.TargetObjId, t2.Wic = null, t2.Status = 2
	from FoundWorksInMs t1
		join Ddex..IdentMw t2 on t1.SourceWorkId = t2.Id
	update SearchStepsWid set Status = 2 where Id = 31

/*
	select t2.Title, t2.ComposerAuthor, t2.DisplayArtistName, t3.Name, t3.Author, t3.Performer
	from FoundWorksInMs t1
		join Ddex..IdentMw t2 on t1.SourceWorkId = t2.Id
		join MediaService..ObjectRight t3 on t1.TargetObjId = t3.ObjId
*/
end

-- spSearchNameInMs 1496
GO
/****** Object:  StoredProcedure [dbo].[spSetSearchStepEnded]    Script Date: 09.08.2025 13:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create   procedure [dbo].[spSetSearchStepEnded]
	@stepId int
as
begin
	update SearchSteps set Status = 2 where Id = @stepId
end
GO
/****** Object:  StoredProcedure [dbo].[spSetSearchStepStarted]    Script Date: 09.08.2025 13:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create   procedure [dbo].[spSetSearchStepStarted]
	@stepId int
as
begin
	update SearchSteps set Status = 1 where Id = @stepId
end
GO
/****** Object:  StoredProcedure [dbo].[spSysClearDatabase]    Script Date: 09.08.2025 13:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create   procedure [dbo].[spSysClearDatabase]
as
begin

drop table if exists TargetNameWorks
drop table if exists TargetNames
drop table if exists TargetNamesT

drop table if exists TargetPerformerPartWorks
drop table if exists TargetPerformerParts

drop table if exists TargetAuthorPartWorks
drop table if exists TargetAuthorParts

drop table if exists FoundNamesInIdentMw
drop table if exists FoundWorksInIdentMw

drop table if exists SearchSteps
drop table if exists SourceWorks
drop table if exists SourceNames
drop table if exists SourceNamesT
drop table if exists SourceNameWorks
drop table if exists SourcePerformerParts
drop table if exists SourceAuthorParts

drop table if exists ExtraTargetWorks
drop table if exists ExtraTargetNames
drop table if exists ExtraTargetNamesT
drop table if exists ExtraTargetNameWorks
drop table if exists ExtraTargetPerformerParts
drop table if exists ExtraTargetPerformerPartWorks
drop table if exists ExtraTargetAuthorParts
drop table if exists ExtraTargetAuthorPartWorks

drop table if exists TargetWorks

-- MS

drop table if exists TargetNameWorksMs
drop table if exists TargetNamesMs
drop table if exists TargetNamesMsT

drop table if exists TargetPerformerPartWorksMs
drop table if exists TargetPerformerPartsMs

drop table if exists TargetAuthorPartWorksMs
drop table if exists TargetAuthorPartsMs

drop table if exists FoundNamesInMs
drop table if exists FoundWorksInMs

drop table if exists SearchStepsMs

drop table if exists TargetWorksMs

end
GO
/****** Object:  StoredProcedure [dbo].[spUpdateTargetInfo]    Script Date: 09.08.2025 13:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create   procedure [dbo].[spUpdateTargetInfo]
as
begin

-- =================================== РОБОЧА ІНФОРМАЦІЯ ДЛЯ ОНОВЛЕННЯ ІНФОРМАЦІЇ ДЛЯ ПОШУКУ
-- Інформація робоча, після передачі в головні таблиці інформація з цих таблиць видаляється
begin

-- НАЗВИ
-- Початковий системний код нової інформації стосовно творів
	declare @baseTargetWorkId int = (select isnull(max(TargetWorkId), 0) from TargetWorks)

-- ExtraTargetWorks
	exec spSetSearchStepStarted 7
	truncate table ExtraTargetWorks
	insert ExtraTargetWorks(
		  TargetWorkId
		, WorkId
		, Name
		, Authors
		, Performers)
	select 
		@baseTargetWorkId + row_number() over(order by Id)
		, Id
		, Title
		, translate(ComposerAuthor, '.|,()&:;\/', '          ')
		, translate(DisplayArtistName, '.|,()&:;\/', '          ')
	from Ddex..IdentMw t1
		left join TargetWorks t2 on t1.Id = t2.WorkId
	where (
			isnull(objId, 0) <> 0
			or isnull(Wic, 0) <> 0
		)
		and t2.WorkId is null
	exec spSetSearchStepEnded 7

	-- select * from ExtraTargetWorks

-- ExtraTargetNames
-- Початковий системний код нової інформації стосовно назв
	declare @baseTargetNameId int = (select isnull(max(TargetNameId), 0) from TargetNames)
	exec spSetSearchStepStarted 8
	truncate table ExtraTargetNames
	; with TmpNames as (
		select distinct Name
		from ExtraTargetWorks
	)
	insert ExtraTargetNames(TargetNameId, Name)
	select @baseTargetNameId + row_number() over(order by Name), Name
	from TmpNames
	exec spSetSearchStepEnded 8

	-- select * from ExtraTargetNames

-- ExtraTargetNamesT
	exec spSetSearchStepStarted 9
	truncate table ExtraTargetNamesT
	insert ExtraTargetNamesT(TargetNameId, Name)
	select TargetNameId, AutoSearch.dbo.ClrTranslitFromUkrToLat(Name)
	from ExtraTargetNames
	exec spSetSearchStepEnded 9

	-- select * from ExtraTargetNamesT

-- ExtraTargetNameWorks
	exec spSetSearchStepStarted 10
	truncate table ExtraTargetNameWorks
	insert ExtraTargetNameWorks(TargetNameId, WorkId, ObjId, Wic)
	select distinct t1.TargetNameId, t2.WorkId, null, null
	from ExtraTargetNames t1
		join ExtraTargetWorks t2 on t1.Name = t2.Name
	exec spSetSearchStepEnded 10

	-- select * from ExtraTargetNameWorks

-- ВИКОНАВЦІ
-- Додаткова інформація без дублювань (назви транслітеровані)
	exec spSetSearchStepStarted 11
	drop table if exists #ExtraTargetPerformerParts
	select distinct WorkId, left(AutoSearch.dbo.ClrTranslitFromUkrToLat(value), 64) as Name
	into #ExtraTargetPerformerParts
	from ExtraTargetWorks
		cross apply string_split(Performers, ' ')
	where len(value) > 2
	exec spSetSearchStepEnded 11

	-- select * from #ExtraTargetPerformerParts

-- Початковий системний код нової інформації стосовно виконавців
	exec spSetSearchStepEnded 12
	declare @baseTargetPerformerPart int = (select isnull(max(TargetPerformerPartId), 0) from TargetPerformerParts)

-- ExtraTargetPerformerParts
	truncate table ExtraTargetPerformerParts
	; with TmpTargetPerformerParts as (
		select distinct Name
		from #ExtraTargetPerformerParts
	)
	insert ExtraTargetPerformerParts(TargetPerformerPartId, Name)
	select @baseTargetPerformerPart + row_number() over(order by Name), Name
	from TmpTargetPerformerParts
	exec spSetSearchStepEnded 12

	-- select * from ExtraTargetPerformerParts

-- ExtraTargetPerformerPartWorks
	exec spSetSearchStepStarted 13
	truncate table ExtraTargetPerformerPartWorks
	insert ExtraTargetPerformerPartWorks(TargetPerformerPartId, WorkId)
	select t1.TargetPerformerPartId, t2.WorkId
	from ExtraTargetPerformerParts t1
		join #ExtraTargetPerformerParts t2 on t1.Name = t2.Name
	exec spSetSearchStepEnded 13

	-- select * from ExtraTargetPerformerPartWorks

	drop table if exists #ExtraTargetPerformerParts

-- АВТОРИ
-- Додаткова інформація без дублювань (назви транслітеровані)
	exec spSetSearchStepStarted 14
	drop table if exists #ExtraTargetAuthorParts
	select distinct WorkId, left(AutoSearch.dbo.ClrTranslitFromUkrToLat(value), 64) as Name
	into #ExtraTargetAuthorParts
	from ExtraTargetWorks
		cross apply string_split(Authors, ' ')
	where len(value) > 2
	exec spSetSearchStepEnded 14
	-- select * from #ExtraTargetAuthorParts

-- Початковий системний код нової інформації стосовно виконавців
	declare @baseTargetAuthorPart int = (select isnull(max(TargetAuthorPartId), 0) from TargetAuthorParts)

-- ExtraTargetAuthorParts
	exec spSetSearchStepStarted 15
	truncate table ExtraTargetAuthorParts
	; with TmpTargetAuthorParts as (
		select distinct Name
		from #ExtraTargetAuthorParts
	)
	insert ExtraTargetAuthorParts(TargetAuthorPartId, Name)
	select @baseTargetAuthorPart + row_number() over(order by Name), Name
	from TmpTargetAuthorParts
	exec spSetSearchStepEnded 15

	-- select * from ExtraTargetAuthorParts

-- ExtraTargetAuthorPartWorks
	exec spSetSearchStepStarted 16
	truncate table ExtraTargetAuthorPartWorks
	insert ExtraTargetAuthorPartWorks(TargetAuthorPartId, WorkId)
	select t1.TargetAuthorPartId, t2.WorkId
	from ExtraTargetAuthorParts t1
		join #ExtraTargetAuthorParts t2 on t1.Name = t2.Name
	exec spSetSearchStepEnded 16

	-- select * from ExtraTargetAuthorPartWorks

	drop table if exists #ExtraTargetAuthorParts
end

-- =================================== РОЗШИРЕННЯ ІНФОРМАЦІЮ ДЛЯ ПОШУКУ
-- Таблиці постійні
begin
-- НАЗВИ
-- Коди назв які слід додати без дублювання
	exec spSetSearchStepStarted 17
	drop table if exists #ExtraTargetNameIdsToAdd
	select t1.TargetNameId
	into #ExtraTargetNameIdsToAdd
	from ExtraTargetNames t1
		left join TargetNames t2 on t1.Name = t2.Name
	where t2.Name is null
	exec spSetSearchStepEnded 17
	-- select * from #ExtraTargetNameIdsToAdd

-- TargetNames
	exec spSetSearchStepStarted 18
	insert TargetNames(TargetNameId, Name)
	select t1.TargetNameId, t1.Name
	from ExtraTargetNames t1
		join #ExtraTargetNameIdsToAdd t2 on t1.TargetNameId = t2.TargetNameId
	exec spSetSearchStepEnded 18
	-- select * from TargetNames

-- TargetNamesT
	exec spSetSearchStepStarted 19
	insert TargetNamesT(TargetNameId, Name)
	select t1.TargetNameId, t1.Name
	from ExtraTargetNamesT t1
		join #ExtraTargetNameIdsToAdd t2 on t1.TargetNameId = t2.TargetNameId
	exec spSetSearchStepEnded 19

-- Коригуємо посилання
	exec spSetSearchStepStarted 20
	update t1
	set t1.TargetNameId = t3.TargetNameId
	--select *
	from ExtraTargetNameWorks t1
		join ExtraTargetNames t2 on t1.TargetNameId = t2.TargetNameId
		join TargetNames t3 on t2.Name = t3.Name
	exec spSetSearchStepEnded 20

-- TargetNameWorks
	exec spSetSearchStepStarted 21
	insert TargetNameWorks(TargetNameId, WorkId, ObjId, Wic)
	select TargetNameId, WorkId, ObjId, Wic
	from ExtraTargetNameWorks
	exec spSetSearchStepEnded 21

	drop table if exists #ExtraTargetNameIdsToAdd

-- ВИКОНАВЦІ

-- Коди виконавців які слід додати без дублювання
	exec spSetSearchStepStarted 22
	drop table if exists #ExtraTargetPerformerPartIdsToAdd

	select t1.TargetPerformerPartId
	into #ExtraTargetPerformerPartIdsToAdd
	from ExtraTargetPerformerParts t1
		left join TargetPerformerParts t2 on t1.Name = t2.Name
	where t2.Name is null
	exec spSetSearchStepEnded 22

	-- select * from #ExtraTargetPerformerPartIdsToAdd

-- TargetPerformerParts
	exec spSetSearchStepStarted 23
	insert TargetPerformerParts(TargetPerformerPartId, Name)
	select t1.TargetPerformerPartId, t1.Name
	from ExtraTargetPerformerParts t1
		join #ExtraTargetPerformerPartIdsToAdd t2 on t1.TargetPerformerPartId = t2.TargetPerformerPartId
	exec spSetSearchStepEnded 23

-- Коригуємо посилання
	exec spSetSearchStepStarted 24
	update t1
	set t1.TargetPerformerPartId = t3.TargetPerformerPartId
	-- select *
	from ExtraTargetPerformerPartWorks t1
		join ExtraTargetPerformerParts t2 on t1.TargetPerformerPartId = t2.TargetPerformerPartId
		join TargetPerformerParts t3 on t2.Name = t3.Name
		exec spSetSearchStepEnded 24

-- TargetPerformerPartWorks
	exec spSetSearchStepStarted 25
	insert TargetPerformerPartWorks(TargetPerformerPartId, WorkId)
	select TargetPerformerPartId, WorkId
	from ExtraTargetPerformerPartWorks
	exec spSetSearchStepEnded 25

	drop table if exists #ExtraTargetPerformerPartIdsToAdd

-- АВТОРИ

-- Коди авторів які слід додати без дублювання
	exec spSetSearchStepStarted 26
	drop table if exists #ExtraTargetAuthorPartIdsToAdd

	select t1.TargetAuthorPartId
	into #ExtraTargetAuthorPartIdsToAdd
	from ExtraTargetAuthorParts t1
		left join TargetAuthorParts t2 on t1.Name = t2.Name
	where t2.Name is null
	exec spSetSearchStepEnded 26
	-- select * from #ExtraTargetAuthorPartIdsToAdd

-- TargetAuthorParts
	exec spSetSearchStepStarted 27
	insert TargetAuthorParts(TargetAuthorPartId, Name)
	select t1.TargetAuthorPartId, t1.Name
	from ExtraTargetAuthorParts t1
		join #ExtraTargetAuthorPartIdsToAdd t2 on t1.TargetAuthorPartId = t2.TargetAuthorPartId
	exec spSetSearchStepEnded 27

-- TargetAuthorPartWorks
	exec spSetSearchStepStarted 28
	insert TargetAuthorPartWorks(TargetAuthorPartId, WorkId)
	select TargetAuthorPartId, WorkId
	from ExtraTargetAuthorPartWorks
	exec spSetSearchStepEnded 28

	drop table if exists #ExtraTargetAuthorPartIdsToAdd

-- Коди творів для яких створена інформація для пошуку
	exec spSetSearchStepStarted 29
	insert TargetWorks(TargetWorkId, WorkId)
	select t1.TargetWorkId, t1.WorkId 
	from ExtraTargetWorks t1
		left join TargetWorks t2 on t1.WorkId = t2.WorkId
	where t2.WorkId is null
	exec spSetSearchStepEnded 29

end

end -- PROCEDURE
GO
/****** Object:  StoredProcedure [dbo].[spUpdateTargetInfoMs]    Script Date: 09.08.2025 13:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create   procedure [dbo].[spUpdateTargetInfoMs]
as
begin

-- =================================== РОБОЧА ІНФОРМАЦІЯ ДЛЯ ОНОВЛЕННЯ ІНФОРМАЦІЇ ДЛЯ ПОШУКУ
-- Інформація робоча, після передачі в головні таблиці інформація з цих таблиць видаляється
begin

-- НАЗВИ
-- Початковий системний код нової інформації стосовно творів
	declare @baseTargetWorkId int = (select isnull(max(TargetWorkId), 0) from TargetWorksMs)
--	select * from TargetWorksMs

-- ExtraTargetWorks
	exec spSetSearchStepStarted 7
	truncate table ExtraTargetWorks
	insert ExtraTargetWorks(
		  TargetWorkId
		, WorkId
		, Name
		, Authors
		, Performers)
	select 
		  @baseTargetWorkId + row_number() over(order by t1.ObjId)
		, t1.ObjId
		, t1.Name
		, translate(t1.author, '.|,()&:;\/', '          ')
		, translate(t1.performer, '.|,()&:;\/', '          ')
	from MediaService..ObjectRight t1
		left join TargetWorksMs t2 on t1.ObjId = t2.ObjId
	where t2.ObjId is null
		and trim(isnull(t1.Name, '')) <> ''
	update SearchSteps set Status = 2 where Id = 7

	-- select * from ExtraTargetWorks

-- ExtraTargetNames - ObjectRight
-- Початковий системний код нової інформації стосовно назв
	declare @baseTargetNameId int = (select isnull(max(TargetNameId), 0) from TargetNamesMs)
	exec spSetSearchStepStarted 8
	truncate table ExtraTargetNames
	; with TmpNames as (
		select distinct Name
		from ExtraTargetWorks
		union
		select Name
		from MediaService..SeekObject
		where CodeI = 1
	)
	insert ExtraTargetNames(TargetNameId, Name)
	select @baseTargetNameId + row_number() over(order by Name), Name
	from TmpNames
	where trim(isnull(Name, '')) <> ''
	exec spSetSearchStepEnded 8

	-- select * from ExtraTargetNames order by Name

-- ExtraTargetNamesT
	exec spSetSearchStepStarted 9
	truncate table ExtraTargetNamesT
	insert ExtraTargetNamesT(TargetNameId, Name)
	select TargetNameId, AutoSearch.dbo.ClrTranslitFromUkrToLat(Name)
	from ExtraTargetNames
	exec spSetSearchStepEnded 9

	-- select * from ExtraTargetNamesT

-- ExtraTargetNameWorks
	exec spSetSearchStepStarted 10
	truncate table ExtraTargetNameWorks
	insert ExtraTargetNameWorks(TargetNameId, WorkId, ObjId, Wic)
	select distinct t1.TargetNameId, t2.WorkId, null, null
	from ExtraTargetNames t1
		join ExtraTargetWorks t2 on t1.Name = t2.Name
	union
	select distinct t1.TargetNameId, t2.ObjId, null, null
	from ExtraTargetNames t1
		join MediaService..SeekObject t2 on t1.Name = t2.Name
	where t2.CodeI = 1
	exec spSetSearchStepEnded 10

	-- select * from ExtraTargetNameWorks

-- ВИКОНАВЦІ
-- Додаткова інформація без дублювань (назви транслітеровані)
	exec spSetSearchStepStarted 11
	drop table if exists #ExtraTargetPerformerParts
	select distinct 
		  WorkId
		, left(
				trim('.,#/\&:| ' from AutoSearch.dbo.ClrTranslitFromUkrToLat(value))
		   , 64) as Name
	into #ExtraTargetPerformerParts
	from ExtraTargetWorks
		cross apply string_split(Performers, ' ')
	where len(value) > 2
	exec spSetSearchStepEnded 11

	-- select * from #ExtraTargetPerformerParts order by Name desc

-- Початковий системний код нової інформації стосовно виконавців
	exec spSetSearchStepEnded 12
	declare @baseTargetPerformerPart int = (select isnull(max(TargetPerformerPartId), 0) from TargetPerformerPartsMs)

-- ExtraTargetPerformerParts
	truncate table ExtraTargetPerformerParts
	; with TmpTargetPerformerParts as (
		select distinct Name
		from #ExtraTargetPerformerParts
	)
	insert ExtraTargetPerformerParts(TargetPerformerPartId, Name)
	select @baseTargetPerformerPart + row_number() over(order by Name), Name
	from TmpTargetPerformerParts
	exec spSetSearchStepEnded 12

	-- select * from ExtraTargetPerformerParts

-- ExtraTargetPerformerPartWorks
	exec spSetSearchStepStarted 13
	truncate table ExtraTargetPerformerPartWorks
	insert ExtraTargetPerformerPartWorks(TargetPerformerPartId, WorkId)
	select t1.TargetPerformerPartId, t2.WorkId
	from ExtraTargetPerformerParts t1
		join #ExtraTargetPerformerParts t2 on t1.Name = t2.Name
	exec spSetSearchStepEnded 13

	-- select * from ExtraTargetPerformerPartWorks

	drop table if exists #ExtraTargetPerformerParts

-- АВТОРИ
-- Додаткова інформація без дублювань (назви транслітеровані)
	exec spSetSearchStepStarted 14
	drop table if exists #ExtraTargetAuthorParts
	select distinct 
		  WorkId
		, left(
			    trim('.,#/\&:| ' from AutoSearch.dbo.ClrTranslitFromUkrToLat(value))
			, 64) as Name
	into #ExtraTargetAuthorParts
	from ExtraTargetWorks
		cross apply string_split(Authors, ' ')
	where len(value) > 2
	exec spSetSearchStepEnded 14
	-- select * from #ExtraTargetAuthorParts

-- Початковий системний код нової інформації стосовно виконавців
	declare @baseTargetAuthorPart int = (select isnull(max(TargetAuthorPartId), 0) from TargetAuthorPartsMs)

-- ExtraTargetAuthorParts
	exec spSetSearchStepStarted 15
	truncate table ExtraTargetAuthorParts
	; with TmpTargetAuthorParts as (
		select distinct Name
		from #ExtraTargetAuthorParts
	)
	insert ExtraTargetAuthorParts(TargetAuthorPartId, Name)
	select @baseTargetAuthorPart + row_number() over(order by Name), Name
	from TmpTargetAuthorParts
	exec spSetSearchStepEnded 15

	-- select * from ExtraTargetAuthorParts

-- ExtraTargetAuthorPartWorks
	exec spSetSearchStepStarted 16
	truncate table ExtraTargetAuthorPartWorks
	insert ExtraTargetAuthorPartWorks(TargetAuthorPartId, WorkId)
	select t1.TargetAuthorPartId, t2.WorkId
	from ExtraTargetAuthorParts t1
		join #ExtraTargetAuthorParts t2 on t1.Name = t2.Name
	exec spSetSearchStepEnded 16

	-- select * from ExtraTargetAuthorPartWorks

	drop table if exists #ExtraTargetAuthorParts
end

-- =================================== РОЗШИРЕННЯ ІНФОРМАЦІЮ ДЛЯ ПОШУКУ
-- Таблиці постійні
begin
-- НАЗВИ
-- Коди назв які слід додати без дублювання
	exec spSetSearchStepStarted 17
	drop table if exists #ExtraTargetNameIdsToAdd
	select t1.TargetNameId
	into #ExtraTargetNameIdsToAdd
	from ExtraTargetNames t1
		left join TargetNamesMs t2 on t1.Name = t2.Name
	where t2.Name is null
	exec spSetSearchStepEnded 17
	-- select * from #ExtraTargetNameIdsToAdd

-- TargetNames
	exec spSetSearchStepStarted 18
	insert TargetNamesMs(TargetNameId, Name)
	select t1.TargetNameId, t1.Name
	from ExtraTargetNames t1
		join #ExtraTargetNameIdsToAdd t2 on t1.TargetNameId = t2.TargetNameId
	exec spSetSearchStepEnded 18
	-- select * from TargetNames

-- TargetNamesT
	exec spSetSearchStepStarted 19
	insert TargetNamesMsT(TargetNameId, Name)
	select t1.TargetNameId, t1.Name
	from ExtraTargetNamesT t1
		join #ExtraTargetNameIdsToAdd t2 on t1.TargetNameId = t2.TargetNameId
	exec spSetSearchStepEnded 19

-- Коригуємо посилання
	exec spSetSearchStepStarted 20
	update t1
	set t1.TargetNameId = t3.TargetNameId
	--select *
	from ExtraTargetNameWorks t1
		join ExtraTargetNames t2 on t1.TargetNameId = t2.TargetNameId
		join TargetNamesMs t3 on t2.Name = t3.Name
	exec spSetSearchStepEnded 20

-- TargetNameWorks
	exec spSetSearchStepStarted 21
	insert TargetNameWorksMs(TargetNameId, WorkId, ObjId, Wic)
	select TargetNameId, WorkId, ObjId, Wic
	from ExtraTargetNameWorks
	exec spSetSearchStepEnded 21

	drop table if exists #ExtraTargetNameIdsToAdd

-- ВИКОНАВЦІ

-- Коди виконавців які слід додати без дублювання
	exec spSetSearchStepStarted 22
	drop table if exists #ExtraTargetPerformerPartIdsToAdd

	select t1.TargetPerformerPartId
	into #ExtraTargetPerformerPartIdsToAdd
	from ExtraTargetPerformerParts t1
		left join TargetPerformerPartsMs t2 on t1.Name = t2.Name
	where t2.Name is null
	exec spSetSearchStepEnded 22

	-- select * from #ExtraTargetPerformerPartIdsToAdd

-- TargetPerformerParts
	exec spSetSearchStepStarted 23
	insert TargetPerformerPartsMs(TargetPerformerPartId, Name)
	select t1.TargetPerformerPartId, t1.Name
	from ExtraTargetPerformerParts t1
		join #ExtraTargetPerformerPartIdsToAdd t2 on t1.TargetPerformerPartId = t2.TargetPerformerPartId
	exec spSetSearchStepEnded 23

-- Коригуємо посилання
	exec spSetSearchStepStarted 24
	update t1
	set t1.TargetPerformerPartId = t3.TargetPerformerPartId
	-- select *
	from ExtraTargetPerformerPartWorks t1
		join ExtraTargetPerformerParts t2 on t1.TargetPerformerPartId = t2.TargetPerformerPartId
		join TargetPerformerPartsMs t3 on t2.Name = t3.Name
	exec spSetSearchStepEnded 24

-- TargetPerformerPartWorks
	exec spSetSearchStepStarted 25
	insert TargetPerformerPartWorksMs(TargetPerformerPartId, WorkId)
	select TargetPerformerPartId, WorkId
	from ExtraTargetPerformerPartWorks
	exec spSetSearchStepEnded 25

	drop table if exists #ExtraTargetPerformerPartIdsToAdd

-- АВТОРИ

-- Коди авторів які слід додати без дублювання
	exec spSetSearchStepStarted 26
	drop table if exists #ExtraTargetAuthorPartIdsToAdd

	select t1.TargetAuthorPartId
	into #ExtraTargetAuthorPartIdsToAdd
	from ExtraTargetAuthorParts t1
		left join TargetAuthorPartsMs t2 on t1.Name = t2.Name
	where t2.Name is null
	exec spSetSearchStepEnded 26
	-- select * from #ExtraTargetAuthorPartIdsToAdd

-- TargetAuthorParts
	exec spSetSearchStepStarted 27
	insert TargetAuthorPartsMs(TargetAuthorPartId, Name)
	select t1.TargetAuthorPartId, t1.Name
	from ExtraTargetAuthorParts t1
		join #ExtraTargetAuthorPartIdsToAdd t2 on t1.TargetAuthorPartId = t2.TargetAuthorPartId
	exec spSetSearchStepEnded 27

-- TargetAuthorPartWorks
	exec spSetSearchStepStarted 28
	insert TargetAuthorPartWorksMs(TargetAuthorPartId, WorkId)
	select TargetAuthorPartId, WorkId
	from ExtraTargetAuthorPartWorks
	exec spSetSearchStepEnded 28

	drop table if exists #ExtraTargetAuthorPartIdsToAdd

-- Коди творів для яких створена інформація для пошуку
	exec spSetSearchStepStarted 29
	insert TargetWorksMs(TargetWorkId, ObjId)
	select t1.TargetWorkId, t1.WorkId 
	from ExtraTargetWorks t1
		left join TargetWorksMs t2 on t1.WorkId = t2.ObjId
	where t2.ObjId is null
	exec spSetSearchStepEnded 29

end

end -- PROCEDURE
GO
