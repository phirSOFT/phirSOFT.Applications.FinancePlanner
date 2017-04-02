using Microsoft.Practices.Unity;
using Prism.Unity;
using FinancePlanner.Views;
using System.Windows;

namespace FinancePlanner
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }
    }
}
