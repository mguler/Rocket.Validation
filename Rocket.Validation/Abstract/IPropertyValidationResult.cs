using System;
using System.Collections.Generic;
using System.Text;

namespace Rocket.Validation.Abstract
{
    public interface IPropertyValidationResult
    {
        string PropertyName { get; set; }
        bool IsValid { get; set; }
        List<string> Messages { get; set; }
    }
}
