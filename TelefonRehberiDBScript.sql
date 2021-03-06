USE [master]
GO
/****** Object:  Database [TelefonRehberi]    Script Date: 2019-04-18 3:41:05 PM ******/
CREATE DATABASE [TelefonRehberi]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TelefonRehberi', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\TelefonRehberi.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TelefonRehberi_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\TelefonRehberi_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [TelefonRehberi] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TelefonRehberi].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TelefonRehberi] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TelefonRehberi] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TelefonRehberi] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TelefonRehberi] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TelefonRehberi] SET ARITHABORT OFF 
GO
ALTER DATABASE [TelefonRehberi] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TelefonRehberi] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TelefonRehberi] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TelefonRehberi] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TelefonRehberi] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TelefonRehberi] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TelefonRehberi] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TelefonRehberi] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TelefonRehberi] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TelefonRehberi] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TelefonRehberi] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TelefonRehberi] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TelefonRehberi] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TelefonRehberi] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TelefonRehberi] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TelefonRehberi] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TelefonRehberi] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TelefonRehberi] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TelefonRehberi] SET  MULTI_USER 
GO
ALTER DATABASE [TelefonRehberi] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TelefonRehberi] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TelefonRehberi] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TelefonRehberi] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TelefonRehberi] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TelefonRehberi] SET QUERY_STORE = OFF
GO
USE [TelefonRehberi]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 2019-04-18 3:41:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[departmentID] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Departman] PRIMARY KEY CLUSTERED 
(
	[departmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 2019-04-18 3:41:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[employeeID] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[surname] [nvarchar](50) NOT NULL,
	[phone] [nvarchar](50) NOT NULL,
	[departmentID] [int] NULL,
	[managerID] [int] NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[employeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Login]    Script Date: 2019-04-18 3:41:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[loginID] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED 
(
	[loginID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Department] ON 

INSERT [dbo].[Department] ([departmentID], [name]) VALUES (38, N'Technology')
INSERT [dbo].[Department] ([departmentID], [name]) VALUES (39, N'Human Resources')
INSERT [dbo].[Department] ([departmentID], [name]) VALUES (40, N'Test')
INSERT [dbo].[Department] ([departmentID], [name]) VALUES (41, N'Technology1')
INSERT [dbo].[Department] ([departmentID], [name]) VALUES (42, N'Technology2')
SET IDENTITY_INSERT [dbo].[Department] OFF
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([employeeID], [name], [surname], [phone], [departmentID], [managerID]) VALUES (35, N'Tolgahan', N'KİŞİN', N'05555555555', 38, NULL)
INSERT [dbo].[Employee] ([employeeID], [name], [surname], [phone], [departmentID], [managerID]) VALUES (36, N'testname', N'testsurname', N'01234567890', 39, 35)
INSERT [dbo].[Employee] ([employeeID], [name], [surname], [phone], [departmentID], [managerID]) VALUES (37, N'TestName1', N'Surname1', N'12341243423', 40, 35)
INSERT [dbo].[Employee] ([employeeID], [name], [surname], [phone], [departmentID], [managerID]) VALUES (38, N'TestName2', N'Surname2', N'12341235437', 38, 36)
INSERT [dbo].[Employee] ([employeeID], [name], [surname], [phone], [departmentID], [managerID]) VALUES (39, N'testName3', N'testsurname3', N'34356572354', 39, 38)
INSERT [dbo].[Employee] ([employeeID], [name], [surname], [phone], [departmentID], [managerID]) VALUES (40, N'testName4', N'Surname4', N'32423657899', 40, 39)
INSERT [dbo].[Employee] ([employeeID], [name], [surname], [phone], [departmentID], [managerID]) VALUES (41, N'asdf', N'asdasf', N'12331435546', 42, 40)
SET IDENTITY_INSERT [dbo].[Employee] OFF
SET IDENTITY_INSERT [dbo].[Login] ON 

INSERT [dbo].[Login] ([loginID], [username], [password]) VALUES (1, N'admin', N'123')
SET IDENTITY_INSERT [dbo].[Login] OFF
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Departman] FOREIGN KEY([departmentID])
REFERENCES [dbo].[Department] ([departmentID])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Departman]
GO
USE [master]
GO
ALTER DATABASE [TelefonRehberi] SET  READ_WRITE 
GO
