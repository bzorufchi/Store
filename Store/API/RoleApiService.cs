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
            Role.RoleName = input.RoleName;

            context.SaveChanges();
            return "نقش کاربر بروزرسانی شد";
        }

        public string DeleteRole(int id)
        {
            var Role = context.Role.Where(R => R.Id == id).FirstOrDefault();
            context.Role.Remove(Role);
            context.SaveChanges();
            return "نقش کاربر حذف شد";
        }
    }
}
