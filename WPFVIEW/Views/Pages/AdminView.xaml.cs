using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ViewModel.ViewModels;

namespace WPFVIEW.Views.Pages
{
    /// <summary>
    /// AdminView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class AdminView : UserControl
    {
        public AdminView(AdminViewModel adminViewModel)
        {
            InitializeComponent();
            AdminViewModel = adminViewModel;
            DataContext = AdminViewModel; //데이터 연결
        }

        public AdminViewModel AdminViewModel { get; }
    }
}
