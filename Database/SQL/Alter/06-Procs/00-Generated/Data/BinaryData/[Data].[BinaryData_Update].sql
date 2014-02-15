-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Data].[BinaryData_Update]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Data].[BinaryData_Update]
GO--
CREATE PROCEDURE [Data].[BinaryData_Update] 
			@BinaryDataId int,
			@DataType varchar(50),
			@Hash varchar(64) = NULL,
			@Data varbinary(max),
			@DateCreated datetime
AS --Generated--
BEGIN

	UPDATE	[Data].[BinaryData] SET 
			[DataType] = @DataType,
			[Hash] = @Hash,
			[Data] = @Data,
			[DateCreated] = @DateCreated
	WHERE	[BinaryDataId] = @BinaryDataId

END