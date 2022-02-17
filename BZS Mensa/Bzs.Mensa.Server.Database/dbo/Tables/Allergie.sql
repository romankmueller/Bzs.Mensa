CREATE TABLE [dbo].[Allergie]
(
	[Id] UNIQUEIDENTIFIER NOT NULL,
	[Bezeichnung] NVARCHAR(50) NOT NULL,
	[Geloescht] bit NOT NULL,
	CONSTRAINT [PK_Allergie] PRIMARY KEY ([Id]),
)
