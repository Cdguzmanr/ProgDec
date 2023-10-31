using Microsoft.AspNetCore.Mvc;

namespace CG.ProgDec.UI.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();        
        }
        
     
        [HttpPost]
        public IActionResult Login(User user)
        {
            bool result = UserManager.Login(user);
            return RedirectToAction(nameof(Index), "Declaration");
        }
}
        
}
