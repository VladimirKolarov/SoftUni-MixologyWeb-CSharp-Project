BEGIN TRANSACTION;
GO

CREATE TABLE [Cocktails] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(100) NOT NULL,
    [ImageUrl] nvarchar(2048) NULL,
    [PreparationInfo] nvarchar(1000) NOT NULL,
    [Description] nvarchar(1000) NULL,
    [Rating] float NULL,
    CONSTRAINT [PK_Cocktails] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Measurements] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(20) NOT NULL,
    CONSTRAINT [PK_Measurements] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Performers] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_Performers] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Songs] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(100) NOT NULL,
    [ExternalLink] nvarchar(2048) NULL,
    CONSTRAINT [PK_Songs] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Comments] (
    [Id] uniqueidentifier NOT NULL,
    [Text] nvarchar(1000) NOT NULL,
    [CreatedOn] datetime2 NOT NULL,
    [CocktailId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Comments] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Comments_Cocktails_CocktailId] FOREIGN KEY ([CocktailId]) REFERENCES [Cocktails] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Ingredients] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(50) NOT NULL,
    [Description] nvarchar(500) NULL,
    [MeasurementId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Ingredients] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Ingredients_Measurements_MeasurementId] FOREIGN KEY ([MeasurementId]) REFERENCES [Measurements] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [CocktailSong] (
    [CocktailsId] uniqueidentifier NOT NULL,
    [SongsId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_CocktailSong] PRIMARY KEY ([CocktailsId], [SongsId]),
    CONSTRAINT [FK_CocktailSong_Cocktails_CocktailsId] FOREIGN KEY ([CocktailsId]) REFERENCES [Cocktails] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_CocktailSong_Songs_SongsId] FOREIGN KEY ([SongsId]) REFERENCES [Songs] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [PerformerSong] (
    [PerformersId] uniqueidentifier NOT NULL,
    [SongsId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_PerformerSong] PRIMARY KEY ([PerformersId], [SongsId]),
    CONSTRAINT [FK_PerformerSong_Performers_PerformersId] FOREIGN KEY ([PerformersId]) REFERENCES [Performers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_PerformerSong_Songs_SongsId] FOREIGN KEY ([SongsId]) REFERENCES [Songs] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [IngredientQuantities] (
    [Id] uniqueidentifier NOT NULL,
    [IngredientId] uniqueidentifier NOT NULL,
    [CocktailId] uniqueidentifier NOT NULL,
    [Quantity] float NOT NULL,
    CONSTRAINT [PK_IngredientQuantities] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_IngredientQuantities_Cocktails_CocktailId] FOREIGN KEY ([CocktailId]) REFERENCES [Cocktails] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_IngredientQuantities_Ingredients_IngredientId] FOREIGN KEY ([IngredientId]) REFERENCES [Ingredients] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_CocktailSong_SongsId] ON [CocktailSong] ([SongsId]);
GO

CREATE INDEX [IX_Comments_CocktailId] ON [Comments] ([CocktailId]);
GO

CREATE INDEX [IX_IngredientQuantities_CocktailId] ON [IngredientQuantities] ([CocktailId]);
GO

CREATE INDEX [IX_IngredientQuantities_IngredientId] ON [IngredientQuantities] ([IngredientId]);
GO

CREATE INDEX [IX_Ingredients_MeasurementId] ON [Ingredients] ([MeasurementId]);
GO

CREATE INDEX [IX_PerformerSong_SongsId] ON [PerformerSong] ([SongsId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221219212530_BasicDatabaseCocktailsAndSongs', N'6.0.12');
GO

COMMIT;
GO

