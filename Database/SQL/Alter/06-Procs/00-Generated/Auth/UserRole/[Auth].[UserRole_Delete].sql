-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[UserRole_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[UserRole_Delete]
GO--
CREATE PROCEDURE [Auth].[UserRole_Delete] 
			@UserRoleId int
AS --Generated--
BEGIN

	DELETE FROM	[Auth].[UserRole]
	WHERE	[UserRoleId] = @UserRoleId

END