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
        public IActionResult Index()
        {

            var context = IoC.AppDbContext;

            var result = context.BugManagement.ToList();
            return View("View", result);

        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View("BugManagerCreate");
        }

        public IActionResult BugManagerCreate(BugManagement bugManagement)
        {
            IoC.AppDbContext.Add(bugManagement);
            IoC.AppDbContext.SaveChanges();

            return View("View", IoC.AppDbContext.BugManagement.ToList());
        }

        public IActionResult Edit(int id)
        {
            var bugEdit = IoC.AppDbContext.BugManagement.Find(id);

            return View("BugManagerEdit", bugEdit);
        }

        public IActionResult BugManagerEdit(BugManagement bugManagement)
        {
            var bugEdit = IoC.AppDbContext.BugManagement.Find(bugManagement.BugNumber);
            bugEdit.BugNumber = bugManagement.BugNumber;
            bugEdit.AssignedTo = bugManagement.AssignedTo;
            bugEdit.BugState = bugManagement.BugState;
            bugEdit.CreateDate = bugManagement.CreateDate;
            IoC.AppDbContext.BugManagement.Update(bugEdit);
            IoC.AppDbContext.SaveChanges();

            return View("BugManagerEdit", bugEdit);
        }

        public IActionResult Delete(int id)
        {
            var bugToRemove = IoC.AppDbContext.BugManagement.Find(id);
            IoC.AppDbContext.BugManagement.Remove(bugToRemove);
            IoC.AppDbContext.SaveChanges();


            return View("View", IoC.AppDbContext.BugManagement.ToList());
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
