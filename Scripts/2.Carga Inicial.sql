USE [BD_Metrica]
GO
SET IDENTITY_INSERT [dbo].[EstadoPago] ON 

GO
INSERT [dbo].[EstadoPago] ([IDEstadoPago], [Nombre]) VALUES (1, N'Pagada')
GO
INSERT [dbo].[EstadoPago] ([IDEstadoPago], [Nombre]) VALUES (2, N'Declinada')
GO
INSERT [dbo].[EstadoPago] ([IDEstadoPago], [Nombre]) VALUES (3, N'Fallida')
GO
INSERT [dbo].[EstadoPago] ([IDEstadoPago], [Nombre]) VALUES (4, N'Anulada')
GO
SET IDENTITY_INSERT [dbo].[EstadoPago] OFF
GO
SET IDENTITY_INSERT [dbo].[Moneda] ON 

GO
INSERT [dbo].[Moneda] ([IDMoneda], [Nombre]) VALUES (1, N'Soles')
GO
INSERT [dbo].[Moneda] ([IDMoneda], [Nombre]) VALUES (2, N'Dolares')
GO
SET IDENTITY_INSERT [dbo].[Moneda] OFF
GO
SET IDENTITY_INSERT [dbo].[Rol] ON 

GO
INSERT [dbo].[Rol] ([IDRol], [Nombre]) VALUES (1, N'Operador1')
GO
INSERT [dbo].[Rol] ([IDRol], [Nombre]) VALUES (2, N'Operador2')
GO
INSERT [dbo].[Rol] ([IDRol], [Nombre]) VALUES (3, N'Administrador')
GO
SET IDENTITY_INSERT [dbo].[Rol] OFF
GO
