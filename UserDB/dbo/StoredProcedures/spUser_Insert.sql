CREATE PROCEDURE [dbo].[spUser_Insert]
    @Id int output,
	@FirstName nvarchar(50),
	@LastName nvarchar(50)
AS
begin
	insert into dbo.[User] (FirstName, LastName)
	values (@FirstName, @LastName);
	set @Id = SCOPE_IDENTITY();
end
