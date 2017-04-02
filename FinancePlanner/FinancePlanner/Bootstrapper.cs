using System.Windows;
using FinancePlanner.Views;
using Microsoft.Practices.Unity;
using Prism.Unity;

namespace FinancePlanner
{
    internal class Bootstrapper : UnityBootstrapper
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