using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;

namespace FindaFlick
{
    static class SearchFunc
    {
        public static HttpClient client = new HttpClient();
        static string key;
        public static void setupApi() 
        {
            DotNetEnv.Env.TraversePath().Load();
            key = Environment.GetEnvironmentVariable("API_KEY");
        }

        public static async Task<Movie> SearchById(int id) 
        {
            string uriId = $"https://api.themoviedb.org/3/movie/{id}?api_key={key}";

            var response = await client.GetAsync(uriId);
            try 
            {
                response.EnsureSuccessStatusCode();
            }
            catch 
            {
                return null;
            }
            
            var responseContent = await response.Content.ReadAsStringAsync();


            return JsonConvert.DeserializeObject<Movie>(responseContent);

        }
        public static async Task<SearchResults> MovieTitleTitle(string title)
        {

          


            string uriTitle = $"https://api.themoviedb.org/3/search/movie?api_key={key}&language=en-US&query={title}&page=1&include_adult=false";

            var response = await client.GetAsync(uriTitle);
            try 
            {
                response.EnsureSuccessStatusCode();
            }
            catch 
            {
                return null;
            }
            
            var responseContent = await response.Content.ReadAsStringAsync();


            return JsonConvert.DeserializeObject<SearchResults>(responseContent);
            



        }

    }
}
