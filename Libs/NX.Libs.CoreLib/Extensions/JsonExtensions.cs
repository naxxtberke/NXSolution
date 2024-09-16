using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace NX.Libs.CoreLib.Extensions
{
    public static class JsonExtensions
    {
        private static readonly JsonSerializerOptions _jsonSerializerOptions = new()
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            WriteIndented = true
        };

        /// <summary>
        /// JSON stringini belirli bir türdeki nesneye dönüştürür.
        /// </summary>
        /// <typeparam name="T">Dönüştürülmek istenen nesne türü.</typeparam>
        /// <param name="json">JSON stringi.</param>
        /// <returns>Dönüştürülmüş nesne.</returns>
        public static T? DeserializeJson<T>(this string json)
        {
            if (string.IsNullOrWhiteSpace(json))
                throw new ArgumentException("JSON stringi boş olamaz.", nameof(json));

            try
            {
                return JsonSerializer.Deserialize<T>(json, _jsonSerializerOptions);
            }
            catch (JsonException ex)
            {
                throw new InvalidOperationException("JSON deserialization hatası.", ex);
            }
        }

        /// <summary>
        /// Verilen nesneyi JSON stringine dönüştürür.
        /// </summary>
        /// <param name="obj">JSON stringine dönüştürülmek istenen nesne.</param>
        /// <returns>Dönüştürülmüş JSON stringi.</returns>
        public static string SerializeToJson(this object obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj), "Nesne null olamaz.");

            try
            {
                return JsonSerializer.Serialize(obj, _jsonSerializerOptions);
            }
            catch (JsonException ex)
            {
                throw new InvalidOperationException("JSON serialization hatası.", ex);
            }
        }

        /// <summary>
        /// JSON stringinden belirli bir alanın değerini alır.
        /// </summary>
        /// <param name="json">JSON stringi.</param>
        /// <param name="propertyName">Alınmak istenen alan adı.</param>
        /// <returns>Belirtilen alanın değeri.</returns>
        public static string GetPropertyValue(this string json, string propertyName)
        {
            if (string.IsNullOrWhiteSpace(json))
                throw new ArgumentException("JSON stringi boş olamaz.", nameof(json));

            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Property name boş olamaz.", nameof(propertyName));

            try
            {
                using JsonDocument doc = JsonDocument.Parse(json);
                if (doc.RootElement.TryGetProperty(propertyName, out JsonElement value))
                    return value.ToString();
                else
                    throw new ArgumentException($"JSON içinde '{propertyName}' adında bir alan bulunamadı.");
            }
            catch (JsonException ex)
            {
                throw new InvalidOperationException("JSON parsing hatası.", ex);
            }
        }
    }
}
