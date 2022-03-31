﻿CREATE TABLE [dbo].[Feiertag]
(
	[Id] UNIQUEIDENTIFIER NOT NULL,
	[Bezeichnung] NVARCHAR(50) NOT NULL,
	[Datum] DATE NOT NULL,
	[Geloescht] BIT NOT NULL,
	CONSTRAINT [PK_Feiertag] PRIMARY KEY ([Id])
)
