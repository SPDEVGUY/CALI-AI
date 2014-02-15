

-- This script drops the SQL login created by the scripts.
DECLARE @DatabaseName as nvarchar(30); SET @DatabaseName = 'CALI';
DECLARE @AccountName as nvarchar(30);  SET @AccountName = '$AccountName';
DECLARE @UseWindowsAuth as bit; SET @UseWindowsAuth = $UseWindowsAuth;





-------------------------------------------------------------------
-- LOGIC CODE BELOW, EDIT DATABASE NAME ABOVE
-------------------------------------------------------------------

IF @UseWindowsAuth = 0 AND EXISTS (SELECT * FROM sys.server_principals WHERE name = @AccountName)
	EXEC('DROP LOGIN [' + @AccountName + ']');