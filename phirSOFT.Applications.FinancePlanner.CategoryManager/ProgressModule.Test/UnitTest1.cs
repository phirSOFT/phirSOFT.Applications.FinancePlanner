using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProgressModule.ViewModels;
using Shared;

namespace ProgressModule.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var mock = new ProgressManagerMock();
            mock.Progresses.Add(new Progress(ProgressState.States.Running, 0.5));

            var vm = new ProgresVieverViewModel(mock);

            Assert.AreEqual(50, vm.Progress);
            Assert.AreEqual(true, vm.IsVisible);

        }
    }

    internal struct Progress : IProgress
    {
        private double _progress;
        private ProgressState.States _state;

        public Progress(ProgressState.States state, double progress)
        {
            _state = state;
            _progress = progress;
        }

        /// <inheritdoc />
        public event PropertyChangedEventHandler PropertyChanged;

        /// <inheritdoc />
        public void Pause()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void Resume()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public bool CanPause => false;

        /// <inheritdoc />
        public string Title => null;

        /// <inheritdoc />
        public string Description => null;

        /// <inheritdoc />
        public ProgressState.States State => _state;

        /// <inheritdoc />
        double IProgress.Progress => _progress;
    }

    internal class ProgressManagerMock : IProgressManager
    {
        /// <inheritdoc />
        public void RegisterProgress(IProgress<ProgressState> progress, ICommand cancelCommand)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void RegisterProgress(IProgress<ProgressState> progress, ICommand cancelCommand, ICommand pauseCommand, ICommand resumeCommand)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public ObservableCollection<IProgress> Progresses { get; } = new ObservableCollection<IProgress>();
    }
}
