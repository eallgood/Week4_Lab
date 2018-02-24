using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Week4_Lab.Models.View;
using Week4_Lab.Repositories;

namespace Week4_Lab.Services
{
    public class PetService : IPetService
    {
        private IPetRepo repo;

        public PetService(IPetRepo repo)
        {
            this.repo = repo;
        }

        public PetViewModel GetPet(int id)
        {
            var pet = repo.GetPet(id).MapToPetViewModel();
            MarkCheckupFlag(pet);
            return pet;
        }

        public IEnumerable<PetViewModel> GetPetsForUser(int userId)
        {
            var pets = repo.GetPetsForUser(userId);
            var petViewModels = new List<PetViewModel>();

            foreach (var pet in pets)
            {
                petViewModels.Add(pet.MapToPetViewModel());
            }

            return petViewModels;
        }

        public void CreatePet(PetViewModel petViewModel)
        {
            repo.SavePet(petViewModel.MapToPet());
        }

        public void UpdatePet(PetViewModel petViewModel)
        {
            repo.UpdatePet(petViewModel.MapToPet());
        }

        public void DeletePet(int id)
        {
            repo.DeletePet(id);
        }

        public void MarkCheckupFlag(PetViewModel petViewModel)
        {
            petViewModel.NeedsCheckup = (petViewModel.NextCheckup - DateTime.Now).Days < 14;
        }
    }
}