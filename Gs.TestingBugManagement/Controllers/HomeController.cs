using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Gs.TestingBugManagement.Models;
using Gs.TestingBugManagement.IOC;
namespace Gs.TestingBugManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext context = new AppDbContext();

        public IActionResult Index()
        {
            var result = context.BugManagement.ToList();
            return View(result);
        }

        public IActionResult View()
        {
            var result = context.BugManagement.ToList();
            return View("View", result);
        }

        public IActionResult Create()
        {
            return View("BugManagerCreate");
        }

        public IActionResult BugManagerCreate(BugManagement bugManagement)
        {
            context.Add(bugManagement);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var bugEdit = context.BugManagement.Find(id);
            return View("BugManagerEdit", bugEdit);
        }

        public IActionResult BugManagerEdit(BugManagement bugManagement)
        {
            var bugEdit = context.BugManagement.Find(bugManagement.BugNumber);
            bugEdit.BugNumber = bugManagement.BugNumber;
            bugEdit.AssignedTo = bugManagement.AssignedTo;
            bugEdit.BugState = bugManagement.BugState;
            bugEdit.CreateDate = bugManagement.CreateDate;
            context.BugManagement.Update(bugEdit);
            context.SaveChanges();

            return View("BugManagerEdit", bugEdit);
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
