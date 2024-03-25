//using AspNetCore;
using Aulfah.BLL.Interfaces;
using Aulfah.DAL.Model;
using Aulfah.Models;
using Aulfah.PL.ModelsVM;
using Aulfah.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Aulfah.PL.Controllers
{
    
    public class CategoryController : Controller
    {
        private readonly IUnitofWork _unitofWork;
        private readonly Product _product;


        public CategoryController(IUnitofWork unitofWork,Product pro)
        {
            _unitofWork = unitofWork;
           _product = pro;
        }
        public IActionResult Index()
        {
            var products = _unitofWork.CategoryRepository.GetAll();
            return View(products);
        }
        // var products = _unitofWork.ProductRepository.SearchCat(id);
       
       /* IEnumerable<Category> cat = _unitofWork.CategoryRepository.GetAll();
          //  ViewBag.category = products;

            return View(cat);
        }
      /*  public IActionResult ProducList(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            IEnumerable<Category> cat = _unitofWork.CategoryRepository.catProduct(id);

            var products = _unitofWork.ProductRepository.SearchCat(id);
          
            return View(products);

        }*/
        public IActionResult Details(string? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var products = _unitofWork.CategoryRepository.Get(id);
            return View(products);

        }
        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _unitofWork.CategoryRepository.Create(category);
                TempData["success"] = "Added Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult Update(string id)
        {
            var dep = _unitofWork.CategoryRepository.Get(id);
            return View(dep);
        }

        [HttpPost]
        public IActionResult Update(Category category)
        {
            if (ModelState.IsValid)
            {
                _unitofWork.CategoryRepository.Update(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }
        [Authorize(Roles = SD.Role_Admin)]
        public ActionResult Delete(string id)
        {
            var category = _unitofWork.CategoryRepository.Get(id);
            _unitofWork.CategoryRepository.Delete(category);
            return RedirectToAction("Index");
        }
    }
}
