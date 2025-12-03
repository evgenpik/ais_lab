using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter.MVVM
{
    public class ViewManager
    {
        private readonly Dictionary<Type, Type> _mappings = new Dictionary<Type, Type>(); //словарь для хранения соответствий между ViewModel и View

        /// <summary>
        /// Метод регистрации соответствий между ViewModel и View.
        /// Если у нас есть MainViewModel, то мы регистрируем, что для него нужно создавать MainView.
        /// Вызывается при старте программы.
        /// </summary>
        public void Register<TViewModel, TView>()
            where TViewModel : ViewModelBase //ограничения на параметры
            where TView : IView
        {
            if (!_mappings.ContainsKey(typeof(TViewModel)))
            {
                _mappings.Add(typeof(TViewModel), typeof(TView));
            }
        }

        /// <summary>
        /// Метод открытия окна. Вызывается из ViewModel или из точки входа.
        /// </summary>
        /// <param name="viewModel">Экземпляр ViewModel, который мы хотим отобразить</param>
        public void Show(ViewModelBase viewModel)
        {
            var vmType = viewModel.GetType();

            if (_mappings.TryGetValue(vmType, out Type viewType))
            {
                //из-за того, что мы не знаем класс заранее, вызываем конструктор через рефлексию
                var view = (IView)Activator.CreateInstance(viewType);

                //тут связываем логику и вид
                view.DataContext = viewModel;

                //показываем окно
                view.Show();
            }
            else
            {
                throw new Exception($"Не найдено View для {vmType.Name}. Вы забыли вызвать Register?");
            }
        }

    }
}
