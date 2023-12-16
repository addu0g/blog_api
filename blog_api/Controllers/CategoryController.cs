using blog_data.Repository.IRepository;
using blog_models;
using Microsoft.AspNetCore.Mvc;

namespace blog_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        [HttpGet(Name = "categories")]
        public IEnumerable<Category> GetAll()
        {
            return _unitOfWork.Category.GetAll();
        }
    }
}
