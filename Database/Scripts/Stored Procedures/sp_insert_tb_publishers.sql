USE DBMyFellowGamer
GO
CREATE PROCEDURE sp_insert_tb_publishers
	@publisherName NVARCHAR(200),
	@creationDate DATETIME
AS
	SET @creationDate = GetDate();

	INSERT INTO Tb_Publishers (PublisherName, CreationDate)
	VALUES (@publisherName, @creationDate);
GO

