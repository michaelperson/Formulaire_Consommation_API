CREATE PROCEDURE [dbo].[BFSP_DeleteContact]
	@Id int
AS
BEGIN
	DELETE FROM [Contact] WHERE Id = @Id;
	RETURN 0
END

