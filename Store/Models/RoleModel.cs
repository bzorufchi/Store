namespace Store.Models
{
    public class GetAllRoleOutput
    {
       
        public string RoleName { get; set; }
        public DateTime CreateDate { get; set; }
    }
    public class AddRoleInput
    {
        
        public string RoleName { get; set; }
        public DateTime CreateDate { get; set; }
    }
    public class UpdateRoleInput
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public DateTime CreateDate { get; set; }
    }
    public class DeleteRole
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
