namespace MenuMvcSiteMapProvider.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MenuModel : DbContext
    {
        public MenuModel()
            : base("name=MenuModel")
        {
            Database.SetInitializer(new InitDatabase());
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
