IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Auth].[RolePermission]') AND type in (N'U'))
BEGIN
	CREATE TABLE [Auth].[RolePermission](
		[RolePermissionId] [int] IDENTITY(1,1) NOT NULL,
		[RoleId] [int] NOT NULL,
		[PermissionId] [int] NOT NULL,
		CONSTRAINT [PK_RolePermission] PRIMARY KEY CLUSTERED ([RolePermissionId] ASC)
	)  
	INSERT INTO [Auth].[TableVersion]([TableName],[Version]) VALUES('[Auth].[RolePermission]', 0)
END
