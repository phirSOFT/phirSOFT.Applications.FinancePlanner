using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using phirSOFT.Applications.FinancePlanner;
using ProgressManager.Annotations;

namespace phirSOFT.Applications.FinancePlanner.ProgressManager.Services
{
    internal partial class ProgressManager : IProgressManager
    {
        private sealed class ManagedProgress : IManagedProgress
        {
            private const int TimeoutUntilUnregister = 2500;
            private string _description;
            private readonly ProgressManager _parent;
            private readonly Progress<ProgressReport> _reporter;
            private double _progress;
            private bool _registred;
            private ProgressStates _state;
            private string _title;
            private readonly object _reportLock;

            public ManagedProgress(ProgressManager parent, Progress<ProgressReport> reporter)
            {
                _parent = parent;
                _reporter = reporter;
                _registred = false;

                _reportLock = new object();
                reporter.ProgressChanged += Reporter_ProgressChanged;
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

            private void Reporter_ProgressChanged(object sender, ProgressReport e)
            {
                Title = e.Title;
                Description = e.Description;
                State = e.State;
                Progress = e.Progress;

                lock (_reportLock)
                {
                    if (!_registred)
                    {
                        _parent._progresses.Add(this);
                        _registred = true;
                    }
                }


                if (State == ProgressStates.Faultet || State == ProgressStates.Finished)
                    Task.Delay(TimeoutUntilUnregister)
                        .ContinueWith(t =>
                        {
                            _parent._progresses.Remove(this);
                            _reporter.ProgressChanged -= Reporter_ProgressChanged;

                        });
            }

            [NotifyPropertyChangedInvocator]
            private void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}