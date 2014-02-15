-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[RolePermission_SelectBy_PermissionId]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[RolePermission_SelectBy_PermissionId]
GO--
CREATE PROCEDURE [Auth].[RolePermission_SelectBy_PermissionId] 
			@PermissionId int
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[RolePermissionId],
			[RoleId],
			[PermissionId]
	FROM	[Auth].[RolePermission]
	WHERE	[PermissionId] = @PermissionId

END