using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Shared;

namespace ProgressModule.ViewModels
{
    internal class ProgresVieverViewModel : BindableBase
    {

        public ProgresVieverViewModel(IProgressManager manager)
        {
            this.manager = manager;
            manager.Progresses.CollectionChanged += Progresses_CollectionChanged;

            foreach (var progress in manager.Progresses)
            {
                progress.PropertyChanged += ProgressChanged;
            }
        }

        private void ProgressChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Task.Run(()=> RecalculateProgress());
        }

        private void RecalculateProgress()
        {
            
            var selection = manager.Progresses.Where(p => p.State == ProgressState.States.Running);
            var result = selection.Aggregate(((int) 0, (double) 0), (c, p) => (c.Item1 + 1, c.Item2 + p.Progress));
            Progress = result.Item2 / result.Item1;
 
        }

        private void Progresses_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (IProgress item in e.NewItems)
                    {
                        item.PropertyChanged += ProgressChanged;
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (IProgress item in e.OldItems)
                    {
                        item.PropertyChanged -= ProgressChanged;
                    }
                    break;
                case NotifyCollectionChangedAction.Replace:
                    break;
                case NotifyCollectionChangedAction.Move:
                    break;
                case NotifyCollectionChangedAction.Reset:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

      

        private IProgressManager manager;
        private double _progress;

        public double Progress
        {
            get { return _progress; }
            set
            {
                SetProperty(ref _progress, value);
            }
        }

        public bool IsVisible { get; set; } = true;
    }
}
