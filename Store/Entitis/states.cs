namespace Store.Entitis
{
    public class States
    {
        public int Id { get; set; }
        public int StateName { get; set; }
        public DateTime CreateDate { get; set; }

        public Orders Orders { get; set; }

    }
}
