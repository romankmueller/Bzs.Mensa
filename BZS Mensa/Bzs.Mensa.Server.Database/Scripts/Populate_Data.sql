INSERT INTO [dbo].[Allergie] ([Id], [Bezeichnung], [Geloescht]) VALUES ('3159822D-7F88-4EC5-9E57-3492D501C60F', 'Gluten', 0)
INSERT INTO [dbo].[Allergie] ([Id], [Bezeichnung], [Geloescht]) VALUES ('327EDA3B-3089-4156-9258-2AFAC0571FA2', 'Laktose', 0)
GO

INSERT INTO [dbo].[Klasse] ([Id], [Bezeichnung], [Schicht_1], [Schicht_2], [Geloescht]) VALUES ('E74EB79C-3684-4D1B-90D9-CEA40EDD14A8', 'H20', 1, 0, 0)
INSERT INTO [dbo].[Klasse] ([Id], [Bezeichnung], [Schicht_1], [Schicht_2], [Geloescht]) VALUES ('8694E6DD-F62E-4394-A93A-C5A5AA368312', 'F20', 0, 1, 0)
GO

INSERT INTO [dbo].[Benutzer] ([Id], [BenutzerName], [Email], [Passwort], [Nachname], [Vorname], [KlasseId], [Vegetarisch], [Geloescht]) VALUES ('AF02063C-EE6A-4C82-A15D-40A121B9315B', 'dev', 'dev@deltaworks.ch', 'dev', 'Software', 'Entwickler', 'E74EB79C-3684-4D1B-90D9-CEA40EDD14A8', 0, 0)
GO

INSERT INTO [dbo].[BenutzerAllergie] ([Id], [BenutzerId], [AllergieId]) VALUES ('43C416BB-BDE2-4647-86FE-C0E860CE3E55', 'AF02063C-EE6A-4C82-A15D-40A121B9315B', '3159822D-7F88-4EC5-9E57-3492D501C60F')
GO

INSERT INTO [dbo].[Feiertag] ([Id], [Bezeichnung], [Datum], [Geloescht]) VALUES ('E7BD010C-59DA-47CA-8634-590CCFCCD422', 'Weihnachten', '2022-12-25', 0)
GO

INSERT INTO [dbo].[Ferien] ([Id], [Bezeichnung], [VonDatum], [BisDatum], [Geloescht]) VALUES ('D066BB37-8323-4F53-BA84-E2BC34A96666', 'Herbstferien', '2022-10-08', '2022-08-23', 0)
GO

INSERT INTO [dbo].[EssenMenu] ([Id], [Datum], [MenuBeschreibung], [Geloescht]) VALUES ('816EE6EB-CDF4-4ADE-8CD5-D82D93ACE2A7', '2022-09-21', 'Schnitzel Pommes', 0)
GO

INSERT INTO [dbo].[EssenStandard] ([Id], [BenutzerId], [Mo], [Di], [Mi], [Do], [Fr], [Sa], [So], [Geloescht]) VALUES ('CFD2BDC1-9CDC-4BE4-9760-795AA6FAFFAD', 'AF02063C-EE6A-4C82-A15D-40A121B9315B', 1, 1, 1, 1, 1, 0, 0, 0)
GO

INSERT INTO [dbo].[Essen] ([Id], [Datum], [BenutzerId], [Geloescht]) VALUES ('76EADD34-4B8B-4EC6-9EC6-F69A1539ED43', '2022-09-21', 'AF02063C-EE6A-4C82-A15D-40A121B9315B', 0)
GO