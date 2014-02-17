-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Data].[Log_Search]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Data].[Log_Search]
GO--
CREATE PROCEDURE [Data].[Log_Search] 
			@RunOnMachineName varchar(50) = NULL,
			@LogContents varchar(max) = NULL
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[LogId],
			[RunOnMachineName],
			[LogContents],
			[RunTime]
	FROM	[Data].[Log]
	WHERE	(@RunOnMachineName IS NULL OR [RunOnMachineName] LIKE '%' + @RunOnMachineName + '%')
			AND (@LogContents IS NULL OR [LogContents] LIKE '%' + @LogContents + '%')

END