using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using mvc.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace mvc.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<EmergingTechnologiesFeedback> emergingTechnologiesFeedbacks { get; set; }
        public DbSet<CompanyAndOrganizationFeedback> companyFeedbacks { get; set; }
    }
}
