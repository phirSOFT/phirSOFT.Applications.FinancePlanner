using System.ComponentModel;
using System.Windows.Input;

namespace phirSOFT.Applications.FinancePlanner
{
    /// <summary>
    /// Represents a progress managed by an <see cref="IProgressManager"/>.
    /// </summary>
    public interface IManagedProgress : INotifyPropertyChanged
    {
        /// <summary>
        /// Gets the title of the progress
        /// </summary>
        string Title { get; }

        /// <summary>
        /// Gets the description of the progress
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Gets the state of the Progress
        /// </summary>
        ProgressStates State { get; }

        /// <summary>
        /// Gets the current progress (if availble)
        /// </summary>
        double Progress { get; }

        /// <summary>
        /// Gets the cancel command.
        /// </summary>
        ICommand Cancel { get; }


        /// <summary>
        /// Gets the command to pause.
        /// </summary>
        ICommand Pause { get; }

        /// <summary>
        /// Gets the command to resume.
        /// </summary>
        ICommand Resume { get; }

    }
}