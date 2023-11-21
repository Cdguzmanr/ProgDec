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

        private readonly IWebHostEnvironment _host;

        public ProgramController(IWebHostEnvironment host)
        {
            _host = host;
        }

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

            if (Authenticate.IsAuthenticated(HttpContext))
            {
                ProgramVM programVM = new ProgramVM();

                programVM.Program = ProgramManager.LoadById(id);
                programVM.DegreeTypes = DegreeTypeManager.Load();
                ViewBag.Title = "Edit " + programVM.Program.Description;

                return View(programVM);
            }
            else
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
        }

        [HttpPost]
        public IActionResult Edit(int id, ProgramVM programVM, bool rollback = false)
        {
            try
            {
                // Process the image

                if (programVM.File != null)
                {
                    programVM.Program.ImagePath = programVM.File.FileName;

                    string path = _host.WebRootPath + "\\images\\";

                    using (var stream = System.IO.File.Create(path + programVM.File.FileName)) // You are going to process the characters enconded in the image
                    {
                        programVM.File.CopyTo(stream);

                        ViewBag.Message = "File Uploaded Successfully...";
                    } 
                }

                int result = ProgramManager.Update(programVM.Program, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message; // ViewBag <-- Special bag where we can put anything we want. 
                return View(programVM);
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
