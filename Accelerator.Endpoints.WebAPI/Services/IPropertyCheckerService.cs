namespace Accelerator.Endpoints.WebAPI.Services
{
    public interface IPropertyCheckerService
    {
        bool TypeHasProperties<T>(string? fields);
    }
}
