namespace Store.Models
{
    public class GetAllShoppingCartOutput
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string PeymentState { get; set; }
        public string PeymentMethod { get; set; }
        public int Count { get; set; }
        public int FixedPrice { get; set; }
    }
    public class AddShoppingCartInput
    {
        public DateTime CreateDate { get; set; }
        public string PeymentState { get; set; }
        public string PeymentMethod { get; set; }
        public int Count { get; set; }
        public int FixedPrice { get; set; }
    }
    public class UpdateShoppingCartInput
    {
        public int id { get; set; }
        public DateTime CreateDate { get; set; }
        public string PeymentState { get; set; }
        public string PeymentMethod { get; set; }
        public int Count { get; set; }
        public int FixedPrice { get; set; }
    }
    public class DeleteShoppingCart
    {
        public int id { get; set; }
    }
}
