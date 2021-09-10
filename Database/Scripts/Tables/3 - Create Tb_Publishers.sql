USE DBMyFellowGamer
GO
IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'Tb_Publishers') )
BEGIN
	CREATE TABLE Tb_Publishers (
		ID INT IDENTITY(1, 1),
		PublisherName NVARCHAR(100) NOT NULL,
		CreationDate DATETIME NOT NULL,
		
		CONSTRAINT PK_Tb_Publishers PRIMARY KEY (ID)
	)
END
ELSE
BEGIN
	PRINT 'Tabela já existe!';
END