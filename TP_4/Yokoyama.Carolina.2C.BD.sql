USE [master]
GO
/****** Object:  Database [ClinicaBD]    Script Date: 16/6/2022 10:04:12 ******/
CREATE DATABASE [ClinicaBD]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ClinicaBD', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ClinicaBD.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ClinicaBD_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ClinicaBD_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ClinicaBD] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ClinicaBD].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ClinicaBD] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ClinicaBD] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ClinicaBD] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ClinicaBD] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ClinicaBD] SET ARITHABORT OFF 
GO
ALTER DATABASE [ClinicaBD] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ClinicaBD] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ClinicaBD] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ClinicaBD] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ClinicaBD] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ClinicaBD] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ClinicaBD] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ClinicaBD] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ClinicaBD] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ClinicaBD] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ClinicaBD] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ClinicaBD] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ClinicaBD] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ClinicaBD] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ClinicaBD] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ClinicaBD] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ClinicaBD] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ClinicaBD] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ClinicaBD] SET  MULTI_USER 
GO
ALTER DATABASE [ClinicaBD] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ClinicaBD] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ClinicaBD] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ClinicaBD] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ClinicaBD] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ClinicaBD] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ClinicaBD] SET QUERY_STORE = OFF
GO
USE [ClinicaBD]
GO
/****** Object:  Table [dbo].[Medicos]    Script Date: 16/6/2022 10:04:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medicos](
	[id_Medico] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[celular] [varchar](50) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[dni] [int] NOT NULL,
	[especialidad] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pacientes]    Script Date: 16/6/2022 10:04:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pacientes](
	[id_Paciente] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[celular] [varchar](50) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[dni] [int] NOT NULL,
	[obraSocial] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Turnos]    Script Date: 16/6/2022 10:04:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Turnos](
	[id_Turno] [int] IDENTITY(1,1) NOT NULL,
	[id_Medico] [int] NOT NULL,
	[id_Paciente] [int] NOT NULL,
	[fecha_Hora] [datetime] NOT NULL,
	[recordatorioNotificado] [int] NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Medicos] ON 

INSERT [dbo].[Medicos] ([id_Medico], [nombre], [apellido], [celular], [email], [dni], [especialidad]) VALUES (1, N'Gerrie', N'Willas', N'254-663-2688', N'gwillas0@microsoft.com', 30820684, 0)
INSERT [dbo].[Medicos] ([id_Medico], [nombre], [apellido], [celular], [email], [dni], [especialidad]) VALUES (2, N'Marne', N'Lorriman', N'198-957-5986', N'mlorriman1@last.fm', 22931403, 4)
INSERT [dbo].[Medicos] ([id_Medico], [nombre], [apellido], [celular], [email], [dni], [especialidad]) VALUES (3, N'Haslett', N'Kment', N'323-514-1174', N'hkment2@java.com', 22723088, 2)
INSERT [dbo].[Medicos] ([id_Medico], [nombre], [apellido], [celular], [email], [dni], [especialidad]) VALUES (4, N'Talya', N'Saye', N'904-235-1584', N'tsaye3@wufoo.com', 26784818, 5)
INSERT [dbo].[Medicos] ([id_Medico], [nombre], [apellido], [celular], [email], [dni], [especialidad]) VALUES (5, N'Bondon', N'Rosenstein', N'830-316-8937', N'brosenstein4@amazon.de', 27679184, 1)
INSERT [dbo].[Medicos] ([id_Medico], [nombre], [apellido], [celular], [email], [dni], [especialidad]) VALUES (6, N'Cindra', N'Woolis', N'268-111-3081', N'cwoolis5@independent.co.uk', 21603202, 2)
INSERT [dbo].[Medicos] ([id_Medico], [nombre], [apellido], [celular], [email], [dni], [especialidad]) VALUES (7, N'Ignace', N'Pilsworth', N'420-441-6649', N'ipilsworth6@icio.us', 21199962, 5)
INSERT [dbo].[Medicos] ([id_Medico], [nombre], [apellido], [celular], [email], [dni], [especialidad]) VALUES (8, N'Lynnelle', N'Rootham', N'873-415-7389', N'lrootham7@furl.net', 23342028, 5)
INSERT [dbo].[Medicos] ([id_Medico], [nombre], [apellido], [celular], [email], [dni], [especialidad]) VALUES (9, N'Kathrine', N'Perview', N'551-227-6602', N'kperview8@ucoz.com', 34918630, 5)
INSERT [dbo].[Medicos] ([id_Medico], [nombre], [apellido], [celular], [email], [dni], [especialidad]) VALUES (10, N'Lissa', N'Gemmill', N'963-755-0452', N'lgemmill9@cbslocal.com', 35206863, 0)
INSERT [dbo].[Medicos] ([id_Medico], [nombre], [apellido], [celular], [email], [dni], [especialidad]) VALUES (11, N'Jeremy', N'Tonge', N'121-274-0189', N'jtongea@example.com', 21498218, 1)
INSERT [dbo].[Medicos] ([id_Medico], [nombre], [apellido], [celular], [email], [dni], [especialidad]) VALUES (12, N'Marlane', N'Josefson', N'377-850-8776', N'mjosefsonb@posterous.com', 28304335, 1)
INSERT [dbo].[Medicos] ([id_Medico], [nombre], [apellido], [celular], [email], [dni], [especialidad]) VALUES (13, N'Ilario', N'Brent', N'385-973-6236', N'ibrentc@privacy.gov.au', 29628572, 5)
INSERT [dbo].[Medicos] ([id_Medico], [nombre], [apellido], [celular], [email], [dni], [especialidad]) VALUES (14, N'Geordie', N'Rubinlicht', N'310-425-6283', N'grubinlichtd@chicagotribune.com', 32378566, 5)
INSERT [dbo].[Medicos] ([id_Medico], [nombre], [apellido], [celular], [email], [dni], [especialidad]) VALUES (15, N'Sibilla', N'Stockney', N'270-725-6655', N'sstockneye@newyorker.com', 26431656, 2)
INSERT [dbo].[Medicos] ([id_Medico], [nombre], [apellido], [celular], [email], [dni], [especialidad]) VALUES (16, N'Reba', N'Esplin', N'464-500-8168', N'resplinf@miibeian.gov.cn', 37345133, 1)
INSERT [dbo].[Medicos] ([id_Medico], [nombre], [apellido], [celular], [email], [dni], [especialidad]) VALUES (17, N'Kimbra', N'Luke', N'945-114-3538', N'klukeg@msn.com', 30493219, 2)
INSERT [dbo].[Medicos] ([id_Medico], [nombre], [apellido], [celular], [email], [dni], [especialidad]) VALUES (18, N'Catie', N'Grose', N'477-345-5450', N'cgroseh@engadget.com', 21827307, 3)
INSERT [dbo].[Medicos] ([id_Medico], [nombre], [apellido], [celular], [email], [dni], [especialidad]) VALUES (19, N'Augusta', N'Harburtson', N'396-557-8352', N'aharburtsoni@zimbio.com', 21280270, 3)
INSERT [dbo].[Medicos] ([id_Medico], [nombre], [apellido], [celular], [email], [dni], [especialidad]) VALUES (20, N'Ailis', N'Priden', N'216-521-3938', N'apridenj@cam.ac.uk', 35205934, 5)
SET IDENTITY_INSERT [dbo].[Medicos] OFF
GO
SET IDENTITY_INSERT [dbo].[Pacientes] ON 

INSERT [dbo].[Pacientes] ([id_Paciente], [nombre], [apellido], [celular], [email], [dni], [obraSocial]) VALUES (1, N'Ashien', N'Swain', N'129-579-8212', N'aswain0@opensource.org', 20907711, 0)
INSERT [dbo].[Pacientes] ([id_Paciente], [nombre], [apellido], [celular], [email], [dni], [obraSocial]) VALUES (2, N'Bail', N'Mulhill', N'889-807-7039', N'bmulhill1@wisc.edu', 22717501, 1)
INSERT [dbo].[Pacientes] ([id_Paciente], [nombre], [apellido], [celular], [email], [dni], [obraSocial]) VALUES (3, N'Glendon', N'Dries', N'443-864-6160', N'gdries2@godaddy.com', 35472886, 3)
INSERT [dbo].[Pacientes] ([id_Paciente], [nombre], [apellido], [celular], [email], [dni], [obraSocial]) VALUES (4, N'Emory', N'Filasov', N'907-242-0663', N'efilasov3@loc.gov', 44863297, 2)
INSERT [dbo].[Pacientes] ([id_Paciente], [nombre], [apellido], [celular], [email], [dni], [obraSocial]) VALUES (5, N'Chrystel', N'Linner', N'624-225-6551', N'clinner4@livejournal.com', 37189810, 3)
INSERT [dbo].[Pacientes] ([id_Paciente], [nombre], [apellido], [celular], [email], [dni], [obraSocial]) VALUES (6, N'Fons', N'Castles', N'623-783-2543', N'fcastles5@zimbio.com', 28676797, 2)
INSERT [dbo].[Pacientes] ([id_Paciente], [nombre], [apellido], [celular], [email], [dni], [obraSocial]) VALUES (7, N'Katha', N'Assard', N'252-725-2129', N'kassard6@columbia.edu', 20767156, 4)
INSERT [dbo].[Pacientes] ([id_Paciente], [nombre], [apellido], [celular], [email], [dni], [obraSocial]) VALUES (8, N'Ivett', N'McGrayle', N'512-741-4555', N'imcgrayle7@cpanel.net', 25133901, 0)
INSERT [dbo].[Pacientes] ([id_Paciente], [nombre], [apellido], [celular], [email], [dni], [obraSocial]) VALUES (9, N'Keene', N'Climpson', N'572-779-4825', N'kclimpson8@squarespace.com', 34895537, 4)
INSERT [dbo].[Pacientes] ([id_Paciente], [nombre], [apellido], [celular], [email], [dni], [obraSocial]) VALUES (10, N'Othello', N'Schindler', N'631-622-1389', N'oschindler9@flavors.me', 47830679, 3)
INSERT [dbo].[Pacientes] ([id_Paciente], [nombre], [apellido], [celular], [email], [dni], [obraSocial]) VALUES (11, N'Sherm', N'Haime', N'973-910-7645', N'shaimea@amazonaws.com', 37649977, 0)
INSERT [dbo].[Pacientes] ([id_Paciente], [nombre], [apellido], [celular], [email], [dni], [obraSocial]) VALUES (12, N'Beryl', N'Surmeir', N'524-370-9624', N'bsurmeirb@usnews.com', 39367794, 1)
INSERT [dbo].[Pacientes] ([id_Paciente], [nombre], [apellido], [celular], [email], [dni], [obraSocial]) VALUES (13, N'Guthry', N'Bowmer', N'652-148-1081', N'gbowmerc@ft.com', 21946999, 1)
INSERT [dbo].[Pacientes] ([id_Paciente], [nombre], [apellido], [celular], [email], [dni], [obraSocial]) VALUES (14, N'Sig', N'Krolman', N'281-490-0409', N'skrolmand@mail.ru', 39863592, 1)
INSERT [dbo].[Pacientes] ([id_Paciente], [nombre], [apellido], [celular], [email], [dni], [obraSocial]) VALUES (15, N'Kaleb', N'Grimwood', N'763-576-8152', N'kgrimwoode@wordpress.com', 27613398, 3)
INSERT [dbo].[Pacientes] ([id_Paciente], [nombre], [apellido], [celular], [email], [dni], [obraSocial]) VALUES (16, N'Torre', N'Stallwood', N'914-611-1917', N'tstallwoodf@merriam-webster.com', 45999318, 0)
INSERT [dbo].[Pacientes] ([id_Paciente], [nombre], [apellido], [celular], [email], [dni], [obraSocial]) VALUES (17, N'Georgi', N'Devers', N'465-874-9117', N'gdeversg@miibeian.gov.cn', 46431052, 2)
INSERT [dbo].[Pacientes] ([id_Paciente], [nombre], [apellido], [celular], [email], [dni], [obraSocial]) VALUES (18, N'Wylie', N'Northing', N'233-103-6541', N'wnorthingh@google.cn', 24749840, 0)
INSERT [dbo].[Pacientes] ([id_Paciente], [nombre], [apellido], [celular], [email], [dni], [obraSocial]) VALUES (19, N'Melly', N'Wombwell', N'230-740-9493', N'mwombwelli@barnesandnoble.com', 44114344, 4)
INSERT [dbo].[Pacientes] ([id_Paciente], [nombre], [apellido], [celular], [email], [dni], [obraSocial]) VALUES (20, N'Julietta', N'Coggell', N'637-509-5850', N'jcoggellj@yandex.ru', 47135889, 1)
INSERT [dbo].[Pacientes] ([id_Paciente], [nombre], [apellido], [celular], [email], [dni], [obraSocial]) VALUES (21, N'Johannah', N'Bromby', N'933-503-4690', N'jbrombyk@nifty.com', 46100967, 2)
INSERT [dbo].[Pacientes] ([id_Paciente], [nombre], [apellido], [celular], [email], [dni], [obraSocial]) VALUES (22, N'Dallas', N'Kubiak', N'903-690-6630', N'dkubiakl@furl.net', 35140223, 1)
INSERT [dbo].[Pacientes] ([id_Paciente], [nombre], [apellido], [celular], [email], [dni], [obraSocial]) VALUES (23, N'Ashlie', N'Pirolini', N'485-201-6581', N'apirolinim@cbslocal.com', 24605090, 3)
INSERT [dbo].[Pacientes] ([id_Paciente], [nombre], [apellido], [celular], [email], [dni], [obraSocial]) VALUES (24, N'Jeanine', N'Kohter', N'819-397-9148', N'jkohtern@mlb.com', 47167000, 3)
INSERT [dbo].[Pacientes] ([id_Paciente], [nombre], [apellido], [celular], [email], [dni], [obraSocial]) VALUES (25, N'Darrell', N'Panniers', N'921-642-8148', N'dpannierso@123-reg.co.uk', 41354563, 4)
INSERT [dbo].[Pacientes] ([id_Paciente], [nombre], [apellido], [celular], [email], [dni], [obraSocial]) VALUES (26, N'Darrell', N'MacArd', N'438-104-3185', N'dmacardp@123-reg.co.uk', 49337764, 0)
INSERT [dbo].[Pacientes] ([id_Paciente], [nombre], [apellido], [celular], [email], [dni], [obraSocial]) VALUES (27, N'Kirbie', N'Victoria', N'731-179-4966', N'kvictoriaq@google.nl', 26117137, 1)
INSERT [dbo].[Pacientes] ([id_Paciente], [nombre], [apellido], [celular], [email], [dni], [obraSocial]) VALUES (28, N'Collie', N'Romanelli', N'398-125-9687', N'cromanellir@parallels.com', 32817271, 4)
INSERT [dbo].[Pacientes] ([id_Paciente], [nombre], [apellido], [celular], [email], [dni], [obraSocial]) VALUES (29, N'Theodoric', N'Moyler', N'302-519-3388', N'tmoylers@trellian.com', 25229363, 0)
INSERT [dbo].[Pacientes] ([id_Paciente], [nombre], [apellido], [celular], [email], [dni], [obraSocial]) VALUES (30, N'Shea', N'Buyers', N'988-445-7179', N'sbuyerst@arizona.edu', 48832971, 2)
SET IDENTITY_INSERT [dbo].[Pacientes] OFF
GO
USE [master]
GO
ALTER DATABASE [ClinicaBD] SET  READ_WRITE 
GO
