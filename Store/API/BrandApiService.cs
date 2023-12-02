using Microsoft.AspNetCore.Mvc;
using Store.Entitis;
using Store.Models;

namespace Store.API
{
    [Route("api/Brand")]
    [ApiController]
    public class BrandApiService : ControllerBase
    {
        private readonly StoreDbContext context;

        public BrandApiService(StoreDbContext context)
        {
            this.context = context;
        }
        [HttpGet("GetAllBrand")]
        public List<GetAllBrandsOutput> GetAllBrand()
        {
            var data = context.Brands.Select(B => new GetAllBrandsOutput()
            { 
                Id = B.Id,
                IsActive=B.IsActive,
                BrandName = B.BrandName,
                CreateDate = B.CreateDate,
               
            }).ToList();
            return data;
        }
        [HttpPost("AddBrands")]
        public bool AddBrands(AddBrandsInput input)
        {
            try
            {
				context.Brands.Add(new Brands()
				{
					BrandName = input.BrandName,

				});
				context.SaveChanges();
                return true;
			}
            catch (Exception)
            {
                return false;
            }
        }
        [HttpPost("UpdateBrands")]
        public bool UpdateBrands(UpdateBrandInput input)
        {

            try
            {
				var Brands = context.Brands.Where(B => B.Id == input.Id).FirstOrDefault();
				if (!string.IsNullOrEmpty(input.BrandName))
				{
					Brands.BrandName = input.BrandName;
				}
				else
				{
					Brands.BrandName = Brands.BrandName;
				}
				//if (input.CreateDate != null)
				//{
				//    Brands!.CreateDate = input.CreateDate;
				//}
				//else
				//{
				//    Brands.CreateDate = DateTime.Now;
				//}

				context.SaveChanges();
                return true;
			}
            catch { return false; }
        }
        [HttpPost("Delete")]
		public string Delete(DeleteBrandInput input)
		{
			if (input.Id == 0)
			{
				throw new Exception("");
			}
			else
			{
				var Brands = context.Brands.Where(b => b.Id == input.Id).FirstOrDefault();
				if (Brands == null)
				{
					throw new Exception("");
				}
				else
				{
					Brands.IsActive = 0;
					context.SaveChanges();
					return "محصول با موفقیت غیر فعال شد";
				}
			}
		}
        [HttpPost("DeleteRole")]
		public string DeleteRole(DeleteBrandInput input)

        {
            if(input.Id == 0)
            {
                throw new Exception("ورودی شما اشتباه است");
            }
            else
            {
                var Brands = context.Brands.Where(B => B.Id == input.Id).FirstOrDefault();
                if (Brands == null)
                {
                    throw new Exception("برند با این مشخصات یافت نشد");
                }
                else
                {
                    context.Brands.Remove(Brands);
                    context.SaveChanges();
                    return " برند حذف شد";
                }
            }
           
           
        }
    }
}
