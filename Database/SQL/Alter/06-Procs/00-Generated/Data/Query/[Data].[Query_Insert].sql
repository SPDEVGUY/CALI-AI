-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Data].[Query_Insert]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Data].[Query_Insert]
GO--
CREATE PROCEDURE [Data].[Query_Insert]
			@Text varchar(max),
			@ProcessorUsed varchar(max) = NULL,
			@Exceptions varchar(max) = NULL,
			@IsSuccess bit
AS --Generated--
BEGIN

	INSERT INTO [Data].[Query] (

			[Text],
			[ProcessorUsed],
			[Exceptions],
			[IsSuccess]
	) VALUES (

			@Text,
			@ProcessorUsed,
			@Exceptions,
			@IsSuccess
	)

	SELECT CAST(SCOPE_IDENTITY() AS int) AS [QueryId]
END