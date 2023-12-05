using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Store.Entitis;
using Store.Models;
using System.Collections.Generic;
using System.Data;

namespace Store.API
{
    [Route("api/Product")]
    [ApiController]
    public class ProductApiService : ControllerBase
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
                CategoryId = p.CategoryId,
                ProductName = p.ProductName,
                ProductDescription = p.ProductDescription,
                ImageURL = p.ImageURL,
                OrginalPrice = p.OrginalPrice,
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
            if (input.Id == 0)
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
                    Product.Like = Product.Like;

                }
                context.SaveChanges();
                return true;
            }

        }
        [HttpPost("GetLastProducts")]
        public List<GetMaxProductLikeOutput> GetLastProducts([FromBody] int count)
        {
            List<GetLastProductsOutput> list = new List<GetLastProductsOutput>();
            using (SqlConnection conn = new SqlConnection("Data Source=82.99.242.155;Initial Catalog=store;User ID=sa;Password=andIShe2019$$; Trust Server Certificate=true;"))
            using (SqlCommand cmd = new SqlCommand("dbo.sp_GetLastProducts", conn))
            {
                conn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@count", count));
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new GetLastProductsOutput()
                    {
                        Count = Convert.ToInt32(reader["Count"]),
                        DiscountPrice = Convert.ToInt32(reader["DiscountPrice"]),
                        ImageURL = (reader["ImageURL"]).ToString(),
                        OrginalPrice = Convert.ToInt32(reader["OrginalPrice"]),
                        ProductName = (reader["ProductName"]).ToString(),
                        Id = Convert.ToInt32(reader["Id"])
                    });
                }
                conn.Close();

            }
            return list;
        }
        [HttpPost("MaxProductLike")]
        public List<GetMaxProductLikeOutput> GetMaxProductLike(int count)
        {
            List<GetMaxProductLikeOutput> list = new List<GetMaxProductLikeOutput>();
            using (SqlConnection conn = new SqlConnection("Data Source=82.99.242.155;Initial Catalog=store;User ID=sa;Password=andIShe2019$$; Trust Server Certificate=true;"))
            using (SqlCommand cmd = new SqlCommand("dbo.sp_GetMaxProductLike", conn))
            {
                conn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@count", count));
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new GetMaxProductLikeOutput()
                    {
                        Count = Convert.ToInt32(reader["Count"]),
                        DiscountPrice = Convert.ToInt32(reader["DiscountPrice"]),
                        Id = Convert.ToInt32(reader["Id"]),
                        ImageURL = (reader["ImageURL"]).ToString(),
                        
                        Like = Convert.ToInt32(reader["Like"]),
                        OrginalPrice = Convert.ToInt32(reader["OrginalPrice"]),
                       
                        ProductName = (reader["ProductName"]).ToString()

                    });
                }
                conn.Close();

            }
            return list;
        }
    }
   
}
