-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[Permission_SelectBy_UserId]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[Permission_SelectBy_UserId]
GO--
CREATE PROCEDURE [Auth].[Permission_SelectBy_UserId] 
			@UserId int
AS 
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[PermissionId],
			[PermissionName],
			[Title],
			[IsRead]
	FROM	[Auth].[Permission]
	WHERE	
	[PermissionId] IN -- Anonymous / All users permissions
	(	SELECT	[PermissionId]
		FROM	[Auth].[RolePermission] RP
		INNER JOIN
				[Auth].[Role] R
				ON RP.[RoleId] = R.[RoleId]
		WHERE
			(R.[ApplyToAnon] = 1 OR (R.[ApplyToAllUsers] = 1 AND @UserId > 0))
			AND R.[IsActive] = 1
	) OR [PermissionId] IN -- Specifically assigned permissions
	(	SELECT	[PermissionId]
		FROM	[Auth].[RolePermission] RP
		INNER JOIN
				[Auth].[Role] R
				ON RP.[RoleId] = R.[RoleId]
		INNER JOIN 
				[Auth].[UserRole] UR
				ON R.[RoleId] = UR.[RoleId]
		WHERE
			UR.[UserId] = @UserId
			AND R.[IsActive] = 1
	)
		

END