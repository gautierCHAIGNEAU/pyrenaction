USE [master]
GO
/****** Object:  Database [pyrenaction]    Script Date: 23/04/2018 14:19:35 ******/
CREATE DATABASE [pyrenaction]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'pyrenaction', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\pyrenaction.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'pyrenaction_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\pyrenaction_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [pyrenaction] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [pyrenaction].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [pyrenaction] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [pyrenaction] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [pyrenaction] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [pyrenaction] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [pyrenaction] SET ARITHABORT OFF 
GO
ALTER DATABASE [pyrenaction] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [pyrenaction] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [pyrenaction] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [pyrenaction] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [pyrenaction] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [pyrenaction] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [pyrenaction] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [pyrenaction] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [pyrenaction] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [pyrenaction] SET  DISABLE_BROKER 
GO
ALTER DATABASE [pyrenaction] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [pyrenaction] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [pyrenaction] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [pyrenaction] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [pyrenaction] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [pyrenaction] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [pyrenaction] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [pyrenaction] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [pyrenaction] SET  MULTI_USER 
GO
ALTER DATABASE [pyrenaction] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [pyrenaction] SET DB_CHAINING OFF 
GO
ALTER DATABASE [pyrenaction] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [pyrenaction] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [pyrenaction] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [pyrenaction] SET QUERY_STORE = OFF
GO
USE [pyrenaction]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [pyrenaction]
GO
/****** Object:  Table [dbo].[Action]    Script Date: 23/04/2018 14:19:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Action](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[date_a] [datetime] NULL,
	[delais] [datetime] NULL,
	[source] [varchar](500) NULL,
	[analyse] [varchar](200) NULL,
	[description] [varchar](200) NULL,
	[statut] [bit] NULL,
	[id_Importance] [int] NOT NULL,
	[id_Famille] [int] NOT NULL,
	[id_Site] [int] NOT NULL,
	[id_Questionnaire] [int] NULL,
	[id_1] [int] NULL,
	[id_Utilisateur] [int] NOT NULL,
	[id_Utilisateur_2] [int] NULL,
 CONSTRAINT [prk_constraint_Action] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Famille]    Script Date: 23/04/2018 14:19:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Famille](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nom] [varchar](50) NULL,
 CONSTRAINT [prk_constraint_Famille] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Importance]    Script Date: 23/04/2018 14:19:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Importance](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nom] [varchar](50) NULL,
	[numero] [int] NULL,
 CONSTRAINT [prk_constraint_Importance] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lien]    Script Date: 23/04/2018 14:19:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lien](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nom] [varchar](100) NULL,
	[url] [varchar](500) NULL,
	[id_Action] [int] NOT NULL,
 CONSTRAINT [prk_constraint_Lien] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mail]    Script Date: 23/04/2018 14:19:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mail](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[objet] [varchar](200) NULL,
	[contenu] [text] NULL,
	[date_m] [datetime] NULL,
	[id_Utilisateur] [int] NOT NULL,
	[id_Action] [int] NOT NULL,
 CONSTRAINT [prk_constraint_Mail] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Question]    Script Date: 23/04/2018 14:19:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[intitule] [varchar](500) NULL,
	[reponse] [bit] NULL,
	[commentaire] [varchar](500) NULL,
	[id_Questionnaire] [int] NULL,
 CONSTRAINT [prk_constraint_Question] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Questionnaire]    Script Date: 23/04/2018 14:19:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Questionnaire](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nb_point] [int] NULL,
 CONSTRAINT [prk_constraint_Questionnaire] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Site]    Script Date: 23/04/2018 14:19:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Site](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nom] [varchar](200) NULL,
	[adresse] [varchar](200) NULL,
	[ville] [varchar](50) NULL,
	[cp] [varchar](10) NULL,
 CONSTRAINT [prk_constraint_Site] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tache]    Script Date: 23/04/2018 14:19:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tache](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[statut] [bit] NULL,
	[nom] [varchar](200) NULL,
	[id_Action] [int] NOT NULL,
 CONSTRAINT [prk_constraint_Tache] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Utilisateur]    Script Date: 23/04/2018 14:19:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Utilisateur](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nom] [varchar](50) NULL,
	[prenom] [varchar](50) NULL,
	[mdp] [varchar](500) NULL,
	[qse] [bit] NULL,
	[email] [varchar](50) NULL,
	[tel] [varchar](20) NULL,
 CONSTRAINT [prk_constraint_Utilisateur] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Action]  WITH CHECK ADD  CONSTRAINT [FK_Action_id_1] FOREIGN KEY([id_1])
REFERENCES [dbo].[Action] ([id])
GO
ALTER TABLE [dbo].[Action] CHECK CONSTRAINT [FK_Action_id_1]
GO
ALTER TABLE [dbo].[Action]  WITH CHECK ADD  CONSTRAINT [FK_Action_id_Famille] FOREIGN KEY([id_Famille])
REFERENCES [dbo].[Famille] ([id])
GO
ALTER TABLE [dbo].[Action] CHECK CONSTRAINT [FK_Action_id_Famille]
GO
ALTER TABLE [dbo].[Action]  WITH CHECK ADD  CONSTRAINT [FK_Action_id_Importance] FOREIGN KEY([id_Importance])
REFERENCES [dbo].[Importance] ([id])
GO
ALTER TABLE [dbo].[Action] CHECK CONSTRAINT [FK_Action_id_Importance]
GO
ALTER TABLE [dbo].[Action]  WITH CHECK ADD  CONSTRAINT [FK_Action_id_Questionnaire] FOREIGN KEY([id_Questionnaire])
REFERENCES [dbo].[Questionnaire] ([id])
GO
ALTER TABLE [dbo].[Action] CHECK CONSTRAINT [FK_Action_id_Questionnaire]
GO
ALTER TABLE [dbo].[Action]  WITH CHECK ADD  CONSTRAINT [FK_Action_id_Site] FOREIGN KEY([id_Site])
REFERENCES [dbo].[Site] ([id])
GO
ALTER TABLE [dbo].[Action] CHECK CONSTRAINT [FK_Action_id_Site]
GO
ALTER TABLE [dbo].[Action]  WITH CHECK ADD  CONSTRAINT [FK_Action_id_Utilisateur] FOREIGN KEY([id_Utilisateur])
REFERENCES [dbo].[Utilisateur] ([id])
GO
ALTER TABLE [dbo].[Action] CHECK CONSTRAINT [FK_Action_id_Utilisateur]
GO
ALTER TABLE [dbo].[Action]  WITH CHECK ADD  CONSTRAINT [FK_Action_id_Utilisateur_2] FOREIGN KEY([id_Utilisateur_2])
REFERENCES [dbo].[Utilisateur] ([id])
GO
ALTER TABLE [dbo].[Action] CHECK CONSTRAINT [FK_Action_id_Utilisateur_2]
GO
ALTER TABLE [dbo].[Lien]  WITH CHECK ADD  CONSTRAINT [FK_Lien_id_Action] FOREIGN KEY([id_Action])
REFERENCES [dbo].[Action] ([id])
GO
ALTER TABLE [dbo].[Lien] CHECK CONSTRAINT [FK_Lien_id_Action]
GO
ALTER TABLE [dbo].[Mail]  WITH CHECK ADD  CONSTRAINT [FK_Mail_id_Action] FOREIGN KEY([id_Action])
REFERENCES [dbo].[Action] ([id])
GO
ALTER TABLE [dbo].[Mail] CHECK CONSTRAINT [FK_Mail_id_Action]
GO
ALTER TABLE [dbo].[Mail]  WITH CHECK ADD  CONSTRAINT [FK_Mail_id_Utilisateur] FOREIGN KEY([id_Utilisateur])
REFERENCES [dbo].[Utilisateur] ([id])
GO
ALTER TABLE [dbo].[Mail] CHECK CONSTRAINT [FK_Mail_id_Utilisateur]
GO
ALTER TABLE [dbo].[Question]  WITH CHECK ADD  CONSTRAINT [FK_Question_id_Questionnaire] FOREIGN KEY([id_Questionnaire])
REFERENCES [dbo].[Questionnaire] ([id])
GO
ALTER TABLE [dbo].[Question] CHECK CONSTRAINT [FK_Question_id_Questionnaire]
GO
ALTER TABLE [dbo].[Tache]  WITH CHECK ADD  CONSTRAINT [FK_Tache_id_Action] FOREIGN KEY([id_Action])
REFERENCES [dbo].[Action] ([id])
GO
ALTER TABLE [dbo].[Tache] CHECK CONSTRAINT [FK_Tache_id_Action]
GO
USE [master]
GO
ALTER DATABASE [pyrenaction] SET  READ_WRITE 
GO
