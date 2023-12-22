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
        public int AddProduct(InsertProduct count)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=82.99.242.155;Initial Catalog=store;User ID=sa;Password=andIShe2019$$; Trust Server Certificate=true;"))
                using (SqlCommand cmd = new SqlCommand("dbo.sp_AddProduct", conn))
                {
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    int zero = 0;
                    cmd.Parameters.Add(new SqlParameter("@BrandId", count.BrandId));
                    cmd.Parameters.Add(new SqlParameter("@CountryId", count.CountryId));
                    cmd.Parameters.Add(new SqlParameter("@CategoryId", count.CategoryId));
                    cmd.Parameters.Add(new SqlParameter("@ProductName", count.ProductName));
                    cmd.Parameters.Add(new SqlParameter("@ProductDescription", count.ProductDescription));
                    cmd.Parameters.Add(new SqlParameter("@ImageURL", count.ImageURL));
                    cmd.Parameters.Add(new SqlParameter("@OrginalPrice", count.OrginalPrice));
                    cmd.Parameters.Add(new SqlParameter("@DiscountPrice", count.DiscountPrice));
                    cmd.Parameters.Add(new SqlParameter("@IsActive", count.IsActive));
                    cmd.Parameters.Add(new SqlParameter("@Count", count.Count));
                    cmd.Parameters.Add(new SqlParameter("@Like", zero));
                    cmd.Parameters.Add(new SqlParameter("@discountpercent", zero));
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                    }
                    conn.Close();

                }
                return 1;
            }
            catch (Exception)
            {

                return 0;
            }



        }

        [HttpPost("GetAllCategory")]
        public List<GetAllCategory> GetAllCategory()
        {
            List<GetAllCategory> list = new List<GetAllCategory>();
            using (SqlConnection conn = new SqlConnection("Data Source=82.99.242.155;Initial Catalog=store;User ID=sa;Password=andIShe2019$$; Trust Server Certificate=true;"))
            using (SqlCommand cmd = new SqlCommand("dbo.sp_GetAllCategory", conn))
            {
                conn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new GetAllCategory()
                    {
                       
                        Id = Convert.ToInt32(reader["Id"]),
                        Name= (reader["Name"]).ToString()
                    });
                }
                conn.Close();

            }
            return list;
        }

        [HttpPost("GetAllCountry")]
        public List<GetAllCountry> GetAllCountry()
        {
            List<GetAllCountry> list = new List<GetAllCountry>();
            using (SqlConnection conn = new SqlConnection("Data Source=82.99.242.155;Initial Catalog=store;User ID=sa;Password=andIShe2019$$; Trust Server Certificate=true;"))
            using (SqlCommand cmd = new SqlCommand("dbo.sp_GetAllCountry", conn))
            {
                conn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new GetAllCountry()
                    {

                        Id = Convert.ToInt32(reader["Id"]),
                        Name = (reader["Name"]).ToString()
                    });
                }
                conn.Close();

            }
            return list;
        }

        [HttpPost("GetAllBrands")]
        public List<GetAllBrands> GetAllBrands()
        {
            List<GetAllBrands> list = new List<GetAllBrands>();
            using (SqlConnection conn = new SqlConnection("Data Source=82.99.242.155;Initial Catalog=store;User ID=sa;Password=andIShe2019$$; Trust Server Certificate=true;"))
            using (SqlCommand cmd = new SqlCommand("dbo.sp_GetAllBrands", conn))
            {
                conn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new GetAllBrands()
                    {

                        Id = Convert.ToInt32(reader["Id"]),
                        Name = (reader["Name"]).ToString()
                    });
                }
                conn.Close();

            }
            return list;
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
            catch (Exception)
            {
                return false;
            }
        }
        [HttpPost("Delete")]

        public int Delete(DeleteProduct count)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=82.99.242.155;Initial Catalog=store;User ID=sa;Password=andIShe2019$$; Trust Server Certificate=true;"))
                using (SqlCommand cmd = new SqlCommand("dbo.sp_DeleteProduct", conn))
                {
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Id", count.Id));
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var r = Convert.ToInt32(reader["r"]);
                    }
                    conn.Close();

                }
                return 1;
            }
            catch (Exception)
            {

                return 0;
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
        public List<GetLastProductsOutput> GetLastProducts([FromBody] int count)
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
        [HttpPost("GetMaxProductLike")]
        public List<GetMaxProductLikeOutput> GetMaxProductLike([FromBody] int count)
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
        [HttpPost("GetShowAllProducts")]
        public List<GetShowAllProductsOutput> GetShowAllProducts([FromBody] int count)
        {
            List<GetShowAllProductsOutput> list = new List<GetShowAllProductsOutput>();
            using (SqlConnection conn = new SqlConnection("Data Source=82.99.242.155;Initial Catalog=store;User ID=sa;Password=andIShe2019$$; Trust Server Certificate=true;"))
            using (SqlCommand cmd = new SqlCommand("dbo.sp_GetShowProduct", conn))
            {
                conn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@count", count));
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new GetShowAllProductsOutput()
                    {
                        Count = Convert.ToInt32(reader["Count"]),
                        Id = Convert.ToInt32(reader["Id"]),
                        ImageURL = (reader["ImageURL"]).ToString(),
                        OrginalPrice = Convert.ToInt32(reader["OrginalPrice"]),
                        //ProductDescription = (reader["ProductDescription"]).ToString(),
                        ProductName = (reader["ProductName"]).ToString()
                    });
                }
                conn.Close();

            }
            return list;
        }
        [HttpPost("ProductAdminPanel")]
        public List<GetShowAllProductsOutput> ProductAdminPanel([FromBody] int count)
        {
            List<GetShowAllProductsOutput> list = new List<GetShowAllProductsOutput>();
            using (SqlConnection conn = new SqlConnection("Data Source=82.99.242.155;Initial Catalog=store;User ID=sa;Password=andIShe2019$$; Trust Server Certificate=true;"))
            using (SqlCommand cmd = new SqlCommand("dbo.sp_GetShowProduct", conn))
            {
                conn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@count", count));
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new GetShowAllProductsOutput()
                    {
                        Count = Convert.ToInt32(reader["Count"]),
                        Id = Convert.ToInt32(reader["Id"]),
                        ImageURL = (reader["ImageURL"]).ToString(),
                        OrginalPrice = Convert.ToInt32(reader["OrginalPrice"]),
                        //ProductDescription = (reader["ProductDescription"]).ToString(),
                        ProductName = (reader["ProductName"]).ToString()
                    });
                }
                conn.Close();

            }
            return list;
        }

        [HttpPost("searchProductsByStr")]
        public List<GetShowAllProductsOutput> searchProductsByStr([FromBody] string Str)
        {
            List<GetShowAllProductsOutput> list = new List<GetShowAllProductsOutput>();
            using (SqlConnection conn = new SqlConnection("Data Source=82.99.242.155;Initial Catalog=store;User ID=sa;Password=andIShe2019$$; Trust Server Certificate=true;"))
            using (SqlCommand cmd = new SqlCommand("dbo.sp_searchProductsByStr", conn))
            {
                conn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@str", Str));
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new GetShowAllProductsOutput()
                    {
                        Count = Convert.ToInt32(reader["Count"]),
                        Id = Convert.ToInt32(reader["Id"]),
                        ImageURL = (reader["ImageURL"]).ToString(),
                        OrginalPrice = Convert.ToInt32(reader["OrginalPrice"]),
                        //ProductDescription = (reader["ProductDescription"]).ToString(),
                        ProductName = (reader["ProductName"]).ToString()
                    });
                }
                conn.Close();

            }
            return list;
        }

        [HttpPost("GetShowSingleProducts")]
        public GetShowSingleProducts GetShowSingleProducts([FromBody] int count)
        {
            GetShowSingleProducts product = new GetShowSingleProducts();
            using (SqlConnection conn = new SqlConnection("Data Source=82.99.242.155;Initial Catalog=store;User ID=sa;Password=andIShe2019$$; Trust Server Certificate=true;"))
            using (SqlCommand cmd = new SqlCommand("dbo.sp_GetShowSingleProduct", conn))
            {
                conn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", count));
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    product = new GetShowSingleProducts()
                    {
                        BrandName = (reader["BrandName"]).ToString(),
                        CountryName = (reader["CountryName"]).ToString(),
                        CategoryName = (reader["CategoryName"]).ToString(),
                        Count = Convert.ToInt32(reader["Count"]),
                        ImageURL = (reader["ImageURL"]).ToString(),
                        Id = Convert.ToInt32(reader["Id"]),
                        Like = Convert.ToInt32(reader["Like"]),
                        OrginalPrice = Convert.ToInt32(reader["OrginalPrice"]),
                        ProductName = (reader["ProductName"]).ToString(),
                        ProductDescription = (reader["ProductDescription"]).ToString(),

                        DiscountPrice = Convert.ToInt32(reader["DiscountPrice"]),
                        IsActive = Convert.ToInt32(reader["IsActive"])
                    };
                }
                conn.Close();

            }
            return product;


        }


    }
}
   



