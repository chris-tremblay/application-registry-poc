using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NotesSample.Web.Configuration;
using NotesSample.Web.Models;

namespace NotesSample.Web
{
    internal class MicroApplicationRegistryClient : IMicroApplicationRegistryClient
    {
        private readonly HttpClient client;
        private readonly MicroApplicationConfiguration microAppConfig;

        /// <summary>
        ///   Initializes a new instance of the <see cref="MicroApplicationRegistryClient"/> class.
        /// </summary>
        /// <param name="config">The <see cref="IConfiguration"/> containing the application configuration.</param>
        /// <param name="client">The pre-configured <see cref="HttpClient"/>.</param>
        public MicroApplicationRegistryClient(IConfiguration config, HttpClient client)
        {
            microAppConfig = config.GetSection(MicroApplicationConfiguration.SectionName).Get<MicroApplicationConfiguration>();

            this.client = client;
        }

        public string BaseUrl => client.BaseAddress.ToString();

        /// <summary>
        ///   Get the registration Json Object.
        /// </summary>
        /// <param name="microAppConfig">The <see cref="MicroApplicationConfiguration"/> object to register.</param>
        /// <returns>The json object.</returns>
        public static string GetRegistrationJson(MicroApplicationConfiguration microAppConfig)
        {
            var data = new JObject();

            data.Add("fqan", JToken.FromObject(microAppConfig.Fqan));
            data.Add("appElementName", JToken.FromObject(microAppConfig.AppElementName));
            data.Add("scriptUrls", IngressUrlsWithVersion(microAppConfig, microAppConfig.ScriptUrls));
            data.Add("styleUrls", IngressUrlsWithVersion(microAppConfig, microAppConfig.StyleUrls));
            data.Add("widgets", JArray.FromObject(microAppConfig.Widgets ?? Array.Empty<Widget>()));

            return data.ToString();
        }

        /// <inheritdoc/>
        public async Task<HttpResponseMessage> Get(string relativeUrl)
            => await client.GetAsync(relativeUrl);

        /// <inheritdoc/>
        public async Task<IEnumerable<string>> GetCorsAllowedOrigins()
            => JsonConvert.DeserializeObject<IEnumerable<string>>(await client.GetStringAsync($"cors/allowed-origins"));

        public async Task<string> GetElementDefinition(string elementName)
            => await client.GetStringAsync($"elements/{elementName}.json");

        /// <inheritdoc/>
        public void RegisterMicroApplication()
        {
            var response = client.PutAsync($"applications/{microAppConfig.Fqan}", new StringContent(GetRegistrationJson(microAppConfig), Encoding.UTF8, "application/json")).Result;

            response.EnsureSuccessStatusCode();
        }

        public void RegisterMicroApplicationProxy(string serviceDomain)
        {
            var response = client.PutAsync($"service-domains?ServiceDomain={serviceDomain}", new StringContent(string.Empty)).Result;

            response.EnsureSuccessStatusCode();
        }

        private static string FullUrl(string baseUrl, string path)
            => string.IsNullOrEmpty(baseUrl)
                ? path
                : baseUrl.TrimEnd('/') + "/" + path.TrimStart('/');

        private static string GetFilePathWithHash(string wwwroot, string p)
        {
            var parts = p.Split('/');
            var dir = wwwroot;

            for (int i = 0; i < parts.Length - 2; i++)
            {
                if (parts[i] != string.Empty)
                    dir = Path.Join(dir, parts[i]);
            }

            var pattern = GetHashPattern(parts.Last());
            var filePath = Directory.GetFiles(dir).First(f => pattern.IsMatch(f));
            parts[parts.Length - 1] = Path.GetFileName(filePath);

            return string.Join('/', parts);
        }

        private static Regex GetHashPattern(string name)
        {
            var replacer = new Regex("\\.[^.]+$");
            var patternString = replacer.Replace(name, ".*$0") + "$";

            return new Regex(patternString);
        }

        private static JToken IngressUrlsWithVersion(MicroApplicationConfiguration microAppConfig, string[] urls)
        {
            var wwwroot = Path.Join(Directory.GetCurrentDirectory(), "wwwroot");

            // Incorporate base url and figure out file names with hashes.

            var fullUrls = urls.Select(p => GetFilePathWithHash(wwwroot, p))
                .Select(p => FullUrl(microAppConfig.IngressBaseUrl, p))
                .ToArray();

            return JArray.FromObject(fullUrls);
        }
    }
}