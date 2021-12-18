using System;
using System.Threading.Tasks;
using static System.Console;

namespace FindaFlick
{
    internal class Idmenu
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

            string[] upDown = { "Search movie by ID-number", "Return to mainmenu", "Exit app" };
            MenuSkeleton menu = new MenuSkeleton(icon, upDown);
            int HighIndex = menu.Nav();
            switch (HighIndex)
            {
                case 0:
                    await RunMenu();
                    break;

                case 1:
                    await Mainmenu.RunMainMenu();
                    break;

                case 2:
                    Environment.Exit(0);
                    break;
            }
        }

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

            Console.WriteLine("Enter ID number: ");
            try
            {
                int id = Convert.ToInt32(Console.ReadLine());
                Movie movieResult = await SearchFunc.SearchById(id);
                if (movieResult != null)
                {
                    Clear();
                    movieResult.showMovieResult();
                }
                else
                {
                    Console.WriteLine("Sorry, nothing found");
                }
            }
            catch
            {
                Console.WriteLine("Not a number...");
            }

            WriteLine("Press any key to clear results and return to menu");
            ReadKey();
            await Idmenu.RunIdMenu();
        }
    }
}