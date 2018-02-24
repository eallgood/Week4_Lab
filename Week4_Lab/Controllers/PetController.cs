using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Week4_Lab.Data;
using Week4_Lab.Data.Entities;
using Week4_Lab.Models.View;
using Week4_Lab.Services;

namespace Week4_Lab.Controllers
{
    public class PetController : Controller
    {
        private IPetService service;
        public PetController(IPetService service)
        {
            this.service = service;
        }

        public ActionResult List(int userId)
        {
            ViewBag.UserId = userId;

            return View(service.GetPetsForUser(userId));
        }

        [HttpGet]
        public ActionResult Create(int userId)
        {
            ViewBag.UserId = userId;

            return View();
        }

        [HttpPost]
        public ActionResult Create(PetViewModel petViewModel)
        {
            if (ModelState.IsValid)
            {
                service.CreatePet(petViewModel);
                return RedirectToAction("List", new { petViewModel.UserId });
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var pet = service.GetPet(id);

            return View(pet);
        }

        [HttpPost]
        public ActionResult Edit(PetViewModel petViewModel)
        {
            petViewModel.UserId = service.GetPet(petViewModel.Id).UserId;

            if (ModelState.IsValid)
            {
                service.UpdatePet(petViewModel);

                return RedirectToAction("List", new { petViewModel.UserId });
            }

            return View();
        }

        public ActionResult Details(int id)
        {
            var pet = service.GetPet(id);
            service.MarkCheckupFlag(pet);

            return View(pet);
        }

        public ActionResult Delete(int id)
        {
            var pet = service.GetPet(id);

            service.DeletePet(id);

            return RedirectToAction("List", new { UserId = pet.UserId });
        }
    }
}