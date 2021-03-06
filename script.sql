USE [master]
GO
/****** Object:  Database [DBStock]    Script Date: 11/10/2021 13:19:33 ******/
CREATE DATABASE [DBStock]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DBStock', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DBStock.mdf' , SIZE = 1515520KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DBStock_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DBStock_log.ldf' , SIZE = 1449984KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DBStock] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DBStock].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DBStock] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DBStock] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DBStock] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DBStock] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DBStock] SET ARITHABORT OFF 
GO
ALTER DATABASE [DBStock] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [DBStock] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DBStock] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DBStock] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DBStock] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DBStock] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DBStock] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DBStock] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DBStock] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DBStock] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DBStock] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DBStock] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DBStock] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DBStock] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DBStock] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DBStock] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [DBStock] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DBStock] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DBStock] SET  MULTI_USER 
GO
ALTER DATABASE [DBStock] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DBStock] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DBStock] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DBStock] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DBStock] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DBStock] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [DBStock] SET QUERY_STORE = OFF
GO
USE [DBStock]
GO
/****** Object:  Table [dbo].[TStock]    Script Date: 11/10/2021 13:19:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TStock](
	[PointOfSale] [nvarchar](max) NOT NULL,
	[Product] [nvarchar](max) NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[Stock] [int] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [DBStock] SET  READ_WRITE 
GO
