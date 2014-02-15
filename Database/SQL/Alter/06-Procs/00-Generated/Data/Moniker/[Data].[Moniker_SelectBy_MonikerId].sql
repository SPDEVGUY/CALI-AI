-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Data].[Moniker_SelectBy_MonikerId]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Data].[Moniker_SelectBy_MonikerId]
GO--
CREATE PROCEDURE [Data].[Moniker_SelectBy_MonikerId] 
			@MonikerId int
AS --Generated--
BEGIN
	SET NOCOUNT ON;

	SELECT	
			[MonikerId],
			[Text],
			[AliasForMoniker],
			[DateCreated]
	FROM	[Data].[Moniker]
	WHERE	[MonikerId] = @MonikerId

END