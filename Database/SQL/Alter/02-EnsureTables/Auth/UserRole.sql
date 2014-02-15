IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Auth].[UserRole]') AND type in (N'U'))
BEGIN
	CREATE TABLE [Auth].[UserRole](
		[UserRoleId] [int] IDENTITY(1,1) NOT NULL,
		[UserId] [int] NOT NULL,
		[RoleId] [int] NOT NULL,
		CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED ([UserRoleId] ASC)
	)  
	INSERT INTO [Auth].[TableVersion]([TableName],[Version]) VALUES('[Auth].[UserRole]', 0)
END
