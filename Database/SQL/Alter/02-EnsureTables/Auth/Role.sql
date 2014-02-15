IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Auth].[Role]') AND type in (N'U'))
BEGIN
	CREATE TABLE [Auth].[Role](
		[RoleId] [int] IDENTITY(1,1) NOT NULL,
		[Title] [varchar](50) NOT NULL,
		[Description] [varchar](max) NOT NULL,
		[IsActive] [bit] NOT NULL,
		[ApplyToAnon] [bit] NOT NULL,		-- Use this flag to automatically have this apply to anonymous
		[ApplyToAllUsers] [bit] NOT NULL,	-- Use this flag to automatically have this apply to all users
		[PreventAddingUsers] [bit] NOT NULL,  -- System admin means do not allow addition of any users by proc
		[WINSID] [varchar](50) NULL,		-- This winsid is the id of a group, and can be used by an AD Sync operation to automatically add users to the role.
		CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED ([RoleId] ASC)
	)  
	INSERT INTO [Auth].[TableVersion]([TableName],[Version]) VALUES('[Auth].[Role]', 0)
END
