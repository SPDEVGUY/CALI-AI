-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[Permission_Insert]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[Permission_Insert]
GO--
CREATE PROCEDURE [Auth].[Permission_Insert]
			@PermissionName varchar(100),
			@Title varchar(150),
			@IsRead bit
AS --Generated--
BEGIN

	INSERT INTO [Auth].[Permission] (

			[PermissionName],
			[Title],
			[IsRead]
	) VALUES (

			@PermissionName,
			@Title,
			@IsRead
	)

	SELECT CAST(SCOPE_IDENTITY() AS int) AS [PermissionId]
END