using System.ComponentModel;
using System.Text;
using Ookii.CommandLine;

namespace phirSOFT.Applications.FinancePlanner
{
    public class StartupOptions
    {
#if DEBUG
        [CommandLineArgument(DefaultValue = true,IsRequired = false)]
#else
        [CommandLineArgument(DefaultValue = false,IsRequired = false)]
#endif
        [Description("Include Debug information into log files")]
        public bool Debug { get; set; }

        [CommandLineArgument(DefaultValue = false,IsRequired = false)]
        public bool Console { get; set; }

        public string DebugOptions()
        {
            var sb = new StringBuilder();
            foreach (var property in typeof(StartupOptions).GetProperties())
                sb.AppendLine($"{property.Name}:{property.GetValue(this)}");

            return sb.ToString();
        }
    }
}