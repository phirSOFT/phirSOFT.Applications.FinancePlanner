namespace phirSOFT.Applications.FinancePlanner.Model
{
    internal class UserCategory : Category
    {

        public override CategoryType CategoryType
        {
            get {
                var parent = Parent;
                while (parent != null)
                {
                    if (parent is SystemCategory)
                        return parent.CategoryType;

                    parent = parent.Parent;
                }
                return CategoryType.Unknown;
            }
        }

        public override bool System => false;
    }
}