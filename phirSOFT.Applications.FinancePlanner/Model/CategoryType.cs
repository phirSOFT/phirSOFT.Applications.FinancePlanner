namespace phirSOFT.Applications.FinancePlanner.Model
{
    /// <summary>
    /// Provides the type of a <see cref="Category"/> or a <see cref="AccountingEntry"/>.
    /// </summary>
    internal enum CategoryType
    {
        /// <summary>
        /// The type is unknown
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// The type is an income (postive sign)
        /// </summary>
        Income = 1,

        /// <summary>
        /// The type is an expense (negatve sign)
        /// The type is an expense (negatve sign)
        /// </summary>
        Expenses =-1
    }
}