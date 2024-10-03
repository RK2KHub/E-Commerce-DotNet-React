using Microsoft.AspNetCore.Http;
using System.Text.Json; // Use System.Text.Json for serialization/deserialization

namespace StationaryBrouchure.Server.Extensions
{
    public static class SessionExtensions
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonSerializer.Serialize(value)); // Use System.Text.Json
        }

        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value); // Use System.Text.Json
        }
    }
}
