CREATE TABLE [dbo].[Klasse]
(
	[Id] UNIQUEIDENTIFIER NOT NULL,
	[Bezeichnung] NVarchar(10) NOT NULL,
	[Schicht_1] bit NOT NULL,
	[Schicht_2] bit NOT NULL,
	[Geloescht] bit NOT NULL,
	CONSTRAINT [PK_Klasse] PRIMARY KEY ([Id])

)
