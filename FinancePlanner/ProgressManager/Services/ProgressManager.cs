using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using phirSOFT.Applications.FinancePlanner;

namespace ProgressManager.Services
{
    /// <summary>
    ///     Concrete implementation of the <see cref="IProgressManager" /> interface.
    /// </summary>
    internal partial class ProgressManager : IProgressManager
    {
        private static readonly ICommand Nullcmd = new NullCommand();
        private readonly ObservableCollection<IManagedProgress> _progresses;

        public ProgressManager()
        {
            _progresses = new ObservableCollection<IManagedProgress>();
            Progresses = new ReadOnlyObservableCollection<IManagedProgress>(_progresses);
        }

        /// <inheritdoc />
        public IProgress<ProgressReport> RegisterProgress(ICommand cancel)
        {
            return RegisterProgress(cancel, null, null);
        }

        /// <inheritdoc />
        public IProgress<ProgressReport> RegisterProgress(ICommand cancel, ICommand pause, ICommand resume)
        {
            if (cancel == null)
                cancel = Nullcmd;
            var prg = new Progress<ProgressReport>();
            var managedProgress = new ManagedProgress(this, prg)
            {
                Cancel = cancel,
                Pause = pause,
                Resume = resume
            };

            return prg;
        }

        /// <inheritdoc />
        public ReadOnlyObservableCollection<IManagedProgress> Progresses { get; }
    }
}