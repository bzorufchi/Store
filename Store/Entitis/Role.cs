namespace Store.Entitis
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public DateTime CreateDate { get; set; }
		public int IsActive { get; set; }
		public ICollection<User> Users { get; set;}

    }
}
