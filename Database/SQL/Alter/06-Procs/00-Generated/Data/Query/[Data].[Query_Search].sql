-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Data].[Query_Search]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Data].[Query_Search]
GO--
CREATE PROCEDURE [Data].[Query_Search] 
			@Text varchar(max) = NULL,
			@ProcessorUsed varchar(max) = NULL,
			@Exceptions varchar(max) = NULL
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[QueryId],
			[Text],
			[ProcessorUsed],
			[Exceptions],
			[IsSuccess]
	FROM	[Data].[Query]
	WHERE	(@Text IS NULL OR [Text] LIKE '%' + @Text + '%')
			AND (@ProcessorUsed IS NULL OR [ProcessorUsed] LIKE '%' + @ProcessorUsed + '%')
			AND (@Exceptions IS NULL OR [Exceptions] LIKE '%' + @Exceptions + '%')

END