using ADMS.Common;
using ADMS.Domain.Entities;
using ADMS.Domain.Interfaces.Managers;
using ADMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ADMS.Controllers
{
    [Authorize]
    public class CategoryController : BaseController
    {
        ICategoryManager _categoryManager;
        ICategoryMappingManager _categoryMappingManager;
        
        public CategoryController(ICategoryManager categoryManager, ICategoryMappingManager categoryMappingManager)
        {
            _categoryManager = categoryManager;
            _categoryMappingManager = categoryMappingManager;
        }

        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            var category = new CategoryViewModel();

            var categories = _categoryManager.GetAllParentCategories();
            category.Categories = categories;

            return View(category);
        }

        [HttpPost]
        public ActionResult Create(CategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid)
            {
                var categoryId = Guid.NewGuid(); 


                var category = new Category
                                    {
                                        CategoryId = categoryId,
                                        CategoryName = categoryViewModel.CategoryName                    
                                    };

                var categoryMap = new CategoryMapping
                                    {
                                        CategoryMapId = Guid.NewGuid(),
                                        CategoryId = categoryId,
                                        ParentCategory = categoryViewModel.ParentCategory,
                                        Category = category
                                    };

                _categoryMappingManager.SaveCategory(categoryMap);
                
            }            

            return new HttpStatusCodeResult(200);
        }

        public JsonResult GetSubcategories(Guid category)
        {
            var categories = new JsonResult();
            categories.Data = _categoryManager.GetAllSubCategories(category);
            return categories;
        }

    }
}