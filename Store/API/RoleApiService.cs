using Microsoft.AspNetCore.Mvc;
using Store.Entitis;
using Store.Models;

namespace Store.API
{
    [Route("api/Role")]
    [ApiController]
    public class RoleApiService : ControllerBase
    {
        private readonly StoreDbContext context;

        public RoleApiService(StoreDbContext context)
        {
            this.context = context;
        }
        [HttpGet("GetAllRole")]
        public List<GetAllRoleOutput> GetAllRole()
        {
            var data = context.Role.Select(R => new GetAllRoleOutput()
            {
              
                Id = R.Id,
                RoleName = R.RoleName,
                CreateDate = R.CreateDate,
                IsActive = R.IsActive
            }).ToList();
            return data;
        }
        [HttpPost("AddRole")]
        public bool AddRole(AddRoleInput input)
        {
            try
            {
				context.Role.Add(new Role()
				{
					RoleName = input.RoleName,
					IsActive = input.IsActive
				});
				context.SaveChanges();
                return true;
			}
            catch (Exception) { 
            return false;
            }
			
        }
        [HttpPost("UpdateRole")]
        public bool UpdateRole(UpdateRoleInput input)
        {

            try
            {
				var Role = context.Role.Where(R => R.Id == input.Id).FirstOrDefault();
				if (!string.IsNullOrEmpty(input.RoleName))
				{
					Role.RoleName = input.RoleName;
				}
				else
				{
					Role.RoleName = Role.RoleName;
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
		public string Delete(DeleteRole input)
		{
			if (input.Id == 0)
			{
				throw new Exception("");
			}
			else
			{
				var Role = context.Role.Where(R => R.Id == input.Id).FirstOrDefault();
				if (Role == null)
				{
					throw new Exception("");
				}
				else
				{
					Role.IsActive = 0;
					context.SaveChanges();
					return "محصول با موفقیت غیر فعال شد";
				}
			}
		}
        [HttpPost("DeleteRole")]
		public string DeleteRole(DeleteRole input)//int id
        {

            if (input.Id == 0)
            {
                throw new Exception("ورودی شما اشتباه است");
            }
            else
            {
                var Role = context.Role.Where(R => R.Id ==input.Id).FirstOrDefault();
                if (Role == null)
                {
                    throw new Exception("نقشی با این مشخصات یافت نشد");
                }
                else
                {
                    context.Role.Remove(Role);
                    context.SaveChanges();
                    return "نقش کاربر حذف شد";
                }
            }
           
            
        }
    }
}
