USE [master]

GO--

-- This script creates a database with the provided name.

DECLARE @DatabaseName as nvarchar(30); SET @DatabaseName = 'CALI';





IF NOT EXISTS (
	SELECT name 
	FROM master.dbo.sysdatabases 
	WHERE ('[' + name + ']' = @DatabaseName OR name = @DatabaseName))
BEGIN

	-------------------------------------------------------------------
	-- LOGIC CODE BELOW, EDIT DATABASE NAME ABOVE
	-------------------------------------------------------------------

	-- Creates Database Object
	EXEC('CREATE DATABASE [' + @DatabaseName + '] COLLATE SQL_Latin1_General_CP1_CI_AS')

	-- Set compatibility level to 90 = SQL Server 2005
	EXEC dbo.sp_dbcmptlevel @dbname=@DatabaseName, @new_cmptlevel=90

	-- Disable full text Database
	IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
		EXEC('EXEC [' + @DatabaseName + '].[dbo].[sp_fulltext_database] @action = ''disable''')

	-- Set Database Defaults
	EXEC('ALTER DATABASE ' + @DatabaseName + ' SET ANSI_NULL_DEFAULT OFF ')
	EXEC('ALTER DATABASE ' + @DatabaseName + ' SET ANSI_NULLS OFF ')
	EXEC('ALTER DATABASE ' + @DatabaseName + ' SET ANSI_PADDING OFF ')
	EXEC('ALTER DATABASE ' + @DatabaseName + ' SET ANSI_WARNINGS OFF ')
	EXEC('ALTER DATABASE ' + @DatabaseName + ' SET ARITHABORT OFF ')
	EXEC('ALTER DATABASE ' + @DatabaseName + ' SET AUTO_CLOSE OFF ')
	EXEC('ALTER DATABASE ' + @DatabaseName + ' SET AUTO_CREATE_STATISTICS ON ')
	EXEC('ALTER DATABASE ' + @DatabaseName + ' SET AUTO_SHRINK OFF ')
	EXEC('ALTER DATABASE ' + @DatabaseName + ' SET AUTO_UPDATE_STATISTICS ON ')
	EXEC('ALTER DATABASE ' + @DatabaseName + ' SET CURSOR_CLOSE_ON_COMMIT OFF ')
	EXEC('ALTER DATABASE ' + @DatabaseName + ' SET CURSOR_DEFAULT  GLOBAL ')
	EXEC('ALTER DATABASE ' + @DatabaseName + ' SET CONCAT_NULL_YIELDS_NULL OFF ')
	EXEC('ALTER DATABASE ' + @DatabaseName + ' SET NUMERIC_ROUNDABORT OFF ')
	EXEC('ALTER DATABASE ' + @DatabaseName + ' SET QUOTED_IDENTIFIER OFF ')
	EXEC('ALTER DATABASE ' + @DatabaseName + ' SET RECURSIVE_TRIGGERS OFF ')
	EXEC('ALTER DATABASE ' + @DatabaseName + ' SET ENABLE_BROKER ')
	EXEC('ALTER DATABASE ' + @DatabaseName + ' SET AUTO_UPDATE_STATISTICS_ASYNC OFF ')
	EXEC('ALTER DATABASE ' + @DatabaseName + ' SET DATE_CORRELATION_OPTIMIZATION OFF ')
	EXEC('ALTER DATABASE ' + @DatabaseName + ' SET TRUSTWORTHY OFF ')
	EXEC('ALTER DATABASE ' + @DatabaseName + ' SET ALLOW_SNAPSHOT_ISOLATION OFF ')
	EXEC('ALTER DATABASE ' + @DatabaseName + ' SET PARAMETERIZATION SIMPLE ')
	EXEC('ALTER DATABASE ' + @DatabaseName + ' SET READ_WRITE ')
	EXEC('ALTER DATABASE ' + @DatabaseName + ' SET RECOVERY FULL ')
	EXEC('ALTER DATABASE ' + @DatabaseName + ' SET MULTI_USER ')
	EXEC('ALTER DATABASE ' + @DatabaseName + ' SET PAGE_VERIFY CHECKSUM  ')
	EXEC('ALTER DATABASE ' + @DatabaseName + ' SET DB_CHAINING OFF ')

END 
GO--
USE [master]

GO--

-- This script creates a database named DatabaseName, an SQL login named DatabaseNameUser, with the provided password.
-- The user is then granted access to run stored procs.

--Note: $ = Var from RunAllSql

DECLARE @DatabaseName as nvarchar(30); SET @DatabaseName = 'CALI';
DECLARE @UseWindowsAuth as bit; SET @UseWindowsAuth = 0;
DECLARE @AccountName as nvarchar(30);  SET @AccountName = 'CALIUser';
DECLARE @SQLAccountPassword as nvarchar(30); SET @SQLAccountPassword = 'ThisIsASecurePassw0rd!';





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
GO--
