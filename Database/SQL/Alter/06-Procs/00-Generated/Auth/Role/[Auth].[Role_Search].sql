-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[Role_Search]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[Role_Search]
GO--
CREATE PROCEDURE [Auth].[Role_Search] 
			@Title varchar(50) = NULL,
			@Description varchar(max) = NULL,
			@WINSID varchar(50) = NULL
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
	WHERE	(@Title IS NULL OR [Title] LIKE '%' + @Title + '%')
			AND (@Description IS NULL OR [Description] LIKE '%' + @Description + '%')
			AND (@WINSID IS NULL OR [WINSID] LIKE '%' + @WINSID + '%')

END