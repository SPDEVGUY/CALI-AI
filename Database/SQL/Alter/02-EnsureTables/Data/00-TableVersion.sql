IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Data].[TableVersion]') AND type in (N'U'))
BEGIN
	CREATE TABLE [Data].[TableVersion](
		[TableId]		[int]			IDENTITY(1,1) NOT NULL,
		[TableName]		[varchar](150)	NOT NULL,
		[Version]		[int]			NOT NULL DEFAULT ((0)),
		CONSTRAINT [PK_TableVersion] PRIMARY KEY CLUSTERED ([TableId] ASC)
	)
	
	INSERT INTO [Data].[TableVersion] ([TableName],[Version]) VALUES('[Data].[TableVersion]',0)
END