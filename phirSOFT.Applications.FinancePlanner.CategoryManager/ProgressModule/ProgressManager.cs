using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using JetBrains.Annotations;
using Shared;

namespace ProgressModule
{
    internal class ProgressManager : IProgressManager
    {
       

        public void RegisterProgress([NotNull] IProgress<ProgressState> progress, [NotNull] ICommand cancelCommand)
        {
            throw new NotImplementedException();
        }

        public void RegisterProgress([NotNull] IProgress<ProgressState> progress, [NotNull] ICommand cancelCommand, [NotNull] ICommand pauseCommand, [NotNull] ICommand resumeCommand)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public ObservableCollection<IProgress> Progresses { get; }
    }
}
