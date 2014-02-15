-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[UserRole_Insert]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[UserRole_Insert]
GO--
CREATE PROCEDURE [Auth].[UserRole_Insert]
			@UserId int,
			@RoleId int
AS --Generated--
BEGIN

	INSERT INTO [Auth].[UserRole] (

			[UserId],
			[RoleId]
	) VALUES (

			@UserId,
			@RoleId
	)

	SELECT CAST(SCOPE_IDENTITY() AS int) AS [UserRoleId]
END