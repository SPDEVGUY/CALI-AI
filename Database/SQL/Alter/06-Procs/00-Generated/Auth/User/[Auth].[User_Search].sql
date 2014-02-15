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