ALTER TABLE [Tag] DROP CONSTRAINT [FK_Tag_Posts_PostId];

GO

DROP TABLE [Categories];

GO

ALTER TABLE [Tag] DROP CONSTRAINT [PK_Tag];

GO

DROP INDEX [IX_Tag_PostId] ON [Tag];

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Tag]') AND [c].[name] = N'Description');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Tag] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Tag] DROP COLUMN [Description];

GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Tag]') AND [c].[name] = N'PostId');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Tag] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Tag] DROP COLUMN [PostId];

GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Tag]') AND [c].[name] = N'Title');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Tag] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Tag] DROP COLUMN [Title];

GO

EXEC sp_rename N'[Tag]', N'Tags';

GO

ALTER TABLE [Tags] ADD [Name] nvarchar(max) NULL;

GO

ALTER TABLE [Tags] ADD CONSTRAINT [PK_Tags] PRIMARY KEY ([Id]);

GO

CREATE TABLE [PostTag] (
    [PostId] int NOT NULL,
    [TagId] int NOT NULL,
    CONSTRAINT [PK_PostTag] PRIMARY KEY ([PostId], [TagId]),
    CONSTRAINT [FK_PostTag_Posts_PostId] FOREIGN KEY ([PostId]) REFERENCES [Posts] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_PostTag_Tags_TagId] FOREIGN KEY ([TagId]) REFERENCES [Tags] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_PostTag_TagId] ON [PostTag] ([TagId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201027185440_PostTagRelationship', N'3.1.9');

GO

