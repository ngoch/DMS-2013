using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace DMS.Web.Host.Models
{
    [Validator(typeof(InputLambdaViewModelValidator))]
    public class InputLambdaViewModel
    {
        [Display(Name = "მნიშვნელობა")]
        public string Value { get; set; }

        public decimal GetValue()
        {
            return Convert.ToDecimal(Value, CultureInfo.InvariantCulture);
        }
    }
}