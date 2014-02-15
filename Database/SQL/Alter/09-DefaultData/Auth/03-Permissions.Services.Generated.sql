IF NOT EXISTS(SELECT * FROM [Auth].[Permission] WHERE [PermissionName] = 'Client_Users_SelectByUser_Current' )
	INSERT INTO [Auth].[Permission] ([PermissionName],[Title],[IsRead]) VALUES ('Client_Users_SelectByUser_Current', 'Client Users SelectByUser Current',1);
IF NOT EXISTS(SELECT * FROM [Auth].[Permission] WHERE [PermissionName] = 'Client_Users_SelectByUser_UpdateProfile' )
	INSERT INTO [Auth].[Permission] ([PermissionName],[Title],[IsRead]) VALUES ('Client_Users_SelectByUser_UpdateProfile', 'Client Users SelectByUser UpdateProfile',1);
IF NOT EXISTS(SELECT * FROM [Auth].[Permission] WHERE [PermissionName] = 'Client_Users_Exists' )
	INSERT INTO [Auth].[Permission] ([PermissionName],[Title],[IsRead]) VALUES ('Client_Users_Exists', 'Client Users Exists',1);
IF NOT EXISTS(SELECT * FROM [Auth].[Permission] WHERE [PermissionName] = 'Client_Users_Search' )
	INSERT INTO [Auth].[Permission] ([PermissionName],[Title],[IsRead]) VALUES ('Client_Users_Search', 'Client Users Search',1);
IF NOT EXISTS(SELECT * FROM [Auth].[Permission] WHERE [PermissionName] = 'Client_Users_SelectAll' )
	INSERT INTO [Auth].[Permission] ([PermissionName],[Title],[IsRead]) VALUES ('Client_Users_SelectAll', 'Client Users SelectAll',1);
