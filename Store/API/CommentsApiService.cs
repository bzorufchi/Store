using Microsoft.AspNetCore.Mvc;
using Store.Entitis;
using Store.Models;

namespace Store.API
{
    [Route("api/Comments")]
    [ApiController]
    public class CommentsApiService
    {
        private readonly StoreDbContext context;

        public CommentsApiService(StoreDbContext context)
        {
            this.context = context;
        }
        [HttpGet("GetAllComments")]
        public List<GetAllCommentsOutput> GetAllComments()
        {
            var data = context.Comments.Select(c => new GetAllCommentsOutput()
            {
                Id = c.Id,
                IsActive = c.IsActive,
                Text = c.Text,
                IsAccepted = c.IsAccepted,
                IsAcceptedDate=c.IsAcceptedDate,
                CreateDate=c.CreateDate,
                ByUserId = c.ByUserId
            }).ToList();
            return data;
        }
        [HttpGet("GetCommentsByProductId")]

        public List<GetAllCommentsOutput> GetCommentsByProductId(int ProductId)
        {
            var data = context.Comments.Where(c => c.ProductId == ProductId).Select(c => new GetAllCommentsOutput()
            {
                Id = c.Id,
                Text = c.Text,
                IsAccepted = c.IsAccepted,
                IsAcceptedDate = c.IsAcceptedDate,
                CreateDate = c.CreateDate,  
                ByUserId = c.ByUserId,

				 IsActive = c.IsActive,
			}).ToList();
            return data;
        }
        [HttpPost("Addcomments")]
        public bool Addcomments(AddCommentsInput input)
        {
            try
            {
				context.Comments.Add(new Comments()
				{

					Text = input.Text,
					IsAccepted = input.IsAccepted,
					IsAcceptedDate = input.IsAcceptedDate,
					ByUserId = input.ByUserId,
					UserId = input.UserId,
					ProductId = input.ProductId,

				});
				context.SaveChanges();
                return true;
			}
            catch (Exception)
            {
                return false;
            }
        }
        [HttpPost("UpdateComments")]
        public bool UpdateComments(UpdateCommentsInput input)
        {
            try
            {
				var Comments = context.Comments.Where(c => c.Id == input.Id).FirstOrDefault();
				if (!String.IsNullOrEmpty(input.Text))
				{
					Comments.Text = input.Text;
					Comments.IsAccepted = 0;
				}
				else
				{
					Comments.Text = Comments.Text;
				}

				context.SaveChanges();
                return true;
			}
            catch { return false; }
        }
        [HttpPost("Delete")]
		public string Delete(DeleteComments input)
		{
			if (input.Id == 0)
			{
				throw new Exception("");
			}
			else
			{
				var comment = context.Comments.Where(c => c.Id == input.Id).FirstOrDefault();
				if (comment == null)
				{
					throw new Exception("");
				}
				else
				{
					comment.IsActive = 0;
					context.SaveChanges();
					return "محصول با موفقیت غیر فعال شد";
				}
			}
		}
        [HttpPost("DeleteComments")]
		public string DeleteComments(DeleteComments input)
        {    //check kardan vorudi
            if (input.Id == 0)
            {
                throw new Exception("ورودی شما اشتباه است");
            }
            else
            {
                var comment = context.Comments.Where(c => c.Id == input.Id).FirstOrDefault();
                if (comment == null)
                {
                    throw new Exception(" کامنتی با این مشخصات یافت نشد");
                }
                else {
                    context.Comments.Remove(comment);
                    context.SaveChanges();
                    return "کامنت کاربر حذف شد";
                }

            }
           
            //int flost dobule short long 
            //string
            // if(comment == null)
            //if(comment is null)
            // {

            // }
            //if(input.Id==0)
            
           
               
           
        }
    }
}
