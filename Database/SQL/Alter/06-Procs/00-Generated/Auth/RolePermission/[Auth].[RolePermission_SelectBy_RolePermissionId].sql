-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[RolePermission_SelectBy_RolePermissionId]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[RolePermission_SelectBy_RolePermissionId]
GO--
CREATE PROCEDURE [Auth].[RolePermission_SelectBy_RolePermissionId] 
			@RolePermissionId int
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[RolePermissionId],
			[RoleId],
			[PermissionId]
	FROM	[Auth].[RolePermission]
	WHERE	[RolePermissionId] = @RolePermissionId

END