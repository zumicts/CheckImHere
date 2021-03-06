using System.Net.Http;
using Portable.FluentRest.Deserializers;
using Portable.FluentRest.Http;

namespace Portable.FluentRest.Extensions
{
    public static class FluentRestExtensions
    {
        public static T Content<T>(this T restObject, object value) where T : RestClient
        {
            restObject.RequestContent = value;
            return restObject;
        }

        public static T Delete<T>(this T restObject) where T : RestClient
        {
            restObject.Method = HttpMethod.Delete;
            return restObject;
        }

        public static T Deserializer<T>(
            this T restObject,
            string contentType,
            IDeserializer deserializer) where T : RestClient
        {
            restObject.ContentHandlers[contentType] = deserializer;
            return restObject;
        }

        public static T Fake<T>(this T restObject, HttpResponseMessage response) where T : RestClient
        {
            var handler = restObject.HttpHandler as QueueFakeResponseHandler;
            if (handler == null)
            {
                handler = new QueueFakeResponseHandler();
                restObject.Handler(handler);
            }
            handler.Enqueue(response);
            return restObject;
        }

        public static T Get<T>(this T restObject) where T : RestClient
        {
            restObject.Method = HttpMethod.Get;
            return restObject;
        }

        public static T Handler<T>(this T restObject, HttpMessageHandler value) where T : RestClient
        {
            restObject.HttpHandler = value;
            return restObject;
        }

        public static T Head<T>(this T restObject) where T : RestClient
        {
            restObject.Method = HttpMethod.Head;
            return restObject;
        }

        public static T Header<T>(this T restObject, string name, string value) where T : RestClient
        {
            restObject.Headers[name] = value;
            return restObject;
        }

        public static T Parameter<T>(this T restObject, string name, string value) where T : RestClient
        {
            restObject.Parameters[name] = value;
            return restObject;
        }

        public static T Post<T>(this T restObject) where T : RestClient
        {
            restObject.Method = HttpMethod.Post;
            return restObject;
        }

        public static T Put<T>(this T restObject) where T : RestClient
        {
            restObject.Method = HttpMethod.Put;
            return restObject;
        }

        public static T Query<T>(this T restObject, string name, object value) where T : RestClient
        {
            restObject.QueryParameters[name] = value;
            return restObject;
        }

        public static T Segment<T>(this T restObject, string name, string value) where T : RestClient
        {
            restObject.UrlSegments[name] = value;
            return restObject;
        }

        public static T Url<T>(this T restObject, string url) where T : RestClient
        {
            restObject.Url = url;
            return restObject;
        }
    }
}