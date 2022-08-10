using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using MyNexus.ApplicationRegistry.Web.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MyNexus.ApplicationRegistry.Web.Authorization
{
    /// <summary>
    ///   Handler for the <see cref="ApiKeyRequirement"/> for the <see cref="AuthorizationConfiguration.ApiPolicyName"/> policy.
    /// </summary>
    public class ApiKeyRequirementHandler : AuthorizationHandler<ApiKeyRequirement>
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public ApiKeyRequirementHandler(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ApiKeyRequirement requirement)
        {
            SucceedRequirementIfApiKeyPresentAndValid(context, requirement);
            if (context.HasFailed)
            {
            }

            return Task.CompletedTask;
        }

        private void SucceedRequirementIfApiKeyPresentAndValid(AuthorizationHandlerContext context, ApiKeyRequirement requirement)
        {
            context.Succeed(requirement);

            /*if (context.Resource is Endpoint endpoint)
            //{
            //    var apiKey = httpContextAccessor.HttpContext.Request.Headers[ApiKeyRequirement.ApiKeyHeaderName].FirstOrDefault();

            //    if (apiKey != null && requirement.ApiKeys.Any(requiredApiKey => apiKey == requiredApiKey))
            //    {
            //        context.Succeed(requirement);
            //    }
            //    else
            //    {
            //        context.Fail();
            //    }
            //}*/
        }
    }
}