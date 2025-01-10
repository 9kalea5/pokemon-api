using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PokemonAPI.Models;

namespace PokemonAPI.Services
{
    public class PokemonService : IPokemonService
    {
        static List<Pokemon> pokemons=new List<Pokemon>(){
            new Pokemon(){Id="1", Name="Pikachu", Type="Electric", Level=50},
            new Pokemon(){Id="2", Name="Charmander", Type="Fire",Level=50},
            new Pokemon(){Id="3", Name="Squirtle", Type="Water", Level=50},
            new Pokemon(){Id="4", Name="Bulbasaur", Type="Grass", Level=50},
        }; 
        public List<Pokemon> GetPokemons(){
            return pokemons;
        }
        private readonly IMongoCollection<Pokemon> _pokemonCollection;

        public PokemonService(IOptions<PokemonDatabaseSettings> pokemonDatabaseSettings)
        {
            var mongoClient = new MongoClient(pokemonDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(pokemonDatabaseSettings.Value.DatabaseName);
            _pokemonCollection = mongoDatabase.GetCollection<Pokemon>(pokemonDatabaseSettings.Value.PokemonCollectionName);
        }
