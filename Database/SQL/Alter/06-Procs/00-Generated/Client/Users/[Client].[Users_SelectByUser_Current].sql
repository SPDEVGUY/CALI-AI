-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Client].[Users_SelectByUser_Current]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Client].[Users_SelectByUser_Current]
GO--
CREATE PROCEDURE [Client].[Users_SelectByUser_Current]
	@AuthUserId int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT	*
	FROM	[Client].[Users]
	WHERE	[UserId] = @AuthUserId

END