using System.ComponentModel.DataAnnotations;

namespace Store.Attribute
{
    public class NatinalCodeAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var allDigitEqual = new[] { "0000000000", "1111111111", "2222222222", "3333333333", "4444444444", "5555555555", "6666666666", "7777777777", "8888888888", "9999999999" };
            var natinalCode = (string)value;
            var arrey = new[] { "0000000000", "1111111111", "2222222222", "3333333333", "4444444444", "5555555555", "6666666666", "7777777777", "8888888888", "9999999999" };
            if (!string.IsNullOrEmpty(natinalCode) && natinalCode.Any(c => char.IsDigit(c)) && !Array.Exists<string>(arrey, x => x == natinalCode) && natinalCode.Length == 10)
            {
                var sum = 0;
                for (int i = 0; i < natinalCode.Length - 1; i++)
                {
                    sum += ((int)char.GetNumericValue(natinalCode[i])) * (10 - i);
                }
                var r = sum % 11;
                return r > 2 && (int)char.GetNumericValue(natinalCode[9]) == 11 - r || r < 2 && (int)char.GetNumericValue(natinalCode[9]) == r;
            }
            return false;
        }
        public override string FormatErrorMessage(string name)
        {
            return base.FormatErrorMessage(name);
        }
    }
}
