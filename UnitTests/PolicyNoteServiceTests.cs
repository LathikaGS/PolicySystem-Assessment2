using Microsoft.EntityFrameworkCore;
using PolicyNoteService.Repositories;
using PolicyNoteService.Data;
using PolicyNoteService.Services;
using Xunit;

public class PolicyNoteServiceTheoryTests
{
    private PolicyService CreateService()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        var context = new AppDbContext(options);
        var repo = new PolicyNoteRepository(context);
        return new PolicyService(repo);
    }

    [Theory]
    [InlineData("POL123", "Test Note 1")]
    [InlineData("POL456", "Test Note 2")]
    [InlineData("POL789", "Test Note 3")]
    public void AddNote_ShouldStoreNote(string policyNumber, string noteText)
    {
        var service = CreateService();

        var note = service.CreateNote(policyNumber, noteText);

        Assert.NotNull(note);
        Assert.Equal(policyNumber, note.PolicyNumber);
        Assert.Equal(noteText, note.Note);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void GetNotes_ShouldReturnCorrectCount(int count)
    {
        var service = CreateService();

        for (int i = 0; i < count; i++)
        {
            service.CreateNote($"POL{i}", $"Note {i}");
        }

        var notes = service.GetNotes();

        Assert.Equal(count, notes.Count);
    }

    [Theory]
    [InlineData(1, true)]
    [InlineData(999, false)]
    public void GetNoteById_ShouldReturnExpectedResult(int id, bool shouldExist)
    {
        var service = CreateService();

        var created = service.CreateNote("POL001", "Existing Note");

        var result = service.GetNote(id);

        if (shouldExist)
        {
            Assert.NotNull(result);
            Assert.Equal(created.Id, result!.Id);
        }
        else
        {
            Assert.Null(result);
        }
    }
}
