using Aulfah.BLL.Interfaces;
using Aulfah.PL.Helper;
using Aulfah.PL.ModelsVM;
using Aulfah.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Aulfah.Models;
using Aulfah.DAL;
using Microsoft.AspNetCore.Mvc.Rendering;
using Aulfah.DAL.Model;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Aulfah.PL.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IMapper _mapper;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProductController(IUnitofWork unitofWork, IMapper mapper, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
             _unitofWork = unitofWork;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;

        }
        public IActionResult Index()
        {
            var products = _unitofWork.ProductRepository.GetAll();
            return View(products);
        }
       /* public IActionResult Details()
        {
            return View();
        }*/
            public IActionResult Details(int id)
        {

            if (id == null)
            {
                return BadRequest();
            }
            // var products = _unitofWork.ProductRepository.Get(id.Value);
            var products = _unitofWork.ProductRepository.Get(id);
            return View(products);
        }

        [Authorize(Roles = SD.Role_Artist)]
        public IActionResult Create()
        {
      
          
           // ViewBag.Category = _unitofWork.CategoryRepository.GetAll();
            ViewBag.Category = new SelectList(_unitofWork.CategoryRepository.GetAll(), "CategoryID", "Name");

            return View();
        }
        [HttpPost]
        [Authorize(Roles = SD.Role_Artist)]

        public IActionResult Create(ProductVM product)
        {
            var artist = User.FindFirstValue(ClaimTypes.NameIdentifier);

          //  if (ModelState.IsValid)
          ///  {
                product.ProductImage = DucomentConfi.DocumentUplod(product.ProductPath, "images");

                product.ArtistID = artist.First();
                var pro = _mapper.Map<ProductVM, Product>(product);

                _unitofWork.ProductRepository.Create(pro);
                TempData["success"] = "added successfully";
                return RedirectToAction("index");
         //   }
         /*   else
            {
                // Log or inspect ModelState errors
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                return View();
            }*/
        }

        //[Authorize(Roles = SD.Role_Artist)]
        public IActionResult Update(int id)
        {
            var dep = _unitofWork.ProductRepository.Get(id);
            return View(dep);
        }

        [HttpPost]
        //[Authorize(Roles = SD.Role_Artist)]
        public IActionResult Update(Product product)
        {
            if (ModelState.IsValid)
            {
                _unitofWork.ProductRepository.Update(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        //[Authorize(Roles = SD.Role_Artist)]
        public ActionResult Delete(int id)
        {
            var dep = _unitofWork.ProductRepository.Get(id);
            _unitofWork.ProductRepository.Delete(dep);
            return RedirectToAction("Index");
        }
        public IActionResult Addtocart(int id,int numberQ)
        {
           
            if (id == null)
            {
                return BadRequest();
            }
           
            var products = _unitofWork.ProductRepository.Get(id);

            Cart cart = _unitofWork.CartRepository.Get(1);
            cart.totalPrice += products.ProductPrice * numberQ;
            cart.Products.Add(products);
            _unitofWork.CartRepository.Update(cart);
            return View(" Index","Home");
        }

        public ActionResult ProducList(int id)
        {
            IEnumerable<Product> products = _unitofWork.ProductRepository.SearchCat(id);
            return View(products);
        }
    }
}
