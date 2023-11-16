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
        public void Addcomments(AddCommentsInput input)
        {
            context.Comments.Add(new Comments()
            {

                Text = input.Text,
                IsAccepted = input.IsAccepted,
                IsAcceptedDate=input.IsAcceptedDate,
                CreateDate=input.CreateDate,
                ByUserId = input.ByUserId,
                UserId=input.UserId,
                ProductId=input.ProductId,

            });
            context.SaveChanges();
        }
        public string UpdateComments(UpdateCommentsInput input)
        {

            var Comments = context.Comments.Where(c => c.Id == input.Id).FirstOrDefault();
            Comments.Text = input.Text;
            Comments.IsAccepted = input.IsAccepted;
            Comments.IsAcceptedDate = input.IsAcceptedDate;
            Comments.CreateDate = input.CreateDate;
            Comments.ByUserId = input.ByUserId;
            Comments.UserId = input.UserId;
            Comments.ProductId = input.ProductId;

            context.SaveChanges();
            return "کامنت کاربر بروزرسانی شد";
        }

        public string DeleteRole(DeleteComments input)
        {
            var comments = context.Comments.Where(c => c.Id ==input.Id).FirstOrDefault();
            context.Comments.Remove(comments);
            context.SaveChanges();
            return "کامنت کاربر حذف شد";
        }
    }
}
