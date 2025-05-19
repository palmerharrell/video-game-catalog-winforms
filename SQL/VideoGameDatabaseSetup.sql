-- Create VideoGamesDB Database 
USE master
IF NOT EXISTS (
   SELECT name
   FROM sys.databases
   WHERE name = N'VideoGamesDB'
)
CREATE DATABASE [VideoGamesDB]
GO

-- Create Tables
USE VideoGamesDB

CREATE TABLE dbo.Games
(
	VGID INT PRIMARY KEY IDENTITY(1, 1),
	Title VARCHAR(100) NOT NULL,
	[Description] VARCHAR(255),
	Genre VARCHAR(50),
	[Platform] VARCHAR(50) NOT NULL,
	Physical BIT,
	ReleaseYear SMALLINT,
	Developer VARCHAR(50),
	Publisher VARCHAR(50),
	ScannedUPC NVARCHAR(50) NOT NULL
)
GO

CREATE TABLE dbo.Images
(
	ImageID INT PRIMARY KEY IDENTITY(1, 1),
	VGID INT NOT NULL,
	[Image] VARBINARY(MAX),
	ImageType VARCHAR(25)
)
GO
