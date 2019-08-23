using System.Collections.Generic;
using Rocket.Validation.Abstract;

namespace Rocket.Validation.Impl
{
    internal class PropertyValidationResult : IPropertyValidationResult
    {
        public string PropertyName { get; set; }
        public bool IsValid { get; set; }
        public List<string> Messages { get; set; }
    }
}
