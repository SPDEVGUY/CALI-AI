-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[TableVersion_Update]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[TableVersion_Update]
GO--
CREATE PROCEDURE [Auth].[TableVersion_Update] 
			@TableId int,
			@TableName varchar(150),
			@Version int
AS --Generated--
BEGIN

	UPDATE	[Auth].[TableVersion] SET 
			[TableName] = @TableName,
			[Version] = @Version
	WHERE	[TableId] = @TableId

END