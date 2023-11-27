using Store.Entitis;
using Store.Models;

namespace Store.API
{
    public class CategoryApiService
    {
        private readonly StoreDbContext context;
        public CategoryApiService(StoreDbContext context)
        {
            this.context = context;
        }

        public List<GetAllCategoryOutput> GetAllCategories()
        {
            var data = context.Category.Select(c => new GetAllCategoryOutput { 
             CategoryDescription = c.Description,
             CategoryName =c.CategoryName
            }).ToList();
            return data;
        }
        public void AddCategory(AddCategoryInput input)
        {
            context.Category.Add(new Category {
              CategoryName = input.CategoryName,
              CategoryParent =input.CategoryParrent,
              Description = input.CategoryDescription
            });
            context.SaveChanges();
        }
        public string UpdateCategory(UpdateCategoryInput input)
        {

            var category= context.Category.Where(c => c.Id == input.Id).FirstOrDefault();
            //if (input.CreateDate!=null)
            //{
            //    category!.CreateDate = input.CreateDate;
            //}
            //else
            //{
            //    category.CreateDate = DateTime.Now;
            //}

            if (!string.IsNullOrEmpty(input.CategoryName))
            {
                category!.CategoryName = input.CategoryName;
            }
            else
            {
                category!.CategoryName = input.CategoryName;
            }
            if (!string.IsNullOrEmpty(input.CategoryDescription)){
                category!.Description = input.CategoryDescription;
            }
            else
            {
                category!.Description = input.CategoryDescription;
            }
            if (input.CategoryParrent >=0)
            {
                category!.CategoryParent = input.CategoryParrent;
            }
            else
            {
                category!.CategoryParent = input.CategoryParrent;
            }
            context.SaveChanges();
            return "دسته بندی بروزرسانی شد";
        }
        public string DeleteCategory(DeleteCategoryInput input)
        {
            if (input.Id == 0)
            {
                throw new Exception("ورودی شما اشتباه است");
            }
            else
            {
                var category = context.Category.Where(c => c.Id == input.Id).FirstOrDefault();
                if (category== null) {
                    throw new Exception("دسته بندی با این مشخصات یافت نشد");
                }
                else
                {
                    context.Category.Remove(category);
                    context.SaveChanges();
                    return "دسته بندی حذف شد";
                }
            }
          
            
        }

      
    }
}
