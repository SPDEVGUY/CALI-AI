-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Data].[BinaryDataMoniker_Insert]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Data].[BinaryDataMoniker_Insert]
GO--
CREATE PROCEDURE [Data].[BinaryDataMoniker_Insert]
			@BinaryDataId int,
			@MonikerId int
AS --Generated--
BEGIN

	INSERT INTO [Data].[BinaryDataMoniker] (

			[BinaryDataId],
			[MonikerId]
	) VALUES (

			@BinaryDataId,
			@MonikerId
	)

	SELECT CAST(SCOPE_IDENTITY() AS int) AS [BinaryDataMonikerId]
END