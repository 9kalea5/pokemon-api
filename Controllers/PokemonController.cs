using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models;
using PokemonAPI.Services;

namespace PokemonAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _pokemonService;

        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Pokemon>>> GetAll()
        {
            var pokemons = await _pokemonService.GetAllAsync();
            return Ok(pokemons);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pokemon>> GetById(string id)
        {
            var pokemon = await _pokemonService.GetByIdAsync(id);
            if (pokemon == null)
            {
                return NotFound();
            }
            return Ok(pokemon);
        }

        [HttpGet("type/{type}")]
        public async Task<ActionResult<List<Pokemon>>> GetByType(string type)
        {
            var pokemons = await _pokemonService.GetByTypeAsync(type);
            return Ok(pokemons);
        }

        [HttpPost]
        public async Task<ActionResult<Pokemon>> Create(Pokemon pokemon)
        {
            await _pokemonService.CreateAsync(pokemon);
            return CreatedAtAction(nameof(GetById), new { id = pokemon.Id }, pokemon);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Pokemon pokemon)
        {
            var existingPokemon = await _pokemonService.GetByIdAsync(id);
            if (existingPokemon == null)
            {
                return NotFound();
            }
            pokemon.Id = id;
            await _pokemonService.UpdateAsync(id, pokemon);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var pokemon = await _pokemonService.GetByIdAsync(id);
            if (pokemon == null)
            {
                return NotFound();
            }
            await _pokemonService.DeleteAsync(id);
            return NoContent();
        }
    }
}
