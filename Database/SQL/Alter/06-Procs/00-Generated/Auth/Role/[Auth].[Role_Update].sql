-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[Role_Update]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[Role_Update]
GO--
CREATE PROCEDURE [Auth].[Role_Update] 
			@RoleId int,
			@Title varchar(50),
			@Description varchar(max),
			@IsActive bit,
			@ApplyToAnon bit,
			@ApplyToAllUsers bit,
			@PreventAddingUsers bit,
			@WINSID varchar(50) = NULL
AS --Generated--
BEGIN

	UPDATE	[Auth].[Role] SET 
			[Title] = @Title,
			[Description] = @Description,
			[IsActive] = @IsActive,
			[ApplyToAnon] = @ApplyToAnon,
			[ApplyToAllUsers] = @ApplyToAllUsers,
			[PreventAddingUsers] = @PreventAddingUsers,
			[WINSID] = @WINSID
	WHERE	[RoleId] = @RoleId

END