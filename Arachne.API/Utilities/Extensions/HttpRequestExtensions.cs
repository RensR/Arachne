using System.IO;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Arachne.API.Utilities.Extensions
{
    public static class HttpRequestExtension
    {
        private static readonly JsonSerializerSettings Settings =
            new JsonSerializerSettings { MissingMemberHandling = MissingMemberHandling.Error };
        
        public static T ReadBody<T>(this HttpRequest httpRequest)
        {
            using var reader = new StreamReader(httpRequest.Body);
            var obj = JsonConvert.DeserializeObject(reader.ReadToEnd(), typeof(T), Settings);
            return (T)obj;
        }
    }
}