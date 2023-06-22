USE DBMyFellowGamer
GO
CREATE PROCEDURE [dbo].[sp_delete_tb_user]
	@idUser INT
AS
	DELETE FROM [dbo].[tb_user] WHERE ID = @idUser;
	
	RETURN @@ROWCOUNT	