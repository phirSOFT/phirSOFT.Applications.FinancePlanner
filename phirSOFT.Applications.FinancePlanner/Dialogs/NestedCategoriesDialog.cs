using Microsoft.WindowsAPICodePack.Dialogs;
using phirSOFT.Applications.FinancePlanner.Model;

namespace phirSOFT.Applications.FinancePlanner.Dialogs
{
    internal class NestedCategoriesDialog
    {
        private static TaskDialog dlg;
        private static TaskDialogCommandLink deleteAllCommandLink;
        private static TaskDialogCommandLink keepChildenCommandLink;
        private static DeleteBehavior _behavior;

        private bool storeAnswer;

        static NestedCategoriesDialog()
        {
            dlg = new TaskDialog
            {
                Cancelable = false,
                Caption = SC.DeleteCategoryTitle,
                FooterCheckBoxText = SC.RememberAnswer,
                InstructionText = SC.DeleteCategoryInstruction,
                Text = SC.DeleteCategoryContent,
                StartupLocation = TaskDialogStartupLocation.CenterOwner
            };

            deleteAllCommandLink = new TaskDialogCommandLink("Delete all",SC.DeleteAll,SC.DeleteAllNote) {Default = true};
            keepChildenCommandLink = new TaskDialogCommandLink("Keep Children", SC.KeepChildren, SC.KeepChildrenNote);
            dlg.Controls.Add(deleteAllCommandLink);
            dlg.Controls.Add(keepChildenCommandLink);

            deleteAllCommandLink.Click += (sender, e) => Behavior = DeleteBehavior.DeleteAll;
            keepChildenCommandLink.Click += (sender, args) => Behavior = DeleteBehavior.KeepChildren;

        }

    

        public DeleteBehavior RequestBehaviour()
        {
            if (!storeAnswer)
            {
                dlg.Show();
                storeAnswer = dlg.FooterCheckBoxChecked ?? false;
            }
          
            return Behavior;
        }

        public void ResetDialog()
        {
            storeAnswer = false;
        }

        public static DeleteBehavior Behavior
        {
            get { return _behavior; }
            set
            {
                _behavior = value;
                dlg.Close();
            }
        }
    }
}