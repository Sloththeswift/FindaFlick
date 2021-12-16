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
    class MovieIdMenu
    {


        
        public static async Task RunMenu()
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
            
           
            Console.WriteLine("Enter ID: ");
            try 
            {
                int id = Convert.ToInt32(Console.ReadLine());
                Movie movieResult = await SearchFunc.SearchById(id);
                if (movieResult != null)
                {
                    movieResult.showMovieResult();

                }
                else
                {
                    Console.WriteLine("Sorry, nothing found");
                }
            }
            catch 
            {
                Console.WriteLine("Not an int sir");
            }
            
            




            WriteLine("Press any key to clear results and return to menu");
            ReadKey();
            await Idmenu.RunIdMenu();


        }
    }
}
