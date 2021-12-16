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
    class ChooseResult
    {

        public static async Task ChooseMovie(SearchResults result) 
        {
            string icon = @" ___                  _         ___   _                   
(  _`\  _            ( )       (  _`\(_ )  _        ( )    
| (_(_)(_)  ___     _| |   _ _ | (_(_)| | (_)   ___ | |/') 
|  _)  | |/' _ `\ /'_` | /'_` )|  _)  | | | | /'___)| , <  
| |    | || ( ) |( (_| |( (_| || |    | | | |( (___ | |\`\ 
(_)    (_)(_) (_)`\__,_)`\__,_)(_)   (___)(_)`\____)(_) (_)
                                                           
                                                           
Here you can search for a movie by ID.


";
            List<string> resultList = new List<string>();
            foreach (Movie m in result.results) 
            {
                resultList.Add(m.title);
            }
            string[] upDown = resultList.ToArray();
            MenuSkeleton menu = new MenuSkeleton(icon, upDown);
            int HighIndex = menu.Nav();
            Clear();
            Movie movie = result.results[HighIndex];
            result.results[HighIndex] = await SearchFunc.SearchById(movie.id);
            result.results[HighIndex].showMovieResult();
            ReadKey();

        

        }
}
}
