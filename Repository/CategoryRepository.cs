namespace CRUD.Repository;

using System;
using System.Collections.Generic;
using CRUD.Database;
using CRUD.DTO;
using CRUD.IRepository;
using CRUD.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _applicationDbContext;
    public CategoryRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }




    public IEnumerable<CategoryDto> GetAllCategory()
    {
        IEnumerable<CategoryDto> categoryList = _applicationDbContext.Categories.Select(category => new CategoryDto
        {
            guid = category.Id,
            CategoryName = category.Name,
            DisplayOrder = category.DisplayOrder
        }).ToList();
        return categoryList;
    }
    public void Create(Category category)
    {
        _applicationDbContext.Categories.Add(category);
        _applicationDbContext.SaveChanges();
    }

    public CategoryDto GetCategoryById(Guid guid)
    {
        var category = _applicationDbContext.Categories.Find(guid);
        if (category is null)
        {
            return null;
        }
        else
        {
            var categoryDto = new CategoryDto
            {
                guid = category.Id,
                CategoryName = category.Name,
                DisplayOrder = category.DisplayOrder
            };
            return categoryDto;
        }

    }
    [HttpPost]
    public void Update(CategoryDto category)
    {
        var categoryDto = new Category
        {
            Name = category.CategoryName,
            DisplayOrder = category.DisplayOrder
        };
        _applicationDbContext.Categories.Update(categoryDto);
        _applicationDbContext.SaveChanges();
    }
    public void Delete(Guid id)
    {
        var post = _applicationDbContext.Categories.Find(id);
        if (post is null)
        {

        }

        _applicationDbContext.Categories.Remove(post);
        _applicationDbContext.SaveChanges();
    }

}