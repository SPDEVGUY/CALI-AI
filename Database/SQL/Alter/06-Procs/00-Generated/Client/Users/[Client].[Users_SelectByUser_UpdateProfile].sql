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