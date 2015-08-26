using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace DMS.Web.Host.Models
{
    [Validator(typeof(FillRatingsItemValueValidator))]
    public class FillRatingsItemValue
    {
        public string Value { get; set; }

        internal decimal GetValue()
        {
            return Convert.ToDecimal(Value, CultureInfo.InvariantCulture);
        }
    }
}
