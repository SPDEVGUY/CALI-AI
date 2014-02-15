-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[UserRole_Update]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[UserRole_Update]
GO--
CREATE PROCEDURE [Auth].[UserRole_Update] 
			@UserRoleId int,
			@UserId int,
			@RoleId int
AS --Generated--
BEGIN

	UPDATE	[Auth].[UserRole] SET 
			[UserId] = @UserId,
			[RoleId] = @RoleId
	WHERE	[UserRoleId] = @UserRoleId

END