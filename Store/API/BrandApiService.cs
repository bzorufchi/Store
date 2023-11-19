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
                Products=B.Products,
            }).ToList();
            return data;
        }
        public void AddBrands(AddBrandsInput input)
        {
            context.Brands.Add(new Brands()
            {
                BrandName = input.BrandName,
                Products=input.Products,
            });
            context.SaveChanges();
        }
        public string UpdateBrands(UpdateBrandInput input)
        {

            var Brands = context.Brands.Where(B => B.Id == input.Id).FirstOrDefault();
            Brands.BrandName = input.BrandName;
            Brands.Products = input.Products;

            context.SaveChanges();
            return " برند بروزرسانی شد";
        }

        public string DeleteRole(DeleteBrandInput input)
        {
            var Brands = context.Brands.Where(B => B.Id ==input.Id).FirstOrDefault();
            context.Brands.Remove(Brands);
            context.SaveChanges();
            return " برند حذف شد";
        }
    }
}
