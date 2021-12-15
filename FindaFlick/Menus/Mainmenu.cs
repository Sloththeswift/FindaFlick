using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace FindaFlick
{
    class Mainmenu
    {
        public static async Task RunMainMenu()
        {
            string icon = @" ___                  _         ___   _                   
(  _`\  _            ( )       (  _`\(_ )  _        ( )    
| (_(_)(_)  ___     _| |   _ _ | (_(_)| | (_)   ___ | |/') 
|  _)  | |/' _ `\ /'_` | /'_` )|  _)  | | | | /'___)| , <  
| |    | || ( ) |( (_| |( (_| || |    | | | |( (___ | |\`\ 
(_)    (_)(_) (_)`\__,_)`\__,_)(_)   (___)(_)`\____)(_) (_)
                                                           
                                                           
Welcome to FindaFlick, let's find some movie trivia for you!
Use the arrow keys and enter to navigate the app.


";
            
            string[] upDown= { "Search movie by title name.", "Search movie by ID.", "Exit app." };
            MenuSkeleton menu = new MenuSkeleton(icon, upDown);
            int HighIndex = menu.Nav();
            switch (HighIndex)
            {
                case 0:
                    await Titlemenu.RunTitleMenu();
                    break;

                case 1:
                    await ShowMovieId.ShowMovieIds();
                    break;

                case 2:
                    Environment.Exit(0);
                    break;

            }
            

        }
    }
}
