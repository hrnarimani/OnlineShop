using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using OnlineShop.Service.IServices;
using OnlineShop.Service.Models;
using System.Text;
using System.Text.Json;

namespace OnlineShop.Web.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryApiController : ControllerBase
    {
        #region Fields

        ICategoryService _categoryService;
        IWebHostEnvironment _webHostEnvironment;
        IDistributedCache _cache;

        #endregion

        #region Ctor

        public CategoryApiController(ICategoryService categoryService, IWebHostEnvironment webHostEnvironment, IDistributedCache cache)
        {
            _categoryService = categoryService;
            _webHostEnvironment = webHostEnvironment;
            _cache = cache;
        }


        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var cacheKey = "AllCategories";
            var cachedData = _cache.Get(cacheKey);
            if (cachedData == null)
            {
                var categories = _categoryService.FindAllAsync().Result;
                var serializedData = JsonSerializer.Serialize(categories);
                var dataBytes = Encoding.UTF8.GetBytes(serializedData);
                _cache.SetAsync(cacheKey, dataBytes);
                return Ok(categories);
            }
            else
            {
                var dataString = Encoding.UTF8.GetString(cachedData);
                var deserializedData = JsonSerializer.Deserialize<List<CategoryModel>>(dataString);
                return Ok(deserializedData);
            }

            return Ok();
        }

        [HttpPost]
        public IActionResult AddCategory([FromBody] CategoryModel model)
        {
            model = _categoryService.Add(model).Result;
            return Ok(model);
        }

        #endregion
    }
}
