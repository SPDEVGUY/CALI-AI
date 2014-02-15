IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Data].[BinaryData]') AND type in (N'U'))
BEGIN
	CREATE TABLE [Data].[BinaryData](
		[BinaryDataId] int IDENTITY(1,1) NOT NULL,
		[DataType] varchar(50)  NOT NULL,
		[Hash] varchar(64)  NULL,
		[Data] varbinary(max)  NOT NULL,
		[DateCreated] datetime  NOT NULL,
		CONSTRAINT [PK_BinaryData] PRIMARY KEY CLUSTERED ([BinaryDataId])
	)  
	INSERT INTO [Data].[TableVersion]([TableName],[Version]) VALUES('[Data].[BinaryData]', 0)
END
