USE [TSCI]
GO

/****** Object:  Table [dbo].[TblVentas]    Script Date: 16/03/2017 07:33:42 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TblVentas](
	[IdCliente] [int] NOT NULL,
	[IdAuto] [int] NOT NULL,
	[Monto] [varchar](50) NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[TblVentas]  WITH CHECK ADD  CONSTRAINT [FK_TblVentas_TblAutos] FOREIGN KEY([IdAuto])
REFERENCES [dbo].[TblAutos] ([IdAuto])
GO

ALTER TABLE [dbo].[TblVentas] CHECK CONSTRAINT [FK_TblVentas_TblAutos]
GO

ALTER TABLE [dbo].[TblVentas]  WITH CHECK ADD  CONSTRAINT [FK_TblVentas_TblClientes] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[TblClientes] ([IdCliente])
GO

ALTER TABLE [dbo].[TblVentas] CHECK CONSTRAINT [FK_TblVentas_TblClientes]
GO


