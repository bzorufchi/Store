using Microsoft.AspNetCore.Mvc;
using Store.Entitis;
using Store.Models;

namespace Store.API
{
    [Route("api/Country")]
    [ApiController]
    public class CountryApiService : ControllerBase
    {
        private readonly StoreDbContext context;

        public CountryApiService(StoreDbContext context)
        {
            this.context = context;
        }
        [HttpGet("GetAllCountry")]
        public List<GetAllCountruOutput> GetAllCountry()
        {
            var data = context.Country.Select(c => new GetAllCountruOutput()
            {
                Id = c.Id,
                IsActive = c.IsActive,
                CountryName = c.CountryName,
                CreateDate = c.CreateDate,

            }).ToList();
            return data;
        }
        [HttpPost("AddCountry")]
        public bool AddCountry(AddCountryInput input)
        {
            try
            {
				context.Country.Add(new Country()
				{
					CountryName = input.CountryName,
				});
				context.SaveChanges();
                return true;
			}
            catch (Exception)
            {
                return false;
            }
        }
        [HttpPost("UpdateCountry")]
        public bool UpdateCountry(UpdateCountryInput input)
        {

            try
            {
				var Country = context.Country.Where(c => c.Id == input.Id).FirstOrDefault();
				if (!string.IsNullOrEmpty(input.CountryName))
				{
					Country.CountryName = input.CountryName;
				}
				else
				{
					Country.CountryName = Country.CountryName;
				}

				context.SaveChanges();
				return true ;
			}
            catch { 
                return false; 
            }
        }
        [HttpPost("Delete")]
		public string Delete(DeleteCountry input)
		{
			if (input.Id == 0)
			{
				throw new Exception("");
			}
			else
			{
				var Country = context.Country.Where(c => c.Id == input.Id).FirstOrDefault();
				if (Country == null)
				{
					throw new Exception("");
				}
				else
				{
					Country.IsActive = 0;
					context.SaveChanges();
					return "محصول با موفقیت غیر فعال شد";
				}
			}
		}
        [HttpPost("DeleteCountry")]
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
