namespace Accelerator.Core.ApplicationServices.Services
{
    public interface IPropertyCheckerService
    {
        bool TypeHasProperties<T>(string? fields);
    }
}
