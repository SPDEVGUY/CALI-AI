DECLARE @SecurityAdminRoleId int;
DECLARE @AllUsersRoleId int;
DECLARE @AnonymousRoleId int;
DECLARE @SecurityAdminUserId int;

SELECT @SecurityAdminRoleId = [RoleId] FROM [Auth].[Role] WHERE [Title] = 'Security Admins'
SELECT @AllUsersRoleId = [RoleId] FROM [Auth].[Role] WHERE [Title] = 'All Users'
SELECT @AnonymousRoleId = [RoleId] FROM [Auth].[Role] WHERE [Title] = 'Anonymous Users'
SELECT @SecurityAdminUserId = [UserId] FROM [Auth].[User] WHERE [UserName] = 'SecurityAdmin'

-- Grant manage user role associations to security admin
INSERT INTO [Auth].[RolePermission]([RoleId],[PermissionId])
	SELECT	@SecurityAdminRoleId, [PermissionId]
	FROM	[Auth].[Permission] P
	WHERE	[PermissionName] LIKE 'Auth%'
	AND		NOT EXISTS(
				SELECT * FROM [Auth].[RolePermission] RP 
				WHERE [RoleId] = @SecurityAdminRoleId and RP.[PermissionId] = P.[PermissionId]
			)

-- Grant write access to authenticated users
INSERT INTO [Auth].[RolePermission]([RoleId],[PermissionId])
	SELECT	@AllUsersRoleId, [PermissionId]
	FROM	[Auth].[Permission] P
	WHERE	[IsRead] = 0
	AND		NOT [PermissionName] LIKE 'Auth%'
	AND		NOT EXISTS(
				SELECT * FROM [Auth].[RolePermission] RP 
				WHERE [RoleId] = @AllUsersRoleId and RP.[PermissionId] = P.[PermissionId]
			)

-- Grant read access to anonymous users (and authenticated users)
INSERT INTO [Auth].[RolePermission]([RoleId],[PermissionId])
	SELECT	@AnonymousRoleId, [PermissionId]
	FROM	[Auth].[Permission] P
	WHERE	[IsRead] = 1
	AND		NOT [PermissionName] LIKE 'Auth%'
	AND		NOT EXISTS(
				SELECT * FROM [Auth].[RolePermission] RP 
				WHERE [RoleId] = @AnonymousRoleId and RP.[PermissionId] = P.[PermissionId]
			)
