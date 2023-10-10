using CG.Bands.UI.Extensions;
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
                new Band{Id = 1, Image = "https://www.rollingstone.com/wp-content/uploads/2022/07/ID-Press-Photo-Credit-Eric-Ray-Davidson-lo-res.jpg", Name = "Imagine Dragons", Genre="Pop Rock Electro", DateFounded=new DateTime(2008, 4, 3)},
                new Band{Id = 2, Image = "https://www.the-sun.com/wp-content/uploads/sites/6/2022/11/members-brian-roger-taylor-freddie-555539482.jpg?w=620", Name= "Queen", Genre="Glam Rock", DateFounded= new DateTime(1970, 5, 9)},
                new Band{Id = 3, Image = "https://mb.cision.com/Public/16699/3560734/a71843662ff4b133_800x800ar.jpg", Name="Coldplay", Genre="Alternative rock pop" ,DateFounded=new DateTime(1997, 10,5)}
            };

        }
        
        private void GetBands()
        {
            if (HttpContext.Session.GetObject<Band[]>("bands") != null)
            {
                bands = HttpContext.Session.GetObject<Band[]>("bands");
            }
            else
            {
                LoadBands();
            }
        }

        private void SetBands()
        {
            HttpContext.Session.SetObject("bands", bands);
        }

        // GET: BandController
        [HttpGet]
        public ActionResult Index()
        {
            GetBands(); // Way to drive the view to a different default page
            return View("IndexCard" , bands);
        }

        // GET: BandController/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            GetBands();
            Band band = bands.FirstOrDefault(b => b.Id == id);
            return View(band);
        }

        // GET: BandController/Create
        public ActionResult Create()
        {
            Band band = new Band();
            return View(band);
        }

        // POST: BandController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Band band)
        {
            try
            {
                GetBands(); 

               // Resize the Array
               Array.Resize(ref bands, bands.Length+1);

                // Calculate the nnew id Value
                band.Id = bands.Length;
                bands[bands.Length -1] = band;

                /*
                 To save variables between pages:

                - Cokies: The data is saved on the client. 
                - Sesion Variable: The data is saved on the server.
                 */

                SetBands();
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
            GetBands();
            Band band = bands.FirstOrDefault(b => b.Id == id);
            return View(band);
        }

        // POST: BandController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Band band)
        {
            try
            {
                GetBands();

                bands[id-1] = band;

                SetBands();

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
            GetBands();
            Band band = bands.FirstOrDefault(b => b.Id == id);
            return View(band);
        }

        // POST: BandController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                GetBands();

                var newbands = bands.Where(b => b.Id != id);
                bands = newbands.ToArray();

                SetBands();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
