using System.Collections.Generic;
using System.Linq;

namespace ipsmedserviceapp.Model.AppModels
{
    public class ValidationResult
    {
        public List<ValidationError> Errors { get; } = new List<ValidationError>();
        public bool AreErrorsExist { get => Errors.Any(); }

        public void AddError(ValidationError error)
        {
            Errors.Add(error);
        }

        public void AddError(string message)
        {
            AddError(new ValidationError { PropertyName = "", ErrorMessage = message });
        }

        public void AddError(string propertyName, string message)
        {
            AddError(new ValidationError { PropertyName = propertyName, ErrorMessage = message });
        }
    }

    public class ValidationError
    {
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }
    }
}
