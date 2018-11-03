using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mvc.Data;
using mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Controllers
{
    [Authorize]
    public class CompanyFeedbacksController : BaseController
    {
        public CompanyFeedbacksController(
            ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager)
            : base(context, authorizationService, userManager)
        {

        }

        // GET: CompanyFeedbacks
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await Context.companyFeedbacks.ToListAsync());
        }

        // GET: CompanyFeedbacks/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyAndOrganizationFeedback = await Context.companyFeedbacks
                .FirstOrDefaultAsync(m => m.ID == id);
            if (companyAndOrganizationFeedback == null)
            {
                return NotFound();
            }

            return View(companyAndOrganizationFeedback);
        }

        // GET: CompanyFeedbacks/Create
        public IActionResult Create()
        {
            CompanyAndOrganizationFeedback feedback = new CompanyAndOrganizationFeedback();
            feedback.Username = UserManager.GetUserName(User);
            feedback.OwnerID = UserManager.GetUserId(User);
            return View(feedback);
        }

        // POST: CompanyFeedbacks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Date,Username,Heading,Rating,Feedback,Agree,Disagree,CompanyName,OwnerID")] CompanyAndOrganizationFeedback feedback)
        {

            if (ModelState.IsValid)
            {
                feedback.Date = DateTime.Now;
                feedback.Username = UserManager.GetUserName(User);
                feedback.OwnerID = UserManager.GetUserId(User);
                if (!UserManager.GetUserName(User).Equals("manager@example.com"))
                {
                    feedback.Agree = 0;
                    feedback.Disagree = 0;
                }
                Context.Add(feedback);
                await Context.SaveChangesAsync();
                return Redirect("/Home/Organizations#feedback-wrapper");
            }
            return View(feedback);
        }

        // GET: CompanyFeedbacks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (!UserManager.GetUserName(User).Equals("manager@example.com"))
            {
                return new ChallengeResult();
            }
            var companyAndOrganizationFeedback = await Context.companyFeedbacks.FindAsync(id);
            if (companyAndOrganizationFeedback == null)
            {
                return NotFound();
            }
            companyAndOrganizationFeedback.Date = DateTime.Now;
            return View(companyAndOrganizationFeedback);
        }

        // POST: CompanyFeedbacks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Date,Username,Heading,Rating,Feedback,Agree,Disagree,CompanyName,OwnerID")] CompanyAndOrganizationFeedback companyAndOrganizationFeedback)
        {
            if (!UserManager.GetUserName(User).Equals("manager@example.com"))
            //if (User.IsInRole(Constants.ManagersRole))
            {
                return new ChallengeResult();
            }

            if (id != companyAndOrganizationFeedback.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var oriFeedback = await Context.companyFeedbacks.FindAsync(id);
                    oriFeedback.Date = DateTime.Now;
                    oriFeedback.Heading = companyAndOrganizationFeedback.Heading;
                    oriFeedback.Rating = companyAndOrganizationFeedback.Rating;
                    oriFeedback.Agree = companyAndOrganizationFeedback.Agree;
                    oriFeedback.Disagree = companyAndOrganizationFeedback.Disagree;
                    oriFeedback.CompanyName = companyAndOrganizationFeedback.CompanyName;

                    Context.Update(oriFeedback);
                    await Context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyAndOrganizationFeedbackExists(companyAndOrganizationFeedback.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Redirect("/Home/Organizations#feedback-wrapper");
            }
            return View(companyAndOrganizationFeedback);
        }

        // GET: CompanyFeedbacks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (!UserManager.GetUserName(User).Equals("manager@example.com"))
            //if (User.IsInRole(Constants.ManagersRole))
            {
                return new ChallengeResult();
            }
            if (id == null)
            {
                return NotFound();
            }

            var companyAndOrganizationFeedback = await Context.companyFeedbacks
                .FirstOrDefaultAsync(m => m.ID == id);
            if (companyAndOrganizationFeedback == null)
            {
                return NotFound();
            }

            return View(companyAndOrganizationFeedback);
        }

        // POST: CompanyFeedbacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!UserManager.GetUserName(User).Equals("manager@example.com"))
            //if (User.IsInRole(Constants.ManagersRole))
            {
                return new ChallengeResult();
            }
            var companyAndOrganizationFeedback = await Context.companyFeedbacks.FindAsync(id);
            Context.companyFeedbacks.Remove(companyAndOrganizationFeedback);
            await Context.SaveChangesAsync();
            return Redirect("/Home/Organizations#feedback-wrapper");
        }

        private bool CompanyAndOrganizationFeedbackExists(int id)
        {
            return Context.companyFeedbacks.Any(e => e.ID == id);
        }
    }
}
