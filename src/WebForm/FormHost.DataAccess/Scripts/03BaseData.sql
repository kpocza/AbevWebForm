SET IDENTITY_INSERT [dbo].[Organization] ON
GO
INSERT INTO [dbo].[Organization] ([Id], [Name], [Description], [Active]) 
VALUES (1, 'APEH', 'APEH (NAV)', 1)
INSERT INTO [dbo].[Organization] ([Id], [Name], [Description], [Active]) 
VALUES (2, 'NAV', 'Nemzeti Adó és Vámhivatal', 1)
INSERT INTO [dbo].[Organization] ([Id], [Name], [Description], [Active]) 
VALUES (3, 'CEGINFO', 'CEGINFO - Közigazgatási és Igazságügyi Minisztérium - Céginformációs osztály', 1)
INSERT INTO [dbo].[Organization] ([Id], [Name], [Description], [Active]) 
VALUES (4, 'BP22PHIV', 'Budapest XXII. kerület', 1)
INSERT INTO [dbo].[Organization] ([Id], [Name], [Description], [Active]) 
VALUES (5, 'VPOP', 'VPOP (NAV)', 1)


GO
SET IDENTITY_INSERT [dbo].[Organization] OFF
GO

SET IDENTITY_INSERT [dbo].[DocumentType] ON
GO
INSERT INTO [dbo].[DocumentType] ([Id], [Name], [Description] ,[ValidFrom] ,[ValidTo],[Active],[Organization_Id])
VALUES (1, '0953', 'Szja bevallás a 2009-es évre', '2010.01.01', '2012.01.01', 1, 1)
INSERT INTO [dbo].[DocumentType] ([Id], [Name], [Description] ,[ValidFrom] ,[ValidTo],[Active],[Organization_Id])
VALUES (2, 'CEGINFO_11EB_01', 'Éves beszámoló a 2011-es évre', '2011.01.01', '2012.01.01', 1, 3)
INSERT INTO [dbo].[DocumentType] ([Id], [Name], [Description] ,[ValidFrom] ,[ValidTo],[Active],[Organization_Id])
VALUES (3, '1053', 'Szja bevallás a 2010-es évre', '2011.01.01', '2012.01.01', 1, 1)
INSERT INTO [dbo].[DocumentType] ([Id], [Name], [Description] ,[ValidFrom] ,[ValidTo],[Active],[Organization_Id])
VALUES (4, 'BP22PHIV_B_1102', 'Egyéni vállalkozás indítása XXII.', '2011.01.01', '2099.01.01', 1, 4)
INSERT INTO [dbo].[DocumentType] ([Id], [Name], [Description] ,[ValidFrom] ,[ValidTo],[Active],[Organization_Id])
VALUES (5, '1165', 'ÁFA bevallás 2011-es évre', '2011.01.01', '2012.01.01', 1, 1)
INSERT INTO [dbo].[DocumentType] ([Id], [Name], [Description] ,[ValidFrom] ,[ValidTo],[Active],[Organization_Id])
VALUES (6, '11T180', 'Bejelentés és adóhatósági regisztrációs adatlap 2011-es évre', '2011.01.01', '2012.01.01', 1, 1)
INSERT INTO [dbo].[DocumentType] ([Id], [Name], [Description] ,[ValidFrom] ,[ValidTo],[Active],[Organization_Id])
VALUES (7, 'VPOP_KT11BEV', 'Környezetvédelmi termékdíjjal kapcsolatos termékdíjfizetési...', '2011.01.01', '2012.01.01', 1, 5)
GO
SET IDENTITY_INSERT [dbo].[DocumentType] OFF
GO

SET IDENTITY_INSERT [dbo].[DocTypeVersion] ON
GO
INSERT INTO [dbo].[DocTypeVersion] ([Id],[VersionString],[Major],[Minor],[IsLast],[Active],[DocumentType_Id])
VALUES (1, '13.0', 13, 0, 1, 1, 1)
INSERT INTO [dbo].[DocTypeVersion] ([Id],[VersionString],[Major],[Minor],[IsLast],[Active],[DocumentType_Id])
VALUES (2, '1.1', 1, 1, 1, 1, 2)
INSERT INTO [dbo].[DocTypeVersion] ([Id],[VersionString],[Major],[Minor],[IsLast],[Active],[DocumentType_Id])
VALUES (3, '5.0', 5, 0, 1, 1, 3)
INSERT INTO [dbo].[DocTypeVersion] ([Id],[VersionString],[Major],[Minor],[IsLast],[Active],[DocumentType_Id])
VALUES (4, '1.0', 1, 0, 1, 1, 4)
INSERT INTO [dbo].[DocTypeVersion] ([Id],[VersionString],[Major],[Minor],[IsLast],[Active],[DocumentType_Id])
VALUES (5, '4.0', 4, 0, 1, 1, 5)
INSERT INTO [dbo].[DocTypeVersion] ([Id],[VersionString],[Major],[Minor],[IsLast],[Active],[DocumentType_Id])
VALUES (6, '8.0', 8, 0, 1, 1, 6)
INSERT INTO [dbo].[DocTypeVersion] ([Id],[VersionString],[Major],[Minor],[IsLast],[Active],[DocumentType_Id])
VALUES (7, '1.1', 1, 1, 1, 1, 7)
GO
SET IDENTITY_INSERT [dbo].[DocTypeVersion] OFF
GO

SET IDENTITY_INSERT [dbo].[User] ON
GO
INSERT INTO [dbo].[User] ([Id], [Name]) VALUES (1, 'Pócza Krisztián')
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
