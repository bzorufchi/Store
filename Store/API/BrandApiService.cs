using Store.Entitis;
using Store.Models;

namespace Store.API
{
    public class BrandApiService
    {
        private readonly StoreDbContext context;

        public BrandApiService(StoreDbContext context)
        {
            this.context = context;
        }
        public List<GetAllBrandsOutput> GetAllBrand()
        {
            var data = context.Brands.Select(B => new GetAllBrandsOutput()
            {
                BrandName = B.BrandName,
                CreateDate = B.CreateDate,
               
            }).ToList();
            return data;
        }
        public void AddBrands(AddBrandsInput input)
        {
            context.Brands.Add(new Brands()
            {
                BrandName = input.BrandName,
                
            });
            context.SaveChanges();
        }
        public string UpdateBrands(UpdateBrandInput input)
        {

            var Brands = context.Brands.Where(B => B.Id == input.Id).FirstOrDefault();
            if (!string.IsNullOrEmpty(input.BrandName))
            {
                Brands!.BrandName = input.BrandName;
            }
            else
            {
                Brands!.BrandName = input.BrandName;
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
            return " برند بروزرسانی شد";
        }

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
