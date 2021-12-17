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
        public static string currentSearchWord ;
        public static HttpClient client = new HttpClient();
        static string key;
        public static void setupApi() 
        {
            DotNetEnv.Env.TraversePath().Load();
            key = Environment.GetEnvironmentVariable("API_KEY");


            if (key == null) 
            {
                WriteLine(@" ___                  _         ___   _                   
(  _`\  _            ( )       (  _`\(_ )  _        ( )    
| (_(_)(_)  ___     _| |   _ _ | (_(_)| | (_)   ___ | |/') 
|  _)  | |/' _ `\ /'_` | /'_` )|  _)  | | | | /'___)| , <  
| |    | || ( ) |( (_| |( (_| || |    | | | |( (___ | |\`\ 
(_)    (_)(_) (_)`\__,_)`\__,_)(_)   (___)(_)`\____)(_) (_)
                                                           
                                                           
");
                WriteLine("No Api key found, please enter a valid key:");
                key = ReadLine();
            }
             
            

               
               

            
            
           
            
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
        public static async Task<SearchResults> MovieTitle(string title, int page=1)
        {



            currentSearchWord = title;
            string uriTitle = $"https://api.themoviedb.org/3/search/movie?api_key={key}&language=en-US&query={title}&page={page}&include_adult=false";

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
