using Demant.Interview.Infrastructure.Web.Model;
using Demant.Interview.Infrastructure.Web.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
WebApplication app = builder.Build();

InMemoryBoardGameRepository boardGameRepository = new InMemoryBoardGameRepository();

app.UseDefaultFiles();
app.UseRouting();

app.MapGet("/games", () => boardGameRepository.List());
app.MapPost("/games", (Boardgame game) =>
{
    try
    {
        boardGameRepository.Create(game);
    }
    catch (InvalidOperationException e)
    {
        return Results.BadRequest(e.Message);
    }

    return Results.Ok();
});

app.MapDelete("/games/{name}", (string name) =>
{
    try
    {
        boardGameRepository.Delete(name);
    }
    catch (InvalidOperationException e)
    {
        return Results.BadRequest(e.Message);
    }

    return Results.Ok();
});

app.MapPost("/borrow-game/{game}", (string game, string user, int days) =>
{
    var games = boardGameRepository.List().Result;
    if (games.Any(g => g.Name == game && g.BorrowedBy != null))
    {
        return Results.BadRequest($"Game has already been borrowed");
    }

    try
    {
        boardGameRepository.Borrow(game, user, days);
    }
    catch (InvalidOperationException e)
    {
        return Results.BadRequest(e.Message);
    }

    return Results.Ok();
});

app.MapPost("/return-game/{game}", (string game) =>
{
    try
    {
        boardGameRepository.Return(game);
    }
    catch (InvalidOperationException e)
    {
        return Results.BadRequest(e.Message);
    }

    return Results.Ok();
});


app.Run();