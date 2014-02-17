-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Data].[Log_Update]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Data].[Log_Update]
GO--
CREATE PROCEDURE [Data].[Log_Update] 
			@LogId int,
			@RunOnMachineName varchar(50),
			@LogContents varchar(max),
			@RunTime datetime
AS --Generated--
BEGIN

	UPDATE	[Data].[Log] SET 
			[RunOnMachineName] = @RunOnMachineName,
			[LogContents] = @LogContents,
			[RunTime] = @RunTime
	WHERE	[LogId] = @LogId

END