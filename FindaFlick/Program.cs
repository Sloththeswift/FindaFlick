using System.Threading.Tasks;

namespace FindaFlick
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            SearchFunc.setupApi();

            await Mainmenu.RunMainMenu();
        }
    }
}