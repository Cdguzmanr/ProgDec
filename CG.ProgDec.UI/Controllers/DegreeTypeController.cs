using CG.ProgDec.BL;
using CG.ProgDec.BL.Models;
using Microsoft.AspNetCore.Mvc;

namespace CG.ProgDec.UI.Controllers
{
    public class DegreeTypeController : Controller
    {
        public IActionResult Index()
        {
            return View(DegreeTypeManager.Load());
        }

        public IActionResult Details(int id)
        {
            return View(DegreeTypeManager.LoadById(id));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DegreeType degreeType)
        {
            try
            {
                int result = DegreeTypeManager.Insert(degreeType);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                throw;
            }
        }

        
    
    }
}
