using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;

namespace FindaFlick
{
    internal class Titlemenu
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
                        await ChooseMovie(result);
                    }
                    else
                        Console.WriteLine("Sorry, nothing found");
                    Console.ReadKey();
                    await Titlemenu.RunTitleMenu();

                    break;

                case 1:
                    await Mainmenu.RunMainMenu();
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
                await ChooseMovie(result);
            }
            else
            {
                Console.WriteLine("Sorry, nothing found");
            }
            WriteLine("Press any key to return to menu");
            ReadKey();

            await Titlemenu.RunTitleMenu();
        }

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
                SearchResults nextpage = await SearchFunc.MovieTitle(SearchFunc.currentSearchWord, result.page + 1);
                await ChooseMovie(nextpage);
                return;
            }
            else if (upDown[HighIndex] == "[Previous page]")
            {
                SearchResults nextpage = await SearchFunc.MovieTitle(SearchFunc.currentSearchWord, result.page - 1);
                await ChooseMovie(nextpage);
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