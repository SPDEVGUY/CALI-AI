-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Data].[BinaryData_Search]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Data].[BinaryData_Search]
GO--
CREATE PROCEDURE [Data].[BinaryData_Search] 
			@DataType varchar(50) = NULL,
			@Hash varchar(64) = NULL
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
	WHERE	(@DataType IS NULL OR [DataType] LIKE '%' + @DataType + '%')
			AND (@Hash IS NULL OR [Hash] LIKE '%' + @Hash + '%')

END