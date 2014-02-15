-----------------------------------------------------------------------------------
--Do not modify this file, instead use an alter proc to over-write the procedure.--
--Make sure you follow the same expected interface of parameters, and resultsets.--
-----------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM [dbo].[sysobjects] WHERE ID=object_id(N'[Data].[Moniker_Insert]') AND OBJECTPROPERTY(id, N'IsProcedure')=1) DROP PROC [Data].[Moniker_Insert]
GO--
CREATE PROCEDURE [Data].[Moniker_Insert]
			@Text varchar(200),
			@AliasForMoniker int,
			@DateCreated datetime
AS --Generated--
BEGIN

	INSERT INTO [Data].[Moniker] (

			[Text],
			[AliasForMoniker],
			[DateCreated]
	) VALUES (

			@Text,
			@AliasForMoniker,
			@DateCreated
	)

	SELECT CAST(SCOPE_IDENTITY() AS int) AS [MonikerId]
END