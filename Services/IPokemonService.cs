using PokemonAPI.Models;

namespace PokemonAPI.Services
{
    public interface IPokemonService
    {
        Task<List<Pokemon>> GetAllAsync();
        Task<Pokemon> GetByIdAsync(string id);
        Task<List<Pokemon>> GetByTypeAsync(string type);
        Task<Pokemon> CreateAsync(Pokemon pokemon);
        Task UpdateAsync(string id, Pokemon pokemon);
        Task DeleteAsync(string id);
    }
}
