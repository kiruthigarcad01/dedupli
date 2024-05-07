USE [master]
GO
/****** Object:  Database [duplifree]    Script Date: 5/7/2024 3:17:22 PM ******/
CREATE DATABASE [duplifree] ON  PRIMARY 
( NAME = N'duplifree', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\duplifree.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'duplifree_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\duplifree_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [duplifree] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [duplifree].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [duplifree] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [duplifree] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [duplifree] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [duplifree] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [duplifree] SET ARITHABORT OFF 
GO
ALTER DATABASE [duplifree] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [duplifree] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [duplifree] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [duplifree] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [duplifree] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [duplifree] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [duplifree] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [duplifree] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [duplifree] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [duplifree] SET  DISABLE_BROKER 
GO
ALTER DATABASE [duplifree] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [duplifree] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [duplifree] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [duplifree] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [duplifree] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [duplifree] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [duplifree] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [duplifree] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [duplifree] SET  MULTI_USER 
GO
ALTER DATABASE [duplifree] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [duplifree] SET DB_CHAINING OFF 
GO
USE [duplifree]
GO
/****** Object:  Table [dbo].[dataholders]    Script Date: 5/7/2024 3:17:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dataholders](
	[FileID] [int] NOT NULL,
	[FileName] [nvarchar](50) NULL,
	[FileType] [nvarchar](100) NULL,
	[FileURL] [nvarchar](250) NULL,
 CONSTRAINT [PK_dataholders] PRIMARY KEY CLUSTERED 
(
	[FileID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Login]    Script Date: 5/7/2024 3:17:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[id] [int] NOT NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
 CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Register]    Script Date: 5/7/2024 3:17:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Register](
	[UserID] [int] NOT NULL,
	[FullName] [nvarchar](50) NULL,
	[username] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[PhoneNumber] [nvarchar](50) NULL,
	[password] [nvarchar](50) NULL,
	[Gender] [nchar](10) NULL,
 CONSTRAINT [PK_Register] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[userfiles]    Script Date: 5/7/2024 3:17:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[userfiles](
	[FileID] [int] IDENTITY(1,1) NOT NULL,
	[FileName] [varchar](50) NULL,
	[FilePath] [nvarchar](50) NULL,
	[FileSize] [int] NULL,
	[UploadedAt] [datetime] NULL,
 CONSTRAINT [PK_userfiles] PRIMARY KEY CLUSTERED 
(
	[FileID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [duplifree] SET  READ_WRITE 
GO
