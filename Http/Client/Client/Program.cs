using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Client
{
    internal class Program
    {
        static readonly HttpClient client = new HttpClient();

        static async Task Main()
        {
            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try
            {
                HttpResponseMessage response = await client.GetAsync("http://localhost:8888/");
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);

                Console.WriteLine(responseBody);

                const string myNameByHeader = "http://localhost:8888/MyNameByHeader/";
                const string myName = "http://localhost:8888/MyName/";
                const string information = "http://localhost:8888/Information/";
                const string success = "http://localhost:8888/Success/";
                const string redirection = "http://localhost:8888/Redirection/";
                const string clientError = "http://localhost:8888/ClientError/";
                const string serverError = "http://localhost:8888/ServerError/";

                var urls = new List<string>()
                {
                    myName,
                    information,
                    success,
                    redirection,
                    clientError,
                    serverError
                };

                foreach (var url in urls)
                {
                    CheckUrl(url);
                }

                GetMyNameByHeader(myNameByHeader);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }

        static async Task CheckUrl(string url)
        {
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            // Above three lines can be replaced with new helper method below
            // string responseBody = await client.GetStringAsync(uri);

            Console.WriteLine(responseBody);
        }

        static async Task GetMyNameByHeader(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(url))
                {
                    using (HttpContent content = response.Content)
                    {
                        string myContent = await content.ReadAsStringAsync();
                        HttpContentHeaders headers = content.Headers;

                        Console.WriteLine(content);
                    }
                }
            }
        }

        static async Task PostMyNameByHeader(string url)
        {
            IEnumerable<KeyValuePair<string,string>> queries = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("query1","William"),
                new KeyValuePair<string, string>("query2","Robert")
            };

            HttpContent httpContent = new FormUrlEncodedContent(queries);

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.PostAsync(url, httpContent))
                {
                    using (HttpContent content = response.Content)
                    {
                        string myContent = await content.ReadAsStringAsync();

                        HttpContentHeaders headers = content.Headers;

                        Console.WriteLine(myContent);
                    }
                }
            }
        }
    }
}
