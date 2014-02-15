-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[Role_Insert]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[Role_Insert]
GO--
CREATE PROCEDURE [Auth].[Role_Insert]
			@Title varchar(50),
			@Description varchar(max),
			@IsActive bit,
			@ApplyToAnon bit,
			@ApplyToAllUsers bit,
			@PreventAddingUsers bit,
			@WINSID varchar(50) = NULL
AS --Generated--
BEGIN

	INSERT INTO [Auth].[Role] (

			[Title],
			[Description],
			[IsActive],
			[ApplyToAnon],
			[ApplyToAllUsers],
			[PreventAddingUsers],
			[WINSID]
	) VALUES (

			@Title,
			@Description,
			@IsActive,
			@ApplyToAnon,
			@ApplyToAllUsers,
			@PreventAddingUsers,
			@WINSID
	)

	SELECT CAST(SCOPE_IDENTITY() AS int) AS [RoleId]
END