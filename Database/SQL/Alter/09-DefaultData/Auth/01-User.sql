IF NOT EXISTS(SELECT * FROM [Auth].[User]) BEGIN

	INSERT INTO [Auth].[User]
			   ([UserName]
			   ,[Password]
			   ,[DisplayName]
			   ,[Email]
			   ,[AuthToken]
			   ,[UserToken]
			   ,[FailedLogins]
			   ,[IsActive])
	SELECT
				'SecurityAdmin'
			   ,HASHBYTES('MD5','$ecurity4dmiN!')
			   ,'Security Admin'
			   ,'Security@test.com'
			   ,NEWID()
			   ,NEWID()
			   ,0
			   ,1	
	UNION ALL SELECT
			   'test'
			   ,HASHBYTES('MD5','test')
			   ,'Test User'
			   ,'Test@test.com'
			   ,NEWID()
			   ,NEWID()
			   ,0
			   ,1
	UNION ALL SELECT
			   'test2'
			   ,HASHBYTES('MD5','test')
			   ,'Test User 2'
			   ,'Test2@test.com'
			   ,NEWID()
			   ,NEWID()
			   ,0
			   ,1
	UNION ALL SELECT
			   'test3'
			   ,HASHBYTES('MD5','test')
			   ,'Test User 3'
			   ,'Test3@test.com'
			   ,NEWID()
			   ,NEWID()
			   ,0
			   ,1
			   
END