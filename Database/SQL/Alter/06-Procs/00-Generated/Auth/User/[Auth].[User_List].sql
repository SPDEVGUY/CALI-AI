-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[User_List]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[User_List]
GO--
CREATE PROCEDURE [Auth].[User_List] 
			@UserName varchar(50) = NULL
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
		[UserId] as [ListKey],
		[UserName] AS [ListLabel]			
	FROM	[Auth].[User]
	WHERE	(@UserName IS NULL OR [UserName] LIKE '%' + @UserName + '%')
	ORDER BY [ListLabel] ASC

END