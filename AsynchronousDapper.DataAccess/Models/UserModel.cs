namespace AsynchronousDapper.DataAccess.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public string? LastName { get; set; }

        // 이것을 사용할려면 new {FirstName = user.FirstName, 
        //public DateTime? InsertDate { get; set; }
        //public DateTime? UpdateDate { get; set; }

    }
}
