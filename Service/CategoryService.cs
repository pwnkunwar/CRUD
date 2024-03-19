namespace CRUD.Service;

using CRUD.DTO;
using CRUD.IRepository;
using CRUD.Models;
public class CategoryService
{
    private readonly ICategoryRepository _repository;
    public CategoryService(ICategoryRepository repository)
    {
        _repository = repository;
    }
    public IEnumerable<CategoryDto> GetAllCategory()
    {
        return _repository.GetAllCategory();

    }
    public void CreateCategory(Category category)
    {
        _repository.Create(category);
    }
    public CategoryDto GetCategoryById(Guid guid)
    {
        return _repository.GetCategoryById(guid);


    }
    public void Update(CategoryDto category)
    {
        _repository.Update(category);
    }
    public void Delete(Guid id)
    {
        _repository.Delete(id);
    }
}