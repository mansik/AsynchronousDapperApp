﻿CREATE PROCEDURE [dbo].[spUser_Update]
	@Id int,
	@FirstName nvarchar(50),
	@LastName nvarchar(50)
AS
begin
	SET NOCOUNT ON

	update dbo.[User]
	set FirstName = @LastName, LastName = @LastName
	where Id = @Id;
end 