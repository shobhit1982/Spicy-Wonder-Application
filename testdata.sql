USE [Spicy2021]
GO
/****** Object:  StoredProcedure [dbo].[P_GetUserRights]    Script Date: 4/4/2021 5:40:12 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_GetUserRights]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_GetUserRights]
GO
/****** Object:  StoredProcedure [dbo].[GetDataForSalesReport]    Script Date: 4/4/2021 5:40:12 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetDataForSalesReport]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetDataForSalesReport]
GO
/****** Object:  StoredProcedure [dbo].[GetDataForPrintInvoice_27_06_17]    Script Date: 4/4/2021 5:40:12 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetDataForPrintInvoice_27_06_17]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetDataForPrintInvoice_27_06_17]
GO
/****** Object:  StoredProcedure [dbo].[GetDataForPrintInvoice_240617]    Script Date: 4/4/2021 5:40:12 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetDataForPrintInvoice_240617]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetDataForPrintInvoice_240617]
GO
/****** Object:  StoredProcedure [dbo].[GetDataForPrintInvoice]    Script Date: 4/4/2021 5:40:12 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetDataForPrintInvoice]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetDataForPrintInvoice]
GO
/****** Object:  View [dbo].[CompanyInfo]    Script Date: 4/4/2021 5:40:12 PM ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[CompanyInfo]'))
DROP VIEW [dbo].[CompanyInfo]
GO
/****** Object:  Table [dbo].[UserTypes]    Script Date: 4/4/2021 5:40:12 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserTypes]') AND type in (N'U'))
DROP TABLE [dbo].[UserTypes]
GO
/****** Object:  Table [dbo].[UserTable]    Script Date: 4/4/2021 5:40:12 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserTable]') AND type in (N'U'))
DROP TABLE [dbo].[UserTable]
GO
/****** Object:  Table [dbo].[UserRights]    Script Date: 4/4/2021 5:40:12 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserRights]') AND type in (N'U'))
DROP TABLE [dbo].[UserRights]
GO
/****** Object:  Table [dbo].[Unit]    Script Date: 4/4/2021 5:40:12 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Unit]') AND type in (N'U'))
DROP TABLE [dbo].[Unit]
GO
/****** Object:  Table [dbo].[Taxes]    Script Date: 4/4/2021 5:40:12 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Taxes]') AND type in (N'U'))
DROP TABLE [dbo].[Taxes]
GO
/****** Object:  Table [dbo].[TaxAppliedOnItem]    Script Date: 4/4/2021 5:40:12 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TaxAppliedOnItem]') AND type in (N'U'))
DROP TABLE [dbo].[TaxAppliedOnItem]
GO
/****** Object:  Table [dbo].[SalesTaxDetails]    Script Date: 4/4/2021 5:40:12 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SalesTaxDetails]') AND type in (N'U'))
DROP TABLE [dbo].[SalesTaxDetails]
GO
/****** Object:  Table [dbo].[SalesMaster]    Script Date: 4/4/2021 5:40:12 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SalesMaster]') AND type in (N'U'))
DROP TABLE [dbo].[SalesMaster]
GO
/****** Object:  Table [dbo].[SalesDetails]    Script Date: 4/4/2021 5:40:12 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SalesDetails]') AND type in (N'U'))
DROP TABLE [dbo].[SalesDetails]
GO
/****** Object:  Table [dbo].[OrderType]    Script Date: 4/4/2021 5:40:12 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrderType]') AND type in (N'U'))
DROP TABLE [dbo].[OrderType]
GO
/****** Object:  Table [dbo].[MenuAndSubMenu]    Script Date: 4/4/2021 5:40:12 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MenuAndSubMenu]') AND type in (N'U'))
DROP TABLE [dbo].[MenuAndSubMenu]
GO
/****** Object:  Table [dbo].[Location]    Script Date: 4/4/2021 5:40:12 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Location]') AND type in (N'U'))
DROP TABLE [dbo].[Location]
GO
/****** Object:  Table [dbo].[ItemSeries]    Script Date: 4/4/2021 5:40:12 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ItemSeries]') AND type in (N'U'))
DROP TABLE [dbo].[ItemSeries]
GO
/****** Object:  Table [dbo].[ItemMaster]    Script Date: 4/4/2021 5:40:12 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ItemMaster]') AND type in (N'U'))
DROP TABLE [dbo].[ItemMaster]
GO
/****** Object:  Table [dbo].[ItemCategory]    Script Date: 4/4/2021 5:40:12 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ItemCategory]') AND type in (N'U'))
DROP TABLE [dbo].[ItemCategory]
GO
/****** Object:  Table [dbo].[Discount]    Script Date: 4/4/2021 5:40:12 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Discount]') AND type in (N'U'))
DROP TABLE [dbo].[Discount]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 4/4/2021 5:40:12 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customer]') AND type in (N'U'))
DROP TABLE [dbo].[Customer]
GO
/****** Object:  Table [dbo].[Config]    Script Date: 4/4/2021 5:40:12 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Config]') AND type in (N'U'))
DROP TABLE [dbo].[Config]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 4/4/2021 5:40:12 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Clients]') AND type in (N'U'))
DROP TABLE [dbo].[Clients]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 4/4/2021 5:40:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Clients]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Clients](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](max) NULL,
	[MachineName] [varchar](max) NULL,
	[StartDate] [varchar](max) NULL,
	[ValidUpTo] [varchar](max) NULL,
	[ActivationKey] [varchar](max) NULL,
	[IsActive] [bit] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Config]    Script Date: 4/4/2021 5:40:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Config]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Config](
	[CName] [varchar](500) NULL,
	[CAddress] [varchar](500) NULL,
	[CAddress1] [varchar](500) NULL,
	[Phone] [varchar](50) NULL,
	[Phone1] [varchar](50) NULL,
	[TaxNo] [varchar](200) NULL,
	[Panno] [varchar](50) NULL
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 4/4/2021 5:40:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customer]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Customer](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[SalesMasterId] [bigint] NULL,
	[CustName] [varchar](max) NULL,
	[Mobile] [varchar](max) NULL,
	[Email] [varchar](max) NULL,
	[Address] [varchar](max) NULL,
	[Remarks] [varchar](max) NULL,
	[IsValid] [bit] NOT NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Discount]    Script Date: 4/4/2021 5:40:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Discount]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Discount](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Discount] [bigint] NOT NULL,
	[Description] [varchar](max) NULL,
	[Remarks] [varchar](max) NULL,
	[IsValid] [bit] NOT NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ItemCategory]    Script Date: 4/4/2021 5:40:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ItemCategory]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ItemCategory](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](max) NULL,
	[Description] [varchar](max) NULL,
	[Remarks] [varchar](max) NULL,
	[IsValid] [bit] NOT NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ItemMaster]    Script Date: 4/4/2021 5:40:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ItemMaster]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ItemMaster](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](max) NULL,
	[Description] [varchar](max) NULL,
	[ItemSeriesId] [bigint] NULL,
	[Price] [decimal](18, 2) NULL,
	[IsTaxable] [bit] NOT NULL,
	[UnitId] [bigint] NULL,
	[IsKot] [bit] NOT NULL,
	[Remarks] [varchar](max) NULL,
	[IsValid] [bit] NOT NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ItemSeries]    Script Date: 4/4/2021 5:40:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ItemSeries]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ItemSeries](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](max) NULL,
	[Description] [varchar](max) NULL,
	[Remarks] [varchar](max) NULL,
	[IsValid] [bit] NOT NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Location]    Script Date: 4/4/2021 5:40:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Location]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Location](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[Seats] [bigint] NULL,
	[Remarks] [nvarchar](255) NULL,
	[IsValid] [bit] NOT NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[MenuAndSubMenu]    Script Date: 4/4/2021 5:40:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MenuAndSubMenu]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[MenuAndSubMenu](
	[ID] [bigint] NOT NULL,
	[ParentId] [bigint] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Remarks] [nvarchar](max) NULL,
	[IsValid] [bit] NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[OrderType]    Script Date: 4/4/2021 5:40:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrderType]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[OrderType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderType] [varchar](150) NULL,
	[IsDefault] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SalesDetails]    Script Date: 4/4/2021 5:40:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SalesDetails]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SalesDetails](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[SaleMasterId] [bigint] NULL,
	[BillNumber] [bigint] NOT NULL,
	[ItemId] [bigint] NULL,
	[Qty] [bigint] NULL,
	[Amount] [decimal](18, 2) NULL,
	[Taxes] [decimal](18, 2) NULL,
	[ItemPrice] [decimal](18, 2) NULL,
	[GridSNo] [bigint] NULL,
	[Description] [varchar](max) NULL,
	[Remarks] [varchar](max) NULL,
	[IsValid] [bit] NOT NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SalesMaster]    Script Date: 4/4/2021 5:40:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SalesMaster]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SalesMaster](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[BillNumber] [bigint] NOT NULL,
	[TableNumber] [varchar](max) NULL,
	[CustomerId] [bigint] NULL,
	[Amount] [decimal](18, 2) NULL,
	[Taxes] [decimal](18, 2) NULL,
	[RoundAmount] [decimal](18, 2) NULL,
	[TotalAmount] [decimal](18, 2) NULL,
	[Difference] [decimal](18, 2) NULL,
	[Discount] [decimal](18, 2) NULL,
	[Status] [bigint] NULL,
	[Remarks] [varchar](max) NULL,
	[IsValid] [bit] NOT NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[PaymentMode] [varchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SalesTaxDetails]    Script Date: 4/4/2021 5:40:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SalesTaxDetails]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SalesTaxDetails](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[SalesDetailsId] [bigint] NULL,
	[TaxId] [bigint] NULL,
	[TaxName] [varchar](max) NULL,
	[TaxRate] [decimal](18, 2) NULL,
	[Amount] [decimal](18, 2) NULL,
	[Description] [varchar](max) NULL,
	[Remarks] [varchar](max) NULL,
	[IsValid] [bit] NOT NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TaxAppliedOnItem]    Script Date: 4/4/2021 5:40:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TaxAppliedOnItem]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TaxAppliedOnItem](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ItemMasterId] [bigint] NULL,
	[TaxId] [bigint] NULL,
	[Description] [varchar](max) NULL,
	[Remarks] [varchar](max) NULL,
	[IsValid] [bit] NOT NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Taxes]    Script Date: 4/4/2021 5:40:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Taxes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Taxes](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](max) NULL,
	[Rate] [decimal](18, 2) NULL,
	[Description] [varchar](max) NULL,
	[Remarks] [varchar](max) NULL,
	[IsValid] [bit] NOT NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Unit]    Script Date: 4/4/2021 5:40:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Unit]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Unit](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](max) NULL,
	[Description] [varchar](max) NULL,
	[Remarks] [varchar](max) NULL,
	[IsValid] [bit] NOT NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserRights]    Script Date: 4/4/2021 5:40:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserRights]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[UserRights](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserTypeId] [bigint] NOT NULL,
	[MenuId] [bigint] NOT NULL,
	[MenuParentId] [bigint] NOT NULL,
	[Remarks] [varchar](max) NULL,
	[IsValid] [bit] NOT NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserTable]    Script Date: 4/4/2021 5:40:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserTable]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[UserTable](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[LoginId] [varchar](max) NOT NULL,
	[Password] [varchar](max) NOT NULL,
	[Name] [varchar](max) NULL,
	[Email] [varchar](max) NULL,
	[Mobile] [varchar](max) NULL,
	[UserType] [bigint] NULL,
	[UserTypeName] [varchar](max) NULL,
	[Address] [varchar](max) NULL,
	[Remarks] [varchar](max) NULL,
	[IsValid] [bit] NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserTypes]    Script Date: 4/4/2021 5:40:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserTypes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[UserTypes](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Remarks] [nvarchar](max) NULL,
	[IsValid] [bit] NOT NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  View [dbo].[CompanyInfo]    Script Date: 4/4/2021 5:40:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[CompanyInfo]'))
EXEC dbo.sp_executesql @statement = N'create view [dbo].[CompanyInfo] as 
Select * from config
' 
GO
INSERT [dbo].[Config] ([CName], [CAddress], [CAddress1], [Phone], [Phone1], [TaxNo], [Panno]) VALUES (N'M/S Spicy Wonder', N'B-8 Bypass Rd, Kamla Nagar', N'  dsd', N'Ph :- 0562-3561317', N'sds', N'GSTN:', N'PAN No :- AEKFS0215D')
GO
SET IDENTITY_INSERT [dbo].[Discount] ON 

GO
INSERT [dbo].[Discount] ([ID], [Discount], [Description], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (5, 10, N'10% discount', N'', 1, 4, CAST(N'2016-12-27 21:51:55.000' AS DateTime), 4, CAST(N'2017-09-09 10:28:46.000' AS DateTime))
GO
INSERT [dbo].[Discount] ([ID], [Discount], [Description], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (6, 5, N'discount', N'', 1, 4, CAST(N'2016-12-27 21:52:03.000' AS DateTime), 4, CAST(N'2017-09-09 10:28:57.000' AS DateTime))
GO
INSERT [dbo].[Discount] ([ID], [Discount], [Description], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (7, 20, N'20% discount', N'', 0, 4, CAST(N'2016-12-27 21:52:12.000' AS DateTime), 4, CAST(N'2016-12-27 21:52:12.000' AS DateTime))
GO
INSERT [dbo].[Discount] ([ID], [Discount], [Description], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (8, 50, N'', N'', 0, 3, CAST(N'2017-01-03 14:19:38.000' AS DateTime), 3, CAST(N'2017-01-03 14:19:38.000' AS DateTime))
GO
INSERT [dbo].[Discount] ([ID], [Discount], [Description], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (9, 0, N'', N'', 1, 3, CAST(N'2017-03-26 14:46:34.000' AS DateTime), 3, CAST(N'2017-06-29 08:35:01.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Discount] OFF
GO
SET IDENTITY_INSERT [dbo].[ItemMaster] ON 

GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (1, N'PLAIN BUTTER DOSA', N'PLAIN BUTTER DOSA', 100, CAST(130.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (2, N'BUTTER MASALA DOSA', N'BUTTER MASALA DOSA', 101, CAST(140.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (3, N'BUTTER ONION MASALA DOSA', N'BUTTER ONION MASALA DOSA', 102, CAST(155.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (4, N'ONION PANEER BUTTER MASALA DOSA', N'ONION PANEER BUTTER MASALA DOSA', 103, CAST(155.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (5, N'MYSORE PLAIN BUTTER DOSA', N'MYSORE PLAIN BUTTER DOSA', 104, CAST(155.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (6, N'MYSORE BUTTER MASALA DOSA', N'MYSORE BUTTER MASALA DOSA', 105, CAST(155.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (7, N'MYSORE PANEER BUTTER MASALA DOSA', N'MYSORE PANEER BUTTER MASALA DOSA', 106, CAST(155.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (8, N'PANEER PLAIN BUTTER DOSA', N'PANEER PLAIN BUTTER DOSA', 107, CAST(155.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (9, N'PANEER BUTTER MASALA DOSA', N'PANEER BUTTER MASALA DOSA', 108, CAST(155.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (10, N'PAPER PLAIN BUTTER DOSA', N'PAPER PLAIN BUTTER DOSA', 109, CAST(155.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (11, N'PAPER BUTTER MASALA DOSA', N'PAPER BUTTER MASALA DOSA', 110, CAST(155.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (12, N'PAPER BUTTER PANEER DOSA', N'PAPER BUTTER PANEER DOSA', 111, CAST(155.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (13, N'RAVA PLAIN BUTTER DOSA', N'RAVA PLAIN BUTTER DOSA', 112, CAST(175.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (14, N'ONION RAVA DOSA', N'ONION RAVA DOSA', 113, CAST(175.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (15, N'RAVA BUTTER MASALA DOSA', N'RAVA BUTTER MASALA DOSA', 114, CAST(175.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (16, N'RAVA PANEER BUTTER MASALA DOSA', N'RAVA PANEER BUTTER MASALA DOSA', 115, CAST(175.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (17, N'SPRING DOSA', N'SPRING DOSA', 116, CAST(185.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (18, N'ONION UTTAPAM', N'ONION UTTAPAM', 117, CAST(150.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (19, N'TOMATO UTTAPAM', N'TOMATO UTTAPAM', 118, CAST(150.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (20, N'CAPSICUM UTTAPAM', N'CAPSICUM UTTAPAM', 119, CAST(150.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (21, N'CHEESY MIX UTTAPAM', N'CHEESY MIX UTTAPAM', 120, CAST(175.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (22, N'MIX UTTAPAM', N'MIX UTTAPAM', 121, CAST(175.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (23, N'NAVRATAN KORMA', N'NAVRATAN KORMA', 200, CAST(275.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (24, N'MALAI KOFTA', N'MALAI KOFTA', 201, CAST(250.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (25, N'SHAHI PANEER', N'SHAHI PANEER', 202, CAST(250.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (26, N'PANEER BUTTER MASALA', N'PANEER BUTTER MASALA', 203, CAST(225.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (27, N'MATAR PANEER', N'MATAR PANEER', 204, CAST(225.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (28, N'PANEER MAKHNI', N'PANEER MAKHNI', 205, CAST(245.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (29, N'PANEER TIKKA MASALA', N'PANEER TIKKA MASALA', 206, CAST(275.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (30, N'KADAHI PANEER ', N'KADAHI PANEER ', 207, CAST(255.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (31, N'MATAR MUSHROOM', N'MATAR MUSHROOM', 208, CAST(255.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (32, N'KHOYA MATAR', N'KHOYA MATAR', 209, CAST(265.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (33, N'KHOYA PANEER', N'KHOYA PANEER', 210, CAST(265.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (34, N'MIX VEG', N'MIX VEG ', 211, CAST(225.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (35, N'CHANNA MASALA', N'CHANNA MASALA', 212, CAST(225.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (36, N'KASHMIRI ALOO', N'KASHMIRI ALOO', 213, CAST(225.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (37, N'NARGIS KOFTA', N'NARGIS KOFTA', 214, CAST(225.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (38, N'DAL MAKHNI', N'DAL MAKHNI', 215, CAST(225.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (39, N'DAL TADKA', N'DAL TADKA', 216, CAST(200.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (40, N'KADAHI VEGETABLE', N'KADAHI VEGETABLE', 217, CAST(240.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (41, N'Cholley', N'Cholley', 218, CAST(200.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (42, N'BOONDI RAITA', N'BOONDI RAITA', 219, CAST(100.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (43, N'MIX VEG RAITA', N'MIX VEG RAITA', 220, CAST(120.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (44, N'PINEAPPLE RAITA', N'PINEAPPLE RAITA', 221, CAST(130.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (45, N'CHOWMEIN', N'CHOWMEIN', 300, CAST(150.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (46, N'HAKKA NOODELS', N'HAKKA NOODELS', 301, CAST(175.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (47, N'CHEESY VEG (BAKED)', N'CHEESY VEG (BAKED)', 302, CAST(225.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (48, N'CREAMY SPAGHETTI', N'CREAMY SPAGHETTI', 303, CAST(225.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (49, N'SPICY CORN ON TOAST', N'SPICY CORN ON TOAST', 304, CAST(240.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (50, N'PASTA (RED/WHITE/MIXED)', N'PASTA (RED/WHITE/MIXED)', 305, CAST(150.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (51, N'VEG MANCHURIAN', N'VEG MANCHURIAN', 306, CAST(160.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (52, N'VEG SANDWICH ', N'VEG SANDWICH ', 307, CAST(110.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (53, N'CHILLY MUSHROOM  ON TOAST', N'CHILLY MUSHROOM  ON TOAST', 308, CAST(240.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (54, N'LASAGNE (BAKED)', N'LASAGNE (BAKED)', 309, CAST(275.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (55, N'MUSHROOM SAUTE WITH RICE', N'MUSHROOM SAUTE WITH RICE', 310, CAST(255.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (56, N'FOR EXTRA CHEESE 35 RS WILL ADDED', N'EXTRA CHEESE', 311, CAST(35.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (57, N'ONION PIZZA ', N'ONION PIZZA ', 312, CAST(180.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (58, N'TOMATO PIZZA', N'TOMATO PIZZA', 313, CAST(180.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (59, N'CAPSICUM PIZZA', N'CAPSICUM PIZZA', 314, CAST(180.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (60, N'RASAM ', N'RASAM ', 315, CAST(120.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (61, N'TOMATO SHORBA', N'TOMATO SHORBA', 316, CAST(120.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (62, N'SWEET CORN SOUP', N'SWEET CORN SOUP', 317, CAST(150.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (63, N'HOT AND SOUR SOUP', N'HOT AND SOUR SOUP', 318, CAST(150.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (64, N'MANCHOW SOUP', N'MANCHOW SOUP', 319, CAST(170.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (65, N'CREAM OF VEG SOUP', N'CREAM OF VEG SOUP', 320, CAST(170.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (66, N'CREAM OF TOMATO SOUP', N'CREAM OF TOMATO SOUP', 321, CAST(150.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (67, N'HARA BHARA KABAB ( 6 PICES)', N'HARA BHARA KABAB ( 6 PICES)', 400, CAST(150.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (68, N'FRENCH FRIES', N'FRENCH FRIES', 401, CAST(120.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (69, N'SPRING ROLL', N'SPRING ROLL', 402, CAST(150.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (70, N'PANEER TIKKA', N'PANEER TIKKA', 403, CAST(210.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (71, N'VEG CUTLET ( 2 PICES)', N'VEG CUTLET ( 2 PICES)', 404, CAST(120.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (72, N'PANEER CUTLET ( 2 PICES)', N'PANEER CUTLET ( 2 PICES)', 405, CAST(150.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (73, N'CHEESE CHILLY  TOAST', N'CHEESE CHILLY  TOAST', 406, CAST(180.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (74, N'VEG GALOUTI KABAB', N'VEG GALOUTI KABAB', 407, CAST(180.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (75, N'SOYA MALAI CHAP', N'SOYA MALAI CHAP', 408, CAST(180.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (76, N'SOYA ACHARI CHAP', N'SOYA ACHARI CHAP', 409, CAST(180.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (77, N'CHEESE BALL', N'CHEESE BALL', 410, CAST(160.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (78, N'CHOLE BHATUREY', N'CHOLE BHATUREY', 411, CAST(160.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (79, N'MASALA PAPAD ', N'MASALA PAPAD ', 412, CAST(70.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (80, N'VEG SEEKH KABAB', N'VEG SEEKH KABAB', 413, CAST(160.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (81, N'DAHI VADA', N'DAHI VADA', 414, CAST(210.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (82, N'HONEY CHILLI PATATO', N'HONEY CHILLI PATATO', 415, CAST(150.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (83, N'CHILLY PANEER ', N'CHILLY PANEER ', 416, CAST(200.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (84, N'CHILLY MUSHROOM (CONTI STYLE)', N'CHILLY MUSHROOM (CONTI STYLE)', 417, CAST(240.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (85, N'PAV BHAJI', N'PAV BHAJI', 418, CAST(120.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (86, N'EXTRA PAV', N'EXTRA PAV', 419, CAST(25.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (87, N'TEA', N'TEA', 500, CAST(70.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (88, N'LEMON TEA', N'LEMON TEA', 501, CAST(70.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (89, N'BLACK TEA ', N'BLACK TEA ', 502, CAST(70.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (90, N'GREEN TEA', N'GREEN TEA', 503, CAST(70.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (91, N'HOT COFFEE', N'HOT COFFEE', 504, CAST(70.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (92, N'COLD COFFEE WITH ICE CREAM', N'COLD COFFEE WITH ICE CREAM', 505, CAST(130.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (93, N'COLD COFFEE ', N'COLD COFFEE ', 506, CAST(100.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (94, N'LEMONADE (SWEET/SALT)', N'LEMONADE (SWEET/SALT)', 507, CAST(70.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (95, N'SOFT DRINK', N'SOFT DRINK', 508, CAST(60.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (96, N'ORANGE JUICE', N'ORANGE JUICE', 509, CAST(85.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (97, N'PINEAPPLE JUICE', N'PINEAPPLE JUICE', 510, CAST(85.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (98, N'WATERMELON JUICE', N'WATERMELON JUICE', 511, CAST(85.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (99, N'MANGO JUICE', N'MANGO JUICE', 512, CAST(85.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (100, N'MANGO SHAKE', N'MANGO SHAKE', 513, CAST(130.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (101, N'BANANA SHAKE', N'BANANA SHAKE', 514, CAST(130.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (102, N'PINEAPPLE SHAKE', N'PINEAPPLE SHAKE', 515, CAST(130.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (103, N'STRAWBERRY SHAKE', N'STRAWBERRY SHAKE', 516, CAST(130.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (104, N'CHOCOLATE SHAKE', N'CHOCOLATE SHAKE', 517, CAST(150.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (105, N'VANILLA SHAKE', N'VANILLA SHAKE', 518, CAST(130.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (106, N'SWEET LASSI', N'SWEET LASSI', 519, CAST(90.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (107, N'SALT LASSI', N'SALT LASSI', 520, CAST(90.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (108, N'ROTI                                                                                                               ', N'ROTI                                                                                                               ', 600, CAST(25.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (109, N'BUTTER ROTI', N'BUTTER ROTI', 601, CAST(30.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (110, N'MISSI ROTI', N'MISSI ROTI', 602, CAST(35.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (111, N'BUTTER MISSI ROTI', N'BUTTER MISSI ROTI', 603, CAST(40.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (112, N'MISSI MASALA ROTI', N'MISSI MASALA ROTI', 604, CAST(50.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (113, N'PLAIN NAAN', N'PLAIN NAAN', 605, CAST(55.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (114, N'BUTTER NAAN', N'BUTTER NAAN', 606, CAST(60.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (115, N'STUFFED NAAN', N'STUFFED NAAN', 607, CAST(70.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (116, N'PANEER NAAN', N'PANEER NAAN', 608, CAST(80.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (117, N'GARLIC NAAN', N'GARLIC NAAN', 609, CAST(80.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (118, N'LACHAA PARATHA', N'LACHAA PARATHA', 610, CAST(70.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (119, N'STUFFED PARATHA', N'STUFFED PARATHA', 611, CAST(70.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (120, N'STUFFED KULCHA', N'STUFFED KULCHA', 612, CAST(80.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (121, N'ONION KULCHA', N'ONION KULCHA', 613, CAST(80.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (122, N'STEAMED RICE', N'STEAMED RICE', 700, CAST(180.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (123, N'LEMON RICE', N'LEMON RICE', 701, CAST(225.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (124, N'VEG PULAO', N'VEG PULAO', 702, CAST(225.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (125, N'MATAR PULAO', N'MATAR PULAO', 703, CAST(225.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (126, N'FRIED RICE ', N'FRIED RICE ', 704, CAST(225.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (127, N'VEG BIRYANI', N'VEG BIRYANI', 705, CAST(225.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (128, N'JEERA RICE', N'JEERA RICE', 706, CAST(225.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (129, N'RAWA KESARI', N'RAWA KESARI', 800, CAST(90.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (130, N'ICE CREAM', N'ICE CREAM', 801, CAST(50.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (131, N'GULAB JAMUN (2 PICES)', N'GULAB JAMUN (2 PICES)', 802, CAST(100.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (132, N'MINI THALI    ', N'MINI THALI    ', 900, CAST(225.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (133, N'SPECIAL THALI ', N'SPECIAL THALI ', 901, CAST(290.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
INSERT [dbo].[ItemMaster] ([ID], [Name], [Description], [ItemSeriesId], [Price], [IsTaxable], [UnitId], [IsKot], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (134, N'SOUTH INDIAN PLATE ', N'SOUTH INDIAN PLATE ', 902, CAST(275.00 AS Decimal(18, 2)), 1, 0, 0, N'', 1, 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime), 3, CAST(N'2021-04-04 17:24:04.253' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[ItemMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[Location] ON 

GO
INSERT [dbo].[Location] ([ID], [Name], [Seats], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (1, N'ss', 20, N'First Floor total seating arrangement', 1, 1, CAST(N'2016-11-12 20:46:00.000' AS DateTime), 1, CAST(N'2016-11-12 20:46:00.000' AS DateTime))
GO
INSERT [dbo].[Location] ([ID], [Name], [Seats], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (2, N'Second Floor', 12, N'Second Floor total seating arrangement', 0, 1, CAST(N'2016-11-12 20:47:00.000' AS DateTime), 1, CAST(N'2016-11-12 20:47:00.000' AS DateTime))
GO
INSERT [dbo].[Location] ([ID], [Name], [Seats], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (3, N'Third Floor', 10, N'third floor', 0, 1, CAST(N'2016-11-12 20:48:00.000' AS DateTime), 1, CAST(N'2016-11-12 20:48:00.000' AS DateTime))
GO
INSERT [dbo].[Location] ([ID], [Name], [Seats], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (4, N'Third Floor', 10, N'third floor', 0, 1, CAST(N'2016-11-12 20:48:00.000' AS DateTime), 1, CAST(N'2016-11-12 20:48:00.000' AS DateTime))
GO
INSERT [dbo].[Location] ([ID], [Name], [Seats], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (5, N'table 56', 56, N'fgdfgsdf', 0, 1, CAST(N'2016-12-12 13:23:00.000' AS DateTime), 1, CAST(N'2016-12-12 13:23:00.000' AS DateTime))
GO
INSERT [dbo].[Location] ([ID], [Name], [Seats], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (6, N'FF', 5, N'dfgdgsdfg', 0, 1, CAST(N'2016-12-12 13:25:00.000' AS DateTime), 1, CAST(N'2016-12-12 13:25:00.000' AS DateTime))
GO
INSERT [dbo].[Location] ([ID], [Name], [Seats], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (7, N'sd', 3, N'', 0, 3, CAST(N'2017-03-26 14:45:18.000' AS DateTime), 3, CAST(N'2017-03-26 14:45:18.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Location] OFF
GO
INSERT [dbo].[MenuAndSubMenu] ([ID], [ParentId], [Name], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (1, 0, N'mastersToolStripMenuItem', N'Master', 1, 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime), 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime))
GO
INSERT [dbo].[MenuAndSubMenu] ([ID], [ParentId], [Name], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (2, 1, N'customerMasterToolStripMenuItem', N'Counter Master', 0, 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime), 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime))
GO
INSERT [dbo].[MenuAndSubMenu] ([ID], [ParentId], [Name], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (3, 1, N'fGItemMasterToolStripMenuItem', N'FG Counter', 0, 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime), 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime))
GO
INSERT [dbo].[MenuAndSubMenu] ([ID], [ParentId], [Name], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (4, 1, N'userToolStripMenuItem', N'Users', 1, 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime), 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime))
GO
INSERT [dbo].[MenuAndSubMenu] ([ID], [ParentId], [Name], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (29, 1, N'unitToolStripMenuItem', N'Unit', 0, 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime), 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime))
GO
INSERT [dbo].[MenuAndSubMenu] ([ID], [ParentId], [Name], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (6, 1, N'userTypesToolStripMenuItem', N'User Types', 1, 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime), 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime))
GO
INSERT [dbo].[MenuAndSubMenu] ([ID], [ParentId], [Name], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (7, 1, N'menuAndSubMenuToolStripMenuItem', N'Menu And SubMenu', 0, 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime), 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime))
GO
INSERT [dbo].[MenuAndSubMenu] ([ID], [ParentId], [Name], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (8, 0, N'tranjectionToolStripMenuItem', N'Transaction', 1, 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime), 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime))
GO
INSERT [dbo].[MenuAndSubMenu] ([ID], [ParentId], [Name], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (9, 8, N'printTockenToolStripMenuItem', N'Print Tocket', 1, 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime), 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime))
GO
INSERT [dbo].[MenuAndSubMenu] ([ID], [ParentId], [Name], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (10, 0, N'reportToolStripMenuItem', N'Report', 1, 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime), 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime))
GO
INSERT [dbo].[MenuAndSubMenu] ([ID], [ParentId], [Name], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (11, 10, N'dateWiseSaleReportToolStripMenuItem', N'Cancel Bill report', 1, 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime), 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime))
GO
INSERT [dbo].[MenuAndSubMenu] ([ID], [ParentId], [Name], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (12, 10, N'itemWiseSaleReportToolStripMenuItem', N'User wise Sales Summary', 1, 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime), 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime))
GO
INSERT [dbo].[MenuAndSubMenu] ([ID], [ParentId], [Name], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (13, 10, N'resetToolStripMenuItem', N'Card Payment Report', 1, 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime), 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime))
GO
INSERT [dbo].[MenuAndSubMenu] ([ID], [ParentId], [Name], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (14, 10, N'dateWiseBillReportToolStripMenuItem', N'Duplicate Cash Memo Report', 1, 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime), 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime))
GO
INSERT [dbo].[MenuAndSubMenu] ([ID], [ParentId], [Name], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (15, 10, N'vatReportToolStripMenuItem', N'Daily Sales Report', 1, 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime), 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime))
GO
INSERT [dbo].[MenuAndSubMenu] ([ID], [ParentId], [Name], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (16, 0, N'toolsToolStripMenuItem', N'Tools', 1, 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime), 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime))
GO
INSERT [dbo].[MenuAndSubMenu] ([ID], [ParentId], [Name], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (17, 16, N'resetToolStripMenuItem1', N'Reset', 1, 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime), 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime))
GO
INSERT [dbo].[MenuAndSubMenu] ([ID], [ParentId], [Name], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (18, 1, N'manageRightsToolStripMenuItem', N'Manage Rights', 1, 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime), 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime))
GO
INSERT [dbo].[MenuAndSubMenu] ([ID], [ParentId], [Name], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (19, 0, N'accountToolStripMenuItem', N'Account', 1, 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime), 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime))
GO
INSERT [dbo].[MenuAndSubMenu] ([ID], [ParentId], [Name], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (20, 19, N'profileToolStripMenuItem', N'Profile', 1, 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime), 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime))
GO
INSERT [dbo].[MenuAndSubMenu] ([ID], [ParentId], [Name], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (21, 19, N'logoutToolStripMenuItem', N'Logout', 1, 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime), 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime))
GO
INSERT [dbo].[MenuAndSubMenu] ([ID], [ParentId], [Name], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (22, 8, N'saleToolStripMenuItem', N'Sale', 1, 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime), 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime))
GO
INSERT [dbo].[MenuAndSubMenu] ([ID], [ParentId], [Name], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (23, 9, N'Tr_SaleFrm', N'Sale Form', 1, 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime), 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime))
GO
INSERT [dbo].[MenuAndSubMenu] ([ID], [ParentId], [Name], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (24, 23, N'btAdd', N'Add Button', 1, 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime), 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime))
GO
INSERT [dbo].[MenuAndSubMenu] ([ID], [ParentId], [Name], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (25, 23, N'btnRevert', N'Revert Button', 1, 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime), 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime))
GO
INSERT [dbo].[MenuAndSubMenu] ([ID], [ParentId], [Name], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (26, 23, N'btnCancel', N'Cancel Button', 1, 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime), 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime))
GO
INSERT [dbo].[MenuAndSubMenu] ([ID], [ParentId], [Name], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (27, 23, N'BtnSearch', N'Search Button', 1, 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime), 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime))
GO
INSERT [dbo].[MenuAndSubMenu] ([ID], [ParentId], [Name], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (28, 23, N'BtnClose', N'Close Button', 1, 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime), 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime))
GO
INSERT [dbo].[MenuAndSubMenu] ([ID], [ParentId], [Name], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (5, 1, N'manageTaxToolStripMenuItem', N'Tax', 1, 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime), 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime))
GO
INSERT [dbo].[MenuAndSubMenu] ([ID], [ParentId], [Name], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (30, 1, N'itemMasterToolStripMenuItem', N'Item Master', 1, 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime), 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime))
GO
INSERT [dbo].[MenuAndSubMenu] ([ID], [ParentId], [Name], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (31, 1, N'locationToolStripMenuItem', N'Location', 1, 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime), 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime))
GO
INSERT [dbo].[MenuAndSubMenu] ([ID], [ParentId], [Name], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (32, 1, N'discountMasterToolStripMenuItem', N'Discount', 1, 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime), 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime))
GO
INSERT [dbo].[MenuAndSubMenu] ([ID], [ParentId], [Name], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (33, 1, N'userRightsToolStripMenuItem', N'User Rights', 1, 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime), 1, CAST(N'2013-07-23 00:00:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[OrderType] ON 

GO
INSERT [dbo].[OrderType] ([Id], [OrderType], [IsDefault]) VALUES (1, N'Cash', 1)
GO
INSERT [dbo].[OrderType] ([Id], [OrderType], [IsDefault]) VALUES (2, N'Zomato', 0)
GO
SET IDENTITY_INSERT [dbo].[OrderType] OFF
GO
SET IDENTITY_INSERT [dbo].[SalesDetails] ON 

GO
INSERT [dbo].[SalesDetails] ([ID], [SaleMasterId], [BillNumber], [ItemId], [Qty], [Amount], [Taxes], [ItemPrice], [GridSNo], [Description], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (1, 1, 1001, 4, 2, CAST(279.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(155.00 AS Decimal(18, 2)), 1, N'3', N'103 ONION PANEER BUTTER MASALA DOSA', 1, 4, CAST(N'2021-04-04 05:15:22.000' AS DateTime), 4, CAST(N'2021-04-04 05:15:22.000' AS DateTime))
GO
INSERT [dbo].[SalesDetails] ([ID], [SaleMasterId], [BillNumber], [ItemId], [Qty], [Amount], [Taxes], [ItemPrice], [GridSNo], [Description], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (2, 1, 1001, 68, 1, CAST(108.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(120.00 AS Decimal(18, 2)), 2, N'3', N'401 FRENCH FRIES', 1, 4, CAST(N'2021-04-04 05:15:59.000' AS DateTime), 4, CAST(N'2021-04-04 05:15:59.000' AS DateTime))
GO
INSERT [dbo].[SalesDetails] ([ID], [SaleMasterId], [BillNumber], [ItemId], [Qty], [Amount], [Taxes], [ItemPrice], [GridSNo], [Description], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (3, 1, 1001, 106, 1, CAST(81.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(90.00 AS Decimal(18, 2)), 3, N'3', N'519 SWEET LASSI', 1, 4, CAST(N'2021-04-04 05:16:40.000' AS DateTime), 4, CAST(N'2021-04-04 05:16:40.000' AS DateTime))
GO
INSERT [dbo].[SalesDetails] ([ID], [SaleMasterId], [BillNumber], [ItemId], [Qty], [Amount], [Taxes], [ItemPrice], [GridSNo], [Description], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (4, 1, 1001, 95, 1, CAST(54.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(60.00 AS Decimal(18, 2)), 4, N'3', N'508 SOFT DRINK', 1, 4, CAST(N'2021-04-04 05:16:57.000' AS DateTime), 4, CAST(N'2021-04-04 05:16:57.000' AS DateTime))
GO
INSERT [dbo].[SalesDetails] ([ID], [SaleMasterId], [BillNumber], [ItemId], [Qty], [Amount], [Taxes], [ItemPrice], [GridSNo], [Description], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (5, 2, 1002, 23, 1, CAST(275.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(275.00 AS Decimal(18, 2)), 1, N'4', N'200 NAVRATAN KORMA', 1, 4, CAST(N'2021-04-04 05:37:49.000' AS DateTime), 4, CAST(N'2021-04-04 05:37:49.000' AS DateTime))
GO
INSERT [dbo].[SalesDetails] ([ID], [SaleMasterId], [BillNumber], [ItemId], [Qty], [Amount], [Taxes], [ItemPrice], [GridSNo], [Description], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (6, 2, 1002, 129, 1, CAST(90.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(90.00 AS Decimal(18, 2)), 2, N'4', N'800 RAWA KESARI', 1, 4, CAST(N'2021-04-04 05:37:58.000' AS DateTime), 4, CAST(N'2021-04-04 05:37:58.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[SalesDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[SalesMaster] ON 

GO
INSERT [dbo].[SalesMaster] ([ID], [BillNumber], [TableNumber], [CustomerId], [Amount], [Taxes], [RoundAmount], [TotalAmount], [Difference], [Discount], [Status], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [PaymentMode]) VALUES (1, 1001, N'3', 1, CAST(580.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(522.00 AS Decimal(18, 2)), CAST(522.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), 4, N'Printed', 1, 4, CAST(N'2021-04-04 05:15:04.000' AS DateTime), 4, CAST(N'2021-04-04 05:15:04.000' AS DateTime), N'CASH')
GO
INSERT [dbo].[SalesMaster] ([ID], [BillNumber], [TableNumber], [CustomerId], [Amount], [Taxes], [RoundAmount], [TotalAmount], [Difference], [Discount], [Status], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [PaymentMode]) VALUES (2, 1002, N'4', 1, CAST(365.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(365.00 AS Decimal(18, 2)), CAST(365.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 4, N'Printed', 1, 4, CAST(N'2021-04-04 05:37:47.000' AS DateTime), 4, CAST(N'2021-04-04 05:37:47.000' AS DateTime), N'CASH')
GO
SET IDENTITY_INSERT [dbo].[SalesMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[Taxes] ON 

GO
INSERT [dbo].[Taxes] ([ID], [Name], [Rate], [Description], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (1, N'CGST', CAST(0.00 AS Decimal(18, 2)), N'Central', N'', 1, 3, CAST(N'2017-06-25 12:04:04.000' AS DateTime), 3, CAST(N'2017-06-25 12:04:04.000' AS DateTime))
GO
INSERT [dbo].[Taxes] ([ID], [Name], [Rate], [Description], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (2, N'SGST', CAST(0.00 AS Decimal(18, 2)), N'State', N'', 1, 3, CAST(N'2017-06-25 12:05:01.000' AS DateTime), 3, CAST(N'2017-06-25 12:05:01.000' AS DateTime))
GO
INSERT [dbo].[Taxes] ([ID], [Name], [Rate], [Description], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (3, N'CGST', CAST(9.00 AS Decimal(18, 2)), N'Central', N'', 0, 4, CAST(N'2018-03-09 12:44:50.000' AS DateTime), 4, CAST(N'2018-03-09 12:44:50.000' AS DateTime))
GO
INSERT [dbo].[Taxes] ([ID], [Name], [Rate], [Description], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (4, N'SGST', CAST(9.00 AS Decimal(18, 2)), N'State', N'', 0, 4, CAST(N'2018-03-09 12:45:09.000' AS DateTime), 4, CAST(N'2018-03-09 12:45:09.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Taxes] OFF
GO
SET IDENTITY_INSERT [dbo].[Unit] ON 

GO
INSERT [dbo].[Unit] ([ID], [Name], [Description], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (1, N'Qty', N'Quantity', N'Quantity', 1, 4, CAST(N'2016-12-12 15:53:00.000' AS DateTime), 1, CAST(N'2016-12-12 15:53:00.000' AS DateTime))
GO
INSERT [dbo].[Unit] ([ID], [Name], [Description], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (3, N'Kg', N'Kilogram', N'Kilogram', 1, 4, CAST(N'2016-12-12 15:53:00.000' AS DateTime), 1, CAST(N'2016-12-12 15:53:00.000' AS DateTime))
GO
INSERT [dbo].[Unit] ([ID], [Name], [Description], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (4, N'Ltr', N'', N'Liter', 1, 4, CAST(N'2016-12-12 21:18:00.000' AS DateTime), 4, CAST(N'2016-12-12 21:18:00.000' AS DateTime))
GO
INSERT [dbo].[Unit] ([ID], [Name], [Description], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (5, N'Pkt', N'', N'Packet', 1, 4, CAST(N'2016-12-12 21:18:00.000' AS DateTime), 4, CAST(N'2016-12-12 21:18:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Unit] OFF
GO
SET IDENTITY_INSERT [dbo].[UserRights] ON 

GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (178, 2, 4, 1, N'', 1, 1, CAST(N'2017-07-21 05:52:29.000' AS DateTime), 1, CAST(N'2017-07-21 05:52:29.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (2, 2, 3, 1, N'', 1, 1, CAST(N'2016-12-30 15:48:48.000' AS DateTime), 1, CAST(N'2016-12-30 15:48:48.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (3, 2, 4, 1, N'', 1, 1, CAST(N'2016-12-30 15:48:48.000' AS DateTime), 1, CAST(N'2016-12-30 15:48:48.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (4, 2, 7, 1, N'', 1, 1, CAST(N'2016-12-30 15:48:48.000' AS DateTime), 1, CAST(N'2016-12-30 15:48:48.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (5, 2, 8, 0, N'', 1, 1, CAST(N'2016-12-30 15:48:48.000' AS DateTime), 1, CAST(N'2016-12-30 15:48:48.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (6, 2, 23, 9, N'', 1, 1, CAST(N'2016-12-30 15:48:48.000' AS DateTime), 1, CAST(N'2016-12-30 15:48:48.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (7, 2, 25, 23, N'', 1, 1, CAST(N'2016-12-30 15:48:48.000' AS DateTime), 1, CAST(N'2016-12-30 15:48:48.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (8, 2, 26, 23, N'', 1, 1, CAST(N'2016-12-30 15:48:48.000' AS DateTime), 1, CAST(N'2016-12-30 15:48:48.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (9, 2, 28, 23, N'', 1, 1, CAST(N'2016-12-30 15:48:48.000' AS DateTime), 1, CAST(N'2016-12-30 15:48:48.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (188, 2, 19, 0, N'', 1, 1, CAST(N'2017-07-21 05:52:29.000' AS DateTime), 1, CAST(N'2017-07-21 05:52:29.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (189, 2, 20, 19, N'', 1, 1, CAST(N'2017-07-21 05:52:29.000' AS DateTime), 1, CAST(N'2017-07-21 05:52:29.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (190, 2, 21, 19, N'', 1, 1, CAST(N'2017-07-21 05:52:29.000' AS DateTime), 1, CAST(N'2017-07-21 05:52:29.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (13, 2, 20, 19, N'', 1, 1, CAST(N'2016-12-30 15:48:48.000' AS DateTime), 1, CAST(N'2016-12-30 15:48:48.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (14, 2, 21, 19, N'', 1, 1, CAST(N'2016-12-30 15:48:48.000' AS DateTime), 1, CAST(N'2016-12-30 15:48:48.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (15, 3, 9, 8, N'', 1, 1, CAST(N'2016-12-30 15:49:07.000' AS DateTime), 1, CAST(N'2016-12-30 15:49:07.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (16, 3, 24, 23, N'', 1, 1, CAST(N'2016-12-30 15:49:07.000' AS DateTime), 1, CAST(N'2016-12-30 15:49:07.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (17, 3, 22, 8, N'', 1, 1, CAST(N'2016-12-30 15:49:07.000' AS DateTime), 1, CAST(N'2016-12-30 15:49:07.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (18, 3, 20, 19, N'', 1, 1, CAST(N'2016-12-30 15:49:07.000' AS DateTime), 1, CAST(N'2016-12-30 15:49:07.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (19, 2, 2, 1, N'', 1, 1, CAST(N'2016-12-30 15:48:48.000' AS DateTime), 1, CAST(N'2016-12-30 15:48:48.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (179, 2, 8, 0, N'', 1, 1, CAST(N'2017-07-21 05:52:29.000' AS DateTime), 1, CAST(N'2017-07-21 05:52:29.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (180, 2, 9, 8, N'', 1, 1, CAST(N'2017-07-21 05:52:29.000' AS DateTime), 1, CAST(N'2017-07-21 05:52:29.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (22, 2, 9, 8, N'', 1, 1, CAST(N'2016-12-30 15:48:48.000' AS DateTime), 1, CAST(N'2016-12-30 15:48:48.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (23, 2, 27, 23, N'', 1, 1, CAST(N'2016-12-30 15:48:48.000' AS DateTime), 1, CAST(N'2016-12-30 15:48:48.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (24, 2, 22, 8, N'', 1, 1, CAST(N'2016-12-30 15:48:48.000' AS DateTime), 1, CAST(N'2016-12-30 15:48:48.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (26, 2, 19, 0, N'', 1, 1, CAST(N'2016-12-30 15:48:48.000' AS DateTime), 1, CAST(N'2016-12-30 15:48:48.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (27, 3, 8, 0, N'', 1, 1, CAST(N'2016-12-30 15:49:07.000' AS DateTime), 1, CAST(N'2016-12-30 15:49:07.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (28, 3, 23, 9, N'', 1, 1, CAST(N'2016-12-30 15:49:07.000' AS DateTime), 1, CAST(N'2016-12-30 15:49:07.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (29, 3, 19, 0, N'', 1, 1, CAST(N'2016-12-30 15:49:07.000' AS DateTime), 1, CAST(N'2016-12-30 15:49:07.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (30, 3, 21, 19, N'', 1, 1, CAST(N'2016-12-30 15:49:07.000' AS DateTime), 1, CAST(N'2016-12-30 15:49:07.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (31, 2, 24, 23, N'', 1, 1, CAST(N'2016-12-30 15:48:48.000' AS DateTime), 1, CAST(N'2016-12-30 15:48:48.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (181, 2, 23, 9, N'', 1, 1, CAST(N'2017-07-21 05:52:29.000' AS DateTime), 1, CAST(N'2017-07-21 05:52:29.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (35, 6, 1, 0, N'', 1, 1, CAST(N'2017-03-26 14:21:07.000' AS DateTime), 1, CAST(N'2017-03-26 14:21:07.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (36, 6, 2, 1, N'', 1, 1, CAST(N'2017-03-26 14:21:07.000' AS DateTime), 1, CAST(N'2017-03-26 14:21:07.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (37, 6, 3, 1, N'', 1, 1, CAST(N'2017-03-26 14:21:07.000' AS DateTime), 1, CAST(N'2017-03-26 14:21:07.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (39, 6, 1, 0, N'', 1, 1, CAST(N'2017-03-26 14:23:34.000' AS DateTime), 1, CAST(N'2017-03-26 14:23:34.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (41, 6, 3, 1, N'', 1, 1, CAST(N'2017-03-26 14:23:34.000' AS DateTime), 1, CAST(N'2017-03-26 14:23:34.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (43, 6, 5, 1, N'', 1, 1, CAST(N'2017-03-26 14:23:35.000' AS DateTime), 1, CAST(N'2017-03-26 14:23:35.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (46, 6, 9, 8, N'', 1, 1, CAST(N'2017-03-26 14:23:35.000' AS DateTime), 1, CAST(N'2017-03-26 14:23:35.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (48, 6, 24, 23, N'', 1, 1, CAST(N'2017-03-26 14:23:35.000' AS DateTime), 1, CAST(N'2017-03-26 14:23:35.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (50, 6, 26, 23, N'', 1, 1, CAST(N'2017-03-26 14:23:35.000' AS DateTime), 1, CAST(N'2017-03-26 14:23:35.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (52, 6, 28, 23, N'', 1, 1, CAST(N'2017-03-26 14:23:36.000' AS DateTime), 1, CAST(N'2017-03-26 14:23:36.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (53, 6, 22, 8, N'', 1, 1, CAST(N'2017-03-26 14:23:36.000' AS DateTime), 1, CAST(N'2017-03-26 14:23:36.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (55, 6, 11, 10, N'', 1, 1, CAST(N'2017-03-26 14:23:36.000' AS DateTime), 1, CAST(N'2017-03-26 14:23:36.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (57, 6, 13, 10, N'', 1, 1, CAST(N'2017-03-26 14:23:36.000' AS DateTime), 1, CAST(N'2017-03-26 14:23:36.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (59, 6, 15, 10, N'', 1, 1, CAST(N'2017-03-26 14:23:36.000' AS DateTime), 1, CAST(N'2017-03-26 14:23:36.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (61, 6, 17, 16, N'', 1, 1, CAST(N'2017-03-26 14:23:36.000' AS DateTime), 1, CAST(N'2017-03-26 14:23:36.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (64, 6, 21, 19, N'', 1, 1, CAST(N'2017-03-26 14:23:36.000' AS DateTime), 1, CAST(N'2017-03-26 14:23:36.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (65, 6, 1, 0, N'', 1, 1, CAST(N'2017-03-26 14:35:43.000' AS DateTime), 1, CAST(N'2017-03-26 14:35:43.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (66, 6, 2, 1, N'', 1, 1, CAST(N'2017-03-26 14:35:43.000' AS DateTime), 1, CAST(N'2017-03-26 14:35:43.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (68, 6, 4, 1, N'', 1, 1, CAST(N'2017-03-26 14:35:43.000' AS DateTime), 1, CAST(N'2017-03-26 14:35:43.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (72, 6, 32, 1, N'', 1, 1, CAST(N'2017-03-26 14:35:43.000' AS DateTime), 1, CAST(N'2017-03-26 14:35:43.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (75, 6, 23, 9, N'', 1, 1, CAST(N'2017-03-26 14:35:43.000' AS DateTime), 1, CAST(N'2017-03-26 14:35:43.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (77, 6, 25, 23, N'', 1, 1, CAST(N'2017-03-26 14:35:44.000' AS DateTime), 1, CAST(N'2017-03-26 14:35:44.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (79, 6, 27, 23, N'', 1, 1, CAST(N'2017-03-26 14:35:44.000' AS DateTime), 1, CAST(N'2017-03-26 14:35:44.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (81, 6, 22, 8, N'', 1, 1, CAST(N'2017-03-26 14:35:44.000' AS DateTime), 1, CAST(N'2017-03-26 14:35:44.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (82, 6, 10, 0, N'', 1, 1, CAST(N'2017-03-26 14:35:44.000' AS DateTime), 1, CAST(N'2017-03-26 14:35:44.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (84, 6, 12, 10, N'', 1, 1, CAST(N'2017-03-26 14:35:44.000' AS DateTime), 1, CAST(N'2017-03-26 14:35:44.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (87, 6, 15, 10, N'', 1, 1, CAST(N'2017-03-26 14:35:44.000' AS DateTime), 1, CAST(N'2017-03-26 14:35:44.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (88, 6, 16, 0, N'', 1, 1, CAST(N'2017-03-26 14:35:44.000' AS DateTime), 1, CAST(N'2017-03-26 14:35:44.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (90, 6, 19, 0, N'', 1, 1, CAST(N'2017-03-26 14:35:44.000' AS DateTime), 1, CAST(N'2017-03-26 14:35:44.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (92, 6, 21, 19, N'', 1, 1, CAST(N'2017-03-26 14:35:44.000' AS DateTime), 1, CAST(N'2017-03-26 14:35:44.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (93, 6, 1, 0, N'', 1, 1, CAST(N'2017-03-26 14:37:15.000' AS DateTime), 1, CAST(N'2017-03-26 14:37:15.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (95, 6, 3, 1, N'', 1, 1, CAST(N'2017-03-26 14:37:15.000' AS DateTime), 1, CAST(N'2017-03-26 14:37:15.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (96, 6, 4, 1, N'', 1, 1, CAST(N'2017-03-26 14:37:15.000' AS DateTime), 1, CAST(N'2017-03-26 14:37:15.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (97, 6, 5, 1, N'', 1, 1, CAST(N'2017-03-26 14:37:15.000' AS DateTime), 1, CAST(N'2017-03-26 14:37:15.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (99, 6, 31, 1, N'', 1, 1, CAST(N'2017-03-26 14:37:15.000' AS DateTime), 1, CAST(N'2017-03-26 14:37:15.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (100, 6, 32, 1, N'', 1, 1, CAST(N'2017-03-26 14:37:15.000' AS DateTime), 1, CAST(N'2017-03-26 14:37:15.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (102, 6, 9, 8, N'', 1, 1, CAST(N'2017-03-26 14:37:15.000' AS DateTime), 1, CAST(N'2017-03-26 14:37:15.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (104, 6, 24, 23, N'', 1, 1, CAST(N'2017-03-26 14:37:15.000' AS DateTime), 1, CAST(N'2017-03-26 14:37:15.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (106, 6, 26, 23, N'', 1, 1, CAST(N'2017-03-26 14:37:16.000' AS DateTime), 1, CAST(N'2017-03-26 14:37:16.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (109, 6, 22, 8, N'', 1, 1, CAST(N'2017-03-26 14:37:16.000' AS DateTime), 1, CAST(N'2017-03-26 14:37:16.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (110, 6, 10, 0, N'', 1, 1, CAST(N'2017-03-26 14:37:16.000' AS DateTime), 1, CAST(N'2017-03-26 14:37:16.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (112, 6, 12, 10, N'', 1, 1, CAST(N'2017-03-26 14:37:16.000' AS DateTime), 1, CAST(N'2017-03-26 14:37:16.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (115, 6, 15, 10, N'', 1, 1, CAST(N'2017-03-26 14:37:16.000' AS DateTime), 1, CAST(N'2017-03-26 14:37:16.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (117, 6, 17, 16, N'', 1, 1, CAST(N'2017-03-26 14:37:16.000' AS DateTime), 1, CAST(N'2017-03-26 14:37:16.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (119, 6, 20, 19, N'', 1, 1, CAST(N'2017-03-26 14:37:17.000' AS DateTime), 1, CAST(N'2017-03-26 14:37:17.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (121, 6, 1, 0, N'', 1, 1, CAST(N'2017-03-26 14:38:13.000' AS DateTime), 1, CAST(N'2017-03-26 14:38:13.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (124, 6, 4, 1, N'', 1, 1, CAST(N'2017-03-26 14:38:14.000' AS DateTime), 1, CAST(N'2017-03-26 14:38:14.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (125, 6, 5, 1, N'', 1, 1, CAST(N'2017-03-26 14:38:14.000' AS DateTime), 1, CAST(N'2017-03-26 14:38:14.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (127, 6, 31, 1, N'', 1, 1, CAST(N'2017-03-26 14:38:14.000' AS DateTime), 1, CAST(N'2017-03-26 14:38:14.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (130, 6, 9, 8, N'', 1, 1, CAST(N'2017-03-26 14:38:14.000' AS DateTime), 1, CAST(N'2017-03-26 14:38:14.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (132, 6, 24, 23, N'', 1, 1, CAST(N'2017-03-26 14:38:14.000' AS DateTime), 1, CAST(N'2017-03-26 14:38:14.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (134, 6, 26, 23, N'', 1, 1, CAST(N'2017-03-26 14:38:14.000' AS DateTime), 1, CAST(N'2017-03-26 14:38:14.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (136, 6, 28, 23, N'', 1, 1, CAST(N'2017-03-26 14:38:14.000' AS DateTime), 1, CAST(N'2017-03-26 14:38:14.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (137, 6, 22, 8, N'', 1, 1, CAST(N'2017-03-26 14:38:14.000' AS DateTime), 1, CAST(N'2017-03-26 14:38:14.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (140, 6, 12, 10, N'', 1, 1, CAST(N'2017-03-26 14:38:14.000' AS DateTime), 1, CAST(N'2017-03-26 14:38:14.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (142, 6, 14, 10, N'', 1, 1, CAST(N'2017-03-26 14:38:15.000' AS DateTime), 1, CAST(N'2017-03-26 14:38:15.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (144, 6, 16, 0, N'', 1, 1, CAST(N'2017-03-26 14:38:15.000' AS DateTime), 1, CAST(N'2017-03-26 14:38:15.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (146, 6, 19, 0, N'', 1, 1, CAST(N'2017-03-26 14:38:15.000' AS DateTime), 1, CAST(N'2017-03-26 14:38:15.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (148, 6, 21, 19, N'', 1, 1, CAST(N'2017-03-26 14:38:15.000' AS DateTime), 1, CAST(N'2017-03-26 14:38:15.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (151, 6, 3, 1, N'', 1, 1, CAST(N'2017-03-26 14:49:50.000' AS DateTime), 1, CAST(N'2017-03-26 14:49:50.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (154, 6, 30, 1, N'', 1, 1, CAST(N'2017-03-26 14:49:50.000' AS DateTime), 1, CAST(N'2017-03-26 14:49:50.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (155, 6, 31, 1, N'', 1, 1, CAST(N'2017-03-26 14:49:50.000' AS DateTime), 1, CAST(N'2017-03-26 14:49:50.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (157, 6, 33, 1, N'', 1, 1, CAST(N'2017-03-26 14:49:51.000' AS DateTime), 1, CAST(N'2017-03-26 14:49:51.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (160, 6, 23, 9, N'', 1, 1, CAST(N'2017-03-26 14:49:51.000' AS DateTime), 1, CAST(N'2017-03-26 14:49:51.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (162, 6, 25, 23, N'', 1, 1, CAST(N'2017-03-26 14:49:51.000' AS DateTime), 1, CAST(N'2017-03-26 14:49:51.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (163, 6, 26, 23, N'', 1, 1, CAST(N'2017-03-26 14:49:51.000' AS DateTime), 1, CAST(N'2017-03-26 14:49:51.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (165, 6, 28, 23, N'', 1, 1, CAST(N'2017-03-26 14:49:51.000' AS DateTime), 1, CAST(N'2017-03-26 14:49:51.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (166, 6, 22, 8, N'', 1, 1, CAST(N'2017-03-26 14:49:51.000' AS DateTime), 1, CAST(N'2017-03-26 14:49:51.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (168, 6, 11, 10, N'', 1, 1, CAST(N'2017-03-26 14:49:52.000' AS DateTime), 1, CAST(N'2017-03-26 14:49:52.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (38, 6, 4, 1, N'', 1, 1, CAST(N'2017-03-26 14:21:07.000' AS DateTime), 1, CAST(N'2017-03-26 14:21:07.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (40, 6, 2, 1, N'', 1, 1, CAST(N'2017-03-26 14:23:34.000' AS DateTime), 1, CAST(N'2017-03-26 14:23:34.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (42, 6, 4, 1, N'', 1, 1, CAST(N'2017-03-26 14:23:34.000' AS DateTime), 1, CAST(N'2017-03-26 14:23:34.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (44, 6, 30, 1, N'', 1, 1, CAST(N'2017-03-26 14:23:35.000' AS DateTime), 1, CAST(N'2017-03-26 14:23:35.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (49, 6, 25, 23, N'', 1, 1, CAST(N'2017-03-26 14:23:35.000' AS DateTime), 1, CAST(N'2017-03-26 14:23:35.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (51, 6, 27, 23, N'', 1, 1, CAST(N'2017-03-26 14:23:35.000' AS DateTime), 1, CAST(N'2017-03-26 14:23:35.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (56, 6, 12, 10, N'', 1, 1, CAST(N'2017-03-26 14:23:36.000' AS DateTime), 1, CAST(N'2017-03-26 14:23:36.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (58, 6, 14, 10, N'', 1, 1, CAST(N'2017-03-26 14:23:36.000' AS DateTime), 1, CAST(N'2017-03-26 14:23:36.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (63, 6, 20, 19, N'', 1, 1, CAST(N'2017-03-26 14:23:36.000' AS DateTime), 1, CAST(N'2017-03-26 14:23:36.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (69, 6, 5, 1, N'', 1, 1, CAST(N'2017-03-26 14:35:43.000' AS DateTime), 1, CAST(N'2017-03-26 14:35:43.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (71, 6, 31, 1, N'', 1, 1, CAST(N'2017-03-26 14:35:43.000' AS DateTime), 1, CAST(N'2017-03-26 14:35:43.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (73, 6, 8, 0, N'', 1, 1, CAST(N'2017-03-26 14:35:43.000' AS DateTime), 1, CAST(N'2017-03-26 14:35:43.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (78, 6, 26, 23, N'', 1, 1, CAST(N'2017-03-26 14:35:44.000' AS DateTime), 1, CAST(N'2017-03-26 14:35:44.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (80, 6, 28, 23, N'', 1, 1, CAST(N'2017-03-26 14:35:44.000' AS DateTime), 1, CAST(N'2017-03-26 14:35:44.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (89, 6, 17, 16, N'', 1, 1, CAST(N'2017-03-26 14:35:44.000' AS DateTime), 1, CAST(N'2017-03-26 14:35:44.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (91, 6, 20, 19, N'', 1, 1, CAST(N'2017-03-26 14:35:44.000' AS DateTime), 1, CAST(N'2017-03-26 14:35:44.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (101, 6, 8, 0, N'', 1, 1, CAST(N'2017-03-26 14:37:15.000' AS DateTime), 1, CAST(N'2017-03-26 14:37:15.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (103, 6, 23, 9, N'', 1, 1, CAST(N'2017-03-26 14:37:15.000' AS DateTime), 1, CAST(N'2017-03-26 14:37:15.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (108, 6, 28, 23, N'', 1, 1, CAST(N'2017-03-26 14:37:16.000' AS DateTime), 1, CAST(N'2017-03-26 14:37:16.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (111, 6, 11, 10, N'', 1, 1, CAST(N'2017-03-26 14:37:16.000' AS DateTime), 1, CAST(N'2017-03-26 14:37:16.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (113, 6, 13, 10, N'', 1, 1, CAST(N'2017-03-26 14:37:16.000' AS DateTime), 1, CAST(N'2017-03-26 14:37:16.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (114, 6, 14, 10, N'', 1, 1, CAST(N'2017-03-26 14:37:16.000' AS DateTime), 1, CAST(N'2017-03-26 14:37:16.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (116, 6, 16, 0, N'', 1, 1, CAST(N'2017-03-26 14:37:16.000' AS DateTime), 1, CAST(N'2017-03-26 14:37:16.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (123, 6, 3, 1, N'', 1, 1, CAST(N'2017-03-26 14:38:14.000' AS DateTime), 1, CAST(N'2017-03-26 14:38:14.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (126, 6, 30, 1, N'', 1, 1, CAST(N'2017-03-26 14:38:14.000' AS DateTime), 1, CAST(N'2017-03-26 14:38:14.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (128, 6, 32, 1, N'', 1, 1, CAST(N'2017-03-26 14:38:14.000' AS DateTime), 1, CAST(N'2017-03-26 14:38:14.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (129, 6, 8, 0, N'', 1, 1, CAST(N'2017-03-26 14:38:14.000' AS DateTime), 1, CAST(N'2017-03-26 14:38:14.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (131, 6, 23, 9, N'', 1, 1, CAST(N'2017-03-26 14:38:14.000' AS DateTime), 1, CAST(N'2017-03-26 14:38:14.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (138, 6, 10, 0, N'', 1, 1, CAST(N'2017-03-26 14:38:14.000' AS DateTime), 1, CAST(N'2017-03-26 14:38:14.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (141, 6, 13, 10, N'', 1, 1, CAST(N'2017-03-26 14:38:14.000' AS DateTime), 1, CAST(N'2017-03-26 14:38:14.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (143, 6, 15, 10, N'', 1, 1, CAST(N'2017-03-26 14:38:15.000' AS DateTime), 1, CAST(N'2017-03-26 14:38:15.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (150, 6, 2, 1, N'', 1, 1, CAST(N'2017-03-26 14:49:50.000' AS DateTime), 1, CAST(N'2017-03-26 14:49:50.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (152, 6, 4, 1, N'', 1, 1, CAST(N'2017-03-26 14:49:50.000' AS DateTime), 1, CAST(N'2017-03-26 14:49:50.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (156, 6, 32, 1, N'', 1, 1, CAST(N'2017-03-26 14:49:50.000' AS DateTime), 1, CAST(N'2017-03-26 14:49:50.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (158, 6, 8, 0, N'', 1, 1, CAST(N'2017-03-26 14:49:51.000' AS DateTime), 1, CAST(N'2017-03-26 14:49:51.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (159, 6, 9, 8, N'', 1, 1, CAST(N'2017-03-26 14:49:51.000' AS DateTime), 1, CAST(N'2017-03-26 14:49:51.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (161, 6, 24, 23, N'', 1, 1, CAST(N'2017-03-26 14:49:51.000' AS DateTime), 1, CAST(N'2017-03-26 14:49:51.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (167, 6, 10, 0, N'', 1, 1, CAST(N'2017-03-26 14:49:51.000' AS DateTime), 1, CAST(N'2017-03-26 14:49:51.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (169, 6, 12, 10, N'', 1, 1, CAST(N'2017-03-26 14:49:52.000' AS DateTime), 1, CAST(N'2017-03-26 14:49:52.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (170, 6, 13, 10, N'', 1, 1, CAST(N'2017-03-26 14:49:52.000' AS DateTime), 1, CAST(N'2017-03-26 14:49:52.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (172, 6, 15, 10, N'', 1, 1, CAST(N'2017-03-26 14:49:52.000' AS DateTime), 1, CAST(N'2017-03-26 14:49:52.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (174, 6, 17, 16, N'', 1, 1, CAST(N'2017-03-26 14:49:52.000' AS DateTime), 1, CAST(N'2017-03-26 14:49:52.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (176, 6, 20, 19, N'', 1, 1, CAST(N'2017-03-26 14:49:52.000' AS DateTime), 1, CAST(N'2017-03-26 14:49:52.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (45, 6, 8, 0, N'', 1, 1, CAST(N'2017-03-26 14:23:35.000' AS DateTime), 1, CAST(N'2017-03-26 14:23:35.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (47, 6, 23, 9, N'', 1, 1, CAST(N'2017-03-26 14:23:35.000' AS DateTime), 1, CAST(N'2017-03-26 14:23:35.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (54, 6, 10, 0, N'', 1, 1, CAST(N'2017-03-26 14:23:36.000' AS DateTime), 1, CAST(N'2017-03-26 14:23:36.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (60, 6, 16, 0, N'', 1, 1, CAST(N'2017-03-26 14:23:36.000' AS DateTime), 1, CAST(N'2017-03-26 14:23:36.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (62, 6, 19, 0, N'', 1, 1, CAST(N'2017-03-26 14:23:36.000' AS DateTime), 1, CAST(N'2017-03-26 14:23:36.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (67, 6, 3, 1, N'', 1, 1, CAST(N'2017-03-26 14:35:43.000' AS DateTime), 1, CAST(N'2017-03-26 14:35:43.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (70, 6, 30, 1, N'', 1, 1, CAST(N'2017-03-26 14:35:43.000' AS DateTime), 1, CAST(N'2017-03-26 14:35:43.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (74, 6, 9, 8, N'', 1, 1, CAST(N'2017-03-26 14:35:43.000' AS DateTime), 1, CAST(N'2017-03-26 14:35:43.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (76, 6, 24, 23, N'', 1, 1, CAST(N'2017-03-26 14:35:43.000' AS DateTime), 1, CAST(N'2017-03-26 14:35:43.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (83, 6, 11, 10, N'', 1, 1, CAST(N'2017-03-26 14:35:44.000' AS DateTime), 1, CAST(N'2017-03-26 14:35:44.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (85, 6, 13, 10, N'', 1, 1, CAST(N'2017-03-26 14:35:44.000' AS DateTime), 1, CAST(N'2017-03-26 14:35:44.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (86, 6, 14, 10, N'', 1, 1, CAST(N'2017-03-26 14:35:44.000' AS DateTime), 1, CAST(N'2017-03-26 14:35:44.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (94, 6, 2, 1, N'', 1, 1, CAST(N'2017-03-26 14:37:15.000' AS DateTime), 1, CAST(N'2017-03-26 14:37:15.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (98, 6, 30, 1, N'', 1, 1, CAST(N'2017-03-26 14:37:15.000' AS DateTime), 1, CAST(N'2017-03-26 14:37:15.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (105, 6, 25, 23, N'', 1, 1, CAST(N'2017-03-26 14:37:16.000' AS DateTime), 1, CAST(N'2017-03-26 14:37:16.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (107, 6, 27, 23, N'', 1, 1, CAST(N'2017-03-26 14:37:16.000' AS DateTime), 1, CAST(N'2017-03-26 14:37:16.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (118, 6, 19, 0, N'', 1, 1, CAST(N'2017-03-26 14:37:17.000' AS DateTime), 1, CAST(N'2017-03-26 14:37:17.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (120, 6, 21, 19, N'', 1, 1, CAST(N'2017-03-26 14:37:17.000' AS DateTime), 1, CAST(N'2017-03-26 14:37:17.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (122, 6, 2, 1, N'', 1, 1, CAST(N'2017-03-26 14:38:14.000' AS DateTime), 1, CAST(N'2017-03-26 14:38:14.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (133, 6, 25, 23, N'', 1, 1, CAST(N'2017-03-26 14:38:14.000' AS DateTime), 1, CAST(N'2017-03-26 14:38:14.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (135, 6, 27, 23, N'', 1, 1, CAST(N'2017-03-26 14:38:14.000' AS DateTime), 1, CAST(N'2017-03-26 14:38:14.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (139, 6, 11, 10, N'', 1, 1, CAST(N'2017-03-26 14:38:14.000' AS DateTime), 1, CAST(N'2017-03-26 14:38:14.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (145, 6, 17, 16, N'', 1, 1, CAST(N'2017-03-26 14:38:15.000' AS DateTime), 1, CAST(N'2017-03-26 14:38:15.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (147, 6, 20, 19, N'', 1, 1, CAST(N'2017-03-26 14:38:15.000' AS DateTime), 1, CAST(N'2017-03-26 14:38:15.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (149, 6, 1, 0, N'', 1, 1, CAST(N'2017-03-26 14:49:50.000' AS DateTime), 1, CAST(N'2017-03-26 14:49:50.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (153, 6, 5, 1, N'', 1, 1, CAST(N'2017-03-26 14:49:50.000' AS DateTime), 1, CAST(N'2017-03-26 14:49:50.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (164, 6, 27, 23, N'', 1, 1, CAST(N'2017-03-26 14:49:51.000' AS DateTime), 1, CAST(N'2017-03-26 14:49:51.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (171, 6, 14, 10, N'', 1, 1, CAST(N'2017-03-26 14:49:52.000' AS DateTime), 1, CAST(N'2017-03-26 14:49:52.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (173, 6, 16, 0, N'', 1, 1, CAST(N'2017-03-26 14:49:52.000' AS DateTime), 1, CAST(N'2017-03-26 14:49:52.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (177, 6, 21, 19, N'', 1, 1, CAST(N'2017-03-26 14:49:52.000' AS DateTime), 1, CAST(N'2017-03-26 14:49:52.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (175, 6, 19, 0, N'', 1, 1, CAST(N'2017-03-26 14:49:52.000' AS DateTime), 1, CAST(N'2017-03-26 14:49:52.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (182, 2, 24, 23, N'', 1, 1, CAST(N'2017-07-21 05:52:29.000' AS DateTime), 1, CAST(N'2017-07-21 05:52:29.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (183, 2, 25, 23, N'', 1, 1, CAST(N'2017-07-21 05:52:29.000' AS DateTime), 1, CAST(N'2017-07-21 05:52:29.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (184, 2, 26, 23, N'', 1, 1, CAST(N'2017-07-21 05:52:29.000' AS DateTime), 1, CAST(N'2017-07-21 05:52:29.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (185, 2, 27, 23, N'', 1, 1, CAST(N'2017-07-21 05:52:29.000' AS DateTime), 1, CAST(N'2017-07-21 05:52:29.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (186, 2, 28, 23, N'', 1, 1, CAST(N'2017-07-21 05:52:29.000' AS DateTime), 1, CAST(N'2017-07-21 05:52:29.000' AS DateTime))
GO
INSERT [dbo].[UserRights] ([Id], [UserTypeId], [MenuId], [MenuParentId], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (187, 2, 22, 8, N'', 1, 1, CAST(N'2017-07-21 05:52:29.000' AS DateTime), 1, CAST(N'2017-07-21 05:52:29.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[UserRights] OFF
GO
SET IDENTITY_INSERT [dbo].[UserTable] ON 

GO
INSERT [dbo].[UserTable] ([Id], [LoginId], [Password], [Name], [Email], [Mobile], [UserType], [UserTypeName], [Address], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (1, N'shobhit', N'123', N'shobhit', N'', N'', 2, N'Manager', N'', N'', 0, 4, CAST(N'2016-12-30 14:37:08.000' AS DateTime), 4, CAST(N'2016-12-30 14:37:08.000' AS DateTime))
GO
INSERT [dbo].[UserTable] ([Id], [LoginId], [Password], [Name], [Email], [Mobile], [UserType], [UserTypeName], [Address], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (2, N'salesuser1', N'123', N'salesuser1', N'', N'', 3, N'SalesPerson', N'', N'', 0, 4, CAST(N'2016-12-30 14:37:40.000' AS DateTime), 4, CAST(N'2016-12-30 14:37:40.000' AS DateTime))
GO
INSERT [dbo].[UserTable] ([Id], [LoginId], [Password], [Name], [Email], [Mobile], [UserType], [UserTypeName], [Address], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (3, N'admin', N'123', N'shobhit', N'', N'', 6, N'Admin', N'', N'', 0, 4, CAST(N'2016-12-30 15:38:36.000' AS DateTime), 4, CAST(N'2016-12-30 15:38:36.000' AS DateTime))
GO
INSERT [dbo].[UserTable] ([Id], [LoginId], [Password], [Name], [Email], [Mobile], [UserType], [UserTypeName], [Address], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (4, N'Shobhit', N'123', N'Aachamn', N'chandan@gmail.com', N'9312246657', 1, N'Administrator', N'Greater Noida UP', N'', 1, 1, CAST(N'2016-08-12 23:50:00.000' AS DateTime), 1, CAST(N'2016-08-12 23:50:00.000' AS DateTime))
GO
INSERT [dbo].[UserTable] ([Id], [LoginId], [Password], [Name], [Email], [Mobile], [UserType], [UserTypeName], [Address], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (5, N'sales1', N'123', N'sales1', N'', N'', 3, N'SalesPerson', N'', N'', 0, 3, CAST(N'2017-03-26 14:44:15.000' AS DateTime), 3, CAST(N'2017-03-26 14:44:15.000' AS DateTime))
GO
INSERT [dbo].[UserTable] ([Id], [LoginId], [Password], [Name], [Email], [Mobile], [UserType], [UserTypeName], [Address], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (6, N'Manager1', N'1212', N'Dinesh', N'', N'', 2, N'Manager', N'', N'', 0, 4, CAST(N'2017-07-16 06:54:56.000' AS DateTime), 4, CAST(N'2017-07-16 06:54:56.000' AS DateTime))
GO
INSERT [dbo].[UserTable] ([Id], [LoginId], [Password], [Name], [Email], [Mobile], [UserType], [UserTypeName], [Address], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (7, N'Manager2', N'1212', N'Aachman', N'', N'', 2, N'Manager', N'', N'', 0, 4, CAST(N'2017-07-16 06:55:19.000' AS DateTime), 4, CAST(N'2017-07-16 06:55:19.000' AS DateTime))
GO
INSERT [dbo].[UserTable] ([Id], [LoginId], [Password], [Name], [Email], [Mobile], [UserType], [UserTypeName], [Address], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (8, N'Dinesh', N'1212', N'Dinesh', N'', N'', 2, N'Manager', N'', N'', 0, 4, CAST(N'2017-07-21 09:43:19.000' AS DateTime), 4, CAST(N'2017-07-21 09:43:19.000' AS DateTime))
GO
INSERT [dbo].[UserTable] ([Id], [LoginId], [Password], [Name], [Email], [Mobile], [UserType], [UserTypeName], [Address], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (9, N'Ravi', N'1212', N'Ravi', N'', N'', 2, N'Manager', N'', N'', 0, 4, CAST(N'2017-07-21 05:59:28.000' AS DateTime), 4, CAST(N'2017-07-21 05:59:28.000' AS DateTime))
GO
INSERT [dbo].[UserTable] ([Id], [LoginId], [Password], [Name], [Email], [Mobile], [UserType], [UserTypeName], [Address], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (10, N'Dinesh', N'123', N'Dinesh', N'', N'', 2, N'Manager', N'', N'', 1, 4, CAST(N'2017-07-21 06:07:42.000' AS DateTime), 4, CAST(N'2017-07-21 06:07:42.000' AS DateTime))
GO
INSERT [dbo].[UserTable] ([Id], [LoginId], [Password], [Name], [Email], [Mobile], [UserType], [UserTypeName], [Address], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (11, N'Ravi', N'55555', N'Ravi', N'', N'', 2, N'Manager', N'', N'', 1, 4, CAST(N'2017-07-21 06:08:10.000' AS DateTime), 4, CAST(N'2017-07-21 06:08:10.000' AS DateTime))
GO
INSERT [dbo].[UserTable] ([Id], [LoginId], [Password], [Name], [Email], [Mobile], [UserType], [UserTypeName], [Address], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (12, N'Neeraj', N'4064401', N'Neeraj', N'', N'', 3, N'SalesPerson', N'', N'', 1, 4, CAST(N'2017-11-01 11:32:56.000' AS DateTime), 4, CAST(N'2017-11-01 11:32:56.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[UserTable] OFF
GO
SET IDENTITY_INSERT [dbo].[UserTypes] ON 

GO
INSERT [dbo].[UserTypes] ([ID], [Name], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (1, N'Administrator', N'System Administrator', 1, 1, CAST(N'2016-08-12 20:43:00.000' AS DateTime), 1, CAST(N'2016-08-12 20:43:00.000' AS DateTime))
GO
INSERT [dbo].[UserTypes] ([ID], [Name], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (2, N'Manager', N'Manager', 1, 1, CAST(N'2016-08-12 21:00:00.000' AS DateTime), 1, CAST(N'2016-08-12 21:00:00.000' AS DateTime))
GO
INSERT [dbo].[UserTypes] ([ID], [Name], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (3, N'SalesPerson', N'Sales Person', 1, 1, CAST(N'2016-08-12 21:01:00.000' AS DateTime), 1, CAST(N'2016-08-12 21:01:00.000' AS DateTime))
GO
INSERT [dbo].[UserTypes] ([ID], [Name], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (4, N'Account', N'Account User', 1, 1, CAST(N'2016-09-12 19:11:00.000' AS DateTime), 1, CAST(N'2016-12-09 19:11:00.000' AS DateTime))
GO
INSERT [dbo].[UserTypes] ([ID], [Name], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (5, N'Test', N'test', 0, 4, CAST(N'2016-12-19 12:55:27.000' AS DateTime), 4, CAST(N'2016-12-19 12:55:27.000' AS DateTime))
GO
INSERT [dbo].[UserTypes] ([ID], [Name], [Remarks], [IsValid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (6, N'Admin', N'Local Admin', 1, 3, CAST(N'2017-03-26 13:52:14.000' AS DateTime), 3, CAST(N'2017-03-26 13:52:14.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[UserTypes] OFF
GO
/****** Object:  StoredProcedure [dbo].[GetDataForPrintInvoice]    Script Date: 4/4/2021 5:40:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetDataForPrintInvoice]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[GetDataForPrintInvoice] AS' 
END
GO

--GetDataForPrintInvoice '1001'
ALTER proc [dbo].[GetDataForPrintInvoice]
@BillNumber varchar(10)
as
begin
DECLARE @cols AS NVARCHAR(MAX),
@query  AS NVARCHAR(MAX)
select @cols = STUFF((SELECT distinct  ',' + QUOTENAME(Name) 
                        FROM Taxes inner join TaxAppliedOnItem on Taxes.ID=TaxAppliedOnItem.TaxId where Taxes.IsValid=1
                        --and ItemMasterId in (select ItemId from SalesDetails where BillNumber=@BillNumber)
                FOR XML PATH(''), TYPE
                ).value('.', 'NVARCHAR(MAX)') 
            ,1,1,'') 
			--set @cols='CGST,SGST'
SELECT @query ='
select * from
(select SaleMasterId,SalesDetailsId,BillNumber,TableNumber,Amount,RoundAmount,Taxes,TotalAmount,Discount
,Difference,Name,Qty,ItemWiseAmount,ItemPrice,LoggedUser,createddate
  --,Taxes.Name as TexName  
  ,VatAmount ,TexName,(select Rate from Taxes where IsValid=1 and Name=''sgst'') as SGSCTRate,(select Rate from Taxes where IsValid=1 and Name=''cgst'') as CGSTRate
   from
(SELECT distinct sd.SaleMasterId,sd.ID as SalesDetailsId , sm.BillNumber, sm.TableNumber,
 sm.Amount, sm.RoundAmount,sm.Taxes,sm.TotalAmount, sm.Discount,sm.Difference, ItemMaster.Name,
  sd.Qty, sd.Amount AS ItemWiseAmount, sd.ItemPrice,UserTable.Name AS LoggedUser
  --,Taxes.Name as TexName
  ,std.TaxId
  ,isnull(std.Amount,0) as VatAmount  ,sm.createddate
  FROM SalesMaster as sm
   INNER JOIN SalesDetails as sd ON sm.ID = sd.SaleMasterId 
   INNER JOIN ItemMaster ON sd.ItemId = ItemMaster.ID 
   INNER JOIN UserTable ON sm.CreatedBy = UserTable.Id
   --inner join TaxAppliedOnItem on ItemMaster.ID = TaxAppliedOnItem.ItemMasterId
   --inner join Taxes on Taxes.ID= TaxAppliedOnItem.TaxId
   inner join SalesTaxDetails std on std.SalesDetailsId=sd.ID
   where sm.BillNumber='''+@BillNumber+''') t1
   inner join (  select distinct Taxes.Name as TexName,Taxes.ID as TaxId from SalesDetails sd inner join ItemMaster i on sd.ItemId=i.ID
   inner join TaxAppliedOnItem tai on i.ID=tai.ItemMasterId
   inner join Taxes on Taxes.ID= tai.TaxId
   inner join SalesTaxDetails std on std.SalesDetailsId=sd.ID
   where sd.BillNumber='''+@BillNumber+''') t2 on t1.TaxId =t2.TaxId
   ) p
   PIVOT
  ( 
  sum(VatAmount) FOR TexName IN ('+@cols+')
  ) AS pv1'
  print @query
  EXEC SP_EXECUTESQL @query
end

GO
/****** Object:  StoredProcedure [dbo].[GetDataForPrintInvoice_240617]    Script Date: 4/4/2021 5:40:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetDataForPrintInvoice_240617]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[GetDataForPrintInvoice_240617] AS' 
END
GO

ALTER proc [dbo].[GetDataForPrintInvoice_240617]
@BillNumber varchar
as
begin
DECLARE @cols AS NVARCHAR(MAX),
@query  AS NVARCHAR(MAX)
select @cols = STUFF((SELECT distinct  ',' + QUOTENAME(Name) 
                        FROM Taxes inner join TaxAppliedOnItem on Taxes.ID=TaxAppliedOnItem.TaxId where Taxes.IsValid=1
                        and ItemMasterId in (select ItemId from SalesDetails where BillNumber=@BillNumber)
                FOR XML PATH(''), TYPE
                ).value('.', 'NVARCHAR(MAX)') 
            ,1,1,'') 
SELECT @query ='
select * from
(SELECT distinct sd.SaleMasterId,sd.ID as SalesDetailsId , sm.BillNumber, sm.TableNumber,
 sm.Amount, sm.RoundAmount,sm.Taxes,sm.TotalAmount, sm.Discount,sm.Difference, ItemMaster.Name,
  sd.Qty, sd.Amount AS ItemWiseAmount, sd.ItemPrice,UserTable.Name AS LoggedUser
  ,Taxes.Name as TexName 
  ,std.Amount as VatAmount
  FROM SalesMaster as sm
   INNER JOIN SalesDetails as sd ON sm.ID = sd.SaleMasterId INNER JOIN ItemMaster ON sd.ItemId = ItemMaster.ID 
   INNER JOIN UserTable ON sm.CreatedBy = UserTable.Id
   inner join TaxAppliedOnItem on ItemMaster.ID = TaxAppliedOnItem.ItemMasterId
   inner join Taxes on Taxes.ID= TaxAppliedOnItem.TaxId
   inner join SalesTaxDetails std on std.SalesDetailsId=sd.ID
   where sm.BillNumber='''+@BillNumber+'''
   ) p
   PIVOT
  ( 
  sum(VatAmount) FOR TexName IN ('+@cols+')
  ) AS pv1'
  print @query
  EXEC SP_EXECUTESQL @query
end


GO
/****** Object:  StoredProcedure [dbo].[GetDataForPrintInvoice_27_06_17]    Script Date: 4/4/2021 5:40:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetDataForPrintInvoice_27_06_17]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[GetDataForPrintInvoice_27_06_17] AS' 
END
GO

-- GetDataForPrintInvoice '16'
ALTER proc [dbo].[GetDataForPrintInvoice_27_06_17]
@BillNumber varchar(10)
as
begin
DECLARE @cols AS NVARCHAR(MAX),
@query  AS NVARCHAR(MAX)
select @cols = STUFF((SELECT distinct  ',' + QUOTENAME(Name) 
                        FROM Taxes inner join TaxAppliedOnItem on Taxes.ID=TaxAppliedOnItem.TaxId where Taxes.IsValid=1
                        --and ItemMasterId in (select ItemId from SalesDetails where BillNumber=@BillNumber)
                FOR XML PATH(''), TYPE
                ).value('.', 'NVARCHAR(MAX)') 
            ,1,1,'') 
			--set @cols='CGST,SGST'
SELECT @query ='
select * from
(select SaleMasterId,SalesDetailsId,BillNumber,TableNumber,Amount,RoundAmount,Taxes,TotalAmount,Discount
,Difference,Name,Qty,ItemWiseAmount,ItemPrice,LoggedUser
  --,Taxes.Name as TexName  
  ,VatAmount ,TexName from
(SELECT distinct sd.SaleMasterId,sd.ID as SalesDetailsId , sm.BillNumber, sm.TableNumber,
 sm.Amount, sm.RoundAmount,sm.Taxes,sm.TotalAmount, sm.Discount,sm.Difference, ItemMaster.Name,
  sd.Qty, sd.Amount AS ItemWiseAmount, sd.ItemPrice,UserTable.Name AS LoggedUser
  --,Taxes.Name as TexName
  ,std.TaxId
  ,isnull(std.Amount,0) as VatAmount  
  FROM SalesMaster as sm
   INNER JOIN SalesDetails as sd ON sm.ID = sd.SaleMasterId 
   INNER JOIN ItemMaster ON sd.ItemId = ItemMaster.ID 
   INNER JOIN UserTable ON sm.CreatedBy = UserTable.Id
   --inner join TaxAppliedOnItem on ItemMaster.ID = TaxAppliedOnItem.ItemMasterId
   --inner join Taxes on Taxes.ID= TaxAppliedOnItem.TaxId
   inner join SalesTaxDetails std on std.SalesDetailsId=sd.ID
   where sm.BillNumber='''+@BillNumber+''') t1
   inner join (  select distinct Taxes.Name as TexName,Taxes.ID as TaxId from SalesDetails sd inner join ItemMaster i on sd.ItemId=i.ID
   inner join TaxAppliedOnItem tai on i.ID=tai.ItemMasterId
   inner join Taxes on Taxes.ID= tai.TaxId
   inner join SalesTaxDetails std on std.SalesDetailsId=sd.ID
   where sd.BillNumber='''+@BillNumber+''') t2 on t1.TaxId =t2.TaxId
   ) p
   PIVOT
  ( 
  sum(VatAmount) FOR TexName IN ('+@cols+')
  ) AS pv1'
  print @query
  EXEC SP_EXECUTESQL @query
end



GO
/****** Object:  StoredProcedure [dbo].[GetDataForSalesReport]    Script Date: 4/4/2021 5:40:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetDataForSalesReport]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[GetDataForSalesReport] AS' 
END
GO

--[GetDataForSalesReport_1Apr2019] '01/04/2019','01/04/2019'
--[GetDataForSalesReport] '01/04/2019','01/04/2019'
ALTER proc [dbo].[GetDataForSalesReport]
@FromDate varchar(20),
@ToDate varchar(20)
as
begin


IF EXISTS (select top 1 BillNumber from SalesMaster sm1 where sm1.CreatedDate between convert(datetime,@FromDate,103) and convert(datetime,@ToDate,103)+1)
begin
declare @fromBill varchar(10),@toBill varchar(10)
set @fromBill=(select cast(MIN(BillNumber) as varchar) from SalesMaster sm where sm.CreatedDate between convert(datetime,@FromDate,103) and convert(datetime,@ToDate,103)+1)
set @toBill=(select cast(MAX(BillNumber) as varchar) from SalesMaster sm where sm.CreatedDate between convert(datetime,@FromDate,103) and convert(datetime,@ToDate,103)+1);



with Tempt (FromDate,ToDate,InvoiceFT,Paymentmode, TotalfoodSale, CGST,SGST,TotalAmount,RoundOffAmount,SGSCTRate,CGSTRate) 
As
(

select @FromDate FromDate,@ToDate ToDate,'From ' + @fromBill +' To ' + @toBill InvoiceFT, '1' PaymentMode,
isnull(SUM(TotalfoodSale),0) TotalfoodSale,isnull(SUM(CGST),0)CGST,isnull(SUM(SGST),0)SGST,isnull(SUM(TotalAmount),0)TotalAmount,isnull(SUM(RoundOffAmount),0)RoundOffAmount,
(select Rate from Taxes where IsValid=1 and Name='sgst') as SGSCTRate,(select Rate from Taxes where IsValid=1 and Name='cgst') as CGSTRate
from(
select
SUM(Amount) TotalfoodSale,SUM(isnull(cgst,0)) CGST,SUM(isnull(sgst,0)) SGST,(SUM(Amount)+SUM(isnull(cgst,0))+SUM(isnull(sgst,0))) TotalAmount
,(select SUM(sm1.Difference) from SalesMaster sm1 
where sm1.PaymentMode='CASH' and sm1.Status=4 and sm1.CreatedDate between convert(datetime,@FromDate,103) and convert(datetime,@ToDate,103)+1) as RoundOffAmount
 from(
SELECT distinct sm.PaymentMode, sm.BillNumber,sd.Amount,sm.RoundAmount,sm.Difference,sdt.Amount TaxAmount, Taxes.Name,sd.CreatedDate
FROM SalesMaster sm
inner join SalesDetails sd on sm.ID=sd.SaleMasterId
inner join SalesTaxDetails sdt on sd.ID=sdt.SalesDetailsId
inner join Taxes on Taxes.ID=sdt.TaxId
where sm.PaymentMode='CASH' and sm.Status=4 and sm.CreatedDate between convert(datetime,@FromDate,103) and convert(datetime,@ToDate,103)+1
)P
 PIVOT
  ( 
  sum(TaxAmount) FOR Name IN (sgst,cgst)
  ) AS pv1
  )t1
  
  union
  
  select @FromDate FromDate,@ToDate ToDate,'From ' + @fromBill +' To ' + @toBill InvoiceFT, '2' PaymentMode,
isnull(SUM(TotalfoodSale),0) TotalfoodSale,isnull(SUM(CGST),0)CGST,isnull(SUM(SGST),0)SGST,isnull(SUM(TotalAmount),0)TotalAmount,isnull(SUM(RoundOffAmount),0)RoundOffAmount,
(select Rate from Taxes where IsValid=1 and Name='sgst') as SGSCTRate,(select Rate from Taxes where IsValid=1 and Name='cgst') as CGSTRate
from(
select
SUM(Amount) TotalfoodSale,SUM(isnull(cgst,0)) CGST,SUM(isnull(sgst,0)) SGST,(SUM(Amount)+SUM(isnull(cgst,0))+SUM(isnull(sgst,0))) TotalAmount
,(select SUM(sm1.Difference) from SalesMaster sm1 
where sm1.PaymentMode='CARD' and sm1.Status=4 and sm1.CreatedDate between convert(datetime,@FromDate,103) and convert(datetime,@ToDate,103)+1) as RoundOffAmount
 from(
SELECT distinct sm.PaymentMode, sm.BillNumber,sd.Amount,sm.RoundAmount,sm.Difference,sdt.Amount TaxAmount, Taxes.Name,sd.CreatedDate
FROM SalesMaster sm
inner join SalesDetails sd on sm.ID=sd.SaleMasterId
inner join SalesTaxDetails sdt on sd.ID=sdt.SalesDetailsId
inner join Taxes on Taxes.ID=sdt.TaxId
where sm.PaymentMode='CARD' and sm.Status=4 and sm.CreatedDate between convert(datetime,@FromDate,103) and convert(datetime,@ToDate,103)+1
)P
 PIVOT
  ( 
  sum(TaxAmount) FOR Name IN (sgst,cgst)
  ) AS pv1
  )t1
  
  union
  
  select @FromDate FromDate,@ToDate ToDate,'From ' + @fromBill +' To ' + @toBill InvoiceFT, '3' PaymentMode,
isnull(SUM(TotalfoodSale),0) TotalfoodSale,isnull(SUM(CGST),0)CGST,isnull(SUM(SGST),0)SGST,isnull(SUM(TotalAmount),0)TotalAmount,isnull(SUM(RoundOffAmount),0)RoundOffAmount,
(select Rate from Taxes where IsValid=1 and Name='sgst') as SGSCTRate,(select Rate from Taxes where IsValid=1 and Name='cgst') as CGSTRate
from(
select
SUM(Amount) TotalfoodSale,SUM(isnull(cgst,0)) CGST,SUM(isnull(sgst,0)) SGST,(SUM(Amount)+SUM(isnull(cgst,0))+SUM(isnull(sgst,0))) TotalAmount
,(select SUM(sm1.Difference) from SalesMaster sm1 
where sm1.PaymentMode='CREDIT' and sm1.Status=4 and sm1.CreatedDate between convert(datetime,@FromDate,103) and convert(datetime,@ToDate,103)+1) as RoundOffAmount
 from(
SELECT distinct sm.PaymentMode, sm.BillNumber,sd.Amount,sm.RoundAmount,sm.Difference,sdt.Amount TaxAmount, Taxes.Name,sd.CreatedDate
FROM SalesMaster sm
inner join SalesDetails sd on sm.ID=sd.SaleMasterId
inner join SalesTaxDetails sdt on sd.ID=sdt.SalesDetailsId
inner join Taxes on Taxes.ID=sdt.TaxId
where sm.PaymentMode='CREDIT' and sm.Status=4 and sm.CreatedDate between convert(datetime,@FromDate,103) and convert(datetime,@ToDate,103)+1
)P
 PIVOT
  ( 
  sum(TaxAmount) FOR Name IN (sgst,cgst)
  ) AS pv1
  )t1
  union
  
 select @FromDate FromDate,@ToDate ToDate,'From ' + @fromBill +' To ' + @toBill InvoiceFT, '4' PaymentMode,
isnull(SUM(TotalfoodSale),0) TotalfoodSale,isnull(SUM(CGST),0)CGST,isnull(SUM(SGST),0)SGST,isnull(SUM(TotalAmount),0)TotalAmount,isnull(SUM(RoundOffAmount),0)RoundOffAmount,
(select Rate from Taxes where IsValid=1 and Name='sgst') as SGSCTRate,(select Rate from Taxes where IsValid=1 and Name='cgst') as CGSTRate
from(
select
SUM(Amount) TotalfoodSale,SUM(isnull(cgst,0)) CGST,SUM(isnull(sgst,0)) SGST,(SUM(Amount)+SUM(isnull(cgst,0))+SUM(isnull(sgst,0))) TotalAmount
,(select SUM(sm1.Difference) from SalesMaster sm1 
where sm1.Status=6 and sm1.CreatedDate between convert(datetime,@FromDate,103) and convert(datetime,@ToDate,103)+1) as RoundOffAmount
 from(
SELECT distinct sm.PaymentMode, sm.BillNumber,sd.Amount,sm.RoundAmount,sm.Difference,sdt.Amount TaxAmount, Taxes.Name,sd.CreatedDate
FROM SalesMaster sm
inner join SalesDetails sd on sm.ID=sd.SaleMasterId
inner join SalesTaxDetails sdt on sd.ID=sdt.SalesDetailsId
inner join Taxes on Taxes.ID=sdt.TaxId
where sm.Status=6 and sm.CreatedDate between convert(datetime,@FromDate,103) and convert(datetime,@ToDate,103)+1
)P
 PIVOT
  ( 
  sum(TaxAmount) FOR Name IN (sgst,cgst)
  ) AS pv1
  )t1 where isnull(t1.TotalfoodSale,0) <> 0
  
  union
  
select @FromDate FromDate,@ToDate ToDate,'From ' + @fromBill +' To ' + @toBill InvoiceFT, '5'PaymentMode,
isnull(SUM(TotalfoodSale),0) TotalfoodSale,isnull(SUM(CGST),0)CGST,isnull(SUM(SGST),0)SGST,isnull(SUM(TotalAmount),0)TotalAmount,isnull(SUM(RoundOffAmount),0)RoundOffAmount,
(select Rate from Taxes where IsValid=1 and Name='sgst') as SGSCTRate,(select Rate from Taxes where IsValid=1 and Name='cgst') as CGSTRate
from(
select
SUM(Amount) TotalfoodSale,SUM(isnull(cgst,0)) CGST,SUM(isnull(sgst,0)) SGST,(SUM(Amount)+SUM(isnull(cgst,0))+SUM(isnull(sgst,0))) TotalAmount
,(select SUM(sm1.Difference) from SalesMaster sm1 
where sm1.Status=4 and sm1.CreatedDate between convert(datetime,@FromDate,103) and convert(datetime,@ToDate,103)+1) as RoundOffAmount
 from(
SELECT distinct sm.PaymentMode, sm.BillNumber,sd.Amount,sm.RoundAmount,sm.Difference,sdt.Amount TaxAmount, Taxes.Name,sd.CreatedDate
FROM SalesMaster sm
inner join SalesDetails sd on sm.ID=sd.SaleMasterId
inner join SalesTaxDetails sdt on sd.ID=sdt.SalesDetailsId
inner join Taxes on Taxes.ID=sdt.TaxId
where sm.Status=4 and sm.CreatedDate between convert(datetime,@FromDate,103) and convert(datetime,@ToDate,103)+1
)P
 PIVOT
  ( 
  sum(TaxAmount) FOR Name IN (sgst,cgst)
  ) AS pv1
  )t1

 
  
  )
  select * from Tempt where TotalfoodSale > 0
  end 
  else
  begin
  select * from SalesMaster where 1=2
  end



end

GO
/****** Object:  StoredProcedure [dbo].[P_GetUserRights]    Script Date: 4/4/2021 5:40:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_GetUserRights]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_GetUserRights] AS' 
END
GO
ALTER procedure [dbo].[P_GetUserRights]
(
@UserId bigint,
@UserTypeId bigint,
@val int=0 output
)
as
begin
	select ur.MenuId,ur.MenuParentId,ms.Name as MenuName from UserRights ur inner join UserTypes utype on ur.UserTypeId=utype.ID
inner join UserTable ut on utype.ID = ut.UserType inner join MenuAndSubMenu ms on ms.ID=ur.MenuId
where ut.Id=@UserId and ut.UserType=@UserTypeId and ut.IsValid=1 and ur.IsValid=1 and utype.IsValid=1 and ms.IsValid=1
	end



GO
