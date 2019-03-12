using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Mvvm;

namespace phirSOFT.Applications.FinancePlanner.ProgressManager.ViewModels
{
    internal class ManagedProgressViewModel : BindableBase
    {
        private readonly IManagedProgress _progress;

        public ManagedProgressViewModel(IManagedProgress progress)
        {
            _progress = progress;


            //redirect Changes
            _progress.PropertyChanged += (sender, e) => OnPropertyChanged(e);
            AllowsSuspending = progress.Pause != null && progress.Resume != null;
        }    

        public double Progress => _progress.Progress * 100;

        public bool AllowsSuspending { get; }

        public ICommand CancelCommand => _progress.Cancel;

        public ICommand PauseCommand => _progress.Pause;

        public ICommand ResumeCommand => _progress.Resume;

        public string Title => _progress.Title;

        public string Description => _progress.Description;

        public ProgressStates State => _progress.State;
    }
}
