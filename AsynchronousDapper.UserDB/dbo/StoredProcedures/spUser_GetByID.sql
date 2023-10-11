CREATE PROCEDURE [dbo].[spUser_GetByID]
	@Id int
AS

	select Id, FirstName, LastName
	from dbo.[User]
	where Id = @Id;


