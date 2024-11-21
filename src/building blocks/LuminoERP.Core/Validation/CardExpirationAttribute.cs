using System.ComponentModel.DataAnnotations;


namespace LuminoERP.Core.Validation
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
    public class CardExpirationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return false;

            var month = value.ToString().Split('/')[0];
            var year = $"20{value.ToString().Split('/')[1]}";

            if (int.TryParse(month, out var monthResult) &&
                int.TryParse(year, out var yearResult))
            {
                var d = new DateTime(yearResult, monthResult, 1);
                return d > DateTime.UtcNow;
            }

            return false;
        }
    }
}
