using Hello.Services;
using Hello.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Hello.Controllers
{
    public class ProductsController : Controller
    {
        ProductServices service;
        public ProductsController()
        {
            service = new ProductServices();
        }
        public IActionResult Index(String? keyWord)
        {
            ProductViewModel model = new ProductViewModel();
            model.Products = service.GetProducts(keyWord);
            if (!String.IsNullOrEmpty(keyWord))

                model.keyWord = keyWord;

            return View(model);
        }
        public IActionResult Delete(int id)
        {
            service.deleteP(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var p = service.getPbyId(id);
            ProductViewModel model = new ProductViewModel();
            model.ProductResponse = p;
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(ProductViewModel model)
        {
            var p = model.ProductResponse;
            var rs = service.update(p);
            return View(model);
        }
        [HttpPost]

        public IActionResult Add(ProductViewModel model)
        {
            var p = model.ProductResponse;
            var rs = service.add(p);
            return RedirectToAction("Index");
        }

    }
}
