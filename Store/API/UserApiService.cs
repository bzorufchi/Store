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
            if (!string.IsNullOrEmpty(input.FirstName))
            {
                user!.FirstName = input.FirstName;
            
            }
            else
            {
                user!.FirstName = input.FirstName;
            }
          
            if (!string.IsNullOrEmpty(input.FirstName))
            {
            user!.FirstName= input.FirstName;
            }
            else
            {
                user!.FirstName=input.FirstName;
            }
            if (!string.IsNullOrEmpty(input.FamilyName))
            {
                user!.FamilyName = input.FamilyName;
            }
            else
            {
                user!.FamilyName=input.FamilyName;
            }
            if (!string.IsNullOrEmpty(input.PhoneNumber))
            {
                user!.PhoneNumber = input.PhoneNumber;
            }
            else
            {
                user!.PhoneNumber=input.PhoneNumber;
            }
            if (!string.IsNullOrEmpty(input.Gender)){

                user.Gender=input.Gender;
            }
            else
            {
                user!.Gender = input.Gender;
            }

            context.SaveChanges();
            return "ثبت شد";
        }

        public string DeleteUser(DeleteUserInput input)
        {

            if (input.Id == 0) {
                throw new Exception("ورودی شما اشتباه است");
            }
            else
            {
                var user = context.User.Where(u => u.Id == input.Id).FirstOrDefault();
                if (user==null)
                {
                    throw new Exception("  کامنتی با این مشخصات یافت نشد");
                }
                else
                {

                    context.User.Remove(user);
                    context.SaveChanges();
                    return "کاربر حذف شد";
                }
            }
           
        }
    }
}
