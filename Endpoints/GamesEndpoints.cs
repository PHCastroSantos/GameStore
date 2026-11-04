using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStore.DTOs;

namespace GameStore.Endpoints
{
    public static class GamesEndpoints
    {
    const string GetGameEndpointName = "GetGame";

    private static readonly List<GameDto> games = new()
    {
    new GameDto(
        1, 
        "Mortal Kombat", 
        "Fighting",
        19.99,
        new DateOnly(1992, 10, 8 )
    ),

    new GameDto(
        2,
        "Street Fighter",
        "Fighting",
        29.99,
        new DateOnly(1987, 8, 30)
    ),
    new GameDto(
        3,
        "Red Dead Redemption",
        "Action-Adventure",
        59.99,
        new DateOnly(2010, 5, 18)
    )
    };

    public static void MapGamesEndpoints(this WebApplication app)
        {

        var group = app.MapGroup("/games");

 // GET /games
group.MapGet("/", () => games);

// GET /games/{id}
group.MapGet("/{id}", (int id) => 
{
    var game = games.Find(game => game.Id == id);

    return game is null ? Results.NotFound() : Results.Ok(game);
})
.WithName(GetGameEndpointName);

// POST /games
group.MapPost("/", (CreateGameDto newGame) =>
{
    GameDto game = new (
        games.Count +1,
        newGame.Title,
        newGame.Genre,
        newGame.Price,
        newGame.ReleaseDate
    );
    games.Add(game);
    return Results.CreatedAtRoute(GetGameEndpointName, new {id = game.Id}, game);
});

// PUT /games/1
group.MapPut("/{id}", (int id, UpdateGameDto updatedGame) =>
{
    var index = games.FindIndex(game => game.Id == id);

    if (index == -1)
    {
        return Results.NotFound();
    }

    games[index] = new GameDto(
        id,
        updatedGame.Title,
        updatedGame.Genre,
        updatedGame.Price,
        updatedGame.ReleaseDate
    );
    return Results.NoContent();
});

// DELETE /games/1
group.MapDelete("/{id}", (int id) =>
{
   games.RemoveAll(game => game.Id == id);

   return Results.NoContent(); 
}); 
        }
    }
}