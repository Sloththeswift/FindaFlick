using static System.Console;

namespace FindaFlick
{
    public class Movie
    {
        public bool adult { get; set; }
        public string backdrop_path { get; set; }
        public object belongs_to_collection { get; set; }
        public int budget { get; set; }
        public Genre[] genres { get; set; }
        public string homepage { get; set; }
        public int id { get; set; }
        public string imdb_id { get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }
        public string overview { get; set; }
        public float popularity { get; set; }
        public string poster_path { get; set; }
        public Production_Companies[] production_companies { get; set; }
        public Production_Countries[] production_countries { get; set; }
        public string release_date { get; set; }
        public int revenue { get; set; }
        public int runtime { get; set; }
        public Spoken_Languages[] spoken_languages { get; set; }
        public string status { get; set; }
        public string tagline { get; set; }
        public string title { get; set; }
        public bool video { get; set; }
        public float vote_average { get; set; }
        public int vote_count { get; set; }

        public void showMovieResult()
        {
            WriteLine(@" ___                  _         ___   _
(  _`\  _            ( )       (  _`\(_ )  _        ( )
| (_(_)(_)  ___     _| |   _ _ | (_(_)| | (_)   ___ | |/')
|  _)  | |/' _ `\ /'_` | /'_` )|  _)  | | | | /'___)| , <
| |    | || ( ) |( (_| |( (_| || |    | | | |( (___ | |\`\
(_)    (_)(_) (_)`\__,_)`\__,_)(_)   (___)(_)`\____)(_) (_)

");

            WriteLine($"Original Title: {original_title}");
            WriteLine();
            WriteLine($"Summary: {overview}");
            WriteLine();
            WriteLine($"Runtime: {runtime} minutes.");
            WriteLine();
            WriteLine($"Release date: {release_date}");
            WriteLine();
            if (homepage == "")
            {
                WriteLine("Homepage not found");
            }
            else
            {
                WriteLine($"Homepage: {homepage}");
            }

            WriteLine();
            WriteLine($"Voting average: {vote_average}");
            WriteLine();
            WriteLine($"Poster path: https://www.themoviedb.org/t/p/w1280{poster_path}");
            WriteLine();
            WriteLine($"Original language: {original_language}");
        }
    }

    public class Genre
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Production_Companies
    {
        public int id { get; set; }
        public string logo_path { get; set; }
        public string name { get; set; }
        public string origin_country { get; set; }
    }

    public class Production_Countries
    {
        public string iso_3166_1 { get; set; }
        public string name { get; set; }
    }

    public class Spoken_Languages
    {
        public string english_name { get; set; }
        public string iso_639_1 { get; set; }
        public string name { get; set; }
    }
}