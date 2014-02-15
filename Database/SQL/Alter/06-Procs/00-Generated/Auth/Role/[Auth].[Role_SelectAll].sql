-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[Role_SelectAll]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[Role_SelectAll]
GO--
CREATE PROCEDURE [Auth].[Role_SelectAll]
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[RoleId],
			[Title],
			[Description],
			[IsActive],
			[ApplyToAnon],
			[ApplyToAllUsers],
			[PreventAddingUsers],
			[WINSID]
	FROM	[Auth].[Role]

END