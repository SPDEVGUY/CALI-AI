IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Client].[TableVersion]') AND type in (N'U'))
BEGIN
	CREATE TABLE [Client].[TableVersion](
		[TableId]		[int]			IDENTITY(1,1) NOT NULL,
		[TableName]		[varchar](150)	NOT NULL,
		[Version]		[int]			NOT NULL DEFAULT ((0)),
		CONSTRAINT [PK_TableVersion] PRIMARY KEY CLUSTERED ([TableId] ASC)
	)
	
	INSERT INTO [Client].[TableVersion] ([TableName],[Version]) VALUES('[Client].[TableVersion]',0)
END