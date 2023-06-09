USE [personsdb]
GO
ALTER TABLE [dbo].[PersonGenres] DROP CONSTRAINT [FK_PersonGenres_Persons_PersonId]
GO
ALTER TABLE [dbo].[PersonGenres] DROP CONSTRAINT [FK_PersonGenres_Genres_GenreId]
GO
ALTER TABLE [dbo].[LinkPersonGenreMovies] DROP CONSTRAINT [FK_LinkPersonGenreMovies_Persons_PersonId]
GO
ALTER TABLE [dbo].[LinkPersonGenreMovies] DROP CONSTRAINT [FK_LinkPersonGenreMovies_Movies_MovieId]
GO
ALTER TABLE [dbo].[LinkPersonGenreMovies] DROP CONSTRAINT [FK_LinkPersonGenreMovies_Genres_GenreId]
GO
ALTER TABLE [dbo].[GenreMovies] DROP CONSTRAINT [FK_GenreMovies_Movies_MovieId]
GO
ALTER TABLE [dbo].[GenreMovies] DROP CONSTRAINT [FK_GenreMovies_Genres_GenreId]
GO
ALTER TABLE [dbo].[LinkPersonGenreMovies] DROP CONSTRAINT [DF__LinkPerso__Ratin__5BE2A6F2]
GO
/****** Object:  Index [IX_PersonGenres_GenreId]    Script Date: 2023-06-06 11:01:45 ******/
DROP INDEX [IX_PersonGenres_GenreId] ON [dbo].[PersonGenres]
GO
/****** Object:  Index [IX_LinkPersonGenreMovies_MovieId]    Script Date: 2023-06-06 11:01:45 ******/
DROP INDEX [IX_LinkPersonGenreMovies_MovieId] ON [dbo].[LinkPersonGenreMovies]
GO
/****** Object:  Index [IX_LinkPersonGenreMovies_GenreId]    Script Date: 2023-06-06 11:01:45 ******/
DROP INDEX [IX_LinkPersonGenreMovies_GenreId] ON [dbo].[LinkPersonGenreMovies]
GO
/****** Object:  Index [IX_GenreMovies_MovieId]    Script Date: 2023-06-06 11:01:45 ******/
DROP INDEX [IX_GenreMovies_MovieId] ON [dbo].[GenreMovies]
GO
/****** Object:  Table [dbo].[Persons]    Script Date: 2023-06-06 11:01:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Persons]') AND type in (N'U'))
DROP TABLE [dbo].[Persons]
GO
/****** Object:  Table [dbo].[PersonGenres]    Script Date: 2023-06-06 11:01:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PersonGenres]') AND type in (N'U'))
DROP TABLE [dbo].[PersonGenres]
GO
/****** Object:  Table [dbo].[Movies]    Script Date: 2023-06-06 11:01:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Movies]') AND type in (N'U'))
DROP TABLE [dbo].[Movies]
GO
/****** Object:  Table [dbo].[LinkPersonGenreMovies]    Script Date: 2023-06-06 11:01:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LinkPersonGenreMovies]') AND type in (N'U'))
DROP TABLE [dbo].[LinkPersonGenreMovies]
GO
/****** Object:  Table [dbo].[Genres]    Script Date: 2023-06-06 11:01:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Genres]') AND type in (N'U'))
DROP TABLE [dbo].[Genres]
GO
/****** Object:  Table [dbo].[GenreMovies]    Script Date: 2023-06-06 11:01:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GenreMovies]') AND type in (N'U'))
DROP TABLE [dbo].[GenreMovies]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2023-06-06 11:01:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[__EFMigrationsHistory]') AND type in (N'U'))
DROP TABLE [dbo].[__EFMigrationsHistory]
GO
USE [master]
GO
/****** Object:  Database [personsdb]    Script Date: 2023-06-06 11:01:45 ******/
DROP DATABASE [personsdb]
GO
/****** Object:  Database [personsdb]    Script Date: 2023-06-06 11:01:45 ******/
CREATE DATABASE [personsdb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'personsdb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\personsdb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'personsdb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\personsdb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [personsdb] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [personsdb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [personsdb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [personsdb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [personsdb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [personsdb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [personsdb] SET ARITHABORT OFF 
GO
ALTER DATABASE [personsdb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [personsdb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [personsdb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [personsdb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [personsdb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [personsdb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [personsdb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [personsdb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [personsdb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [personsdb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [personsdb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [personsdb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [personsdb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [personsdb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [personsdb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [personsdb] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [personsdb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [personsdb] SET RECOVERY FULL 
GO
ALTER DATABASE [personsdb] SET  MULTI_USER 
GO
ALTER DATABASE [personsdb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [personsdb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [personsdb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [personsdb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [personsdb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [personsdb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'personsdb', N'ON'
GO
ALTER DATABASE [personsdb] SET QUERY_STORE = ON
GO
ALTER DATABASE [personsdb] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [personsdb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2023-06-06 11:01:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GenreMovies]    Script Date: 2023-06-06 11:01:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GenreMovies](
	[GenreId] [int] NOT NULL,
	[MovieId] [int] NOT NULL,
 CONSTRAINT [PK_GenreMovies] PRIMARY KEY CLUSTERED 
(
	[GenreId] ASC,
	[MovieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genres]    Script Date: 2023-06-06 11:01:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genres](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TMDBId] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Genres] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LinkPersonGenreMovies]    Script Date: 2023-06-06 11:01:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LinkPersonGenreMovies](
	[MovieId] [int] NOT NULL,
	[PersonId] [int] NOT NULL,
	[GenreId] [int] NOT NULL,
	[MovieLink] [nvarchar](max) NULL,
	[Rating] [int] NOT NULL,
 CONSTRAINT [PK_LinkPersonGenreMovies] PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC,
	[GenreId] ASC,
	[MovieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movies]    Script Date: 2023-06-06 11:01:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[ReleaseYear] [int] NOT NULL,
 CONSTRAINT [PK_Movies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonGenres]    Script Date: 2023-06-06 11:01:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonGenres](
	[PersonId] [int] NOT NULL,
	[GenreId] [int] NOT NULL,
 CONSTRAINT [PK_PersonGenres] PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC,
	[GenreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Persons]    Script Date: 2023-06-06 11:01:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persons](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230605200610_InitialCreate', N'7.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230605204922_AddedRatingsToLink', N'7.0.5')
GO
SET IDENTITY_INSERT [dbo].[Genres] ON 

INSERT [dbo].[Genres] ([Id], [TMDBId], [Name], [Description]) VALUES (2, 28, N'Action', N'Action film is a film genre in which the protagonist is thrust into a series of events that typically involve violence and physical feats.')
INSERT [dbo].[Genres] ([Id], [TMDBId], [Name], [Description]) VALUES (3, 12, N'Adventure', N'A common theme of adventure films is of characters leaving their home or place of comfort and going to fulfill a goal, embarking on travels, quests, treasure hunts, heroic journeys; and explorations or searches for the unknown. Subgenres of adventure films include swashbuckler films, pirate films, and survival films.
')
INSERT [dbo].[Genres] ([Id], [TMDBId], [Name], [Description]) VALUES (6, 16, N'Animation', N'Animated film is a collection of illustrations that are photographed frame-by-frame and then played in a quick succession. Since its inception, animation has had a creative and imaginative tendency. Being able to bring animals and objects to life, this genre has catered towards fairy tales and children''s stories.')
INSERT [dbo].[Genres] ([Id], [TMDBId], [Name], [Description]) VALUES (7, 35, N'Comedy', N'Comedy films are "make ''em laugh" films designed to elicit laughter from the audience. Comedies are light-hearted dramas, crafted to amuse, entertain, and provoke enjoyment. The comedy genre humorously exaggerates the situation, the language, action, and characters.')
INSERT [dbo].[Genres] ([Id], [TMDBId], [Name], [Description]) VALUES (8, 80, N'Crime', N'Crime film is a genre that revolves around the action of a criminal mastermind. A Crime film will often revolve around the criminal himself, chronicling his rise and fall. Some Crime films will have a storyline that follows the criminal''s victim, yet others follow the person in pursuit of the criminal.')
INSERT [dbo].[Genres] ([Id], [TMDBId], [Name], [Description]) VALUES (10, 99, N'Documentary', N'A documentary film or documentary is a non-fictional motion-picture intended to "document reality, primarily for the purposes of instruction, education or maintaining a historical record".')
INSERT [dbo].[Genres] ([Id], [TMDBId], [Name], [Description]) VALUES (11, 18, N'Drama', N'The drama genre features stories with high stakes and many conflicts. They''re plot-driven and demand that every character and scene move the story forward. Dramas follow a clearly defined narrative plot structure, portraying real-life scenarios or extreme situations with emotionally-driven characters.')
INSERT [dbo].[Genres] ([Id], [TMDBId], [Name], [Description]) VALUES (12, 10751, N'Family', N'A children''s film, or family film, is a film genre that contains children or relates to them in the context of home and family. Children''s films are made specifically for children and not necessarily for a general audience, while family films are made for a wider appeal with a general audience in mind.')
INSERT [dbo].[Genres] ([Id], [TMDBId], [Name], [Description]) VALUES (13, 14, N'Fantasy', N'Fantasy films are films that belong to the fantasy genre with fantastic themes, usually magic, supernatural events, mythology, folklore, or exotic fantasy worlds. The genre is considered a form of speculative fiction alongside science fiction films and horror films, although the genres do overlap.')
INSERT [dbo].[Genres] ([Id], [TMDBId], [Name], [Description]) VALUES (14, 36, N'History', N'A historical film is a fiction film showing past events or set within a historical period. This extensive genre shares territory with the biopic, costume drama, heritage film, and epic film.')
INSERT [dbo].[Genres] ([Id], [TMDBId], [Name], [Description]) VALUES (16, 27, N'Horror', N'Horror is a genre of storytelling intended to scare, shock, and thrill its audience. Horror can be interpreted in many different ways, but there is often a central villain, monster, or threat that is often a reflection of the fears being experienced by society at the time.')
INSERT [dbo].[Genres] ([Id], [TMDBId], [Name], [Description]) VALUES (18, 10402, N'Music', N'Musical film is a film genre in which songs by the characters are interwoven into the narrative, sometimes accompanied by dancing. The songs usually advance the plot or develop the film''s characters, but in some cases, they serve merely as breaks in the storyline, often as elaborate "production numbers".')
INSERT [dbo].[Genres] ([Id], [TMDBId], [Name], [Description]) VALUES (19, 9648, N'Mystery', N'A mystery film is a genre of film that revolves around the solution of a problem or a crime. It focuses on the efforts of the detective, private investigator or amateur sleuth to solve the mysterious circumstances of an issue by means of clues, investigation, and clever deduction.')
INSERT [dbo].[Genres] ([Id], [TMDBId], [Name], [Description]) VALUES (20, 10749, N'Romance', N'Romance films involve romantic love stories recorded in visual media for broadcast in theatres or on television that focus on passion, emotion, and the affectionate romantic involvement of the main characters. Typically their journey through dating, courtship or marriage is featured.')
INSERT [dbo].[Genres] ([Id], [TMDBId], [Name], [Description]) VALUES (21, 878, N'Science Fiction', N'A genre characterized by stories involving conflicts between science and technology, human nature, and social organization in futuristic or fantastical settings, created in cinema through distinctive iconographies, images, and sounds often produced by means of special effects technology.')
INSERT [dbo].[Genres] ([Id], [TMDBId], [Name], [Description]) VALUES (22, 10770, N'TV Movie', N'a film made specifically for television, and not intended for release in cinemas.')
INSERT [dbo].[Genres] ([Id], [TMDBId], [Name], [Description]) VALUES (23, 53, N'Thriller', N'Thriller is a genre of fiction with numerous, often overlapping, subgenres, including crime, horror and detective fiction. Thrillers are characterized and defined by the moods they elicit, giving their audiences heightened feelings of suspense, excitement, surprise, anticipation and anxiety.')
INSERT [dbo].[Genres] ([Id], [TMDBId], [Name], [Description]) VALUES (25, 10752, N'War', N'War film is a film genre concerned with warfare, typically about naval, air, or land battles, with combat scenes central to the drama. It has been strongly associated with the 20th century. The fateful nature of battle scenes means that war films often end with them.')
INSERT [dbo].[Genres] ([Id], [TMDBId], [Name], [Description]) VALUES (26, 37, N'Western', N'What Is the Western Genre? Western is a literature, film, and television genre. Westerns are primarily set in the American Old West between the late eighteenth century and late nineteenth century and tell the stories of cowboys, settlers, and outlaws exploring the western frontier and taming the Wild West.')
SET IDENTITY_INSERT [dbo].[Genres] OFF
GO
INSERT [dbo].[LinkPersonGenreMovies] ([MovieId], [PersonId], [GenreId], [MovieLink], [Rating]) VALUES (1, 1, 2, NULL, 9)
INSERT [dbo].[LinkPersonGenreMovies] ([MovieId], [PersonId], [GenreId], [MovieLink], [Rating]) VALUES (2, 1, 12, NULL, 0)
GO
SET IDENTITY_INSERT [dbo].[Movies] ON 

INSERT [dbo].[Movies] ([Id], [Title], [ReleaseYear]) VALUES (1, N'Guardians of the galaxy Vol 3', 2023)
INSERT [dbo].[Movies] ([Id], [Title], [ReleaseYear]) VALUES (2, N'Jaws', 1975)
INSERT [dbo].[Movies] ([Id], [Title], [ReleaseYear]) VALUES (3, N'The little mermaid', 2018)
INSERT [dbo].[Movies] ([Id], [Title], [ReleaseYear]) VALUES (4, N'The little mermaid', 2018)
SET IDENTITY_INSERT [dbo].[Movies] OFF
GO
INSERT [dbo].[PersonGenres] ([PersonId], [GenreId]) VALUES (1, 2)
INSERT [dbo].[PersonGenres] ([PersonId], [GenreId]) VALUES (3, 3)
GO
SET IDENTITY_INSERT [dbo].[Persons] ON 

INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [Email]) VALUES (1, N'Bob', N'Boblin', N'bobby.boblin@gmail.com')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [Email]) VALUES (2, N'Frank', N'Franky', N'Franky.frank@gmail.com')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [Email]) VALUES (3, N'Lucy', N'Lulu', N'Lucy.lulu@gmail.com')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [Email]) VALUES (4, N'Max', N'Guclu', N'max.guclu@chasacademy.se')
SET IDENTITY_INSERT [dbo].[Persons] OFF
GO
/****** Object:  Index [IX_GenreMovies_MovieId]    Script Date: 2023-06-06 11:01:45 ******/
CREATE NONCLUSTERED INDEX [IX_GenreMovies_MovieId] ON [dbo].[GenreMovies]
(
	[MovieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_LinkPersonGenreMovies_GenreId]    Script Date: 2023-06-06 11:01:45 ******/
CREATE NONCLUSTERED INDEX [IX_LinkPersonGenreMovies_GenreId] ON [dbo].[LinkPersonGenreMovies]
(
	[GenreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_LinkPersonGenreMovies_MovieId]    Script Date: 2023-06-06 11:01:45 ******/
CREATE NONCLUSTERED INDEX [IX_LinkPersonGenreMovies_MovieId] ON [dbo].[LinkPersonGenreMovies]
(
	[MovieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PersonGenres_GenreId]    Script Date: 2023-06-06 11:01:45 ******/
CREATE NONCLUSTERED INDEX [IX_PersonGenres_GenreId] ON [dbo].[PersonGenres]
(
	[GenreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[LinkPersonGenreMovies] ADD  DEFAULT ((0)) FOR [Rating]
GO
ALTER TABLE [dbo].[GenreMovies]  WITH CHECK ADD  CONSTRAINT [FK_GenreMovies_Genres_GenreId] FOREIGN KEY([GenreId])
REFERENCES [dbo].[Genres] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GenreMovies] CHECK CONSTRAINT [FK_GenreMovies_Genres_GenreId]
GO
ALTER TABLE [dbo].[GenreMovies]  WITH CHECK ADD  CONSTRAINT [FK_GenreMovies_Movies_MovieId] FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movies] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GenreMovies] CHECK CONSTRAINT [FK_GenreMovies_Movies_MovieId]
GO
ALTER TABLE [dbo].[LinkPersonGenreMovies]  WITH CHECK ADD  CONSTRAINT [FK_LinkPersonGenreMovies_Genres_GenreId] FOREIGN KEY([GenreId])
REFERENCES [dbo].[Genres] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LinkPersonGenreMovies] CHECK CONSTRAINT [FK_LinkPersonGenreMovies_Genres_GenreId]
GO
ALTER TABLE [dbo].[LinkPersonGenreMovies]  WITH CHECK ADD  CONSTRAINT [FK_LinkPersonGenreMovies_Movies_MovieId] FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movies] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LinkPersonGenreMovies] CHECK CONSTRAINT [FK_LinkPersonGenreMovies_Movies_MovieId]
GO
ALTER TABLE [dbo].[LinkPersonGenreMovies]  WITH CHECK ADD  CONSTRAINT [FK_LinkPersonGenreMovies_Persons_PersonId] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Persons] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LinkPersonGenreMovies] CHECK CONSTRAINT [FK_LinkPersonGenreMovies_Persons_PersonId]
GO
ALTER TABLE [dbo].[PersonGenres]  WITH CHECK ADD  CONSTRAINT [FK_PersonGenres_Genres_GenreId] FOREIGN KEY([GenreId])
REFERENCES [dbo].[Genres] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PersonGenres] CHECK CONSTRAINT [FK_PersonGenres_Genres_GenreId]
GO
ALTER TABLE [dbo].[PersonGenres]  WITH CHECK ADD  CONSTRAINT [FK_PersonGenres_Persons_PersonId] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Persons] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PersonGenres] CHECK CONSTRAINT [FK_PersonGenres_Persons_PersonId]
GO
USE [master]
GO
ALTER DATABASE [personsdb] SET  READ_WRITE 
GO
