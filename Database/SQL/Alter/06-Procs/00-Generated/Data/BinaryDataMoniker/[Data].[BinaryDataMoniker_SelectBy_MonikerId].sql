-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Data].[BinaryDataMoniker_SelectBy_MonikerId]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Data].[BinaryDataMoniker_SelectBy_MonikerId]
GO--
CREATE PROCEDURE [Data].[BinaryDataMoniker_SelectBy_MonikerId] 
			@MonikerId int
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[BinaryDataMonikerId],
			[BinaryDataId],
			[MonikerId]
	FROM	[Data].[BinaryDataMoniker]
	WHERE	[MonikerId] = @MonikerId

END