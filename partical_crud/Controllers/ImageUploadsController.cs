using Microsoft.AspNetCore.Mvc;

namespace partical_crud.Controllers
{
    public class ImageUploadsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
