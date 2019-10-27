using System.Collections.Generic;


namespace Rocket.Validation.Abstract
{
    public interface IValidationResult
    {
        IPropertyValidationResult[] Result { get; }
        bool IsValid { get; }
        void Add(string propertyName, string message);
    }
}
