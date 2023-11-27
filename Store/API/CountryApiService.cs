using Store.Entitis;
using Store.Models;

namespace Store.API
{
    public class CountryApiService
    {
        private readonly StoreDbContext context;

        public CountryApiService(StoreDbContext context)
        {
            this.context = context;
        }
        public List<GetAllCountruOutput> GetAllCountry()
        {
            var data = context.Country.Select(c => new GetAllCountruOutput()
            {
                CountryName = c.CountryName,
                CreateDate = c.CreateDate,

            }).ToList();
            return data;
        }
        public void AddCountry(AddCountryInput input)
        {
            context.Country.Add(new Country()
            {
                CountryName = input.CountryName,
            });
            context.SaveChanges();
        }
        public string UpdateCountry(UpdateCountryInput input)
        {

            var Country = context.Country.Where(c => c.Id == input.Id).FirstOrDefault();
            if (!string.IsNullOrEmpty(input.CountryName))
            {
                Country!.CountryName = input.CountryName;
            }
            else
            {
                Country!.CountryName = input.CountryName;
            }

            context.SaveChanges();
            return " کشور بروزرسانی شد";
        }

        public string DeleteCountry(DeleteCountry input)
        {
            if (input.Id == 0)
            {
                throw new Exception("ورودی شما اشتباه است");
            }
            else
            {
                var Country = context.Country.Where(c => c.Id == input.Id).FirstOrDefault();
                if (Country == null)
                {
                    throw new Exception("کشوری یافت نشد");

                }
                else
                {
                    context.Country.Remove(Country);
                    context.SaveChanges();
                    return "کشور حذف شد";
                }
            }
           
         
        }
    }
}
