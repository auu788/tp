using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GUI.ViewModels.ValidationRules
{
    public class ReviewCommentValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string str = value as string;
            if (String.IsNullOrEmpty(str))
            {
                return new ValidationResult(false, "Komentarz nie może być pusty");
            }
            else if (str.Count() > 3850)
            {
                return new ValidationResult(false, "Komentarz nie może przekraczać 3850 znaków");
            }

            return new ValidationResult(true, null);
        }
    }
}
