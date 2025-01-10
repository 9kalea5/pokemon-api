# pokemon-api

This project provides a RESTful API for managing Pokemon data. You can perform various actions, including retrieving, adding, updating, and deleting Pokemon.

## Features

- **Get all Pokemons**: Retrieve a list of all Pokemon in the database.
- **Get Pokemon by ID**: Fetch details of a specific Pokemon using its ID.
- **Get Pokemon by Type**: Retrieve Pokemon based on their type(s).
- **Add New Pokemon**: Add a new Pokemon to the database.
- **Update Pokemon**: Modify an existing Pokemon's information.
- **Delete Pokemon**: Remove a Pokemon from the database.

---

## Endpoints

### 1. Get All Pokemons
**GET** `/api/pokemons`

Returns a list of all Pokemons.

### 2. Get Pokemon by ID
**GET** `/api/pokemons/{id}`

Retrieve details of a specific Pokemon by its unique ID.

### 3. Get Pokemon by Type
**GET** `/api/pokemons/type/{type}`

Fetch Pokemons that belong to a specific type (e.g., Water, Fire).

### 4. Add New Pokemon
**POST** `/api/pokemons`

- **Request Body**: 
  ```json
  {
    "name": "Pikachu",
    "type": ["Electric"],
    "abilities": ["Static", "Lightning Rod"]
  }
