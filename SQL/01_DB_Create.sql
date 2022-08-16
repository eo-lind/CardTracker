USE [master]

IF db_id('CardTracker') IS NULL
  CREATE DATABASE [CardTracker]
GO

USE [CardTracker]
GO


DROP TABLE IF EXISTS [User];
DROP TABLE IF EXISTS [Player];
DROP TABLE IF EXISTS [Team];
DROP TABLE IF EXISTS [Manufacturer];
DROP TABLE IF EXISTS [Status];
DROP TABLE IF EXISTS [Attribute];
DROP TABLE IF EXISTS [Series];
DROP TABLE IF EXISTS [Card];
--DROP TABLE IF EXISTS [PlayerTeam];
GO

CREATE TABLE [User] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [UserName] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [Player] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [NameFirst] nvarchar(255) NOT NULL,
  [NameLast] nvarchar(255) NOT NULL,
  [ImageUrlHeadshot] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [Team] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [TeamName] nvarchar(255) NOT NULL,
  [Website] nvarchar(255) NOT NULL,
  [ImageUrlLogo] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [Manufacturer] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [MfrName] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [Status] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [StatusName] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [Attribute] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [AttributeName] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [Series] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [SeriesName] nvarchar(255) NOT NULL,
  [ManufacturerId] int NOT NULL
)
GO

CREATE TABLE [Card] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [ImageUrlFront] nvarchar(255),
  [ImageUrlBack] nvarchar(255),
  [NumInSeries] int,
  [ManufactureYear] int NOT NULL,
  [ManufacturerId] int NOT NULL,
  [StatusId] int NOT NULL,
  [PlayerId] int NOT NULL,
  [TeamId] int NOT NULL,
  [UserId] int NOT NULL,
  [AttributeId] int,
  [SeriesId] int
)
GO

--CREATE TABLE [PlayerTeam] (
--  [Id] int PRIMARY KEY IDENTITY(1, 1),
--  [PlayerId] int NOT NULL,
--  [TeamId] int NOT NULL
--)
--GO

ALTER TABLE [Series] ADD FOREIGN KEY ([ManufacturerId]) REFERENCES [Manufacturer] ([Id])
GO

ALTER TABLE [Card] ADD FOREIGN KEY ([ManufacturerId]) REFERENCES [Manufacturer] ([Id])
GO

ALTER TABLE [Card] ADD FOREIGN KEY ([StatusId]) REFERENCES [Status] ([Id])
GO

ALTER TABLE [Card] ADD FOREIGN KEY ([PlayerId]) REFERENCES [Player] ([Id])
GO

ALTER TABLE [Card] ADD FOREIGN KEY ([TeamId]) REFERENCES [Team] ([Id])
GO

ALTER TABLE [Card] ADD FOREIGN KEY ([UserId]) REFERENCES [User] ([Id])
GO

ALTER TABLE [Card] ADD FOREIGN KEY ([AttributeId]) REFERENCES [Attribute] ([Id])
GO

ALTER TABLE [Card] ADD FOREIGN KEY ([SeriesId]) REFERENCES [Series] ([Id])
GO

--ALTER TABLE [PlayerTeam] ADD FOREIGN KEY ([PlayerId]) REFERENCES [Player] ([Id])
--GO

--ALTER TABLE [PlayerTeam] ADD FOREIGN KEY ([TeamId]) REFERENCES [Team] ([Id])
--GO

