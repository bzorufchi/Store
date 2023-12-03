namespace Store.Entitis
{
    public class User
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string FirstName { get; set; }
        public string FamilyName { get; set; }
        public DateTime BirthDate { get; set; }
        public string NationalCode { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime CreateDate { get; set; }
        public string PhoneNumber { get; set; }
        public int Gender { get; set; }
		public int? IsActive { get; set; }
		public Role Role { get; set; }
        public ICollection<Comments> Comments { get; set;}
        public ICollection<ShoppingCart> shoppingCarts { get; set; }
    }
}
