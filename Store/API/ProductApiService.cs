using Store.Entitis;
using Store.Models;

namespace Store.API
{
    public class ProductApiService
    {
        private readonly StoreDbContext context;

        public ProductApiService(StoreDbContext context)
        {
            this.context = context;
        }
        public List<GetAllProductOutput> GetAllRole()
        {
            var data = context.Product.Select(p => new GetAllProductOutput()
            {
                BrandId = p.BrandId,
                CountryId = p.CountryId,
                CategoryId= p.CategoryId,
                ProductName= p.ProductName,
                ProductDescription= p.ProductDescription,
                ImageURL = p.ImageURL,
                OrginalPrice=p.OrginalPrice,
                DiscountPrice = p.DiscountPrice,
                IsActive = p.IsActive,
                Count = p.Count,
                Like = p.Like,
                discountpercent = p.discountpercent,
                CreationDate = p.CreationDate
            }).ToList();
            return data;
        }
        public void AddProduct(AddProductInput input)
        {
            context.Product.Add(new Product()
            {

               
                ProductName = input.ProductName,
                ProductDescription = input.ProductDescription,
                ImageURL = input.ImageURL,
                OrginalPrice = input.OrginalPrice,
                DiscountPrice = input.DiscountPrice,
                IsActive = input.IsActive,
                Count = input.Count,
                Like = input.Like,
                discountpercent = input.discountpercent,
                CreationDate = input.CreationDate
            });
            context.SaveChanges();
        }
        public string UpdateProduct(UpdateProductInput input)
        {

            var Product = context.Product.Where(p => p.Id ==input.Id).FirstOrDefault();
            Product.BrandId = input.BrandId;
                Product.CountryId = input.CountryId;
                Product.CategoryId = input.CategoryId;
                Product.ProductName = input.ProductName;
                Product.ProductDescription = input.ProductDescription;
                Product.ImageURL = input.ImageURL;
                Product.OrginalPrice = input.OrginalPrice;
                Product.DiscountPrice = input.DiscountPrice;
                Product.IsActive = input.IsActive;
                Product.count = input.Count;
            Product.Like = input.Like;
                Product.discountpercent = input.discountpercent;
                Product.CreationDate = input.CreationDate;

            context.SaveChanges();
            return "محصول کاربر بروزرسانی شد";
        }

        public string DeleteProduct(DeleteProduct input)
        {
            var Product = context.Product.Where(p => p.Id ==input.Id).FirstOrDefault();
            context.Role.Remove(Product);
            context.SaveChanges();
            return "محصول کاربر حذف شد";
        }
    }
}
