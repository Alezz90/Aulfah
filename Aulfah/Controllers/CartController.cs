using Aulfah.BLL.Interfaces;
using Aulfah.DAL;
using Aulfah.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace Aulfah.PL.Controllers
{
	public class CartController : Controller
	{
        private readonly IUnitofWork _unitofWork;
        public CartController(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

      

        public IActionResult Index(string id)
        {
            //Getting customer using the ID passed 
            var customerCart = _unitofWork.CustomerRepository.Get(id);

            //getting the Cart using the cart ID which will create once the Customer is Regist
            if (id == null)
            {
                return BadRequest();
            }
            
                var cart = _unitofWork.CartRepository.Get((int)customerCart.CartId);
            

            ViewData["Customer Cart"] = cart;

            //Using  totatprice() Methods  
            var Products = cart.Products;
            ViewBag.totalPriceOfProduct = Product.totalPrice(Products.ToList());

            return View(Products);
        }
        // Creating Artist Account

        [HttpPost]
        public IActionResult Create(Cart cart)
        {
            if (cart == null)
            {
                return BadRequest();
            }

            _unitofWork.CartRepository.Create(cart);

            /* NEED TO CHECK */
            return RedirectToAction("Home", "CustomerController");

        }

        public IActionResult Add(Product product) 
        {
            // Check if the key exists in ViewData
            if (ViewData.ContainsKey("Customer Cart"))
            {
                // Retrieve the existing cart and perform operations
                var cart = ViewData["Customer Cart"] as Cart; 
                if (cart != null)
                {
                    // Check if the  the product Quantity if it more than one
                    if (product.Quantity >= 0)
                    {
                        product.Quantity--;
                        _unitofWork.ProductRepository.Update(product);
                    }
                    cart.Products.Add(product);
                    _unitofWork.CartRepository.Update(cart);
                }
                
            }

            return View(product);   
        }

        
        public IActionResult Delete(string id)
        {
            var product = _unitofWork.CartRepository.Get(id);
            _unitofWork.CartRepository.Delete(product);
            return View(product);
        }

        public IActionResult DeleteProduct(Product productTODelete)
        {
            // Check if the key exists in ViewData
            if (ViewData.ContainsKey("Customer Cart"))
            {
                // Retrieve the existing cart and perform operations
                var cart = ViewData["Customer Cart"] as Cart;
                if (cart != null && productTODelete != null)
                {
                    /*Remove the product to the cart It must to Update the
                     Quantity of Product */
                    productTODelete.Quantity++;
                    _unitofWork.ProductRepository.Update(productTODelete);
                    cart.Products.Remove(productTODelete);
                    _unitofWork.CartRepository.Update(cart);
                }

            }

            return RedirectToAction("Index");
        }

        //[HttpPost, ActionName("Delete")]
        //public IActionResult DeleteConfirm(int id)
        //{
        //    var product = _unitofWork.CartRepository.Get(id);
        //    _unitofWork.CartRepository.Delete(product);
        //    return RedirectToAction("Cart, Index");
        //}

        
        
    }
}
 