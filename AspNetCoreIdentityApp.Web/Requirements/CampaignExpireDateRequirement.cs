using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace AspNetCoreIdentityApp.Web.Requirements
{
    public class CampaignExpireDateRequirement: IAuthorizationRequirement
    {
    }

    public class ExchangeExpireRequirementHandler : AuthorizationHandler<CampaignExpireDateRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CampaignExpireDateRequirement requirement)
        {         
            if (!context.User.HasClaim(x => x.Type == "CampaignExpireDate"))
            {
                context.Fail();
                return Task.CompletedTask;
            }

            Claim exchangeExpireDate = context.User.FindFirst("CampaignExpireDate")!;

            if(DateTime.Now > Convert.ToDateTime(exchangeExpireDate.Value)) 
            { 
                context.Fail();
                return Task.CompletedTask;
            }

            context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}
