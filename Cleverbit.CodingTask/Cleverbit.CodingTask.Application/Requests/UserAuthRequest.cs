
using Cleverbit.CodingTask.Application.Validators;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Cleverbit.CodingTask.Application.Requests
{
    public class UserAuthRequest : IValidatableObject
    {

        public string UserName { get; set; }
        public string Password { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new UserValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
        }
    }


}
