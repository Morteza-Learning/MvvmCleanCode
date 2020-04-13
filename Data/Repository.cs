using System.Linq;

namespace Data
{
    public class Repository : IRepository
    {
        public MyData GetMyDataFromDb()
        {
            using (var db = new Context())
            {
                return db.MyDatas.First();
            }
        }

        public void SaveDataToDb(string title)
        {
            using (var db = new Context())
            {
                db.MyDatas.Add(new MyData() { Title = title });
                db.SaveChanges();
            }
        }
    }
}