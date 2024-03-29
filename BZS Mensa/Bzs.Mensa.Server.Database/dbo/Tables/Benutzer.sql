﻿CREATE TABLE [dbo].[Benutzer]
(
	[Id] UNIQUEIDENTIFIER NOT NULL,
	[BenutzerName] NVARCHAR(50) NOT NULL,
	[Email] NVARCHAR(100) NOT NULL,
	[Passwort] NVARCHAR(MAX) NOT NULL,
	[Nachname] NVARCHAR(50) NOT NULL,
	[Vorname] NVARCHAR(50) NOT NULL,
	[KlasseId] UNIQUEIDENTIFIER NOT NULL,
	[Vegetarisch] bit NOT NULL,
	[Geloescht] bit NOT NULL,
	CONSTRAINT [PK_Benutzer] PRIMARY KEY ([Id]),
	CONSTRAINT [FK_Benutzer.KlasseId_Klasse.Id] Foreign Key ([KlasseId]) References [Klasse]([Id])
)
