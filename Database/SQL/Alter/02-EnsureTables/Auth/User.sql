IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Auth].[User]') AND type in (N'U'))
BEGIN
	CREATE TABLE [Auth].[User](
		[UserId] [int] IDENTITY(1,1) NOT NULL,
		[UserName] [varchar](50) NOT NULL,
		[Password] [binary](16) NOT NULL,
		[DisplayName] [varchar](50) NOT NULL,
		[Email] [varchar](100) NOT NULL,
		[AuthToken] [uniqueidentifier] NOT NULL,
		[UserToken] [uniqueidentifier] NOT NULL,
		[FailedLogins] [int] NOT NULL,
		[IsActive] [bit] NOT NULL,
		[WINSID] [varchar](50) NULL,
		CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([UserId] ASC)
	)  
	INSERT INTO [Auth].[TableVersion]([TableName],[Version]) VALUES('[Auth].[User]', 0)
END
