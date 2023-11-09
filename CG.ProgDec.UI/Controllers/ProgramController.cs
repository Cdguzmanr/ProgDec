using CG.ProgDec.BL;
using CG.ProgDec.BL.Models;
using CG.ProgDec.UI.Models;
using CG.ProgDec.UI.ViewModels;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace CG.ProgDec.UI.Controllers
{
    public class ProgramController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "List of All Programs";
            return View(ProgramManager.Load());
        }

        public IActionResult Details(int id)
        {
            var item = ProgramManager.LoadById(id);
            ViewBag.Title = "Details for " + item.Description;
            return View(item);
        }

        public IActionResult Create()
        {

            ViewBag.Title = "Create a Program";

            ProgramVM programVM = new ProgramVM();

            programVM.Program = new BL.Models.Program();
            programVM.DegreeTypes = DegreeTypeManager.Load();

            if (Authenticate.IsAuthenticated(HttpContext))
                return View(programVM);
            else
                return RedirectToAction("Login", "User", new {returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request)}); // Still need to add "Login" 
            
        }

        [HttpPost]
        public IActionResult Create(ProgramVM programVM)
        {
            try
            {


                int result = ProgramManager.Insert(programVM.Program);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IActionResult Edit(int id)
        {
            var item = ProgramManager.LoadById(id);
            ViewBag.Title = "Edit " + item.Description;
            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(int id, BL.Models.Program program, bool rollback = false)
        {
            try
            {
                int result = ProgramManager.Update(program, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message; // ViewBag <-- Special bag where we can put anything we want. 
                return View(program);
            }
        }

        public IActionResult Delete(int id)
        {
            var item = ProgramManager.LoadById(id);
            ViewBag.Title = "Delete";
            return View(item);
        }

        [HttpPost]
        public IActionResult Delete(int id, BL.Models.Program program, bool rollback = false)
        {
            try
            {
                int result = ProgramManager.Delete(id, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(program);
            }
        }


    }
}
