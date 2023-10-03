using CG.Bands.UI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CG.Bands.UI.Controllers
{
    public class BandController : Controller
    {
        Band[] bands;

        public void LoadBands()
        {
            bands = new Band[]
            {
                new Band{Id = 1, Name = "Imagine Dragons", Genre="Pop Rock Electro", DateFounded=new DateTime(2008, 4, 3)},
                new Band{Id = 2, Name= "Queen", Genre="Glam Rock", DateFounded= new DateTime(1970, 5, 9)},
                new Band{Id = 3, Name="Coldplay", Genre="Alternative rock pop" ,DateFounded=new DateTime(1997, 10,5)}
            };

        }

        // GET: BandController
        [HttpGet]
        public ActionResult Index()
        {
            LoadBands();
            return View(bands);
        }

        // GET: BandController/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            LoadBands();
            Band band = bands.FirstOrDefault(b => b.Id == id);
            return View(band);
        }

        // GET: BandController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BandController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BandController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BandController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BandController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BandController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
