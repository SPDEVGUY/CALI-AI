IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Data].[Query]') AND type in (N'U'))
BEGIN
	CREATE TABLE [Data].[Query](
		[QueryId] int IDENTITY(1,1) NOT NULL,
		[Text] varchar(max)  NOT NULL,
		[ProcessorUsed] varchar(max)  NULL,
		[Exceptions] varchar(max)  NULL,
		[IsSuccess] bit  NOT NULL,
		CONSTRAINT [PK_Query] PRIMARY KEY CLUSTERED ([QueryId])
	)  
	INSERT INTO [Data].[TableVersion]([TableName],[Version]) VALUES('[Data].[Query]', 0)
END
