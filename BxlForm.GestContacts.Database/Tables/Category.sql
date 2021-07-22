CREATE TABLE [dbo].[Category]
(
	[Id] INT NOT NULL IDENTITY, 
    [Name] NVARCHAR(75) NOT NULL, 
    CONSTRAINT [PK_Category] PRIMARY KEY ([Id])
)
