using System.Windows.Controls;
using ViewModel.ViewModels;
using WPFVIEW.Services;

namespace WPFVIEW.Views.Pages
{
    /// <summary>
    /// HomeView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeViewModel _HomeViewModel { get; }
        public HomeView(HomeViewModel homeViewModel)
        {
            InitializeComponent();
            _HomeViewModel = homeViewModel;
            DataContext = _HomeViewModel;//데이터 연결
            ViewManager.ShowPageOnMainView<HomeView>();
        }
    }
}
