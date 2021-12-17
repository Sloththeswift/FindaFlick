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
    class Titlemenu
    {
        public static async Task RunTitleMenu()
        {
            string icon = @" ___                  _         ___   _                   
(  _`\  _            ( )       (  _`\(_ )  _        ( )    
| (_(_)(_)  ___     _| |   _ _ | (_(_)| | (_)   ___ | |/') 
|  _)  | |/' _ `\ /'_` | /'_` )|  _)  | | | | /'___)| , <  
| |    | || ( ) |( (_| |( (_| || |    | | | |( (___ | |\`\ 
(_)    (_)(_) (_)`\__,_)`\__,_)(_)   (___)(_)`\____)(_) (_)
                                                           
                                                           
Here you can search for movies by title name.


";

            string[] upDown = { "Search movie by title name.", "Return to mainmenu", "Exit app." };
            MenuSkeleton menu = new MenuSkeleton(icon, upDown);
            int HighIndex = menu.Nav();
            switch (HighIndex)
            {
                case 0:
                    Console.WriteLine("Enter Title: ");
                    string title = Console.ReadLine();
                    SearchResults result = await SearchFunc.MovieTitle(title);
                    if (result != null && result.results.Any()) 
                    {
                        await ChooseResult.ChooseMovie(result);
                    }
                    else                     
                        Console.WriteLine("Sorry, nothing found");
                        Console.ReadKey();
                        await Titlemenu.RunTitleMenu();
                    
                    
                    break;

                case 1:
                    await Mainmenu .RunMainMenu();
                    break;

                case 2:
                    Environment.Exit(0);
                    break;

            }

            




        }

        public static async Task SearchTitle()
        {
            string icon = @" ___                  _         ___   _                   
(  _`\  _            ( )       (  _`\(_ )  _        ( )    
| (_(_)(_)  ___     _| |   _ _ | (_(_)| | (_)   ___ | |/') 
|  _)  | |/' _ `\ /'_` | /'_` )|  _)  | | | | /'___)| , <  
| |    | || ( ) |( (_| |( (_| || |    | | | |( (___ | |\`\ 
(_)    (_)(_) (_)`\__,_)`\__,_)(_)   (___)(_)`\____)(_) (_)
                                                           
                                                           
Here you can search for movies by title name.


";
            Clear();
            WriteLine(icon);
            WriteLine("Enter Title: ");
            string title = Console.ReadLine();
            SearchResults result = await SearchFunc.MovieTitle(title);
            if (result != null && result.results.Any())
            {
                await ChooseResult.ChooseMovie(result);
            }
            else Console.WriteLine("Sorry, nothing found");
            WriteLine("Press any key to return to menu");
            ReadKey();
            await Titlemenu.RunTitleMenu();

        }
    }
}
