-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[Permission_Search]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[Permission_Search]
GO--
CREATE PROCEDURE [Auth].[Permission_Search] 
			@PermissionName varchar(100) = NULL,
			@Title varchar(150) = NULL
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[PermissionId],
			[PermissionName],
			[Title],
			[IsRead]
	FROM	[Auth].[Permission]
	WHERE	(@PermissionName IS NULL OR [PermissionName] LIKE '%' + @PermissionName + '%')
			AND (@Title IS NULL OR [Title] LIKE '%' + @Title + '%')

END