-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Client].[TableVersion_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Client].[TableVersion_Delete]
GO--
CREATE PROCEDURE [Client].[TableVersion_Delete] 
			@TableId int
AS --Generated--
BEGIN

	DELETE FROM	[Client].[TableVersion]
	WHERE	[TableId] = @TableId

END