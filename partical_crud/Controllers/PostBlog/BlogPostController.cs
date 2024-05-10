using Microsoft.AspNetCore.Mvc;

namespace partical_crud.Controllers.PostBlog
{
    public class BlogPostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
