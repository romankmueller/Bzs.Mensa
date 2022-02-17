CREATE TABLE [dbo].[Essen]
(
	[Id] UNIQUEIDENTIFIER NOT NULL,
	[Datum] DATE NOT NULL,
	[BenutzerId] UNIQUEIDENTIFIER NOT NULL,
	[Geloescht] bit NOT NULL,
	CONSTRAINT [PK_Essen] PRIMARY KEY ([Id]),
	CONSTRAINT [FK_Essen.BenutzerId_Benutzer.Id] Foreign Key ([BenutzerId]) References [Benutzer]([Id])

)
