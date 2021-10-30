using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Models;

namespace FirstAssignmentDNP.Data
{
    public class CloudFamilyService : IFamiliesData
    {
        private string uri = "https://localhost:5003";

        private readonly HttpClient client;

        public CloudFamilyService()
        {
            client = new HttpClient();
        }


        public Task<IList<Family>> GetFamiliesAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Family> GetFamilyAsync(int IdFamily)
        {
            throw new System.NotImplementedException();
        }

        public Task<Adult> GetAdultAsync(int IdFamily, int IdAdult)
        {
            throw new System.NotImplementedException();
        }

        public Task<Child> GetChildAsync(int IdFamily, int IdChild)
        {
            throw new System.NotImplementedException();
        }

        public Task<Pet> GetPetAsync(int IdFamily, int IdPet)
        {
            throw new System.NotImplementedException();
        }

        public Task AddAdultToFamilyAsync(Family family, Adult _newAdult)
        {
            throw new System.NotImplementedException();
        }

        public Task AddChildToFamilyAsync(Family family, Child _newChild)
        {
            throw new System.NotImplementedException();
        }

        public Task AddFamilyAsync(Family family)
        {
            throw new System.NotImplementedException();
        }

        public Task AddInterest(int IdFamily, Child child, Interest interest)
        {
            throw new System.NotImplementedException();
        }

        public Task AddPetForFamily(Family family, Child? child, Pet pet)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateFamily(Family family)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAdult(int familyId, Adult adult)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateChild(int familyId, Child child)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdatePet(int familyId, Pet pet)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveFamily(Family family)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveAdult(int IdFamily, Adult adult)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveChild(int IdFamily, Child child)
        {
            throw new System.NotImplementedException();
        }

        public Task RemovePet(int IdFamily, Pet pet)
        {
            throw new System.NotImplementedException();
        }
    }
}