namespace Data
{
    public interface IRepository
    {
        MyData GetMyDataFromDb();

        void SaveDataToDb(string title);

        string GetDataBaseInfo();
    }
}