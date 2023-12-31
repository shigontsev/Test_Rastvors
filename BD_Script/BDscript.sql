USE [master]
GO
/****** Object:  Database [MudDBTest]    Script Date: 29.10.2023 17:58:57 ******/
CREATE DATABASE [MudDBTest]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MudDBTest', FILENAME = N'E:\Repos_Another\Tests_REP\Test_Rastvors\Rastvors.WinFormsApp\App_Data\MudDBTest.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MudDBTest_log', FILENAME = N'E:\Repos_Another\Tests_REP\Test_Rastvors\Rastvors.WinFormsApp\App_Data\MudDBTest_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [MudDBTest] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MudDBTest].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MudDBTest] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MudDBTest] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MudDBTest] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MudDBTest] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MudDBTest] SET ARITHABORT OFF 
GO
ALTER DATABASE [MudDBTest] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [MudDBTest] SET AUTO_SHRINK ON 
GO
ALTER DATABASE [MudDBTest] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MudDBTest] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MudDBTest] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MudDBTest] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MudDBTest] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MudDBTest] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MudDBTest] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MudDBTest] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MudDBTest] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MudDBTest] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MudDBTest] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MudDBTest] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MudDBTest] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MudDBTest] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MudDBTest] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MudDBTest] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MudDBTest] SET  MULTI_USER 
GO
ALTER DATABASE [MudDBTest] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MudDBTest] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MudDBTest] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MudDBTest] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MudDBTest] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MudDBTest] SET QUERY_STORE = OFF
GO
USE [MudDBTest]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [MudDBTest]
GO
/****** Object:  Table [dbo].[Components]    Script Date: 29.10.2023 17:58:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Components](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Components] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rastvors]    Script Date: 29.10.2023 17:58:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rastvors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Value] [float] NOT NULL,
 CONSTRAINT [PK_Rastvors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Structures]    Script Date: 29.10.2023 17:58:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Structures](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Rastvor_Id] [int] NOT NULL,
	[Component_Id] [int] NOT NULL,
	[Value] [float] NOT NULL,
 CONSTRAINT [PK_Structures] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Components] ON 

INSERT [dbo].[Components] ([Id], [Name]) VALUES (1, N'Вода')
INSERT [dbo].[Components] ([Id], [Name]) VALUES (2, N'Глина')
INSERT [dbo].[Components] ([Id], [Name]) VALUES (3, N'Эмульсия')
INSERT [dbo].[Components] ([Id], [Name]) VALUES (4, N'Comp1')
INSERT [dbo].[Components] ([Id], [Name]) VALUES (5, N'Comp2')
INSERT [dbo].[Components] ([Id], [Name]) VALUES (6, N'Comp3')
SET IDENTITY_INSERT [dbo].[Components] OFF
GO
SET IDENTITY_INSERT [dbo].[Rastvors] ON 

INSERT [dbo].[Rastvors] ([Id], [Name], [Value]) VALUES (1, N'sad1', 23)
INSERT [dbo].[Rastvors] ([Id], [Name], [Value]) VALUES (2, N'sad2', 3)
INSERT [dbo].[Rastvors] ([Id], [Name], [Value]) VALUES (4, N'sad4', 333)
INSERT [dbo].[Rastvors] ([Id], [Name], [Value]) VALUES (5, N'sad5', 33)
SET IDENTITY_INSERT [dbo].[Rastvors] OFF
GO
SET IDENTITY_INSERT [dbo].[Structures] ON 

INSERT [dbo].[Structures] ([Id], [Rastvor_Id], [Component_Id], [Value]) VALUES (3, 2, 3, 5)
INSERT [dbo].[Structures] ([Id], [Rastvor_Id], [Component_Id], [Value]) VALUES (4, 2, 2, 35)
INSERT [dbo].[Structures] ([Id], [Rastvor_Id], [Component_Id], [Value]) VALUES (7, 4, 1, 100)
INSERT [dbo].[Structures] ([Id], [Rastvor_Id], [Component_Id], [Value]) VALUES (8, 1, 1, 100)
INSERT [dbo].[Structures] ([Id], [Rastvor_Id], [Component_Id], [Value]) VALUES (9, 2, 1, 30)
INSERT [dbo].[Structures] ([Id], [Rastvor_Id], [Component_Id], [Value]) VALUES (10, 2, 4, 30)
INSERT [dbo].[Structures] ([Id], [Rastvor_Id], [Component_Id], [Value]) VALUES (11, 5, 1, 30)
INSERT [dbo].[Structures] ([Id], [Rastvor_Id], [Component_Id], [Value]) VALUES (14, 5, 2, 30)
INSERT [dbo].[Structures] ([Id], [Rastvor_Id], [Component_Id], [Value]) VALUES (15, 5, 3, 40)
SET IDENTITY_INSERT [dbo].[Structures] OFF
GO
ALTER TABLE [dbo].[Structures]  WITH CHECK ADD  CONSTRAINT [FK_Structures_Components] FOREIGN KEY([Component_Id])
REFERENCES [dbo].[Components] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Structures] CHECK CONSTRAINT [FK_Structures_Components]
GO
ALTER TABLE [dbo].[Structures]  WITH CHECK ADD  CONSTRAINT [FK_Structures_Rastvors] FOREIGN KEY([Rastvor_Id])
REFERENCES [dbo].[Rastvors] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Structures] CHECK CONSTRAINT [FK_Structures_Rastvors]
GO
USE [master]
GO
ALTER DATABASE [MudDBTest] SET  READ_WRITE 
GO
