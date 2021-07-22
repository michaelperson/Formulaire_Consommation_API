CREATE TABLE [dbo].[Contact]
(
	[Id] INT NOT NULL IDENTITY, 
    [LastName] NVARCHAR(75) NOT NULL, 
    [FirstName] NVARCHAR(75) NOT NULL, 
    [Email] NVARCHAR(384) NOT NULL, 
    [CategoryId] INT NOT NULL, 
    CONSTRAINT [FK_Contact_Category] FOREIGN KEY ([CategoryId]) REFERENCES [Category]([Id]), 
    CONSTRAINT [PK_Contact] PRIMARY KEY ([Id])
)
