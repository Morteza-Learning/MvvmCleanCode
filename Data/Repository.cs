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


        public string GetDataBaseInfo()
        {
            using (var db = new Context())
            {
                return "ConnectionString :" + db.Database.Connection.ConnectionString + "\r\n" + 
                    "Database :" + db.Database.Connection.Database + "\r\n" + 
                   "DataSource :" + db.Database.Connection.DataSource + "\r\n" +
                   "State :" + db.Database.Connection.State;
            }
        }
    }
}