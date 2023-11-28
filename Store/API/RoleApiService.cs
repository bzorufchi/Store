using Store.Entitis;
using Store.Models;

namespace Store.API
{
    public class RoleApiService
    {
        private readonly StoreDbContext context;

        public RoleApiService(StoreDbContext context)
        {
            this.context = context;
        }
        public List<GetAllRoleOutput> GetAllRole()
        {
            var data = context.Role.Select(R => new GetAllRoleOutput()
            {
                // to do bahare
                // Id اضافه شود
                RoleName = R.RoleName,
                CreateDate = R.CreateDate,
            }).ToList();
            return data;
        }
        public void AddRole(AddRoleInput input)
        {
            context.Role.Add(new Role()
            {
                RoleName = input.RoleName,
            });
            context.SaveChanges();
        }
        public string UpdateRole(UpdateRoleInput input)
        {

            var Role = context.Role.Where(R => R.Id == input.Id).FirstOrDefault();
            if (!string.IsNullOrEmpty(input.RoleName))
            {
                Role!.RoleName = input.RoleName;
            }
            else
            {
                Role!.RoleName = Role.RoleName;
            }

            context.SaveChanges();
            return "نقش کاربر بروزرسانی شد";
        }

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
