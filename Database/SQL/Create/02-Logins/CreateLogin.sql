USE [master]
GO

-- This script creates a database named DatabaseName, an SQL login named DatabaseNameUser, with the provided password.
-- The user is then granted access to run stored procs.

--Note: $ = Var from RunAllSql

DECLARE @DatabaseName as nvarchar(30); SET @DatabaseName = 'CALI';
DECLARE @UseWindowsAuth as bit; SET @UseWindowsAuth = $UseWindowsAuth;
DECLARE @AccountName as nvarchar(30);  SET @AccountName = '$AccountName';
DECLARE @SQLAccountPassword as nvarchar(30); SET @SQLAccountPassword = '$SQLAccountPassword';





-------------------------------------------------------------------
-- LOGIC CODE BELOW, EDIT DATABASE NAME ABOVE
-------------------------------------------------------------------

IF NOT EXISTS (SELECT * FROM sys.server_principals WHERE name = @AccountName) BEGIN
	IF @UseWindowsAuth = 0 -- Create the SQL user login
		EXEC('CREATE LOGIN [' + @AccountName + '] WITH PASSWORD=N''' + @SQLAccountPassword +  ''', DEFAULT_DATABASE=[' + @DatabaseName + '], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF')

	ELSE -- Create the Windows Auth Login
		EXEC('CREATE LOGIN [' + @AccountName + '] FROM WINDOWS WITH DEFAULT_DATABASE=[' + @DatabaseName + ']')
END

EXEC('
USE [' + @DatabaseName + ']
	IF DATABASE_PRINCIPAL_ID(''db_executor'') IS NULL
	BEGIN 
		CREATE ROLE db_executor AuthORIZATION dbo
	END
	IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N''' + @AccountName + ''')
	BEGIN
		CREATE USER [' + @AccountName + '] FOR LOGIN [' + @AccountName + ']
		EXEC sp_addrolemember ''db_datawriter'', N''' + @AccountName + '''
		EXEC sp_addrolemember ''db_datareader'', N''' + @AccountName + '''
		EXEC sp_addrolemember ''db_executor'', N''' + @AccountName + '''
	END
')