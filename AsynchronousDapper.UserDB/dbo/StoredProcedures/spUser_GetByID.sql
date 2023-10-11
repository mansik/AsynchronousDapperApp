CREATE PROCEDURE [dbo].[spUser_GetByID]
	@Id int
AS
begin
	SET NOCOUNT ON	

	select Id, FirstName, LastName
	from dbo.[User]
	where Id = @Id;
end

