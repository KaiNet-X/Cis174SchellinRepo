IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200621183833_om')
BEGIN
    CREATE TABLE [Categories] (
        [CategoryID] int NOT NULL IDENTITY,
        [CategoryName] nvarchar(max) NULL,
        CONSTRAINT [PK_Categories] PRIMARY KEY ([CategoryID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200621183833_om')
BEGIN
    CREATE TABLE [Games] (
        [GameID] int NOT NULL IDENTITY,
        [GameName] nvarchar(max) NULL,
        CONSTRAINT [PK_Games] PRIMARY KEY ([GameID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200621183833_om')
BEGIN
    CREATE TABLE [Sports] (
        [SportID] int NOT NULL IDENTITY,
        [SportName] nvarchar(max) NULL,
        [CategoryID] int NOT NULL,
        CONSTRAINT [PK_Sports] PRIMARY KEY ([SportID]),
        CONSTRAINT [FK_Sports_Categories_CategoryID] FOREIGN KEY ([CategoryID]) REFERENCES [Categories] ([CategoryID]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200621183833_om')
BEGIN
    CREATE TABLE [Countries] (
        [CountryID] int NOT NULL IDENTITY,
        [CountryName] nvarchar(max) NULL,
        [GameID] int NOT NULL,
        [SportID] int NOT NULL,
        CONSTRAINT [PK_Countries] PRIMARY KEY ([CountryID]),
        CONSTRAINT [FK_Countries_Games_GameID] FOREIGN KEY ([GameID]) REFERENCES [Games] ([GameID]) ON DELETE CASCADE,
        CONSTRAINT [FK_Countries_Sports_SportID] FOREIGN KEY ([SportID]) REFERENCES [Sports] ([SportID]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200621183833_om')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CategoryID', N'CategoryName') AND [object_id] = OBJECT_ID(N'[Categories]'))
        SET IDENTITY_INSERT [Categories] ON;
    INSERT INTO [Categories] ([CategoryID], [CategoryName])
    VALUES (1, N'indoor'),
    (2, N'outdoor');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CategoryID', N'CategoryName') AND [object_id] = OBJECT_ID(N'[Categories]'))
        SET IDENTITY_INSERT [Categories] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200621183833_om')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'GameID', N'GameName') AND [object_id] = OBJECT_ID(N'[Games]'))
        SET IDENTITY_INSERT [Games] ON;
    INSERT INTO [Games] ([GameID], [GameName])
    VALUES (1, N'Winter Olympics'),
    (2, N'Summer Olympics'),
    (3, N'Paralympics'),
    (4, N'Youth Olympic Games');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'GameID', N'GameName') AND [object_id] = OBJECT_ID(N'[Games]'))
        SET IDENTITY_INSERT [Games] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200621183833_om')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'SportID', N'CategoryID', N'SportName') AND [object_id] = OBJECT_ID(N'[Sports]'))
        SET IDENTITY_INSERT [Sports] ON;
    INSERT INTO [Sports] ([SportID], [CategoryID], [SportName])
    VALUES (1, 1, N'Curling'),
    (3, 1, N'Diving'),
    (5, 1, N'Archery'),
    (7, 1, N'Breakdancing'),
    (2, 2, N'Bobsleigh'),
    (4, 2, N'Road Cycling'),
    (6, 2, N'Canoe Sprint'),
    (8, 2, N'Skateboarding');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'SportID', N'CategoryID', N'SportName') AND [object_id] = OBJECT_ID(N'[Sports]'))
        SET IDENTITY_INSERT [Sports] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200621183833_om')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CountryID', N'CountryName', N'GameID', N'SportID') AND [object_id] = OBJECT_ID(N'[Countries]'))
        SET IDENTITY_INSERT [Countries] ON;
    INSERT INTO [Countries] ([CountryID], [CountryName], [GameID], [SportID])
    VALUES (1, N'Canada', 1, 1),
    (22, N'Finland', 4, 8),
    (18, N'Zimbabwe', 3, 6),
    (17, N'Pakistan', 3, 6),
    (16, N'Austria', 3, 6),
    (12, N'USA', 2, 4),
    (11, N'Netherlands', 2, 4),
    (10, N'Brazil', 2, 4),
    (6, N'Japan', 1, 2),
    (5, N'Italy', 1, 2),
    (4, N'Jamaica', 1, 2),
    (21, N'Russia', 4, 7),
    (20, N'Cyprus', 4, 7),
    (19, N'France', 4, 7),
    (15, N'Ukraine', 3, 5),
    (14, N'Uruguay', 3, 5),
    (13, N'Thailand', 3, 5),
    (9, N'Mexico', 2, 3),
    (8, N'China', 2, 3),
    (7, N'Germany', 2, 3),
    (3, N'Great Britain', 1, 1),
    (2, N'Sweden', 1, 1),
    (23, N'Slovakia', 4, 8),
    (24, N'Portugal', 4, 8);
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CountryID', N'CountryName', N'GameID', N'SportID') AND [object_id] = OBJECT_ID(N'[Countries]'))
        SET IDENTITY_INSERT [Countries] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200621183833_om')
BEGIN
    CREATE INDEX [IX_Countries_GameID] ON [Countries] ([GameID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200621183833_om')
BEGIN
    CREATE INDEX [IX_Countries_SportID] ON [Countries] ([SportID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200621183833_om')
BEGIN
    CREATE INDEX [IX_Sports_CategoryID] ON [Sports] ([CategoryID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200621183833_om')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200621183833_om', N'3.1.4');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200622022307_oc1')
BEGIN
    UPDATE [Categories] SET [CategoryName] = N'Indoor'
    WHERE [CategoryID] = 1;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200622022307_oc1')
BEGIN
    UPDATE [Categories] SET [CategoryName] = N'Outdoor'
    WHERE [CategoryID] = 2;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200622022307_oc1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200622022307_oc1', N'3.1.4');
END;

GO

