IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Auth].[Permission]') AND type in (N'U'))
BEGIN
	CREATE TABLE [Auth].[Permission](
		[PermissionId] [int] IDENTITY(1,1) NOT NULL, --NOTE: This will probably not end up lining up with the enum value, go by name instead.
		[PermissionName] [varchar](100) NOT NULL, --NOTE: This should be the same as the auto generated enum.
		[Title] [varchar](150) NOT NULL, --NOTE: This is a human readable title.
		[IsRead] [bit] NOT NULL,
		CONSTRAINT [PK_Permission] PRIMARY KEY CLUSTERED ([PermissionId] ASC)
	)  
	INSERT INTO [Auth].[TableVersion]([TableName],[Version]) VALUES('[Auth].[Permission]', 0)
END
