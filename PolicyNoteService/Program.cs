using Microsoft.EntityFrameworkCore;
using PolicyNoteService.Data;
using PolicyNoteService.Repositories;
using PolicyNoteService.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("PolicyNotesDb"));

builder.Services.AddScoped<PolicyNoteRepository>();
builder.Services.AddScoped<PolicyService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("/notes", (PolicyService service, CreatePolicyNoteDto dto) =>
{
    var result = service.CreateNote(dto.PolicyNumber, dto.Note);
    return Results.Created($"/notes/{result.Id}", result);
});

app.MapGet("/notes", (PolicyService service) =>
{
    return Results.Ok(service.GetNotes());
});

app.MapGet("/notes/{id:int}", (PolicyService service, int id) =>
{
    var note = service.GetNote(id);
    return note is null ? Results.NotFound() : Results.Ok(note);
});

app.Run();

record CreatePolicyNoteDto(string PolicyNumber, string Note);

public partial class Program { }
