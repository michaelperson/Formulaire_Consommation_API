CREATE PROCEDURE [dbo].[BFSP_AddContact]
	@LastName NVARCHAR(75),
	@FirstName NVARCHAR(75),
	@Email NVARCHAR(75),
	@CategoryId INT
AS
BEGIN
	INSERT INTO [Contact] ([LastName], [FirstName], [Email], [CategoryId]) VALUES (@LastName, @FirstName, @Email, @CategoryId);
	RETURN 0
END