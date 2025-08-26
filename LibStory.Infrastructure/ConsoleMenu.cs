using LibStory.Application.Interfaces;
using LibStory.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibStory.Infrastructure
{
    public class ConsoleMenu : IMainMenu
    {
        public void DrawMainMenu()
        {
            Console.WriteLine("Select your choice:");
            Console.WriteLine("1. Create Book");
            Console.WriteLine("2. Save Book");
            Console.WriteLine("3. PrintBook");
            Console.WriteLine("4. PrintAllBooks");
            //var choice = GetChoice();
        }

        public MenuChoice GetChoice()
        {
            do
            {
                var input = Console.ReadLine();
                if(int.TryParse(input, out int choice))
                {
                    return (MenuChoice)choice;
                }
            }
            while (true);
        }
    }
}
