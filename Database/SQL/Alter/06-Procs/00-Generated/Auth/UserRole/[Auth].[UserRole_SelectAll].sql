-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[UserRole_SelectAll]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[UserRole_SelectAll]
GO--
CREATE PROCEDURE [Auth].[UserRole_SelectAll]
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[UserRoleId],
			[UserId],
			[RoleId]
	FROM	[Auth].[UserRole]

END