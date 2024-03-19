using CRUD.DTO;
using Microsoft.AspNetCore.Mvc;
using CRUD.Models;

namespace CRUD.IRepository;

public interface ICategoryRepository
{
    IEnumerable<CategoryDto> GetAllCategory();
    void Create(Category category);
    CategoryDto GetCategoryById(Guid guid);
    void Update(CategoryDto category);
    void Delete(Guid guid);

}