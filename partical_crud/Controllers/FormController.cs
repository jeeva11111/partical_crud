using Microsoft.AspNetCore.Mvc;
using partical_crud.Data;
using partical_crud.Models;

namespace partical_crud.Controllers
{
    public class FormController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly IWebHostEnvironment _environment;

        public FormController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public IActionResult Index()
        {
            ViewBag.CountryList = _context.Country.ToList();
            return View();
        }
        public IActionResult GetTheForm()
        {
            return Json("_FormUpload");
        }

        [HttpGet]
        public IActionResult GetStates(int id)
        {
            return Json(_context.states.Where(x => x.CountryId == id).ToList());
        }

        [HttpGet]
        public IActionResult GetCities(int id)
        {
            return Json(_context.City.Where(x => x.StateId == id));
        }

        public async Task<IActionResult> PostNewUser(UserViewModel model)
        {
            try
            {
              
                    if (model.UserImage != null && model.UserImage.Length > 0)
                    {

                        var getPath = Path.Combine(_environment.WebRootPath, "UserProfile");
                        if (!Directory.Exists(getPath))
                        {
                            Directory.CreateDirectory(getPath);
                        }

                        var folderPath = Path.Combine(getPath, model.UserImage.FileName);


                        using (var stream = new FileStream(folderPath, FileMode.Create))
                        {
                            await model.UserImage.CopyToAsync(stream);
                        }
                        var user = new UserViewModel() { UserName = model.UserName, UserImage = model.UserImage, SpeakingDate = model.SpeakingDate, Email = model.Email, SpeakingTime = model.SpeakingTime, LastName = model.LastName, Address = model.Address, Qualification = model.Qualification, Phone = model.Phone, UserFileName = folderPath, City = model.City, State = model.State, Country = model.Country, CityId = model.CityId, StateId = model.StateId, CountryId = model.CountryId, ZipCode = model.ZipCode, Experience = model.Experience, Venue = model.Venue };

                        _context.AccountInfo.Add(user);
                        _context.SaveChanges();
                        return View("Index");
                    
                }


            }
            catch (Exception ex) { return Json($"unable to add the new user{ex.Message}"); }

            return View("Index");
        }

    }
}
