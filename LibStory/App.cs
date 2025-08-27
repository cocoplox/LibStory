using LibStory.Application.Interfaces;
using LibStory.Application.Queries;
using LibStory.Domain.Enums;
using LibStory.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibStory
{

    public class App
    {
        private readonly IMediator _mediatr;
        private readonly IMainMenu _menu;
        public App(IMediator mediatr, IMainMenu menu)
        {
            _mediatr = mediatr;
            _menu = menu;
        }
        public async Task Run()
        {
            //TODO: Graphic UI :(
            _menu.DrawMainMenu();
            var choice = _menu.GetChoice();
            switch (choice)
            {
                case MenuChoice.CreateBook:
                    await _mediatr.Send(new AddBookQuery());
                    break;
                case MenuChoice.PrintBook:
                    await _mediatr.Send(new PrintBookQuery() { bookToPrint = new Domain.Models.Book() { Title = "Test" } });
                    break;
                case MenuChoice.ShowAllBooks:
                    await _mediatr.Send(new PrintAllBooksQuery());
                    break;
            }
            //Confirmación para continuar o salir
        }
    }
}
