using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Shared;

namespace Presenter
{

    /// <summary>
    /// класс Presenter в архитектуре MVP
    /// связывает пассивное представление (IGameView) с моделью (IGameService)
    /// Обрабатывает действия пользователя, полученные от View, и обновляет View данными из Service
    /// </summary>
    public class GamePresenter
    {
        private readonly IGameView _view;
        private readonly IGameService _service;
        private IEnumerable<Game> _allGamesCache; // Кэш для сброса фильтров


        /// <summary>
        /// Инициализирует новый экземпляр GamePresenter.
        /// </summary>
        /// <param name="view">Экземпляр представления, которым будет управлять презентер.</param>
        /// <param name="service">Экземпляр сервиса бизнес-логики.</param>
        public GamePresenter(IGameView view, IGameService service)
        {
            _view = view;
            _service = service;

            //Подписываемся на события от View
            _view.AddGameRequested += OnAddGameRequested;
            _view.DeleteGameRequested += OnDeleteGameRequested;
            _view.UpdateGameRequested += OnUpdateGameRequested;
            _view.AddPlatformRequested += OnAddPlatformRequested;
            _view.RefreshRequested += OnRefreshRequested;
            _view.FilterByPlatformRequested += OnFilterByPlatformRequested;
            _view.FilterByPlatformNameRequested += OnFilterByPlatformNameRequested;
            _view.GroupByGenreRequested += OnGroupByGenreRequested;
            _view.ResetFilterRequested += OnResetFilterRequested;

            //Подписываемся на события от Service
            _service.GamesLoaded += OnGamesLoaded;
            _service.PlatformsLoaded += OnPlatformsLoaded;
            _service.ErrorOccurred += OnServiceErrorOccurred;
            _service.SuccessOccurred += OnServiceSuccessOccurred;
        }

        #region Методы-обработчики событий от Service



        /// <summary>
        /// Обрабатывает событие от сервиса после загрузки/обновления списка игр.
        /// Сохраняет список в кэш и передает его в View для отображения.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="games">Загруженный список игр.</param>
        private void OnGamesLoaded(object sender, IEnumerable<Game> games)
        {
            _allGamesCache = games.ToList();
            _view.ShowGames(_allGamesCache);
            _view.ClearInputFields();
        }

        private void OnPlatformsLoaded(object sender, IEnumerable<Platform> platforms)
        {
            _view.ShowPlatforms(platforms);
        }

        private void OnServiceErrorOccurred(object sender, string message)
        {
            _view.ShowError(message);
        }

        private void OnServiceSuccessOccurred(object sender, string message)
        {
            _view.ShowSuccess(message);
        }

        #endregion

        #region Методы-обработчики событий от View

        /// <summary>
        /// Обрабатывает запрос от View на первоначальную/полную загрузку данных.
        /// </summary>
        private void OnRefreshRequested(object sender, EventArgs e)
        {
            OnGamesLoaded(this, _service.GetAllGames());
            OnPlatformsLoaded(this, _service.GetAllPlatforms());
        }

        /// <summary>
        /// Обрабатывает запрос от View на добавление игры. 
        /// Собирает данные из свойств View и передает их в сервис. Ну и так для всех остальных обработчиков 
        /// </summary>
        private void OnAddGameRequested(object sender, EventArgs e)
        {
            _service.AddGame(_view.GameTitle, _view.SelectedGenre, _view.Developer, _view.ReleaseYear, _view.SelectedPlatformId, _view.Rating);
        }

        private void OnDeleteGameRequested(object sender, Guid gameId)
        {
            _service.DeleteGame(gameId);
        }

        private void OnUpdateGameRequested(object sender, GameUpdateEventArgs args)
        {
            _service.UpdateGame(args.Id, args.Title, args.Rating, args.PlatformId, args.Developer, args.Genre);
        }

        private void OnAddPlatformRequested(object sender, string platformName)
        {
            _service.TryAddPlatform(platformName);
        }

        private void OnFilterByPlatformRequested(object sender, Guid platformId)
        {
            _view.ShowGames(_service.GetGamesByPlatform(platformId));
        }

        private void OnFilterByPlatformNameRequested(object sender, string platformName)
        {
            var foundGames = _service.FindGamesByPlatformName(platformName);
            if (!foundGames.Any()) _view.ShowSuccess($"Игры для платформы '{platformName}' не найдены.");
            _view.ShowGames(foundGames);
        }

        private void OnGroupByGenreRequested(object sender, EventArgs e)
        {
            if (_allGamesCache == null) return;
            var sortedGames = _allGamesCache.OrderBy(g => g.GameGenre).ThenBy(g => g.Title).ToList();
            _view.ShowGames(sortedGames);
        }

        private void OnResetFilterRequested(object sender, EventArgs e)
        {
            if (_allGamesCache != null) _view.ShowGames(_allGamesCache);
        }

        #endregion
    }
}
