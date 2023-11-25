using Store.Entitis;
using Store.Models;

namespace Store.API
{
    public class CommentsApiService
    {
        private readonly StoreDbContext context;

        public CommentsApiService(StoreDbContext context)
        {
            this.context = context;
        }
        public List<GetAllCommentsOutput> GetAllComments()
        {
            var data = context.Comments.Select(c => new GetAllCommentsOutput()
            {
                Text = c.Text,
                IsAccepted = c.IsAccepted,
                IsAcceptedDate=c.IsAcceptedDate,
                CreateDate=c.CreateDate,
                ByUserId = c.ByUserId
            }).ToList();
            return data;
        }

        public List<GetAllCommentsOutput> GetCommentsByProductId(int ProductId)
        {
            var data = context.Comments.Where(c => c.ProductId == ProductId).Select(c => new GetAllCommentsOutput()
            {
                Text = c.Text,
                IsAccepted = c.IsAccepted,
                IsAcceptedDate = c.IsAcceptedDate,
                CreateDate = c.CreateDate,  
                ByUserId = c.ByUserId
            }).ToList();
            return data;
        }
            public void Addcomments(AddCommentsInput input)
        {
            context.Comments.Add(new Comments()
            {

                Text = input.Text,
                IsAccepted = input.IsAccepted,
                IsAcceptedDate=input.IsAcceptedDate,
                ByUserId = input.ByUserId,
                UserId=input.UserId,
                ProductId=input.ProductId,

            });
            context.SaveChanges();
        }
        public string UpdateComments(UpdateCommentsInput input)
        {
            var Comments = context.Comments.Where(c => c.Id == input.Id).FirstOrDefault();
            if (!String.IsNullOrEmpty(input.Text))
            {
                Comments!.Text=input.Text;
                Comments.IsAccepted = 0;
            }
            else
            {
                Comments!.Text = Comments.Text;
            }

            context.SaveChanges();
            return "کامنت کاربر بروزرسانی شد";
        }

        public string DeleteComments(DeleteComments input)
        {
            var comments = context.Comments.Where(c => c.Id == input.Id).FirstOrDefault();
            if (!string.IsNullOrEmpty(input.Id==0))
            {
                Comments!.Id=input.Id;
            }
            else
            {
                context.Comments.Remove(comments);
                context.SaveChanges();
                return "کامنت کاربر حذف شد";
            }
        }
    }
}
