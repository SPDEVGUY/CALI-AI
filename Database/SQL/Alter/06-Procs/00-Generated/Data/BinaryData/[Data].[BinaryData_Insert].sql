-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Data].[BinaryData_Insert]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Data].[BinaryData_Insert]
GO--
CREATE PROCEDURE [Data].[BinaryData_Insert]
			@DataType varchar(50),
			@Hash varchar(64) = NULL,
			@Data varbinary(max),
			@DateCreated datetime
AS --Generated--
BEGIN

	INSERT INTO [Data].[BinaryData] (

			[DataType],
			[Hash],
			[Data],
			[DateCreated]
	) VALUES (

			@DataType,
			@Hash,
			@Data,
			@DateCreated
	)

	SELECT CAST(SCOPE_IDENTITY() AS int) AS [BinaryDataId]
END