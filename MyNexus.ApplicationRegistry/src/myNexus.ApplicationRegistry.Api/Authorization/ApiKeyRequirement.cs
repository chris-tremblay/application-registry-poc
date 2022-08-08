using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Linq;

namespace MyNexus.ApplicationRegistry.Web.Authorization
{
    public class ApiKeyRequirement : IAuthorizationRequirement
    {
        public const string ApiKeyHeaderName = "mnc-registry-api-key";

        public ApiKeyRequirement(IEnumerable<string> apiKeys)
        {
            ApiKeys = apiKeys?.ToList() ?? new List<string>();
        }

        public IReadOnlyList<string> ApiKeys { get; }
    }
}