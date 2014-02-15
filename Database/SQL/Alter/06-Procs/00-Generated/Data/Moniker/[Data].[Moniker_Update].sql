-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Data].[Moniker_Update]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Data].[Moniker_Update]
GO--
CREATE PROCEDURE [Data].[Moniker_Update] 
			@MonikerId int,
			@Text varchar(200),
			@AliasForMoniker int,
			@DateCreated datetime
AS --Generated--
BEGIN

	UPDATE	[Data].[Moniker] SET 
			[Text] = @Text,
			[AliasForMoniker] = @AliasForMoniker,
			[DateCreated] = @DateCreated
	WHERE	[MonikerId] = @MonikerId

END