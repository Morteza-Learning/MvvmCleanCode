using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
