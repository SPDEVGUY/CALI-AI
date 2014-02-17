-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Data].[Log_SelectBy_LogId]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Data].[Log_SelectBy_LogId]
GO--
CREATE PROCEDURE [Data].[Log_SelectBy_LogId] 
			@LogId int
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[LogId],
			[RunOnMachineName],
			[LogContents],
			[RunTime]
	FROM	[Data].[Log]
	WHERE	[LogId] = @LogId

END