using Aulfah.BLL.Interfaces;
using Aulfah.DAL;
using Aulfah.Models;
using Aulfah.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Xml.Linq;

namespace Aulfah.Controllers
    
{
    
    public class HomeController : Controller
    {

        private readonly IUnitofWork _unitOfWork;

        public HomeController(IUnitofWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }

        public IActionResult Index(string name)
        {

            IEnumerable<Product> ProductList;
            if (name != null)
            {
                ProductList = _unitOfWork.ProductRepository.Search(name,1);
            }
            ProductList = _unitOfWork.ProductRepository.GetAll();
           
            var CategoryList = _unitOfWork.CategoryRepository.GetAll();

            ViewData["Categories"] = CategoryList;

            return View(ProductList);

        }

        public IActionResult About()
        {
            return View();
        }

    }
}