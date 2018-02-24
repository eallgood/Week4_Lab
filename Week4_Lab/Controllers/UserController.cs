using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Week4_Lab.Data;
using Week4_Lab.Data.Entities;
using Week4_Lab.Models.View;
using Week4_Lab.Repositories;

namespace Week4_Lab.Controllers
{
    public class UserController : Controller
    {
        private IUserRepo repo;
        public UserController(IUserRepo repo)
        {
            this.repo = repo;
        }

        public ActionResult List()
        {
            var users = repo.GetAllUsers();
            ICollection<UserViewModel> userViewModels = new List<UserViewModel>();

            foreach (var user in users)
            {
                userViewModels.Add(user.MapToUserViewModel());
            }

            return View(userViewModels);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                repo.SaveUser(userViewModel.MapToUser());

                return RedirectToAction("List");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            var user = repo.GetUser(id);

            return View(user.MapToUserViewModel());
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var user = repo.GetUser(id);

            return View(user.MapToUserViewModel());
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                repo.UpdateUser(userViewModel.MapToUser());

                return RedirectToAction("List");
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            repo.DeleteUser(id);

            return RedirectToAction("List");
        }
    }
}