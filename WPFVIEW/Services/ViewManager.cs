using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Controls;
using ViewModel.ViewModels;
using WPFVIEW.Components;
using WPFVIEW.Views.Pages;
using WPFVIEW.Views.Windows;


namespace WPFVIEW.Services
{
    public class ViewManager
    {
        public static MainView? _MainView { get; set; }
        public static MainViewModel? _MainViewModel { get; set; }
        public static ServiceProvider? _ServiceProvider { get; set; }
        private static UserControl? _GoBackPage { get; set; }

        public static void InitViewManagerData(MainView iMainView, ServiceProvider iServiceProvider)
        {
            _MainView = iMainView;
            _MainViewModel = iMainView.MainViewModel;
            _ServiceProvider = iServiceProvider;
        }

        public static void ShowPageOnMainView<T>(bool iFullPage = false) where T : UserControl
        {
            try
            {
                var pageServices = _ServiceProvider?.GetService<T>();
                if (pageServices is null) return;
                if (pageServices is UserControl page)
                {
                    Show(page, iFullPage);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void Show(UserControl iPage, bool iFullPage = false)
        {
            _MainView!.AnimatedContentControl.PagePlace.Content = null;
            _MainView!.AnimatedContentControl.PagePlace.Content = iPage;

            _MainView!.AnimatedContentControl.MetroTabItem.IsSelected = false;
            _MainView!.AnimatedContentControl.MetroTabItem.IsSelected = true;

            if (iFullPage)
            {

            }
            else
            {
                _GoBackPage = iPage;
            }
        }

        public static void GoBackOrToHome()
        {
            if (_GoBackPage is null)
            {
                ShowPageOnMainView<HomeView>();
                return;
            }

            Show(_GoBackPage);
        }
    }
}
