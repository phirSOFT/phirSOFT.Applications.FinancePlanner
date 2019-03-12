using System;
using System.Windows.Input;
using phirSOFT.Applications.FinancePlanner;

namespace phirSOFT.Applications.FinancePlanner.ProgressManager.Services
{
    internal partial class ProgressManager : IProgressManager
    {
        /// <summary>
        ///     Represents a command, that can never be executed
        /// </summary>
        private class NullCommand : ICommand
        {
            /// <inheritdoc />
            public bool CanExecute(object parameter)
            {
                return false;
            }

            /// <inheritdoc />
            public void Execute(object parameter)
            {
                throw new NotImplementedException();
            }

            /// <inheritdoc />
            public event EventHandler CanExecuteChanged;
        }
    }
}