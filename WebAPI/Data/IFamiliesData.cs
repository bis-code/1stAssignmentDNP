using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace FirstAssignmentDNP.Data
{
    public interface IFamiliesData
    {
        Task<IList<Family>> GetFamiliesAsync();
        Task<Family> GetFamilyAsync(int IdFamily);
        Task<Adult> GetAdultAsync(int IdFamily, int IdAdult);
        Task<Child> GetChildAsync(int IdFamily, int IdChild);
        Task<Pet> GetPetAsync(int IdFamily, int IdPet);
        Task AddAdultToFamilyAsync(Family family, Adult _newAdult);
        Task AddChildToFamilyAsync(Family family, Child _newChild);
        Task AddFamilyAsync(Family family);
        Task AddInterestAsync(int IdFamily, Child child, Interest interest);
        Task AddPetForFamilyAsync(Family family, Child? child, Pet pet);

        Task UpdateFamilyAsync(Family family);
        Task UpdateAdultAsync(int familyId, Adult adult);
        Task UpdateChildAsync(int familyId, Child child);
        Task UpdatePetAsync(int familyId, Pet pet);
        Task RemoveFamilyAsync(Family family);
        Task RemoveAdultAsync(int IdFamily, Adult adult);
        Task RemoveChildAsync(int IdFamily, Child child);
        Task RemovePetAsync(int IdFamily, Pet pet);
    }
}