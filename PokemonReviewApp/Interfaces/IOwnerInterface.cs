using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces
{
    public interface IOwnerInterface
    {
        ICollection<Owner> GetOwners();
        Owner GetOwner(int ownerId);
        ICollection<Pokemon> GetPokemonByOwner(int ownerId);
        bool OwnerExists(int ownerId);
        bool CreateOwner(Owner owner);
        bool Save();
    }
}
