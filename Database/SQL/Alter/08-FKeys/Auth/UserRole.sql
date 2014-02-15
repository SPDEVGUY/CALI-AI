ALTER TABLE [Auth].[UserRole]
ADD	CONSTRAINT [FK_UserRole_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Auth].[Role] ([RoleId])
,	CONSTRAINT [FK_UserRole_UserId] FOREIGN KEY ([UserId]) REFERENCES [Auth].[User] ([UserId])
