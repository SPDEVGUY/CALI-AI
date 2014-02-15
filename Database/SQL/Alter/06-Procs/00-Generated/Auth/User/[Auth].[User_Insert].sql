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