/* var user =  userManager.GetUserAsync(User);
            var userFirstName = user?.Id;*/

using Aulfah.BLL.Interfaces;
using Aulfah.DAL.Model;
using Aulfah.Models;
using Aulfah.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Aulfah.PL.Controllers
{
   [Authorize(Roles = SD.Role_Artist)]
	public class ArtistController : Controller
    {
		private readonly IUnitofWork _unitofWork;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;



        public ArtistController(IUnitofWork unitofWork, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _unitofWork = unitofWork;
            _userManager = userManager;
            _signInManager = signInManager;

           
        }
		public IActionResult Home()
		{
            var artist = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (artist == null)
            {
                return BadRequest();
            }
            // i want to cheack the user login id delete it after
            ViewBag.Artist = artist; 
            
           var ArtistServices = _unitofWork.ArtistRepository.userservice(artist);
           

            //Retriving All Prudect Add By Artist
            ViewBag.ArtistProduct = _unitofWork.ProductRepository.UserProduct(artist);
            ViewBag.ArtistService = _unitofWork.ServiceRepository.UserServices(artist);

            //if (artist != null) 
            /* Here I want to retrieve all products from the orders where at least 
               one product is sold by a specific artist, stroing them in a 
               single list of products from all the orders that meet the criteria. 
             */

            /*  var SaledProduct = _unitofWork.OrdersRepository.GetAll()
                  .Where(o => o.Cart.Products.Any(product => product.ArtistID == artist.ArtistID))
                  .SelectMany(o => o.Cart.Products).ToList();*************************/

            /* Here I want to calculate the total price of the products,
            and store it in ViewBag I used totalPrice a static Method 
            developed in Product Class
             */
            // ViewBag.ArtistEarning = Product.totalPrice(SaledProduct);**********************

            /* Here I want to set the count of the product,
               to get the number of elements in the list
             */
            //ViewBag.ArtistServicesObjectCoubt = SaledProduct;*************************

            return View(ArtistServices);
        }


        public IActionResult Index()
        {
            var emps = _unitofWork.ArtistRepository.GetAll();

            return View(emps);
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var emp = _unitofWork.ArtistRepository.Get(id.Value);
            return View(emp);

        }


        // Creating Artist Account
        public IActionResult Create()
        {
           // ViewBag.Departments = _unitofWork.ArtistRepository.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Artist artist)
        {
            if (artist == null)
            {
                return BadRequest();
            }
            //emp.ImageUrl = DocumentConf.DocumentUpload(emp.Image, "Images");
            
            _unitofWork.ArtistRepository.Create(artist);
            return View();
          ///  return RedirectToAction("Home", new { id = artist.ArtistID });******************
        }
        
        // Update Artist
        public IActionResult Update(int id)
        {
            var artist = _unitofWork.ArtistRepository.Get(id);
            return View(artist);
        }

        [HttpPost]
        public IActionResult Update(Artist artist)
        {
            if (ModelState.IsValid)
            {
                _unitofWork.ArtistRepository.Update(artist);
                return RedirectToAction("Home");
            }
            return View(artist);
        }

        //Deleting Artist Account
        public IActionResult Delete(int id)
        {
            var artist = _unitofWork.ArtistRepository.Get(id);
            return View(artist);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            var artist = _unitofWork.ArtistRepository.Get(id);

            //DocumentConf.DcoumentDelete(emp.ImageUrl, "Images");

            _unitofWork.ArtistRepository.Delete(artist);
            return RedirectToAction("Home");
        }

        public async Task<IActionResult>  Profile()
        {
            var loggedInUser = await _userManager.GetUserAsync(User);
            return View(loggedInUser);
        }

        public IActionResult EditProfile()
        {
            return View();
        }
    }
}
