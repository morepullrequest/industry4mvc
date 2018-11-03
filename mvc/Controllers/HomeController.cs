using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc.Data;
using mvc.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace mvc.Controllers
{
    [AllowAnonymous]
    public class HomeController : BaseController
    {
        public HomeController(
            ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager)
            : base(context, authorizationService, userManager)
        {

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public async Task<IActionResult> Technologies()
        {
            string cookie = HttpContext.Request.Cookies[".AspNetCore.Identity.Application"];
            String hash = "";
            if (!String.IsNullOrEmpty(cookie))
            {
                MD5 md5 = MD5.Create();
                byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(cookie));
                StringBuilder res = new StringBuilder();
                for(int i = 0; i < data.Length; i++)
                {
                    res.Append(data[i].ToString("x2"));
                }
                 hash= res.ToString();
            }

            ViewData["cookie"] = hash;

            IQueryable<EmergingTechnologiesFeedback> feedbacks = from f in Context.emergingTechnologiesFeedbacks
                                                                 select f;

            return View(await feedbacks.OrderByDescending(f => f.Date).ToListAsync());
        }

        public async Task<IActionResult> Organizations()
        {
            IQueryable<CompanyAndOrganizationFeedback> feedbacks = from f in Context.companyFeedbacks
                                                                   select f;
            return View(await feedbacks.OrderByDescending(f => f.Date).ToListAsync());
        }

        public IActionResult Worldmap()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
