using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter.MVVM
{
    //обертка для модели Game, чтобы работать с ней в MVVM
    public class GameDTO: ViewModelBase
    {
        private Guid _id;
        private string _title;
        private Genre _genre;
        private string _developer;
        private int _releaseYear;
        private int _rating;
        private Guid _platformId;
        private string _platformName;

        #region Свойства
        public Guid Id
        {
            get => _id;
            set => Set(ref _id, value); 
        }

        public string Title
        {
            get => _title;
            set => Set(ref _title, value); //вот тут как раз используется Set из ViewModelBase, чтобы уведомлять View об изменениях
        }

        public Genre GameGenre
        {
            get => _genre;
            set => Set(ref _genre, value); //и здесь
        }

        public string Developer
        {
            get => _developer;
            set => Set(ref _developer, value);//ну и так далеее
        }

        public int ReleaseYear
        {
            get => _releaseYear;
            set => Set(ref _releaseYear, value);
        }

        public int Rating
        {
            get => _rating;
            set => Set(ref _rating, value);
        }

        public Guid PlatformId
        {
            get => _platformId;
            set => Set(ref _platformId, value);
        }

        public string PlatformName
        {
            get => _platformName;
            set => Set(ref _platformName, value);
        }
        #endregion

        #region Методы маппинга
        /// <summary>
        /// Метод преобразования DTO в модель Game
        /// </summary>
        /// <returns>Объект Game со свойствами GameDTO</returns>
        public Game ToModel()
        {
            return new Game
            {
                Id = this.Id,
                Title = this.Title,
                GameGenre = this.GameGenre,
                Developer = this.Developer,
                ReleaseYear = this.ReleaseYear,
                Rating = this.Rating,
                PlatformId = this.PlatformId
            };
        }

        /// <summary>
        /// Метод, преобразующий модель Game в DTO
        /// </summary>
        /// <param name="game"></param>
        /// <returns>Объект GameDTO со свойствами исходного Game</returns>
        public static GameDTO FromModel(Game game)
        {
            return new GameDTO
            {
                Id = game.Id,
                Title = game.Title,
                GameGenre = game.GameGenre,
                Developer = game.Developer,
                ReleaseYear = game.ReleaseYear,
                Rating = game.Rating,
                PlatformId = game.PlatformId,
                PlatformName = game.Platform?.Name ?? "Неизвестно"
            };
        }
        public override string ToString() => $"{Title} ({PlatformName})";
        #endregion
    }
}

