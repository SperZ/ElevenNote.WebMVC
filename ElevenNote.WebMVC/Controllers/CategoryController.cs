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

        public ActionResult Details(int id)
        {
            var service = CreateCategoryService();
            var model = service.GetCategoryById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateCategoryService();
            var detail = service.GetCategoryById(id);
            var model =
                new CategoryEdit()
                {
                    CategoryId = detail.CategoryId,
                    Title = detail.Title
                };
            return View(model);
        }
        // Post: new edit to category
        [HttpPost]
        public ActionResult Edit(int id, CategoryEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CategoryId != id)
            {
                ModelState.AddModelError("", "Id mismatch");
            }

            var service = CreateCategoryService();
            if (service.UpdateCategory(model))
            {
                TempData["SaveResult"] = "Your category has been updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your category could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateCategoryService();
            var model = service.GetCategoryById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateCategoryService();
            service.DeleteCategory(id);
            TempData["SaveResult"] = "You category was deleted.";

            return RedirectToAction("Index");
        }
    }
}