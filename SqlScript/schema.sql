/****** Object:  Table [dbo].[Automoveis]    Script Date: 28/07/2015 18:47:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Automoveis](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[modelo] [varchar](255) NOT NULL,
	[preco] [decimal](18, 2) NOT NULL,
	[marca] [int] NOT NULL,
	[ano] [int] NOT NULL,
 CONSTRAINT [PK_Automoveis] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Marcas]    Script Date: 28/07/2015 18:47:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Marcas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nome] [varchar](255) NOT NULL,
 CONSTRAINT [PK_Marcas] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Opcionais]    Script Date: 28/07/2015 18:47:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Opcionais](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descricao] [varchar](255) NOT NULL,
 CONSTRAINT [PK_Opcionais] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OpcionaisRelacao]    Script Date: 28/07/2015 18:47:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OpcionaisRelacao](
	[automovel_id] [int] NOT NULL,
	[opcional_id] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Index [IX_Ano]    Script Date: 28/07/2015 18:47:50 ******/
CREATE NONCLUSTERED INDEX [IX_Ano] ON [dbo].[Automoveis]
(
	[ano] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Marca]    Script Date: 28/07/2015 18:47:50 ******/
CREATE NONCLUSTERED INDEX [IX_Marca] ON [dbo].[Automoveis]
(
	[marca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Modelo]    Script Date: 28/07/2015 18:47:50 ******/
CREATE NONCLUSTERED INDEX [IX_Modelo] ON [dbo].[Automoveis]
(
	[modelo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Automoveis]  WITH CHECK ADD  CONSTRAINT [FK_Automoveis_Marcas] FOREIGN KEY([marca])
REFERENCES [dbo].[Marcas] ([id])
GO
ALTER TABLE [dbo].[Automoveis] CHECK CONSTRAINT [FK_Automoveis_Marcas]
GO
ALTER TABLE [dbo].[OpcionaisRelacao]  WITH CHECK ADD  CONSTRAINT [FK_OpcionaisRelacao_Automoveis] FOREIGN KEY([automovel_id])
REFERENCES [dbo].[Automoveis] ([id])
GO
ALTER TABLE [dbo].[OpcionaisRelacao] CHECK CONSTRAINT [FK_OpcionaisRelacao_Automoveis]
GO
ALTER TABLE [dbo].[OpcionaisRelacao]  WITH CHECK ADD  CONSTRAINT [FK_OpcionaisRelacao_Opcionais] FOREIGN KEY([opcional_id])
REFERENCES [dbo].[Opcionais] ([id])
GO
ALTER TABLE [dbo].[OpcionaisRelacao] CHECK CONSTRAINT [FK_OpcionaisRelacao_Opcionais]
GO
USE [master]
GO
ALTER DATABASE [GerenciadorAutomoveis] SET  READ_WRITE 
GO