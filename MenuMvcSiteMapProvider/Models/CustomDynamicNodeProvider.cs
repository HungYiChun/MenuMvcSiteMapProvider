using MvcSiteMapProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MenuMvcSiteMapProvider.Models
{
    public class CustomDynamicNodeProvider : DynamicNodeProviderBase
    {

        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode nodes)
        {
            // 動態Menu List
            var returnValue = new List<DynamicNode>();

            using (var db = new MenuModel())
            {
                // Custom 使用者的Menu使用權
                // 預設使用者為 "Visit"，拜訪者
                string roleUser = "Visit";
                // 依各權限擁有的Menu Parent
                string[] haveMenu = new string[] { };
                // 判斷Session是否有使用者登入身分
                if (HttpContext.Current.Session["Role"] != null)
                {
                    roleUser = HttpContext.Current.Session["Role"].ToString();
                }
                // 依權限所屬的Menu List(包含Menu Parents和Menu Son)
                // Menu分Menu Parents和Menu Son，Menu Parents為父項，Menu Son為Menu Parents下的子項
                // 當父項關閉，所屬子項均關閉，子項也能獨立關閉
                List<Menu> roleMenus = new List<Menu>();
                Menu parentMenu;
                switch (roleUser) {
                    case "Admin" :
                        haveMenu = new string[] { "1", "2", "3" };
                        break;
                    case "Teacher":
                        haveMenu = new string[] { "1", "2", "3" };
                        break;
                    case "Student":
                        haveMenu = new string[] { "1", "2" };
                        break;
                    case "Visit":
                        haveMenu = new string[] { "1" };
                        break;
                }

                //Custom 使用者的Menu使用權
                foreach (string temp in haveMenu)
                {
                    parentMenu = db.Menu.FirstOrDefault(x => x.Id.ToString() == temp);
                    if (parentMenu.State == 1)
                    {
                        //Menu List 加入 父項
                        roleMenus.AddRange(db.Menu.Where(x => x.State ==1 
                        && x.Id.ToString() == temp 
                        &&(DateTime.Now > x.StartTime || x.StartTime.Equals(null)) 
                        && (DateTime.Now < x.EndTime || x.EndTime.Equals(null))).ToList());
                        //Menu List 加入 子項List
                        roleMenus.AddRange(db.Menu.Where(x => x.State == 1 
                        && x.ParentMenuId.ToString() == temp 
                        && (DateTime.Now > x.StartTime || x.StartTime.Equals(null)) 
                        && (DateTime.Now < x.EndTime || x.EndTime.Equals(null))).OrderBy(x => x.OrderSerial).ToList());
                    }
                }
                //Custom 使用者的Menu使用權
                foreach (Menu menu in roleMenus)
                {
                    DynamicNode node = new DynamicNode()
                    {
                        // 顯示的文字
                        Title = menu.MenuName,
                        // 父Menu項目Id
                        ParentKey = menu.ParentMenuId.HasValue ? menu.ParentMenuId.Value.ToString() : "",
                        // Node Key
                        Key = menu.Id.ToString(),
                        // Action Name
                        Action = menu.Action,
                        // Controller Name
                        Controller = menu.Controller,
                        // Area Name
                        Area = menu.Area,
                        // Url (只要有值就會以此為主)
                        Url = menu.Url
                    };

                    if (!string.IsNullOrWhiteSpace(menu.RouteValues))
                    {
                        // 此部分利用menu.RouteValues欄位文字轉乘key-value pair
                        // 當作RouteValues使用
                        // ex. Key1=value1,Key2=value2...
                        node.RouteValues = menu.RouteValues.Split(',').Select(value => value.Split('='))
                                                .ToDictionary(pair => pair[0], pair => (object)pair[1]);
                    }

                    returnValue.Add(node);
                }
            }

            return returnValue;
        }
    }
}