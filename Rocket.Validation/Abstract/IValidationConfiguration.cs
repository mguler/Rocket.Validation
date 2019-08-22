namespace Rocket.Validation.Abstract
{
    public interface IValidationConfiguration
    {
        void Configure(IValidationServiceProvider validationServiceProvider);
    }
}
