CREATE PROCEDURE [dbo].[spGuests_Insert]
	@firstName nvarchar(50),
	@lastName nvarchar(50)
AS

BEGIN

	set nocount on;

	if not exists (select 1 from dbo.Guests where FirstName = @firstName and LastName = @lastName)
	BEGIN
		INSERT INTO dbo.Guests (FirstName, LastName)
		VALUES (@firstName, @lastName);
	END

	SELECT TOP 1 [Id], [FirstName], [LastName]
	FROM dbo.Guests
	WHERE FirstName = @firstName and LastName = @lastName;

END
