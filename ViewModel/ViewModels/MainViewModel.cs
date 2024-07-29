using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Xml.Schema;

namespace ViewModel.ViewModels
{
    public partial class MainViewModel : BaseViewModel
    {
        public event EventHandler? EventOpenPage;
        public MainViewModel()
        {
            Title = "Main";
        }

        [RelayCommand]
        void OpenPage(object iParam)
        {
            EventOpenPage?.Invoke(iParam, EventArgs.Empty);
        }
    }
}
