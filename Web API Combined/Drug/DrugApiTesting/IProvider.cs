namespace DrugApiTesting
{
    internal interface IProvider
    {
        void searchDrugsByID(int v);
        void searchDrugsByName(string v);
    }
}