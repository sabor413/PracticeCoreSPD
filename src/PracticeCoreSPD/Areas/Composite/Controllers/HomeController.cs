using System.Collections.Generic;
using System.Xml;
using Microsoft.AspNetCore.Mvc;
using PracticeCoreSPD.Areas.Composite.Core;
using PracticeCoreSPD.Core;

namespace PracticeCoreSPD.Areas.Composite.Controllers
{
    [Area("Composite")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(AppSettings.MenuFilePath);
            List<Menu> menus = new List<Menu>();
            if (doc.DocumentElement != null)
            {
                foreach (XmlNode nodeOuter in doc.DocumentElement.ChildNodes)
                {
                    Menu menu = new Menu
                    {
                        Text = nodeOuter.ChildNodes[0].InnerText,
                        NavigateUrl = nodeOuter.ChildNodes[1].InnerText
                    };
                    if (nodeOuter.Attributes != null)
                        menu.OpenInNewWindow = bool.Parse(nodeOuter.Attributes["newWindow"].Value); //check newWindow for null
                    menu.Children = new List<IMenuComponent>();
                    foreach (XmlNode nodeInner in nodeOuter.ChildNodes[2].ChildNodes)
                    {
                        MenuItem menuItem = new MenuItem
                        {
                            Text = nodeInner.ChildNodes[0].InnerText,
                            NavigateUrl = nodeInner.ChildNodes[1].InnerText
                        };
                        menu.Children.Add(menuItem);
                    }
                    menus.Add(menu);
                }  
            }
            return View(menus);
        }
    }
}
