using System.Reflection;

namespace Accelerator.Framework.Extentions
{
    public static class PropertyExtention<T> where T : class
    {
        public static List<string> GetClassProperty()
        {
            List<string> result = new List<string>();
            PropertyInfo[] propertyInfos;
            propertyInfos = typeof(T).GetProperties();
            Array.Sort(propertyInfos,
                delegate (PropertyInfo propertyInfo1, PropertyInfo propertyInfo2)
                { 
                    return propertyInfo1.Name.CompareTo(propertyInfo2.Name); 
                });
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                result.Add(propertyInfo.Name);
            }

            return result;
        }
    }
}
