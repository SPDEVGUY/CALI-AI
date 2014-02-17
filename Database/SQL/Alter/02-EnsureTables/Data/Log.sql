IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Data].[Log]') AND type in (N'U'))
BEGIN
	CREATE TABLE [Data].[Log](
		[LogId] int IDENTITY(1,1) NOT NULL,
		[RunOnMachineName] varchar(50)  NOT NULL,
		[LogContents] varchar(max)  NOT NULL,
		[RunTime] datetime  NOT NULL,
		CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED ([LogId])
	)  
	INSERT INTO [Data].[TableVersion]([TableName],[Version]) VALUES('[Data].[Log]', 0)
END
