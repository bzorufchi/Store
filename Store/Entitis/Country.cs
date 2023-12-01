namespace Store.Entitis
{
    public class Country
    {
        public int Id { get; set; }
        public string CountryName { get; set; }=string.Empty;
        public DateTime CreateDate { get; set; }
		public int IsActive { get; set; }
		public ICollection<Country> Countries { get; set;}
    }
}
