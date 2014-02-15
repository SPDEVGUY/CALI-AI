ALTER TABLE [Auth].[RolePermission]
ADD	CONSTRAINT [FK_RolePermission_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Auth].[Role] ([RoleId])
,	CONSTRAINT [FK_RolePermission_PermissionId] FOREIGN KEY ([PermissionId]) REFERENCES [Auth].[Permission] ([PermissionId])
