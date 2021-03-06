USE [master]
GO
/****** Object:  Database [SpicySpoon]    Script Date: 03-12-2016 9:08:30 AM ******/
CREATE DATABASE [SpicySpoon] ON  PRIMARY 
( NAME = N'SAIISYS(AIMS)', FILENAME = N'D:\Data\Client Data\SpicySpoon db\SAIISYS(AIMS).mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SAIISYS(AIMS)_log', FILENAME = N'D:\Data\Client Data\SpicySpoon db\SAIISYS(AIMS)_log.ldf' , SIZE = 3136KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SpicySpoon] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SpicySpoon].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SpicySpoon] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SpicySpoon] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SpicySpoon] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SpicySpoon] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SpicySpoon] SET ARITHABORT OFF 
GO
ALTER DATABASE [SpicySpoon] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [SpicySpoon] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [SpicySpoon] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SpicySpoon] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SpicySpoon] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SpicySpoon] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SpicySpoon] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SpicySpoon] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SpicySpoon] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SpicySpoon] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SpicySpoon] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SpicySpoon] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SpicySpoon] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SpicySpoon] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SpicySpoon] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SpicySpoon] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SpicySpoon] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SpicySpoon] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SpicySpoon] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SpicySpoon] SET  MULTI_USER 
GO
ALTER DATABASE [SpicySpoon] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SpicySpoon] SET DB_CHAINING OFF 
GO
USE [SpicySpoon]
GO
/****** Object:  StoredProcedure [dbo].[Sp_CategoryMaster_Insert]    Script Date: 03-12-2016 9:08:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[Sp_CategoryMaster_Insert]
(
@Name Varchar(200),
@Print int,
@LogIn varchar(50),
@LogDate datetime,
@val int=0 output
)
as
	Declare 
		@Prefix varchar(50),
		@Count	Bigint
		
begin
	if not exists(select * from tbl_CategoryMaster Where Name=@Name)
	begin
		
		Set @Count= (Select IsNull(Max(Convert(int,Code)),0)+1 From  tbl_CategoryMaster)
		
		Insert into tbl_CategoryMaster(Code,Name,[Print],LogIn,LogDate)
		values(@Count,@Name,@Print,@LogIn,@LogDate)
		set @val=1
	end
    else
		set @val=2
	end













GO
/****** Object:  StoredProcedure [dbo].[sp_categoryMaster_select]    Script Date: 03-12-2016 9:08:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_categoryMaster_select]
	AS
	select * from Tbl_CategoryMaster


GO
/****** Object:  StoredProcedure [dbo].[Sp_CategoryMaster_Update]    Script Date: 03-12-2016 9:08:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create procedure [dbo].[Sp_CategoryMaster_Update]
(
@Code varchar(50),
@Name Varchar(200),
@Print int,
@LogIn varchar(50),
@val int=0 output
)
as
begin
	if  not exists(select * from tbl_CategoryMaster where Code<>@Code and Name=@Name)
	begin
		update tbl_CategoryMaster set
		Name=@Name,
		LogIn=@LogIn,
		[Print] = @Print
		Where Code=@Code 
		set @val=1
	end
    else
		set @val=2
	end










GO
/****** Object:  StoredProcedure [dbo].[Sp_Login_Select]    Script Date: 03-12-2016 9:08:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[Sp_Login_Select]
as
select * from Tbl_Login
GO
/****** Object:  StoredProcedure [dbo].[sp_Login_update]    Script Date: 03-12-2016 9:08:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[sp_Login_update]
( @ID int,
	@Password varchar(200),
	@val int = 0 output
)
as
begin
update Tbl_Login set 
password = @Password where ID = @ID
set @val = 1

end
GO
/****** Object:  Table [dbo].[Mst_Info]    Script Date: 03-12-2016 9:08:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Mst_Info](
	[Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[FirmName] [varchar](100) NULL,
	[Address] [varchar](500) NULL,
	[HeadOfficeAddress] [varchar](500) NULL,
	[PhoneNo] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[TinNo] [varchar](50) NULL,
	[SaletaxNo] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Mst_Item]    Script Date: 03-12-2016 9:08:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Mst_Item](
	[ItemCode] [int] NOT NULL,
	[Counter_Code] [varchar](50) NULL,
	[ItemName] [varchar](100) NULL,
	[INameHindi] [nvarchar](100) NULL,
	[Rate] [bigint] NULL,
	[Discount] [float] NULL,
	[LogIn] [varchar](50) NULL,
	[LogDate] [datetime] NULL,
 CONSTRAINT [PK_Mst_Item] PRIMARY KEY CLUSTERED 
(
	[ItemCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Mst_Tax]    Script Date: 03-12-2016 9:08:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Mst_Tax](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tax_name] [varchar](100) NULL,
	[TaxPer] [decimal](18, 2) NULL,
	[Active] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tbl_CategoryMaster]    Script Date: 03-12-2016 9:08:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_CategoryMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Print] [int] NOT NULL,
	[LogIn] [varchar](50) NOT NULL,
	[LogDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Tbl_CategoryMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tbl_Login]    Script Date: 03-12-2016 9:08:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_Login](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserType] [varchar](50) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[restriction] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tokan_Details]    Script Date: 03-12-2016 9:08:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tokan_Details](
	[Tokan_No] [bigint] NULL,
	[Cat_Code] [int] NULL,
	[Cat_Name] [varchar](100) NULL,
	[Item_Code] [bigint] NULL,
	[Item_Name] [varchar](100) NULL,
	[Qty] [bigint] NULL,
	[Rate] [int] NULL,
	[Amount] [float] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tokan_Master]    Script Date: 03-12-2016 9:08:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tokan_Master](
	[TK_No] [bigint] NOT NULL,
	[Tk_Date] [datetime] NULL,
	[Total_amt] [float] NULL,
	[LogIn] [varchar](50) NULL,
	[LoginDate] [datetime] NULL,
 CONSTRAINT [PK_Tokan_Master] PRIMARY KEY CLUSTERED 
(
	[TK_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tran_Sale_Det]    Script Date: 03-12-2016 9:08:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tran_Sale_Det](
	[SaleDet_SrNo] [numeric](18, 0) NOT NULL,
	[Sale_Id] [numeric](18, 0) NULL,
	[Item_Id] [numeric](18, 0) NULL,
	[Qty] [numeric](18, 2) NULL,
	[Rate] [numeric](18, 2) NULL,
	[Amount] [numeric](18, 2) NULL,
	[ReturnQty] [numeric](18, 2) NULL,
	[ReturnDate] [datetime] NULL,
	[ReturnRemark] [varchar](500) NULL,
	[PCK] [varchar](50) NULL,
 CONSTRAINT [PK_Tran_Sale_Det] PRIMARY KEY CLUSTERED 
(
	[SaleDet_SrNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tran_Sale_Mas]    Script Date: 03-12-2016 9:08:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tran_Sale_Mas](
	[Sale_Id] [bigint] NOT NULL,
	[Sale_No] [varchar](50) NOT NULL,
	[Fin_Year] [varchar](50) NOT NULL,
	[Sale_Date] [datetime] NULL,
	[TaxId] [int] NULL,
	[TaxPer] [numeric](18, 2) NULL,
	[TaxAmount] [numeric](18, 0) NULL,
	[Total_Amt] [numeric](18, 2) NULL,
	[username] [varchar](50) NULL,
	[date_time] [datetime] NULL,
	[Person_Acc_Id] [numeric](18, 0) NULL,
	[Payment_Mode] [varchar](50) NULL,
	[Remark] [varchar](50) NULL,
	[Bill_Status] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Mst_Info] ON 

GO
INSERT [dbo].[Mst_Info] ([Id], [FirmName], [Address], [HeadOfficeAddress], [PhoneNo], [Email], [TinNo], [SaletaxNo]) VALUES (CAST(1 AS Numeric(18, 0)), N'Spice Spoon', N'Kamala Nagar', N'Bhagawan Takij', N'', N'', N'123456HG996321546', N'A4545F7667GHT878787')
GO
SET IDENTITY_INSERT [dbo].[Mst_Info] OFF
GO
INSERT [dbo].[Mst_Item] ([ItemCode], [Counter_Code], [ItemName], [INameHindi], [Rate], [Discount], [LogIn], [LogDate]) VALUES (101, N'2', N'Dosa', N'fgfgfgf', 50, 0, N'', CAST(0x0000A20400000000 AS DateTime))
GO
INSERT [dbo].[Mst_Item] ([ItemCode], [Counter_Code], [ItemName], [INameHindi], [Rate], [Discount], [LogIn], [LogDate]) VALUES (102, N'3', N'Shahi Paneer', N'''kkg', 100, 0, N'', CAST(0x0000A20500000000 AS DateTime))
GO
INSERT [dbo].[Mst_Item] ([ItemCode], [Counter_Code], [ItemName], [INameHindi], [Rate], [Discount], [LogIn], [LogDate]) VALUES (501, N'2', N'jghjgzjahgxjasg', N'sjhcjkshxcsxchxhcj', 10, 0, N'', CAST(0x0000A27000000000 AS DateTime))
GO
INSERT [dbo].[Mst_Item] ([ItemCode], [Counter_Code], [ItemName], [INameHindi], [Rate], [Discount], [LogIn], [LogDate]) VALUES (1000, N'8', N'2X5', N'eeefrre', 50, 0, N'', CAST(0x0000A24800000000 AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Mst_Tax] ON 

GO
INSERT [dbo].[Mst_Tax] ([Id], [Tax_name], [TaxPer], [Active]) VALUES (1, N'Vat', CAST(14.20 AS Decimal(18, 2)), 1)
GO
SET IDENTITY_INSERT [dbo].[Mst_Tax] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_CategoryMaster] ON 

GO
INSERT [dbo].[Tbl_CategoryMaster] ([Id], [Code], [Name], [Print], [LogIn], [LogDate]) VALUES (1, N'1', N'South Indian', 2, N'', CAST(0x0000A1F30163B614 AS DateTime))
GO
INSERT [dbo].[Tbl_CategoryMaster] ([Id], [Code], [Name], [Print], [LogIn], [LogDate]) VALUES (2, N'2', N'Chinese', 2, N'', CAST(0x0000A1F30163C621 AS DateTime))
GO
INSERT [dbo].[Tbl_CategoryMaster] ([Id], [Code], [Name], [Print], [LogIn], [LogDate]) VALUES (3, N'3', N'Meals', 2, N'', CAST(0x0000A1F30163DA52 AS DateTime))
GO
INSERT [dbo].[Tbl_CategoryMaster] ([Id], [Code], [Name], [Print], [LogIn], [LogDate]) VALUES (7, N'4', N'gdfdfdfgd', 2, N'', CAST(0x0000A27001559A94 AS DateTime))
GO
INSERT [dbo].[Tbl_CategoryMaster] ([Id], [Code], [Name], [Print], [LogIn], [LogDate]) VALUES (8, N'5', N'Box', 1, N'', CAST(0x0000A248013BB935 AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Tbl_CategoryMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_Login] ON 

GO
INSERT [dbo].[Tbl_Login] ([ID], [UserType], [UserName], [Password], [restriction]) VALUES (1, N'Administrator', N'a', N'a', NULL)
GO
INSERT [dbo].[Tbl_Login] ([ID], [UserType], [UserName], [Password], [restriction]) VALUES (2, N'Operator', N'Shobhit', N'a', N'12')
GO
INSERT [dbo].[Tbl_Login] ([ID], [UserType], [UserName], [Password], [restriction]) VALUES (12, N'Operator', N'shal', N'1234', NULL)
GO
INSERT [dbo].[Tbl_Login] ([ID], [UserType], [UserName], [Password], [restriction]) VALUES (13, N'Operator', N's', N's', NULL)
GO
INSERT [dbo].[Tbl_Login] ([ID], [UserType], [UserName], [Password], [restriction]) VALUES (14, N'Operator', N'd', N'd', NULL)
GO
INSERT [dbo].[Tbl_Login] ([ID], [UserType], [UserName], [Password], [restriction]) VALUES (15, N'Administrator', N'chandan', N'123456', NULL)
GO
SET IDENTITY_INSERT [dbo].[Tbl_Login] OFF
GO
INSERT [dbo].[Tokan_Details] ([Tokan_No], [Cat_Code], [Cat_Name], [Item_Code], [Item_Name], [Qty], [Rate], [Amount]) VALUES (1, NULL, NULL, 1, NULL, 10, 50, 500)
GO
INSERT [dbo].[Tokan_Details] ([Tokan_No], [Cat_Code], [Cat_Name], [Item_Code], [Item_Name], [Qty], [Rate], [Amount]) VALUES (1, NULL, NULL, 6, NULL, 4, 100, 400)
GO
INSERT [dbo].[Tokan_Details] ([Tokan_No], [Cat_Code], [Cat_Name], [Item_Code], [Item_Name], [Qty], [Rate], [Amount]) VALUES (1, NULL, NULL, 7, NULL, 10, 200, 2000)
GO
INSERT [dbo].[Tokan_Details] ([Tokan_No], [Cat_Code], [Cat_Name], [Item_Code], [Item_Name], [Qty], [Rate], [Amount]) VALUES (1, NULL, NULL, 8, NULL, 5, 300, 1500)
GO
INSERT [dbo].[Tokan_Details] ([Tokan_No], [Cat_Code], [Cat_Name], [Item_Code], [Item_Name], [Qty], [Rate], [Amount]) VALUES (1, NULL, NULL, 1, NULL, 10, 50, 500)
GO
INSERT [dbo].[Tokan_Details] ([Tokan_No], [Cat_Code], [Cat_Name], [Item_Code], [Item_Name], [Qty], [Rate], [Amount]) VALUES (1, NULL, NULL, 6, NULL, 4, 100, 400)
GO
INSERT [dbo].[Tokan_Details] ([Tokan_No], [Cat_Code], [Cat_Name], [Item_Code], [Item_Name], [Qty], [Rate], [Amount]) VALUES (1, NULL, NULL, 7, NULL, 10, 200, 2000)
GO
INSERT [dbo].[Tokan_Details] ([Tokan_No], [Cat_Code], [Cat_Name], [Item_Code], [Item_Name], [Qty], [Rate], [Amount]) VALUES (1, NULL, NULL, 8, NULL, 5, 300, 1500)
GO
INSERT [dbo].[Tokan_Master] ([TK_No], [Tk_Date], [Total_amt], [LogIn], [LoginDate]) VALUES (1, CAST(0x0000A1E700000000 AS DateTime), 0, N'', CAST(0x0000A1E700000000 AS DateTime))
GO
INSERT [dbo].[Tokan_Master] ([TK_No], [Tk_Date], [Total_amt], [LogIn], [LoginDate]) VALUES (2, CAST(0x0000A1E700000000 AS DateTime), 0, N'', CAST(0x0000A1E700000000 AS DateTime))
GO
INSERT [dbo].[Tokan_Master] ([TK_No], [Tk_Date], [Total_amt], [LogIn], [LoginDate]) VALUES (3, CAST(0x0000A1E700000000 AS DateTime), 0, N'', CAST(0x0000A1E700000000 AS DateTime))
GO
INSERT [dbo].[Tokan_Master] ([TK_No], [Tk_Date], [Total_amt], [LogIn], [LoginDate]) VALUES (4, CAST(0x0000A1E800000000 AS DateTime), 0, N'', CAST(0x0000A1E800000000 AS DateTime))
GO
INSERT [dbo].[Tokan_Master] ([TK_No], [Tk_Date], [Total_amt], [LogIn], [LoginDate]) VALUES (5, CAST(0x0000A1E800000000 AS DateTime), 0, N'', CAST(0x0000A1E800000000 AS DateTime))
GO
INSERT [dbo].[Tokan_Master] ([TK_No], [Tk_Date], [Total_amt], [LogIn], [LoginDate]) VALUES (6, CAST(0x0000A1E800000000 AS DateTime), 0, N'', CAST(0x0000A1E800000000 AS DateTime))
GO
INSERT [dbo].[Tokan_Master] ([TK_No], [Tk_Date], [Total_amt], [LogIn], [LoginDate]) VALUES (7, CAST(0x0000A1E800000000 AS DateTime), 0, N'', CAST(0x0000A1E800000000 AS DateTime))
GO
INSERT [dbo].[Tokan_Master] ([TK_No], [Tk_Date], [Total_amt], [LogIn], [LoginDate]) VALUES (8, CAST(0x0000A1E800000000 AS DateTime), 0, N'', CAST(0x0000A1E800000000 AS DateTime))
GO
INSERT [dbo].[Tokan_Master] ([TK_No], [Tk_Date], [Total_amt], [LogIn], [LoginDate]) VALUES (9, CAST(0x0000A1E800000000 AS DateTime), 0, N'', CAST(0x0000A1E800000000 AS DateTime))
GO
INSERT [dbo].[Tokan_Master] ([TK_No], [Tk_Date], [Total_amt], [LogIn], [LoginDate]) VALUES (10, CAST(0x0000A1E800000000 AS DateTime), 0, N'', CAST(0x0000A1E800000000 AS DateTime))
GO
INSERT [dbo].[Tokan_Master] ([TK_No], [Tk_Date], [Total_amt], [LogIn], [LoginDate]) VALUES (11, CAST(0x0000A1E800000000 AS DateTime), 0, N'', CAST(0x0000A1E800000000 AS DateTime))
GO
INSERT [dbo].[Tokan_Master] ([TK_No], [Tk_Date], [Total_amt], [LogIn], [LoginDate]) VALUES (12, CAST(0x0000A1E800000000 AS DateTime), 0, N'', CAST(0x0000A1E800000000 AS DateTime))
GO
INSERT [dbo].[Tokan_Master] ([TK_No], [Tk_Date], [Total_amt], [LogIn], [LoginDate]) VALUES (13, CAST(0x0000A1E800000000 AS DateTime), 0, N'', CAST(0x0000A1E800000000 AS DateTime))
GO
INSERT [dbo].[Tran_Sale_Det] ([SaleDet_SrNo], [Sale_Id], [Item_Id], [Qty], [Rate], [Amount], [ReturnQty], [ReturnDate], [ReturnRemark], [PCK]) VALUES (CAST(4 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(101 AS Numeric(18, 0)), CAST(2.00 AS Numeric(18, 2)), CAST(50.00 AS Numeric(18, 2)), CAST(100.00 AS Numeric(18, 2)), NULL, NULL, NULL, N'0')
GO
INSERT [dbo].[Tran_Sale_Det] ([SaleDet_SrNo], [Sale_Id], [Item_Id], [Qty], [Rate], [Amount], [ReturnQty], [ReturnDate], [ReturnRemark], [PCK]) VALUES (CAST(7 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(101 AS Numeric(18, 0)), CAST(2.00 AS Numeric(18, 2)), CAST(50.00 AS Numeric(18, 2)), CAST(100.00 AS Numeric(18, 2)), NULL, NULL, NULL, N'00')
GO
INSERT [dbo].[Tran_Sale_Det] ([SaleDet_SrNo], [Sale_Id], [Item_Id], [Qty], [Rate], [Amount], [ReturnQty], [ReturnDate], [ReturnRemark], [PCK]) VALUES (CAST(10 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(102 AS Numeric(18, 0)), CAST(2.00 AS Numeric(18, 2)), CAST(100.00 AS Numeric(18, 2)), CAST(200.00 AS Numeric(18, 2)), NULL, NULL, NULL, N'0')
GO
INSERT [dbo].[Tran_Sale_Det] ([SaleDet_SrNo], [Sale_Id], [Item_Id], [Qty], [Rate], [Amount], [ReturnQty], [ReturnDate], [ReturnRemark], [PCK]) VALUES (CAST(13 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(102 AS Numeric(18, 0)), CAST(2.00 AS Numeric(18, 2)), CAST(100.00 AS Numeric(18, 2)), CAST(200.00 AS Numeric(18, 2)), NULL, NULL, NULL, N'0')
GO
INSERT [dbo].[Tran_Sale_Det] ([SaleDet_SrNo], [Sale_Id], [Item_Id], [Qty], [Rate], [Amount], [ReturnQty], [ReturnDate], [ReturnRemark], [PCK]) VALUES (CAST(14 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(101 AS Numeric(18, 0)), CAST(3.00 AS Numeric(18, 2)), CAST(50.00 AS Numeric(18, 2)), CAST(150.00 AS Numeric(18, 2)), NULL, NULL, NULL, N'00')
GO
INSERT [dbo].[Tran_Sale_Det] ([SaleDet_SrNo], [Sale_Id], [Item_Id], [Qty], [Rate], [Amount], [ReturnQty], [ReturnDate], [ReturnRemark], [PCK]) VALUES (CAST(16 AS Numeric(18, 0)), CAST(7 AS Numeric(18, 0)), CAST(101 AS Numeric(18, 0)), CAST(2.00 AS Numeric(18, 2)), CAST(50.00 AS Numeric(18, 2)), CAST(100.00 AS Numeric(18, 2)), NULL, NULL, NULL, N'0')
GO
INSERT [dbo].[Tran_Sale_Det] ([SaleDet_SrNo], [Sale_Id], [Item_Id], [Qty], [Rate], [Amount], [ReturnQty], [ReturnDate], [ReturnRemark], [PCK]) VALUES (CAST(17 AS Numeric(18, 0)), CAST(8 AS Numeric(18, 0)), CAST(102 AS Numeric(18, 0)), CAST(2.00 AS Numeric(18, 2)), CAST(100.00 AS Numeric(18, 2)), CAST(200.00 AS Numeric(18, 2)), NULL, NULL, NULL, N'0')
GO
INSERT [dbo].[Tran_Sale_Det] ([SaleDet_SrNo], [Sale_Id], [Item_Id], [Qty], [Rate], [Amount], [ReturnQty], [ReturnDate], [ReturnRemark], [PCK]) VALUES (CAST(19 AS Numeric(18, 0)), CAST(9 AS Numeric(18, 0)), CAST(102 AS Numeric(18, 0)), CAST(2.00 AS Numeric(18, 2)), CAST(100.00 AS Numeric(18, 2)), CAST(200.00 AS Numeric(18, 2)), NULL, NULL, NULL, N'0')
GO
INSERT [dbo].[Tran_Sale_Det] ([SaleDet_SrNo], [Sale_Id], [Item_Id], [Qty], [Rate], [Amount], [ReturnQty], [ReturnDate], [ReturnRemark], [PCK]) VALUES (CAST(20 AS Numeric(18, 0)), CAST(10 AS Numeric(18, 0)), CAST(102 AS Numeric(18, 0)), CAST(2.00 AS Numeric(18, 2)), CAST(100.00 AS Numeric(18, 2)), CAST(200.00 AS Numeric(18, 2)), NULL, NULL, NULL, N'00')
GO
INSERT [dbo].[Tran_Sale_Det] ([SaleDet_SrNo], [Sale_Id], [Item_Id], [Qty], [Rate], [Amount], [ReturnQty], [ReturnDate], [ReturnRemark], [PCK]) VALUES (CAST(21 AS Numeric(18, 0)), CAST(11 AS Numeric(18, 0)), CAST(101 AS Numeric(18, 0)), CAST(2.00 AS Numeric(18, 2)), CAST(50.00 AS Numeric(18, 2)), CAST(100.00 AS Numeric(18, 2)), NULL, NULL, NULL, N'00')
GO
INSERT [dbo].[Tran_Sale_Det] ([SaleDet_SrNo], [Sale_Id], [Item_Id], [Qty], [Rate], [Amount], [ReturnQty], [ReturnDate], [ReturnRemark], [PCK]) VALUES (CAST(22 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(101 AS Numeric(18, 0)), CAST(1.00 AS Numeric(18, 2)), CAST(50.00 AS Numeric(18, 2)), CAST(50.00 AS Numeric(18, 2)), NULL, NULL, NULL, N'0')
GO
INSERT [dbo].[Tran_Sale_Det] ([SaleDet_SrNo], [Sale_Id], [Item_Id], [Qty], [Rate], [Amount], [ReturnQty], [ReturnDate], [ReturnRemark], [PCK]) VALUES (CAST(23 AS Numeric(18, 0)), CAST(13 AS Numeric(18, 0)), CAST(102 AS Numeric(18, 0)), CAST(2.00 AS Numeric(18, 2)), CAST(100.00 AS Numeric(18, 2)), CAST(200.00 AS Numeric(18, 2)), NULL, NULL, NULL, N'0')
GO
INSERT [dbo].[Tran_Sale_Det] ([SaleDet_SrNo], [Sale_Id], [Item_Id], [Qty], [Rate], [Amount], [ReturnQty], [ReturnDate], [ReturnRemark], [PCK]) VALUES (CAST(24 AS Numeric(18, 0)), CAST(14 AS Numeric(18, 0)), CAST(102 AS Numeric(18, 0)), CAST(2.00 AS Numeric(18, 2)), CAST(100.00 AS Numeric(18, 2)), CAST(200.00 AS Numeric(18, 2)), NULL, NULL, NULL, N'0')
GO
INSERT [dbo].[Tran_Sale_Det] ([SaleDet_SrNo], [Sale_Id], [Item_Id], [Qty], [Rate], [Amount], [ReturnQty], [ReturnDate], [ReturnRemark], [PCK]) VALUES (CAST(25 AS Numeric(18, 0)), CAST(14 AS Numeric(18, 0)), CAST(102 AS Numeric(18, 0)), CAST(2.00 AS Numeric(18, 2)), CAST(100.00 AS Numeric(18, 2)), CAST(200.00 AS Numeric(18, 2)), NULL, NULL, NULL, N'0')
GO
INSERT [dbo].[Tran_Sale_Det] ([SaleDet_SrNo], [Sale_Id], [Item_Id], [Qty], [Rate], [Amount], [ReturnQty], [ReturnDate], [ReturnRemark], [PCK]) VALUES (CAST(26 AS Numeric(18, 0)), CAST(15 AS Numeric(18, 0)), CAST(101 AS Numeric(18, 0)), CAST(2.00 AS Numeric(18, 2)), CAST(50.00 AS Numeric(18, 2)), CAST(100.00 AS Numeric(18, 2)), NULL, NULL, NULL, N'0')
GO
INSERT [dbo].[Tran_Sale_Det] ([SaleDet_SrNo], [Sale_Id], [Item_Id], [Qty], [Rate], [Amount], [ReturnQty], [ReturnDate], [ReturnRemark], [PCK]) VALUES (CAST(27 AS Numeric(18, 0)), CAST(15 AS Numeric(18, 0)), CAST(501 AS Numeric(18, 0)), CAST(1.00 AS Numeric(18, 2)), CAST(10.00 AS Numeric(18, 2)), CAST(10.00 AS Numeric(18, 2)), NULL, NULL, NULL, N'00')
GO
INSERT [dbo].[Tran_Sale_Det] ([SaleDet_SrNo], [Sale_Id], [Item_Id], [Qty], [Rate], [Amount], [ReturnQty], [ReturnDate], [ReturnRemark], [PCK]) VALUES (CAST(28 AS Numeric(18, 0)), CAST(16 AS Numeric(18, 0)), CAST(101 AS Numeric(18, 0)), CAST(2.00 AS Numeric(18, 2)), CAST(50.00 AS Numeric(18, 2)), CAST(100.00 AS Numeric(18, 2)), NULL, NULL, NULL, N'0')
GO
INSERT [dbo].[Tran_Sale_Det] ([SaleDet_SrNo], [Sale_Id], [Item_Id], [Qty], [Rate], [Amount], [ReturnQty], [ReturnDate], [ReturnRemark], [PCK]) VALUES (CAST(29 AS Numeric(18, 0)), CAST(17 AS Numeric(18, 0)), CAST(101 AS Numeric(18, 0)), CAST(2.00 AS Numeric(18, 2)), CAST(50.00 AS Numeric(18, 2)), CAST(100.00 AS Numeric(18, 2)), NULL, NULL, NULL, N'00')
GO
INSERT [dbo].[Tran_Sale_Det] ([SaleDet_SrNo], [Sale_Id], [Item_Id], [Qty], [Rate], [Amount], [ReturnQty], [ReturnDate], [ReturnRemark], [PCK]) VALUES (CAST(30 AS Numeric(18, 0)), CAST(17 AS Numeric(18, 0)), CAST(501 AS Numeric(18, 0)), CAST(2.00 AS Numeric(18, 2)), CAST(10.00 AS Numeric(18, 2)), CAST(20.00 AS Numeric(18, 2)), NULL, NULL, NULL, N'0')
GO
INSERT [dbo].[Tran_Sale_Det] ([SaleDet_SrNo], [Sale_Id], [Item_Id], [Qty], [Rate], [Amount], [ReturnQty], [ReturnDate], [ReturnRemark], [PCK]) VALUES (CAST(31 AS Numeric(18, 0)), CAST(18 AS Numeric(18, 0)), CAST(101 AS Numeric(18, 0)), CAST(2.00 AS Numeric(18, 2)), CAST(50.00 AS Numeric(18, 2)), CAST(100.00 AS Numeric(18, 2)), NULL, NULL, NULL, N'0')
GO
INSERT [dbo].[Tran_Sale_Det] ([SaleDet_SrNo], [Sale_Id], [Item_Id], [Qty], [Rate], [Amount], [ReturnQty], [ReturnDate], [ReturnRemark], [PCK]) VALUES (CAST(32 AS Numeric(18, 0)), CAST(18 AS Numeric(18, 0)), CAST(501 AS Numeric(18, 0)), CAST(1.00 AS Numeric(18, 2)), CAST(10.00 AS Numeric(18, 2)), CAST(10.00 AS Numeric(18, 2)), NULL, NULL, NULL, N'0')
GO
INSERT [dbo].[Tran_Sale_Det] ([SaleDet_SrNo], [Sale_Id], [Item_Id], [Qty], [Rate], [Amount], [ReturnQty], [ReturnDate], [ReturnRemark], [PCK]) VALUES (CAST(34 AS Numeric(18, 0)), CAST(18 AS Numeric(18, 0)), CAST(101 AS Numeric(18, 0)), CAST(10.00 AS Numeric(18, 2)), CAST(50.00 AS Numeric(18, 2)), CAST(500.00 AS Numeric(18, 2)), NULL, NULL, NULL, N'00')
GO
INSERT [dbo].[Tran_Sale_Det] ([SaleDet_SrNo], [Sale_Id], [Item_Id], [Qty], [Rate], [Amount], [ReturnQty], [ReturnDate], [ReturnRemark], [PCK]) VALUES (CAST(35 AS Numeric(18, 0)), CAST(19 AS Numeric(18, 0)), CAST(101 AS Numeric(18, 0)), CAST(2.00 AS Numeric(18, 2)), CAST(50.00 AS Numeric(18, 2)), CAST(100.00 AS Numeric(18, 2)), NULL, NULL, NULL, N'00')
GO
INSERT [dbo].[Tran_Sale_Det] ([SaleDet_SrNo], [Sale_Id], [Item_Id], [Qty], [Rate], [Amount], [ReturnQty], [ReturnDate], [ReturnRemark], [PCK]) VALUES (CAST(36 AS Numeric(18, 0)), CAST(19 AS Numeric(18, 0)), CAST(101 AS Numeric(18, 0)), CAST(2.00 AS Numeric(18, 2)), CAST(50.00 AS Numeric(18, 2)), CAST(100.00 AS Numeric(18, 2)), NULL, NULL, NULL, N'00')
GO
INSERT [dbo].[Tran_Sale_Det] ([SaleDet_SrNo], [Sale_Id], [Item_Id], [Qty], [Rate], [Amount], [ReturnQty], [ReturnDate], [ReturnRemark], [PCK]) VALUES (CAST(38 AS Numeric(18, 0)), CAST(21 AS Numeric(18, 0)), CAST(101 AS Numeric(18, 0)), CAST(2.00 AS Numeric(18, 2)), CAST(50.00 AS Numeric(18, 2)), CAST(100.00 AS Numeric(18, 2)), NULL, NULL, NULL, N'0')
GO
INSERT [dbo].[Tran_Sale_Det] ([SaleDet_SrNo], [Sale_Id], [Item_Id], [Qty], [Rate], [Amount], [ReturnQty], [ReturnDate], [ReturnRemark], [PCK]) VALUES (CAST(40 AS Numeric(18, 0)), CAST(20 AS Numeric(18, 0)), CAST(101 AS Numeric(18, 0)), CAST(2.00 AS Numeric(18, 2)), CAST(50.00 AS Numeric(18, 2)), CAST(100.00 AS Numeric(18, 2)), NULL, NULL, NULL, N'00')
GO
INSERT [dbo].[Tran_Sale_Det] ([SaleDet_SrNo], [Sale_Id], [Item_Id], [Qty], [Rate], [Amount], [ReturnQty], [ReturnDate], [ReturnRemark], [PCK]) VALUES (CAST(41 AS Numeric(18, 0)), CAST(22 AS Numeric(18, 0)), CAST(101 AS Numeric(18, 0)), CAST(2.00 AS Numeric(18, 2)), CAST(50.00 AS Numeric(18, 2)), CAST(100.00 AS Numeric(18, 2)), NULL, NULL, NULL, N'0')
GO
INSERT [dbo].[Tran_Sale_Det] ([SaleDet_SrNo], [Sale_Id], [Item_Id], [Qty], [Rate], [Amount], [ReturnQty], [ReturnDate], [ReturnRemark], [PCK]) VALUES (CAST(42 AS Numeric(18, 0)), CAST(22 AS Numeric(18, 0)), CAST(501 AS Numeric(18, 0)), CAST(2.00 AS Numeric(18, 2)), CAST(10.00 AS Numeric(18, 2)), CAST(20.00 AS Numeric(18, 2)), NULL, NULL, NULL, N'0')
GO
INSERT [dbo].[Tran_Sale_Det] ([SaleDet_SrNo], [Sale_Id], [Item_Id], [Qty], [Rate], [Amount], [ReturnQty], [ReturnDate], [ReturnRemark], [PCK]) VALUES (CAST(43 AS Numeric(18, 0)), CAST(23 AS Numeric(18, 0)), CAST(101 AS Numeric(18, 0)), CAST(2.00 AS Numeric(18, 2)), CAST(50.00 AS Numeric(18, 2)), CAST(100.00 AS Numeric(18, 2)), NULL, NULL, NULL, N'00')
GO
INSERT [dbo].[Tran_Sale_Det] ([SaleDet_SrNo], [Sale_Id], [Item_Id], [Qty], [Rate], [Amount], [ReturnQty], [ReturnDate], [ReturnRemark], [PCK]) VALUES (CAST(44 AS Numeric(18, 0)), CAST(24 AS Numeric(18, 0)), CAST(1000 AS Numeric(18, 0)), CAST(2.00 AS Numeric(18, 2)), CAST(50.00 AS Numeric(18, 2)), CAST(100.00 AS Numeric(18, 2)), NULL, NULL, NULL, N'00')
GO
INSERT [dbo].[Tran_Sale_Det] ([SaleDet_SrNo], [Sale_Id], [Item_Id], [Qty], [Rate], [Amount], [ReturnQty], [ReturnDate], [ReturnRemark], [PCK]) VALUES (CAST(45 AS Numeric(18, 0)), CAST(25 AS Numeric(18, 0)), CAST(101 AS Numeric(18, 0)), CAST(2.00 AS Numeric(18, 2)), CAST(50.00 AS Numeric(18, 2)), CAST(100.00 AS Numeric(18, 2)), NULL, NULL, NULL, N'0')
GO
INSERT [dbo].[Tran_Sale_Det] ([SaleDet_SrNo], [Sale_Id], [Item_Id], [Qty], [Rate], [Amount], [ReturnQty], [ReturnDate], [ReturnRemark], [PCK]) VALUES (CAST(46 AS Numeric(18, 0)), CAST(26 AS Numeric(18, 0)), CAST(101 AS Numeric(18, 0)), CAST(11.00 AS Numeric(18, 2)), CAST(50.00 AS Numeric(18, 2)), CAST(550.00 AS Numeric(18, 2)), NULL, NULL, NULL, N'0')
GO
INSERT [dbo].[Tran_Sale_Det] ([SaleDet_SrNo], [Sale_Id], [Item_Id], [Qty], [Rate], [Amount], [ReturnQty], [ReturnDate], [ReturnRemark], [PCK]) VALUES (CAST(47 AS Numeric(18, 0)), CAST(27 AS Numeric(18, 0)), CAST(101 AS Numeric(18, 0)), CAST(2.00 AS Numeric(18, 2)), CAST(50.00 AS Numeric(18, 2)), CAST(100.00 AS Numeric(18, 2)), NULL, NULL, NULL, N'0')
GO
INSERT [dbo].[Tran_Sale_Det] ([SaleDet_SrNo], [Sale_Id], [Item_Id], [Qty], [Rate], [Amount], [ReturnQty], [ReturnDate], [ReturnRemark], [PCK]) VALUES (CAST(48 AS Numeric(18, 0)), CAST(28 AS Numeric(18, 0)), CAST(101 AS Numeric(18, 0)), CAST(2.00 AS Numeric(18, 2)), CAST(50.00 AS Numeric(18, 2)), CAST(100.00 AS Numeric(18, 2)), NULL, NULL, NULL, N'0')
GO
INSERT [dbo].[Tran_Sale_Det] ([SaleDet_SrNo], [Sale_Id], [Item_Id], [Qty], [Rate], [Amount], [ReturnQty], [ReturnDate], [ReturnRemark], [PCK]) VALUES (CAST(49 AS Numeric(18, 0)), CAST(28 AS Numeric(18, 0)), CAST(101 AS Numeric(18, 0)), CAST(3.00 AS Numeric(18, 2)), CAST(50.00 AS Numeric(18, 2)), CAST(150.00 AS Numeric(18, 2)), NULL, NULL, NULL, N'00')
GO
INSERT [dbo].[Tran_Sale_Mas] ([Sale_Id], [Sale_No], [Fin_Year], [Sale_Date], [TaxId], [TaxPer], [TaxAmount], [Total_Amt], [username], [date_time], [Person_Acc_Id], [Payment_Mode], [Remark], [Bill_Status]) VALUES (1, N'1', N'', CAST(0x0000A6D000000000 AS DateTime), 1, CAST(14.20 AS Numeric(18, 2)), CAST(25 AS Numeric(18, 0)), CAST(200.00 AS Numeric(18, 2)), N'1', CAST(0x0000A6D0016F37D0 AS DateTime), CAST(0 AS Numeric(18, 0)), N'Cash', N'', NULL)
GO
INSERT [dbo].[Tran_Sale_Mas] ([Sale_Id], [Sale_No], [Fin_Year], [Sale_Date], [TaxId], [TaxPer], [TaxAmount], [Total_Amt], [username], [date_time], [Person_Acc_Id], [Payment_Mode], [Remark], [Bill_Status]) VALUES (2, N'2', N'', CAST(0x0000A6D000000000 AS DateTime), 1, CAST(14.20 AS Numeric(18, 2)), CAST(37 AS Numeric(18, 0)), CAST(300.00 AS Numeric(18, 2)), N'1', CAST(0x0000A6D001700AC0 AS DateTime), CAST(0 AS Numeric(18, 0)), N'Cash', N'', NULL)
GO
INSERT [dbo].[Tran_Sale_Mas] ([Sale_Id], [Sale_No], [Fin_Year], [Sale_Date], [TaxId], [TaxPer], [TaxAmount], [Total_Amt], [username], [date_time], [Person_Acc_Id], [Payment_Mode], [Remark], [Bill_Status]) VALUES (3, N'3', N'', CAST(0x0000A6D000000000 AS DateTime), 1, CAST(14.20 AS Numeric(18, 2)), CAST(12 AS Numeric(18, 0)), CAST(100.00 AS Numeric(18, 2)), N'1', CAST(0x0000A6D001811220 AS DateTime), CAST(0 AS Numeric(18, 0)), N'Cash', N'', NULL)
GO
INSERT [dbo].[Tran_Sale_Mas] ([Sale_Id], [Sale_No], [Fin_Year], [Sale_Date], [TaxId], [TaxPer], [TaxAmount], [Total_Amt], [username], [date_time], [Person_Acc_Id], [Payment_Mode], [Remark], [Bill_Status]) VALUES (4, N'4', N'', CAST(0x0000A6D000000000 AS DateTime), 1, CAST(14.20 AS Numeric(18, 2)), CAST(44 AS Numeric(18, 0)), CAST(350.00 AS Numeric(18, 2)), N'1', CAST(0x0000A6D001822B60 AS DateTime), CAST(0 AS Numeric(18, 0)), N'Cash', N'', NULL)
GO
INSERT [dbo].[Tran_Sale_Mas] ([Sale_Id], [Sale_No], [Fin_Year], [Sale_Date], [TaxId], [TaxPer], [TaxAmount], [Total_Amt], [username], [date_time], [Person_Acc_Id], [Payment_Mode], [Remark], [Bill_Status]) VALUES (5, N'5', N'', CAST(0x0000A6D000000000 AS DateTime), 1, CAST(14.20 AS Numeric(18, 2)), CAST(12 AS Numeric(18, 0)), CAST(100.00 AS Numeric(18, 2)), N'1', CAST(0x0000A6D00182B800 AS DateTime), CAST(0 AS Numeric(18, 0)), N'Cash', N'', NULL)
GO
INSERT [dbo].[Tran_Sale_Mas] ([Sale_Id], [Sale_No], [Fin_Year], [Sale_Date], [TaxId], [TaxPer], [TaxAmount], [Total_Amt], [username], [date_time], [Person_Acc_Id], [Payment_Mode], [Remark], [Bill_Status]) VALUES (6, N'6', N'', CAST(0x0000A6D000000000 AS DateTime), 1, CAST(14.20 AS Numeric(18, 2)), CAST(75 AS Numeric(18, 0)), CAST(600.00 AS Numeric(18, 2)), N'1', CAST(0x0000A6D00182FE50 AS DateTime), CAST(0 AS Numeric(18, 0)), N'Cash', N'', NULL)
GO
INSERT [dbo].[Tran_Sale_Mas] ([Sale_Id], [Sale_No], [Fin_Year], [Sale_Date], [TaxId], [TaxPer], [TaxAmount], [Total_Amt], [username], [date_time], [Person_Acc_Id], [Payment_Mode], [Remark], [Bill_Status]) VALUES (7, N'7', N'', CAST(0x0000A6D000000000 AS DateTime), 1, CAST(14.20 AS Numeric(18, 2)), CAST(12 AS Numeric(18, 0)), CAST(100.00 AS Numeric(18, 2)), N'1', CAST(0x0000A6D00189DC20 AS DateTime), CAST(0 AS Numeric(18, 0)), N'Cash', N'', NULL)
GO
INSERT [dbo].[Tran_Sale_Mas] ([Sale_Id], [Sale_No], [Fin_Year], [Sale_Date], [TaxId], [TaxPer], [TaxAmount], [Total_Amt], [username], [date_time], [Person_Acc_Id], [Payment_Mode], [Remark], [Bill_Status]) VALUES (8, N'8', N'', CAST(0x0000A6D000000000 AS DateTime), 1, CAST(14.20 AS Numeric(18, 2)), CAST(25 AS Numeric(18, 0)), CAST(200.00 AS Numeric(18, 2)), N'1', CAST(0x0000A6D0018A68C0 AS DateTime), CAST(0 AS Numeric(18, 0)), N'Cash', N'', NULL)
GO
INSERT [dbo].[Tran_Sale_Mas] ([Sale_Id], [Sale_No], [Fin_Year], [Sale_Date], [TaxId], [TaxPer], [TaxAmount], [Total_Amt], [username], [date_time], [Person_Acc_Id], [Payment_Mode], [Remark], [Bill_Status]) VALUES (9, N'9', N'', CAST(0x0000A6D000000000 AS DateTime), 1, CAST(14.20 AS Numeric(18, 2)), CAST(25 AS Numeric(18, 0)), CAST(200.00 AS Numeric(18, 2)), N'1', CAST(0x0000A6D100000000 AS DateTime), CAST(0 AS Numeric(18, 0)), N'Cash', N'', NULL)
GO
INSERT [dbo].[Tran_Sale_Mas] ([Sale_Id], [Sale_No], [Fin_Year], [Sale_Date], [TaxId], [TaxPer], [TaxAmount], [Total_Amt], [username], [date_time], [Person_Acc_Id], [Payment_Mode], [Remark], [Bill_Status]) VALUES (10, N'1', N'', CAST(0x0000A6D100000000 AS DateTime), 1, CAST(14.20 AS Numeric(18, 2)), CAST(25 AS Numeric(18, 0)), CAST(200.00 AS Numeric(18, 2)), N'1', CAST(0x0000A6D100008CA0 AS DateTime), CAST(0 AS Numeric(18, 0)), N'Cash', N'', NULL)
GO
INSERT [dbo].[Tran_Sale_Mas] ([Sale_Id], [Sale_No], [Fin_Year], [Sale_Date], [TaxId], [TaxPer], [TaxAmount], [Total_Amt], [username], [date_time], [Person_Acc_Id], [Payment_Mode], [Remark], [Bill_Status]) VALUES (11, N'2', N'', CAST(0x0000A6D100000000 AS DateTime), 1, CAST(14.20 AS Numeric(18, 2)), CAST(12 AS Numeric(18, 0)), CAST(100.00 AS Numeric(18, 2)), N'1', CAST(0x0000A6D10000D2F0 AS DateTime), CAST(0 AS Numeric(18, 0)), N'Cash', N'', NULL)
GO
INSERT [dbo].[Tran_Sale_Mas] ([Sale_Id], [Sale_No], [Fin_Year], [Sale_Date], [TaxId], [TaxPer], [TaxAmount], [Total_Amt], [username], [date_time], [Person_Acc_Id], [Payment_Mode], [Remark], [Bill_Status]) VALUES (12, N'3', N'', CAST(0x0000A6D100000000 AS DateTime), 1, CAST(14.20 AS Numeric(18, 2)), CAST(6 AS Numeric(18, 0)), CAST(50.00 AS Numeric(18, 2)), N'1', CAST(0x0000A6D100011940 AS DateTime), CAST(0 AS Numeric(18, 0)), N'Cash', N'', NULL)
GO
INSERT [dbo].[Tran_Sale_Mas] ([Sale_Id], [Sale_No], [Fin_Year], [Sale_Date], [TaxId], [TaxPer], [TaxAmount], [Total_Amt], [username], [date_time], [Person_Acc_Id], [Payment_Mode], [Remark], [Bill_Status]) VALUES (13, N'4', N'', CAST(0x0000A6D100000000 AS DateTime), 1, CAST(14.20 AS Numeric(18, 2)), CAST(25 AS Numeric(18, 0)), CAST(200.00 AS Numeric(18, 2)), N'1', CAST(0x0000A6D10003D860 AS DateTime), CAST(0 AS Numeric(18, 0)), N'Cash', N'', NULL)
GO
INSERT [dbo].[Tran_Sale_Mas] ([Sale_Id], [Sale_No], [Fin_Year], [Sale_Date], [TaxId], [TaxPer], [TaxAmount], [Total_Amt], [username], [date_time], [Person_Acc_Id], [Payment_Mode], [Remark], [Bill_Status]) VALUES (14, N'5', N'', CAST(0x0000A6D100000000 AS DateTime), 1, CAST(14.20 AS Numeric(18, 2)), CAST(50 AS Numeric(18, 0)), CAST(400.00 AS Numeric(18, 2)), N'1', CAST(0x0000A6D100163F50 AS DateTime), CAST(0 AS Numeric(18, 0)), N'Cash', N'', N'Cancle')
GO
INSERT [dbo].[Tran_Sale_Mas] ([Sale_Id], [Sale_No], [Fin_Year], [Sale_Date], [TaxId], [TaxPer], [TaxAmount], [Total_Amt], [username], [date_time], [Person_Acc_Id], [Payment_Mode], [Remark], [Bill_Status]) VALUES (17, N'8', N'', CAST(0x0000A6D100000000 AS DateTime), 1, CAST(14.20 AS Numeric(18, 2)), CAST(15 AS Numeric(18, 0)), CAST(120.00 AS Numeric(18, 2)), N'1', CAST(0x0000A6D1001F95F0 AS DateTime), CAST(0 AS Numeric(18, 0)), N'Cash', N'', NULL)
GO
INSERT [dbo].[Tran_Sale_Mas] ([Sale_Id], [Sale_No], [Fin_Year], [Sale_Date], [TaxId], [TaxPer], [TaxAmount], [Total_Amt], [username], [date_time], [Person_Acc_Id], [Payment_Mode], [Remark], [Bill_Status]) VALUES (18, N'9', N'', CAST(0x0000A6D100000000 AS DateTime), 1, CAST(14.20 AS Numeric(18, 2)), CAST(76 AS Numeric(18, 0)), CAST(610.00 AS Numeric(18, 2)), N'1', CAST(0x0000A6D1002A4C20 AS DateTime), CAST(0 AS Numeric(18, 0)), N'Cash', N'', NULL)
GO
INSERT [dbo].[Tran_Sale_Mas] ([Sale_Id], [Sale_No], [Fin_Year], [Sale_Date], [TaxId], [TaxPer], [TaxAmount], [Total_Amt], [username], [date_time], [Person_Acc_Id], [Payment_Mode], [Remark], [Bill_Status]) VALUES (19, N'10', N'', CAST(0x0000A6D100000000 AS DateTime), 1, CAST(14.20 AS Numeric(18, 2)), CAST(25 AS Numeric(18, 0)), CAST(200.00 AS Numeric(18, 2)), N'1', CAST(0x0000A6D1002AD8C0 AS DateTime), CAST(0 AS Numeric(18, 0)), N'Cash', N'', NULL)
GO
INSERT [dbo].[Tran_Sale_Mas] ([Sale_Id], [Sale_No], [Fin_Year], [Sale_Date], [TaxId], [TaxPer], [TaxAmount], [Total_Amt], [username], [date_time], [Person_Acc_Id], [Payment_Mode], [Remark], [Bill_Status]) VALUES (20, N'11', N'', CAST(0x0000A6D100000000 AS DateTime), 1, CAST(14.20 AS Numeric(18, 2)), CAST(12 AS Numeric(18, 0)), CAST(100.00 AS Numeric(18, 2)), N'1', CAST(0x0000A6D1002DDE30 AS DateTime), CAST(0 AS Numeric(18, 0)), N'Cash', N'', NULL)
GO
INSERT [dbo].[Tran_Sale_Mas] ([Sale_Id], [Sale_No], [Fin_Year], [Sale_Date], [TaxId], [TaxPer], [TaxAmount], [Total_Amt], [username], [date_time], [Person_Acc_Id], [Payment_Mode], [Remark], [Bill_Status]) VALUES (22, N'13', N'', CAST(0x0000A6D100000000 AS DateTime), 1, CAST(14.20 AS Numeric(18, 2)), CAST(15 AS Numeric(18, 0)), CAST(120.00 AS Numeric(18, 2)), N'1', CAST(0x0000A6D10033A2C0 AS DateTime), CAST(0 AS Numeric(18, 0)), N'Cash', N'', NULL)
GO
INSERT [dbo].[Tran_Sale_Mas] ([Sale_Id], [Sale_No], [Fin_Year], [Sale_Date], [TaxId], [TaxPer], [TaxAmount], [Total_Amt], [username], [date_time], [Person_Acc_Id], [Payment_Mode], [Remark], [Bill_Status]) VALUES (23, N'14', N'', CAST(0x0000A6D100000000 AS DateTime), 1, CAST(14.20 AS Numeric(18, 2)), CAST(12 AS Numeric(18, 0)), CAST(100.00 AS Numeric(18, 2)), N'1', CAST(0x0000A6D10033E910 AS DateTime), CAST(0 AS Numeric(18, 0)), N'Cash', N'', NULL)
GO
INSERT [dbo].[Tran_Sale_Mas] ([Sale_Id], [Sale_No], [Fin_Year], [Sale_Date], [TaxId], [TaxPer], [TaxAmount], [Total_Amt], [username], [date_time], [Person_Acc_Id], [Payment_Mode], [Remark], [Bill_Status]) VALUES (24, N'15', N'', CAST(0x0000A6D100000000 AS DateTime), 1, CAST(14.20 AS Numeric(18, 2)), CAST(12 AS Numeric(18, 0)), CAST(100.00 AS Numeric(18, 2)), N'1', CAST(0x0000A6D100342F60 AS DateTime), CAST(0 AS Numeric(18, 0)), N'Cash', N'', NULL)
GO
INSERT [dbo].[Tran_Sale_Mas] ([Sale_Id], [Sale_No], [Fin_Year], [Sale_Date], [TaxId], [TaxPer], [TaxAmount], [Total_Amt], [username], [date_time], [Person_Acc_Id], [Payment_Mode], [Remark], [Bill_Status]) VALUES (25, N'16', N'', CAST(0x0000A6D100000000 AS DateTime), 1, CAST(14.20 AS Numeric(18, 2)), CAST(12 AS Numeric(18, 0)), CAST(100.00 AS Numeric(18, 2)), N'1', CAST(0x0000A6D1003475B0 AS DateTime), CAST(0 AS Numeric(18, 0)), N'Cash', N'', NULL)
GO
INSERT [dbo].[Tran_Sale_Mas] ([Sale_Id], [Sale_No], [Fin_Year], [Sale_Date], [TaxId], [TaxPer], [TaxAmount], [Total_Amt], [username], [date_time], [Person_Acc_Id], [Payment_Mode], [Remark], [Bill_Status]) VALUES (26, N'17', N'', CAST(0x0000A6D100000000 AS DateTime), 1, CAST(14.20 AS Numeric(18, 2)), CAST(68 AS Numeric(18, 0)), CAST(550.00 AS Numeric(18, 2)), N'1', CAST(0x0000A6D10034BC00 AS DateTime), CAST(0 AS Numeric(18, 0)), N'Cash', N'', NULL)
GO
INSERT [dbo].[Tran_Sale_Mas] ([Sale_Id], [Sale_No], [Fin_Year], [Sale_Date], [TaxId], [TaxPer], [TaxAmount], [Total_Amt], [username], [date_time], [Person_Acc_Id], [Payment_Mode], [Remark], [Bill_Status]) VALUES (27, N'18', N'', CAST(0x0000A6D100000000 AS DateTime), 1, CAST(14.20 AS Numeric(18, 2)), CAST(12 AS Numeric(18, 0)), CAST(100.00 AS Numeric(18, 2)), N'1', CAST(0x0000A6D10034BC00 AS DateTime), CAST(0 AS Numeric(18, 0)), N'Cash', N'', NULL)
GO
INSERT [dbo].[Tran_Sale_Mas] ([Sale_Id], [Sale_No], [Fin_Year], [Sale_Date], [TaxId], [TaxPer], [TaxAmount], [Total_Amt], [username], [date_time], [Person_Acc_Id], [Payment_Mode], [Remark], [Bill_Status]) VALUES (15, N'6', N'', CAST(0x0000A6D100000000 AS DateTime), 1, CAST(14.20 AS Numeric(18, 2)), CAST(14 AS Numeric(18, 0)), CAST(110.00 AS Numeric(18, 2)), N'1', CAST(0x0000A6D10017E530 AS DateTime), CAST(0 AS Numeric(18, 0)), N'Cash', N'', NULL)
GO
INSERT [dbo].[Tran_Sale_Mas] ([Sale_Id], [Sale_No], [Fin_Year], [Sale_Date], [TaxId], [TaxPer], [TaxAmount], [Total_Amt], [username], [date_time], [Person_Acc_Id], [Payment_Mode], [Remark], [Bill_Status]) VALUES (16, N'7', N'', CAST(0x0000A6D100000000 AS DateTime), 1, CAST(14.20 AS Numeric(18, 2)), CAST(12 AS Numeric(18, 0)), CAST(100.00 AS Numeric(18, 2)), N'1', CAST(0x0000A6D1001D6370 AS DateTime), CAST(0 AS Numeric(18, 0)), N'Cash', N'', NULL)
GO
INSERT [dbo].[Tran_Sale_Mas] ([Sale_Id], [Sale_No], [Fin_Year], [Sale_Date], [TaxId], [TaxPer], [TaxAmount], [Total_Amt], [username], [date_time], [Person_Acc_Id], [Payment_Mode], [Remark], [Bill_Status]) VALUES (21, N'12', N'', CAST(0x0000A6D100000000 AS DateTime), 1, CAST(14.20 AS Numeric(18, 2)), CAST(12 AS Numeric(18, 0)), CAST(100.00 AS Numeric(18, 2)), N'1', CAST(0x0000A6D10030E3A0 AS DateTime), CAST(0 AS Numeric(18, 0)), N'Card', N'45454', NULL)
GO
INSERT [dbo].[Tran_Sale_Mas] ([Sale_Id], [Sale_No], [Fin_Year], [Sale_Date], [TaxId], [TaxPer], [TaxAmount], [Total_Amt], [username], [date_time], [Person_Acc_Id], [Payment_Mode], [Remark], [Bill_Status]) VALUES (28, N'19', N'', CAST(0x0000A6D100000000 AS DateTime), 1, CAST(14.20 AS Numeric(18, 2)), CAST(31 AS Numeric(18, 0)), CAST(250.00 AS Numeric(18, 2)), N'1', CAST(0x0000A6D10036EE80 AS DateTime), CAST(0 AS Numeric(18, 0)), N'Cash', N'', N'Cancle')
GO
/****** Object:  Index [IX_Tran_Sale_Mas]    Script Date: 03-12-2016 9:08:30 AM ******/
ALTER TABLE [dbo].[Tran_Sale_Mas] ADD  CONSTRAINT [IX_Tran_Sale_Mas] UNIQUE NONCLUSTERED 
(
	[Sale_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [SpicySpoon] SET  READ_WRITE 
GO
