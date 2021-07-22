CREATE TABLE [dbo].[Utilisateur]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Email] NVARCHAR(350) NOT NULL, 
    [Password] NVARCHAR(MAX) NOT NULL
)
