USE [master]
GO
/****** Object:  Database [MostriVsEroi]    Script Date: 03/09/2021 14:53:18 ******/
CREATE DATABASE [MostriVsEroi]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MostriVsEroi', FILENAME = N'C:\Users\utente\MostriVsEroi.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MostriVsEroi_log', FILENAME = N'C:\Users\utente\MostriVsEroi_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [MostriVsEroi] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MostriVsEroi].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MostriVsEroi] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MostriVsEroi] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MostriVsEroi] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MostriVsEroi] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MostriVsEroi] SET ARITHABORT OFF 
GO
ALTER DATABASE [MostriVsEroi] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MostriVsEroi] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MostriVsEroi] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MostriVsEroi] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MostriVsEroi] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MostriVsEroi] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MostriVsEroi] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MostriVsEroi] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MostriVsEroi] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MostriVsEroi] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MostriVsEroi] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MostriVsEroi] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MostriVsEroi] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MostriVsEroi] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MostriVsEroi] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MostriVsEroi] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MostriVsEroi] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MostriVsEroi] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MostriVsEroi] SET  MULTI_USER 
GO
ALTER DATABASE [MostriVsEroi] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MostriVsEroi] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MostriVsEroi] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MostriVsEroi] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MostriVsEroi] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MostriVsEroi] SET QUERY_STORE = OFF
GO
USE [MostriVsEroi]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [MostriVsEroi]
GO
/****** Object:  Table [dbo].[Arma]    Script Date: 03/09/2021 14:53:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Arma](
	[Id] [int] NOT NULL,
	[Nome] [nvarchar](50) NULL,
	[PuntiDanno] [int] NULL,
 CONSTRAINT [PK_Arma] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Eroe]    Script Date: 03/09/2021 14:53:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Eroe](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
	[IdCategoria] [int] NOT NULL,
	[IdArma] [int] NOT NULL,
	[Livello] [int] NOT NULL,
	[IdUtente] [nvarchar](50) NOT NULL,
	[PuntiAccumulati] [int] NULL,
 CONSTRAINT [PK_Eroe] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mostro]    Script Date: 03/09/2021 14:53:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mostro](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](50) NULL,
	[IdCategoria] [int] NULL,
	[IdArma] [int] NULL,
	[Livello] [int] NULL,
 CONSTRAINT [PK_Mostro] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Utente]    Script Date: 03/09/2021 14:53:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Utente](
	[Nickname] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Admin] [bit] NULL
) ON [PRIMARY]
GO
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno]) VALUES (1, N'Alabarda', 15)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno]) VALUES (2, N'Ascia', 8)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno]) VALUES (3, N'Mazza', 5)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno]) VALUES (4, N'Spada', 10)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno]) VALUES (5, N'Spadone', 15)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno]) VALUES (6, N'ArcoFrecce', 8)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno]) VALUES (7, N'Bacchetta', 5)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno]) VALUES (8, N'BastoneMagico', 10)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno]) VALUES (9, N'OndaUrto', 15)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno]) VALUES (10, N'Pugnale', 5)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno]) VALUES (11, N'DiscorsoNoioso', 4)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno]) VALUES (12, N'Farneticazione', 7)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno]) VALUES (13, N'Imprecazione', 5)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno]) VALUES (14, N'MagiaNera', 3)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno]) VALUES (15, N'Arco', 7)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno]) VALUES (16, N'Clava', 5)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno]) VALUES (17, N'SpadaRotta', 3)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno]) VALUES (18, N'MazzaChiodata', 10)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno]) VALUES (19, N'AlabardaDelDrago', 30)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno]) VALUES (20, N'Divinazione', 15)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno]) VALUES (21, N'Fulmine', 10)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno]) VALUES (22, N'FulmineCeleste', 15)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno]) VALUES (23, N'Tempesta', 8)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno]) VALUES (24, N'TempestaOscura', 15)
GO
SET IDENTITY_INSERT [dbo].[Eroe] ON 

INSERT [dbo].[Eroe] ([Id], [Nome], [IdCategoria], [IdArma], [Livello], [IdUtente], [PuntiAccumulati]) VALUES (1, N'Antuus', 2, 2, 1, N'robi13891', 10)
INSERT [dbo].[Eroe] ([Id], [Nome], [IdCategoria], [IdArma], [Livello], [IdUtente], [PuntiAccumulati]) VALUES (3, N'Belfagor', 1, 3, 1, N'robi13890', 0)
INSERT [dbo].[Eroe] ([Id], [Nome], [IdCategoria], [IdArma], [Livello], [IdUtente], [PuntiAccumulati]) VALUES (4, N'Aracno', 1, 4, 1, N'robi13891', 15)
INSERT [dbo].[Eroe] ([Id], [Nome], [IdCategoria], [IdArma], [Livello], [IdUtente], [PuntiAccumulati]) VALUES (5, N'Balto', 1, 5, 1, N'robi13891', 10)
INSERT [dbo].[Eroe] ([Id], [Nome], [IdCategoria], [IdArma], [Livello], [IdUtente], [PuntiAccumulati]) VALUES (1008, N'Gaga', 1, 1, 1, N'a', 0)
SET IDENTITY_INSERT [dbo].[Eroe] OFF
GO
SET IDENTITY_INSERT [dbo].[Mostro] ON 

INSERT [dbo].[Mostro] ([Id], [Nome], [IdCategoria], [IdArma], [Livello]) VALUES (1002, N'MANNEQUINN', 3, 4, 1)
INSERT [dbo].[Mostro] ([Id], [Nome], [IdCategoria], [IdArma], [Livello]) VALUES (1003, N'GRU', 3, 4, 1)
INSERT [dbo].[Mostro] ([Id], [Nome], [IdCategoria], [IdArma], [Livello]) VALUES (1004, N'Scruut', 4, 16, 4)
INSERT [dbo].[Mostro] ([Id], [Nome], [IdCategoria], [IdArma], [Livello]) VALUES (1005, N'Pergola', 5, 24, 4)
INSERT [dbo].[Mostro] ([Id], [Nome], [IdCategoria], [IdArma], [Livello]) VALUES (1006, N'Nardi', 3, 12, 1)
INSERT [dbo].[Mostro] ([Id], [Nome], [IdCategoria], [IdArma], [Livello]) VALUES (2006, N'MagoNero', 4, 18, 4)
SET IDENTITY_INSERT [dbo].[Mostro] OFF
GO
INSERT [dbo].[Utente] ([Nickname], [Password], [Admin]) VALUES (N'robi13891', N'abcder', 0)
INSERT [dbo].[Utente] ([Nickname], [Password], [Admin]) VALUES (N'robi13890', N'abcder', 1)
INSERT [dbo].[Utente] ([Nickname], [Password], [Admin]) VALUES (N'a', N'a', 0)
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Utente]    Script Date: 03/09/2021 14:53:18 ******/
ALTER TABLE [dbo].[Utente] ADD  CONSTRAINT [IX_Utente] UNIQUE NONCLUSTERED 
(
	[Nickname] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Eroe]  WITH CHECK ADD  CONSTRAINT [FK_Eroe_Utente] FOREIGN KEY([IdUtente])
REFERENCES [dbo].[Utente] ([Nickname])
GO
ALTER TABLE [dbo].[Eroe] CHECK CONSTRAINT [FK_Eroe_Utente]
GO
USE [master]
GO
ALTER DATABASE [MostriVsEroi] SET  READ_WRITE 
GO
