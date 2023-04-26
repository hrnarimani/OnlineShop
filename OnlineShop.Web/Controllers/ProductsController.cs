using Microsoft.AspNetCore.Mvc;
using OnlineShop.Service.IServices;
using OnlineShop.Service.Models;


namespace OnlineShop.Web.Controllers
{
    public class ProductsController : Controller
    {
        #region Fields

        IProductService _productService;
        IWebHostEnvironment _webHostEnvironment;
        #endregion

        #region Ctor

        public ProductsController(IProductService productService, IWebHostEnvironment webHostEnvironment)
        {
            _productService = productService;
            _webHostEnvironment = webHostEnvironment;
        }


        #endregion

        public IActionResult Index()
        {
            var model = _productService.FindAllAsync().Result;
            return View(model);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Add new Product";
            ViewData["Action"] = "Create";
            return View("Edit");
        }


        [HttpPost]
        public IActionResult Create(ProductModel model)
        {
            ProcessPicture(model);
            _productService.Add(model);
            ViewData["Title"] = "Add new Product";
            ViewData["Action"] = "Create";
            return View("Edit");
        }

        public IActionResult Edit(int id)
        {
            var model = _productService.Find(id);
            ViewData["Title"] = "Edit Product";
            ViewData["Action"] = "Edit";
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(ProductModel model)
        {
            ProcessPicture(model);
            _productService.Update(model);
            return View();
        }

        public IActionResult Details(int id)
        {
            var model = _productService.Find(id);
            return View(model);
        }

        private void ProcessPicture(ProductModel model)
        {
            string pictureName = null;
            string path = Path.Combine(_webHostEnvironment.WebRootPath, FileHelper.PicturesFolderName);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (model.NewPicture != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, FileHelper.PicturesFolderName);
                pictureName = Guid.NewGuid().ToString() + "_" + model.NewPicture.FileName;
                string filePath = Path.Combine(uploadsFolder, pictureName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.NewPicture.CopyTo(fileStream);
                }

                model.Picture = pictureName;
            }

            else if (model.Id > 0)
            {
                model.Picture = _productService.Find(model.Id).Picture;
            }

        }
    }
}
