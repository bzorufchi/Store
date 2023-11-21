using System.ComponentModel.DataAnnotations;

namespace Store.Attribute
{
    public class MobileAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var Mobile=value.ToString();
            if (Mobile.Length==11)
            {
                return true;
            }
            return false;
        }
        public override string FormatErrorMessage(string name)
        {
            return base.FormatErrorMessage(name);
        }
    }

}
