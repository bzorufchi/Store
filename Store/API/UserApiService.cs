using Microsoft.AspNetCore.Mvc.Formatters;
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
                Id = u.Id,
                Name = u.FirstName,
                Family = u.FamilyName,
                NationalCode=u.NationalCode,
                PhoneNumber=u.PhoneNumber,
                Birthday = u.BirthDate
            }).ToList();
            return data;
        }


        public GetAllUsersOutput GetSingelUsers(SelectUserInput input)
        {
            var user = context.User.Where(u => u.Id == input.Id || u.NationalCode == input.NationalCode || u.PhoneNumber==input.PhoneNumber).Select(u => new GetAllUsersOutput()
            {
                Id=u.Id,
                Name = u.FirstName,
                Family = u.FamilyName,
                  NationalCode=u.NationalCode,
                PhoneNumber=u.PhoneNumber,
                Birthday = u.BirthDate
            }
            ).FirstOrDefault();
          
            return user;
        }

        public bool AddUser(AddUserInput input)
        {
            try
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
                return true;

            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool UpdateUser(UpdateUserInput input)
        {
            try
            {
                   var user = context.User.Where(u=> u.Id==input.Id).FirstOrDefault();
                   if (!string.IsNullOrEmpty(input.FirstName))
                   {
                       user.FirstName = input.FirstName;
                   
                   }
                   else
                   {
                       user.FirstName = user.FirstName;
                   }
          
                   if (!string.IsNullOrEmpty(input.NationalCode))
                   {
                   user!.NationalCode = input.NationalCode;
                   }
                   else
                   {
                       user.NationalCode = user.NationalCode;
                   }
                   if (!string.IsNullOrEmpty(input.FamilyName))
                   {
                       user.FamilyName = input.FamilyName;
                   }
                   else
                   {
                       user.FamilyName=user.FamilyName;
                   }
                   if (!string.IsNullOrEmpty(input.PhoneNumber))
                   {
                       user.PhoneNumber = input.PhoneNumber;
                   }
                   else
                   {
                       user.PhoneNumber=user.PhoneNumber;
                   }
                   if (!string.IsNullOrEmpty(input.Password)){

                       user.Password = input.Password;
                   }
                   else
                   {
                       user.Password = user.Password;
                   }
                   if(!string.IsNullOrEmpty(input.UserName))
                   {
                       user.UserName = input.UserName;
                   }
                   else
                   { user!.UserName = user.UserName;}

                   if (input.Gender == 0 || input.Gender == 1)
                   {
                       user.Gender = input.Gender;
                   }
                   else
                   {
                       user.Gender = user.Gender;
                   }
                   if (input.BirthDate != null)
                   {
                       user.BirthDate = input.BirthDate;
                   }
                   else
                   {
                       user.BirthDate = user.BirthDate;
                   }
                       context.SaveChanges();
                 return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteUser(SelectUserInput input)
        {
            if (input.Id == 0) {
                return false;
            }
            else
            {
                var user = context.User.Where(u => u.Id == input.Id || u.NationalCode==input.NationalCode).FirstOrDefault();
                if (user == null)
                {
                    return false;
                }
                else
                {
                    context.User.Remove(user);
                    context.SaveChanges();
                    return true;
                }
            } 
        }
        // to do bahare
        //public bool UpdateRoleUser(?????)
        //{
        //    return true;

        //    return false;
        //}
    }
}
