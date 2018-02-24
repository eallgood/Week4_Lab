using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Week4_Lab.Data;
using Week4_Lab.Data.Entities;

namespace Week4_Lab.Repositories
{
    public class PetRepo : IPetRepo
    {
        private AppDbContext dbContext;
        
        public PetRepo(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void UpdatePet(Pet pet)
        {
            dbContext.Pets.Find(pet.Id).Update(pet);
            dbContext.SaveChanges();
        }

        public Pet GetPet(int petId)
        {
            return dbContext.Pets.Find(petId);
        }

        public IEnumerable<Pet> GetPetsForUser(int userId)
        {
            return dbContext.Pets.Where(pet => pet.UserId == userId).ToList();
        }

        public void SavePet(Pet pet)
        {
            dbContext.Pets.Add(pet);
            dbContext.SaveChanges();
        }

        public void DeletePet(int id)
        {
            var pet = dbContext.Pets.Find(id);

            if (pet != null)
            {
                dbContext.Pets.Remove(pet);
                dbContext.SaveChanges();
            }
        }
    }
}