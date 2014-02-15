-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Data].[Query_Update]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Data].[Query_Update]
GO--
CREATE PROCEDURE [Data].[Query_Update] 
			@QueryId int,
			@Text varchar(max),
			@ProcessorUsed varchar(max) = NULL,
			@Exceptions varchar(max) = NULL,
			@IsSuccess bit
AS --Generated--
BEGIN

	UPDATE	[Data].[Query] SET 
			[Text] = @Text,
			[ProcessorUsed] = @ProcessorUsed,
			[Exceptions] = @Exceptions,
			[IsSuccess] = @IsSuccess
	WHERE	[QueryId] = @QueryId

END