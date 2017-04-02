using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using phirSOFT.Applications.FinancePlanner;
using ProgressManager.Annotations;

namespace ProgressManager.Services
{

    /// <summary>
    /// Concrete implementation of the <see cref="IProgressManager"/> interface.
    /// </summary>
    internal class ProgressManager : IProgressManager
    {
        private ObservableCollection<IManagedProgress> progresses;

        private static readonly ICommand Nullcmd = new NullCommand();

        public ProgressManager()
        {
            progresses = new ObservableCollection<IManagedProgress>();
            Progresses = new ReadOnlyObservableCollection<IManagedProgress>(progresses);
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
            {
                cancel = Nullcmd;
            }
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

        private class ManagedProgress : IManagedProgress
        {
            private ProgressManager _parent;
            private bool _registred;
            private ProgressStates _state;
            private double _progress;
            private string _description;
            private string _title;
            private const int TimeoutUntilUnregister = 2500;
            private object reportLock;

            public ManagedProgress(ProgressManager parent, Progress<ProgressReport> reporter)
            {
                _parent = parent;
                _registred = false;

                reportLock = new object();
                reporter.ProgressChanged += Reporter_ProgressChanged;
            }

            private void Reporter_ProgressChanged(object sender, ProgressReport e)
            {
                Title = e.Title;
                Description = e.Description;
                State = e.State;
                Progress = e.Progress;

                lock (reportLock)
                {
                    if (!_registred)
                    {
                        _parent.progresses.Add(this);
                        _registred = true;
                    }
                }


                //Check wether progress is done and if so, set parent to null, so the garbage collector can collect this. 
                if (State == ProgressStates.Faultet || State == ProgressStates.Finished)
                    Task.Delay(TimeoutUntilUnregister)
                        .ContinueWith((t) =>
                    {
                        _parent.progresses.Remove(this);
                        _parent = null;
                    });

            }

            public string Title
            {
                get { return _title; }
                private set
                {
                    if (value == _title) return;
                    _title = value;
                    OnPropertyChanged();
                }
            }

            public string Description
            {
                get { return _description; }
                private set
                {
                    if (value == _description) return;
                    _description = value;
                    OnPropertyChanged();
                }
            }

            public ProgressStates State
            {
                get { return _state; }
                private set
                {
                    if (value == _state) return;
                    _state = value;
                    OnPropertyChanged();
                }
            }

            public double Progress
            {
                get { return _progress; }
                private set
                {
                    if (value.Equals(_progress)) return;
                    _progress = value;
                    OnPropertyChanged();
                }
            }

            public ICommand Cancel { get; set; }

            public ICommand Pause { get; set; }

            public ICommand Resume { get; set; }

            public event PropertyChangedEventHandler PropertyChanged;

            [NotifyPropertyChangedInvocator]
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Represents a command, that can never be executed
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
