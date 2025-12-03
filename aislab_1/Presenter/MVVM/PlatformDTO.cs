using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter.MVVM
{
    public class PlatformDTO: ViewModelBase
    {
        private Guid _id;
        private string _name;

        #region Свойства
        public Guid Id
        {
            get => _id;
            set => Set(ref _id, value);
        }

        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }
        #endregion

        #region Методы маппинга
        /// <summary>
        /// Преобразование DTO в модель
        /// </summary>
        /// <returns>Platform со свойствами PlatformDTo</returns>
        public Platform ToModel()
        {
            return new Platform
            {
                Id = this.Id,
                Name = this.Name
            };
        }

        /// <summary>
        /// Преобразование модели в DTO
        /// </summary>
        /// <param name="platform"></param>
        /// <returns>PlatformDTO со свойствами Platform</returns>
        public static PlatformDTO FromModel(Platform platform)
        {
            return new PlatformDTO
            {
                Id = platform.Id,
                Name = platform.Name
            };
        }

        public override string ToString() => Name;
        #endregion
    }
}
