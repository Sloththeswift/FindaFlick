using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FindaFlick
{
    class Program
    {
        static async Task Main(string[] args) 
        {
            SearchFunc.setupApi();
            
            await Mainmenu.RunMainMenu();
        }
    }
}
