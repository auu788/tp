﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GUI.ViewModels.ValidationRules
{
    public class ProductNameValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string str = value as string;
            if(String.IsNullOrEmpty(str))
            {
                return new ValidationResult(false, "Nazwa produktu nie może być pusta");
            } else if (str.Count() > 50)
            {
                return new ValidationResult(false, "Nazwa produktu nie może przekraczać 50 znaków");
            }

            return new ValidationResult(true, null);
        }
    }
}
