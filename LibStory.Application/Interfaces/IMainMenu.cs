using LibStory.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibStory.Application.Interfaces
{
    public interface IMainMenu
    {
        void DrawMainMenu();
        MenuChoice GetChoice();
        string GetBookByTitle();

    }
}
