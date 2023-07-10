namespace Accelerator.Endpoints.WebAPI.Services
{
    public interface IPropertyMappingSerivce
    {
        Dictionary<string, PropertyMappingValue> GetPropertyMapping<TSource, TDestination>();
        bool ValidMappingExists<TSource, TDestination>(string fields);
    }
}
