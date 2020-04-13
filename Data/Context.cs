using System;
using System.Data.Entity;

namespace Data
{
    public class Context : DbContext
    {
        public Context()
            : base("name=CString")
        {
            base.Configuration.ProxyCreationEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer<Context>(new DropCreateDatabaseAlways<Context>());
            AppDomain.CurrentDomain.SetData("DataDirectory", System.AppDomain.CurrentDomain.BaseDirectory);
        }

        public virtual DbSet<MyData> MyDatas { get; set; }
    }
}