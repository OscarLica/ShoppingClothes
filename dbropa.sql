USE [master]
GO
DROP DATABASE IF EXISTS [TiendaRopa]
GO
/****** Object:  Database [TiendaRopa]    Script Date: 29/09/2021 06:18:07 a. m. ******/
CREATE DATABASE [TiendaRopa]

GO
USE [TiendaRopa]
GO
/****** Object:  Table [dbo].[Cat_Almacen]    Script Date: 29/09/2021 06:18:08 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cat_Almacen](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](75) NULL,
	[Descripcion] [nvarchar](75) NULL,
	[Estado] [nvarchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cat_Categoria]    Script Date: 29/09/2021 06:18:08 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cat_Categoria](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](75) NULL,
	[Estado] [nvarchar](25) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cat_Color]    Script Date: 29/09/2021 06:18:08 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cat_Color](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](75) NULL,
	[Estado] [nvarchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cat_Marca]    Script Date: 29/09/2021 06:18:08 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cat_Marca](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](75) NULL,
	[Estado] [nvarchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cat_Proveedor]    Script Date: 29/09/2021 06:18:08 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cat_Proveedor](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NombreCompañia] [nvarchar](75) NULL,
	[NombreContacto] [nvarchar](75) NULL,
	[CargoContacto] [nvarchar](75) NULL,
	[Direccion] [nvarchar](150) NULL,
	[Telefono] [nvarchar](75) NULL,
	[Email] [nvarchar](75) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cat_SubCategoria]    Script Date: 29/09/2021 06:18:08 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cat_SubCategoria](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdCategoria] [int] NULL,
	[Nombre] [nvarchar](256) NULL,
	[Estado] [nvarchar](25) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cat_Talla]    Script Date: 29/09/2021 06:18:08 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cat_Talla](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](75) NULL,
	[Estado] [nvarchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RegistroPersona]    Script Date: 29/09/2021 06:18:08 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RegistroPersona](
	[IdRegistroPersona] [int] IDENTITY(3,3) NOT NULL,
	[PrimerNombre] [nvarchar](75) NULL,
	[SegundoNombre] [nvarchar](75) NULL,
	[PrimerApellido] [nvarchar](75) NULL,
	[SegundoApellido] [nvarchar](75) NULL,
	[Direccion] [nvarchar](75) NULL,
	[Telefono] [nvarchar](20) NULL,
	[Email] [nvarchar](75) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdRegistroPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 29/09/2021 06:18:08 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[IdRol] [int] IDENTITY(1,3) NOT NULL,
	[Rol] [nvarchar](75) NULL,
	[DescripcionRoles] [nvarchar](75) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RolesUsuario]    Script Date: 29/09/2021 06:18:08 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolesUsuario](
	[IdRolesUsuario] [int] IDENTITY(1,1) NOT NULL,
	[IdRegistroPersona] [int] NOT NULL,
	[IdRol] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdRolesUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SesionUsuarios]    Script Date: 29/09/2021 06:18:08 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SesionUsuarios](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[IdRegistroPersona] [int] NOT NULL,
	[Email] [nvarchar](75) NULL,
	[Contraseña] [nvarchar](75) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Almacen_Producto]    Script Date: 29/09/2021 06:18:08 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Almacen_Producto](
	[IdAlmacenProducto] [int] IDENTITY(1,1) NOT NULL,
	[IdAlmacen] [int] NULL,
	[IdProducto] [int] NULL,
	[IdMarca] [int] NULL,
	[IdTalla] [int] NULL,
	[IdColor] [int] NULL,
	[NombreProducto] [nvarchar](150) NULL,
	[DescripcionArticulo] [nvarchar](150) NULL,
	[PrecioUnitario] [money] NULL,
	[Cantidad] [int] NULL,
	[PrecioVenta] [money] NULL,
	[Unidades] [decimal](18, 9) NULL,
	[UnidadesTotales] [decimal](18, 9) NULL,
	[IdCompra] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdAlmacenProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Compras]    Script Date: 29/09/2021 06:18:08 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Compras](
	[IdCompra] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NULL,
	[IdProveedor] [int] NULL,
	[FechaCompra] [smalldatetime] NULL,
	[NoFactura] [nvarchar](75) NULL,
	[SubTotal] [money] NULL,
	[Descuento] [money] NULL,
	[Iva] [money] NULL,
	[Total] [money] NULL,
	[Estado] [nvarchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCompra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Configuracion]    Script Date: 29/09/2021 06:18:08 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Configuracion](
	[IdConfiguracion] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NULL,
	[LogoEmpresa] [image] NULL,
	[NombreEmpresa] [nvarchar](75) NULL,
	[DireccionEmpresa] [nvarchar](75) NULL,
	[EncabezadoFactura] [nvarchar](75) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdConfiguracion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Detalle_Compra]    Script Date: 29/09/2021 06:18:08 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Detalle_Compra](
	[IdDetalleCompra] [int] IDENTITY(1,1) NOT NULL,
	[IdCompra] [int] NOT NULL,
	[IdProducto] [int] NOT NULL,
	[Producto] [nvarchar](256) NULL,
	[Descripcion] [nvarchar](75) NULL,
	[Cantidad] [int] NULL,
	[PrecioCompra] [money] NULL,
	[SubTotal] [money] NULL,
	[Descuento] [money] NULL,
	[Total] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDetalleCompra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Detalle_Venta]    Script Date: 29/09/2021 06:18:08 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Detalle_Venta](
	[IdDetalleVenta] [int] IDENTITY(1,1) NOT NULL,
	[IdVenta] [int] NULL,
	[IdAlmacenProducto] [int] NULL,
	[Cantidad] [int] NULL,
	[Precio] [money] NULL,
	[SubTotal] [money] NULL,
	[Descuento] [money] NULL,
	[Total] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDetalleVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Devoluciones]    Script Date: 29/09/2021 06:18:08 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Devoluciones](
	[IdProdDev] [int] IDENTITY(1,1) NOT NULL,
	[IdProducto] [int] NULL,
	[IdUsuario] [int] NULL,
	[IdVenta] [int] NULL,
	[FechaDeDevolucion] [smalldatetime] NULL,
	[NoFactura] [nvarchar](75) NULL,
	[Cantidad] [int] NULL,
	[Descripcion] [nvarchar](75) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProdDev] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_MovimientoProductos]    Script Date: 29/09/2021 06:18:08 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_MovimientoProductos](
	[IdMovimientoProducto] [int] IDENTITY(1,1) NOT NULL,
	[IdTipoMovimiento] [int] NOT NULL,
	[IdUsuario] [int] NULL,
	[IdProducto] [int] NULL,
	[FechaDeMovimiento] [smalldatetime] NULL,
	[CodigoArticulo] [nvarchar](75) NULL,
	[Cantidad] [int] NULL,
	[DescripcionMovimientoProducto] [nvarchar](75) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdMovimientoProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Producto]    Script Date: 29/09/2021 06:18:08 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Producto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NombreProducto] [nvarchar](75) NULL,
	[Descripcion] [nvarchar](256) NULL,
	[IdSubCategoria] [int] NULL,
	[Estado] [nvarchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Producto_Dañado]    Script Date: 29/09/2021 06:18:08 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Producto_Dañado](
	[IdProdDañado] [int] IDENTITY(1,1) NOT NULL,
	[IdTipoMovimiento] [int] NOT NULL,
	[IdAlmacenProducto] [int] NULL,
	[NombreProducto] [nvarchar](75) NULL,
	[Cantidad] [int] NULL,
	[Descripcion] [nvarchar](75) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProdDañado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Promocion]    Script Date: 29/09/2021 06:18:08 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Promocion](
	[IdPromocion] [int] IDENTITY(1,1) NOT NULL,
	[NombrePromocion] [nvarchar](75) NULL,
	[Descripcion] [nvarchar](75) NULL,
	[FechaInicio] [smalldatetime] NULL,
	[FechaFin] [smalldatetime] NULL,
	[Descuento] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPromocion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_TipoMovimiento]    Script Date: 29/09/2021 06:18:08 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_TipoMovimiento](
	[IdTipoMovimiento] [int] IDENTITY(1,1) NOT NULL,
	[NombreMovimiento] [nvarchar](75) NULL,
	[Descripcion] [nvarchar](75) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdTipoMovimiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Ventas]    Script Date: 29/09/2021 06:18:08 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Ventas](
	[IdVenta] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NULL,
	[IdPromocion] [int] NULL,
	[NumeroFactura] [nvarchar](75) NULL,
	[NombreCliente] [nvarchar](75) NULL,
	[Fecha] [smalldatetime] NULL,
	[IVA] [money] NULL,
	[SubTotal] [money] NULL,
	[Descuento] [money] NULL,
	[Total] [money] NULL,
	[PagoEfectivo] [money] NULL,
	[Cambio] [money] NULL,
	[Anular] [nvarchar](75) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cat_Almacen] ON 

INSERT [dbo].[Cat_Almacen] ([Id], [Nombre], [Descripcion], [Estado]) VALUES (1, N'Almacen 1', N'Almacen un de productos nuevos', N'true')
SET IDENTITY_INSERT [dbo].[Cat_Almacen] OFF
GO
SET IDENTITY_INSERT [dbo].[Cat_Categoria] ON 

INSERT [dbo].[Cat_Categoria] ([Id], [Nombre], [Estado]) VALUES (1, N'Camisas', N'true')
SET IDENTITY_INSERT [dbo].[Cat_Categoria] OFF
GO
SET IDENTITY_INSERT [dbo].[Cat_Color] ON 

INSERT [dbo].[Cat_Color] ([Id], [Nombre], [Estado]) VALUES (1, N'Verde', N'true')
SET IDENTITY_INSERT [dbo].[Cat_Color] OFF
GO
SET IDENTITY_INSERT [dbo].[Cat_Marca] ON 

INSERT [dbo].[Cat_Marca] ([Id], [Nombre], [Estado]) VALUES (1, N'Fila', N'true')
INSERT [dbo].[Cat_Marca] ([Id], [Nombre], [Estado]) VALUES (2, N'Lacoste', N'true')
INSERT [dbo].[Cat_Marca] ([Id], [Nombre], [Estado]) VALUES (3, N'Adidas', N'true')
SET IDENTITY_INSERT [dbo].[Cat_Marca] OFF
GO
SET IDENTITY_INSERT [dbo].[Cat_Proveedor] ON 

INSERT [dbo].[Cat_Proveedor] ([Id], [NombreCompañia], [NombreContacto], [CargoContacto], [Direccion], [Telefono], [Email]) VALUES (2, N'Adidas Company', N'Juan', N'Vendedor', N'La paz', N'9898965', N'ojimenez@gmail.com')
SET IDENTITY_INSERT [dbo].[Cat_Proveedor] OFF
GO
SET IDENTITY_INSERT [dbo].[Cat_SubCategoria] ON 

INSERT [dbo].[Cat_SubCategoria] ([Id], [IdCategoria], [Nombre], [Estado]) VALUES (1, 1, N'Camisas maga corta', N'true')
SET IDENTITY_INSERT [dbo].[Cat_SubCategoria] OFF
GO
SET IDENTITY_INSERT [dbo].[Cat_Talla] ON 

INSERT [dbo].[Cat_Talla] ([Id], [Nombre], [Estado]) VALUES (3, N'S', N'true')
SET IDENTITY_INSERT [dbo].[Cat_Talla] OFF
GO
SET IDENTITY_INSERT [dbo].[RegistroPersona] ON 

INSERT [dbo].[RegistroPersona] ([IdRegistroPersona], [PrimerNombre], [SegundoNombre], [PrimerApellido], [SegundoApellido], [Direccion], [Telefono], [Email]) VALUES (3, N'Suyen', N'', N'Cortez', N'', N'', N'', N'')
SET IDENTITY_INSERT [dbo].[RegistroPersona] OFF
GO
SET IDENTITY_INSERT [dbo].[SesionUsuarios] ON 

INSERT [dbo].[SesionUsuarios] ([IdUsuario], [IdRegistroPersona], [Email], [Contraseña]) VALUES (1, 3, N'suyen@cortez.com', N'suyen123.')
SET IDENTITY_INSERT [dbo].[SesionUsuarios] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_Almacen_Producto] ON 

INSERT [dbo].[Tbl_Almacen_Producto] ([IdAlmacenProducto], [IdAlmacen], [IdProducto], [IdMarca], [IdTalla], [IdColor], [NombreProducto], [DescripcionArticulo], [PrecioUnitario], [Cantidad], [PrecioVenta], [Unidades], [UnidadesTotales], [IdCompra]) VALUES (4, 1, 1, 1, 3, 1, N'', N'', 10.0000, 10, 100.0000, CAST(10.000000000 AS Decimal(18, 9)), CAST(10.000000000 AS Decimal(18, 9)), 16)
INSERT [dbo].[Tbl_Almacen_Producto] ([IdAlmacenProducto], [IdAlmacen], [IdProducto], [IdMarca], [IdTalla], [IdColor], [NombreProducto], [DescripcionArticulo], [PrecioUnitario], [Cantidad], [PrecioVenta], [Unidades], [UnidadesTotales], [IdCompra]) VALUES (5, 1, 1, 2, 3, 1, N'', N'', 52.0000, 52, 52.0000, CAST(52.000000000 AS Decimal(18, 9)), CAST(52.000000000 AS Decimal(18, 9)), 17)
SET IDENTITY_INSERT [dbo].[Tbl_Almacen_Producto] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_Compras] ON 

INSERT [dbo].[Tbl_Compras] ([IdCompra], [IdUsuario], [IdProveedor], [FechaCompra], [NoFactura], [SubTotal], [Descuento], [Iva], [Total], [Estado]) VALUES (16, 1, 2, CAST(N'2021-09-28T00:00:00' AS SmallDateTime), N'00001', 100.0000, 10.0000, 14.0000, 104.0000, N'')
INSERT [dbo].[Tbl_Compras] ([IdCompra], [IdUsuario], [IdProveedor], [FechaCompra], [NoFactura], [SubTotal], [Descuento], [Iva], [Total], [Estado]) VALUES (17, 1, 2, CAST(N'2021-09-28T00:00:00' AS SmallDateTime), N'00002', 2704.0000, 10.0000, 14.0000, 2812.1600, N'')
INSERT [dbo].[Tbl_Compras] ([IdCompra], [IdUsuario], [IdProveedor], [FechaCompra], [NoFactura], [SubTotal], [Descuento], [Iva], [Total], [Estado]) VALUES (18, 1, 2, CAST(N'2021-09-28T00:00:00' AS SmallDateTime), N'00003', 0.0000, 10.0000, 14.0000, 0.0000, N'')
SET IDENTITY_INSERT [dbo].[Tbl_Compras] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_Detalle_Compra] ON 

INSERT [dbo].[Tbl_Detalle_Compra] ([IdDetalleCompra], [IdCompra], [IdProducto], [Producto], [Descripcion], [Cantidad], [PrecioCompra], [SubTotal], [Descuento], [Total]) VALUES (15, 16, 1, N'', N'', 10, 10.0000, 100.0000, 10.0000, 100.0000)
INSERT [dbo].[Tbl_Detalle_Compra] ([IdDetalleCompra], [IdCompra], [IdProducto], [Producto], [Descripcion], [Cantidad], [PrecioCompra], [SubTotal], [Descuento], [Total]) VALUES (16, 17, 1, N'', N'', 52, 52.0000, 2704.0000, 10.0000, 2704.0000)
SET IDENTITY_INSERT [dbo].[Tbl_Detalle_Compra] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_Producto] ON 

INSERT [dbo].[Tbl_Producto] ([Id], [NombreProducto], [Descripcion], [IdSubCategoria], [Estado]) VALUES (1, N'Camisa manga corta cuello v', N'Camisa manga corta cuello v', 1, N'true')
SET IDENTITY_INSERT [dbo].[Tbl_Producto] OFF
GO
ALTER TABLE [dbo].[Cat_SubCategoria]  WITH CHECK ADD  CONSTRAINT [FK_CatSubCategoria_Cat_Categoria] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Cat_Categoria] ([Id])
GO
ALTER TABLE [dbo].[Cat_SubCategoria] CHECK CONSTRAINT [FK_CatSubCategoria_Cat_Categoria]
GO
ALTER TABLE [dbo].[RolesUsuario]  WITH CHECK ADD  CONSTRAINT [FK_RolesUsuario_Roles] FOREIGN KEY([IdRol])
REFERENCES [dbo].[Roles] ([IdRol])
GO
ALTER TABLE [dbo].[RolesUsuario] CHECK CONSTRAINT [FK_RolesUsuario_Roles]
GO
ALTER TABLE [dbo].[RolesUsuario]  WITH CHECK ADD  CONSTRAINT [FK_RolesUsuarios_RegistroPersona] FOREIGN KEY([IdRegistroPersona])
REFERENCES [dbo].[RegistroPersona] ([IdRegistroPersona])
GO
ALTER TABLE [dbo].[RolesUsuario] CHECK CONSTRAINT [FK_RolesUsuarios_RegistroPersona]
GO
ALTER TABLE [dbo].[SesionUsuarios]  WITH CHECK ADD  CONSTRAINT [FK_SesionUsuarios_RegistroUsuario] FOREIGN KEY([IdRegistroPersona])
REFERENCES [dbo].[RegistroPersona] ([IdRegistroPersona])
GO
ALTER TABLE [dbo].[SesionUsuarios] CHECK CONSTRAINT [FK_SesionUsuarios_RegistroUsuario]
GO
ALTER TABLE [dbo].[Tbl_Almacen_Producto]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Almacen_Producto_Cat_Almacen] FOREIGN KEY([IdAlmacen])
REFERENCES [dbo].[Cat_Almacen] ([Id])
GO
ALTER TABLE [dbo].[Tbl_Almacen_Producto] CHECK CONSTRAINT [FK_Tbl_Almacen_Producto_Cat_Almacen]
GO
ALTER TABLE [dbo].[Tbl_Almacen_Producto]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Almacen_Producto_Cat_Color] FOREIGN KEY([IdColor])
REFERENCES [dbo].[Cat_Color] ([Id])
GO
ALTER TABLE [dbo].[Tbl_Almacen_Producto] CHECK CONSTRAINT [FK_Tbl_Almacen_Producto_Cat_Color]
GO
ALTER TABLE [dbo].[Tbl_Almacen_Producto]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Almacen_Producto_Cat_Marca] FOREIGN KEY([IdMarca])
REFERENCES [dbo].[Cat_Marca] ([Id])
GO
ALTER TABLE [dbo].[Tbl_Almacen_Producto] CHECK CONSTRAINT [FK_Tbl_Almacen_Producto_Cat_Marca]
GO
ALTER TABLE [dbo].[Tbl_Almacen_Producto]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Almacen_Producto_Cat_Talla] FOREIGN KEY([IdTalla])
REFERENCES [dbo].[Cat_Talla] ([Id])
GO
ALTER TABLE [dbo].[Tbl_Almacen_Producto] CHECK CONSTRAINT [FK_Tbl_Almacen_Producto_Cat_Talla]
GO
ALTER TABLE [dbo].[Tbl_Almacen_Producto]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Almacen_Producto_Tbl_Producto] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Tbl_Producto] ([Id])
GO
ALTER TABLE [dbo].[Tbl_Almacen_Producto] CHECK CONSTRAINT [FK_Tbl_Almacen_Producto_Tbl_Producto]
GO
ALTER TABLE [dbo].[Tbl_Compras]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Compras_CatProveedor] FOREIGN KEY([IdProveedor])
REFERENCES [dbo].[Cat_Proveedor] ([Id])
GO
ALTER TABLE [dbo].[Tbl_Compras] CHECK CONSTRAINT [FK_Tbl_Compras_CatProveedor]
GO
ALTER TABLE [dbo].[Tbl_Compras]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Compras_SesionUsuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[SesionUsuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[Tbl_Compras] CHECK CONSTRAINT [FK_Tbl_Compras_SesionUsuarios]
GO
ALTER TABLE [dbo].[Tbl_Configuracion]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Configuracion_SesionUsuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[SesionUsuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[Tbl_Configuracion] CHECK CONSTRAINT [FK_Tbl_Configuracion_SesionUsuarios]
GO
ALTER TABLE [dbo].[Tbl_Detalle_Compra]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Detalle_Compra_Tbl_Compras] FOREIGN KEY([IdCompra])
REFERENCES [dbo].[Tbl_Compras] ([IdCompra])
GO
ALTER TABLE [dbo].[Tbl_Detalle_Compra] CHECK CONSTRAINT [FK_Tbl_Detalle_Compra_Tbl_Compras]
GO
ALTER TABLE [dbo].[Tbl_Detalle_Compra]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Detalle_Compra_Tbl_Producto] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Tbl_Producto] ([Id])
GO
ALTER TABLE [dbo].[Tbl_Detalle_Compra] CHECK CONSTRAINT [FK_Tbl_Detalle_Compra_Tbl_Producto]
GO
ALTER TABLE [dbo].[Tbl_Detalle_Venta]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Detalle_Venta_Tbl_Almacen_Producto] FOREIGN KEY([IdAlmacenProducto])
REFERENCES [dbo].[Tbl_Almacen_Producto] ([IdAlmacenProducto])
GO
ALTER TABLE [dbo].[Tbl_Detalle_Venta] CHECK CONSTRAINT [FK_Tbl_Detalle_Venta_Tbl_Almacen_Producto]
GO
ALTER TABLE [dbo].[Tbl_Detalle_Venta]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Detalle_Venta_Tbl_Ventas] FOREIGN KEY([IdVenta])
REFERENCES [dbo].[Tbl_Ventas] ([IdVenta])
GO
ALTER TABLE [dbo].[Tbl_Detalle_Venta] CHECK CONSTRAINT [FK_Tbl_Detalle_Venta_Tbl_Ventas]
GO
ALTER TABLE [dbo].[Tbl_Devoluciones]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Devoluciones_Tbl_Producto] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Tbl_Producto] ([Id])
GO
ALTER TABLE [dbo].[Tbl_Devoluciones] CHECK CONSTRAINT [FK_Tbl_Devoluciones_Tbl_Producto]
GO
ALTER TABLE [dbo].[Tbl_Devoluciones]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Devoluciones_Tbl_Ventas] FOREIGN KEY([IdVenta])
REFERENCES [dbo].[Tbl_Ventas] ([IdVenta])
GO
ALTER TABLE [dbo].[Tbl_Devoluciones] CHECK CONSTRAINT [FK_Tbl_Devoluciones_Tbl_Ventas]
GO
ALTER TABLE [dbo].[Tbl_MovimientoProductos]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_MovimientoProductos_SesionUsuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[SesionUsuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[Tbl_MovimientoProductos] CHECK CONSTRAINT [FK_Tbl_MovimientoProductos_SesionUsuarios]
GO
ALTER TABLE [dbo].[Tbl_MovimientoProductos]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_MovimientoProductos_Tbl_Producto] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Tbl_Producto] ([Id])
GO
ALTER TABLE [dbo].[Tbl_MovimientoProductos] CHECK CONSTRAINT [FK_Tbl_MovimientoProductos_Tbl_Producto]
GO
ALTER TABLE [dbo].[Tbl_MovimientoProductos]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_MovimientoProductos_Tbl_TipoMovimiento] FOREIGN KEY([IdTipoMovimiento])
REFERENCES [dbo].[Tbl_TipoMovimiento] ([IdTipoMovimiento])
GO
ALTER TABLE [dbo].[Tbl_MovimientoProductos] CHECK CONSTRAINT [FK_Tbl_MovimientoProductos_Tbl_TipoMovimiento]
GO
ALTER TABLE [dbo].[Tbl_Producto]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Producto_Cat_SubCategoria] FOREIGN KEY([IdSubCategoria])
REFERENCES [dbo].[Cat_SubCategoria] ([Id])
GO
ALTER TABLE [dbo].[Tbl_Producto] CHECK CONSTRAINT [FK_Tbl_Producto_Cat_SubCategoria]
GO
ALTER TABLE [dbo].[Tbl_Producto_Dañado]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Producto_Dañado_Tbl_Almacen_Producto] FOREIGN KEY([IdAlmacenProducto])
REFERENCES [dbo].[Tbl_Almacen_Producto] ([IdAlmacenProducto])
GO
ALTER TABLE [dbo].[Tbl_Producto_Dañado] CHECK CONSTRAINT [FK_Tbl_Producto_Dañado_Tbl_Almacen_Producto]
GO
ALTER TABLE [dbo].[Tbl_Producto_Dañado]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Producto_Dañado_Tbl_TipoMovimiento] FOREIGN KEY([IdTipoMovimiento])
REFERENCES [dbo].[Tbl_TipoMovimiento] ([IdTipoMovimiento])
GO
ALTER TABLE [dbo].[Tbl_Producto_Dañado] CHECK CONSTRAINT [FK_Tbl_Producto_Dañado_Tbl_TipoMovimiento]
GO
ALTER TABLE [dbo].[Tbl_Ventas]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Ventas_SesionUsuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[SesionUsuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[Tbl_Ventas] CHECK CONSTRAINT [FK_Tbl_Ventas_SesionUsuarios]
GO
ALTER TABLE [dbo].[Tbl_Ventas]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Ventas_Tbl_Promocion] FOREIGN KEY([IdPromocion])
REFERENCES [dbo].[Tbl_Promocion] ([IdPromocion])
GO
ALTER TABLE [dbo].[Tbl_Ventas] CHECK CONSTRAINT [FK_Tbl_Ventas_Tbl_Promocion]
GO
USE [master]
GO
ALTER DATABASE [TiendaRopa] SET  READ_WRITE 
GO
