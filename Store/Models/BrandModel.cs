using Store.Entitis;
using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public class GetAllBrandsOutput
    {   public int Id {get;set;}
        public string BrandName { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; }
		public int IsActive { get; set; }
	}
    public class AddBrandsInput
    {
        public int Id { get; set; }
        public string BrandName { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; }
		public int IsActive { get; set; }
	}
    public class UpdateBrandInput
    {
        public int Id { get; set; }
        public string BrandName { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; }
		public int IsActive { get; set; }
	}
    public class DeleteBrandInput
    {
        public int Id { get; set; }
    }
}
