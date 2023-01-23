using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Web;

namespace managecfshop.Data
{
    public class managecfshopContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public managecfshopContext() : base("name=managecfshopContext")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuider) 
        {
            base.OnModelCreating(modelBuider);
        }

        public System.Data.Entity.DbSet<ManageCoffeeShop.Models.Bill> Bills { get; set; }

        public System.Data.Entity.DbSet<coffeeShop.Models.ABC> ABCs { get; set; }

        public System.Data.Entity.DbSet<ManageCoffeeShop.Model.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<coffeeShop.Models.Account> Accounts { get; set; }

        public System.Data.Entity.DbSet<ManageCoffeeShop.Models.Table> Tables { get; set; }

        public System.Data.Entity.DbSet<ManageCoffeeShop.Models.SelectMenu> SelectMenus { get; set; }

        public System.Data.Entity.DbSet<ManageCoffeeShop.Models.BillInfor> BillInfors { get; set; }

        public System.Data.Entity.DbSet<coffeeShop.Models.Login> Logins { get; set; }
    }
}
