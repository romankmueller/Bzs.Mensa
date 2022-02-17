CREATE TABLE [dbo].[BenutzerAllergie]
(
	[Id] UNIQUEIDENTIFIER NOT NULL,
	[BenutzerId] UNIQUEIDENTIFIER NOT NULL,
	[AllergieId] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT [PK_BenutzerAllergie] PRIMARY KEY ([Id]),
	CONSTRAINT [FK_BenutzerAllergie.BenutzerId_Benutzer.Id] Foreign Key ([BenutzerId]) References [Benutzer]([Id]),
	CONSTRAINT [FK_BenutzerAllergie.AllergieId_Allergie.Id] Foreign Key ([AllergieId]) References [Allergie]([Id])

)
