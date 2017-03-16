USE [TSCI]
GO

/****** Object:  Table [dbo].[TblAutos]    Script Date: 16/03/2017 07:32:39 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TblAutos](
	[IdAuto] [int] IDENTITY(1,1) NOT NULL,
	[Modelo] [varchar](20) NOT NULL,
	[Marca] [varchar](15) NOT NULL,
	[Anio] [int] NOT NULL,
 CONSTRAINT [PK_TblAutos] PRIMARY KEY CLUSTERED 
(
	[IdAuto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


