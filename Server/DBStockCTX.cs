using MySql.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceServ;
using System.Diagnostics;

namespace Server
{
    /// <summary>
    /// Class defines stock database context.
    /// </summary>
    [DbConfigurationType(typeof(MySqlEFConfiguration))] // set the proper config for MySql
    class DBStockCTX : DbContext
    {
        
        public DBStockCTX() : base("server = localhost; User Id = root; Persist Security Info=True; database=StockDB; password=moh123") // use the connection string
        {
        }

        // set the table sets properties
        public virtual DbSet<Product> products { get; set; }
        public virtual DbSet<ProductCategory> productscategories { get; set; }
    }
}
