IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Data].[Moniker]') AND type in (N'U'))
BEGIN
	CREATE TABLE [Data].[Moniker](
		[MonikerId] int IDENTITY(1,1) NOT NULL,
		[Text] varchar(200)  NOT NULL,
		[AliasForMoniker] int  NOT NULL,
		[DateCreated] datetime  NOT NULL,
		CONSTRAINT [PK_Moniker] PRIMARY KEY CLUSTERED ([MonikerId])
	)  
	INSERT INTO [Data].[TableVersion]([TableName],[Version]) VALUES('[Data].[Moniker]', 0)
END
