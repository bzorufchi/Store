using Store.Entitis;

namespace Store.Models
{
    public class GetAllStatesOutput
    {
        public int StateName { get; set; }
        public DateTime CreateDate { get; set; }
    }
    public class AddStatesInput {
        public int StateName { get; set; }
        public DateTime CreateDate { get; set; }
    }
    public class UpdateStatesInput
    {
        public int Id { get; set; }
        public int StateName { get; set; }
        public DateTime CreateDate { get; set; }

    }
    public class DeleteStatesInput
    {
        public int Id { get; set; }
    }
}
