namespace Store.Entitis
{
    public class Brands
    {
        public int Id { get; set; }
        public string BrandName { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; }

		public int? IsActive { get; set; }
		public ICollection<Product> Products { get; set; }

    }
}
