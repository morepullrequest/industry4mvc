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
    public class EmergingTechnologiesFeedbacksController : BaseController
    {
        public EmergingTechnologiesFeedbacksController(
            ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager)
            : base(context, authorizationService, userManager)
        {

        }


        // GET: EmergingTechnologiesFeedbacks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emergingTechnologiesFeedback = await Context.emergingTechnologiesFeedbacks
                .FirstOrDefaultAsync(m => m.ID == id);
            if (emergingTechnologiesFeedback == null)
            {
                return NotFound();
            }

            return View(emergingTechnologiesFeedback);
        }

        // GET: EmergingTechnologiesFeedbacks/Create
        public IActionResult Create()
        {
            EmergingTechnologiesFeedback emergingTechnologiesFeedback = new EmergingTechnologiesFeedback();
            emergingTechnologiesFeedback.Username = UserManager.GetUserName(User);
            emergingTechnologiesFeedback.OwnerID = UserManager.GetUserId(User);
            return View(emergingTechnologiesFeedback);
        }

        // POST: EmergingTechnologiesFeedbacks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Date,Username,Heading,Rating,Feedback,Agree,Disagree,EmergingTechnologiesName")] EmergingTechnologiesFeedback emergingTechnologiesFeedback)
        {
            emergingTechnologiesFeedback.Date = DateTime.Now;
            emergingTechnologiesFeedback.Username = UserManager.GetUserName(User);
            emergingTechnologiesFeedback.OwnerID = UserManager.GetUserId(User);

            if (ModelState.IsValid)
            {
                emergingTechnologiesFeedback.Username = UserManager.GetUserName(User);
                emergingTechnologiesFeedback.OwnerID = UserManager.GetUserId(User);
                if (!UserManager.GetUserName(User).Equals("manager@example.com"))
                {
                    emergingTechnologiesFeedback.Agree = 0;
                    emergingTechnologiesFeedback.Disagree = 0;
                }

                Context.Add(emergingTechnologiesFeedback);
                await Context.SaveChangesAsync();
                return Redirect("/Home/Technologies#feedback-wrapper");
            }

            return View(emergingTechnologiesFeedback);
        }

        // GET: EmergingTechnologiesFeedbacks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            if (!UserManager.GetUserName(User).Equals("manager@example.com"))
            //if (User.IsInRole(Constants.ManagersRole))
            {
                return new ChallengeResult();
            }

            var emergingTechnologiesFeedback = await Context.emergingTechnologiesFeedbacks.FindAsync(id);


            if (emergingTechnologiesFeedback == null)
            {
                return NotFound();
            }
            emergingTechnologiesFeedback.Date = DateTime.Now;
            return View(emergingTechnologiesFeedback);
        }

        // POST: EmergingTechnologiesFeedbacks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Date,Username,Heading,Rating,Feedback,Agree,Disagree,EmergingTechnologiesName")] EmergingTechnologiesFeedback emergingTechnologiesFeedback)
        {
            if (!UserManager.GetUserName(User).Equals("manager@example.com"))
            //if (User.IsInRole(Constants.ManagersRole))
            {
                return new ChallengeResult();
            }

            if (id != emergingTechnologiesFeedback.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var oriFeedback = await Context.emergingTechnologiesFeedbacks.FindAsync(id);
                    oriFeedback.Date = DateTime.Now;
                    oriFeedback.Heading = emergingTechnologiesFeedback.Heading;
                    oriFeedback.Rating = emergingTechnologiesFeedback.Rating;
                    oriFeedback.Agree = emergingTechnologiesFeedback.Agree;
                    oriFeedback.Disagree = emergingTechnologiesFeedback.Disagree;
                    oriFeedback.EmergingTechnologiesName = emergingTechnologiesFeedback.EmergingTechnologiesName;

                    Context.Update(oriFeedback);
                    await Context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmergingTechnologiesFeedbackExists(emergingTechnologiesFeedback.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Redirect("/Home/Technologies");
            }
            return View(emergingTechnologiesFeedback);
        }

        // GET: EmergingTechnologiesFeedbacks/Delete/5
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

            var emergingTechnologiesFeedback = await Context.emergingTechnologiesFeedbacks
                .FirstOrDefaultAsync(m => m.ID == id);

            if (emergingTechnologiesFeedback == null)
            {
                return NotFound();
            }

            return View(emergingTechnologiesFeedback);
        }

        // POST: EmergingTechnologiesFeedbacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!UserManager.GetUserName(User).Equals("manager@example.com"))
            //if (User.IsInRole(Constants.ManagersRole))
            {
                return new ChallengeResult();
            }

            var emergingTechnologiesFeedback = await Context.emergingTechnologiesFeedbacks.FindAsync(id);

            Context.emergingTechnologiesFeedbacks.Remove(emergingTechnologiesFeedback);
            await Context.SaveChangesAsync();
            return Redirect("/Home/Technologies");
        }

        private bool EmergingTechnologiesFeedbackExists(int id)
        {
            return Context.emergingTechnologiesFeedbacks.Any(e => e.ID == id);
        }


    }
}
