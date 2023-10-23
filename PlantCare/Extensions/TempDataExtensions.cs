using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;

namespace PlantCare.Extensions;

/// <summary>
/// Extension methods for ITempDataDictionary.
/// </summary>
public static class TempDataExtensions
{
    /// <summary>
    /// Serialize object to string and create key/value pair in temp dictionary.
    /// </summary>
    /// <typeparam name="T">Type of passed value.</typeparam>
    /// <param name="tempData">Temp dictionary where value will be stored.</param>
    /// <param name="key">Key by which value can be retrieved from the temp dictionary.</param>
    /// <param name="value">Value which will be stored in temp dictionary.</param>
    public static void Set<T>(this ITempDataDictionary tempData, string key, T value) where T : class
    {
        tempData[key] = JsonConvert.SerializeObject(value);
    }

    /// <summary>
    /// Try to get value from the temp dictionary.
    /// If value present, deserialize it to type T and return it.
    /// If not, null is returned.
    /// </summary>
    /// <typeparam name="T">Initial type of stored object.</typeparam>
    /// <param name="tempData">Temp data where value stored.</param>
    /// <param name="key">Key by which value can be retrieved from the temp dictionary.</param>
    /// <returns>Null or deserialized value of type T</returns>
    public static T Get<T>(this ITempDataDictionary tempData, string key) where T : class
    {
        tempData.TryGetValue(key, out object obj);
        return obj == null ? null : JsonConvert.DeserializeObject<T>((string)obj);
    }
}