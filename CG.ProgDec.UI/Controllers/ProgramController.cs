using CG.ProgDec.BL;
using CG.ProgDec.BL.Models;
using Microsoft.AspNetCore.Mvc;

namespace CG.ProgDec.UI.Controllers
{
    public class ProgramController : Controller
    {
        public IActionResult Index()
        {
            return View(ProgramManager.Load());
        }

        public IActionResult Details(int id)
        {
            return View(ProgramManager.LoadById(id));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BL.Models.Program program)
        {
            try
            {
                int result = ProgramManager.Insert(program);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IActionResult Edit(int id)
        {
            return View(ProgramManager.LoadById(id));
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
            return View(ProgramManager.LoadById(id));
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
