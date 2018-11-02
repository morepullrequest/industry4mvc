using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mvc.Data;
using mvc.Models;

namespace mvc.Controllers
{
    public class EmergingTechnologiesFeedbacksController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public EmergingTechnologiesFeedbacksController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: EmergingTechnologiesFeedbacks
        public async Task<IActionResult> Index()
        {
            return View(await _context.emergingTechnologiesFeedbacks.ToListAsync());
        }

        // GET: EmergingTechnologiesFeedbacks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emergingTechnologiesFeedback = await _context.emergingTechnologiesFeedbacks
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
            emergingTechnologiesFeedback.Username = _userManager.GetUserName(User);
            emergingTechnologiesFeedback.OwnerID = _userManager.GetUserId(User);
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
                emergingTechnologiesFeedback.Username = _userManager.GetUserName(User);
                emergingTechnologiesFeedback.OwnerID = _userManager.GetUserId(User);
                _context.Add(emergingTechnologiesFeedback);
                await _context.SaveChangesAsync();
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

            var emergingTechnologiesFeedback = await _context.emergingTechnologiesFeedbacks.FindAsync(id);
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
            if (id != emergingTechnologiesFeedback.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emergingTechnologiesFeedback);
                    await _context.SaveChangesAsync();
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

            var emergingTechnologiesFeedback = await _context.emergingTechnologiesFeedbacks
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
            var emergingTechnologiesFeedback = await _context.emergingTechnologiesFeedbacks.FindAsync(id);
            _context.emergingTechnologiesFeedbacks.Remove(emergingTechnologiesFeedback);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmergingTechnologiesFeedbackExists(int id)
        {
            return _context.emergingTechnologiesFeedbacks.Any(e => e.ID == id);
        }
    }
}
