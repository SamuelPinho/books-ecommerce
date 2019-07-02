using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Negocio
{

    public class RoleRequirement : IAuthorizationRequirement
    {
        public string Role { get; set; }

        public RoleRequirement(string role)
        {
            Role = role;
        }
    }

    public class RolePolicy : AuthorizationHandler<RoleRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleRequirement requirement)
        {
            var user = context.User;
            var role = user.Claims.Where(c => c.Type == ClaimTypes.Role);
            if(!user.HasClaim(c => c.Type == "usr_papel_id"))
            {
                return Task.CompletedTask;
            }
            var papel = user.FindFirst("usr_papel_id").Value;

            return Task.CompletedTask;


        }
    }
}
