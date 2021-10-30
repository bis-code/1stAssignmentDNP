using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using FileData;
using Models;

namespace FirstAssignmentDNP.Data
{
    public class FamiliesJSONData : IFamiliesData
    {
        private FileContext FileContext;

        public FamiliesJSONData()
        {
            FileContext = new FileContext();
        }

        public async Task<IList<Family>> GetFamiliesAsync()
        {
            IList<Family> temp = new List<Family>(FileContext.Families);
            return temp;
        }
        public async Task<Family> GetFamilyAsync(int IdFamily)
        {
            return FileContext.Families.First(f => f.Id == IdFamily);
        }

        public async Task<Adult> GetAdultAsync(int IdFamily, int IdAdult)
        {
            return FileContext.Families.First(f => f.Id == IdFamily).Adults.First(a => a.Id == IdAdult);
        }

        public async Task<Child> GetChildAsync(int IdFamily, int IdChild)
        {
            return FileContext.Families.First(f => f.Id == IdFamily).Children.First(c => c.Id == IdChild);
        }
        
        public async Task<Pet> GetPetAsync(int IdFamily, int IdPet)
        {
            return FileContext.Families.First(f => f.Id == IdFamily).Pets.First(p => p.Id == IdPet);
        }
        
        public async Task<Adult> AddAdultToFamilyAsync(Family _family, Adult _newAdult)
        {
            int max = 0;
            foreach (var family in FileContext.Families)
            {
                int currentMax = 0;
                if(family.Adults.Count > 0)
                    currentMax = family.Adults.Max(a => a.Id);
                if (currentMax > max)
                    max = currentMax;
            }
            _newAdult.Id = (++max);
            _newAdult.Photo = "default.png";
            int indexOfFamily = FileContext.Families.IndexOf(_family);
            FileContext.Families[indexOfFamily].Adults.Add(_newAdult);
            FileContext.SaveChanges();
            return _newAdult;
        }

        public async Task<Child> AddChildToFamilyAsync(Family _family, Child _newChild)
        {
            int max = 0;
            foreach (var family in FileContext.Families)
            {
                int currentMax = 0;
                if (_family.Pets.Count > 0)
                    currentMax = family.Pets.Max(p => p.Id);
                if (currentMax > max)
                    max = currentMax;
            }
            _newChild.Id = (++max);
            _newChild.Photo = "default.png";
            _newChild.Interests = new List<Interest>();
            _newChild.Pets = new List<Pet>();
            int indexOfFamily = FileContext.Families.IndexOf(_family);
            FileContext.Families[indexOfFamily].Children.Add(_newChild);
            FileContext.SaveChanges();
            return _newChild;
        }

        public async Task<Family> AddFamilyAsync(Family family)
        {
            int max = FileContext.Families.Max(f => f.Id);
            family.Id = (++max);
            family.Photo = "default.png";
            family.Children = new List<Child>();
            family.Pets = new List<Pet>();
            FileContext.Families.Add(family);
            FileContext.SaveChanges();
            return family;
        }

        public async Task<Interest> AddInterestAsync(int IdFamily, Child child, Interest interest)
        {
            int indexOfFamily = FileContext.Families.IndexOf(FileContext.Families.First(f => f.Id == IdFamily));
            int indexOfChild = FileContext.Families[indexOfFamily].Children.IndexOf(child);

            FileContext.Families[indexOfFamily].Children[indexOfChild].Interests.Add(interest);
            FileContext.SaveChanges();
            return interest;
        }

        public async Task<Pet> AddPetForFamilyAsync(Family family, Child? child, Pet pet)
        {
            int max = 0;
            foreach (var _family in FileContext.Families)
            {
                int currentMax = 0;
                if (_family.Pets.Count > 0)
                    currentMax = _family.Pets.Max(p => p.Id);
                if (currentMax > max)
                    max = currentMax;
            }
            pet.Id = (++max);
            int indexOfFamily = FileContext.Families.IndexOf(family);
            if (child != null)
            {
                int indexOfChild = FileContext.Families[indexOfFamily].Children.IndexOf(child);
                FileContext.Families[indexOfFamily].Children[indexOfChild].Pets.Add(pet);
            }
            FileContext.Families[indexOfFamily].Pets.Add(pet);
            FileContext.SaveChanges();
            return pet;
        }

        public async Task<Family> UpdateFamilyAsync(Family family)
        {
            int id = FileContext.Families.IndexOf(family);
            FileContext.Families[id] = family;
            FileContext.SaveChanges();
            return family;
        }

        public async Task<Adult> UpdateAdultAsync(int IdFamily,Adult adult)
        {
            int id = FileContext.Families.First(f => f.Id == IdFamily).Adults.IndexOf(adult);
            FileContext.Families.First(f => f.Id == IdFamily).Adults[id] = adult;
            FileContext.SaveChanges();
            return adult;
        }

        public async Task<Child> UpdateChildAsync(int IdFamily, Child child)
        {
            int id = FileContext.Families.First(f => f.Id == IdFamily).Children.IndexOf(child);
            FileContext.Families.First(f => f.Id == IdFamily).Children[id] = child;
            FileContext.SaveChanges();
            return child;
        }

        public async Task<Pet> UpdatePetAsync(int IdFamily, Pet pet)
        {
            int id = FileContext.Families.First(f => f.Id == IdFamily).Pets.IndexOf(pet);
            FileContext.Families.First(f => f.Id == IdFamily).Pets[id] = pet;
            FileContext.SaveChanges();
            return pet;
        }
        
        public async Task RemoveFamilyAsync(Family family)
        {
            FileContext.Families.Remove(family);
            FileContext.SaveChanges();
        }

        public async Task RemoveAdultAsync(int IdFamily, Adult adult)
        {
            FileContext.Families.First(f => f.Id == IdFamily).Adults.Remove(adult);
            FileContext.SaveChanges();    
        }

        public async Task RemoveChildAsync(int IdFamily, Child child)
        {
            FileContext.Families.First(f => f.Id == IdFamily).Children.Remove(child);
            FileContext.SaveChanges();
        }

        public async Task RemovePetAsync(int IdFamily, Pet pet)
        {
            FileContext.Families.First(f => f.Id == IdFamily).Pets.Remove(pet);
            FileContext.SaveChanges();
        }
    }
}