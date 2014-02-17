-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Data].[Query_SelectBy_QueryId]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Data].[Query_SelectBy_QueryId]
GO--
CREATE PROCEDURE [Data].[Query_SelectBy_QueryId] 
			@QueryId int
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[QueryId],
			[Text],
			[PoviderSource],
			[ProcessorUsed],
			[Exceptions],
			[IsSuccess]
	FROM	[Data].[Query]
	WHERE	[QueryId] = @QueryId

END