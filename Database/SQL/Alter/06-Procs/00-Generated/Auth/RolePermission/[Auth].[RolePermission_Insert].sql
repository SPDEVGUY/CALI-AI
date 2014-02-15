-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[RolePermission_Insert]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[RolePermission_Insert]
GO--
CREATE PROCEDURE [Auth].[RolePermission_Insert]
			@RoleId int,
			@PermissionId int
AS --Generated--
BEGIN

	INSERT INTO [Auth].[RolePermission] (

			[RoleId],
			[PermissionId]
	) VALUES (

			@RoleId,
			@PermissionId
	)

	SELECT CAST(SCOPE_IDENTITY() AS int) AS [RolePermissionId]
END