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