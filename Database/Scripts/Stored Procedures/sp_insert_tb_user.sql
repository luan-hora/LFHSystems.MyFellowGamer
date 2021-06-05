USE DBMyFellowGamer
GO
CREATE PROCEDURE [dbo].[sp_insert_tb_user]
	@username NVARCHAR(100),
	@email NVARCHAR(100),
	@pin NVARCHAR(200),
	@termsOfUse BIT,
	@privacyPolicy BIT,
	@creationDate DATETIME
AS
	INSERT INTO [dbo].[tb_user]
	(Username, Email, PIN, TermsOfUse, PrivacyPolicy, CreationDate)
	VALUES
	(@username, @email, @pin, @TermsOfUse, @PrivacyPolicy, @CreationDate)
	
	SELECT ID FROM tb_user WHERE Username = @username