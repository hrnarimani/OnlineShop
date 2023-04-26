using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Service.IServices;

namespace OnlineShop.Web.Controllers
{
    [Route("api/Product")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {

        #region Fields

        IProductService _productService;
        IWebHostEnvironment _webHostEnvironment;
        #endregion

        #region Ctor

        public ProductAPIController(IProductService productService, IWebHostEnvironment webHostEnvironment)
        {
            _productService = productService;
            _webHostEnvironment = webHostEnvironment;
        }
        #endregion
        [HttpGet]
        public IActionResult Index()
        {
            var model = _productService.FindAllAsync().Result;
            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var model = _productService.Find(id);
                return Ok(model);
            }
            catch
            {
                return BadRequest();
            }


        }

    }
}
