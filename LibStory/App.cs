using LibStory.Application.Commands;
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
        private readonly IManager _manager;
        private readonly Dictionary<MenuChoice, Func<Task>> _menuActions;
        public App(IMediator mediatr, IMainMenu menu , IManager manager)
        {
            _mediatr = mediatr;
            _menu = menu;
            _manager = manager;
            _menuActions = new Dictionary<MenuChoice, Func<Task>>()
            {
                { MenuChoice.CreateBook, CreateBookAsync },
                { MenuChoice.ShowAllBooks, ShowAllBooksAsync },
                { MenuChoice.SearchBookByTitle, SearchBookByTitleAsync },
                { MenuChoice.CreateRecord, CreateRecordAsync }
            };
        }
        public async Task Run()
        {
            _menu.DrawMainMenu();
            var choice = _menu.GetChoice();
            _menuActions.TryGetValue(choice, out var action);
            if(action is not null)
            {
                await action();
            }
        }
        private async Task CreateBookAsync()
        {
            var response = await _mediatr.Send(new AddBookCommand());
            if(response)
                _manager.PrinteMessage("Libro creado con exito");
            else
                _manager.PrinteMessage("No se ha podido crear el libro");
        }
        private async Task ShowAllBooksAsync()
        {
            var response = await _mediatr.Send(new GetAllBooksQuery());
            _manager.PrintBooks(response);
        }
        private async Task SearchBookByTitleAsync()
        {
            var title = _manager.GetResponse("Introduce el titulo del libro a buscar: ");
            var response = await _mediatr.Send(new BookByTitleQuery() { Title = title });
            _manager.PrintBooks(response);
        }
        private async Task CreateRecordAsync()
        {
            //TODO
        }
    }
}
