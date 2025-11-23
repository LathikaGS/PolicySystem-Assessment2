using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

public class PolicyNotesIntegrationTests
    : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public PolicyNotesIntegrationTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Theory]
    [InlineData("POL1001", "First note")]
    [InlineData("POL1002", "Second note")]
    [InlineData("POL1003", "Third note")]
    public async Task PostNotes_Returns201_ForValidInput(string policyNumber, string note)
    {
        var response = await _client.PostAsJsonAsync("/notes", new
        {
            policyNumber = policyNumber,
            note = note
        });

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }

    [Theory]
    [InlineData(1, HttpStatusCode.OK)]
    [InlineData(9999, HttpStatusCode.NotFound)]
    public async Task GetNoteById_ReturnsExpectedStatus(int id, HttpStatusCode expectedStatus)
    {

        if (id == 1)
        {
            await _client.PostAsJsonAsync("/notes", new
            {
                policyNumber = "POL_TEST",
                note = "Test Note"
            });
        }

        var response = await _client.GetAsync($"/notes/{id}");
        Assert.Equal(expectedStatus, response.StatusCode);
    }

    [Theory]
    [InlineData("/notes")]
    public async Task GetNotes_Returns200(string url)
    {
        var response = await _client.GetAsync(url);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
