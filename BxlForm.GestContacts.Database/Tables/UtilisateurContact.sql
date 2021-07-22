CREATE TABLE [dbo].[UtilisateurContact]
(
	[IdUtilisateur] INT NOT NULL , 
    [IdContact] INT NOT NULL, 
    CONSTRAINT [PK_UtilisateurContact] PRIMARY KEY ([IdContact], [IdUtilisateur]), 
    CONSTRAINT [FK_UtilisateurContact_ToUtilisateur] FOREIGN KEY ([IdUtilisateur]) REFERENCES [Utilisateur]([Id]),
    CONSTRAINT [FK_UtilisateurContact_ToContact] FOREIGN KEY ([IdContact]) REFERENCES [Contact]([Id])
)
