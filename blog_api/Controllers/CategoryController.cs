using blog_data.Repository.IRepository;
using blog_models;
using blog_services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace blog_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;

        }
        [HttpGet(Name = "categories")]
        public IEnumerable<Category> GetAll()
        {
            return _categoryService.GetCategories();
        }
    }
}
