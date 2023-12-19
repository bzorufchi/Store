using Store.Attribute;
using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public class GetAllUsersOutput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string NationalCode { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birthday { get; set; }
        public int? IsActive { get; set; }

    }
    public class LoginOutput
    {
        public int Userid { get; set; }
        public int RoleId { get; set; }
        public DateTime ExpTime { get; set; }
    }
    public class LoginUsers
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class AddUserInput
    {
       // public int RoleId { get; set; }
        [Required(ErrorMessage ="پر کردن این فیلد الزامی می باشد")]
        //[EmailAddress]
        public string FirstName { get; set; }
        public string FamilyName { get; set; }
        //public DateTime BirthDate { get; set; }
        // [NatinalCode]
        // public string NationalCode { get; set; }
        [NatinalCode]
        public string UserName { get; set; }
        public string Password { get; set; }
       // public DateTime CreateDate { get; set; }
        [Mobile(ErrorMessage = "شماره موبایل صحیح نیست")]
        public string PhoneNumber { get; set; }
       // public int Gender { get; set; }
		//public int? IsActive { get; set; }
	}
    public class UpdateUserInput 
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string FirstName { get; set; }
        public string FamilyName { get; set; }
        public DateTime BirthDate { get; set; }
        [NatinalCode]
        public string NationalCode { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime CreateDate { get; set; }
        [Mobile(ErrorMessage = "شماره موبایل صحیح نیست")]
        public string PhoneNumber { get; set; }
        public int Gender { get; set; }
		public int? IsActive { get; set; }
	}
    public class UpdateRoleUser
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
    }
    public class SelectUserInput
    {
        public int Id { get; set; }
        public string NationalCode { get; set; }
        public string PhoneNumber { get; set; }
		

	}

    public class GetUserFullName
    {
       public int Id { get; set; }
    }
}
