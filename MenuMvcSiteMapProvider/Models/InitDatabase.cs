using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MenuMvcSiteMapProvider.Models
{
    public class InitDatabase : DropCreateDatabaseAlways<MenuModel>
    {
        protected override void Seed(MenuMvcSiteMapProvider.Models.MenuModel context)
        {
            List<Account> accountList = new List<Account>();
            accountList.Add(new Account() { Username = "acc1", Password = "520520", Role = "Admin" });
            accountList.Add(new Account() { Username = "acc2", Password = "520520", Role = "Teacher" });
            accountList.Add(new Account() { Username = "acc3", Password = "520520", Role = "Student" });
            accountList.Add(new Account() { Username = "acc4", Password = "520520", Role = "Visit" });

            context.Account.AddRange(accountList);

            List<Menu> menuList = new List<Menu>();
            menuList.Add(new Menu() { MenuName = "Parent1", Area = null, Controller = null, Action = null, Url = "#1", ParentMenuId = null, State = 1, RouteValues = null, OrderSerial = 1, StartTime = null, EndTime = null });
            menuList.Add(new Menu() { MenuName = "Parent2", Area = null, Controller = null, Action = null, Url = "#2", ParentMenuId = null, State = 1, RouteValues = null, OrderSerial = 2, StartTime = null, EndTime = null });
            menuList.Add(new Menu() { MenuName = "Parent3", Area = null, Controller = null, Action = null, Url = "#3", ParentMenuId = null, State = 1, RouteValues = null, OrderSerial = 3, StartTime = null, EndTime = null });
            menuList.Add(new Menu() { MenuName = "Son1", Area = "Work", Controller = "Works", Action = "work1", Url = null, ParentMenuId = 1, State = 1, RouteValues = null, OrderSerial = 1, StartTime = null, EndTime = null });
            menuList.Add(new Menu() { MenuName = "Son2", Area = "Work", Controller = "Works", Action = "work1", Url = null, ParentMenuId = 1, State = 0, RouteValues = null, OrderSerial = 2, StartTime = null, EndTime = null });
            menuList.Add(new Menu() { MenuName = "Son3", Area = "Work", Controller = "Works", Action = "work1", Url = null, ParentMenuId = 1, State = 1, RouteValues = null, OrderSerial = 3, StartTime = null, EndTime = null });
            menuList.Add(new Menu() { MenuName = "Son4", Area = "Job", Controller = "Jobs", Action = "job1", Url = null, ParentMenuId = 2, State = 1, RouteValues = null, OrderSerial = 3, StartTime = null, EndTime = null });
            menuList.Add(new Menu() { MenuName = "Son5", Area = "Job", Controller = "Jobs", Action = "job2", Url = null, ParentMenuId = 2, State = 1, RouteValues = null, OrderSerial = 2, StartTime = null, EndTime = null });
            menuList.Add(new Menu() { MenuName = "Son6", Area = "Job", Controller = "Jobs", Action = "job3", Url = null, ParentMenuId = 2, State = 1, RouteValues = null, OrderSerial = 1, StartTime = null, EndTime = null });
            menuList.Add(new Menu() { MenuName = "Son7", Area = "Time", Controller = "Times", Action = "time1", Url = null, ParentMenuId = 3, State = 1, RouteValues = null, OrderSerial = 1, StartTime = null, EndTime = null });
            menuList.Add(new Menu() { MenuName = "Son8", Area = "Time", Controller = "Times", Action = "time2", Url = null, ParentMenuId = 3, State = 1, RouteValues = null, OrderSerial = 2, StartTime = null, EndTime = null });
            menuList.Add(new Menu() { MenuName = "Son9", Area = "Time", Controller = "Times", Action = "time3", Url = null, ParentMenuId = 3, State = 1, RouteValues = null, OrderSerial = 3, StartTime = null, EndTime = null });

            context.Menu.AddRange(menuList);

            context.SaveChanges();
        }
    }
}