namespace Store.Entitis
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int CategoryParent { get; set; }
        public DateTime CreateDate { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
