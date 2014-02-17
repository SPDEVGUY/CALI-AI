-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Data].[Log_Insert]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Data].[Log_Insert]
GO--
CREATE PROCEDURE [Data].[Log_Insert]
			@RunOnMachineName varchar(50),
			@LogContents varchar(max),
			@RunTime datetime
AS --Generated--
BEGIN

	INSERT INTO [Data].[Log] (

			[RunOnMachineName],
			[LogContents],
			[RunTime]
	) VALUES (

			@RunOnMachineName,
			@LogContents,
			@RunTime
	)

	SELECT CAST(SCOPE_IDENTITY() AS int) AS [LogId]
END