USE [GerenciadorAutomoveis]
GO
SET IDENTITY_INSERT [dbo].[Marcas] ON 

INSERT [dbo].[Marcas] ([id], [nome]) VALUES (1, N'Chevrolet')
INSERT [dbo].[Marcas] ([id], [nome]) VALUES (2, N'Fiat')
INSERT [dbo].[Marcas] ([id], [nome]) VALUES (3, N'Volkswagen')
INSERT [dbo].[Marcas] ([id], [nome]) VALUES (4, N'Jeep')
INSERT [dbo].[Marcas] ([id], [nome]) VALUES (5, N'Renault')
SET IDENTITY_INSERT [dbo].[Marcas] OFF
SET IDENTITY_INSERT [dbo].[Automoveis] ON 

INSERT [dbo].[Automoveis] ([id], [modelo], [preco], [marca], [ano]) VALUES (1, N'Gol', CAST(31200.00 AS Decimal(18, 2)), 3, 2011)
INSERT [dbo].[Automoveis] ([id], [modelo], [preco], [marca], [ano]) VALUES (4, N'Uno123', CAST(26212.21 AS Decimal(18, 2)), 1, 1998)
INSERT [dbo].[Automoveis] ([id], [modelo], [preco], [marca], [ano]) VALUES (5, N'Vectra', CAST(32000.00 AS Decimal(18, 2)), 1, 2009)
INSERT [dbo].[Automoveis] ([id], [modelo], [preco], [marca], [ano]) VALUES (15, N'Astra', CAST(24000.00 AS Decimal(18, 2)), 1, 2006)
INSERT [dbo].[Automoveis] ([id], [modelo], [preco], [marca], [ano]) VALUES (17, N'Corola1', CAST(750123.00 AS Decimal(18, 2)), 1, 2000)
SET IDENTITY_INSERT [dbo].[Automoveis] OFF
SET IDENTITY_INSERT [dbo].[Opcionais] ON 

INSERT [dbo].[Opcionais] ([id], [descricao]) VALUES (1, N'Ar condicionado')
INSERT [dbo].[Opcionais] ([id], [descricao]) VALUES (2, N'Direção hidraulica')
INSERT [dbo].[Opcionais] ([id], [descricao]) VALUES (3, N'Vidro elétrico')
INSERT [dbo].[Opcionais] ([id], [descricao]) VALUES (4, N'Trava elétrica')
INSERT [dbo].[Opcionais] ([id], [descricao]) VALUES (5, N'Bancos de couro')
SET IDENTITY_INSERT [dbo].[Opcionais] OFF
INSERT [dbo].[OpcionaisRelacao] ([automovel_id], [opcional_id]) VALUES (17, 1)
INSERT [dbo].[OpcionaisRelacao] ([automovel_id], [opcional_id]) VALUES (4, 1)
INSERT [dbo].[OpcionaisRelacao] ([automovel_id], [opcional_id]) VALUES (4, 3)
INSERT [dbo].[OpcionaisRelacao] ([automovel_id], [opcional_id]) VALUES (4, 4)
INSERT [dbo].[OpcionaisRelacao] ([automovel_id], [opcional_id]) VALUES (1, 1)
