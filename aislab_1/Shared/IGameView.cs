using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface IGameView //ps форма реализует этот интерфейс и просто генерирует события, а вся логика в презентере
    {
        // события от view к presenter
        event EventHandler AddGameRequested;
        event EventHandler<Guid> DeleteGameRequested;
        event EventHandler<GameUpdateEventArgs> UpdateGameRequested;
        event EventHandler<Guid> FilterByPlatformRequested;
        event EventHandler<string> FilterByPlatformNameRequested;
        event EventHandler GroupByGenreRequested;
        event EventHandler ResetFilterRequested;
        event EventHandler<string> AddPlatformRequested;
        event EventHandler RefreshRequested;

        // свойства для получения данных из ui
        string GameTitle { get; }
        Genre SelectedGenre { get; }
        string Developer { get; }
        int ReleaseYear { get; }
        Guid SelectedPlatformId { get; }
        int Rating { get; }

        // методы для обновления view
        void ShowGames(IEnumerable<Game> games);
        void ShowPlatforms(IEnumerable<Platform> platforms);
        void ShowError(string message);

        void ShowSuccess(string message);
        void ClearInputFields();
        void RefreshUI();
    }
}
