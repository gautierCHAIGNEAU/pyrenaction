USE [master]
GO
/****** Object:  Database [pyrenaction]    Script Date: 26/04/2018 09:14:58 ******/
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
/****** Object:  Table [dbo].[Action]    Script Date: 26/04/2018 09:14:58 ******/
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
	[nb_points] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Famille]    Script Date: 26/04/2018 09:14:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Famille](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nom] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Importance]    Script Date: 26/04/2018 09:14:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Importance](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nom] [varchar](50) NULL,
	[numero] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lien]    Script Date: 26/04/2018 09:14:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lien](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nom] [varchar](100) NULL,
	[url] [varchar](500) NULL,
	[id_Action] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mail]    Script Date: 26/04/2018 09:14:59 ******/
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
	[id_Action] [int] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Question]    Script Date: 26/04/2018 09:14:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[intitule] [varchar](500) NULL,
	[reponse] [bit] NULL,
	[commentaire] [varchar](500) NULL,
	[id_Questionnaire] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Questionnaire]    Script Date: 26/04/2018 09:14:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Questionnaire](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nb_point] [int] NULL,
	[nom] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Site]    Script Date: 26/04/2018 09:14:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Site](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nom] [varchar](200) NULL,
	[adresse] [varchar](200) NULL,
	[ville] [varchar](50) NULL,
	[cp] [varchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tache]    Script Date: 26/04/2018 09:14:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tache](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[statut] [bit] NULL,
	[nom] [varchar](200) NULL,
	[id_Action] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Utilisateur]    Script Date: 26/04/2018 09:14:59 ******/
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
	[tel] [varchar](20) NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Famille] ON 

INSERT [dbo].[Famille] ([id], [nom]) VALUES (1, N'RH')
INSERT [dbo].[Famille] ([id], [nom]) VALUES (2, N'MATERIEL')
INSERT [dbo].[Famille] ([id], [nom]) VALUES (3, N'QUALITE')
INSERT [dbo].[Famille] ([id], [nom]) VALUES (4, N'SECURITE')
INSERT [dbo].[Famille] ([id], [nom]) VALUES (5, N'ENVIRONNEMENT')
SET IDENTITY_INSERT [dbo].[Famille] OFF
SET IDENTITY_INSERT [dbo].[Importance] ON 

INSERT [dbo].[Importance] ([id], [nom], [numero]) VALUES (1, N'URGENT', 1)
INSERT [dbo].[Importance] ([id], [nom], [numero]) VALUES (2, N'PEU IMPORTANT', 2)
INSERT [dbo].[Importance] ([id], [nom], [numero]) VALUES (3, N'ACTION CORRECTIVE NON ACHEVEE', 3)
SET IDENTITY_INSERT [dbo].[Importance] OFF
SET IDENTITY_INSERT [dbo].[Question] ON 

INSERT [dbo].[Question] ([id], [intitule], [reponse], [commentaire], [id_Questionnaire]) VALUES (1, N'Trouvez vous que le projet traité est bon ? Oui (3 points) Non (1 points). Si non, détaillez.', NULL, NULL, 1)
INSERT [dbo].[Question] ([id], [intitule], [reponse], [commentaire], [id_Questionnaire]) VALUES (2, N'Les taux sont-ils bons ? Oui (3 points) Non (1 point). Si non, qu''avez-vous trouvé ?', NULL, NULL, 1)
INSERT [dbo].[Question] ([id], [intitule], [reponse], [commentaire], [id_Questionnaire]) VALUES (3, N'Toutes les personnes sont formées et informées ? Oui (3 points) Non (1 points). Qui manque t-il ?', NULL, NULL, 1)
INSERT [dbo].[Question] ([id], [intitule], [reponse], [commentaire], [id_Questionnaire]) VALUES (4, N'Avez-vous des subjections à faire ? Oui (1 points) Non (3 points). Si oui, lesquels ?', NULL, NULL, 1)
INSERT [dbo].[Question] ([id], [intitule], [reponse], [commentaire], [id_Questionnaire]) VALUES (5, N'Cette action doit-elle se refaire ? Oui (1 point) Non (3points).', NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[Question] OFF
SET IDENTITY_INSERT [dbo].[Questionnaire] ON 

INSERT [dbo].[Questionnaire] ([id], [nb_point], [nom]) VALUES (1, 5, N'Quest 1')
SET IDENTITY_INSERT [dbo].[Questionnaire] OFF
SET IDENTITY_INSERT [dbo].[Site] ON 

INSERT [dbo].[Site] ([id], [nom], [adresse], [ville], [cp]) VALUES (1, N'RAYNAL', N'adresse site RAYNAL', N'RAYNAL', N'99999')
INSERT [dbo].[Site] ([id], [nom], [adresse], [ville], [cp]) VALUES (2, N'TARBES', N'adresse Raynal site TARBES', N'TARBES', N'65000')
INSERT [dbo].[Site] ([id], [nom], [adresse], [ville], [cp]) VALUES (3, N'PERIOLE', N'adresse Raynal site PERIOLE', N'PERIOLE', N'99999')
INSERT [dbo].[Site] ([id], [nom], [adresse], [ville], [cp]) VALUES (4, N'PAU', N'adresse Raynal site PAU', N'PAU', N'64000')
INSERT [dbo].[Site] ([id], [nom], [adresse], [ville], [cp]) VALUES (5, N'ERM 1', N'adresse Raynal site ERM 1', N'UNK', N'99999')
INSERT [dbo].[Site] ([id], [nom], [adresse], [ville], [cp]) VALUES (6, N'ATV', N'adresse Raynal site ATV', N'UNK', N'99999')
INSERT [dbo].[Site] ([id], [nom], [adresse], [ville], [cp]) VALUES (7, N'TOUS', NULL, N'UNK', N'99999')
SET IDENTITY_INSERT [dbo].[Site] OFF
SET IDENTITY_INSERT [dbo].[Utilisateur] ON 

INSERT [dbo].[Utilisateur] ([id], [nom], [prenom], [mdp], [qse], [email], [tel]) VALUES (1, N'CHEYNET', N'C', N'UNK', 0, N'jeromelesperon@gmail.com', N'UNK')
INSERT [dbo].[Utilisateur] ([id], [nom], [prenom], [mdp], [qse], [email], [tel]) VALUES (2, N'LASSERON', N'C', N'UNK', 1, N'jeromelesperon@gmail.com', N'UNK')
INSERT [dbo].[Utilisateur] ([id], [nom], [prenom], [mdp], [qse], [email], [tel]) VALUES (3, N'THIEBAULT', N'E', N'UNK', 0, N'jeromelesperon@gmail.com', N'UNK')
INSERT [dbo].[Utilisateur] ([id], [nom], [prenom], [mdp], [qse], [email], [tel]) VALUES (4, N'GOCZON', N'E', N'UNK', 0, N'jeromelesperon@gmail.com', N'UNK')
INSERT [dbo].[Utilisateur] ([id], [nom], [prenom], [mdp], [qse], [email], [tel]) VALUES (5, N'AUDDOUY', N'F-L', N'UNK', 0, N'jeromelesperon@gmail.com', N'UNK')
INSERT [dbo].[Utilisateur] ([id], [nom], [prenom], [mdp], [qse], [email], [tel]) VALUES (6, N'AMEUR', N'H', N'UNK', 0, N'jeromelesperon@gmail.com', N'UNK')
INSERT [dbo].[Utilisateur] ([id], [nom], [prenom], [mdp], [qse], [email], [tel]) VALUES (7, N'ABADIE', N'J-P', N'UNK', 0, N'jeromelesperon@gmail.com', N'UNK')
INSERT [dbo].[Utilisateur] ([id], [nom], [prenom], [mdp], [qse], [email], [tel]) VALUES (8, N'BENCHADI', N'M', N'UNK', 0, N'jeromelesperon@gmail.com', N'UNK')
INSERT [dbo].[Utilisateur] ([id], [nom], [prenom], [mdp], [qse], [email], [tel]) VALUES (9, N'MARTY', N'M', N'UNK', 0, N'jeromelesperon@gmail.com', N'UNK')
INSERT [dbo].[Utilisateur] ([id], [nom], [prenom], [mdp], [qse], [email], [tel]) VALUES (10, N'FREDET', N'P', N'UNK', 0, N'jeromelesperon@gmail.com', N'UNK')
INSERT [dbo].[Utilisateur] ([id], [nom], [prenom], [mdp], [qse], [email], [tel]) VALUES (11, N'FREZIER', N'T', N'UNK', 0, N'jeromelesperon@gmail.com', N'UNK')
INSERT [dbo].[Utilisateur] ([id], [nom], [prenom], [mdp], [qse], [email], [tel]) VALUES (12, N'MONTOUT', N'T', N'UNK', 0, N'jeromelesperon@gmail.com', N'UNK')
INSERT [dbo].[Utilisateur] ([id], [nom], [prenom], [mdp], [qse], [email], [tel]) VALUES (13, N'DEXTER', N'T', N'UNK', 1, N'jeromelesperon@gmail.com', N'UNK')
INSERT [dbo].[Utilisateur] ([id], [nom], [prenom], [mdp], [qse], [email], [tel]) VALUES (14, N'MAFFRE', N'Y', N'UNK', 0, N'jeromelesperon@gmail.com', N'UNK')
INSERT [dbo].[Utilisateur] ([id], [nom], [prenom], [mdp], [qse], [email], [tel]) VALUES (18, N'CHAIGNEAU', N'G', N'toto', 1, N'gautier.chaigneau@gmail.com', N'0562356879')
SET IDENTITY_INSERT [dbo].[Utilisateur] OFF
/****** Object:  Index [prk_constraint_Action]    Script Date: 26/04/2018 09:14:59 ******/
ALTER TABLE [dbo].[Action] ADD  CONSTRAINT [prk_constraint_Action] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [prk_constraint_Famille]    Script Date: 26/04/2018 09:14:59 ******/
ALTER TABLE [dbo].[Famille] ADD  CONSTRAINT [prk_constraint_Famille] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [prk_constraint_Importance]    Script Date: 26/04/2018 09:14:59 ******/
ALTER TABLE [dbo].[Importance] ADD  CONSTRAINT [prk_constraint_Importance] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [prk_constraint_Lien]    Script Date: 26/04/2018 09:14:59 ******/
ALTER TABLE [dbo].[Lien] ADD  CONSTRAINT [prk_constraint_Lien] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [prk_constraint_Mail]    Script Date: 26/04/2018 09:14:59 ******/
ALTER TABLE [dbo].[Mail] ADD  CONSTRAINT [prk_constraint_Mail] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [prk_constraint_Question]    Script Date: 26/04/2018 09:14:59 ******/
ALTER TABLE [dbo].[Question] ADD  CONSTRAINT [prk_constraint_Question] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [prk_constraint_Questionnaire]    Script Date: 26/04/2018 09:14:59 ******/
ALTER TABLE [dbo].[Questionnaire] ADD  CONSTRAINT [prk_constraint_Questionnaire] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [prk_constraint_Site]    Script Date: 26/04/2018 09:14:59 ******/
ALTER TABLE [dbo].[Site] ADD  CONSTRAINT [prk_constraint_Site] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [prk_constraint_Tache]    Script Date: 26/04/2018 09:14:59 ******/
ALTER TABLE [dbo].[Tache] ADD  CONSTRAINT [prk_constraint_Tache] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [prk_constraint_Utilisateur]    Script Date: 26/04/2018 09:14:59 ******/
ALTER TABLE [dbo].[Utilisateur] ADD  CONSTRAINT [prk_constraint_Utilisateur] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
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
