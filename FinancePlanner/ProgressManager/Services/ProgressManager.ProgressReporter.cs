using System;
using System.Collections.Concurrent;

namespace phirSOFT.Applications.FinancePlanner.ProgressManager.Services
{
    internal partial class ProgressManager : IProgressManager
    {
        /// <summary>
        /// Provides a custom implementation of the <see cref="IProgress{T}"/> interface, that assures, that message is preserved.
        /// </summary>
        private sealed class ProgressReporter : IProgress<ProgressReport>, IDisposable
        {
            private readonly BlockingCollection<ProgressReport> _messages;

            public ProgressReporter()
            {
                _messages = new BlockingCollection<ProgressReport>();
            }

            /// <inheritdoc />
            public void Report(ProgressReport value)
            {
                _messages.Add(value);
            }

            /// <inheritdoc />
            public void Dispose()
            {
                _messages?.Dispose();
            }
        }
    }

 
}