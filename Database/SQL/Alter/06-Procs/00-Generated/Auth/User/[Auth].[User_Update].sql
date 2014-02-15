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