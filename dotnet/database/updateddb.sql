USE [master]
GO
/****** Object:  Database [final_capstone]    Script Date: 8/7/2020 12:12:17 PM ******/
CREATE DATABASE [final_capstone]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'final_capstone', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\final_capstone.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'final_capstone_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\final_capstone_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [final_capstone] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [final_capstone].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [final_capstone] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [final_capstone] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [final_capstone] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [final_capstone] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [final_capstone] SET ARITHABORT OFF 
GO
ALTER DATABASE [final_capstone] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [final_capstone] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [final_capstone] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [final_capstone] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [final_capstone] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [final_capstone] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [final_capstone] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [final_capstone] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [final_capstone] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [final_capstone] SET  ENABLE_BROKER 
GO
ALTER DATABASE [final_capstone] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [final_capstone] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [final_capstone] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [final_capstone] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [final_capstone] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [final_capstone] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [final_capstone] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [final_capstone] SET RECOVERY FULL 
GO
ALTER DATABASE [final_capstone] SET  MULTI_USER 
GO
ALTER DATABASE [final_capstone] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [final_capstone] SET DB_CHAINING OFF 
GO
ALTER DATABASE [final_capstone] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [final_capstone] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [final_capstone] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'final_capstone', N'ON'
GO
ALTER DATABASE [final_capstone] SET QUERY_STORE = OFF
GO
USE [final_capstone]
GO
/****** Object:  Table [dbo].[landmarks]    Script Date: 8/7/2020 12:12:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[landmarks](
	[landmark_id] [int] IDENTITY(1,1) NOT NULL,
	[landmark_name] [varchar](50) NOT NULL,
	[landmark_address] [varchar](200) NOT NULL,
	[landmark_description] [varchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 8/7/2020 12:12:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password_hash] [varchar](200) NOT NULL,
	[salt] [varchar](200) NOT NULL,
	[user_role] [varchar](50) NOT NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/*********Table [dbo].[itinerary]***********/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[itineraries] (
	[id] [int] IDENTITY (1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[itinerary_name] [varchar](100) NOT NULL,
	[starting_address][varchar](255) NOT NULL,
	[locations][varchar](255)
FOREIGN KEY (user_id) REFERENCES users(user_id) 
)

SET IDENTITY_INSERT [dbo].[landmarks] ON 
INSERT [dbo].[landmarks] ([landmark_id], [landmark_name], [landmark_address], [landmark_description]) VALUES (1, N'Ohio Stadium', N'411 Woody Hayes Dr, Columbus, OH 43210=', N'OSU football stadium')
INSERT [dbo].[landmarks] ([landmark_id], [landmark_name], [landmark_address], [landmark_description]) VALUES (2, N'Thurber House', N'77 Jefferson Ave, Columbus, OH 43215', N'Writers House')
INSERT [dbo].[landmarks] ([landmark_id], [landmark_name], [landmark_address], [landmark_description]) VALUES (3, N'Columbus Zoo and Aquarium', N'4850 West Powell Road Powell OH 43065', N'Worlds Best Zoo')
INSERT [dbo].[landmarks] ([landmark_id], [landmark_name], [landmark_address], [landmark_description]) VALUES (4, N'North Market', N'59 Spruce St, Columbus, OH 43215', N'8 different types of chinese food')
INSERT [dbo].[landmarks] ([landmark_id], [landmark_name], [landmark_address], [landmark_description]) VALUES (5, N'COSI', N'333 W Broad St, Columbus, OH 43215', N'Sciency stuff')
INSERT [dbo].[landmarks] ([landmark_id], [landmark_name], [landmark_address], [landmark_description]) VALUES (6, N'Columbus Museum of Art', N'480 E Broad St, Columbus, OH 43215', N'Arty stuff')
INSERT [dbo].[landmarks] ([landmark_id], [landmark_name], [landmark_address], [landmark_description]) VALUES (7, N'Franklin Park Conservatory', N'1777 E Broad St, Columbus, OH 43205', N'Arty stuff')
INSERT [dbo].[landmarks] ([landmark_id], [landmark_name], [landmark_address], [landmark_description]) VALUES (8, N'Main Street Bridge (Columbus, Ohio)', N'303 W Main StColumbusOH43215', N'Great view')
SET IDENTITY_INSERT [dbo].[landmarks] OFF
GO
SET IDENTITY_INSERT [dbo].[users] ON 

INSERT [dbo].[users] ([user_id], [username], [password_hash], [salt], [user_role]) VALUES (1, N'user', N'Jg45HuwT7PZkfuKTz6IB90CtWY4=', N'LHxP4Xh7bN0=', N'user')
INSERT [dbo].[users] ([user_id], [username], [password_hash], [salt], [user_role]) VALUES (2, N'admin', N'YhyGVQ+Ch69n4JMBncM4lNF/i9s=', N'Ar/aB2thQTI=', N'admin')
SET IDENTITY_INSERT [dbo].[users] OFF
GO
USE [master]
GO
ALTER DATABASE [final_capstone] SET  READ_WRITE 
GO
