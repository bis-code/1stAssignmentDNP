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
        Task AddInterest(int IdFamily, Child child, Interest interest);
        Task AddPetForFamily(Family family, Child? child, Pet pet);

        Task UpdateFamily(Family family);
        Task UpdateAdult(int familyId, Adult adult);
        Task UpdateChild(int familyId, Child child);
        Task UpdatePet(int familyId, Pet pet);
        Task RemoveFamily(Family family);
        Task RemoveAdult(int IdFamily, Adult adult);
        Task RemoveChild(int IdFamily, Child child);
        Task RemovePet(int IdFamily, Pet pet);
    }
}