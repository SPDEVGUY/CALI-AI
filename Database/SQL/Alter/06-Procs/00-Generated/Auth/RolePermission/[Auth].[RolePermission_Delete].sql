-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[RolePermission_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[RolePermission_Delete]
GO--
CREATE PROCEDURE [Auth].[RolePermission_Delete] 
			@RolePermissionId int
AS --Generated--
BEGIN

	DELETE FROM	[Auth].[RolePermission]
	WHERE	[RolePermissionId] = @RolePermissionId

END