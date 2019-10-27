using Rocket.Validation.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rocket.Validation.Impl
{
    public class ValidationResult : IValidationResult
    {
        private readonly List<IPropertyValidationResult> _propertyValidationResultCache;
        public ValidationResult()
        {
            _propertyValidationResultCache = new List<IPropertyValidationResult>();
        }
        public IPropertyValidationResult[] Result { get => _propertyValidationResultCache.ToArray(); }
        public bool IsValid { get => _propertyValidationResultCache.All(propertyValidationResult => propertyValidationResult.IsValid); }
        public void Add(string propertyName, string message)
        {
            var propertyValidationResult = _propertyValidationResultCache.SingleOrDefault(pvr => pvr.PropertyName == propertyName);
            propertyValidationResult = propertyValidationResult ??  new PropertyValidationResult { PropertyName = propertyName };

            propertyValidationResult.Messages.Add(message);

            if (!_propertyValidationResultCache.Contains(propertyValidationResult))
            {
                _propertyValidationResultCache.Add(propertyValidationResult);
            }
        }
    }
}
