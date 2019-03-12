using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using JetBrains.Annotations;

namespace Shared
{
    public interface IProgressManager
    {
        void RegisterProgress([NotNull] IProgress<ProgressState> progress, [NotNull] ICommand cancelCommand);

        void RegisterProgress([NotNull] IProgress<ProgressState> progress, [NotNull] ICommand cancelCommand, [NotNull] ICommand pauseCommand, [NotNull] ICommand resumeCommand);

        ObservableCollection<IProgress> Progresses { get; }
    }

    public struct ProgressState
    {
        public double Progress { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public States State { get; set; }

        public enum States
        {
            Pending,
            Intermediate,
            Running,
            Paused,

        }
    }
}
