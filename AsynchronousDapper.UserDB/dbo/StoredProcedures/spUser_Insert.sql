CREATE PROCEDURE [dbo].[spUser_Insert]    
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Id int output
AS
begin
	SET NOCOUNT ON

	insert into dbo.[User] (FirstName, LastName)
	values (@FirstName, @LastName);

	set @Id = SCOPE_IDENTITY();
end
