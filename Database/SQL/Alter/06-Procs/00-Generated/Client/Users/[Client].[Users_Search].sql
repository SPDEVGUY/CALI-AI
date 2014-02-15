-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Client].[Users_Search]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Client].[Users_Search]
GO--
CREATE PROCEDURE [Client].[Users_Search] 
			@DisplayName varchar(50) = NULL
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[UserId],
			[DisplayName]
	FROM	[Client].[Users]
	WHERE	(@DisplayName IS NULL OR [DisplayName] LIKE '%' + @DisplayName + '%')

END