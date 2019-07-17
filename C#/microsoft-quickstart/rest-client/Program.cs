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
            // get the result value of this task
            var repositories = ProcessRepositories().Result;

            // displaying the repository names to the console
            foreach (var repo in repositories)
            {
                Console.WriteLine(repo.Name);
                Console.WriteLine(repo.Description);
                Console.WriteLine(repo.GithubHomeUrl);
                Console.WriteLine(repo.Homepage);
                Console.WriteLine(repo.Watchers);
                Console.WriteLine(repo.LastPush);
                Console.WriteLine();
            }
        }

        private static async Task<List<Repository>> ProcessRepositories()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            // creating the JSON serializer
            var serializer = new DataContractJsonSerializer(typeof(List<Repository>));

            // get a stream instead of string since the serializer uses a stream as its source
            var streamTask = client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");
            // use the serializer to convert JSON into C# objects
            var repositories = serializer.ReadObject(await streamTask) as List<Repository>;

            return repositories;
        }
    }

    
}
