using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using mvc.Data;
using mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Authorization
{
    public class FeedbackAdminAuthHandler
        : AuthorizationHandler<OperationAuthorizationRequirement, EmergingTechnologiesFeedback>
    {
        protected override Task HandleRequirementAsync(
                                      AuthorizationHandlerContext context,
                            OperationAuthorizationRequirement requirement,
                             EmergingTechnologiesFeedback resource)
        {
            if (context.User == null)
            {
                return Task.CompletedTask;
            }

            // Administrators can do anything.
            if (context.User.IsInRole(Constants.ContactAdministratorsRole))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
