using Store.Entitis;

namespace Store.Models
{
    public class GetAllStatesOutput
    {
        public int Id { get; set; }
        public string StateName { get; set; }
        public DateTime CreateDate { get; set; }
		public int IsActive { get; set; }
	}
    public class AddStatesInput {
        public string StateName { get; set; }
        public DateTime CreateDate { get; set; }
		public int IsActive { get; set; }
	}
    public class UpdateStatesInput
    {
        public int Id { get; set; }
        public string StateName { get; set; }
		public int IsActive { get; set; }
	}
    public class DeleteStatesInput
    {
        public int Id { get; set; }
    }
}
