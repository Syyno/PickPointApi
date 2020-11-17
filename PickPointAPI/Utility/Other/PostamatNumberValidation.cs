using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace PickPointAPI.Util
{
    public class PostamatNumberValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var data = (DataManager)validationContext
                .GetService(typeof(DataManager));
            bool success = data.Postamats.IsPostamatExists((int) value);
            return success
                ? ValidationResult.Success
                : new ValidationResult($"There is no postamat with id of {(int) value}");
        }
    }
}
