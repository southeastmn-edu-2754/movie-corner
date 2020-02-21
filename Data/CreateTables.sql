USE [Movies]
GO
/****** Object:  Table [cms].[user]    Script Date: 2/20/2020 09:14:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [cms].[user](
	[userId] [int] IDENTITY(1,1) NOT NULL,
	[userName] [nvarchar](20) NOT NULL,
	[fullName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_cms.user] PRIMARY KEY CLUSTERED 
(
	[userId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [cms].[watchlist]    Script Date: 2/20/2020 09:14:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [cms].[watchlist](
	[watchlistId] [int] NOT NULL,
	[title] [nvarchar](50) NOT NULL,
	[created] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_watchlist] PRIMARY KEY CLUSTERED 
(
	[watchlistId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [cms].[watchlist_titles]    Script Date: 2/20/2020 09:14:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [cms].[watchlist_titles](
	[watchlistId] [int] NOT NULL,
	[tconst] [char](10) NOT NULL,
	[sequenceNum] [smallint] NOT NULL,
	[created] [smalldatetime] NOT NULL,
	[ownerId] [int] NOT NULL,
 CONSTRAINT [PK_watchlist_titles] PRIMARY KEY CLUSTERED 
(
	[watchlistId] ASC,
	[tconst] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [imdb].[artist_category]    Script Date: 2/20/2020 09:14:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [imdb].[artist_category](
	[category] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[category] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [imdb].[name_basics]    Script Date: 2/20/2020 09:14:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [imdb].[name_basics](
	[nconst] [char](10) NOT NULL,
	[primaryName] [nvarchar](100) NOT NULL,
	[birthYear] [char](4) NOT NULL,
	[deathYear] [char](4) NOT NULL,
	[primaryProfession] [varchar](100) NULL,
	[knownForTitles] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[nconst] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [imdb].[title_akas]    Script Date: 2/20/2020 09:14:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [imdb].[title_akas](
	[titleId] [char](10) NOT NULL,
	[ordering] [char](2) NOT NULL,
	[title] [nvarchar](255) NOT NULL,
	[region] [char](4) NOT NULL,
	[language] [char](3) NOT NULL,
	[types] [varchar](20) NOT NULL,
	[attributes] [varchar](100) NOT NULL,
	[isOriginalTitle] [char](2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[titleId] ASC,
	[ordering] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [imdb].[title_basics]    Script Date: 2/20/2020 09:14:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [imdb].[title_basics](
	[tconst] [char](10) NOT NULL,
	[titleType] [varchar](20) NOT NULL,
	[primaryTitle] [nvarchar](255) NOT NULL,
	[originalTitle] [nvarchar](255) NULL,
	[isAdult] [char](1) NOT NULL,
	[startYear] [char](4) NOT NULL,
	[endYear] [char](4) NOT NULL,
	[runtimeMinutes] [char](4) NOT NULL,
	[genres] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[tconst] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [imdb].[title_episode]    Script Date: 2/20/2020 09:14:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [imdb].[title_episode](
	[tconst] [char](10) NOT NULL,
	[parentTconst] [char](10) NOT NULL,
	[seasonNumber] [char](4) NOT NULL,
	[episodeNumber] [char](5) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[tconst] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [imdb].[title_genre]    Script Date: 2/20/2020 09:14:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [imdb].[title_genre](
	[genre] [varchar](20) NOT NULL,
	[tconst] [char](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[genre] ASC,
	[tconst] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [imdb].[title_principals]    Script Date: 2/20/2020 09:14:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [imdb].[title_principals](
	[tconst] [char](10) NOT NULL,
	[ordering] [char](2) NOT NULL,
	[nconst] [char](10) NOT NULL,
	[category] [varchar](30) NOT NULL,
	[job] [varchar](255) NOT NULL,
	[characters] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[tconst] ASC,
	[ordering] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [imdb].[title_ratings]    Script Date: 2/20/2020 09:14:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [imdb].[title_ratings](
	[tconst] [char](10) NOT NULL,
	[averageRating] [char](4) NOT NULL,
	[numVotes] [char](8) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[tconst] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [cms].[watchlist_titles]  WITH CHECK ADD  CONSTRAINT [FK_watchlist_titles_title_basics] FOREIGN KEY([tconst])
REFERENCES [imdb].[title_basics] ([tconst])
GO
ALTER TABLE [cms].[watchlist_titles] CHECK CONSTRAINT [FK_watchlist_titles_title_basics]
GO
ALTER TABLE [cms].[watchlist_titles]  WITH CHECK ADD  CONSTRAINT [FK_watchlist_titles_user] FOREIGN KEY([ownerId])
REFERENCES [cms].[user] ([userId])
GO
ALTER TABLE [cms].[watchlist_titles] CHECK CONSTRAINT [FK_watchlist_titles_user]
GO
ALTER TABLE [cms].[watchlist_titles]  WITH CHECK ADD  CONSTRAINT [FK_watchlist_titles_watchlist] FOREIGN KEY([watchlistId])
REFERENCES [cms].[watchlist] ([watchlistId])
GO
ALTER TABLE [cms].[watchlist_titles] CHECK CONSTRAINT [FK_watchlist_titles_watchlist]
GO
ALTER TABLE [imdb].[title_akas]  WITH CHECK ADD  CONSTRAINT [FK_title_akas_title_basics] FOREIGN KEY([titleId])
REFERENCES [imdb].[title_basics] ([tconst])
GO
ALTER TABLE [imdb].[title_akas] CHECK CONSTRAINT [FK_title_akas_title_basics]
GO
ALTER TABLE [imdb].[title_genre]  WITH CHECK ADD  CONSTRAINT [FK_title_genre_title_basics] FOREIGN KEY([tconst])
REFERENCES [imdb].[title_basics] ([tconst])
GO
ALTER TABLE [imdb].[title_genre] CHECK CONSTRAINT [FK_title_genre_title_basics]
GO
ALTER TABLE [imdb].[title_principals]  WITH CHECK ADD  CONSTRAINT [FK_title_principals_artist_category] FOREIGN KEY([category])
REFERENCES [imdb].[artist_category] ([category])
GO
ALTER TABLE [imdb].[title_principals] CHECK CONSTRAINT [FK_title_principals_artist_category]
GO
ALTER TABLE [imdb].[title_principals]  WITH CHECK ADD  CONSTRAINT [FK_title_principals_name_basics] FOREIGN KEY([nconst])
REFERENCES [imdb].[name_basics] ([nconst])
GO
ALTER TABLE [imdb].[title_principals] CHECK CONSTRAINT [FK_title_principals_name_basics]
GO
ALTER TABLE [imdb].[title_principals]  WITH CHECK ADD  CONSTRAINT [FK_title_principals_title_basics] FOREIGN KEY([tconst])
REFERENCES [imdb].[title_basics] ([tconst])
GO
ALTER TABLE [imdb].[title_principals] CHECK CONSTRAINT [FK_title_principals_title_basics]
GO
ALTER TABLE [imdb].[title_genre]  WITH CHECK ADD  CONSTRAINT [CHK_Valid_Genres] CHECK  (([genre]='Western' OR [genre]='War' OR [genre]='Thriller' OR [genre]='Sport' OR [genre]='Short' OR [genre]='Sci-Fi' OR [genre]='Romance' OR [genre]='News' OR [genre]='Mystery' OR [genre]='Musical' OR [genre]='Music' OR [genre]='Horror' OR [genre]='History' OR [genre]='Film-Noir' OR [genre]='Fantasy' OR [genre]='Family' OR [genre]='Drama' OR [genre]='Documentary' OR [genre]='Crime' OR [genre]='Comedy' OR [genre]='Biography' OR [genre]='Animation' OR [genre]='Adventure' OR [genre]='Action' OR [genre]='\N'))
GO
ALTER TABLE [imdb].[title_genre] CHECK CONSTRAINT [CHK_Valid_Genres]
GO
