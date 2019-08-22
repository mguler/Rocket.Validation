using Rocket.Validation.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Rocket.Validation.Impl
{
    public class RocketValidator : IValidationServiceProvider
    {
        private readonly IDictionary<MethodInfo, Delegate> _validatorCache = new Dictionary<MethodInfo, Delegate>();
        public bool ThrowExceptionIfValidationFails { get; set; }

        public RocketValidator(IValidationConfiguration[] validationConfiguration)
        {
            foreach (var configuration in validationConfiguration)
            {
                configuration.Configure(this);
            }
        }

        public bool Validate(MethodInfo method, params object[] methodParameters)
        {
            var validator = _validatorCache.SingleOrDefault(methodInfo =>
                methodInfo.Key == method).Value;

            if (validator != null)
            {
                try
                {
                    validator.DynamicInvoke(methodParameters);
                }
                catch (Exception ex)
                {
                    throw ex.InnerException ?? ex;
                }
            }

            return true;
        }

        private void AddToValidatorCache(LambdaExpression method, Delegate validatorFunction)
        {
            var body = method.Body as UnaryExpression;
            var operand = body.Operand as MethodCallExpression;
            var obj = operand.Object as ConstantExpression;
            var value = obj.Value as MethodInfo;
            _validatorCache.Add(value, validatorFunction);
        }

        public void Register<TOwner, TParam, T1>(Expression<Func<TOwner, Func<T1>>> method, Func<TParam, IValidationResult> validatorFunction) => AddToValidatorCache(method, validatorFunction);
        public void Register<TOwner, TParam, T1, T2>(Expression<Func<TOwner, Func<T1, T2>>> method, Func<TParam, IValidationResult> validatorFunction) => AddToValidatorCache(method, validatorFunction);
        public void Register<TOwner, TParam, T1, T2, T3>(Expression<Func<TOwner, Func<T1, T2, T3>>> method, Func<TParam, IValidationResult> validatorFunction) => AddToValidatorCache(method, validatorFunction);
        public void Register<TOwner, TParam, T1, T2, T3, T4>(Expression<Func<TOwner, Func<T1, T2, T3, T4>>> method, Func<TParam, IValidationResult> validatorFunction) => AddToValidatorCache(method, validatorFunction);
        public void Register<TOwner, TParam, T1, T2, T3, T4, T5>(Expression<Func<TOwner, Func<T1, T2, T3, T4, T5>>> method, Func<TParam, IValidationResult> validatorFunction) => AddToValidatorCache(method, validatorFunction);
        public void Register<TOwner, TParam, T1, T2, T3, T4, T5, T6>(Expression<Func<TOwner, Func<T1, T2, T3, T4, T5, T6>>> method, Func<TParam, IValidationResult> validatorFunction) => AddToValidatorCache(method, validatorFunction);
        public void Register<TOwner, TParam, T1, T2, T3, T4, T5, T6, T7>(Expression<Func<TOwner, Func<T1, T2, T3, T4, T5, T6, T7>>> method, Func<TParam, IValidationResult> validatorFunction) => AddToValidatorCache(method, validatorFunction);
        public void Register<TOwner, TParam, T1, T2, T3, T4, T5, T6, T7, T8>(Expression<Func<TOwner, Func<T1, T2, T3, T4, T5, T6, T7, T8>>> method, Func<TParam, IValidationResult> validatorFunction) => AddToValidatorCache(method, validatorFunction);
        public void Register<TOwner, TParam, T1, T2, T3, T4, T5, T6, T7, T8, T9>(Expression<Func<TOwner, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9>>> method, Func<TParam, IValidationResult> validatorFunction) => AddToValidatorCache(method, validatorFunction);
        public void Register<TOwner, TParam, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Expression<Func<TOwner, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>> method, Func<TParam, IValidationResult> validatorFunction) => AddToValidatorCache(method, validatorFunction);
        public void Register<TOwner, TParam, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Expression<Func<TOwner, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>>> method, Func<TParam, IValidationResult> validatorFunction) => AddToValidatorCache(method, validatorFunction);
        public void Register<TOwner, TParam, T1>(Expression<Func<TOwner, Action<T1>>> action, Func<TParam, IValidationResult> validatorFunction) => AddToValidatorCache(action, validatorFunction);
        public void Register<TOwner, TParam, T1, T2>(Expression<Func<TOwner, Action<T1, T2>>> action, Func<TParam, IValidationResult> validatorFunction) => AddToValidatorCache(action, validatorFunction);
        public void Register<TOwner, TParam, T1, T2, T3>(Expression<Func<TOwner, Action<T1, T2, T3>>> action, Func<TParam, IValidationResult> validatorFunction) => AddToValidatorCache(action, validatorFunction);
        public void Register<TOwner, TParam, T1, T2, T3, T4>(Expression<Func<TOwner, Action<T1, T2, T3, T4>>> action, Func<TParam, IValidationResult> validatorFunction) => AddToValidatorCache(action, validatorFunction);
        public void Register<TOwner, TParam, T1, T2, T3, T4, T5>(Expression<Func<TOwner, Action<T1, T2, T3, T4, T5>>> action, Func<TParam, IValidationResult> validatorFunction) => AddToValidatorCache(action, validatorFunction);
        public void Register<TOwner, TParam, T1, T2, T3, T4, T5, T6>(Expression<Func<TOwner, Action<T1, T2, T3, T4, T5, T6>>> action, Func<TParam, IValidationResult> validatorFunction) => AddToValidatorCache(action, validatorFunction);
        public void Register<TOwner, TParam, T1, T2, T3, T4, T5, T6, T7>(Expression<Func<TOwner, Action<T1, T2, T3, T4, T5, T6, T7>>> action, Func<TParam, IValidationResult> validatorFunction) => AddToValidatorCache(action, validatorFunction);
        public void Register<TOwner, TParam, T1, T2, T3, T4, T5, T6, T7, T8>(Expression<Func<TOwner, Action<T1, T2, T3, T4, T5, T6, T7, T8>>> action, Func<TParam, IValidationResult> validatorFunction) => AddToValidatorCache(action, validatorFunction);
        public void Register<TOwner, TParam, T1, T2, T3, T4, T5, T6, T7, T8, T9>(Expression<Func<TOwner, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>>> action, Func<TParam, IValidationResult> validatorFunction) => AddToValidatorCache(action, validatorFunction);
        public void Register<TOwner, TParam, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Expression<Func<TOwner, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>> action, Func<TParam, IValidationResult> validatorFunction) => AddToValidatorCache(action, validatorFunction);
        public void Register<TOwner, TParam, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Expression<Func<TOwner, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>>> action, Func<TParam, IValidationResult> validatorFunction) => AddToValidatorCache(action, validatorFunction);
    }
}