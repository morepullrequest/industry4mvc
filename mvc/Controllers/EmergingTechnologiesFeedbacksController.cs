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

        // GET: EmergingTechnologiesFeedbacks
        public async Task<IActionResult> Index()
        {
            return View(await Context.emergingTechnologiesFeedbacks.ToListAsync());
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
        public async Task<IActionResult> Create([Bind("ID,ReleaseDate,Username,Heading,Rating,Feedback,Agree,Disagree,EmergingTechnologiesName,OwnerID")] EmergingTechnologiesFeedback emergingTechnologiesFeedback)
        {
            if (ModelState.IsValid)
            {
                emergingTechnologiesFeedback.Username = UserManager.GetUserName(User);
                emergingTechnologiesFeedback.OwnerID = UserManager.GetUserId(User);
                Context.Add(emergingTechnologiesFeedback);
                await Context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
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

            var isAuth = await AuthorizationService.AuthorizeAsync(User, id, FeedbackOperations.Update);

            if (!isAuth.Succeeded)
            {
                return new ChallengeResult();
            }

            var emergingTechnologiesFeedback = await Context.emergingTechnologiesFeedbacks.FindAsync(id);



            if (emergingTechnologiesFeedback == null)
            {
                return NotFound();
            }
            return View(emergingTechnologiesFeedback);
        }

        // POST: EmergingTechnologiesFeedbacks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ReleaseDate,Username,Heading,Rating,Feedback,Agree,Disagree,EmergingTechnologiesName,OwnerID")] EmergingTechnologiesFeedback emergingTechnologiesFeedback)
        {
            var isAuth = await AuthorizationService.AuthorizeAsync(User, emergingTechnologiesFeedback, FeedbackOperations.Update);

            if (!isAuth.Succeeded)
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
                    Context.Update(emergingTechnologiesFeedback);
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
                return RedirectToAction(nameof(Index));
            }
            return View(emergingTechnologiesFeedback);
        }

        // GET: EmergingTechnologiesFeedbacks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }



            var emergingTechnologiesFeedback = await Context.emergingTechnologiesFeedbacks
                .FirstOrDefaultAsync(m => m.ID == id);

            var isAuth = await AuthorizationService.AuthorizeAsync(User, emergingTechnologiesFeedback, FeedbackOperations.Delete);

            if (!isAuth.Succeeded)
            {
                return new ChallengeResult();
            }

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

            var emergingTechnologiesFeedback = await Context.emergingTechnologiesFeedbacks.FindAsync(id);

            var isAuth = await AuthorizationService.AuthorizeAsync(User, emergingTechnologiesFeedback, FeedbackOperations.Delete);

            if (!isAuth.Succeeded)
            {
                return new ChallengeResult();
            }

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
