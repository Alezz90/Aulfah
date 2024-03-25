using Aulfah.BLL.Interfaces;
using Aulfah.DAL.Model;
using Aulfah.Models;
using Aulfah.PL.ModelsVM;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Aulfah.PL.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IUnitofWork _unitofWork;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
      
        public CustomerController(IUnitofWork unitofWork, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _unitofWork = unitofWork;
            _userManager = userManager;
            _signInManager = signInManager;

        }
        public IActionResult Index()
        {
            var customer = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (customer == null)
            {
                return BadRequest();
            }
            ViewBag.Artist = customer;
            var customerPage= _unitofWork.ArtistRepository.userservice(customer);

            return View(customerPage);
        }
        // tring to find prodact that customer but it in his cart 
        public IActionResult customerCart()
        {
            var customer = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (customer == null)
            {
                return BadRequest();
            }
            //var cusCart = _unitofWork.CartRepository.Get(id.Value);
            var cusCart = _unitofWork.CartRepository.CustomerCart(customer);
            // return View(cusCart);
            return RedirectToAction("Home","CartController", cusCart);

        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }
            _unitofWork.CustomerRepository.Create(customer);

            return RedirectToAction("Home", new { id = customer.Id });
        }

        // Update customer 
        public IActionResult Update(string id)
        {
            var dep = _unitofWork.CustomerRepository.Get(id);
            return View(dep);
        }

        [HttpPost]
        public IActionResult Update(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _unitofWork.CustomerRepository.Update(customer);
                return RedirectToAction("Home");
            }
            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(string id)
        {
            var Cus = _unitofWork.CustomerRepository.Get(id);
            _unitofWork.CustomerRepository.Delete(Cus);
            return RedirectToAction("Home");
        }

        public IActionResult EditProfile()
        {
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }
    }
     
}

