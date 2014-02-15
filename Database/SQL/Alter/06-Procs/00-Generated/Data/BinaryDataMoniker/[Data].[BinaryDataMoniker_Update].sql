-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Data].[BinaryDataMoniker_Update]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Data].[BinaryDataMoniker_Update]
GO--
CREATE PROCEDURE [Data].[BinaryDataMoniker_Update] 
			@BinaryDataMonikerId int,
			@BinaryDataId int,
			@MonikerId int
AS --Generated--
BEGIN

	UPDATE	[Data].[BinaryDataMoniker] SET 
			[BinaryDataId] = @BinaryDataId,
			[MonikerId] = @MonikerId
	WHERE	[BinaryDataMonikerId] = @BinaryDataMonikerId

END