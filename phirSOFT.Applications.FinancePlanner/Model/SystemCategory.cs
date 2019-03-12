using System;

namespace phirSOFT.Applications.FinancePlanner.Model
{
    internal class SystemCategory : Category
    {
     

        public override CategoryType CategoryType => Type;
        public override bool System => true;

        public CategoryType Type { get; set; }

        public override string Title
        {
            get
            {
                if (base.Title != null) return base.Title;

                return GetTypeString(Type);
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value == GetTypeString(Type))
                    base.Title = null;
                else
                    base.Title = value;
            }
        }

        private string GetTypeString(CategoryType type)
        {
            switch (type)
            {
                case CategoryType.Unknown:
                    return SC.UnkownCategory;
                case CategoryType.Income:
                    return SC.Income;
                case CategoryType.Expenses:
                    return SC.Expenses;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}