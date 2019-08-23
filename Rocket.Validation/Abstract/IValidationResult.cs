using System.Collections.Generic;


namespace Rocket.Validation.Abstract
{
    public interface IValidationResult
    {
        string ParameterName { get; set; }
        bool IsValid { get; }
        void Add(string propertyName, string message);
    }
}
