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
    class ShowMovieId
    {

        public static HttpClient client = new HttpClient();
        public static async Task ShowMovieIds()
        {
            string icon = @" ___                  _         ___   _                   
(  _`\  _            ( )       (  _`\(_ )  _        ( )    
| (_(_)(_)  ___     _| |   _ _ | (_(_)| | (_)   ___ | |/') 
|  _)  | |/' _ `\ /'_` | /'_` )|  _)  | | | | /'___)| , <  
| |    | || ( ) |( (_| |( (_| || |    | | | |( (___ | |\`\ 
(_)    (_)(_) (_)`\__,_)`\__,_)(_)   (___)(_)`\____)(_) (_)
                                                           
                                                           
Here you can search for a movie by ID.


";
            Console.Clear();
            WriteLine(icon);
            
            DotNetEnv.Env.TraversePath().Load();
            string key = Environment.GetEnvironmentVariable("API_KEY");
            Console.WriteLine("Enter ID: ");
            int id = Convert.ToInt32(Console.ReadLine());


            string uriId = $"https://api.themoviedb.org/3/movie/{id}?api_key={key}";

            var response = await client.GetAsync(uriId);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            

            MovieDetailsId movie = JsonConvert.DeserializeObject<MovieDetailsId>(responseContent);

            WriteLine(movie.original_title);
            WriteLine(movie.overview);
            WriteLine(movie.runtime);
            WriteLine(movie.release_date);
            WriteLine(movie.homepage);
            WriteLine(movie.vote_average);
            WriteLine(movie.poster_path);
            WriteLine(movie.original_language);
            WriteLine("Press any key to clear results and return to menu");
            ReadKey();
            await Idmenu.RunIdMenu();


        }
    }
}
