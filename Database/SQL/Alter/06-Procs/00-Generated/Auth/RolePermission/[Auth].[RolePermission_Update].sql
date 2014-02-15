-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[RolePermission_Update]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[RolePermission_Update]
GO--
CREATE PROCEDURE [Auth].[RolePermission_Update] 
			@RolePermissionId int,
			@RoleId int,
			@PermissionId int
AS --Generated--
BEGIN

	UPDATE	[Auth].[RolePermission] SET 
			[RoleId] = @RoleId,
			[PermissionId] = @PermissionId
	WHERE	[RolePermissionId] = @RolePermissionId

END