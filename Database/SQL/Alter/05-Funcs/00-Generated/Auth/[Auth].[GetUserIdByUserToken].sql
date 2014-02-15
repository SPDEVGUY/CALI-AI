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