using System.Text.Json;
using Microsoft.AspNetCore.Connections;

namespace RedHorizonSite.Data;

public class ShowService
{
    private const string FILE_PATH = "shows.json";

    //TODO: It's not very efficent to load all the json everytime.
    public async Task AddShowAsync(Show newShow)
    {
        var shows = new ShowsData(new HashSet<Show>());

        if (File.Exists(FILE_PATH))
        {
            var existingDataAsJson = await File.ReadAllTextAsync(FILE_PATH);
            var existingData = JsonSerializer.Deserialize<ShowsData>(existingDataAsJson);
            shows = existingData;
        }

        shows.Shows.Add(newShow);

        var json =  JsonSerializer.Serialize(shows);
        await File.WriteAllTextAsync(FILE_PATH,json);
    }

    public async Task<ShowsData> GetShowsAsync()
    {
        if (File.Exists(FILE_PATH))
        {
            var json = await File.ReadAllTextAsync(FILE_PATH);
            return JsonSerializer.Deserialize<ShowsData>(json) ?? new ShowsData(new HashSet<Show>());
        }

        throw new ArgumentNullException("file don't exist");

    }
}

public record Show(string Date, string Location, string Description);

public record ShowsData(HashSet<Show> Shows);