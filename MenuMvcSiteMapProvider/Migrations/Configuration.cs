namespace MenuMvcSiteMapProvider.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MenuMvcSiteMapProvider.Models.MenuModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MenuMvcSiteMapProvider.Models.MenuModel context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Account.AddOrUpdate(x => x.Id,
                new Account() { Username = "acc1", Password = "520520", Role = "Admin" },
                new Account() { Username = "acc2", Password = "520520", Role = "Teacher" },
                new Account() { Username = "acc3", Password = "520520", Role = "Student" },
                new Account() { Username = "acc4", Password = "520520", Role = "Visit" }
                );

            context.Menu.AddOrUpdate(x => x.Id,
                new Menu() { MenuName = "Parent1", Area = null, Controller = null, Action = null, Url = "#1", ParentMenuId = null, State = 1, RouteValues = null, OrderSerial = 1, StartTime = null, EndTime = null },
                new Menu() { MenuName = "Parent2", Area = null, Controller = null, Action = null, Url = "#2", ParentMenuId = null, State = 1, RouteValues = null, OrderSerial = 2, StartTime = null, EndTime = null },
                new Menu() { MenuName = "Parent3", Area = null, Controller = null, Action = null, Url = "#3", ParentMenuId = null, State = 1, RouteValues = null, OrderSerial = 3, StartTime = null, EndTime = null },
                new Menu() { MenuName = "Son1", Area = "Work", Controller = "Works", Action = "work1", Url = null, ParentMenuId = 1, State = 1, RouteValues = null, OrderSerial = 1, StartTime = null, EndTime = null },
                new Menu() { MenuName = "Son2", Area = "Work", Controller = "Works", Action = "work1", Url = null, ParentMenuId = 1, State = 0, RouteValues = null, OrderSerial = 2, StartTime = null, EndTime = null },
                new Menu() { MenuName = "Son3", Area = "Work", Controller = "Works", Action = "work1", Url = null, ParentMenuId = 1, State = 1, RouteValues = null, OrderSerial = 3, StartTime = null, EndTime = null },
                new Menu() { MenuName = "Son4", Area = "Job", Controller = "Jobs", Action = "job1", Url = null, ParentMenuId = 2, State = 1, RouteValues = null, OrderSerial = 3, StartTime = null, EndTime = null },
                new Menu() { MenuName = "Son5", Area = "Job", Controller = "Jobs", Action = "job2", Url = null, ParentMenuId = 2, State = 1, RouteValues = null, OrderSerial = 2, StartTime = null, EndTime = null },
                new Menu() { MenuName = "Son6", Area = "Job", Controller = "Jobs", Action = "job3", Url = null, ParentMenuId = 2, State = 1, RouteValues = null, OrderSerial = 1, StartTime = null, EndTime = null },
                new Menu() { MenuName = "Son7", Area = "Time", Controller = "Times", Action = "time1", Url = null, ParentMenuId = 3, State = 1, RouteValues = null, OrderSerial = 1, StartTime = null, EndTime = null },
                new Menu() { MenuName = "Son8", Area = "Time", Controller = "Times", Action = "time2", Url = null, ParentMenuId = 3, State = 1, RouteValues = null, OrderSerial = 2, StartTime = null, EndTime = null },
                new Menu() { MenuName = "Son9", Area = "Time", Controller = "Times", Action = "time3", Url = null, ParentMenuId = 3, State = 1, RouteValues = null, OrderSerial = 3, StartTime = null, EndTime = null }
                );
        }
    }
}
