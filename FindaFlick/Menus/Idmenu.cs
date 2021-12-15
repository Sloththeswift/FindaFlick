using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace FindaFlick
{
    class Idmenu
    {
        public static async Task RunIdMenu()
        {
            string icon = @" ___                  _         ___   _                   
(  _`\  _            ( )       (  _`\(_ )  _        ( )    
| (_(_)(_)  ___     _| |   _ _ | (_(_)| | (_)   ___ | |/') 
|  _)  | |/' _ `\ /'_` | /'_` )|  _)  | | | | /'___)| , <  
| |    | || ( ) |( (_| |( (_| || |    | | | |( (___ | |\`\ 
(_)    (_)(_) (_)`\__,_)`\__,_)(_)   (___)(_)`\____)(_) (_)
                                                           
                                                           
Here you can search for a movie by ID.


";

            string[] upDown = { "Search movie by ID", "Return to mainmenu", "Exit app" };
            MenuSkeleton menu = new MenuSkeleton(icon, upDown);
            int HighIndex = menu.Nav();
            switch (HighIndex)
            {
                case 0:
                    await ShowMovieId.ShowMovieIds();
                    break;

                case 1:
                    await Mainmenu.RunMainMenu();
                    break;

                case 2:
                    Environment.Exit(0);
                    break;

            }


        }
    }
}
