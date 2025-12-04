using Ninject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using BusinessLogical;
using Presenter.MVVM;
using Shared;
using View.WPF;

namespace View.WPF
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {

        private IKernel _kernel;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _kernel = new StandardKernel(new SimpleConfigModule());
            _kernel.Bind<ViewManager>().ToSelf().InSingletonScope();

            var viewManager = _kernel.Get<ViewManager>();
            viewManager.Register<MainViewModel, MainWindow>();

            var mainViewModel = _kernel.Get<MainViewModel>();
            viewManager.Show(mainViewModel);
        }
    }
}
