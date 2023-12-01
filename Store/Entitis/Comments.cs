namespace Store.Entitis
{
    public class Comments
    {
        public int Id { get; set; }
        public int ProductId { get; set; } 
        public int UserId { get; set; }
        public string Text { get; set; }
        public int IsAccepted { get; set; }
        public DateTime IsAcceptedDate { get; set; }
        public DateTime CreateDate { get; set; }
        public int ByUserId { get; set; }
		public int IsActive { get; set; }
		public User User { get; set; }
        public Product Product { get; set; }

    }
}
