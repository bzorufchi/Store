namespace Store.Models
{
    public class GetAllCommentsOutput
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int IsAccepted { get; set; }
        public DateTime IsAcceptedDate { get; set; }
        public DateTime CreateDate { get; set; }
        public int ByUserId { get; set; }
		public int IsActive { get; set; }
	}
    public class AddCommentsInput
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }
      
	}
    public class UpdateCommentsInput
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }
        public int IsAccepted { get; set; }
        public DateTime IsAcceptedDate { get; set; }

        public DateTime CreateDate { get; set; }
        public int ByUserId { get; set; }
		public int IsActive { get; set; }
	}
    public class DeleteComments
    {
        public int Id { get; set; }
    }

    public class GetProductComments
    {
        public int Id { get; set; }
        public string username { get; set; }
       public string Text {get; set; }
    }


}
