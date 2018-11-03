using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Data
{
    public class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider, string testUserPw)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // same password 

                // admin can do anything
                //var adminID = await EnsureUser(serviceProvider, testUserPw, "admin@example.com");
                //await EnsureRole(serviceProvider, adminID, Constants.AdministratorsRole);

                // manager can edit or delete feedback
                var managerID = await EnsureUser(serviceProvider, testUserPw, "manager@example.com");
                await EnsureRole(serviceProvider, managerID, Constants.ManagersRole);

                // common user
                string username = "user@example.com";
                var userId = await EnsureUser(serviceProvider, testUserPw, username);

                SeedDB(context, userId, username);
            }
        }



        private static async Task<string> EnsureUser(IServiceProvider serviceProvider,
            string testUserPw, string UserName)
        {
            var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();
            var user = await userManager.FindByNameAsync(UserName);
            if (user == null)
            {
                user = new IdentityUser { UserName = UserName };
                userManager.CreateAsync(user, testUserPw).Wait();
            }
            return user.Id;
        }

        private static async Task<IdentityResult> EnsureRole(IServiceProvider serviceProvider,
                                                              string uid, string role)
        {

            IdentityResult IR = null;
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

            if (roleManager == null)
            {
                throw new Exception("roleManager null");
            }

            // create role
            if (!await roleManager.RoleExistsAsync(role))
            {
                IR = await roleManager.CreateAsync(new IdentityRole(role));
            }

            // grant role to user
            var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();
            var user = await userManager.FindByIdAsync(uid);

            IR = await userManager.AddToRoleAsync(user, role);

            return IR;
        }

        public static void SeedDB(ApplicationDbContext context, string userId, string username)
        {
            if (!context.emergingTechnologiesFeedbacks.Any())
            {
                context.emergingTechnologiesFeedbacks.AddRange(
                   new EmergingTechnologiesFeedback
                   {
                       Username = username,
                       EmergingTechnologiesName = "Internet of Things",
                       Heading = "What companies are working on IoT",
                       Rating = 4,
                       Feedback = "I know IBM, Apple, Microsoft, Google and Amazon. Are there any other companies?",
                       Agree = 2,
                       Disagree = 0,
                       OwnerID = userId
                   },
                   new EmergingTechnologiesFeedback
                   {
                       Username = username,
                       Heading = "4 AI startups that analyze customer reviews",
                       EmergingTechnologiesName = "Artificial Intelligence",
                       Rating = 3,
                       Feedback = "I know IBM, Apple, Microsoft, Google and Amazon. Are there any other companies?",
                       Agree = 4,
                       Disagree = 2,
                       OwnerID = userId
                   }
                  );
                context.SaveChanges();
            }
            if (!context.companyFeedbacks.Any())
            {
                context.companyFeedbacks.AddRange(
                   new CompanyAndOrganizationFeedback
                   {
                       Username = username,
                       CompanyName = "Google",
                       Heading = "What companies are working on IoT",
                       Rating = 4,
                       Feedback = "I know IBM, Apple, Microsoft, Google and Amazon. Are there any other companies?",
                       Agree = 2,
                       Disagree = 0,
                       OwnerID = userId
                   },
                   new CompanyAndOrganizationFeedback
                   {
                       Username = username,
                       Heading = "4 AI startups that analyze customer reviews",
                       CompanyName = "Google",
                       Rating = 3,
                       Feedback = "I know IBM, Apple, Microsoft, Google and Amazon. Are there any other companies?",
                       Agree = 4,
                       Disagree = 2,
                       OwnerID = userId
                   }
                  );
                context.SaveChanges();
            }


        }
    }
}
