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
            string icon = @$" ___                  _         ___   _                   
(  _`\  _            ( )       (  _`\(_ )  _        ( )    
| (_(_)(_)  ___     _| |   _ _ | (_(_)| | (_)   ___ | |/') 
|  _)  | |/' _ `\ /'_` | /'_` )|  _)  | | | | /'___)| , <  
| |    | || ( ) |( (_| |( (_| || |    | | | |( (___ | |\`\ 
(_)    (_)(_) (_)`\__,_)`\__,_)(_)   (___)(_)`\____)(_) (_)
                                                           
                                                           
{result.total_results} results were found, this is page {result.page} of {result.total_pages}, pick your movie!


";
            List<string> resultList = new List<string>();
            foreach (Movie m in result.results) 
            {
                resultList.Add(m.title);
            }
            if (result.page != result.total_pages) 
            {
                resultList.Add("[Next page]");
            }
            if (result.page != 1)
            {
                resultList.Add("[Previous page]");
            }


            string[] upDown = resultList.ToArray();
            MenuSkeleton menu = new MenuSkeleton(icon, upDown);
            
            int HighIndex = menu.Nav();
            Clear();
            if (upDown[HighIndex] == "[Next page]") 
            {
                SearchResults nextpage = await SearchFunc.MovieTitle(SearchFunc.currentSearchWord, result.page+1);
                await ChooseResult.ChooseMovie(nextpage);
                return;
            }
            else if (upDown[HighIndex] == "[Previous page]") 
            {
                SearchResults nextpage = await SearchFunc.MovieTitle(SearchFunc.currentSearchWord, result.page - 1);
                await ChooseResult.ChooseMovie(nextpage);
                return;
            }
            else 
            {
                Movie movie = result.results[HighIndex];
                result.results[HighIndex] = await SearchFunc.SearchById(movie.id);
                result.results[HighIndex].showMovieResult();




                
                
                

            }
            
            
            ReadKey();
            
        

        }
    }
}
