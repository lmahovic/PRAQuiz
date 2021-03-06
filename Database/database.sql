USE [master]
GO
/****** Object:  Database [PRAQuiz]    Script Date: 3.2.2022. 13:36:52 ******/
CREATE DATABASE [PRAQuiz]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PRAQuiz', FILENAME = N'C:\Users\Lav\PRAQuiz.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PRAQuiz_log', FILENAME = N'C:\Users\Lav\PRAQuiz_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [PRAQuiz] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PRAQuiz].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PRAQuiz] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PRAQuiz] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PRAQuiz] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PRAQuiz] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PRAQuiz] SET ARITHABORT OFF 
GO
ALTER DATABASE [PRAQuiz] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [PRAQuiz] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PRAQuiz] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PRAQuiz] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PRAQuiz] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PRAQuiz] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PRAQuiz] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PRAQuiz] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PRAQuiz] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PRAQuiz] SET  ENABLE_BROKER 
GO
ALTER DATABASE [PRAQuiz] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PRAQuiz] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PRAQuiz] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PRAQuiz] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PRAQuiz] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PRAQuiz] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PRAQuiz] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PRAQuiz] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PRAQuiz] SET  MULTI_USER 
GO
ALTER DATABASE [PRAQuiz] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PRAQuiz] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PRAQuiz] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PRAQuiz] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PRAQuiz] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PRAQuiz] SET QUERY_STORE = OFF
GO
USE [PRAQuiz]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [PRAQuiz]
GO
/****** Object:  Table [dbo].[Answer]    Script Date: 3.2.2022. 13:36:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Answer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AnswerText] [nvarchar](250) NOT NULL,
	[Correct] [bit] NOT NULL,
	[QuestionID] [int] NOT NULL,
	[AnswerOrder] [tinyint] NOT NULL,
 CONSTRAINT [Answer_pk] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Author]    Script Date: 3.2.2022. 13:36:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Author](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [Author_pk] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Game]    Script Date: 3.2.2022. 13:36:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Game](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[QuizID] [int] NOT NULL,
	[GamePIN] [nvarchar](10) NOT NULL,
	[StartTime] [datetime] NULL,
	[FinishTime] [datetime] NULL,
 CONSTRAINT [Game_pk] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Player]    Script Date: 3.2.2022. 13:36:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Player](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nickname] [nvarchar](50) NOT NULL,
	[GameID] [int] NOT NULL,
	[HasQuit] [bit] NOT NULL,
 CONSTRAINT [Player_pk] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlayerQuestionAnswer]    Script Date: 3.2.2022. 13:36:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlayerQuestionAnswer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PlayerID] [int] NOT NULL,
	[QuestionID] [int] NOT NULL,
	[AnswerID] [int] NULL,
	[AnswerTime] [bigint] NULL,
	[Points] [int] NULL,
 CONSTRAINT [PlayerQuestionAnswer_pk] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlayerRanking]    Script Date: 3.2.2022. 13:36:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlayerRanking](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PlayerID] [int] NOT NULL,
	[TotalPoints] [int] NOT NULL,
	[Ranking] [int] NOT NULL,
 CONSTRAINT [PlayerRanking_pk] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Question]    Script Date: 3.2.2022. 13:36:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[QuestionText] [nvarchar](500) NOT NULL,
	[TimeLimit] [int] NOT NULL,
	[QuizID] [int] NOT NULL,
	[QuestionOrder] [tinyint] NOT NULL,
 CONSTRAINT [Question_pk] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Quiz]    Script Date: 3.2.2022. 13:36:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quiz](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[AuthorID] [int] NOT NULL,
 CONSTRAINT [Quiz_pk] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Answer] ON 

INSERT [dbo].[Answer] ([ID], [AnswerText], [Correct], [QuestionID], [AnswerOrder]) VALUES (1, N'Test answer 1', 1, 1, 1)
INSERT [dbo].[Answer] ([ID], [AnswerText], [Correct], [QuestionID], [AnswerOrder]) VALUES (2, N'Test answer 2', 0, 1, 2)
INSERT [dbo].[Answer] ([ID], [AnswerText], [Correct], [QuestionID], [AnswerOrder]) VALUES (7, N'Test answer 1', 1, 2, 1)
INSERT [dbo].[Answer] ([ID], [AnswerText], [Correct], [QuestionID], [AnswerOrder]) VALUES (8, N'Test answer 2', 0, 2, 2)
INSERT [dbo].[Answer] ([ID], [AnswerText], [Correct], [QuestionID], [AnswerOrder]) VALUES (10, N'Test answer 3-2', 0, 2, 3)
INSERT [dbo].[Answer] ([ID], [AnswerText], [Correct], [QuestionID], [AnswerOrder]) VALUES (11, N'Test answer 3-1', 1, 3, 1)
INSERT [dbo].[Answer] ([ID], [AnswerText], [Correct], [QuestionID], [AnswerOrder]) VALUES (12, N'Test answer 3-2', 0, 3, 2)
INSERT [dbo].[Answer] ([ID], [AnswerText], [Correct], [QuestionID], [AnswerOrder]) VALUES (13, N'Test answer 3-3', 0, 3, 3)
INSERT [dbo].[Answer] ([ID], [AnswerText], [Correct], [QuestionID], [AnswerOrder]) VALUES (14, N'Test answer 3-4', 0, 3, 4)
SET IDENTITY_INSERT [dbo].[Answer] OFF
GO
SET IDENTITY_INSERT [dbo].[Author] ON 

INSERT [dbo].[Author] ([ID], [Email], [Password]) VALUES (1, N'TestEmail', N'TestPassword')
SET IDENTITY_INSERT [dbo].[Author] OFF
GO
SET IDENTITY_INSERT [dbo].[Game] ON 

INSERT [dbo].[Game] ([ID], [QuizID], [GamePIN], [StartTime], [FinishTime]) VALUES (1, 1, N'1', NULL, CAST(N'2022-02-02T19:41:26.767' AS DateTime))
INSERT [dbo].[Game] ([ID], [QuizID], [GamePIN], [StartTime], [FinishTime]) VALUES (2, 1, N'72167', CAST(N'2022-02-01T13:53:36.377' AS DateTime), CAST(N'2022-02-02T19:41:26.767' AS DateTime))
INSERT [dbo].[Game] ([ID], [QuizID], [GamePIN], [StartTime], [FinishTime]) VALUES (5, 1, N'86712', NULL, CAST(N'2022-02-02T19:41:26.767' AS DateTime))
INSERT [dbo].[Game] ([ID], [QuizID], [GamePIN], [StartTime], [FinishTime]) VALUES (6, 1, N'21566', NULL, CAST(N'2022-02-02T19:41:26.767' AS DateTime))
INSERT [dbo].[Game] ([ID], [QuizID], [GamePIN], [StartTime], [FinishTime]) VALUES (7, 1, N'17131', NULL, CAST(N'2022-02-02T19:41:26.767' AS DateTime))
INSERT [dbo].[Game] ([ID], [QuizID], [GamePIN], [StartTime], [FinishTime]) VALUES (8, 1, N'27622', NULL, CAST(N'2022-02-02T19:41:26.767' AS DateTime))
INSERT [dbo].[Game] ([ID], [QuizID], [GamePIN], [StartTime], [FinishTime]) VALUES (9, 1, N'70267', NULL, CAST(N'2022-02-02T19:41:26.767' AS DateTime))
INSERT [dbo].[Game] ([ID], [QuizID], [GamePIN], [StartTime], [FinishTime]) VALUES (10, 1, N'24768', CAST(N'2022-02-02T18:12:48.533' AS DateTime), CAST(N'2022-02-02T19:41:26.767' AS DateTime))
INSERT [dbo].[Game] ([ID], [QuizID], [GamePIN], [StartTime], [FinishTime]) VALUES (11, 1, N'47778', CAST(N'2022-02-02T18:34:11.713' AS DateTime), CAST(N'2022-02-02T19:41:26.767' AS DateTime))
INSERT [dbo].[Game] ([ID], [QuizID], [GamePIN], [StartTime], [FinishTime]) VALUES (12, 1, N'84020', NULL, CAST(N'2022-02-02T19:41:26.767' AS DateTime))
INSERT [dbo].[Game] ([ID], [QuizID], [GamePIN], [StartTime], [FinishTime]) VALUES (13, 1, N'41565', NULL, CAST(N'2022-02-02T19:41:26.767' AS DateTime))
INSERT [dbo].[Game] ([ID], [QuizID], [GamePIN], [StartTime], [FinishTime]) VALUES (14, 1, N'15410', NULL, CAST(N'2022-02-02T19:41:26.767' AS DateTime))
INSERT [dbo].[Game] ([ID], [QuizID], [GamePIN], [StartTime], [FinishTime]) VALUES (15, 1, N'00236', CAST(N'2022-02-02T18:58:06.630' AS DateTime), CAST(N'2022-02-02T19:41:26.767' AS DateTime))
INSERT [dbo].[Game] ([ID], [QuizID], [GamePIN], [StartTime], [FinishTime]) VALUES (16, 1, N'82758', NULL, CAST(N'2022-02-02T19:41:26.767' AS DateTime))
INSERT [dbo].[Game] ([ID], [QuizID], [GamePIN], [StartTime], [FinishTime]) VALUES (17, 1, N'83355', CAST(N'2022-02-02T19:05:18.063' AS DateTime), CAST(N'2022-02-02T19:41:26.767' AS DateTime))
INSERT [dbo].[Game] ([ID], [QuizID], [GamePIN], [StartTime], [FinishTime]) VALUES (18, 1, N'34688', CAST(N'2022-02-02T19:16:51.683' AS DateTime), CAST(N'2022-02-02T19:41:26.767' AS DateTime))
INSERT [dbo].[Game] ([ID], [QuizID], [GamePIN], [StartTime], [FinishTime]) VALUES (19, 1, N'22078', CAST(N'2022-02-02T19:19:50.603' AS DateTime), CAST(N'2022-02-02T19:41:26.767' AS DateTime))
INSERT [dbo].[Game] ([ID], [QuizID], [GamePIN], [StartTime], [FinishTime]) VALUES (20, 1, N'55850', CAST(N'2022-02-02T19:24:06.353' AS DateTime), CAST(N'2022-02-02T19:41:26.767' AS DateTime))
INSERT [dbo].[Game] ([ID], [QuizID], [GamePIN], [StartTime], [FinishTime]) VALUES (21, 1, N'82703', CAST(N'2022-02-02T19:27:06.103' AS DateTime), CAST(N'2022-02-02T19:41:26.767' AS DateTime))
INSERT [dbo].[Game] ([ID], [QuizID], [GamePIN], [StartTime], [FinishTime]) VALUES (22, 1, N'30448', CAST(N'2022-02-02T19:33:40.220' AS DateTime), CAST(N'2022-02-02T19:41:26.767' AS DateTime))
INSERT [dbo].[Game] ([ID], [QuizID], [GamePIN], [StartTime], [FinishTime]) VALUES (23, 1, N'28656', CAST(N'2022-02-02T19:36:59.383' AS DateTime), CAST(N'2022-02-02T19:41:26.767' AS DateTime))
INSERT [dbo].[Game] ([ID], [QuizID], [GamePIN], [StartTime], [FinishTime]) VALUES (24, 1, N'28714', CAST(N'2022-02-02T19:43:34.593' AS DateTime), CAST(N'2022-02-02T19:45:52.120' AS DateTime))
INSERT [dbo].[Game] ([ID], [QuizID], [GamePIN], [StartTime], [FinishTime]) VALUES (25, 1, N'15321', CAST(N'2022-02-02T19:48:00.363' AS DateTime), NULL)
INSERT [dbo].[Game] ([ID], [QuizID], [GamePIN], [StartTime], [FinishTime]) VALUES (26, 1, N'17062', CAST(N'2022-02-02T19:53:30.213' AS DateTime), CAST(N'2022-02-02T19:54:38.377' AS DateTime))
INSERT [dbo].[Game] ([ID], [QuizID], [GamePIN], [StartTime], [FinishTime]) VALUES (27, 1, N'12323', CAST(N'2022-02-02T19:58:29.590' AS DateTime), NULL)
INSERT [dbo].[Game] ([ID], [QuizID], [GamePIN], [StartTime], [FinishTime]) VALUES (28, 1, N'30701', CAST(N'2022-02-02T21:00:01.043' AS DateTime), CAST(N'2022-02-02T21:02:05.180' AS DateTime))
INSERT [dbo].[Game] ([ID], [QuizID], [GamePIN], [StartTime], [FinishTime]) VALUES (29, 1, N'70455', CAST(N'2022-02-02T23:18:26.250' AS DateTime), CAST(N'2022-02-02T23:19:54.227' AS DateTime))
INSERT [dbo].[Game] ([ID], [QuizID], [GamePIN], [StartTime], [FinishTime]) VALUES (30, 1, N'35487', NULL, NULL)
INSERT [dbo].[Game] ([ID], [QuizID], [GamePIN], [StartTime], [FinishTime]) VALUES (31, 1, N'68761', CAST(N'2022-02-03T13:28:26.250' AS DateTime), CAST(N'2022-02-03T13:29:17.130' AS DateTime))
SET IDENTITY_INSERT [dbo].[Game] OFF
GO
SET IDENTITY_INSERT [dbo].[Player] ON 

INSERT [dbo].[Player] ([ID], [Nickname], [GameID], [HasQuit]) VALUES (1, N'TestPlayer', 1, 0)
INSERT [dbo].[Player] ([ID], [Nickname], [GameID], [HasQuit]) VALUES (2, N'TestPlayer2', 1, 0)
INSERT [dbo].[Player] ([ID], [Nickname], [GameID], [HasQuit]) VALUES (3, N'TestPlayer3', 1, 0)
INSERT [dbo].[Player] ([ID], [Nickname], [GameID], [HasQuit]) VALUES (9, N'TestPlayer99', 1, 0)
INSERT [dbo].[Player] ([ID], [Nickname], [GameID], [HasQuit]) VALUES (10, N'TestPlayer69', 1, 0)
INSERT [dbo].[Player] ([ID], [Nickname], [GameID], [HasQuit]) VALUES (11, N'TestPlayer79', 1, 0)
INSERT [dbo].[Player] ([ID], [Nickname], [GameID], [HasQuit]) VALUES (12, N'1', 1, 1)
INSERT [dbo].[Player] ([ID], [Nickname], [GameID], [HasQuit]) VALUES (13, N'Test669', 1, 0)
INSERT [dbo].[Player] ([ID], [Nickname], [GameID], [HasQuit]) VALUES (14, N'Test123', 7, 0)
INSERT [dbo].[Player] ([ID], [Nickname], [GameID], [HasQuit]) VALUES (15, N'Test', 8, 0)
INSERT [dbo].[Player] ([ID], [Nickname], [GameID], [HasQuit]) VALUES (16, N'Test', 10, 0)
INSERT [dbo].[Player] ([ID], [Nickname], [GameID], [HasQuit]) VALUES (17, N'Test', 11, 0)
INSERT [dbo].[Player] ([ID], [Nickname], [GameID], [HasQuit]) VALUES (18, N'Test', 15, 1)
INSERT [dbo].[Player] ([ID], [Nickname], [GameID], [HasQuit]) VALUES (19, N'Test', 17, 1)
INSERT [dbo].[Player] ([ID], [Nickname], [GameID], [HasQuit]) VALUES (20, N'dasdas', 18, 0)
INSERT [dbo].[Player] ([ID], [Nickname], [GameID], [HasQuit]) VALUES (21, N'dasdas', 19, 1)
INSERT [dbo].[Player] ([ID], [Nickname], [GameID], [HasQuit]) VALUES (22, N'dasdas', 20, 1)
INSERT [dbo].[Player] ([ID], [Nickname], [GameID], [HasQuit]) VALUES (23, N'dasdas', 21, 0)
INSERT [dbo].[Player] ([ID], [Nickname], [GameID], [HasQuit]) VALUES (24, N'dasdas', 22, 0)
INSERT [dbo].[Player] ([ID], [Nickname], [GameID], [HasQuit]) VALUES (25, N'dasdas', 23, 0)
INSERT [dbo].[Player] ([ID], [Nickname], [GameID], [HasQuit]) VALUES (26, N'dasdas', 24, 0)
INSERT [dbo].[Player] ([ID], [Nickname], [GameID], [HasQuit]) VALUES (27, N'dasdas2', 24, 0)
INSERT [dbo].[Player] ([ID], [Nickname], [GameID], [HasQuit]) VALUES (28, N'dasdas3', 24, 0)
INSERT [dbo].[Player] ([ID], [Nickname], [GameID], [HasQuit]) VALUES (29, N'dasdas', 25, 0)
INSERT [dbo].[Player] ([ID], [Nickname], [GameID], [HasQuit]) VALUES (30, N'dasdas2', 25, 0)
INSERT [dbo].[Player] ([ID], [Nickname], [GameID], [HasQuit]) VALUES (31, N'dasdas3', 25, 1)
INSERT [dbo].[Player] ([ID], [Nickname], [GameID], [HasQuit]) VALUES (32, N'dasdas', 26, 0)
INSERT [dbo].[Player] ([ID], [Nickname], [GameID], [HasQuit]) VALUES (33, N'dasdas2', 26, 0)
INSERT [dbo].[Player] ([ID], [Nickname], [GameID], [HasQuit]) VALUES (34, N'dasdas3', 26, 1)
INSERT [dbo].[Player] ([ID], [Nickname], [GameID], [HasQuit]) VALUES (35, N'dasdas', 27, 0)
INSERT [dbo].[Player] ([ID], [Nickname], [GameID], [HasQuit]) VALUES (36, N'dasdas2', 27, 0)
INSERT [dbo].[Player] ([ID], [Nickname], [GameID], [HasQuit]) VALUES (37, N'dasdas3', 27, 0)
INSERT [dbo].[Player] ([ID], [Nickname], [GameID], [HasQuit]) VALUES (38, N'dasdas', 28, 0)
INSERT [dbo].[Player] ([ID], [Nickname], [GameID], [HasQuit]) VALUES (39, N'dasdas2', 28, 0)
INSERT [dbo].[Player] ([ID], [Nickname], [GameID], [HasQuit]) VALUES (40, N'dasdas3', 28, 0)
INSERT [dbo].[Player] ([ID], [Nickname], [GameID], [HasQuit]) VALUES (41, N'dasdas', 29, 0)
INSERT [dbo].[Player] ([ID], [Nickname], [GameID], [HasQuit]) VALUES (42, N'dasdas2', 29, 0)
INSERT [dbo].[Player] ([ID], [Nickname], [GameID], [HasQuit]) VALUES (43, N'dasdas', 30, 0)
INSERT [dbo].[Player] ([ID], [Nickname], [GameID], [HasQuit]) VALUES (44, N'dasdas', 31, 0)
SET IDENTITY_INSERT [dbo].[Player] OFF
GO
SET IDENTITY_INSERT [dbo].[PlayerQuestionAnswer] ON 

INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (381, 1, 1, 11, NULL, 10)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (382, 2, 1, 11, NULL, 10)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (383, 3, 1, 11, NULL, 10)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (384, 9, 1, 11, NULL, 10)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (385, 10, 1, 11, NULL, 10)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (386, 11, 1, 11, NULL, 10)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (387, 12, 1, 11, NULL, 10)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (388, 13, 1, 11, NULL, 10)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (389, 1, 2, 11, NULL, 10)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (390, 2, 2, 11, NULL, 10)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (391, 3, 2, 11, NULL, 10)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (392, 9, 2, 11, NULL, 10)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (393, 10, 2, 11, NULL, 10)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (394, 11, 2, 11, NULL, 10)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (395, 12, 2, 11, NULL, 10)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (396, 13, 2, 11, NULL, 10)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (397, 1, 3, 11, NULL, 10)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (398, 2, 3, 11, NULL, 10)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (399, 3, 3, 11, NULL, 10)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (400, 9, 3, 11, NULL, 10)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (401, 10, 3, 11, NULL, 10)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (402, 11, 3, 11, NULL, 10)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (403, 12, 3, 11, NULL, 10)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (404, 13, 3, 11, NULL, 10)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (405, 14, 1, 1, 10650, 200)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (406, 14, 2, NULL, 10000, 0)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (407, 14, 3, 11, 7233, 200)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (408, 15, 1, NULL, NULL, NULL)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (409, 16, 1, 1, 14677, 200)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (410, 16, 2, NULL, 10000, 0)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (411, 17, 1, 1, 5796, 200)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (412, 17, 2, NULL, 10000, 0)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (413, 17, 3, 11, 4845, 200)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (414, 18, 1, 1, 5283, 200)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (415, 18, 2, NULL, 10000, 0)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (416, 18, 3, 11, 1185, 200)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (417, 19, 1, 1, 6893, 200)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (418, 19, 2, 7, 4550, 154)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (419, 19, 3, 11, 3685, 200)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (420, 20, 1, NULL, NULL, NULL)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (421, 21, 1, 1, 12051, 200)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (422, 21, 2, 7, 3028, 170)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (423, 21, 3, 11, 3448, 200)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (424, 22, 1, 1, 9495, 200)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (425, 22, 2, 7, 4511, 155)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (426, 22, 3, 11, 4183, 200)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (427, 23, 1, 1, 4837, 200)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (428, 23, 2, 7, 4964, 150)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (429, 23, 3, 11, 1248, 200)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (430, 24, 1, 1, 2727, 200)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (431, 24, 2, 7, 1022, 190)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (432, 24, 3, 11, 2448, 200)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (433, 25, 1, 1, 8241, 200)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (434, 25, 2, 7, 6295, 137)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (435, 25, 3, 11, 2458, 200)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (436, 26, 1, 1, 3524, 165)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (437, 27, 1, 2, 5577, 0)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (438, 28, 1, 1, 7394, 126)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (439, 26, 2, 10, 6357, 0)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (440, 27, 2, 7, 9104, 139)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (441, 28, 2, NULL, 15000, 0)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (442, 26, 3, 11, 5071, 175)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (443, 27, 3, 13, 9319, 0)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (444, 28, 3, 11, 12403, 138)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (445, 29, 1, NULL, 10000, 0)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (446, 30, 1, NULL, 10000, 0)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (447, 31, 1, NULL, 10000, 0)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (448, 29, 2, NULL, 15000, 0)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (449, 30, 2, NULL, 15000, 0)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (450, 31, 2, NULL, 15000, 0)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (451, 29, 3, 12, 1225, 0)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (452, 30, 3, 12, 2462, 0)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (453, 31, 3, NULL, NULL, NULL)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (454, 32, 1, 1, 7156, 128)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (455, 33, 1, 1, 8326, 117)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (456, 34, 1, 2, 9786, 0)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (457, 32, 2, 8, 2028, 0)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (458, 33, 2, 8, 3032, 0)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (459, 34, 2, NULL, NULL, NULL)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (460, 32, 3, 11, 932, 195)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (461, 33, 3, 11, 1723, 191)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (462, 34, 3, NULL, NULL, NULL)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (463, 35, 1, 1, 8009, 120)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (464, 36, 1, NULL, 10000, 0)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (465, 37, 1, 1, 9480, 105)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (466, 38, 1, 1, 8555, 114)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (467, 39, 1, 1, 7502, 125)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (468, 40, 1, 2, 8936, 0)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (469, 38, 2, 8, 9132, 0)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (470, 39, 2, 7, 5233, 165)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (471, 40, 2, NULL, 15000, 0)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (472, 38, 3, 11, 4610, 177)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (473, 39, 3, 14, 8202, 0)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (474, 40, 3, 11, 5963, 170)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (475, 41, 1, 1, 5378, 146)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (476, 42, 1, 1, 7272, 127)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (477, 41, 2, 8, 4010, 0)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (478, 42, 2, NULL, 15000, 0)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (479, 41, 3, 11, 3569, 182)
GO
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (480, 42, 3, 11, 6280, 169)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (481, 44, 1, 1, 3257, 167)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (482, 44, 2, 7, 3167, 179)
INSERT [dbo].[PlayerQuestionAnswer] ([ID], [PlayerID], [QuestionID], [AnswerID], [AnswerTime], [Points]) VALUES (483, 44, 3, 11, 2994, 185)
SET IDENTITY_INSERT [dbo].[PlayerQuestionAnswer] OFF
GO
SET IDENTITY_INSERT [dbo].[PlayerRanking] ON 

INSERT [dbo].[PlayerRanking] ([ID], [PlayerID], [TotalPoints], [Ranking]) VALUES (124, 1, 30, 1)
INSERT [dbo].[PlayerRanking] ([ID], [PlayerID], [TotalPoints], [Ranking]) VALUES (125, 2, 30, 1)
INSERT [dbo].[PlayerRanking] ([ID], [PlayerID], [TotalPoints], [Ranking]) VALUES (126, 3, 30, 1)
INSERT [dbo].[PlayerRanking] ([ID], [PlayerID], [TotalPoints], [Ranking]) VALUES (127, 9, 30, 1)
INSERT [dbo].[PlayerRanking] ([ID], [PlayerID], [TotalPoints], [Ranking]) VALUES (128, 10, 30, 1)
INSERT [dbo].[PlayerRanking] ([ID], [PlayerID], [TotalPoints], [Ranking]) VALUES (129, 11, 30, 1)
INSERT [dbo].[PlayerRanking] ([ID], [PlayerID], [TotalPoints], [Ranking]) VALUES (130, 12, 30, 1)
INSERT [dbo].[PlayerRanking] ([ID], [PlayerID], [TotalPoints], [Ranking]) VALUES (131, 13, 30, 1)
INSERT [dbo].[PlayerRanking] ([ID], [PlayerID], [TotalPoints], [Ranking]) VALUES (132, 14, 400, 1)
INSERT [dbo].[PlayerRanking] ([ID], [PlayerID], [TotalPoints], [Ranking]) VALUES (133, 16, 200, 1)
INSERT [dbo].[PlayerRanking] ([ID], [PlayerID], [TotalPoints], [Ranking]) VALUES (134, 17, 200, 1)
INSERT [dbo].[PlayerRanking] ([ID], [PlayerID], [TotalPoints], [Ranking]) VALUES (135, 18, 400, 1)
INSERT [dbo].[PlayerRanking] ([ID], [PlayerID], [TotalPoints], [Ranking]) VALUES (136, 19, 554, 1)
INSERT [dbo].[PlayerRanking] ([ID], [PlayerID], [TotalPoints], [Ranking]) VALUES (137, 21, 570, 1)
INSERT [dbo].[PlayerRanking] ([ID], [PlayerID], [TotalPoints], [Ranking]) VALUES (138, 22, 555, 1)
INSERT [dbo].[PlayerRanking] ([ID], [PlayerID], [TotalPoints], [Ranking]) VALUES (139, 23, 350, 1)
INSERT [dbo].[PlayerRanking] ([ID], [PlayerID], [TotalPoints], [Ranking]) VALUES (140, 24, 590, 1)
INSERT [dbo].[PlayerRanking] ([ID], [PlayerID], [TotalPoints], [Ranking]) VALUES (141, 25, 537, 1)
INSERT [dbo].[PlayerRanking] ([ID], [PlayerID], [TotalPoints], [Ranking]) VALUES (142, 26, 340, 1)
INSERT [dbo].[PlayerRanking] ([ID], [PlayerID], [TotalPoints], [Ranking]) VALUES (143, 28, 264, 2)
INSERT [dbo].[PlayerRanking] ([ID], [PlayerID], [TotalPoints], [Ranking]) VALUES (144, 27, 139, 3)
INSERT [dbo].[PlayerRanking] ([ID], [PlayerID], [TotalPoints], [Ranking]) VALUES (145, 29, 0, 1)
INSERT [dbo].[PlayerRanking] ([ID], [PlayerID], [TotalPoints], [Ranking]) VALUES (146, 30, 0, 1)
INSERT [dbo].[PlayerRanking] ([ID], [PlayerID], [TotalPoints], [Ranking]) VALUES (147, 31, 0, 1)
INSERT [dbo].[PlayerRanking] ([ID], [PlayerID], [TotalPoints], [Ranking]) VALUES (148, 32, 323, 1)
INSERT [dbo].[PlayerRanking] ([ID], [PlayerID], [TotalPoints], [Ranking]) VALUES (149, 33, 308, 2)
INSERT [dbo].[PlayerRanking] ([ID], [PlayerID], [TotalPoints], [Ranking]) VALUES (150, 34, 0, 3)
INSERT [dbo].[PlayerRanking] ([ID], [PlayerID], [TotalPoints], [Ranking]) VALUES (151, 39, 290, 2)
INSERT [dbo].[PlayerRanking] ([ID], [PlayerID], [TotalPoints], [Ranking]) VALUES (152, 38, 291, 1)
INSERT [dbo].[PlayerRanking] ([ID], [PlayerID], [TotalPoints], [Ranking]) VALUES (153, 40, 170, 3)
INSERT [dbo].[PlayerRanking] ([ID], [PlayerID], [TotalPoints], [Ranking]) VALUES (154, 41, 328, 1)
INSERT [dbo].[PlayerRanking] ([ID], [PlayerID], [TotalPoints], [Ranking]) VALUES (155, 42, 296, 2)
INSERT [dbo].[PlayerRanking] ([ID], [PlayerID], [TotalPoints], [Ranking]) VALUES (156, 44, 531, 1)
SET IDENTITY_INSERT [dbo].[PlayerRanking] OFF
GO
SET IDENTITY_INSERT [dbo].[Question] ON 

INSERT [dbo].[Question] ([ID], [QuestionText], [TimeLimit], [QuizID], [QuestionOrder]) VALUES (1, N'Test question 1234', 10, 1, 1)
INSERT [dbo].[Question] ([ID], [QuestionText], [TimeLimit], [QuizID], [QuestionOrder]) VALUES (2, N'Test question 2 1234', 15, 1, 2)
INSERT [dbo].[Question] ([ID], [QuestionText], [TimeLimit], [QuizID], [QuestionOrder]) VALUES (3, N'Test question 3 1234', 20, 1, 3)
SET IDENTITY_INSERT [dbo].[Question] OFF
GO
SET IDENTITY_INSERT [dbo].[Quiz] ON 

INSERT [dbo].[Quiz] ([ID], [Title], [AuthorID]) VALUES (1, N'TestQuiz', 1)
INSERT [dbo].[Quiz] ([ID], [Title], [AuthorID]) VALUES (2, N'TestQuiz2', 1)
SET IDENTITY_INSERT [dbo].[Quiz] OFF
GO
/****** Object:  Index [PlayerRanking_PlayerID_uindex]    Script Date: 3.2.2022. 13:36:52 ******/
CREATE UNIQUE NONCLUSTERED INDEX [PlayerRanking_PlayerID_uindex] ON [dbo].[PlayerRanking]
(
	[PlayerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Answer] ADD  DEFAULT ((0)) FOR [Correct]
GO
ALTER TABLE [dbo].[Player] ADD  CONSTRAINT [DF_Player_HasQuit]  DEFAULT ((0)) FOR [HasQuit]
GO
ALTER TABLE [dbo].[Answer]  WITH CHECK ADD  CONSTRAINT [Answer_Question_ID_fk] FOREIGN KEY([QuestionID])
REFERENCES [dbo].[Question] ([ID])
GO
ALTER TABLE [dbo].[Answer] CHECK CONSTRAINT [Answer_Question_ID_fk]
GO
ALTER TABLE [dbo].[Game]  WITH CHECK ADD  CONSTRAINT [Game_Quiz_ID_fk] FOREIGN KEY([QuizID])
REFERENCES [dbo].[Quiz] ([ID])
GO
ALTER TABLE [dbo].[Game] CHECK CONSTRAINT [Game_Quiz_ID_fk]
GO
ALTER TABLE [dbo].[Player]  WITH CHECK ADD  CONSTRAINT [Player_Game_ID_fk] FOREIGN KEY([GameID])
REFERENCES [dbo].[Game] ([ID])
GO
ALTER TABLE [dbo].[Player] CHECK CONSTRAINT [Player_Game_ID_fk]
GO
ALTER TABLE [dbo].[PlayerQuestionAnswer]  WITH CHECK ADD  CONSTRAINT [PlayerQuestionAnswer_Answer_ID_fk] FOREIGN KEY([AnswerID])
REFERENCES [dbo].[Answer] ([ID])
GO
ALTER TABLE [dbo].[PlayerQuestionAnswer] CHECK CONSTRAINT [PlayerQuestionAnswer_Answer_ID_fk]
GO
ALTER TABLE [dbo].[PlayerQuestionAnswer]  WITH CHECK ADD  CONSTRAINT [PlayerQuestionAnswer_Player_ID_fk] FOREIGN KEY([PlayerID])
REFERENCES [dbo].[Player] ([ID])
GO
ALTER TABLE [dbo].[PlayerQuestionAnswer] CHECK CONSTRAINT [PlayerQuestionAnswer_Player_ID_fk]
GO
ALTER TABLE [dbo].[PlayerQuestionAnswer]  WITH CHECK ADD  CONSTRAINT [PlayerQuestionAnswer_Question_ID_fk] FOREIGN KEY([QuestionID])
REFERENCES [dbo].[Question] ([ID])
GO
ALTER TABLE [dbo].[PlayerQuestionAnswer] CHECK CONSTRAINT [PlayerQuestionAnswer_Question_ID_fk]
GO
ALTER TABLE [dbo].[PlayerRanking]  WITH CHECK ADD  CONSTRAINT [PlayerRanking_Player_ID_fk] FOREIGN KEY([PlayerID])
REFERENCES [dbo].[Player] ([ID])
GO
ALTER TABLE [dbo].[PlayerRanking] CHECK CONSTRAINT [PlayerRanking_Player_ID_fk]
GO
ALTER TABLE [dbo].[Question]  WITH CHECK ADD  CONSTRAINT [Question_Quiz_ID_fk] FOREIGN KEY([QuizID])
REFERENCES [dbo].[Quiz] ([ID])
GO
ALTER TABLE [dbo].[Question] CHECK CONSTRAINT [Question_Quiz_ID_fk]
GO
ALTER TABLE [dbo].[Quiz]  WITH CHECK ADD  CONSTRAINT [Quiz_Author_ID_fk] FOREIGN KEY([AuthorID])
REFERENCES [dbo].[Author] ([ID])
GO
ALTER TABLE [dbo].[Quiz] CHECK CONSTRAINT [Quiz_Author_ID_fk]
GO
USE [master]
GO
ALTER DATABASE [PRAQuiz] SET  READ_WRITE 
GO
