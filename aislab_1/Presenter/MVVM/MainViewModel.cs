using Model;
using Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace Presenter.MVVM
{
    public class MainViewModel: ViewModelBase
    {
        private readonly IGameService _gameService;
        private readonly ViewManager _viewManager;//на случай, если будем использовать новые окна


        //исп ObservableCollection чтобы не обновлять вью вручную при изменениях
        public ObservableCollection<GameDTO> Games { get; set; } = new ObservableCollection<GameDTO>();
        public ObservableCollection<PlatformDTO> Platforms { get; set; } = new ObservableCollection<PlatformDTO>();

        #region Поля ввода и свойства
        public IEnumerable<Genre> AllGenres => Enum.GetValues(typeof(Genre)).Cast<Genre>();

        private string _inputTitle;
        public string InputTitle { get => _inputTitle; set => Set(ref _inputTitle, value); }

        private string _inputDeveloper;
        public string InputDeveloper { get => _inputDeveloper; set => Set(ref _inputDeveloper, value); }

        private int _inputReleaseYear = DateTime.Now.Year;
        public int InputReleaseYear { get => _inputReleaseYear; set => Set(ref _inputReleaseYear, value); }

        private int _inputRating = 1;
        public int InputRating { get => _inputRating; set => Set(ref _inputRating, value); }

        private Genre _selectedGenre;
        public Genre SelectedInputGenre { get => _selectedGenre; set => Set(ref _selectedGenre, value); }

        private Guid _selectedPlatformId;
        public Guid SelectedInputPlatformId { get => _selectedPlatformId; set => Set(ref _selectedPlatformId, value); }

        private string _newPlatformName;
        public string NewPlatformName { get => _newPlatformName; set => Set(ref _newPlatformName, value); }

        public string _platformSearchText;

        public string PlatformSearchText { get => _platformSearchText; set => Set(ref _platformSearchText, value); }    

        //свойство выбранной игры, при изменении которого заполняются поля ввода
        private GameDTO _selectedGame;

        /// <summary>
        /// Выбранная игра в списке. При изменении заполняет поля ввода свойствами выбранной игры.
        /// </summary>
        public GameDTO SelectedGame
        {
            get => _selectedGame;
            set
            {
                if (Set(ref _selectedGame, value))
                {
                    if (_selectedGame != null)
                    {
                        InputTitle = _selectedGame.Title;
                        InputDeveloper = _selectedGame.Developer;
                        InputReleaseYear = _selectedGame.ReleaseYear;
                        InputRating = _selectedGame.Rating;
                        SelectedInputGenre = _selectedGame.GameGenre;
                        SelectedInputPlatformId = _selectedGame.PlatformId;
                    }
                }
            }
        }
        #endregion


        #region Команды
        public ICommand AddGameCommand { get; }
        public ICommand UpdateGameCommand { get; }
        public ICommand DeleteGameCommand { get; }
        public ICommand ClearInputsCommand { get; } // Кнопка "Сбросить"
        public ICommand AddPlatformCommand { get; }
        public ICommand RefreshCommand { get; }

        public ICommand FilterByPlatformCommand { get; }
        public ICommand GroupByGenreCommand { get; }
        public ICommand SearchPlatformCommand { get; }

        #endregion

        public MainViewModel(IGameService service, ViewManager viewManager)
        {
            _gameService = service;
            _viewManager = viewManager;
            
            //инициализируем команды
            AddGameCommand = new RelayCommand(AddGame);
            UpdateGameCommand = new RelayCommand(UpdateGame, _ => SelectedGame != null); // активна, только если выбрана игра
            DeleteGameCommand = new RelayCommand(DeleteGame, _ => SelectedGame != null);
            ClearInputsCommand = new RelayCommand(_ => ClearFields());
            AddPlatformCommand = new RelayCommand(AddPlatform, _ => !string.IsNullOrWhiteSpace(NewPlatformName));
            RefreshCommand = new RelayCommand(_ => LoadData());

            FilterByPlatformCommand = new RelayCommand(FilterByPlatform);
            GroupByGenreCommand = new RelayCommand(GroupByGenre);
            SearchPlatformCommand = new RelayCommand(SearchByPlatformName);


            _gameService.GamesLoaded += OnGamesLoaded;
            _gameService.PlatformsLoaded += OnPlatformsLoaded;

            

            LoadData();
        }

        #region логика команд

        /// <summary>
        /// Метод, получающий данные из сервиса и обновляющий таблицы
        /// </summary>
        private void LoadData()
        {         
            //получаем данные из сервиса, вернется model и события GamesLoaded/PlatformsLoaded сработают внутри сервиса и вызовут методы для обновления
            var games = _gameService.GetAllGames();
            OnGamesLoaded(this, games);

            var platforms = _gameService.GetAllPlatforms();
            OnPlatformsLoaded(this, platforms);
        }

        /// <summary>
        /// Метод для добавления игры
        /// </summary>
        /// <param name="parameter"></param>
        private void AddGame(object parameter)
        {

            _gameService.AddGame(InputTitle, SelectedInputGenre, InputDeveloper,
                                 InputReleaseYear, SelectedInputPlatformId, InputRating);
            ClearFields();
        }

        /// <summary>
        /// Метод для обновления выбранной игры
        /// </summary>
        /// <param name="parameter"></param>
        private void UpdateGame(object parameter)
        {
            if (SelectedGame == null) return;

            _gameService.UpdateGame(SelectedGame.Id, InputTitle, InputRating,
                                    SelectedInputPlatformId, InputDeveloper, SelectedInputGenre);

            SelectedGame = null;
            ClearFields();
        }

        /// <summary>
        /// Метод для удаления выбранной игры
        /// </summary>
        /// <param name="parameter"></param>
        private void DeleteGame(object parameter)
        {
            if (SelectedGame == null) return;

            _gameService.DeleteGame(SelectedGame.Id);
            SelectedGame = null;
            ClearFields();
        }

        /// <summary>
        /// Метод для добавления новой платформы
        /// </summary>
        /// <param name="parameter"></param>
        private void AddPlatform(object parameter)
        {
            _gameService.TryAddPlatform(NewPlatformName);
            NewPlatformName = string.Empty; 
        }

        /// <summary>
        /// Метод для очистки полей ввода
        /// </summary>
        private void ClearFields()
        {
            InputTitle = string.Empty;
            InputDeveloper = string.Empty;
            InputReleaseYear = DateTime.Now.Year;
            InputRating = 1;
            SelectedInputGenre = Genre.Action;
            if (Platforms.Any()) SelectedInputPlatformId = Platforms.First().Id;

            SelectedGame = null; 
        }

        private void FilterByPlatform(object parameter)
        {
            
            var filtered = _gameService.GetGamesByPlatform(SelectedInputPlatformId);
            OnGamesLoaded(this, filtered);
        }

        private void GroupByGenre(object parameter)
        {
            var grouped = _gameService.GetGamesGroupedByGenre()
                                      .SelectMany(g => g) //разгруппируем обратно в IEnumerable<Game>
                                      .ToList();
            OnGamesLoaded(this, grouped);
        }

        private void SearchByPlatformName(object parameter)
        {
            

            var found = _gameService.FindGamesByPlatformName(PlatformSearchText);
            OnGamesLoaded(this, found);
        }





        #region обработчики событий сервиса
        private void OnGamesLoaded(object sender, IEnumerable<Game> games)
        {
            Games.Clear();

            foreach (var game in games)
            {
                Games.Add(GameDTO.FromModel(game));
            }
        }

        private void OnPlatformsLoaded(object sender, IEnumerable<Platform> platforms)
        {
            SelectedInputPlatformId = Guid.Empty;

            Platforms.Clear();
            foreach (var platform in platforms)
            {
                Platforms.Add(PlatformDTO.FromModel(platform));
            }

            if (Platforms.Any() && SelectedInputPlatformId == Guid.Empty)
            {
                SelectedInputPlatformId = Platforms.First().Id;
            }
        }
        #endregion

        #endregion

    }
}
