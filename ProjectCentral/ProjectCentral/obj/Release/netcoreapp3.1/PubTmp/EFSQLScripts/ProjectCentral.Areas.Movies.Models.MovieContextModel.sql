IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200611035202_s')
BEGIN
    CREATE TABLE [Genres] (
        [GenreID] nvarchar(450) NOT NULL,
        [Name] nvarchar(max) NULL,
        CONSTRAINT [PK_Genres] PRIMARY KEY ([GenreID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200611035202_s')
BEGIN
    CREATE TABLE [Movies] (
        [MovieID] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [Year] int NOT NULL,
        [Rating] int NOT NULL,
        [GenreID] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_Movies] PRIMARY KEY ([MovieID]),
        CONSTRAINT [FK_Movies_Genres_GenreID] FOREIGN KEY ([GenreID]) REFERENCES [Genres] ([GenreID]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200611035202_s')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'GenreID', N'Name') AND [object_id] = OBJECT_ID(N'[Genres]'))
        SET IDENTITY_INSERT [Genres] ON;
    INSERT INTO [Genres] ([GenreID], [Name])
    VALUES (N'A', N'Action'),
    (N'C', N'Comedy'),
    (N'D', N'Drama'),
    (N'H', N'Horror'),
    (N'M', N'Musical'),
    (N'R', N'RomCom'),
    (N'S', N'SciFi');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'GenreID', N'Name') AND [object_id] = OBJECT_ID(N'[Genres]'))
        SET IDENTITY_INSERT [Genres] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200611035202_s')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'MovieID', N'GenreID', N'Name', N'Rating', N'Year') AND [object_id] = OBJECT_ID(N'[Movies]'))
        SET IDENTITY_INSERT [Movies] ON;
    INSERT INTO [Movies] ([MovieID], [GenreID], [Name], [Rating], [Year])
    VALUES (2, N'A', N'Wonder Woman', 3, 2017);
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'MovieID', N'GenreID', N'Name', N'Rating', N'Year') AND [object_id] = OBJECT_ID(N'[Movies]'))
        SET IDENTITY_INSERT [Movies] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200611035202_s')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'MovieID', N'GenreID', N'Name', N'Rating', N'Year') AND [object_id] = OBJECT_ID(N'[Movies]'))
        SET IDENTITY_INSERT [Movies] ON;
    INSERT INTO [Movies] ([MovieID], [GenreID], [Name], [Rating], [Year])
    VALUES (1, N'D', N'Cassablanca', 5, 1942);
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'MovieID', N'GenreID', N'Name', N'Rating', N'Year') AND [object_id] = OBJECT_ID(N'[Movies]'))
        SET IDENTITY_INSERT [Movies] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200611035202_s')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'MovieID', N'GenreID', N'Name', N'Rating', N'Year') AND [object_id] = OBJECT_ID(N'[Movies]'))
        SET IDENTITY_INSERT [Movies] ON;
    INSERT INTO [Movies] ([MovieID], [GenreID], [Name], [Rating], [Year])
    VALUES (3, N'R', N'Moonstruck', 4, 1988);
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'MovieID', N'GenreID', N'Name', N'Rating', N'Year') AND [object_id] = OBJECT_ID(N'[Movies]'))
        SET IDENTITY_INSERT [Movies] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200611035202_s')
BEGIN
    CREATE INDEX [IX_Movies_GenreID] ON [Movies] ([GenreID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200611035202_s')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200611035202_s', N'3.1.4');
END;

GO

