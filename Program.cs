using GameStore.DTOs;

var builder = WebApplication.CreateBuilder(args);

const string GetGameEndpointName = "GetGame";

var app = builder.Build();

List<GameDto> games = [
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
];

// GET /games
app.MapGet("/games", () => games);

// GET /games/{id}
app.MapGet("/games/{id}", (int id) => 
{
    var game = games.Find(game => game.Id == id);

    return game is null ? Results.NotFound() : Results.Ok(game);
})
.WithName(GetGameEndpointName);

// POST /games
app.MapPost("/games", (CreateGameDto newGame) =>
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
app.MapPut("/games/{id}", (int id, UpdateGameDto updatedGame) =>
{
    var index = games.FindIndex(game => game.Id == id);

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
app.MapDelete("/games/{id}", (int id) =>
{
   games.RemoveAll(game => game.Id == id);

   return Results.NoContent(); 
});


app.Run();