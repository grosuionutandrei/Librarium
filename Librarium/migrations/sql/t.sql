USE Librarium;
GO

ALTER TABLE [Books] ADD [ISBN_Normalized] nvarchar(20) NOT NULL Default 'pending';
GO

