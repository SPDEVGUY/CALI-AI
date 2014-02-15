-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Data].[BinaryData_SelectBy_BinaryDataId]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Data].[BinaryData_SelectBy_BinaryDataId]
GO--
CREATE PROCEDURE [Data].[BinaryData_SelectBy_BinaryDataId] 
			@BinaryDataId int
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[BinaryDataId],
			[DataType],
			[Hash],
			[Data],
			[DateCreated]
	FROM	[Data].[BinaryData]
	WHERE	[BinaryDataId] = @BinaryDataId

END