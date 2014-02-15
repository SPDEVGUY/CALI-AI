-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[Role_List]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[Role_List]
GO--
CREATE PROCEDURE [Auth].[Role_List] 
			@Title varchar(50) = NULL
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
		[RoleId] as [ListKey],
		[Title] AS [ListLabel]			
	FROM	[Auth].[Role]
	WHERE	(@Title IS NULL OR [Title] LIKE '%' + @Title + '%')
	ORDER BY [ListLabel] ASC

END