﻿CREATE TABLE [dbo].[EssenMenu]
(
	[Id] UNIQUEIDENTIFIER NOT NULL,
	[Datum] DATE NOT NULL,
	[MenuBeschreibung] NVARCHAR(MAX) NOT NULL,
	[Geloescht] BIT NOT NULL,
	CONSTRAINT [PK_EssenMenu] PRIMARY KEY ([Id])
)
