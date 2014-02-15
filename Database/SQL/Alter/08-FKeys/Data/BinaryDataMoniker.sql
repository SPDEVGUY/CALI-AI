ALTER TABLE [Data].[BinaryDataMoniker]
ADD	CONSTRAINT [FK_Data_BinaryDataMoniker_BinaryDataId] FOREIGN KEY ([BinaryDataId]) REFERENCES [Data].[BinaryData] ([BinaryDataId])

,	CONSTRAINT [FK_Data_BinaryDataMoniker_MonikerId] FOREIGN KEY ([MonikerId]) REFERENCES [Data].[Moniker] ([MonikerId])

