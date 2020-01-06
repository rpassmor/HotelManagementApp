CREATE PROCEDURE [dbo].[spBookings_CheckIn]

	@Id int

AS

BEGIN
SET NOCOUNT ON;

	update dbo.Bookings
	set CheckedIn = 1
	where Id = @Id;

END
