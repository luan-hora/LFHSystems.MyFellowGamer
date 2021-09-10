USE DBMyFellowGamer
GO
IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'Tb_User_Reviews') )
BEGIN
	CREATE TABLE Tb_User_Reviews (
		ID INT IDENTITY(1, 1),
		UserId INT NOT NULL,
		GameId INT NOT NULL,
		ReviewDescription NVARCHAR(MAX) NOT NULL,
		ReviewTags NVARCHAR(MAX) NULL,
		RatingScore DECIMAL(1, 1) NOT NULL,
		ReviewDate DATETIME NOT NULL,
	
		CONSTRAINT PK_Tb_User_Reviews PRIMARY KEY(ID),
		CONSTRAINT FK_Tb_User_Reviews_Tb_User FOREIGN KEY (UserId) REFERENCES Tb_User(ID),
		CONSTRAINT FK_Tb_User_Reviews_Tb_Games FOREIGN KEY (GameId) REFERENCES Tb_Games(ID)
	);
END;
ELSE
BEGIN
	PRINT 'Tabela já existe!';
END