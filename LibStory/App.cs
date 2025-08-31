using LibStory.Application.Commands;
using LibStory.Application.Interfaces;
using LibStory.Application.Queries;
using LibStory.Domain.Enums;
using MediatR;

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
            await action();
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
            if (response == null || !response.Any())
            {
                _manager.PrinteMessage($"No se encontraron libros con el titulo: {title}");
                return;
            }

            _manager.PrintBooks(response);
            
        }
        private async Task CreateRecordAsync()
        {
            //TODO -> IMPORTANTE manejo de excepciones (Libro no encontrado...)
            //TODO -> Mostrrar Libros antes de pedir nada, filtrar entre nombre o id
            //DONE -> filtrar por nombre
            await ShowAllBooksAsync();
            var title = _manager.GetResponse("Introduce el titulo del libro que estas leyendo: ");
            int PageFrom = 0;
            int PageTo = 0;
            do
            {
                 PageFrom = (int)_manager.GetNumericResponse("Introduce la pagina desde la que has leido: ");
                 PageTo = (int)_manager.GetNumericResponse("Introduce la pagina hasta la que has leido: ");
                if(PageTo <= PageFrom)
                    _manager.PrinteMessage("La pagina hasta la que has leido debe ser mayor que la pagina desde la que has leido");
                else
                    break;
            }
            while (true);
            var response = await _mediatr.Send(new AddRecordCommand(){ BookTitle = title, PageFrom = PageFrom, PageTo = PageTo });
            if (response)
                _manager.PrinteMessage("Historial actualizado");
            else
                _manager.PrinteMessage("Hubo un error al actualizar el historial");
        }
    }
}
