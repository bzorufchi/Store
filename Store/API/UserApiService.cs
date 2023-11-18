using Store.Entitis;
using Store.Models;

namespace Store.API
{
    public class UserApiService
    {
        private readonly StoreDbContext context;

        public UserApiService(StoreDbContext context)
        {
            this.context = context;
        }

        public List<GetAllUsersOutput> GetAllUsers()
        {
            var data = context.User.Select(u => new GetAllUsersOutput()
            {
                Name = u.FirstName,
                Family = u.FamilyName,
                Birthday = u.BirthDate
            }).ToList();
            return data;
        }

        public void AddUser(AddUserInput input)
        {
            context.User.Add(new User()
            {
                BirthDate = input.BirthDate,
                FirstName = input.FirstName, 
                FamilyName = input.FamilyName,
                Gender = input.Gender,
                NationalCode = input.NationalCode,
                Password = input.Password,
                PhoneNumber = input.PhoneNumber,
                RoleId = input.RoleId,
                UserName = input.UserName
            });
            context.SaveChanges();
        }

        public string UpdateUser(UpdateUserInput input)
        {

            var user = context.User.Where(u=> u.Id==input.Id).FirstOrDefault();
            user.UserName = input.UserName;
            user.PhoneNumber = input.PhoneNumber;
            user.RoleId = input.RoleId;
            user.BirthDate = input.BirthDate;
            user.FirstName = input.FirstName;
            user.FamilyName = input.FamilyName;
            user.Gender = input.Gender;
            user.NationalCode = input.NationalCode;
            user.Password = input.Password;

            context.SaveChanges();
            return "ثبت شد";
        }

        public string DeleteUser(DeleteUserInput input)
        {
            var user = context.User.Where(u => u.Id==input.Id).FirstOrDefault();
            context.User.Remove(user);
            context.SaveChanges();
            return "کاربر حذف شد";
        }
    }
}
