using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace FindaFlick
{
    class MenuSkeleton
    {
        private int HighIndex;
        private string[] Choices;
        private string Evoke;

        public MenuSkeleton(string evoke, string[] choices) 
        {
            Evoke = evoke;
            Choices = choices;
            HighIndex = 0;
        }


        private void ShowChoices() 
        {
            WriteLine(Evoke);
            for (int i = 0; i < Choices.Length; i++) 
            {
                string markedChoice = Choices[i];
                string prefix;

                if (i == HighIndex) 
                {
                    prefix = "■";

                }

                else 
                {
                    prefix = " ";
                }

                WriteLine($"{prefix} {markedChoice}");
            }
        }

        public int Nav() 
        {
            ConsoleKey keyPushed;
            do
            {
                Clear();
                ShowChoices();
                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPushed = keyInfo.Key;

                if (keyPushed == ConsoleKey.UpArrow)
                {
                    HighIndex--;
                    if (HighIndex == -1)
                    {
                        HighIndex = Choices.Length - 1;
                    }
                }
                else if (keyPushed == ConsoleKey.DownArrow)
                {
                    HighIndex++;
                    if (HighIndex == Choices.Length)
                    {
                        HighIndex = 0;
                    }
                }
            } while (keyPushed != ConsoleKey.Enter);
            return HighIndex;
        }

    }
}
