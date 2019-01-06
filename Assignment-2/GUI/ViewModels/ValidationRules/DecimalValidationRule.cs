using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GUI.ViewModels.ValidationRules
{
    public class DecimalValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            Regex r = new Regex(@"^[0-9]+(\.[0-9]{1,2})?$");

            if (r.IsMatch(value as string))
            {
                return new ValidationResult(true, null);
            }
            else
            {
                return new ValidationResult(false, "Liczba powinna być w formacie 00.00!");
            }
        }
    }
}
