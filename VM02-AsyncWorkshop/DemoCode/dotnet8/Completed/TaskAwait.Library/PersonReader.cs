using System.Text.Json;
using TaskAwait.Shared;

namespace TaskAwait.Library;

public class PersonReader
{
    HttpClient client = 
        new() { BaseAddress = new Uri("http://localhost:9874") };
    JsonSerializerOptions options = 
        new() { PropertyNameCaseInsensitive = true };

    public async Task<List<Person>> GetPeopleAsync(CancellationToken cancelToken = new())
    {
        //throw new NotImplementedException("Jeremy did not implement GetPeopleAsync");

        HttpResponseMessage response = 
            await client.GetAsync("people", cancelToken).ConfigureAwait(false);

        cancelToken.ThrowIfCancellationRequested();

        if (!response.IsSuccessStatusCode)
            throw new Exception($"Unable to retrieve People. Status code {response.StatusCode}");

        var stringResult = 
            await response.Content.ReadAsStringAsync(cancelToken).ConfigureAwait(false);
        var result = JsonSerializer.Deserialize<List<Person>>(stringResult, options);
        if (result is null)
            throw new JsonException("Unable to deserialize List<Person> object (json object may be empty)");
        return result;
    }

    public Person GetPerson(int id)
    {
        var result = People.GetPeople().FirstOrDefault(p => p.Id == id);
        if (result is null)
            throw new Exception($"Unable to locate Person object: ID={id}");
        Thread.Sleep(1000);
        return result;
    }


    // Why we return "Task<T>" whenever we use await
    // Using Task manually
    public Task<Person> GetPersonAsyncWithTask(int id)
    {
        Task<List<Person>> peopleTask = GetPeopleAsync();
        Task<Person> result = peopleTask.ContinueWith(task =>
        {
            List<Person> people = task.Result;
            Person selectedPerson = people.Single(p => p.Id == id);
            return selectedPerson;
        });
        return result;
    }

    // Why we return "Task<T>" whenever we use await
    // Using await
    public async Task<Person> GetPersonAsyncWithAwait(int id)
    {
        List<Person> people = await GetPeopleAsync();
        Person selectedPerson = people.Single(p => p.Id == id);
        return selectedPerson;
    }


    // Fully Async
    public async Task<Person> GetPersonAsync(int id, CancellationToken cancelToken = new())
    {
        //throw new NotImplementedException("Jeremy did not implement GetPersonAsync");

        HttpResponseMessage response =
            await client.GetAsync($"people/{id}", cancelToken).ConfigureAwait(false);

        cancelToken.ThrowIfCancellationRequested();

        if (!response.IsSuccessStatusCode)
            throw new Exception($"Unable to retrieve Person. Status code {response.StatusCode}");

        var stringResult =
            await response.Content.ReadAsStringAsync(cancelToken).ConfigureAwait(false);
        var result = JsonSerializer.Deserialize<Person>(stringResult, options);
        if (result is null)
            throw new JsonException("Unable to deserialize Person object (json object may be empty)");
        return result;
    }


    //// Await Task, Return Result
    //public async Task<Person> GetPersonAsync(int id)
    //{
    //    Task<Person> personTask = Task.Run(() => GetPerson(id));
    //    Person person = await personTask;
    //    return person;
    //}

    //// Return Task Directly
    //public Task<Person> GetPersonAsync(int id)
    //{
    //    Task<Person> personTask = Task.Run(() => GetPerson(id));
    //    return personTask;
    //}

    public async Task<List<int>> GetIdsAsync(
        CancellationToken cancelToken = new())
    {
        HttpResponseMessage response = 
            await client.GetAsync("people/ids", cancelToken).ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
            throw new Exception($"Unable to retrieve IDs. Status code {response.StatusCode}");

        var stringResult = 
            await response.Content.ReadAsStringAsync(cancelToken).ConfigureAwait(false);
        var result = JsonSerializer.Deserialize<List<int>>(stringResult);
        if (result is null)
            throw new JsonException("Unable to deserialize List<int> object (json object may be empty)");
        return result;
    }

    public async Task<List<Person>> GetPeopleAsync(IProgress<int> progress,
        CancellationToken cancelToken = new())
    {
        List<int> ids = await GetIdsAsync(cancelToken).ConfigureAwait(false);
        var people = new List<Person>();

        for (int i = 0; i < ids.Count; i++)
        {
            cancelToken.ThrowIfCancellationRequested();

            int id = ids[i];
            var person = await Task.Run(() => GetPerson(id)).ConfigureAwait(false);

            int percentComplete = (int)((i + 1) / (float)ids.Count * 100);
            progress.Report(percentComplete);

            people.Add(person);
        }

        return people;
    }
}