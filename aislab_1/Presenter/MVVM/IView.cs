using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter.MVVM
{
    public interface IView //когда будешь писать окна WPF, реализуй этот интерфейс
    {
        // метод, чтобы показать окно
        void Show();

        // метод, чтобы закрыть окно
        void Close();

        // свойство для установки контекста данных (ViewModel)
        object DataContext { get; set; }
    }
}
