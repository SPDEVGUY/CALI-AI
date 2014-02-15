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