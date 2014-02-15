-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Auth].[TableVersion_Search]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Auth].[TableVersion_Search]
GO--
CREATE PROCEDURE [Auth].[TableVersion_Search] 
			@TableName varchar(150) = NULL
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[TableId],
			[TableName],
			[Version]
	FROM	[Auth].[TableVersion]
	WHERE	(@TableName IS NULL OR [TableName] LIKE '%' + @TableName + '%')

END