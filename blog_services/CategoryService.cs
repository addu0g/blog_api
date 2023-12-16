using blog_data.Repository.IRepository;
using blog_models;
using blog_services.IServices;
using System.Linq.Expressions;

namespace blog_services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public List<Category> Categories { get; set; }
        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Category> GetCategories()
        {
            return _unitOfWork.Category.GetAll();
            
        }
    }
}
