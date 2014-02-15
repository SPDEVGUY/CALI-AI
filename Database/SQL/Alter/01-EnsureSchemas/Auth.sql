DECLARE @SchemaName as nvarchar(20); SET @SchemaName = 'Auth';


-------------------------------------------------------------------
-- LOGIC CODE BELOW, EDIT SCHEMA NAME ABOVE
-------------------------------------------------------------------

IF NOT EXISTS (select * FROM sys.schemas WHERE name = @SchemaName)
	BEGIN   
		EXEC('CREATE SCHEMA [' + @SchemaName + ']');
		EXEC('GRANT EXECUTE ON SCHEMA::[' + @SchemaName + '] TO db_executor');
	END