USE [TSCI]
GO

/****** Object:  Table [dbo].[TblConfiguraciones]    Script Date: 17/03/2017 09:41:47 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TblConfiguraciones](
	[IdConfiguracion] [int] IDENTITY(1,1) NOT NULL,
	[IdPerfil] [int] NOT NULL,
	[Configuracion] [text] NOT NULL,
 CONSTRAINT [PK_TblConfiguraciones] PRIMARY KEY CLUSTERED 
(
	[IdConfiguracion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[TblConfiguraciones]  WITH CHECK ADD  CONSTRAINT [FK_TblConfiguraciones_TblPerfiles] FOREIGN KEY([IdPerfil])
REFERENCES [dbo].[TblPerfiles] ([IdPerfil])
GO

ALTER TABLE [dbo].[TblConfiguraciones] CHECK CONSTRAINT [FK_TblConfiguraciones_TblPerfiles]
GO


