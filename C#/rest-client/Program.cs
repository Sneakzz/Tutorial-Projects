using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;

namespace WebAPIClient
{
    class Program
    {
        // create the HttpClient object that handles the requests and responses
        private static readonly HttpClient client = new HttpClient();
        static void Main(string[] args)
        {
            // the program can not stop before the Task has completed so use .Wait()
            ProcessRepositories().Wait();
        }

        private static async Task ProcessRepositories()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            // creating the JSON serializer
            var serializer = new DataContractJsonSerializer(typeof(List<Repo>));

            // get a stream instead of string since the serializer uses a stream as its source
            var streamTask = client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");
            // use the serializer to convert JSON into C# objects
            var repositories = serializer.ReadObject(await streamTask) as List<Repo>;

            // displaying the name of each repository
            foreach (var repo in repositories)
            {
                Console.WriteLine(repo.name);
            }
        }
    }

    
}
