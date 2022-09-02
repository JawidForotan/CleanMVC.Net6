using Microsoft.AspNetCore.Mvc;
using SimpleMVC.Interfaces;

namespace SimpleMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productSevice)
        {
            _productService = productSevice;
        }
        public IActionResult GetAll()
        {
            return View(_productService.GetProducts());
        }
        public IActionResult GetOne(int id)
        {
            var product = _productService.GetOne(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);

        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Name, price")] Product product)
        {

            if (!ModelState.IsValid)
            {
                return View(product);
            }
            _productService.CreateNew(product);
            TempData["AlertMessage"] = "Created Successfully";
            return RedirectToAction(nameof(GetAll));


        }

        public IActionResult Delete(int id)
        {
            _productService.deleteProduct(id);
            TempData["AlertMessage"] = "Deleted Successfully";
            return RedirectToAction(nameof(GetAll));
        }
        public IActionResult Update(int id)
        {
            var product = _productService.GetOne(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost]
        public IActionResult Update(int id, [Bind("Id, Name, price")] Product product)
        {

            if (!ModelState.IsValid)
            {
                return View(product);
            }
            _productService.UpdateProduct(id, product);
            TempData["AlertMessage"] = "Updated Successfully";
            return RedirectToAction(nameof(GetAll));


        }
    }
}
