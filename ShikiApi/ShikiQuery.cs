using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using Newtonsoft.Json;
using ShikiApi.JSONWriter;

namespace ShikiApi
{
    internal static class ShikiQuery
    {

        #region Get

        internal static string GET(string url, Shikimori user, params KeyValuePair<string, string>[] parametrs)
        {
            if (user == null)
                throw new Exception("Shiki api is null");

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + user.AccessToken);
                httpClient.DefaultRequestHeaders.Add("User-Agent", user.Application.Name);

                if (parametrs.Length <= 0)
                    return httpClient.GetStringAsync(url).Result;

                var builder = new UriBuilder(url);
                var query = new StringBuilder();
                foreach (var keyValuePair in parametrs)
                {
                    query.Append(keyValuePair.Key);
                    query.Append("=");
                    query.Append(keyValuePair.Value);
                    query.Append("&");
                }

                query.Remove(query.Length - 1, 1);
                builder.Query = query.ToString();
                url = builder.ToString();

                return httpClient.GetStringAsync(url).Result;
            }
        }

        internal static T GET<T>(string url, Shikimori user, params KeyValuePair<string, string>[] parametrs)
        {
            if (user == null)
                throw new Exception("Shiki api is null");

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + user.AccessToken);
                httpClient.DefaultRequestHeaders.Add("User-Agent", user.Application.Name);

                if (parametrs.Length > 0)
                {
                    var builder = new UriBuilder(url);
                    var query = new StringBuilder();
                    foreach (var keyValuePair in parametrs)
                    {
                        query.Append(keyValuePair.Key);
                        query.Append("=");
                        query.Append(keyValuePair.Value);
                        query.Append("&");
                    }

                    query.Remove(query.Length - 1, 1);
                    builder.Query = query.ToString();
                    url = builder.ToString();
                }

                var response = httpClient.GetStringAsync(url).Result;
                var settings = new JsonSerializerSettings() { Converters = new[] { new PersonGrouppedRoleConverter(), } };
                var result = JsonConvert.DeserializeObject<T>(response, settings);
                return result;
            }
        }

        #endregion

        #region Post

        internal static T POST<T>(string url, StringContent args, Shikimori user)
        {
            if (user == null)
                throw new Exception("Shiki api is null");

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + user.AccessToken);
                httpClient.DefaultRequestHeaders.Add("User-Agent", user.Application.Name);

                var response = httpClient.PostAsync(url, args).Result.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<T>(response);
                return result;
            }
        }

        internal static T POST<T>(string url, Shikimori user)
        {
            return POST<T>(url, user, new KeyValuePair<string, string>[0]);
        }

        internal static T POST<T>(string url, Shikimori user, params KeyValuePair<string, string>[] args)
        {

            if (user == null)
                throw new Exception("Shiki api is null");

            var content = new StringContent(args.ConvertToJsonString(), Encoding.UTF8, "application/json");

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + user.AccessToken);
                httpClient.DefaultRequestHeaders.Add("User-Agent", user.Application.Name);

                var response = httpClient.PostAsync(url, content).Result.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<T>(response);
                return result;
            }
        }

        #endregion

        #region Put

        internal static T PUT<T>(string url, Shikimori user, StringContent args)
        {
            if (user == null)
                throw new Exception("Shiki api is null");

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + user.AccessToken);
                httpClient.DefaultRequestHeaders.Add("User-Agent", user.Application.Name);

                var response = httpClient.PutAsync(url, args).Result.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<T>(response);
                return result;
            }
        }

        internal static T PUT<T>(string url, Shikimori user, params KeyValuePair<string, string>[] parametrs)
        {
            if (user == null)
                throw new Exception("Shiki api is null");

            var content = new StringContent(parametrs.ConvertToJsonString(), Encoding.UTF8, "application/json");

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + user.AccessToken);
                httpClient.DefaultRequestHeaders.Add("User-Agent", user.Application.Name);

                var response = httpClient.PutAsync(url, content).Result.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<T>(response);
                return result;
            }
        }

        #endregion

        #region Delete

        internal static HttpStatusCode DELETE(string url, Shikimori user = null)
        {
            if (user == null)
                throw new Exception("Shiki api is null");

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + user.AccessToken);
                httpClient.DefaultRequestHeaders.Add("User-Agent", user.Application.Name);

                var response = httpClient.DeleteAsync(url);
                return response.Result.StatusCode;
            }
        }

        #endregion

    }
}