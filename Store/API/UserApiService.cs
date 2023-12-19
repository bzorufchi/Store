using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Store.Entitis;
using Store.Models;

namespace Store.API
{
    [Route("api/User")]
    [ApiController]
    public class UserApiService : ControllerBase
    {
        private readonly StoreDbContext context;

        public UserApiService(StoreDbContext context)
        {
            this.context = context;
        }
        [HttpGet("GetAllUsers")]
        public List<GetAllUsersOutput> GetAllUsers()
        {
            var data = context.User.Select(u => new GetAllUsersOutput()
            {
                Id = u.Id,
                Name = u.FirstName,
                Family = u.FamilyName,
                NationalCode=u.NationalCode,
                PhoneNumber=u.PhoneNumber,
                Birthday = u.BirthDate,
				IsActive = u.IsActive
			}).ToList();
            return data;
        }

        [HttpPost("GetSingelUsers")]
        public GetAllUsersOutput GetSingelUsers(SelectUserInput input)
        {
            var user = context.User.Where(u => u.Id == input.Id || u.NationalCode == input.NationalCode || u.PhoneNumber==input.PhoneNumber).Select(u => new GetAllUsersOutput()
            {
                Id=u.Id,
                Name = u.FirstName,
                Family = u.FamilyName,
                  NationalCode=u.NationalCode,
                PhoneNumber=u.PhoneNumber,
                Birthday = u.BirthDate,
				IsActive = u.IsActive
			}
            ).FirstOrDefault();
          
            return user;
        }

        [HttpPost("Login")]
        public LoginOutput Login(LoginUsers input)
        {
            LoginOutput output = new LoginOutput();
            try
            {
                var user = context.User.Where(u => u.UserName == input.UserName).First();
                if (user == null)
                {
                    output.Userid = 0;
                    output.RoleId = 0;
                    output.ExpTime = DateTime.Now;
                    return output;
                }
                else
                output.Userid = user.Id;
                output.RoleId = user.RoleId;
                output.ExpTime = DateTime.Now.AddMinutes(3);
                return output;
            }
            catch 
            {
                output.Userid = 0;
                output.RoleId = 0;
                output.ExpTime = DateTime.Now;
                return output;
            }
        }

        [HttpPost("AddUser")]
        public bool AddUser(AddUserInput input)
         {
            try
            {
                context.User.Add(new User()
                {
                    BirthDate = DateTime.Now,
                    FirstName = input.FirstName,
                    FamilyName = input.FamilyName,
                    Gender = 0,
                    NationalCode = input.UserName,
                    Password = input.Password,
                    PhoneNumber = input.PhoneNumber,
                    RoleId = 2,
                    UserName = input.UserName,
					IsActive = 1,
                    CreateDate=DateTime.Now,
				});
                context.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                return false;
            }

        }

        [HttpPost("UpdateUser")]
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
                if (input.RoleId != null)
                {
                    user.RoleId = input.RoleId;
                }
                else
                {
                    user.RoleId=user.RoleId;
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
		public string Delete(SelectUserInput input)
		{
			if (input.Id == 0)
			{
				throw new Exception("");
			}
			else
			{
				var user = context.User.Where(u => u.Id == input.Id).FirstOrDefault();
				if (user == null)
				{
					throw new Exception("");
				}
				else
				{
					user.IsActive = 0;
					context.SaveChanges();
					return "محصول با موفقیت غیر فعال شد";
				}
			}
		}

        [HttpPost("DeleteUser")]
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

        [HttpPost("UpdateRoleUser")]
        public bool UpdateRoleUser(UpdateRoleUser input)
        {
            if (input.RoleId==0 || input.RoleId==null)
            {
                return false;   
            }
            else
            {
                var user = context.User.Where(u => u.Id==input.Id).FirstOrDefault();

                if (input.RoleId > 0)
                {
                    user.RoleId = input.RoleId;
                }
                else
                {
                    user.RoleId = user.RoleId;
                }
                context.SaveChanges();
                return true;
            }
        }

        [HttpPost("GetUserFullName")]
        public string GetUserFullName(GetUserFullName  input)
        {
            var fullName=context.User.Where(u=>u.Id==input.Id).Select(u=> u.FirstName + " " + u.FamilyName)
            .FirstOrDefault()!;
            return fullName;
        }
    }
}
