CREATE PROCEDURE [dbo].[spUser_Delete]
	@Id int
AS
begin
	SET NOCOUNT ON

	delete 
	from dbo.[User]
	where Id = @Id;
end
