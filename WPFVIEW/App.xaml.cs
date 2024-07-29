using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using ViewModel.ViewModels;
using WPFVIEW.Services;
using WPFVIEW.Views.Pages;
using WPFVIEW.Views.Windows;

namespace WPFVIEW
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        ServiceProvider? _ServiceProvider;

        public App()
        {
            ServiceCollection _ServiceCollection = new();
            ConfigureServices(_ServiceCollection);
            _ServiceProvider = _ServiceCollection.BuildServiceProvider();
            ViewManager._ServiceProvider = _ServiceProvider;
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var manView = _ServiceProvider.GetService<MainView>();
            if (manView is null)
            {
                MessageBox.Show("Problem im SErviceProcvider()");
                Current.Shutdown();
            }
            ViewManager.InitViewManagerData(manView!, _ServiceProvider);
            manView!.Show();
            base.OnStartup(e);
        }

        /// <summary>
        /// 의존성
        /// </summary>
        /// <param name="iServiceCollection"></param>
        void ConfigureServices(ServiceCollection iServiceCollection)
        {
            iServiceCollection.AddSingleton<MainView>();
            iServiceCollection.AddSingleton<MainViewModel>();

            iServiceCollection.AddSingleton<HomeView>();
            iServiceCollection.AddSingleton<HomeViewModel>();

            iServiceCollection.AddSingleton<AdminView>();
            iServiceCollection.AddSingleton<AdminViewModel>();
        }
    }

}
