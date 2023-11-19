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
            category.CategoryName = input.CategoryName;
            category.Description = input.CategoryDescription;
            category.CategoryParent=input.CategoryParrent;
            context.SaveChanges();
            return "دسته بندی بروزرسانی شد";
        }
        public string DeleteCategory(DeleteCategoryInput input)
        {
            var category = context.Category.Where(c => c.Id == input.Id).FirstOrDefault();
            context.Category.Remove(category);
            context.SaveChanges();
            return "دسته بندی حذف شد";
        }

      
    }
}
