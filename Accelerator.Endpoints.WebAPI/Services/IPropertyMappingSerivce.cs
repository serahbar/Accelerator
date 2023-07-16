namespace Accelerator.Endpoints.WebAPI.Services
{
    public interface IPropertyMappingSerivce
    {
        Dictionary<string, PropertyMappingValue> GetPropertyMapping<TSource, TDestination>();
        bool ValidMappingExistsFor<TSource, TDestination>(string fields);
    }
}
