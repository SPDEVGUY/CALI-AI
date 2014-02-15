CREATE VIEW [Client].[Users] WITH SCHEMABINDING
AS
--Only return things you don't mind anyone seeing.
--Example: Protected email, usertoken, username...
SELECT [UserId]
      ,[DisplayName]
  FROM [Auth].[User]
