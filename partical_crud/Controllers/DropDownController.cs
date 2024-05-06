using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using partical_crud.Data;
using partical_crud.Models;

namespace partical_crud.Controllers
{
    public class DropDownController : Controller
    {

        // createing the obj
        private readonly ApplicationDbContext _context;


        private List<State> listOfState;
        private List<Country> listOfCountry;

        // drop down list
        public DropDownController()
        {
            // state
            listOfState = new List<State>();
            listOfCountry = new List<Country>();
            listOfState.Add(new State() { Id = 1, StateName = "New Delhi", CountryId = 1 });
            listOfState.Add(new State() { Id = 1, StateName = "Chennai", CountryId = 1 });

            listOfState.Add(new State() { Id = 2, StateName = "Canberra", CountryId = 2 });
            listOfState.Add(new State() { Id = 2, StateName = "Melbourne", CountryId = 2 });

            listOfState.Add(new State() { Id = 3, StateName = "California", CountryId = 3 });
            listOfState.Add(new State() { Id = 3, StateName = "Florida", CountryId = 3 });

            // Country
            listOfCountry.Add(new Country() { Id = 1, CountryName = "India" });
            listOfCountry.Add(new Country() { Id = 2, CountryName = "Australia" });

            listOfCountry.Add(new Country() { Id = 3, CountryName = "America" });

        }
        // GETING THE STATE MODEL
        public ActionResult Index()
        {
            IEnumerable<SelectListItem> listOfItems = (from obj in listOfCountry select new SelectListItem() { Text = obj.CountryName, Value = obj.Id.ToString() }).ToList();
            return View(listOfItems);
        }

        public IActionResult GetState(int CountryID)
        {
            IEnumerable<SelectListItem> listItems = (
                from obj in listOfState where obj.CountryId == CountryID select new SelectListItem() { Value = obj.Id.ToString(), Text = obj.StateName }).ToList();
            return PartialView("_StateView", listItems);
        }

        public IActionResult GetById()
        {
            return View("GetById");
        }
        //public async Task<IActionResult> GetUserList()
        //{
        //    var store = _context;
        //    return View(store);
        //    //  var userList = await _iuser.ListUser();
        //    // return View(userList);
        //}

    }

}

