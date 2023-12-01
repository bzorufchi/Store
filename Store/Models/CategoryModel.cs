namespace Store.Models
{
    public class GetAllCategoryOutput
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
		public int IsActive { get; set; }
	}
    public class AddCategoryInput
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public DateTime CreateDate{ get; set; }

        public int CategoryParrent { get; set; }
		public int IsActive { get; set; }
	}
    public class UpdateCategoryInput
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public DateTime CreateDate { get; set; }

        public int CategoryParrent { get; set; }
		public int IsActive { get; set; }
	}
    public class DeleteCategoryInput
    {
        public int Id { get; set; }
        
    }
}
