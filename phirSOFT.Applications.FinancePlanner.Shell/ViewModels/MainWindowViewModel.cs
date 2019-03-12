using Prism.Commands;
using Prism.Mvvm;
using System.Windows.Input;

namespace phirSOFT.Applications.FinancePlanner.Shell.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Unity Application";

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ICommand CloseCommand { get; } = new DelegateCommand<IClosable>(c => c.Close());
    }
}