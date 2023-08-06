IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Vaccines] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [DosesRequired] int NOT NULL,
    [DaysBetweenDoses] int NULL,
    [TotalDosesRecieved] int NOT NULL,
    [TotalDosesLeft] int NOT NULL,
    CONSTRAINT [PK_Vaccines] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230803233644_IntialSchema', N'7.0.9');
GO

COMMIT;
GO

