using Gs.TestingBugManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;

namespace Gs.TestingBugManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext context = new AppDbContext();

        public IActionResult Index()
        {
            var result = context.BugManagement.Include(b => b.Bug).Include(b => b.Enterprise).Include(b => b.Environment);
            return View(result.ToList());
        }

        public IActionResult View()
        {
            var result = context.BugManagement.Include(b => b.Bug).Include(b => b.Enterprise).Include(b => b.Environment);
            return View("View", result);
        }


        public IActionResult Create()
        {
            ViewData["BugID"] = new SelectList(context.Set<Bug>(), "BugID", "BugState");
            ViewData["EnterpriseID"] = new SelectList(context.Set<Enterprise>(), "EnterpriseID", "EnterpriseType");
            ViewData["EnvironmentID"] = new SelectList(context.Set<Environment>(), "EnvironmentID", "EnvironmentType");
            return View("BugManagerCreate");
        }

        public IActionResult BugManagerCreate(BugManagement bugManagement)
        {
            context.Add(bugManagement);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        // GET: BugManagements/Edit/5
        public ActionResult Edit(int? id)
        {
            var bugEdit = context.BugManagement.Find(id);

            ViewData["BugID"] = new SelectList(context.Set<Bug>(), "BugID", "BugState");
            ViewData["EnterpriseID"] = new SelectList(context.Set<Enterprise>(), "EnterpriseID", "EnterpriseType");
            ViewData["EnvironmentID"] = new SelectList(context.Set<Environment>(), "EnvironmentID", "EnvironmentType");

            return View("BugManagerEdit", bugEdit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BugManagerEdit(BugManagement bugManagement)
        {
    
            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(bugManagement);
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {

                    return NotFound();

                }          
            }
            return RedirectToAction(nameof(Index));
        }
            public IActionResult Delete(int id)
            {
                var bugToRemove = context.BugManagement.Find(id);
                context.BugManagement.Remove(bugToRemove);
                context.SaveChanges();

                return View("View", context.BugManagement.ToList());
            }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
