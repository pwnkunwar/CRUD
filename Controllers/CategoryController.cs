using System.Data.Common;
using CRUD.DTO;
using CRUD.Models;
using CRUD.Service;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers;
public class CategoryController : Controller
{
    private readonly CategoryService _categoryService;
    public CategoryController(CategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    public async Task<IActionResult> Index()
    {

        return View(_categoryService.GetAllCategory());
    }
    [HttpGet]
    public IActionResult Create()
    {
        return View();

    }
    [HttpPost]
    public async Task<IActionResult> Create(Category category)
    {
        _categoryService.CreateCategory(category);
        return RedirectToAction("Index");

    }

    [HttpGet]
    public IActionResult Update(Guid id)
    {
        var categoryDto = _categoryService.GetCategoryById(id);
        if (categoryDto is null)
        {
            return NotFound();
        }
        return View(categoryDto);

    }
    [HttpPost]
    public IActionResult Update(CategoryDto category)
    {
        _categoryService.Update(category);
        return RedirectToAction("Index");
    }
    public IActionResult Delete(Guid id)
    {
        var categoryDto = _categoryService.GetCategoryById(id);
        if (categoryDto is null)
        {
            return NotFound();
        }
        return View(categoryDto);
    }
    [HttpPost, ActionName("Delete")]
    public IActionResult DeletePost(Guid id)
    {
        _categoryService.Delete(id);
        return RedirectToAction("Index");
    }

}