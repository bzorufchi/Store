using Store.Entitis;

namespace Store.Models
{
    public class GetAllCountruOutput
    {
       public int Id { get; set; }
        public string CountryName { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; }
		public int IsActive { get; set; }

	}
    public class AddCountryInput
    {
       
        public string CountryName { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; }
		public int IsActive { get; set; }

	}
    public class UpdateCountryInput
    {
        public int Id { get; set; }
        public string CountryName { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; }
		public int IsActive { get; set; }

	}
    public class DeleteCountry
    {
        public int Id { get; set; }
    }
}
