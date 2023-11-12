namespace Store.Entitis
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public string PeymentState { get; set; }
        public string PeymentMethod { get; set; }
        public int Count { get; set; }
        public int FixedPrice { get; set; }

        public User User { get; set; }
        public ICollection<Orders> Orders { get; set; }
    }
}
