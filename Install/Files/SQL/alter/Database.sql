USE [CALI]
DECLARE @SchemaName as nvarchar(20); SET @SchemaName = 'Auth';




-------------------------------------------------------------------
-- LOGIC CODE BELOW, EDIT SCHEMA NAME ABOVE
-------------------------------------------------------------------

IF DB_NAME() IN ('master', 'msdb', 'model', 'distribution')
BEGIN
	RAISERROR('Not for use on system databases', 16, 1)
	GOTO Done
END

SET NOCOUNT ON

DECLARE @DropStatement nvarchar(4000)
DECLARE @SequenceNumber int
DECLARE @LastError int
DECLARE @TablesDropped int

DECLARE DropStatements CURSOR LOCAL FAST_FORWARD READ_ONLY FOR

-- Stored Procedures
	SELECT	1 AS SequenceNumber,
			N'DROP PROCEDURE ' + QUOTENAME(ROUTINE_SCHEMA) + N'.' + QUOTENAME(ROUTINE_NAME) AS DropStatement
	FROM	INFORMATION_SCHEMA.ROUTINES
	WHERE	ROUTINE_TYPE = N'PROCEDURE'
	AND		ROUTINE_SCHEMA = @SchemaName
	AND		OBJECTPROPERTY( OBJECT_ID(QUOTENAME(ROUTINE_SCHEMA) + N'.' + QUOTENAME(ROUTINE_NAME)), 'IsMSShipped') = 0
UNION ALL
-- Functions
	SELECT	2 AS SequenceNumber,
			N'DROP FUNCTION ' + QUOTENAME(ROUTINE_SCHEMA) + N'.' + QUOTENAME(ROUTINE_NAME) AS DropStatement
	FROM	INFORMATION_SCHEMA.ROUTINES
	WHERE	ROUTINE_TYPE = N'FUNCTION'
	AND		ROUTINE_SCHEMA = @SchemaName
	AND		OBJECTPROPERTY( OBJECT_ID(QUOTENAME(ROUTINE_SCHEMA) + N'.' + QUOTENAME(ROUTINE_NAME)), 'IsMSShipped') = 0
UNION ALL
-- Forgeign Keys
	SELECT	3 AS SequenceNumber, 
			N'ALTER TABLE ' + QUOTENAME(TABLE_SCHEMA) + N'.' + QUOTENAME(TABLE_NAME) + N' DROP CONSTRAINT ' + CONSTRAINT_NAME AS DropStatement
	FROM	INFORMATION_SCHEMA.TABLE_CONSTRAINTS
	WHERE	CONSTRAINT_TYPE = N'FOREIGN KEY'
	AND		CONSTRAINT_SCHEMA = @SchemaName
UNION ALL
-- Indexes
	SELECT	4 AS SequenceNumber,
			N'DROP INDEX ' + QUOTENAME(IX.[Name]) + N' ON ' + QUOTENAME(S.[Name]) + N'.' + QUOTENAME(T.[Name]) + N' WITH ( ONLINE = OFF )' AS DropStatement
	FROM	sys.indexes IX
	INNER JOIN sys.objects T ON IX.Object_Id = T.Object_Id
	INNER JOIN sys.schemas S ON T.Schema_Id = S.Schema_Id
	WHERE	IX.[Name] LIKE 'IX_%'
	AND		S.[Name] = @SchemaName	
UNION ALL
-- Views
	SELECT	5 AS SequenceNumber,
			N'DROP VIEW ' + QUOTENAME(TABLE_SCHEMA) + N'.' + QUOTENAME(TABLE_NAME) AS DropStatement
	FROM	INFORMATION_SCHEMA.TABLES
	WHERE	TABLE_TYPE = N'VIEW' 
	AND		TABLE_SCHEMA = @SchemaName	
	AND		OBJECTPROPERTY( OBJECT_ID(QUOTENAME(TABLE_SCHEMA) + N'.' + QUOTENAME(TABLE_NAME)), 'IsMSShipped') = 0

OPEN DropStatements
WHILE 1 = 1
BEGIN
	FETCH NEXT FROM DropStatements INTO @SequenceNumber, @DropStatement
	IF @@FETCH_STATUS = -1 BREAK
	BEGIN
		RAISERROR('%s', 0, 1, @DropStatement) WITH NOWAIT
		EXECUTE sp_ExecuteSQL @DropStatement
		SET @LastError = @@ERROR
		IF @LastError > 0
		BEGIN
			RAISERROR('Script terminated due to unexpected error', 16, 1)
			GOTO Done
		END
	END
END

CLOSE DropStatements
DEALLOCATE DropStatements

Done:
GO--
USE [CALI]
DECLARE @SchemaName as nvarchar(20); SET @SchemaName = 'Client';




-------------------------------------------------------------------
-- LOGIC CODE BELOW, EDIT SCHEMA NAME ABOVE
-------------------------------------------------------------------

IF DB_NAME() IN ('master', 'msdb', 'model', 'distribution')
BEGIN
	RAISERROR('Not for use on system databases', 16, 1)
	GOTO Done
END

SET NOCOUNT ON

DECLARE @DropStatement nvarchar(4000)
DECLARE @SequenceNumber int
DECLARE @LastError int
DECLARE @TablesDropped int

DECLARE DropStatements CURSOR LOCAL FAST_FORWARD READ_ONLY FOR

-- Stored Procedures
	SELECT	1 AS SequenceNumber,
			N'DROP PROCEDURE ' + QUOTENAME(ROUTINE_SCHEMA) + N'.' + QUOTENAME(ROUTINE_NAME) AS DropStatement
	FROM	INFORMATION_SCHEMA.ROUTINES
	WHERE	ROUTINE_TYPE = N'PROCEDURE'
	AND		ROUTINE_SCHEMA = @SchemaName
	AND		OBJECTPROPERTY( OBJECT_ID(QUOTENAME(ROUTINE_SCHEMA) + N'.' + QUOTENAME(ROUTINE_NAME)), 'IsMSShipped') = 0
UNION ALL
-- Functions
	SELECT	2 AS SequenceNumber,
			N'DROP FUNCTION ' + QUOTENAME(ROUTINE_SCHEMA) + N'.' + QUOTENAME(ROUTINE_NAME) AS DropStatement
	FROM	INFORMATION_SCHEMA.ROUTINES
	WHERE	ROUTINE_TYPE = N'FUNCTION'
	AND		ROUTINE_SCHEMA = @SchemaName
	AND		OBJECTPROPERTY( OBJECT_ID(QUOTENAME(ROUTINE_SCHEMA) + N'.' + QUOTENAME(ROUTINE_NAME)), 'IsMSShipped') = 0
UNION ALL
-- Forgeign Keys
	SELECT	3 AS SequenceNumber, 
			N'ALTER TABLE ' + QUOTENAME(TABLE_SCHEMA) + N'.' + QUOTENAME(TABLE_NAME) + N' DROP CONSTRAINT ' + CONSTRAINT_NAME AS DropStatement
	FROM	INFORMATION_SCHEMA.TABLE_CONSTRAINTS
	WHERE	CONSTRAINT_TYPE = N'FOREIGN KEY'
	AND		CONSTRAINT_SCHEMA = @SchemaName
UNION ALL
-- Indexes
	SELECT	4 AS SequenceNumber,
			N'DROP INDEX ' + QUOTENAME(IX.[Name]) + N' ON ' + QUOTENAME(S.[Name]) + N'.' + QUOTENAME(T.[Name]) + N' WITH ( ONLINE = OFF )' AS DropStatement
	FROM	sys.indexes IX
	INNER JOIN sys.objects T ON IX.Object_Id = T.Object_Id
	INNER JOIN sys.schemas S ON T.Schema_Id = S.Schema_Id
	WHERE	IX.[Name] LIKE 'IX_%'
	AND		S.[Name] = @SchemaName	
UNION ALL
-- Views
	SELECT	5 AS SequenceNumber,
			N'DROP VIEW ' + QUOTENAME(TABLE_SCHEMA) + N'.' + QUOTENAME(TABLE_NAME) AS DropStatement
	FROM	INFORMATION_SCHEMA.TABLES
	WHERE	TABLE_TYPE = N'VIEW' 
	AND		TABLE_SCHEMA = @SchemaName	
	AND		OBJECTPROPERTY( OBJECT_ID(QUOTENAME(TABLE_SCHEMA) + N'.' + QUOTENAME(TABLE_NAME)), 'IsMSShipped') = 0

OPEN DropStatements
WHILE 1 = 1
BEGIN
	FETCH NEXT FROM DropStatements INTO @SequenceNumber, @DropStatement
	IF @@FETCH_STATUS = -1 BREAK
	BEGIN
		RAISERROR('%s', 0, 1, @DropStatement) WITH NOWAIT
		EXECUTE sp_ExecuteSQL @DropStatement
		SET @LastError = @@ERROR
		IF @LastError > 0
		BEGIN
			RAISERROR('Script terminated due to unexpected error', 16, 1)
			GOTO Done
		END
	END
END

CLOSE DropStatements
DEALLOCATE DropStatements

Done:
GO--
USE [CALI]
DECLARE @SchemaName as nvarchar(20); SET @SchemaName = 'Data';




-------------------------------------------------------------------
-- LOGIC CODE BELOW, EDIT SCHEMA NAME ABOVE
-------------------------------------------------------------------

IF DB_NAME() IN ('master', 'msdb', 'model', 'distribution')
BEGIN
	RAISERROR('Not for use on system databases', 16, 1)
	GOTO Done
END

SET NOCOUNT ON

DECLARE @DropStatement nvarchar(4000)
DECLARE @SequenceNumber int
DECLARE @LastError int
DECLARE @TablesDropped int

DECLARE DropStatements CURSOR LOCAL FAST_FORWARD READ_ONLY FOR

-- Stored Procedures
	SELECT	1 AS SequenceNumber,
			N'DROP PROCEDURE ' + QUOTENAME(ROUTINE_SCHEMA) + N'.' + QUOTENAME(ROUTINE_NAME) AS DropStatement
	FROM	INFORMATION_SCHEMA.ROUTINES
	WHERE	ROUTINE_TYPE = N'PROCEDURE'
	AND		ROUTINE_SCHEMA = @SchemaName
	AND		OBJECTPROPERTY( OBJECT_ID(QUOTENAME(ROUTINE_SCHEMA) + N'.' + QUOTENAME(ROUTINE_NAME)), 'IsMSShipped') = 0
UNION ALL
-- Functions
	SELECT	2 AS SequenceNumber,
			N'DROP FUNCTION ' + QUOTENAME(ROUTINE_SCHEMA) + N'.' + QUOTENAME(ROUTINE_NAME) AS DropStatement
	FROM	INFORMATION_SCHEMA.ROUTINES
	WHERE	ROUTINE_TYPE = N'FUNCTION'
	AND		ROUTINE_SCHEMA = @SchemaName
	AND		OBJECTPROPERTY( OBJECT_ID(QUOTENAME(ROUTINE_SCHEMA) + N'.' + QUOTENAME(ROUTINE_NAME)), 'IsMSShipped') = 0
UNION ALL
-- Forgeign Keys
	SELECT	3 AS SequenceNumber, 
			N'ALTER TABLE ' + QUOTENAME(TABLE_SCHEMA) + N'.' + QUOTENAME(TABLE_NAME) + N' DROP CONSTRAINT ' + CONSTRAINT_NAME AS DropStatement
	FROM	INFORMATION_SCHEMA.TABLE_CONSTRAINTS
	WHERE	CONSTRAINT_TYPE = N'FOREIGN KEY'
	AND		CONSTRAINT_SCHEMA = @SchemaName
UNION ALL
-- Indexes
	SELECT	4 AS SequenceNumber,
			N'DROP INDEX ' + QUOTENAME(IX.[Name]) + N' ON ' + QUOTENAME(S.[Name]) + N'.' + QUOTENAME(T.[Name]) + N' WITH ( ONLINE = OFF )' AS DropStatement
	FROM	sys.indexes IX
	INNER JOIN sys.objects T ON IX.Object_Id = T.Object_Id
	INNER JOIN sys.schemas S ON T.Schema_Id = S.Schema_Id
	WHERE	IX.[Name] LIKE 'IX_%'
	AND		S.[Name] = @SchemaName	
UNION ALL
-- Views
	SELECT	5 AS SequenceNumber,
			N'DROP VIEW ' + QUOTENAME(TABLE_SCHEMA) + N'.' + QUOTENAME(TABLE_NAME) AS DropStatement
	FROM	INFORMATION_SCHEMA.TABLES
	WHERE	TABLE_TYPE = N'VIEW' 
	AND		TABLE_SCHEMA = @SchemaName	
	AND		OBJECTPROPERTY( OBJECT_ID(QUOTENAME(TABLE_SCHEMA) + N'.' + QUOTENAME(TABLE_NAME)), 'IsMSShipped') = 0

OPEN DropStatements
WHILE 1 = 1
BEGIN
	FETCH NEXT FROM DropStatements INTO @SequenceNumber, @DropStatement
	IF @@FETCH_STATUS = -1 BREAK
	BEGIN
		RAISERROR('%s', 0, 1, @DropStatement) WITH NOWAIT
		EXECUTE sp_ExecuteSQL @DropStatement
		SET @LastError = @@ERROR
		IF @LastError > 0
		BEGIN
			RAISERROR('Script terminated due to unexpected error', 16, 1)
			GOTO Done
		END
	END
END

CLOSE DropStatements
DEALLOCATE DropStatements

Done:
GO--
DECLARE @SchemaName as nvarchar(20); SET @SchemaName = 'Auth';


-------------------------------------------------------------------
-- LOGIC CODE BELOW, EDIT SCHEMA NAME ABOVE
-------------------------------------------------------------------

IF NOT EXISTS (select * FROM sys.schemas WHERE name = @SchemaName)
	BEGIN   
		EXEC('CREATE SCHEMA [' + @SchemaName + ']');
		EXEC('GRANT EXECUTE ON SCHEMA::[' + @SchemaName + '] TO db_executor');
	END
GO--
DECLARE @SchemaName as nvarchar(20); SET @SchemaName = 'Client';


-------------------------------------------------------------------
-- LOGIC CODE BELOW, EDIT SCHEMA NAME ABOVE
-------------------------------------------------------------------

IF NOT EXISTS (select * FROM sys.schemas WHERE name = @SchemaName)
	BEGIN   
		EXEC('CREATE SCHEMA [' + @SchemaName + ']');
		EXEC('GRANT EXECUTE ON SCHEMA::[' + @SchemaName + '] TO db_executor');
	END
GO--
DECLARE @SchemaName as nvarchar(20); SET @SchemaName = 'Data';


-------------------------------------------------------------------
-- LOGIC CODE BELOW, EDIT SCHEMA NAME ABOVE
-------------------------------------------------------------------

IF NOT EXISTS (select * FROM sys.schemas WHERE name = @SchemaName)
	BEGIN   
		EXEC('CREATE SCHEMA [' + @SchemaName + ']');
		EXEC('GRANT EXECUTE ON SCHEMA::[' + @SchemaName + '] TO db_executor');
	END
GO--
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Auth].[TableVersion]') AND type in (N'U'))
BEGIN
	CREATE TABLE [Auth].[TableVersion](
		[TableId]		[int]			IDENTITY(1,1) NOT NULL,
		[TableName]		[varchar](150)	NOT NULL,
		[Version]		[int]			NOT NULL DEFAULT ((0)),
		CONSTRAINT [PK_TableVersion] PRIMARY KEY CLUSTERED ([TableId] ASC)
	)
	
	INSERT INTO [Auth].[TableVersion] ([TableName],[Version]) VALUES('[Auth].[TableVersion]',0)
END
GO--
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Auth].[Permission]') AND type in (N'U'))
BEGIN
	CREATE TABLE [Auth].[Permission](
		[PermissionId] [int] IDENTITY(1,1) NOT NULL, --NOTE: This will probably not end up lining up with the enum value, go by name instead.
		[PermissionName] [varchar](100) NOT NULL, --NOTE: This should be the same as the auto generated enum.
		[Title] [varchar](150) NOT NULL, --NOTE: This is a human readable title.
		[IsRead] [bit] NOT NULL,
		CONSTRAINT [PK_Permission] PRIMARY KEY CLUSTERED ([PermissionId] ASC)
	)  
	INSERT INTO [Auth].[TableVersion]([TableName],[Version]) VALUES('[Auth].[Permission]', 0)
END

GO--
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Auth].[Role]') AND type in (N'U'))
BEGIN
	CREATE TABLE [Auth].[Role](
		[RoleId] [int] IDENTITY(1,1) NOT NULL,
		[Title] [varchar](50) NOT NULL,
		[Description] [varchar](max) NOT NULL,
		[IsActive] [bit] NOT NULL,
		[ApplyToAnon] [bit] NOT NULL,		-- Use this flag to automatically have this apply to anonymous
		[ApplyToAllUsers] [bit] NOT NULL,	-- Use this flag to automatically have this apply to all users
		[PreventAddingUsers] [bit] NOT NULL,  -- System admin means do not allow addition of any users by proc
		[WINSID] [varchar](50) NULL,		-- This winsid is the id of a group, and can be used by an AD Sync operation to automatically add users to the role.
		CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED ([RoleId] ASC)
	)  
	INSERT INTO [Auth].[TableVersion]([TableName],[Version]) VALUES('[Auth].[Role]', 0)
END

GO--
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Auth].[RolePermission]') AND type in (N'U'))
BEGIN
	CREATE TABLE [Auth].[RolePermission](
		[RolePermissionId] [int] IDENTITY(1,1) NOT NULL,
		[RoleId] [int] NOT NULL,
		[PermissionId] [int] NOT NULL,
		CONSTRAINT [PK_RolePermission] PRIMARY KEY CLUSTERED ([RolePermissionId] ASC)
	)  
	INSERT INTO [Auth].[TableVersion]([TableName],[Version]) VALUES('[Auth].[RolePermission]', 0)
END

GO--
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Auth].[User]') AND type in (N'U'))
BEGIN
	CREATE TABLE [Auth].[User](
		[UserId] [int] IDENTITY(1,1) NOT NULL,
		[UserName] [varchar](50) NOT NULL,
		[Password] [binary](16) NOT NULL,
		[DisplayName] [varchar](50) NOT NULL,
		[Email] [varchar](100) NOT NULL,
		[AuthToken] [uniqueidentifier] NOT NULL,
		[UserToken] [uniqueidentifier] NOT NULL,
		[FailedLogins] [int] NOT NULL,
		[IsActive] [bit] NOT NULL,
		[WINSID] [varchar](50) NULL,
		CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([UserId] ASC)
	)  
	INSERT INTO [Auth].[TableVersion]([TableName],[Version]) VALUES('[Auth].[User]', 0)
END

GO--
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Auth].[UserRole]') AND type in (N'U'))
BEGIN
	CREATE TABLE [Auth].[UserRole](
		[UserRoleId] [int] IDENTITY(1,1) NOT NULL,
		[UserId] [int] NOT NULL,
		[RoleId] [int] NOT NULL,
		CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED ([UserRoleId] ASC)
	)  
	INSERT INTO [Auth].[TableVersion]([TableName],[Version]) VALUES('[Auth].[UserRole]', 0)
END

GO--
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Client].[TableVersion]') AND type in (N'U'))
BEGIN
	CREATE TABLE [Client].[TableVersion](
		[TableId]		[int]			IDENTITY(1,1) NOT NULL,
		[TableName]		[varchar](150)	NOT NULL,
		[Version]		[int]			NOT NULL DEFAULT ((0)),
		CONSTRAINT [PK_TableVersion] PRIMARY KEY CLUSTERED ([TableId] ASC)
	)
	
	INSERT INTO [Client].[TableVersion] ([TableName],[Version]) VALUES('[Client].[TableVersion]',0)
END
GO--
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Data].[TableVersion]') AND type in (N'U'))
BEGIN
	CREATE TABLE [Data].[TableVersion](
		[TableId]		[int]			IDENTITY(1,1) NOT NULL,
		[TableName]		[varchar](150)	NOT NULL,
		[Version]		[int]			NOT NULL DEFAULT ((0)),
		CONSTRAINT [PK_TableVersion] PRIMARY KEY CLUSTERED ([TableId] ASC)
	)
	
	INSERT INTO [Data].[TableVersion] ([TableName],[Version]) VALUES('[Data].[TableVersion]',0)
END
GO--
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Data].[BinaryData]') AND type in (N'U'))
BEGIN
	CREATE TABLE [Data].[BinaryData](
		[BinaryDataId] int IDENTITY(1,1) NOT NULL,
		[DataType] varchar(50)  NOT NULL,
		[Hash] varchar(64)  NULL,
		[Data] varbinary(max)  NOT NULL,
		[DateCreated] datetime  NOT NULL,
		CONSTRAINT [PK_BinaryData] PRIMARY KEY CLUSTERED ([BinaryDataId])
	)  
	INSERT INTO [Data].[TableVersion]([TableName],[Version]) VALUES('[Data].[BinaryData]', 0)
END

GO--
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Data].[BinaryDataMoniker]') AND type in (N'U'))
BEGIN
	CREATE TABLE [Data].[BinaryDataMoniker](
		[BinaryDataMonikerId] int IDENTITY(1,1) NOT NULL,
		[BinaryDataId] int  NOT NULL,
		[MonikerId] int  NOT NULL,
		CONSTRAINT [PK_BinaryDataMoniker] PRIMARY KEY CLUSTERED ([BinaryDataMonikerId])
	)  
	INSERT INTO [Data].[TableVersion]([TableName],[Version]) VALUES('[Data].[BinaryDataMoniker]', 0)
END

GO--
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Data].[Log]') AND type in (N'U'))
BEGIN
	CREATE TABLE [Data].[Log](
		[LogId] int IDENTITY(1,1) NOT NULL,
		[RunOnMachineName] varchar(50)  NOT NULL,
		[LogContents] varchar(max)  NOT NULL,
		[RunTime] datetime  NOT NULL,
		CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED ([LogId])
	)  
	INSERT INTO [Data].[TableVersion]([TableName],[Version]) VALUES('[Data].[Log]', 0)
END

GO--
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Data].[Moniker]') AND type in (N'U'))
BEGIN
	CREATE TABLE [Data].[Moniker](
		[MonikerId] int IDENTITY(1,1) NOT NULL,
		[Text] varchar(200)  NOT NULL,
		[AliasForMoniker] int  NOT NULL,
		[DateCreated] datetime  NOT NULL,
		CONSTRAINT [PK_Moniker] PRIMARY KEY CLUSTERED ([MonikerId])
	)  
	INSERT INTO [Data].[TableVersion]([TableName],[Version]) VALUES('[Data].[Moniker]', 0)
END

GO--
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Data].[Query]') AND type in (N'U'))
BEGIN
	CREATE TABLE [Data].[Query](
		[QueryId] int IDENTITY(1,1) NOT NULL,
		[Text] varchar(max)  NOT NULL,
		[PoviderSource] varchar(max)  NULL,
		[ProcessorUsed] varchar(max)  NULL,
		[Exceptions] varchar(max)  NULL,
		[IsSuccess] bit  NOT NULL,
		CONSTRAINT [PK_Query] PRIMARY KEY CLUSTERED ([QueryId])
	)  
	INSERT INTO [Data].[TableVersion]([TableName],[Version]) VALUES('[Data].[Query]', 0)
END

GO--
CREATE VIEW [Client].[Users] WITH SCHEMABINDING
AS
--Only return things you don't mind anyone seeing.
--Example: Protected email, usertoken, username...
SELECT [UserId]
      ,[DisplayName]
  FROM [Auth].[User]

GO--
CREATE FUNCTION [Auth].[GetUserIdByUserToken]
(
	@UserToken varchar(36)
)
RETURNS INT
AS
BEGIN
	DECLARE @UserId INT;
	SET @UserId = ISNULL(
		(
			SELECT [UserId] FROM [Auth].[User] WHERE [UserToken] = @UserToken 
		), 0)

	RETURN @UserId
END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[Permission_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[Permission_Delete]

GO--

CREATE PROCEDURE [Auth].[Permission_Delete] 
			@PermissionId int
AS --Generated--
BEGIN

	DELETE FROM	[Auth].[Permission]
	WHERE	[PermissionId] = @PermissionId

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[Permission_Exists]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[Permission_Exists]

GO--

CREATE PROCEDURE [Auth].[Permission_Exists]
			@PermissionId int
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	IF EXISTS(
		SELECT * FROM [Auth].[Permission]
		WHERE	[PermissionId] = @PermissionId
	) BEGIN
		SELECT CAST(1 as bit) as [Exists]
	END ELSE BEGIN
		SELECT CAST(0 as bit) as [Exists]
	END
END

GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[Permission_Insert]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[Permission_Insert]

GO--

CREATE PROCEDURE [Auth].[Permission_Insert]
			@PermissionName varchar(100),
			@Title varchar(150),
			@IsRead bit
AS --Generated--
BEGIN

	INSERT INTO [Auth].[Permission] (

			[PermissionName],
			[Title],
			[IsRead]
	) VALUES (

			@PermissionName,
			@Title,
			@IsRead
	)

	SELECT CAST(SCOPE_IDENTITY() AS int) AS [PermissionId]
END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[Permission_List]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[Permission_List]

GO--

CREATE PROCEDURE [Auth].[Permission_List] 
			@Title varchar(150) = NULL
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
		[PermissionId] as [ListKey],
		[Title] AS [ListLabel]			
	FROM	[Auth].[Permission]
	WHERE	(@Title IS NULL OR [Title] LIKE '%' + @Title + '%')
	ORDER BY [ListLabel] ASC

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[Permission_Search]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[Permission_Search]

GO--

CREATE PROCEDURE [Auth].[Permission_Search] 
			@PermissionName varchar(100) = NULL,
			@Title varchar(150) = NULL
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[PermissionId],
			[PermissionName],
			[Title],
			[IsRead]
	FROM	[Auth].[Permission]
	WHERE	(@PermissionName IS NULL OR [PermissionName] LIKE '%' + @PermissionName + '%')
			AND (@Title IS NULL OR [Title] LIKE '%' + @Title + '%')

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[Permission_SelectAll]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[Permission_SelectAll]

GO--

CREATE PROCEDURE [Auth].[Permission_SelectAll]
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[PermissionId],
			[PermissionName],
			[Title],
			[IsRead]
	FROM	[Auth].[Permission]

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[Permission_SelectBy_PermissionId]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[Permission_SelectBy_PermissionId]

GO--

CREATE PROCEDURE [Auth].[Permission_SelectBy_PermissionId] 
			@PermissionId int
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[PermissionId],
			[PermissionName],
			[Title],
			[IsRead]
	FROM	[Auth].[Permission]
	WHERE	[PermissionId] = @PermissionId

END
GO--
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
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[Permission_Update]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[Permission_Update]

GO--

CREATE PROCEDURE [Auth].[Permission_Update] 
			@PermissionId int,
			@PermissionName varchar(100),
			@Title varchar(150),
			@IsRead bit
AS --Generated--
BEGIN

	UPDATE	[Auth].[Permission] SET 
			[PermissionName] = @PermissionName,
			[Title] = @Title,
			[IsRead] = @IsRead
	WHERE	[PermissionId] = @PermissionId

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[Role_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[Role_Delete]

GO--

CREATE PROCEDURE [Auth].[Role_Delete] 
			@RoleId int
AS --Generated--
BEGIN

	DELETE FROM	[Auth].[Role]
	WHERE	[RoleId] = @RoleId

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[Role_Exists]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[Role_Exists]

GO--

CREATE PROCEDURE [Auth].[Role_Exists]
			@RoleId int
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	IF EXISTS(
		SELECT * FROM [Auth].[Role]
		WHERE	[RoleId] = @RoleId
	) BEGIN
		SELECT CAST(1 as bit) as [Exists]
	END ELSE BEGIN
		SELECT CAST(0 as bit) as [Exists]
	END
END

GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[Role_Insert]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[Role_Insert]

GO--

CREATE PROCEDURE [Auth].[Role_Insert]
			@Title varchar(50),
			@Description varchar(max),
			@IsActive bit,
			@ApplyToAnon bit,
			@ApplyToAllUsers bit,
			@PreventAddingUsers bit,
			@WINSID varchar(50) = NULL
AS --Generated--
BEGIN

	INSERT INTO [Auth].[Role] (

			[Title],
			[Description],
			[IsActive],
			[ApplyToAnon],
			[ApplyToAllUsers],
			[PreventAddingUsers],
			[WINSID]
	) VALUES (

			@Title,
			@Description,
			@IsActive,
			@ApplyToAnon,
			@ApplyToAllUsers,
			@PreventAddingUsers,
			@WINSID
	)

	SELECT CAST(SCOPE_IDENTITY() AS int) AS [RoleId]
END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[Role_List]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[Role_List]

GO--

CREATE PROCEDURE [Auth].[Role_List] 
			@Title varchar(50) = NULL
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
		[RoleId] as [ListKey],
		[Title] AS [ListLabel]			
	FROM	[Auth].[Role]
	WHERE	(@Title IS NULL OR [Title] LIKE '%' + @Title + '%')
	ORDER BY [ListLabel] ASC

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[Role_Search]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[Role_Search]

GO--

CREATE PROCEDURE [Auth].[Role_Search] 
			@Title varchar(50) = NULL,
			@Description varchar(max) = NULL,
			@WINSID varchar(50) = NULL
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[RoleId],
			[Title],
			[Description],
			[IsActive],
			[ApplyToAnon],
			[ApplyToAllUsers],
			[PreventAddingUsers],
			[WINSID]
	FROM	[Auth].[Role]
	WHERE	(@Title IS NULL OR [Title] LIKE '%' + @Title + '%')
			AND (@Description IS NULL OR [Description] LIKE '%' + @Description + '%')
			AND (@WINSID IS NULL OR [WINSID] LIKE '%' + @WINSID + '%')

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[Role_SelectAll]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[Role_SelectAll]

GO--

CREATE PROCEDURE [Auth].[Role_SelectAll]
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[RoleId],
			[Title],
			[Description],
			[IsActive],
			[ApplyToAnon],
			[ApplyToAllUsers],
			[PreventAddingUsers],
			[WINSID]
	FROM	[Auth].[Role]

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[Role_SelectBy_RoleId]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[Role_SelectBy_RoleId]

GO--

CREATE PROCEDURE [Auth].[Role_SelectBy_RoleId] 
			@RoleId int
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[RoleId],
			[Title],
			[Description],
			[IsActive],
			[ApplyToAnon],
			[ApplyToAllUsers],
			[PreventAddingUsers],
			[WINSID]
	FROM	[Auth].[Role]
	WHERE	[RoleId] = @RoleId

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[Role_Update]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[Role_Update]

GO--

CREATE PROCEDURE [Auth].[Role_Update] 
			@RoleId int,
			@Title varchar(50),
			@Description varchar(max),
			@IsActive bit,
			@ApplyToAnon bit,
			@ApplyToAllUsers bit,
			@PreventAddingUsers bit,
			@WINSID varchar(50) = NULL
AS --Generated--
BEGIN

	UPDATE	[Auth].[Role] SET 
			[Title] = @Title,
			[Description] = @Description,
			[IsActive] = @IsActive,
			[ApplyToAnon] = @ApplyToAnon,
			[ApplyToAllUsers] = @ApplyToAllUsers,
			[PreventAddingUsers] = @PreventAddingUsers,
			[WINSID] = @WINSID
	WHERE	[RoleId] = @RoleId

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[RolePermission_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[RolePermission_Delete]

GO--

CREATE PROCEDURE [Auth].[RolePermission_Delete] 
			@RolePermissionId int
AS --Generated--
BEGIN

	DELETE FROM	[Auth].[RolePermission]
	WHERE	[RolePermissionId] = @RolePermissionId

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[RolePermission_Exists]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[RolePermission_Exists]

GO--

CREATE PROCEDURE [Auth].[RolePermission_Exists]
			@RolePermissionId int
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	IF EXISTS(
		SELECT * FROM [Auth].[RolePermission]
		WHERE	[RolePermissionId] = @RolePermissionId
	) BEGIN
		SELECT CAST(1 as bit) as [Exists]
	END ELSE BEGIN
		SELECT CAST(0 as bit) as [Exists]
	END
END

GO--
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
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[RolePermission_SelectAll]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[RolePermission_SelectAll]

GO--

CREATE PROCEDURE [Auth].[RolePermission_SelectAll]
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[RolePermissionId],
			[RoleId],
			[PermissionId]
	FROM	[Auth].[RolePermission]

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[RolePermission_SelectBy_PermissionId]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[RolePermission_SelectBy_PermissionId]

GO--

CREATE PROCEDURE [Auth].[RolePermission_SelectBy_PermissionId] 
			@PermissionId int
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[RolePermissionId],
			[RoleId],
			[PermissionId]
	FROM	[Auth].[RolePermission]
	WHERE	[PermissionId] = @PermissionId

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[RolePermission_SelectBy_RoleId]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[RolePermission_SelectBy_RoleId]

GO--

CREATE PROCEDURE [Auth].[RolePermission_SelectBy_RoleId] 
			@RoleId int
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[RolePermissionId],
			[RoleId],
			[PermissionId]
	FROM	[Auth].[RolePermission]
	WHERE	[RoleId] = @RoleId

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[RolePermission_SelectBy_RolePermissionId]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[RolePermission_SelectBy_RolePermissionId]

GO--

CREATE PROCEDURE [Auth].[RolePermission_SelectBy_RolePermissionId] 
			@RolePermissionId int
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[RolePermissionId],
			[RoleId],
			[PermissionId]
	FROM	[Auth].[RolePermission]
	WHERE	[RolePermissionId] = @RolePermissionId

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[RolePermission_Update]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[RolePermission_Update]

GO--

CREATE PROCEDURE [Auth].[RolePermission_Update] 
			@RolePermissionId int,
			@RoleId int,
			@PermissionId int
AS --Generated--
BEGIN

	UPDATE	[Auth].[RolePermission] SET 
			[RoleId] = @RoleId,
			[PermissionId] = @PermissionId
	WHERE	[RolePermissionId] = @RolePermissionId

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[TableVersion_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[TableVersion_Delete]

GO--

CREATE PROCEDURE [Auth].[TableVersion_Delete] 
			@TableId int
AS --Generated--
BEGIN

	DELETE FROM	[Auth].[TableVersion]
	WHERE	[TableId] = @TableId

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[TableVersion_Exists]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[TableVersion_Exists]

GO--

CREATE PROCEDURE [Auth].[TableVersion_Exists]
			@TableId int
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	IF EXISTS(
		SELECT * FROM [Auth].[TableVersion]
		WHERE	[TableId] = @TableId
	) BEGIN
		SELECT CAST(1 as bit) as [Exists]
	END ELSE BEGIN
		SELECT CAST(0 as bit) as [Exists]
	END
END

GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[TableVersion_Insert]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[TableVersion_Insert]

GO--

CREATE PROCEDURE [Auth].[TableVersion_Insert]
			@TableName varchar(150),
			@Version int
AS --Generated--
BEGIN

	INSERT INTO [Auth].[TableVersion] (

			[TableName],
			[Version]
	) VALUES (

			@TableName,
			@Version
	)

	SELECT CAST(SCOPE_IDENTITY() AS int) AS [TableId]
END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[TableVersion_Search]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[TableVersion_Search]

GO--

CREATE PROCEDURE [Auth].[TableVersion_Search] 
			@TableName varchar(150) = NULL
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[TableId],
			[TableName],
			[Version]
	FROM	[Auth].[TableVersion]
	WHERE	(@TableName IS NULL OR [TableName] LIKE '%' + @TableName + '%')

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[TableVersion_SelectAll]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[TableVersion_SelectAll]

GO--

CREATE PROCEDURE [Auth].[TableVersion_SelectAll]
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[TableId],
			[TableName],
			[Version]
	FROM	[Auth].[TableVersion]

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[TableVersion_SelectBy_TableId]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[TableVersion_SelectBy_TableId]

GO--

CREATE PROCEDURE [Auth].[TableVersion_SelectBy_TableId] 
			@TableId int
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[TableId],
			[TableName],
			[Version]
	FROM	[Auth].[TableVersion]
	WHERE	[TableId] = @TableId

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[TableVersion_Update]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[TableVersion_Update]

GO--

CREATE PROCEDURE [Auth].[TableVersion_Update] 
			@TableId int,
			@TableName varchar(150),
			@Version int
AS --Generated--
BEGIN

	UPDATE	[Auth].[TableVersion] SET 
			[TableName] = @TableName,
			[Version] = @Version
	WHERE	[TableId] = @TableId

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[User_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[User_Delete]

GO--

CREATE PROCEDURE [Auth].[User_Delete] 
			@UserId int
AS --Generated--
BEGIN

	DELETE FROM	[Auth].[User]
	WHERE	[UserId] = @UserId

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[User_Exists]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[User_Exists]

GO--

CREATE PROCEDURE [Auth].[User_Exists]
			@UserId int
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	IF EXISTS(
		SELECT * FROM [Auth].[User]
		WHERE	[UserId] = @UserId
	) BEGIN
		SELECT CAST(1 as bit) as [Exists]
	END ELSE BEGIN
		SELECT CAST(0 as bit) as [Exists]
	END
END

GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[User_Insert]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[User_Insert]

GO--

CREATE PROCEDURE [Auth].[User_Insert]
			@UserName varchar(50),
			@Password binary(16),
			@DisplayName varchar(50),
			@Email varchar(100),
			@AuthToken uniqueidentifier,
			@UserToken uniqueidentifier,
			@FailedLogins int,
			@IsActive bit,
			@WINSID varchar(50) = NULL
AS --Generated--
BEGIN

	INSERT INTO [Auth].[User] (

			[UserName],
			[Password],
			[DisplayName],
			[Email],
			[AuthToken],
			[UserToken],
			[FailedLogins],
			[IsActive],
			[WINSID]
	) VALUES (

			@UserName,
			@Password,
			@DisplayName,
			@Email,
			@AuthToken,
			@UserToken,
			@FailedLogins,
			@IsActive,
			@WINSID
	)

	SELECT CAST(SCOPE_IDENTITY() AS int) AS [UserId]
END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[User_List]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[User_List]

GO--

CREATE PROCEDURE [Auth].[User_List] 
			@UserName varchar(50) = NULL
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
		[UserId] as [ListKey],
		[UserName] AS [ListLabel]			
	FROM	[Auth].[User]
	WHERE	(@UserName IS NULL OR [UserName] LIKE '%' + @UserName + '%')
	ORDER BY [ListLabel] ASC

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[User_Search]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[User_Search]

GO--

CREATE PROCEDURE [Auth].[User_Search] 
			@UserName varchar(50) = NULL,
			@DisplayName varchar(50) = NULL,
			@Email varchar(100) = NULL,
			@WINSID varchar(50) = NULL
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[UserId],
			[UserName],
			[Password],
			[DisplayName],
			[Email],
			[AuthToken],
			[UserToken],
			[FailedLogins],
			[IsActive],
			[WINSID]
	FROM	[Auth].[User]
	WHERE	(@UserName IS NULL OR [UserName] LIKE '%' + @UserName + '%')
			AND (@DisplayName IS NULL OR [DisplayName] LIKE '%' + @DisplayName + '%')
			AND (@Email IS NULL OR [Email] LIKE '%' + @Email + '%')
			AND (@WINSID IS NULL OR [WINSID] LIKE '%' + @WINSID + '%')

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[User_SelectAll]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[User_SelectAll]

GO--

CREATE PROCEDURE [Auth].[User_SelectAll]
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[UserId],
			[UserName],
			[Password],
			[DisplayName],
			[Email],
			[AuthToken],
			[UserToken],
			[FailedLogins],
			[IsActive],
			[WINSID]
	FROM	[Auth].[User]

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[User_SelectBy_Email]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[User_SelectBy_Email]

GO--

CREATE PROCEDURE [Auth].[User_SelectBy_Email] 
			@Email varchar(100)
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[UserId],
			[UserName],
			[Password],
			[DisplayName],
			[Email],
			[AuthToken],
			[UserToken],
			[FailedLogins],
			[IsActive],
			[WINSID]
	FROM	[Auth].[User]
	WHERE	[Email] = @Email

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[User_SelectBy_UserId]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[User_SelectBy_UserId]

GO--

CREATE PROCEDURE [Auth].[User_SelectBy_UserId] 
			@UserId int
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[UserId],
			[UserName],
			[Password],
			[DisplayName],
			[Email],
			[AuthToken],
			[UserToken],
			[FailedLogins],
			[IsActive],
			[WINSID]
	FROM	[Auth].[User]
	WHERE	[UserId] = @UserId

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[User_SelectBy_UserName]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[User_SelectBy_UserName]

GO--

CREATE PROCEDURE [Auth].[User_SelectBy_UserName] 
			@UserName varchar(50)
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[UserId],
			[UserName],
			[Password],
			[DisplayName],
			[Email],
			[AuthToken],
			[UserToken],
			[FailedLogins],
			[IsActive],
			[WINSID]
	FROM	[Auth].[User]
	WHERE	[UserName] = @UserName

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[User_SelectBy_UserToken]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[User_SelectBy_UserToken]

GO--

CREATE PROCEDURE [Auth].[User_SelectBy_UserToken] 
			@UserToken uniqueidentifier
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[UserId],
			[UserName],
			[Password],
			[DisplayName],
			[Email],
			[AuthToken],
			[UserToken],
			[FailedLogins],
			[IsActive],
			[WINSID]
	FROM	[Auth].[User]
	WHERE	[UserToken] = @UserToken

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[User_SelectBy_WINSID]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[User_SelectBy_WINSID]

GO--

CREATE PROCEDURE [Auth].[User_SelectBy_WINSID] 
			@WINSID varchar(50)
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[UserId],
			[UserName],
			[Password],
			[DisplayName],
			[Email],
			[AuthToken],
			[UserToken],
			[FailedLogins],
			[IsActive],
			[WINSID]
	FROM	[Auth].[User]
	WHERE	[WINSID] = @WINSID

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[User_Update]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[User_Update]

GO--

CREATE PROCEDURE [Auth].[User_Update] 
			@UserId int,
			@UserName varchar(50),
			@Password binary(16),
			@DisplayName varchar(50),
			@Email varchar(100),
			@AuthToken uniqueidentifier,
			@UserToken uniqueidentifier,
			@FailedLogins int,
			@IsActive bit,
			@WINSID varchar(50) = NULL
AS --Generated--
BEGIN

	UPDATE	[Auth].[User] SET 
			[UserName] = @UserName,
			[Password] = @Password,
			[DisplayName] = @DisplayName,
			[Email] = @Email,
			[AuthToken] = @AuthToken,
			[UserToken] = @UserToken,
			[FailedLogins] = @FailedLogins,
			[IsActive] = @IsActive,
			[WINSID] = @WINSID
	WHERE	[UserId] = @UserId

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[UserRole_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[UserRole_Delete]

GO--

CREATE PROCEDURE [Auth].[UserRole_Delete] 
			@UserRoleId int
AS --Generated--
BEGIN

	DELETE FROM	[Auth].[UserRole]
	WHERE	[UserRoleId] = @UserRoleId

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[UserRole_Exists]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[UserRole_Exists]

GO--

CREATE PROCEDURE [Auth].[UserRole_Exists]
			@UserRoleId int
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	IF EXISTS(
		SELECT * FROM [Auth].[UserRole]
		WHERE	[UserRoleId] = @UserRoleId
	) BEGIN
		SELECT CAST(1 as bit) as [Exists]
	END ELSE BEGIN
		SELECT CAST(0 as bit) as [Exists]
	END
END

GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[UserRole_Insert]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[UserRole_Insert]

GO--

CREATE PROCEDURE [Auth].[UserRole_Insert]
			@UserId int,
			@RoleId int
AS --Generated--
BEGIN

	INSERT INTO [Auth].[UserRole] (

			[UserId],
			[RoleId]
	) VALUES (

			@UserId,
			@RoleId
	)

	SELECT CAST(SCOPE_IDENTITY() AS int) AS [UserRoleId]
END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[UserRole_SelectAll]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[UserRole_SelectAll]

GO--

CREATE PROCEDURE [Auth].[UserRole_SelectAll]
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[UserRoleId],
			[UserId],
			[RoleId]
	FROM	[Auth].[UserRole]

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[UserRole_SelectBy_RoleId]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[UserRole_SelectBy_RoleId]

GO--

CREATE PROCEDURE [Auth].[UserRole_SelectBy_RoleId] 
			@RoleId int
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[UserRoleId],
			[UserId],
			[RoleId]
	FROM	[Auth].[UserRole]
	WHERE	[RoleId] = @RoleId

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[UserRole_SelectBy_UserId]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[UserRole_SelectBy_UserId]

GO--

CREATE PROCEDURE [Auth].[UserRole_SelectBy_UserId] 
			@UserId int
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[UserRoleId],
			[UserId],
			[RoleId]
	FROM	[Auth].[UserRole]
	WHERE	[UserId] = @UserId

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[UserRole_SelectBy_UserRoleId]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[UserRole_SelectBy_UserRoleId]

GO--

CREATE PROCEDURE [Auth].[UserRole_SelectBy_UserRoleId] 
			@UserRoleId int
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[UserRoleId],
			[UserId],
			[RoleId]
	FROM	[Auth].[UserRole]
	WHERE	[UserRoleId] = @UserRoleId

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[UserRole_Update]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[UserRole_Update]

GO--

CREATE PROCEDURE [Auth].[UserRole_Update] 
			@UserRoleId int,
			@UserId int,
			@RoleId int
AS --Generated--
BEGIN

	UPDATE	[Auth].[UserRole] SET 
			[UserId] = @UserId,
			[RoleId] = @RoleId
	WHERE	[UserRoleId] = @UserRoleId

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Client].[TableVersion_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Client].[TableVersion_Delete]

GO--

CREATE PROCEDURE [Client].[TableVersion_Delete] 
			@TableId int
AS --Generated--
BEGIN

	DELETE FROM	[Client].[TableVersion]
	WHERE	[TableId] = @TableId

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Client].[TableVersion_Exists]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Client].[TableVersion_Exists]

GO--

CREATE PROCEDURE [Client].[TableVersion_Exists]
			@TableId int
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	IF EXISTS(
		SELECT * FROM [Client].[TableVersion]
		WHERE	[TableId] = @TableId
	) BEGIN
		SELECT CAST(1 as bit) as [Exists]
	END ELSE BEGIN
		SELECT CAST(0 as bit) as [Exists]
	END
END

GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Client].[TableVersion_Insert]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Client].[TableVersion_Insert]

GO--

CREATE PROCEDURE [Client].[TableVersion_Insert]
			@TableName varchar(150),
			@Version int
AS --Generated--
BEGIN

	INSERT INTO [Client].[TableVersion] (

			[TableName],
			[Version]
	) VALUES (

			@TableName,
			@Version
	)

	SELECT CAST(SCOPE_IDENTITY() AS int) AS [TableId]
END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Client].[TableVersion_Search]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Client].[TableVersion_Search]

GO--

CREATE PROCEDURE [Client].[TableVersion_Search] 
			@TableName varchar(150) = NULL
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[TableId],
			[TableName],
			[Version]
	FROM	[Client].[TableVersion]
	WHERE	(@TableName IS NULL OR [TableName] LIKE '%' + @TableName + '%')

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Client].[TableVersion_SelectAll]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Client].[TableVersion_SelectAll]

GO--

CREATE PROCEDURE [Client].[TableVersion_SelectAll]
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[TableId],
			[TableName],
			[Version]
	FROM	[Client].[TableVersion]

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Client].[TableVersion_SelectBy_TableId]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Client].[TableVersion_SelectBy_TableId]

GO--

CREATE PROCEDURE [Client].[TableVersion_SelectBy_TableId] 
			@TableId int
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[TableId],
			[TableName],
			[Version]
	FROM	[Client].[TableVersion]
	WHERE	[TableId] = @TableId

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Client].[TableVersion_Update]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Client].[TableVersion_Update]

GO--

CREATE PROCEDURE [Client].[TableVersion_Update] 
			@TableId int,
			@TableName varchar(150),
			@Version int
AS --Generated--
BEGIN

	UPDATE	[Client].[TableVersion] SET 
			[TableName] = @TableName,
			[Version] = @Version
	WHERE	[TableId] = @TableId

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Client].[Users_Exists]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Client].[Users_Exists]

GO--

CREATE PROCEDURE [Client].[Users_Exists]
			@UserId int
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	IF EXISTS(
		SELECT * FROM [Client].[Users]
		WHERE	[UserId] = @UserId
	) BEGIN
		SELECT CAST(1 as bit) as [Exists]
	END ELSE BEGIN
		SELECT CAST(0 as bit) as [Exists]
	END
END

GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Client].[Users_Search]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Client].[Users_Search]

GO--

CREATE PROCEDURE [Client].[Users_Search] 
			@DisplayName varchar(50) = NULL
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[UserId],
			[DisplayName]
	FROM	[Client].[Users]
	WHERE	(@DisplayName IS NULL OR [DisplayName] LIKE '%' + @DisplayName + '%')

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Client].[Users_SelectAll]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Client].[Users_SelectAll]

GO--

CREATE PROCEDURE [Client].[Users_SelectAll]
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[UserId],
			[DisplayName]
	FROM	[Client].[Users]

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Client].[Users_SelectByUser_Current]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Client].[Users_SelectByUser_Current]

GO--

CREATE PROCEDURE [Client].[Users_SelectByUser_Current]
	@AuthUserId int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT	*
	FROM	[Client].[Users]
	WHERE	[UserId] = @AuthUserId

END
GO--
IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Client].[Users_SelectByUser_UpdateProfile]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Client].[Users_SelectByUser_UpdateProfile]

GO--

CREATE PROCEDURE [Client].[Users_SelectByUser_UpdateProfile]
	@AuthUserId int,
	@DisplayName varchar(50),
	@Email varchar(100)
AS
BEGIN
	SET NOCOUNT ON;

	if( LEN(@DisplayName) <= 1 ) SET @DisplayName = 'My Name Is Invaid';


	UPDATE [Auth].[User] SET
	[DisplayName] = @DisplayName,
	[Email] = @Email
	WHERE	[UserId] = @AuthUserId


	SELECT	*
	FROM	[Client].[Users]
	WHERE	[UserId] = @AuthUserId

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Data].[BinaryData_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Data].[BinaryData_Delete]

GO--

CREATE PROCEDURE [Data].[BinaryData_Delete] 
			@BinaryDataId int
AS --Generated--
BEGIN

	DELETE FROM	[Data].[BinaryData]
	WHERE	[BinaryDataId] = @BinaryDataId

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Data].[BinaryData_Exists]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Data].[BinaryData_Exists]

GO--

CREATE PROCEDURE [Data].[BinaryData_Exists]
			@BinaryDataId int
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	IF EXISTS(
		SELECT * FROM [Data].[BinaryData]
		WHERE	[BinaryDataId] = @BinaryDataId
	) BEGIN
		SELECT CAST(1 as bit) as [Exists]
	END ELSE BEGIN
		SELECT CAST(0 as bit) as [Exists]
	END
END

GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Data].[BinaryData_Insert]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Data].[BinaryData_Insert]

GO--

CREATE PROCEDURE [Data].[BinaryData_Insert]
			@DataType varchar(50),
			@Hash varchar(64) = NULL,
			@Data varbinary(max),
			@DateCreated datetime
AS --Generated--
BEGIN

	INSERT INTO [Data].[BinaryData] (

			[DataType],
			[Hash],
			[Data],
			[DateCreated]
	) VALUES (

			@DataType,
			@Hash,
			@Data,
			@DateCreated
	)

	SELECT CAST(SCOPE_IDENTITY() AS int) AS [BinaryDataId]
END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Data].[BinaryData_Search]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Data].[BinaryData_Search]

GO--

CREATE PROCEDURE [Data].[BinaryData_Search] 
			@DataType varchar(50) = NULL,
			@Hash varchar(64) = NULL
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[BinaryDataId],
			[DataType],
			[Hash],
			[Data],
			[DateCreated]
	FROM	[Data].[BinaryData]
	WHERE	(@DataType IS NULL OR [DataType] LIKE '%' + @DataType + '%')
			AND (@Hash IS NULL OR [Hash] LIKE '%' + @Hash + '%')

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Data].[BinaryData_SelectAll]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Data].[BinaryData_SelectAll]

GO--

CREATE PROCEDURE [Data].[BinaryData_SelectAll]
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[BinaryDataId],
			[DataType],
			[Hash],
			[Data],
			[DateCreated]
	FROM	[Data].[BinaryData]

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Data].[BinaryData_SelectBy_BinaryDataId]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Data].[BinaryData_SelectBy_BinaryDataId]

GO--

CREATE PROCEDURE [Data].[BinaryData_SelectBy_BinaryDataId] 
			@BinaryDataId int
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[BinaryDataId],
			[DataType],
			[Hash],
			[Data],
			[DateCreated]
	FROM	[Data].[BinaryData]
	WHERE	[BinaryDataId] = @BinaryDataId

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Data].[BinaryData_SelectBy_Hash]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Data].[BinaryData_SelectBy_Hash]

GO--

CREATE PROCEDURE [Data].[BinaryData_SelectBy_Hash] 
			@Hash varchar(64)
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[BinaryDataId],
			[DataType],
			[Hash],
			[Data],
			[DateCreated]
	FROM	[Data].[BinaryData]
	WHERE	[Hash] = @Hash

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Data].[BinaryData_Update]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Data].[BinaryData_Update]

GO--

CREATE PROCEDURE [Data].[BinaryData_Update] 
			@BinaryDataId int,
			@DataType varchar(50),
			@Hash varchar(64) = NULL,
			@Data varbinary(max),
			@DateCreated datetime
AS --Generated--
BEGIN

	UPDATE	[Data].[BinaryData] SET 
			[DataType] = @DataType,
			[Hash] = @Hash,
			[Data] = @Data,
			[DateCreated] = @DateCreated
	WHERE	[BinaryDataId] = @BinaryDataId

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Data].[BinaryDataMoniker_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Data].[BinaryDataMoniker_Delete]

GO--

CREATE PROCEDURE [Data].[BinaryDataMoniker_Delete] 
			@BinaryDataMonikerId int
AS --Generated--
BEGIN

	DELETE FROM	[Data].[BinaryDataMoniker]
	WHERE	[BinaryDataMonikerId] = @BinaryDataMonikerId

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Data].[BinaryDataMoniker_Exists]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Data].[BinaryDataMoniker_Exists]

GO--

CREATE PROCEDURE [Data].[BinaryDataMoniker_Exists]
			@BinaryDataMonikerId int
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	IF EXISTS(
		SELECT * FROM [Data].[BinaryDataMoniker]
		WHERE	[BinaryDataMonikerId] = @BinaryDataMonikerId
	) BEGIN
		SELECT CAST(1 as bit) as [Exists]
	END ELSE BEGIN
		SELECT CAST(0 as bit) as [Exists]
	END
END

GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Data].[BinaryDataMoniker_Insert]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Data].[BinaryDataMoniker_Insert]

GO--

CREATE PROCEDURE [Data].[BinaryDataMoniker_Insert]
			@BinaryDataId int,
			@MonikerId int
AS --Generated--
BEGIN

	INSERT INTO [Data].[BinaryDataMoniker] (

			[BinaryDataId],
			[MonikerId]
	) VALUES (

			@BinaryDataId,
			@MonikerId
	)

	SELECT CAST(SCOPE_IDENTITY() AS int) AS [BinaryDataMonikerId]
END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Data].[BinaryDataMoniker_SelectAll]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Data].[BinaryDataMoniker_SelectAll]

GO--

CREATE PROCEDURE [Data].[BinaryDataMoniker_SelectAll]
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[BinaryDataMonikerId],
			[BinaryDataId],
			[MonikerId]
	FROM	[Data].[BinaryDataMoniker]

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Data].[BinaryDataMoniker_SelectBy_BinaryDataId]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Data].[BinaryDataMoniker_SelectBy_BinaryDataId]

GO--

CREATE PROCEDURE [Data].[BinaryDataMoniker_SelectBy_BinaryDataId] 
			@BinaryDataId int
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[BinaryDataMonikerId],
			[BinaryDataId],
			[MonikerId]
	FROM	[Data].[BinaryDataMoniker]
	WHERE	[BinaryDataId] = @BinaryDataId

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Data].[BinaryDataMoniker_SelectBy_BinaryDataMonikerId]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Data].[BinaryDataMoniker_SelectBy_BinaryDataMonikerId]

GO--

CREATE PROCEDURE [Data].[BinaryDataMoniker_SelectBy_BinaryDataMonikerId] 
			@BinaryDataMonikerId int
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[BinaryDataMonikerId],
			[BinaryDataId],
			[MonikerId]
	FROM	[Data].[BinaryDataMoniker]
	WHERE	[BinaryDataMonikerId] = @BinaryDataMonikerId

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Data].[BinaryDataMoniker_SelectBy_MonikerId]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Data].[BinaryDataMoniker_SelectBy_MonikerId]

GO--

CREATE PROCEDURE [Data].[BinaryDataMoniker_SelectBy_MonikerId] 
			@MonikerId int
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[BinaryDataMonikerId],
			[BinaryDataId],
			[MonikerId]
	FROM	[Data].[BinaryDataMoniker]
	WHERE	[MonikerId] = @MonikerId

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Data].[BinaryDataMoniker_Update]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Data].[BinaryDataMoniker_Update]

GO--

CREATE PROCEDURE [Data].[BinaryDataMoniker_Update] 
			@BinaryDataMonikerId int,
			@BinaryDataId int,
			@MonikerId int
AS --Generated--
BEGIN

	UPDATE	[Data].[BinaryDataMoniker] SET 
			[BinaryDataId] = @BinaryDataId,
			[MonikerId] = @MonikerId
	WHERE	[BinaryDataMonikerId] = @BinaryDataMonikerId

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Data].[Log_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Data].[Log_Delete]

GO--

CREATE PROCEDURE [Data].[Log_Delete] 
			@LogId int
AS --Generated--
BEGIN

	DELETE FROM	[Data].[Log]
	WHERE	[LogId] = @LogId

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Data].[Log_Exists]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Data].[Log_Exists]

GO--

CREATE PROCEDURE [Data].[Log_Exists]
			@LogId int
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	IF EXISTS(
		SELECT * FROM [Data].[Log]
		WHERE	[LogId] = @LogId
	) BEGIN
		SELECT CAST(1 as bit) as [Exists]
	END ELSE BEGIN
		SELECT CAST(0 as bit) as [Exists]
	END
END

GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Data].[Log_Insert]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Data].[Log_Insert]

GO--

CREATE PROCEDURE [Data].[Log_Insert]
			@RunOnMachineName varchar(50),
			@LogContents varchar(max),
			@RunTime datetime
AS --Generated--
BEGIN

	INSERT INTO [Data].[Log] (

			[RunOnMachineName],
			[LogContents],
			[RunTime]
	) VALUES (

			@RunOnMachineName,
			@LogContents,
			@RunTime
	)

	SELECT CAST(SCOPE_IDENTITY() AS int) AS [LogId]
END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Data].[Log_Search]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Data].[Log_Search]

GO--

CREATE PROCEDURE [Data].[Log_Search] 
			@RunOnMachineName varchar(50) = NULL,
			@LogContents varchar(max) = NULL
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[LogId],
			[RunOnMachineName],
			[LogContents],
			[RunTime]
	FROM	[Data].[Log]
	WHERE	(@RunOnMachineName IS NULL OR [RunOnMachineName] LIKE '%' + @RunOnMachineName + '%')
			AND (@LogContents IS NULL OR [LogContents] LIKE '%' + @LogContents + '%')

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Data].[Log_SelectAll]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Data].[Log_SelectAll]

GO--

CREATE PROCEDURE [Data].[Log_SelectAll]
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[LogId],
			[RunOnMachineName],
			[LogContents],
			[RunTime]
	FROM	[Data].[Log]

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Data].[Log_SelectBy_LogId]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Data].[Log_SelectBy_LogId]

GO--

CREATE PROCEDURE [Data].[Log_SelectBy_LogId] 
			@LogId int
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[LogId],
			[RunOnMachineName],
			[LogContents],
			[RunTime]
	FROM	[Data].[Log]
	WHERE	[LogId] = @LogId

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Data].[Log_Update]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Data].[Log_Update]

GO--

CREATE PROCEDURE [Data].[Log_Update] 
			@LogId int,
			@RunOnMachineName varchar(50),
			@LogContents varchar(max),
			@RunTime datetime
AS --Generated--
BEGIN

	UPDATE	[Data].[Log] SET 
			[RunOnMachineName] = @RunOnMachineName,
			[LogContents] = @LogContents,
			[RunTime] = @RunTime
	WHERE	[LogId] = @LogId

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Data].[Moniker_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Data].[Moniker_Delete]

GO--

CREATE PROCEDURE [Data].[Moniker_Delete] 
			@MonikerId int
AS --Generated--
BEGIN

	DELETE FROM	[Data].[Moniker]
	WHERE	[MonikerId] = @MonikerId

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Data].[Moniker_Exists]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Data].[Moniker_Exists]

GO--

CREATE PROCEDURE [Data].[Moniker_Exists]
			@MonikerId int
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	IF EXISTS(
		SELECT * FROM [Data].[Moniker]
		WHERE	[MonikerId] = @MonikerId
	) BEGIN
		SELECT CAST(1 as bit) as [Exists]
	END ELSE BEGIN
		SELECT CAST(0 as bit) as [Exists]
	END
END

GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Data].[Moniker_Insert]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Data].[Moniker_Insert]

GO--

CREATE PROCEDURE [Data].[Moniker_Insert]
			@Text varchar(200),
			@AliasForMoniker int,
			@DateCreated datetime
AS --Generated--
BEGIN

	INSERT INTO [Data].[Moniker] (

			[Text],
			[AliasForMoniker],
			[DateCreated]
	) VALUES (

			@Text,
			@AliasForMoniker,
			@DateCreated
	)

	SELECT CAST(SCOPE_IDENTITY() AS int) AS [MonikerId]
END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Data].[Moniker_Search]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Data].[Moniker_Search]

GO--

CREATE PROCEDURE [Data].[Moniker_Search] 
			@Text varchar(200) = NULL
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[MonikerId],
			[Text],
			[AliasForMoniker],
			[DateCreated]
	FROM	[Data].[Moniker]
	WHERE	(@Text IS NULL OR [Text] LIKE '%' + @Text + '%')

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Data].[Moniker_SelectAll]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Data].[Moniker_SelectAll]

GO--

CREATE PROCEDURE [Data].[Moniker_SelectAll]
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[MonikerId],
			[Text],
			[AliasForMoniker],
			[DateCreated]
	FROM	[Data].[Moniker]

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Data].[Moniker_SelectBy_MonikerId]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Data].[Moniker_SelectBy_MonikerId]

GO--

CREATE PROCEDURE [Data].[Moniker_SelectBy_MonikerId] 
			@MonikerId int
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[MonikerId],
			[Text],
			[AliasForMoniker],
			[DateCreated]
	FROM	[Data].[Moniker]
	WHERE	[MonikerId] = @MonikerId

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Data].[Moniker_SelectBy_Text]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Data].[Moniker_SelectBy_Text]

GO--

CREATE PROCEDURE [Data].[Moniker_SelectBy_Text] 
			@Text varchar(200)
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[MonikerId],
			[Text],
			[AliasForMoniker],
			[DateCreated]
	FROM	[Data].[Moniker]
	WHERE	[Text] = @Text

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Data].[Moniker_Update]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Data].[Moniker_Update]

GO--

CREATE PROCEDURE [Data].[Moniker_Update] 
			@MonikerId int,
			@Text varchar(200),
			@AliasForMoniker int,
			@DateCreated datetime
AS --Generated--
BEGIN

	UPDATE	[Data].[Moniker] SET 
			[Text] = @Text,
			[AliasForMoniker] = @AliasForMoniker,
			[DateCreated] = @DateCreated
	WHERE	[MonikerId] = @MonikerId

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Data].[Query_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Data].[Query_Delete]

GO--

CREATE PROCEDURE [Data].[Query_Delete] 
			@QueryId int
AS --Generated--
BEGIN

	DELETE FROM	[Data].[Query]
	WHERE	[QueryId] = @QueryId

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Data].[Query_Exists]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Data].[Query_Exists]

GO--

CREATE PROCEDURE [Data].[Query_Exists]
			@QueryId int
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	IF EXISTS(
		SELECT * FROM [Data].[Query]
		WHERE	[QueryId] = @QueryId
	) BEGIN
		SELECT CAST(1 as bit) as [Exists]
	END ELSE BEGIN
		SELECT CAST(0 as bit) as [Exists]
	END
END

GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Data].[Query_Insert]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Data].[Query_Insert]

GO--

CREATE PROCEDURE [Data].[Query_Insert]
			@Text varchar(max),
			@PoviderSource varchar(max) = NULL,
			@ProcessorUsed varchar(max) = NULL,
			@Exceptions varchar(max) = NULL,
			@IsSuccess bit
AS --Generated--
BEGIN

	INSERT INTO [Data].[Query] (

			[Text],
			[PoviderSource],
			[ProcessorUsed],
			[Exceptions],
			[IsSuccess]
	) VALUES (

			@Text,
			@PoviderSource,
			@ProcessorUsed,
			@Exceptions,
			@IsSuccess
	)

	SELECT CAST(SCOPE_IDENTITY() AS int) AS [QueryId]
END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Data].[Query_Search]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Data].[Query_Search]

GO--

CREATE PROCEDURE [Data].[Query_Search] 
			@Text varchar(max) = NULL,
			@PoviderSource varchar(max) = NULL,
			@ProcessorUsed varchar(max) = NULL,
			@Exceptions varchar(max) = NULL
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[QueryId],
			[Text],
			[PoviderSource],
			[ProcessorUsed],
			[Exceptions],
			[IsSuccess]
	FROM	[Data].[Query]
	WHERE	(@Text IS NULL OR [Text] LIKE '%' + @Text + '%')
			AND (@PoviderSource IS NULL OR [PoviderSource] LIKE '%' + @PoviderSource + '%')
			AND (@ProcessorUsed IS NULL OR [ProcessorUsed] LIKE '%' + @ProcessorUsed + '%')
			AND (@Exceptions IS NULL OR [Exceptions] LIKE '%' + @Exceptions + '%')

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Data].[Query_SelectAll]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Data].[Query_SelectAll]

GO--

CREATE PROCEDURE [Data].[Query_SelectAll]
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[QueryId],
			[Text],
			[PoviderSource],
			[ProcessorUsed],
			[Exceptions],
			[IsSuccess]
	FROM	[Data].[Query]

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Data].[Query_SelectBy_QueryId]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Data].[Query_SelectBy_QueryId]

GO--

CREATE PROCEDURE [Data].[Query_SelectBy_QueryId] 
			@QueryId int
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[QueryId],
			[Text],
			[PoviderSource],
			[ProcessorUsed],
			[Exceptions],
			[IsSuccess]
	FROM	[Data].[Query]
	WHERE	[QueryId] = @QueryId

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Data].[Query_Update]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Data].[Query_Update]

GO--

CREATE PROCEDURE [Data].[Query_Update] 
			@QueryId int,
			@Text varchar(max),
			@PoviderSource varchar(max) = NULL,
			@ProcessorUsed varchar(max) = NULL,
			@Exceptions varchar(max) = NULL,
			@IsSuccess bit
AS --Generated--
BEGIN

	UPDATE	[Data].[Query] SET 
			[Text] = @Text,
			[PoviderSource] = @PoviderSource,
			[ProcessorUsed] = @ProcessorUsed,
			[Exceptions] = @Exceptions,
			[IsSuccess] = @IsSuccess
	WHERE	[QueryId] = @QueryId

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Data].[TableVersion_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Data].[TableVersion_Delete]

GO--

CREATE PROCEDURE [Data].[TableVersion_Delete] 
			@TableId int
AS --Generated--
BEGIN

	DELETE FROM	[Data].[TableVersion]
	WHERE	[TableId] = @TableId

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Data].[TableVersion_Exists]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Data].[TableVersion_Exists]

GO--

CREATE PROCEDURE [Data].[TableVersion_Exists]
			@TableId int
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	IF EXISTS(
		SELECT * FROM [Data].[TableVersion]
		WHERE	[TableId] = @TableId
	) BEGIN
		SELECT CAST(1 as bit) as [Exists]
	END ELSE BEGIN
		SELECT CAST(0 as bit) as [Exists]
	END
END

GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Data].[TableVersion_Insert]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Data].[TableVersion_Insert]

GO--

CREATE PROCEDURE [Data].[TableVersion_Insert]
			@TableName varchar(150),
			@Version int
AS --Generated--
BEGIN

	INSERT INTO [Data].[TableVersion] (

			[TableName],
			[Version]
	) VALUES (

			@TableName,
			@Version
	)

	SELECT CAST(SCOPE_IDENTITY() AS int) AS [TableId]
END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Data].[TableVersion_Search]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Data].[TableVersion_Search]

GO--

CREATE PROCEDURE [Data].[TableVersion_Search] 
			@TableName varchar(150) = NULL
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[TableId],
			[TableName],
			[Version]
	FROM	[Data].[TableVersion]
	WHERE	(@TableName IS NULL OR [TableName] LIKE '%' + @TableName + '%')

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Data].[TableVersion_SelectAll]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Data].[TableVersion_SelectAll]

GO--

CREATE PROCEDURE [Data].[TableVersion_SelectAll]
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[TableId],
			[TableName],
			[Version]
	FROM	[Data].[TableVersion]

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Data].[TableVersion_SelectBy_TableId]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Data].[TableVersion_SelectBy_TableId]

GO--

CREATE PROCEDURE [Data].[TableVersion_SelectBy_TableId] 
			@TableId int
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[TableId],
			[TableName],
			[Version]
	FROM	[Data].[TableVersion]
	WHERE	[TableId] = @TableId

END
GO--
-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Data].[TableVersion_Update]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Data].[TableVersion_Update]

GO--

CREATE PROCEDURE [Data].[TableVersion_Update] 
			@TableId int,
			@TableName varchar(150),
			@Version int
AS --Generated--
BEGIN

	UPDATE	[Data].[TableVersion] SET 
			[TableName] = @TableName,
			[Version] = @Version
	WHERE	[TableId] = @TableId

END
GO--

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
GO--

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Client].[Users_SelectByUser_Current]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Client].[Users_SelectByUser_Current]

GO--

CREATE PROCEDURE [Client].[Users_SelectByUser_Current]
	@AuthUserId int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT	*
	FROM	[Client].[Users]
	WHERE	[UserId] = @AuthUserId

END
GO--

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Client].[Users_SelectByUser_UpdateProfile]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Client].[Users_SelectByUser_UpdateProfile]

GO--

CREATE PROCEDURE [Client].[Users_SelectByUser_UpdateProfile]
	@AuthUserId int,
	@DisplayName varchar(50),
	@Email varchar(100)
AS
BEGIN
	SET NOCOUNT ON;

	if( LEN(@DisplayName) <= 1 ) SET @DisplayName = 'My Name Is Invaid';


	UPDATE [Auth].[User] SET
	[DisplayName] = @DisplayName,
	[Email] = @Email
	WHERE	[UserId] = @AuthUserId


	SELECT	*
	FROM	[Client].[Users]
	WHERE	[UserId] = @AuthUserId

END
GO--
CREATE NONCLUSTERED INDEX [IX_User_UserName] 
	ON [Auth].[User] ([UserName])
CREATE NONCLUSTERED INDEX [IX_User_Email] 
	ON [Auth].[User] ([Email])
CREATE NONCLUSTERED INDEX [IX_User_UserToken] 
	ON [Auth].[User] ([UserToken])
CREATE NONCLUSTERED INDEX [IX_User_WINSID] 
	ON [Auth].[User] ([WINSID])

GO--
CREATE UNIQUE NONCLUSTERED INDEX [IX_BinaryData_Hash] 
	ON [Data].[BinaryData] ([Hash])

GO--
CREATE UNIQUE NONCLUSTERED INDEX [IX_Moniker_Text] 
	ON [Data].[Moniker] ([Text])

GO--
ALTER TABLE [Auth].[RolePermission]
ADD	CONSTRAINT [FK_RolePermission_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Auth].[Role] ([RoleId])
,	CONSTRAINT [FK_RolePermission_PermissionId] FOREIGN KEY ([PermissionId]) REFERENCES [Auth].[Permission] ([PermissionId])

GO--
ALTER TABLE [Auth].[UserRole]
ADD	CONSTRAINT [FK_UserRole_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Auth].[Role] ([RoleId])
,	CONSTRAINT [FK_UserRole_UserId] FOREIGN KEY ([UserId]) REFERENCES [Auth].[User] ([UserId])

GO--
ALTER TABLE [Data].[BinaryDataMoniker]
ADD	CONSTRAINT [FK_Data_BinaryDataMoniker_BinaryDataId] FOREIGN KEY ([BinaryDataId]) REFERENCES [Data].[BinaryData] ([BinaryDataId])

,	CONSTRAINT [FK_Data_BinaryDataMoniker_MonikerId] FOREIGN KEY ([MonikerId]) REFERENCES [Data].[Moniker] ([MonikerId])


GO--
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
GO--
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
GO--
IF NOT EXISTS(SELECT * FROM [Auth].[Permission] WHERE [PermissionName] = 'Client_Users_SelectByUser_Current' )
	INSERT INTO [Auth].[Permission] ([PermissionName],[Title],[IsRead]) VALUES ('Client_Users_SelectByUser_Current', 'Client Users SelectByUser Current',1);
IF NOT EXISTS(SELECT * FROM [Auth].[Permission] WHERE [PermissionName] = 'Client_Users_SelectByUser_UpdateProfile' )
	INSERT INTO [Auth].[Permission] ([PermissionName],[Title],[IsRead]) VALUES ('Client_Users_SelectByUser_UpdateProfile', 'Client Users SelectByUser UpdateProfile',1);
IF NOT EXISTS(SELECT * FROM [Auth].[Permission] WHERE [PermissionName] = 'Client_Users_Exists' )
	INSERT INTO [Auth].[Permission] ([PermissionName],[Title],[IsRead]) VALUES ('Client_Users_Exists', 'Client Users Exists',1);
IF NOT EXISTS(SELECT * FROM [Auth].[Permission] WHERE [PermissionName] = 'Client_Users_Search' )
	INSERT INTO [Auth].[Permission] ([PermissionName],[Title],[IsRead]) VALUES ('Client_Users_Search', 'Client Users Search',1);
IF NOT EXISTS(SELECT * FROM [Auth].[Permission] WHERE [PermissionName] = 'Client_Users_SelectAll' )
	INSERT INTO [Auth].[Permission] ([PermissionName],[Title],[IsRead]) VALUES ('Client_Users_SelectAll', 'Client Users SelectAll',1);

GO--
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

GO--
