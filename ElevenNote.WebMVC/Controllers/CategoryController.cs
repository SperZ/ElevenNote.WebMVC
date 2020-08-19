using ElevenNote.Models.CategoryModels;
using ElevenNote.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElevenNote.WebMVC.Controllers
{
    public class CategoryController : Controller
    {
        [Authorize]
        public CategoryService CreateCategoryService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CategoryService(userId);
            return service;
        }
        // GET: Category
        public ActionResult Index()
        {
            var service = CreateCategoryService();
            var model = service.GetCategories();

            return View(model);
        }

        //Get; View for Create Method
        public ActionResult Create()
        {
            return View();
        }

        //Post: Create category that will be added to database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateCategoryService();

            if (service.CreateCategory(model))
            {
                TempData["SaveResult"] = "Your category was created";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Unable to create category");
            return View(model);
        }
    }
}