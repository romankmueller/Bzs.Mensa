CREATE TABLE [dbo].[EssenStandard]
(
	[Id] UNIQUEIDENTIFIER NOT NULL,
	[BenutzerId] UNIQUEIDENTIFIER NOT NULL,
	[Mo] BIT NOT NULL,
	[Di] BIT NOT NULL,
	[Mi] BIT NOT NULL,
	[Do] BIT NOT NULL,
	[Fr] BIT NOT NULL,
	[Sa] BIT NOT NULL,
	[So] BIT NOT NULL,
	[Geloescht] BIT NOT NULL
	CONSTRAINT [PK_EssenStandard] PRIMARY KEY ([Id]),
	CONSTRAINT [FK_EssenStandard.BenutzerId_Benutzer.Id] FOREIGN KEY ([BenutzerId]) REFERENCES [dbo].[Benutzer] ([Id])
)
