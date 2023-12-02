using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Store.Entitis;
using Store.Models;

namespace Store.API
{
    [Route("api/Product")]
    [ApiController]
    public class ProductApiService
    {
        private readonly StoreDbContext context;

        public ProductApiService(StoreDbContext context)
        {
            this.context = context;
        }
        [HttpGet("GetAllProduct")]
        public List<GetAllProductOutput> GetAllProduct()
        {
            var data = context.Product.Select(p => new GetAllProductOutput()
            {
               
                Id = p.Id,
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
        [HttpPost("AddProduct")]
        public bool AddProduct(AddProductInput input)
        {
            try
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
				});
				context.SaveChanges();
                return true;
			}
            catch (Exception) {
            return false;
            }
        }
        [HttpPost("UpdateProduct")]
  
        public bool UpdateProduct(UpdateProductInput input)
        {

            try
            {
				var Product = context.Product.Where(p => p.Id == input.Id).FirstOrDefault();

				Product.BrandId = input.BrandId;
				Product.CountryId = input.CountryId;
				Product.CategoryId = input.CategoryId;
				if (!string.IsNullOrEmpty(input.ProductName))
				{
					Product.ProductName = input.ProductName;
				}
				else
				{
					Product.ProductName = Product.ProductName;
				}
				if (!string.IsNullOrEmpty(input.ProductDescription))
				{
					Product.ProductDescription = input.ProductDescription;
				}
				else
				{
					Product.ProductDescription = Product.ProductDescription;
				}
				if (!string.IsNullOrEmpty(input.ImageURL))
				{
					Product!.ImageURL = input.ImageURL;
				}
				else
				{
					Product.ImageURL = Product.ImageURL;
				}
				if (input.OrginalPrice > 0)
				{
					Product!.OrginalPrice = input.OrginalPrice;
				}
				else
				{
					Product.OrginalPrice = Product.OrginalPrice;
				}
				if (input.DiscountPrice > 0)
				{
					Product.DiscountPrice = input.DiscountPrice;
				}
				else
				{
					Product.DiscountPrice = Product.DiscountPrice;
				}
				//to do bahare

				//if (input.IsActive == 0 || 1)
				//{
				//    Product.IsActive = input.IsActive;
				//}
				//else
				//{
				//    Product.IsActive = Product.IsActive;
				//}
				if (input.Count > 0)
				{
					Product.Count = input.Count;
				}
				else
				{
					Product.Count = 0;
				}
				if (input.Like > 0)
				{
					Product.Like = input.Like;
				}
				else
				{
					Product.Like = Product.Like;
				}
				if (input.discountpercent > 0)
				{
					Product.discountpercent = input.discountpercent;
				}
				else
				{
					Product.discountpercent = Product.discountpercent;
				}

				context.SaveChanges();
				return true;
			}
            catch (Exception) {
            return false;
            }
        }
        [HttpPost("Delete")]
        public string Delete(DeleteProduct input)
        {
            if (input.Id==0)
            {
                throw new Exception("");
            }
            else
            {
                var product = context.Product.Where(p => p.Id == input.Id).FirstOrDefault();
                if (product == null)
                {
                    throw new Exception("");
                }
                else
                {
                    product.IsActive = 0;
                    context.SaveChanges();
                    return "محصول با موفقیت غیر فعال شد";
                }
            }
        }
        [HttpPost("DeleteProduct")]
        public string DeleteProduct(DeleteProduct input)
        {
            if (input.Id == 0)
            {
                throw new Exception("ورودی شما اشتباه است");
            }
            else
            {
                var Product = context.Product.Where(p => p.Id == input.Id).FirstOrDefault();
                if (input == null)
                {
                    throw new Exception("محصولی با این مشخصات یافت نشد");
                }
                else
                {
                    context.Product.Remove(Product);
                    context.SaveChanges();
                    return "محصول کاربر حذف شد";
                }
            }
           
            
        }
        [HttpPost("AddProductLike")]

        public bool AddProductLike(AddProductInput input)

        {

            if (input.Like == null)
            {
                return false;
            }
            else
            {
                var Product = context.Product.Where(p => p.Id == input.Id).FirstOrDefault();
                if (input.Like > 0)
                {
                    Product.Like = Product.Like + 1;
                }
                else
                {
                    Product.Like= Product.Like;
              
                }
                context.SaveChanges();
                return true;
            }

        }
    }
    
}
