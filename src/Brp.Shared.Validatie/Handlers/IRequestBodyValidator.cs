namespace Brp.Shared.Validatie.Handlers;

public interface IRequestBodyValidator
{
    FluentValidation.Results.ValidationResult ValidateRequestBody(string requestBody);
}
