USE DBMyFellowGamer
GO
CREATE PROCEDURE dbo.sp_select_tb_user
	@username NVARCHAR(200) = NULL,
	@email NVARCHAR(200) = NULL
AS

	IF @username IS NOT NULL
	BEGIN
		SELECT ID, Username, Email, PIN, TermsOfUse, PrivacyPolicy, CreationDate FROM Tb_User WHERE Username = @username;
	END

	IF @email IS NOT NULL
	BEGIN
		SELECT ID, Username, Email, PIN, TermsOfUse, PrivacyPolicy, CreationDate FROM Tb_User WHERE Email = @email;
	END