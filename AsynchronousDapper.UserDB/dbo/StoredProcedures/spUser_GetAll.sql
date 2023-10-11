CREATE PROCEDURE [dbo].[spUser_GetAll]
AS
begin
	SET NOCOUNT ON

	select *
	from dbo.[User];
end
