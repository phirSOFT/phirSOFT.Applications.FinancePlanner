namespace Finanzplan.DB
{
    enum Interval : int
    {
        singleOccurence = 0,
        monthly = 1,
        bimonthly = 2,
        quarter = 3,
        semianual = 6,
        yearly = 12,
    }
}