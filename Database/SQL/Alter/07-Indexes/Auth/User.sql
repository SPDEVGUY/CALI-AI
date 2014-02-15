CREATE NONCLUSTERED INDEX [IX_User_UserName] 
	ON [Auth].[User] ([UserName])
CREATE NONCLUSTERED INDEX [IX_User_Email] 
	ON [Auth].[User] ([Email])
CREATE NONCLUSTERED INDEX [IX_User_UserToken] 
	ON [Auth].[User] ([UserToken])
CREATE NONCLUSTERED INDEX [IX_User_WINSID] 
	ON [Auth].[User] ([WINSID])
