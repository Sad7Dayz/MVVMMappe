using MahApps.Metro.Controls;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;
using ViewModel.ViewModels;
using WPFVIEW.Services;
using WPFVIEW.Views.Pages;

namespace WPFVIEW.Views.Windows
{
    /// <summary>
    /// MainView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainView : MetroWindow
    {
        public MainViewModel MainViewModel { get; }
        //public ServiceProvider ServiceProvider;

        public MainView(MainViewModel mainViewModel)
        {
            InitializeComponent();
            MainViewModel = mainViewModel;
            DataContext = MainViewModel; //데이터 연결
            InitEvents();
        }

        private void InitEvents()
        {
            MainViewModel.EventOpenPage += (s, e) => OpenPage(s);
        }

        /// <summary>
        /// Tab
        /// </summary>
        /// <param name="ISender"></param>
        private void OpenPage(object? ISender)
        {
            if (ISender is Button Btn)
            {
                if (Btn == BtnHome)
                {
                    ViewManager.ShowPageOnMainView<HomeView>();
                }
                else if (Btn == BtnAdmin)
                {
                    ViewManager.ShowPageOnMainView<AdminView>();
                }
            }
        }
    }
}
