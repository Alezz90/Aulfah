using Aulfah.BLL.Interfaces;
using Aulfah.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aulfah.PL.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IUnitofWork _unitofWork;
        public CustomerController(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        public IActionResult Index()
        {
            var cus = _unitofWork.CustomerRepository.GetAll();

            return View(cus);
        }
        // tring to find prodact that customer but it in his cart 
        public IActionResult customerCart(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var cusCart = _unitofWork.CartRepository.Get(id.Value);
            return View(cusCart);

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
        public IActionResult Update(int id)
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
        public IActionResult DeleteConfirm(int id)
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

