using ipsmedserviceapp.Model.AppModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ipsmedserviceapp.Extensions
{
    public static class ModelStateExtensions
    {
        public static void AddValidationErrors(this ModelStateDictionary modelState, ValidationResult validationResult)
        {
            if (!validationResult.AreErrorsExist)
                return;

            foreach (var error in validationResult.Errors)
                modelState.AddModelError(error.PropertyName, error.ErrorMessage);
        }
    }
}
