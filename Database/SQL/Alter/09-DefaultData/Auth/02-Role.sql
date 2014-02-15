IF NOT EXISTS(SELECT * FROM [Auth].[Role]) BEGIN

	INSERT INTO [Auth].[Role]
           ([Title]
           ,[Description]
           ,[IsActive]
           ,[ApplyToAnon]
           ,[ApplyToAllUsers]
           ,[PreventAddingUsers])
	SELECT
			   'Security Admins'
			   ,'A role for the security admin user.'
			   ,1
			   ,0
			   ,0
			   ,1
	UNION ALL SELECT
			   'All Users'
			   ,'A role that applies permissions to all users.'
			   ,1
			   ,0
			   ,1
			   ,1	
	UNION ALL SELECT
			   'Anonymous Users'
			   ,'A role that applies permissions to anonymous users (and all users).'
			   ,1
			   ,1
			   ,1
			   ,1
END