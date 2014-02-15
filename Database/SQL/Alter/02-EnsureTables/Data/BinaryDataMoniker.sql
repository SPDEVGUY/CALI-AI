IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Data].[BinaryDataMoniker]') AND type in (N'U'))
BEGIN
	CREATE TABLE [Data].[BinaryDataMoniker](
		[BinaryDataMonikerId] int IDENTITY(1,1) NOT NULL,
		[BinaryDataId] int  NOT NULL,
		[MonikerId] int  NOT NULL,
		CONSTRAINT [PK_BinaryDataMoniker] PRIMARY KEY CLUSTERED ([BinaryDataMonikerId])
	)  
	INSERT INTO [Data].[TableVersion]([TableName],[Version]) VALUES('[Data].[BinaryDataMoniker]', 0)
END
