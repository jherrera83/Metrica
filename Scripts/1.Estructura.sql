USE [BD_Metrica]
GO
/****** Object:  Table [dbo].[Banco]    Script Date: 23/12/2018 19:55:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Banco](
	[IDBanco] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Direccion] [varchar](200) NULL,
	[FechaRegistro] [datetime] NULL,
	[Estado] [char](1) NOT NULL CONSTRAINT [DF_Banco_Estado]  DEFAULT ('1'),
 CONSTRAINT [PK_Banco] PRIMARY KEY CLUSTERED 
(
	[IDBanco] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EstadoPago]    Script Date: 23/12/2018 19:55:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EstadoPago](
	[IDEstadoPago] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
 CONSTRAINT [PK_EstadoPago] PRIMARY KEY CLUSTERED 
(
	[IDEstadoPago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Moneda]    Script Date: 23/12/2018 19:55:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Moneda](
	[IDMoneda] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
 CONSTRAINT [PK_Moneda] PRIMARY KEY CLUSTERED 
(
	[IDMoneda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OrdenPago]    Script Date: 23/12/2018 19:55:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OrdenPago](
	[IDOrdenPago] [int] IDENTITY(1,1) NOT NULL,
	[IDSucursal] [int] NOT NULL,
	[IDMoneda] [int] NOT NULL,
	[Monto] [decimal](19, 2) NULL,
	[IDEstadoPago] [int] NOT NULL,
	[FechaPago] [datetime] NULL,
	[Estado] [char](1) NOT NULL CONSTRAINT [DF_OrdenPago_Estado]  DEFAULT ('1'),
 CONSTRAINT [PK_OrdenPago] PRIMARY KEY CLUSTERED 
(
	[IDOrdenPago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 23/12/2018 19:55:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Rol](
	[IDRol] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[IDRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Sucursal]    Script Date: 23/12/2018 19:55:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sucursal](
	[IDSucursal] [int] IDENTITY(1,1) NOT NULL,
	[IDBanco] [int] NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Direccion] [varchar](200) NULL,
	[FechaRegistro] [datetime] NULL,
	[Estado] [char](1) NOT NULL CONSTRAINT [DF_Sucursal_Estado]  DEFAULT ('1'),
 CONSTRAINT [PK_Sucursal] PRIMARY KEY CLUSTERED 
(
	[IDSucursal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[OrdenPago]  WITH CHECK ADD  CONSTRAINT [FK_OrdenPago_EstadoPago] FOREIGN KEY([IDEstadoPago])
REFERENCES [dbo].[EstadoPago] ([IDEstadoPago])
GO
ALTER TABLE [dbo].[OrdenPago] CHECK CONSTRAINT [FK_OrdenPago_EstadoPago]
GO
ALTER TABLE [dbo].[OrdenPago]  WITH CHECK ADD  CONSTRAINT [FK_OrdenPago_Moneda] FOREIGN KEY([IDMoneda])
REFERENCES [dbo].[Moneda] ([IDMoneda])
GO
ALTER TABLE [dbo].[OrdenPago] CHECK CONSTRAINT [FK_OrdenPago_Moneda]
GO
ALTER TABLE [dbo].[OrdenPago]  WITH CHECK ADD  CONSTRAINT [FK_OrdenPago_Sucursal] FOREIGN KEY([IDSucursal])
REFERENCES [dbo].[Sucursal] ([IDSucursal])
GO
ALTER TABLE [dbo].[OrdenPago] CHECK CONSTRAINT [FK_OrdenPago_Sucursal]
GO
ALTER TABLE [dbo].[Sucursal]  WITH CHECK ADD  CONSTRAINT [FK_Sucursal_Banco] FOREIGN KEY([IDBanco])
REFERENCES [dbo].[Banco] ([IDBanco])
GO
ALTER TABLE [dbo].[Sucursal] CHECK CONSTRAINT [FK_Sucursal_Banco]
GO
/****** Object:  StoredProcedure [dbo].[Banco_Actualizar]    Script Date: 23/12/2018 19:55:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Banco_Actualizar]
(
	@IdBanco int,
	@Nombre varchar(50),
	@Direccion varchar(200)
)
AS
BEGIN
	UPDATE [dbo].[Banco]
   SET [Nombre] = @Nombre
      ,[Direccion] = @Direccion
      ,[FechaRegistro] = GETDATE()
 WHERE IDBanco = @IdBanco
END
GO
/****** Object:  StoredProcedure [dbo].[Banco_Eliminar]    Script Date: 23/12/2018 19:55:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Banco_Eliminar]
(
	@IdBanco int
)
AS
BEGIN

-- ELIMINA BANCO
   UPDATE [dbo].[Banco]
   SET Estado = '0'  
   WHERE IDBanco = @IdBanco

-- ELIMINA SUCURSALES
   UPDATE dbo.Sucursal
   SET Estado = '0'		
   WHERE IDBanco = @IdBanco

-- ELIMINA ORDENES DE PAGO
	UPDATE op
	set op.Estado = '0'		
	FROM dbo.OrdenPago op	
	INNER JOIN dbo.Sucursal s
		ON s.IDSucursal = op.IDSucursal
	WHERE s.IDBanco = @IdBanco
	
END
GO
/****** Object:  StoredProcedure [dbo].[Banco_Insertar]    Script Date: 23/12/2018 19:55:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Banco_Insertar]
(
	@Nombre varchar(50),
	@Direccion varchar(200)
)
AS
BEGIN
	INSERT INTO [dbo].[Banco]
           ([Nombre]
           ,[Direccion]
           ,[FechaRegistro])
     VALUES
           (@Nombre
           ,@Direccion
           ,GETDATE())
END
GO
/****** Object:  StoredProcedure [dbo].[Banco_Listar]    Script Date: 23/12/2018 19:55:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Banco_Listar]
AS
BEGIN
	SELECT IdBanco,
			Nombre,
			Direccion			
	FROM dbo.Banco
	WHERE Estado = '1'
END
GO
/****** Object:  StoredProcedure [dbo].[Banco_Obtener]    Script Date: 23/12/2018 19:55:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Banco_Obtener]
(
	@IdBanco int
)
AS
BEGIN
	SELECT IdBanco,
			Nombre,
			Direccion			
	FROM dbo.Banco
	WHERE IDBanco = @IdBanco
END
GO
/****** Object:  StoredProcedure [dbo].[EstadoPago_Listar]    Script Date: 23/12/2018 19:55:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EstadoPago_Listar]
AS
BEGIN
	SELECT IdEstadoPago,
			Nombre
	FROM dbo.EstadoPago
END
GO
/****** Object:  StoredProcedure [dbo].[Moneda_Listar]    Script Date: 23/12/2018 19:55:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Moneda_Listar]
AS
SELECT [IDMoneda]
      ,[Nombre]
  FROM [dbo].[Moneda]

GO
/****** Object:  StoredProcedure [dbo].[OrdenesPago_PorSucursalMoneda]    Script Date: 23/12/2018 19:55:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[OrdenesPago_PorSucursalMoneda]
(
	@IdSucursal int,
	@IdMoneda int
)
AS
BEGIN
SELECT op.[IDOrdenPago]
      ,op.[IDSucursal]
      ,op.[IDMoneda]
      ,op.[Monto]
      ,op.[IDEstadoPago]
      ,op.[FechaPago]
	  ,mon.Nombre as NombreMoneda
	  ,ep.Nombre as NombreEstadoPago
	  ,b.Nombre as NombreBanco
	  ,su.Nombre as NombreSucursal
  FROM [dbo].[OrdenPago] op
  INNER JOIN dbo.Sucursal su
	ON su.IDSucursal = op.IDSucursal
  INNER JOIN dbo.Banco b
	ON b.IDBanco = su.IDBanco
  INNER JOIN dbo.Moneda mon 
	ON mon.IDMoneda = op.IDMoneda
  INNER JOIN dbo.EstadoPago ep
	ON ep.IDEstadoPago = op.IDEstadoPago
	WHERE op.IDSucursal = @IdSucursal
	AND op.IDMoneda = @IdMoneda
END
GO
/****** Object:  StoredProcedure [dbo].[OrdenPago_Actualizar]    Script Date: 23/12/2018 19:55:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[OrdenPago_Actualizar]
(
	@IdOrdenPago int,
	@IdSucursal int,
	@IdMoneda int,
	@Monto decimal(19,2),
	@IdEstadoPago int	
)
AS
BEGIN
UPDATE [dbo].[OrdenPago]
SET [IDSucursal] = @IdSucursal,
	IDMoneda = @IdMoneda,
	IDEstadoPago = @IdEstadoPago,
	Monto = @Monto,
	FechaPago = GETDATE()
WHERE IDOrdenPago = @IdOrdenPago
END
GO
/****** Object:  StoredProcedure [dbo].[OrdenPago_Eliminar]    Script Date: 23/12/2018 19:55:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[OrdenPago_Eliminar]
(
	@IdOrdenPago int
)
AS
BEGIN
UPDATE [dbo].[OrdenPago]
SET Estado = '0',
	FechaPago = GETDATE()
WHERE IDOrdenPago = @IdOrdenPago
END
GO
/****** Object:  StoredProcedure [dbo].[OrdenPago_Insertar]    Script Date: 23/12/2018 19:55:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[OrdenPago_Insertar]
(
	@IdSucursal int,
	@IdMoneda int,
	@Monto decimal(19,2),
	@IdEstadoPago int	
)
AS
BEGIN
INSERT INTO [dbo].[OrdenPago]
           ([IDSucursal]
           ,[IDMoneda]
           ,[Monto]
           ,[IDEstadoPago]
           ,[FechaPago])
     VALUES
           (@IdSucursal,
            @IdMoneda,
            @Monto,
            @IdEstadoPago,
			GETDATE()
            )
END
GO
/****** Object:  StoredProcedure [dbo].[OrdenPago_Listar]    Script Date: 23/12/2018 19:55:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[OrdenPago_Listar]
AS
BEGIN
SELECT op.[IDOrdenPago]
      ,op.[IDSucursal]
      ,op.[IDMoneda]
      ,op.[Monto]
      ,op.[IDEstadoPago]
      ,op.[FechaPago]
	  ,mon.Nombre as NombreMoneda
	  ,ep.Nombre as NombreEstadoPago
	  ,b.Nombre as NombreBanco
	  ,su.Nombre as NombreSucursal
  FROM [dbo].[OrdenPago] op
  INNER JOIN dbo.Sucursal su
	ON su.IDSucursal = op.IDSucursal
  INNER JOIN dbo.Banco b
	ON b.IDBanco = su.IDBanco
  INNER JOIN dbo.Moneda mon 
	ON mon.IDMoneda = op.IDMoneda
  INNER JOIN dbo.EstadoPago ep
	ON ep.IDEstadoPago = op.IDEstadoPago
  WHERE op.Estado = '1'
END
GO
/****** Object:  StoredProcedure [dbo].[OrdenPago_Obtener]    Script Date: 23/12/2018 19:55:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[OrdenPago_Obtener]
(
	@IdOrdenPago int
)
AS
BEGIN
SELECT op.[IDOrdenPago]	
      ,op.[IDSucursal]
      ,op.[IDMoneda]
      ,op.[Monto]
      ,op.[IDEstadoPago]
      ,op.[FechaPago]
	  ,b.IDBanco
	  ,mon.Nombre as NombreMoneda
	  ,ep.Nombre as NombreEstadoPago
	  ,b.Nombre as NombreBanco
	  ,su.Nombre as NombreSucursal
  FROM [dbo].[OrdenPago] op
  INNER JOIN dbo.Sucursal su
	ON su.IDSucursal = op.IDSucursal
  INNER JOIN dbo.Banco b
	ON b.IDBanco = su.IDBanco 
  INNER JOIN dbo.Moneda mon 
	ON mon.IDMoneda = op.IDMoneda
  INNER JOIN dbo.EstadoPago ep
	ON ep.IDEstadoPago = op.IDEstadoPago
  WHERE op.IDOrdenPago = @IdOrdenPago
END
GO
/****** Object:  StoredProcedure [dbo].[Rol_Listar]    Script Date: 23/12/2018 19:55:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Rol_Listar]
AS
BEGIN
	SELECT IdRol,
			Nombre
	FROM dbo.Rol
END
GO
/****** Object:  StoredProcedure [dbo].[Sucursal_Actualizar]    Script Date: 23/12/2018 19:55:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sucursal_Actualizar]
(
	@IdSucursal int,
	@IdBanco int,
	@Nombre varchar(50),
	@Direccion varchar(200)
)
AS
BEGIN
UPDATE [dbo].[Sucursal]
SET [IDBanco] = @IdBanco,
	Nombre = @Nombre,
	Direccion = @Direccion,
	FechaRegistro = GETDATE()
WHERE IDSucursal = @IdSucursal
END
GO
/****** Object:  StoredProcedure [dbo].[Sucursal_Eliminar]    Script Date: 23/12/2018 19:55:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sucursal_Eliminar]
(
	@IdSucursal int
)
AS
BEGIN
-- ELIMINA SUCURSAL
UPDATE [dbo].[Sucursal]
SET Estado = '0'
WHERE IDSucursal = @IdSucursal

-- ELIMINA ORDENES DE PAGO
UPDATE dbo.OrdenPago
SET Estado = '0'
WHERE IDSucursal = @IdSucursal

END
GO
/****** Object:  StoredProcedure [dbo].[Sucursal_Insertar]    Script Date: 23/12/2018 19:55:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sucursal_Insertar]
(
	@IdBanco int,
	@Nombre varchar(50),
	@Direccion varchar(200)
)
AS
BEGIN
INSERT INTO [dbo].[Sucursal]
           ([IDBanco]
           ,[Nombre]
           ,[Direccion]
           ,[FechaRegistro])
     VALUES
           (
		   @IdBanco,
		   @Nombre,
		   @Direccion,
		   GETDATE()
		   )
END
GO
/****** Object:  StoredProcedure [dbo].[Sucursal_Listar]    Script Date: 23/12/2018 19:55:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sucursal_Listar]
AS
BEGIN
SELECT s.[IDSucursal]
      ,s.[IDBanco]
      ,s.[Nombre]
      ,s.[Direccion]
	  ,b.Nombre as NombreBanco
  FROM [dbo].[Sucursal] s
  INNER JOIN dbo.Banco b
	ON b.IDBanco = s.IDBanco
  WHERE s.Estado = '1'
END
GO
/****** Object:  StoredProcedure [dbo].[Sucursal_Obtener]    Script Date: 23/12/2018 19:55:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sucursal_Obtener]
(
	@IdSucursal int
)
AS
BEGIN
SELECT s.[IDSucursal]
      ,s.[IDBanco]
      ,s.[Nombre]
      ,s.[Direccion]      
	  ,b.Nombre as NombreBanco
  FROM [dbo].[Sucursal] s
  INNER JOIN dbo.Banco b
	ON b.IDBanco = s.IDBanco
  WHERE s.IDSucursal = @IdSucursal
END
GO
/****** Object:  StoredProcedure [dbo].[Sucursales_PorBanco]    Script Date: 23/12/2018 19:55:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Sucursales_PorBanco]
(
	@IdBanco int
)
AS
BEGIN
SELECT s.[IDSucursal]
      ,s.[IDBanco]
      ,s.[Nombre]
      ,s.[Direccion]
      ,s.[FechaRegistro]
	  ,b.Nombre as NombreBanco
  FROM [dbo].[Sucursal] s
  INNER JOIN dbo.Banco b
	ON b.IDBanco = s.IDBanco
   WHERE s.IDBanco = @IdBanco
   AND s.Estado = '1'
END
GO
