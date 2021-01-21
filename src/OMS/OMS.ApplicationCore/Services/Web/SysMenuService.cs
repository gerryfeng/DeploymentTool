using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace OMS.ApplicationCore
{
    public class SysMenuService :  ISysMenuService
    {
        private readonly ISysMenuRepository _menuRepository;
        private readonly ILogger<SysMenuService> _logger;
        private readonly IFlowGroupRepository _groupRepository;
        private readonly ISysMapSetRepository _sysMapSetRepository;

        public SysMenuService(ISysMenuRepository menuRepository, ILogger<SysMenuService> logger, IFlowGroupRepository groupRepository
            ,ISysMapSetRepository sysMapSetRepository) 
        {
            _menuRepository = menuRepository;
            _logger = logger;
            _groupRepository = groupRepository;
            _sysMapSetRepository = sysMapSetRepository;
        }

        #region 小程序菜单
        /// <summary>
        /// 获取小程序菜单
        /// </summary>
        /// <param name="websiteType"></param>
        /// <returns></returns>
        public async Task<List<Web4ModuleTreeItem>> MobilGetMiniAppListAsync(string websiteType, XmlDocument doc)
        {
            List<Web4ModuleTreeItem> result = new List<Web4ModuleTreeItem>();

            XmlNodeList websiteList = doc.SelectNodes(@"/configuration/MiniAPPSite");
            foreach (XmlNode xmlNode in websiteList)
            {
                if (xmlNode.SelectSingleNode("mode") != null && xmlNode.SelectSingleNode("mode").InnerText == websiteType)
                {
                    Web4ModuleTreeItem item = new Web4ModuleTreeItem();
                    item.stationID = websiteType + (result.Count + 1).ToString();
                    item.id = websiteType + xmlNode.SelectSingleNode("client").InnerText.Trim();
                    item.text = xmlNode.SelectSingleNode("title").InnerText;
                    item.menuType = "MiniApp" + websiteType + "Station";
                    item.clickType = "MiniApp" + websiteType + "Station";
                    item.leaf = false;
                    item.expanded = true;
                    item.iconCls = websiteType == "single" ? "civ-flag-green" : "civ-flag-pink";

                    item.allowDrag = false;
                    item.allowDrop = false;
                    item.draggable = false;
                    item.isTarget = true;

                    if (websiteType == "single")
                    {
                        item.dragAttribute = "MiniAppSingleStation";
                        item.allowDrag = true;
                        item.allowDrop = true;
                        item.draggable = true;
                    }

                    Web4ModuleTreeItem item10 = new Web4ModuleTreeItem();
                    item10.id = "MiniAppStationRoot" + xmlNode.SelectSingleNode("client").InnerText.Trim();
                    item10.text = "网站配置";
                    item10.iconCls = "civ-cog";
                    item10.leaf = true;
                    item10.clickType = "MiniAppWebsiteRoot";
                    item10.menuType = "MiniAppWebsiteRoot";
                    item.children.Add(item10);

                    if (websiteType == "single")
                    {
                        Web4ModuleTreeItem item13 = new Web4ModuleTreeItem();
                        item13.id = "MiniAppMenuRoot" + xmlNode.SelectSingleNode("client").InnerText.Trim();
                        item13.text = "菜单管理";
                        item13.iconCls = "civ-application-application_cascade";
                        item13.clickType = "MiniAppMenuRoot";
                        item13.menuType = "MiniAppMenuRoot";
                        item13.menuID = "-1";
                        item13.allowDrag = false;
                        item13.allowDrop = true;
                        item13.draggable = false;
                        item13.isTarget = true;
                        item13.dragAttribute = "MiniAppMenuRoot";
                        item13.children =await Task.Run(() => MiniAppGetMenuList(xmlNode.SelectSingleNode("client").InnerText.Trim())) ;
                        if (item13.children.Count == 0)
                            item13.leaf = true;

                        item.children.Add(item13);
                    }
                    else if (websiteType == "integration")
                    {
                        Web4ModuleTreeItem item13 = new Web4ModuleTreeItem();
                        item13.id = "MiniAppChildStation" + xmlNode.SelectSingleNode("client").InnerText.Trim();
                        item13.text = "子站管理";
                        item13.iconCls = "civ-application-application_cascade";
                        item13.clickType = "MiniAppChildStation";
                        item13.menuType = "MiniAppChildStation";
                        item13.menuID = "-1";
                        item13.expanded = true;
                        item13.allowDrag = false;
                        item13.allowDrop = true;
                        item13.draggable = false;
                        item13.isTarget = true;
                        item13.dragAttribute = "MiniAppChildStation";
                        item13.children = await Task.Run(() => MiniAppGetChildStationList(xmlNode.SelectSingleNode("client").InnerText.Trim())) ;
                        if (item13.children.Count == 0)
                            item13.leaf = true;

                        item.children.Add(item13);
                    }

                    result.Add(item);
                }
            }

            return result;
        }

        /// <summary>
        /// 删除小程序菜单和角色
        /// </summary>
        /// <param name="visible"></param>
        /// <returns></returns>
        public async Task DeleteMiniMenu(string visible)
        {
            List<SysMenu> menus = _menuRepository.GetList(new Q_Menu() { visible = visible, isTrack = false, isInclude = true });
            _menuRepository.RemoveRange(menus);
            _groupRepository.RemoveRange(await _groupRepository.GetListAsync(new Q_Group() { visible = visible }));
        }
        private bool Web4NeedExpand(List<Web4ModuleTreeItem> list, string select)
        {
            if (list.Count == 0)
                return false;

            bool result = false;

            for (int i = 0; i < list.Count; i++)
            {
                if ((list[i].id == select || Web4NeedExpand(list[i].children, select)) && list[i].children.Count > 0)
                {
                    result = true;
                    list[i].expanded = true;
                }
                else if (list[i].id == select || Web4NeedExpand(list[i].children, select))
                {
                    result = true;
                    list[i].expanded = false;
                }
                else
                {
                    list[i].expanded = false;
                }
            }

            return result;
        }

        private List<Web4ModuleTreeItem> MiniAppGetChildStationList(string subSystemValue)
        {
            List<Web4ModuleTreeItem> result = new List<Web4ModuleTreeItem>();

            List<SysMenu> menus = _menuRepository.GetList(new Q_Menu() { visible = subSystemValue, parentIdNotEquals = -2 }).OrderBy(x => x.Orderid).ToList();

            foreach (SysMenu m in menus)
            {
                if (m.Pageurl.StartsWith("href:"))
                {
                    Web4ModuleTreeItem item = new Web4ModuleTreeItem();
                    item.menuID = m.Nodeid.ToString();
                    item.id = "children-" + item.menuID;
                    item.text = m.Nodename;
                    item.menuType = "MiniAppChildrenWebsite";
                    item.clickType = "MiniAppChildrenWebsite";
                    item.dragAttribute = "MiniAppChildrenWebsite";
                    item.iconCls = "civ-application";
                    item.leaf = true;
                    item.allowDrag = true;
                    item.allowDrop = false;
                    item.draggable = true;
                    item.isTarget = true;
                    item.isTarget = true;

                    result.Add(item);
                }
                else if (m.Parentid == -1)
                {
                    if (!string.IsNullOrEmpty(m.Pageurl))
                    {
                        Web4ModuleTreeItem firstMenu = new Web4ModuleTreeItem();
                        firstMenu.menuID = m.Nodeid.ToString();
                        firstMenu.id = "menu-" + firstMenu.menuID;
                        firstMenu.text = m.Nodename;
                        firstMenu.menuType = "MiniAppMenu";
                        firstMenu.clickType = "MiniAppMenu";
                        firstMenu.iconCls = "civ-application";
                        firstMenu.allowDrag = true;
                        firstMenu.allowDrop = true;
                        firstMenu.draggable = true;
                        firstMenu.isTarget = true;
                        firstMenu.dragAttribute = "MiniAppMenu";
                        firstMenu.children = new List<Web4ModuleTreeItem>();
                        firstMenu.leaf = true;
                        firstMenu.expanded = false;

                        result.Add(firstMenu);
                    }
                    else
                    {
                        Web4ModuleTreeItem firstMenuGroup = new Web4ModuleTreeItem();
                        firstMenuGroup.menuID = m.Nodeid.ToString();
                        firstMenuGroup.id = "menu-" + firstMenuGroup.menuID;
                        firstMenuGroup.text = m.Nodename;
                        firstMenuGroup.menuType = "MiniAppMenuGroup";
                        firstMenuGroup.clickType = "MiniAppMenuGroup";
                        firstMenuGroup.iconCls = "civ-folder";
                        firstMenuGroup.allowDrag = true;
                        firstMenuGroup.allowDrop = true;
                        firstMenuGroup.draggable = true;
                        firstMenuGroup.isTarget = true;
                        firstMenuGroup.dragAttribute = "MiniAppMenuGroup";

                        firstMenuGroup.children.AddRange(GetMenuItem(m.Nodeid, menus));

                        result.Add(firstMenuGroup);
                    }
                }
            }

            return result;
        }

        private List<Web4ModuleTreeItem> GetMenuItem(int nodeId, List<SysMenu> menus)
        {
            List<Web4ModuleTreeItem> result = new List<Web4ModuleTreeItem>();

            foreach (SysMenu m in menus)
            {
                if (nodeId == m.Parentid)
                {
                    Web4ModuleTreeItem item = new Web4ModuleTreeItem();
                    item.menuID = m.Nodeid.ToString();
                    item.id = "menu-" + item.menuID;
                    item.text = m.Nodename;

                    if (!string.IsNullOrEmpty(m.Pageurl))
                    {
                        item.menuType = "Web4Menu";
                        item.clickType = "Web4Menu";

                        item.iconCls = "civ-application";
                        item.allowDrag = true;
                        item.allowDrop = true;
                        item.draggable = true;
                        item.isTarget = true;
                        item.dragAttribute = "Web4Menu";
                        item.children = new List<Web4ModuleTreeItem>();
                        item.leaf = true;
                        item.expanded = false;
                        item.product = m.Product;
                    }
                    else
                    {
                        item.menuType = "Web4MenuGroup";
                        item.clickType = "Web4MenuGroup";
                        item.iconCls = "civ-folder";
                        item.allowDrag = true;
                        item.allowDrop = true;
                        item.draggable = true;
                        item.isTarget = true;
                        item.dragAttribute = "Web4MenuGroup";
                        item.product = m.Product;
                        item.children.AddRange(GetMenuItem(m.Nodeid, menus));

                    }

                    result.Add(item);
                }
            }

            return result;
        }

        private List<Web4ModuleTreeItem> MiniAppGetMenuList(string subSystemValue)
        {
            List<Web4ModuleTreeItem> result = new List<Web4ModuleTreeItem>();

            //DataBaseManager.CheckWorkflowDataBaseV3();

            List<SysMenu> menus = _menuRepository.GetList(new Q_Menu() { visible = subSystemValue }).OrderBy(x => x.Orderid).ToList();

            foreach (SysMenu m in menus)
            {
                if (m.Parentid == -1)
                {
                    if (!string.IsNullOrEmpty(m.Pageurl))
                    {
                        Web4ModuleTreeItem firstMenu = new Web4ModuleTreeItem();
                        firstMenu.menuID = m.Nodeid.ToString();
                        firstMenu.id = "menu-" + firstMenu.menuID;
                        firstMenu.text = m.Nodename;
                        firstMenu.menuType = "MiniAppMenu";
                        firstMenu.clickType = "MiniAppMenu";
                        firstMenu.iconCls = "civ-application";
                        firstMenu.allowDrag = true;
                        firstMenu.allowDrop = true;
                        firstMenu.draggable = true;
                        firstMenu.isTarget = true;
                        firstMenu.dragAttribute = "MiniAppMenu";
                        firstMenu.children = new List<Web4ModuleTreeItem>();
                        firstMenu.leaf = true;
                        firstMenu.expanded = false;

                        result.Add(firstMenu);
                    }
                    else
                    {
                        Web4ModuleTreeItem firstMenuGroup = new Web4ModuleTreeItem();
                        firstMenuGroup.menuID = m.Nodeid.ToString();
                        firstMenuGroup.id = "menu-" + firstMenuGroup.menuID;
                        firstMenuGroup.text = m.Nodename;
                        firstMenuGroup.menuType = "MiniAppMenuGroup";
                        firstMenuGroup.clickType = "MiniAppMenuGroup";
                        firstMenuGroup.iconCls = "civ-folder";
                        firstMenuGroup.allowDrag = true;
                        firstMenuGroup.allowDrop = true;
                        firstMenuGroup.draggable = true;
                        firstMenuGroup.isTarget = true;
                        firstMenuGroup.dragAttribute = "MiniAppMenuGroup";

                        firstMenuGroup.children.AddRange(GetMiniAppMenuItem(m.Nodeid, menus, firstMenuGroup));

                        result.Add(firstMenuGroup);
                    }
                }
            }
            return result;
        }

        private List<Web4ModuleTreeItem> GetMiniAppMenuItem(int nodeId, List<SysMenu> menus, Web4ModuleTreeItem parentItem)
        {
            List<Web4ModuleTreeItem> result = new List<Web4ModuleTreeItem>();
            foreach (SysMenu m in menus)
            {
                if (nodeId == m.Parentid)
                {
                    Web4ModuleTreeItem item = new Web4ModuleTreeItem();
                    item.menuID = m.Nodeid.ToString();
                    item.id = "menu-" + item.menuID;
                    item.text = m.Nodename;

                    if (!string.IsNullOrEmpty(m.Pageurl))
                    {
                        if (parentItem.menuType == "MiniAppMenuGroupTwo")
                        {
                            item.menuType = "MiniAppMenuThree";
                        }
                        else
                        {
                            item.menuType = "MiniAppMenu";
                        }
                        item.clickType = "MiniAppMenu";
                        item.iconCls = "civ-application";
                        item.allowDrag = true;
                        item.allowDrop = true;
                        item.draggable = true;
                        item.isTarget = true;
                        item.dragAttribute = "MiniAppMenu";
                        item.children = new List<Web4ModuleTreeItem>();
                        item.leaf = true;
                        item.expanded = false;
                    }
                    else
                    {
                        item.menuType = "MiniAppMenuGroupTwo";
                        item.clickType = "MiniAppMenuGroup";
                        item.iconCls = "civ-folder";
                        item.allowDrag = true;
                        item.allowDrop = true;
                        item.draggable = true;
                        item.isTarget = true;
                        item.dragAttribute = "MiniAppMenuGroup";

                        item.children.AddRange(GetMiniAppMenuItem(m.Nodeid, menus, item));
                    }
                    result.Add(item);
                }
            }

            return result;
        }
        #endregion

        #region Web配置
       /// <summary>
       /// web菜单
       /// </summary>
       /// <param name="websiteType"></param>
       /// <param name="doc"></param>
       /// <returns></returns>
        public async Task<List<Web4ModuleTreeItem>> Web4GetICStationListAsync(string websiteType, XmlDocument doc)
        {
            List<Web4ModuleTreeItem> result = new List<Web4ModuleTreeItem>();
            XmlNodeList websiteList = doc.SelectNodes(@"/configuration/website");
            foreach (XmlNode xmlNode in websiteList)
            {
                if (xmlNode.SelectSingleNode("mode") != null && xmlNode.SelectSingleNode("mode").InnerText == websiteType)
                {
                    Web4ModuleTreeItem item = new Web4ModuleTreeItem();
                    item.stationID = websiteType + (result.Count + 1).ToString();
                    item.id = websiteType + xmlNode.SelectSingleNode("client").InnerText.Trim();
                    item.text = xmlNode.SelectSingleNode("title").InnerText;
                    item.menuType = "Web4" + websiteType + "Station";
                    item.clickType = "Web4" + websiteType + "Station";
                    item.leaf = false;
                    item.expanded = true;
                    item.iconCls = websiteType == "single" ? "civ-flag-green" : "civ-flag-pink";

                    item.allowDrag = false;
                    item.allowDrop = false;
                    item.draggable = false;
                    item.isTarget = true;

                    if (websiteType == "single")
                    {
                        item.dragAttribute = "Web4SingleStation";
                        item.allowDrag = true;
                        item.allowDrop = true;
                        item.draggable = true;
                    }

                    Web4ModuleTreeItem item10 = new Web4ModuleTreeItem();
                    item10.id = "Web4StationRoot" + xmlNode.SelectSingleNode("client").InnerText.Trim();
                    item10.text = "网站配置";
                    item10.iconCls = "civ-cog";
                    item10.leaf = true;
                    item10.clickType = "Web4WebsiteRoot";
                    item10.menuType = "Web4WebsiteRoot";
                    item.children.Add(item10);

                    if (websiteType == "single")
                    {
                        Web4ModuleTreeItem item13 = new Web4ModuleTreeItem();
                        item13.id = "Web4MenuRoot" + xmlNode.SelectSingleNode("client").InnerText.Trim();
                        item13.text = "菜单管理";
                        item13.iconCls = "civ-application-application_cascade";
                        item13.clickType = "Web4MenuRoot";
                        item13.menuType = "Web4MenuRoot";
                        item13.menuID = "-1";
                        item13.allowDrag = false;
                        item13.allowDrop = true;
                        item13.draggable = false;
                        item13.isTarget = true;
                        item13.dragAttribute = "Web4MenuRoot";
                        item13.children =await Task.Run(() => Web4GetMenuList(xmlNode.SelectSingleNode("client").InnerText.Trim())) ;
                        if (item13.children.Count == 0)
                            item13.leaf = true;

                        item.children.Add(item13);
                    }
                    else if (websiteType == "integration")
                    {
                        Web4ModuleTreeItem item13 = new Web4ModuleTreeItem();
                        item13.id = "Web4ChildStation" + xmlNode.SelectSingleNode("client").InnerText.Trim();
                        item13.text = "子站管理";
                        item13.iconCls = "civ-application-application_cascade";
                        item13.clickType = "Web4ChildStation";
                        item13.menuType = "Web4ChildStation";
                        item13.menuID = "-1";
                        item13.expanded = true;
                        item13.allowDrag = false;
                        item13.allowDrop = true;
                        item13.draggable = false;
                        item13.isTarget = true;
                        item13.dragAttribute = "Web4ChildStation";
                        item13.children = await Task.Run(() => Web4GetChildStationList(xmlNode.SelectSingleNode("client").InnerText.Trim()));
                        if (item13.children.Count == 0)
                            item13.leaf = true;

                        item.children.Add(item13);
                    }

                    result.Add(item);
                }
            }
            return result;
        }

        private List<Web4ModuleTreeItem> Web4GetChildStationList(string subSystemValue)
        {
            List<Web4ModuleTreeItem> result = new List<Web4ModuleTreeItem>();

            List<SysMenu> menus = _menuRepository.GetList(new Q_Menu() { visible = subSystemValue, parentIdNotEquals = -2 }).OrderBy(x => x.Orderid).ToList(); ;

            foreach (SysMenu m in menus)
            {
                if (m.Pageurl.StartsWith("href:"))
                {
                    Web4ModuleTreeItem item = new Web4ModuleTreeItem();
                    item.menuID = m.Nodeid.ToString();
                    item.id = "children-" + item.menuID;
                    item.text = m.Nodename;
                    item.menuType = "Web4ChildrenWebsite";
                    item.clickType = "Web4ChildrenWebsite";
                    item.dragAttribute = "Web4ChildrenWebsite";
                    item.iconCls = "civ-application";
                    item.leaf = true;
                    item.allowDrag = true;
                    item.allowDrop = false;
                    item.draggable = true;
                    item.isTarget = true;
                    item.isTarget = true;

                    result.Add(item);
                }
                else if (m.Parentid == -1)
                {
                    if (!string.IsNullOrEmpty(m.Pageurl))
                    {
                        Web4ModuleTreeItem firstMenu = new Web4ModuleTreeItem();
                        firstMenu.menuID = m.Nodeid.ToString();
                        firstMenu.id = "menu-" + firstMenu.menuID;
                        firstMenu.text = m.Nodename;
                        firstMenu.menuType = "Web4Menu";
                        firstMenu.clickType = "Web4Menu";
                        firstMenu.iconCls = "civ-application";
                        firstMenu.allowDrag = true;
                        firstMenu.allowDrop = true;
                        firstMenu.draggable = true;
                        firstMenu.isTarget = true;
                        firstMenu.dragAttribute = "Web4Menu";
                        firstMenu.children = new List<Web4ModuleTreeItem>();
                        firstMenu.leaf = true;
                        firstMenu.expanded = false;

                        result.Add(firstMenu);
                    }
                    else
                    {
                        Web4ModuleTreeItem firstMenuGroup = new Web4ModuleTreeItem();
                        firstMenuGroup.menuID = m.Nodeid.ToString();
                        firstMenuGroup.id = "menu-" + firstMenuGroup.menuID;
                        firstMenuGroup.text = m.Nodename;
                        firstMenuGroup.menuType = "Web4MenuGroup";
                        firstMenuGroup.clickType = "Web4MenuGroup";
                        firstMenuGroup.iconCls = "civ-folder";
                        firstMenuGroup.allowDrag = true;
                        firstMenuGroup.allowDrop = true;
                        firstMenuGroup.draggable = true;
                        firstMenuGroup.isTarget = true;
                        firstMenuGroup.dragAttribute = "Web4MenuGroup";

                        firstMenuGroup.children.AddRange(GetMenuItem(m.Nodeid, menus));

                        result.Add(firstMenuGroup);
                    }
                }
            }

            return result;
        }

        private async Task<List<Web4ModuleTreeItem>> Web4GetStationList(string subSystemValue)
        {
            List<Web4ModuleTreeItem> result = new List<Web4ModuleTreeItem>();
            //select * from FLOW_GROUPS where 类型 = 2 and 名称 like '站点[_]%' and visible = '{0}' order by indexorder,机构ID

            List<Flow_Groups> groups = await _groupRepository.GetListAsync(new Q_Group() { visible = subSystemValue, type = 2, name = "站点_" });
            foreach (Flow_Groups g in groups)
            {
                Web4ModuleTreeItem item = new Web4ModuleTreeItem();
                item.stationID = g.机构ID.ToString();
                item.id = "station-" + item.stationID;
                item.text = g.名称.Substring("站点_".Length);
                item.description = g.描述;
                item.menuType = "Web4Station";
                item.clickType = "Web4Station";
                item.leaf = true;
                item.expanded = false;
                item.iconCls = "civ-user-orange";
                item.allowDrag = true;
                item.allowDrop = true;
                item.draggable = true;
                item.isTarget = true;
                item.dragAttribute = "Role";

                result.Add(item);
            }
            return result;
        }
        private List<Web4ModuleTreeItem> Web4GetMenuList(string subSystemValue)
        {
            List<Web4ModuleTreeItem> result = new List<Web4ModuleTreeItem>();

            //DataBaseManager.CheckWorkflowDataBaseV3();
            List<SysMenu> menus = _menuRepository.GetList(new Q_Menu() { visible = subSystemValue }).OrderBy(x => x.Orderid).ToList();

            foreach (SysMenu m in menus)
            {
                if (m.Parentid != -1) continue;

                if (!string.IsNullOrEmpty(m.Pageurl))
                {
                    Web4ModuleTreeItem firstMenu = new Web4ModuleTreeItem();
                    firstMenu.menuID = m.Nodeid.ToString();
                    firstMenu.id = "menu-" + firstMenu.menuID;
                    firstMenu.text = m.Nodename;
                    firstMenu.menuType = "Web4Menu";
                    firstMenu.clickType = "Web4Menu";
                    firstMenu.iconCls = "civ-application";
                    firstMenu.allowDrag = true;
                    firstMenu.allowDrop = true;
                    firstMenu.draggable = true;
                    firstMenu.isTarget = true;
                    firstMenu.dragAttribute = "Web4Menu";
                    firstMenu.children = new List<Web4ModuleTreeItem>();
                    firstMenu.leaf = true;
                    firstMenu.expanded = false;
                    firstMenu.product = m.Product;
                    result.Add(firstMenu);
                }
                else
                {
                    Web4ModuleTreeItem firstMenuGroup = new Web4ModuleTreeItem();
                    firstMenuGroup.menuID = m.Nodeid.ToString();
                    firstMenuGroup.id = "menu-" + firstMenuGroup.menuID;
                    firstMenuGroup.text = m.Nodename;
                    firstMenuGroup.menuType = "Web4MenuGroup";
                    firstMenuGroup.clickType = "Web4MenuGroup";
                    firstMenuGroup.iconCls = "civ-folder";
                    firstMenuGroup.allowDrag = true;
                    firstMenuGroup.allowDrop = true;
                    firstMenuGroup.draggable = true;
                    firstMenuGroup.isTarget = true;
                    firstMenuGroup.dragAttribute = "Web4MenuGroup";
                    firstMenuGroup.product = m.Product;
                    firstMenuGroup.children.AddRange(GetMenuItem(m.Nodeid, menus));

                    result.Add(firstMenuGroup);
                }
            }


            return result;
        }

        #endregion

        #region 手持菜单
        public async Task<List<MobileModuleTreeItem>> GetMobileModuleTreeAsync(string userMode, string subSystemValue)
        {
            // DbOper.DeleteUnique();

            List<MobileModuleTreeItem> result = new List<MobileModuleTreeItem>();
            if (userMode == "admin" || userMode == "super")
            {
                MobileModuleTreeItem item3 = new MobileModuleTreeItem();
                item3.id = "MobileSevenParams";
                item3.text = "七参数";
                item3.iconCls = "civ-note-edit";
                item3.leaf = true;
                item3.clickType = "MobileSevenParams";
                item3.menuType = "MobileSevenParams";
                result.Add(item3);

                MobileModuleTreeItem item6 = new MobileModuleTreeItem();
                item6.id = "MobileMenuRoot";
                item6.text = "菜单管理";
                item6.iconCls = "civ-application-application_cascade";
                item6.clickType = "MobileMenuRoot";
                item6.menuType = "MobileMenuRoot";
                item6.children =await Task.Run(() => MobileGetMenuList(subSystemValue)) ;
                if (item6.children.Count == 0)
                    item6.leaf = true;
                else
                {
                    item6.expanded = true;
                    item6.leaf = false;
                }
                result.Add(item6);
            }
            else if (userMode == "common")
            {
                MobileModuleTreeItem item3 = new MobileModuleTreeItem();
                item3.id = "MobileSevenParams";
                item3.text = "七参数";
                item3.iconCls = "civ-note-edit";
                item3.leaf = true;
                item3.clickType = "MobileSevenParams";
                item3.menuType = "MobileSevenParams";
                result.Add(item3);
            }

            return result;
        }

        /// <summary>
        /// 手持菜单管理
        /// </summary>
        /// <param name="subSystemValue"></param>
        /// <returns></returns>
        private List<MobileModuleTreeItem> MobileGetMenuList(string subSystemValue)
        {
            List<MobileModuleTreeItem> result = new List<MobileModuleTreeItem>();

            List<SysMenu> menus = _menuRepository.GetList(new Q_Menu() { visible = subSystemValue });

            MobileMenu mobileAllMenu = buildMenuFromDB(subSystemValue, menus.Where(x => x.Visible == subSystemValue).ToList());

            //添加一级菜单
            MobileModuleTreeItem mainMenus = new MobileModuleTreeItem();
            mainMenus.id = "menu-MainMenus";
            mainMenus.text = "主页菜单";
            mainMenus.menuID = "MainMenus";
            mainMenus.iconCls = "civ-folder";
            mainMenus.expanded = false;

            mainMenus.allowDrag = false;
            mainMenus.allowDrop = true;
            mainMenus.draggable = false;
            mainMenus.isTarget = true;
            mainMenus.dragAttribute = "MobileMainMenusRoot";

            if (mobileAllMenu.MainMenus.Count > 0)
                mainMenus.leaf = false;
            else
                mainMenus.leaf = true;
            mainMenus.menuType = "MobileMenuTopHomePage";

            result.Add(mainMenus);

            MobileModuleTreeItem mapToolBars = new MobileModuleTreeItem();
            mapToolBars.id = "menu-MapToolBars";
            mapToolBars.text = "工具菜单";
            mapToolBars.menuID = "MapToolBars";
            mapToolBars.iconCls = "civ-folder";
            mapToolBars.expanded = false;

            mapToolBars.allowDrag = false;
            mapToolBars.allowDrop = true;
            mapToolBars.draggable = false;
            mapToolBars.isTarget = true;
            mapToolBars.dragAttribute = "MobileMapToolBarsRoot";

            if (mobileAllMenu.MapToolBars.Count > 0)
                mapToolBars.leaf = false;
            else
                mapToolBars.leaf = true;
            mapToolBars.menuType = "MobileMenuTop";

            result.Add(mapToolBars);

            MobileModuleTreeItem mapMoreMenus = new MobileModuleTreeItem();
            mapMoreMenus.id = "menu-MapMoreMenus";
            mapMoreMenus.text = "附加菜单";
            mapMoreMenus.menuID = "MapMoreMenus";
            mapMoreMenus.iconCls = "civ-folder";
            mapMoreMenus.expanded = false;

            mapMoreMenus.allowDrag = false;
            mapMoreMenus.allowDrop = true;
            mapMoreMenus.draggable = false;
            mapMoreMenus.isTarget = true;
            mapMoreMenus.dragAttribute = "MobileMapMoreMenusRoot";

            if (mobileAllMenu.MapMoreMenus.Count > 0)
                mapMoreMenus.leaf = false;
            else
                mapMoreMenus.leaf = true;
            mapMoreMenus.menuType = "MobileMenuTop";

            result.Add(mapMoreMenus);

            List<string> secondMenusIDs = new List<string>();

            //添加二级菜单
            foreach (MobileMenuItem item in mobileAllMenu.MainMenus)
            {
                MobileModuleTreeItem menu = new MobileModuleTreeItem();

                //菜单组
                if (string.IsNullOrEmpty(item.Name))
                {
                    menu.id = "menu-" + item.MenuID;
                    menu.menuID = item.MenuID;
                    menu.text = item.Alias;
                    menu.iconCls = "civ-folder";
                    menu.clickType = "MobileMainMenuGroup";
                    menu.menuType = "MobileMainMenuGroup";
                    menu.allowDrag = true;
                    menu.allowDrop = true;
                    menu.draggable = true;
                    menu.expanded = false;
                    menu.isTarget = true;
                    menu.dragAttribute = "MobileMainMenuGroup";

                    secondMenusIDs.Add(item.MenuID);
                }
                else
                {
                    menu.id = "menu-" + item.MenuID;
                    menu.menuID = item.MenuID;
                    menu.text = item.Alias;
                    menu.iconCls = "civ-application";
                    menu.expanded = false;
                    menu.leaf = true;
                    menu.clickType = "MobileMenu";
                    menu.menuType = "MobileMenu";

                    menu.allowDrag = true;
                    menu.allowDrop = true;
                    menu.draggable = true;
                    menu.isTarget = true;
                    menu.dragAttribute = "MobileMainMenus";
                }

                result[0].children.Add(menu);
            }

            List<SysMenu> secondMenu = menus;
            if (secondMenusIDs.Count > 0) secondMenu = secondMenu.Where(x => secondMenusIDs.Contains(x.Nodeid.ToString())).OrderBy(x => new { x.Orderid, x.Nodeid }).ToList();

            for (int i = 0; i < result[0].children.Count; i++)
            {
                foreach (SysMenu m in secondMenu)
                {
                    if (result[0].children[i].menuID == m.Parentid.ToString())
                    {
                        MobileModuleTreeItem menu = new MobileModuleTreeItem();
                        menu.id = "menu-" + m.Nodeid;
                        menu.menuID = m.Nodeid.ToString();
                        menu.text = m.Nodename;
                        menu.iconCls = "civ-application";
                        menu.expanded = false;
                        menu.leaf = true;
                        menu.clickType = "MobileMenu";
                        menu.menuType = "MobileMenu";

                        menu.allowDrag = true;
                        menu.allowDrop = true;
                        menu.draggable = true;
                        menu.isTarget = true;
                        menu.dragAttribute = "MobileMainMenus";

                        result[0].children[i].children.Add(menu);
                    }
                }
                if (result[0].children[i].children.Count == 0)
                    result[0].children[i].leaf = true;
            }

            foreach (MobileMenuItem item in mobileAllMenu.MapToolBars)
            {
                MobileModuleTreeItem menu = new MobileModuleTreeItem();

                menu.id = "menu-" + item.MenuID;
                menu.menuID = item.MenuID;
                menu.text = item.Alias;
                menu.iconCls = "civ-application";
                menu.expanded = false;
                menu.leaf = true;
                menu.clickType = "MobileMenu";
                menu.menuType = "MobileMenu";

                menu.allowDrag = true;
                menu.allowDrop = true;
                menu.draggable = true;
                menu.isTarget = true;
                menu.dragAttribute = "MobileMapToolBars";

                result[1].children.Add(menu);
            }

            foreach (MobileMenuItem item in mobileAllMenu.MapMoreMenus)
            {
                MobileModuleTreeItem menu = new MobileModuleTreeItem();

                menu.id = "menu-" + item.MenuID;
                menu.menuID = item.MenuID;
                menu.text = item.Alias;
                menu.iconCls = "civ-application";
                menu.expanded = false;
                menu.leaf = true;
                menu.clickType = "MobileMenu";
                menu.menuType = "MobileMenu";

                menu.allowDrag = true;
                menu.allowDrop = true;
                menu.draggable = true;
                menu.isTarget = true;
                menu.dragAttribute = "MobileMapMoreMenus";

                result[2].children.Add(menu);
            }

            return result;
        }

        private MobileMenu buildMenuFromDB(string subSystemValue, List<SysMenu> menus)
        {
            MobileMenu menu = new MobileMenu();

            var mainMenus = from m1 in menus
                            join m2 in (from k in menus where k.Parentid == -1 && k.Nodename == "主页菜单" select new { NodeId = k.Nodeid })
                            on m1.Parentid equals m2.NodeId
                            select m1;

            mainMenus.ToList().ForEach(w => {
                menu.MainMenus.Add(new MobileMenuItem() { MenuID = w.Nodeid.ToString(), parentID = w.Parentid.ToString(), Alias = w.Nodename, Name = w.Pageurl });
                menu.MainMenus.Last().children.AddRange(GetMainMenuItem(w.Nodeid, menus));
            });

            var mapToolBars = from m1 in menus
                              join m2 in (from k in menus where k.Parentid == -1 && k.Nodename == "工具菜单" select new { NodeId = k.Nodeid })
                              on m1.Parentid equals m2.NodeId
                              select m1;

            mapToolBars.ToList().ForEach(w => {
                menu.MapToolBars.Add(new MobileMenuItem() { MenuID = w.Nodeid.ToString(), Alias = w.Nodename, Name = w.Pageurl });
            });

            var mapMoreMenus = from m1 in menus
                               join m2 in (from k in menus where k.Parentid == -1 && k.Nodename == "附加菜单" select new { NodeId = k.Nodeid })
                               on m1.Parentid equals m2.NodeId
                               select m1;

            mapMoreMenus.ToList().ForEach(w => {
                menu.MapMoreMenus.Add(new MobileMenuItem() { MenuID = w.Nodeid.ToString(), Alias = w.Nodename, Name = w.Pageurl });
            });

            return menu;
        }

        private List<MobileMenuItem> GetMainMenuItem(int nodeId, List<SysMenu> menus)
        {
            List<MobileMenuItem> result = new List<MobileMenuItem>();
            foreach (SysMenu m in menus)
            {
                if (nodeId == m.Parentid)
                {
                    MobileMenuItem item = new MobileMenuItem();
                    item.MenuID = m.Nodeid.ToString();
                    item.parentID = m.Parentid.ToString();
                    item.Alias = m.Nodename;
                    item.Name = m.Pageurl;

                    if (!string.IsNullOrEmpty(m.Nodename))
                        item.children.AddRange(GetMainMenuItem(m.Nodeid, menus));

                    result.Add(item);
                }
            }

            return result;
        }
        #endregion

        #region 获取网站配置
        public async Task<List<WebSiteConfig>> GetWebSiteConfigAsync(string client, string token, string departID, XmlDocument doc, string maplayerPath)
        {
            List<WebSiteConfig> result = new List<WebSiteConfig>();

            WebSiteConfig webSiteConfig = await GetWebSiteItem(client, token, departID, doc, maplayerPath);
            result.Add(webSiteConfig);
           
            if (webSiteConfig.mode == "integration")
            {
                List<Flow_Groups> groups = await _groupRepository.GetListAsync(new Q_Group() { type = 2, Include = true, token = token, notEqualNames = new List<string>() { "站点_", "地图_" }});
               
                for (int i = 0; i < groups.Count; i++)
                {
                    WebSiteConfig item = new WebSiteConfig();
                    item = await GetWebSiteItem(groups[i].VISIBLE, token, departID, doc, maplayerPath);

                    if (item.client != null)
                        result.Add(item);
                }
            }

            return result;
        }

        private async Task<WebSiteConfig> GetWebSiteItem(string client, string token, string departID, XmlDocument doc, string maplayerPath)
        {
            WebSiteConfig webSiteConfig1 = new WebSiteConfig
            {
                mapsettings = new MapConfig()
            };

            #region 基本配置
            XmlNodeList xmlNodeList = doc.SelectNodes(@"/configuration/website");
            foreach (XmlNode xmlNode in xmlNodeList)
            {
                if (client == xmlNode.SelectSingleNode("client").InnerText.Trim())
                {
                    webSiteConfig1.title = xmlNode.SelectSingleNode("title").InnerText.Trim();
                    webSiteConfig1.style = xmlNode.SelectSingleNode("style").InnerText.Trim();
                    webSiteConfig1.subtitle = xmlNode.SelectSingleNode("subtitle").InnerText.Trim();
                    webSiteConfig1.client = xmlNode.SelectSingleNode("client").InnerText.Trim();
                    webSiteConfig1.mode = xmlNode.SelectSingleNode("mode").InnerText.Trim();
                    webSiteConfig1.shortcutIcon = xmlNode.SelectSingleNode("shortcutIcon").InnerText.Trim();
                    webSiteConfig1.logo = xmlNode.SelectSingleNode("logo").InnerText.Trim();
                    webSiteConfig1.bannerLogo = xmlNode.SelectSingleNode("bannerLogo").InnerText.Trim();

                    Widgets widget = new Widgets();
                    widget.label = "系统菜单组";
                    widget.url = xmlNode.SelectSingleNode("homePage").InnerText.Trim();
                    widget.visible = false;
                    webSiteConfig1.widgets.Add(widget);
                    
                    webSiteConfig1.loginTemplate = xmlNode.SelectSingleNode("loginTemplate").InnerText.Trim();

                    webSiteConfig1.theme = "";
                    if (xmlNode.SelectSingleNode("theme") != null)
                        webSiteConfig1.theme = xmlNode.SelectSingleNode("theme").InnerText.Trim();

                    webSiteConfig1.menu = "";
                    if (xmlNode.SelectSingleNode("menu") != null)
                        webSiteConfig1.menu = xmlNode.SelectSingleNode("menu").InnerText.Trim();

                    webSiteConfig1.qrcode = "";
                    if (xmlNode.SelectSingleNode("qrcode") != null)
                        webSiteConfig1.qrcode = xmlNode.SelectSingleNode("qrcode").InnerText.Trim();

                    webSiteConfig1.mdi = "";
                    if (xmlNode.SelectSingleNode("mdi") != null)
                        webSiteConfig1.mdi = xmlNode.SelectSingleNode("mdi").InnerText.Trim();

                    webSiteConfig1.alarmWays = "";
                    if (xmlNode.SelectSingleNode("alarmWays") != null)
                        webSiteConfig1.alarmWays = xmlNode.SelectSingleNode("alarmWays").InnerText.Trim();

                    webSiteConfig1.waterMark = true;
                    if (xmlNode.SelectSingleNode("waterMark") != null)
                        webSiteConfig1.waterMark = bool.Parse(xmlNode.SelectSingleNode("waterMark").InnerText.Trim());

                    webSiteConfig1.hideMap = false;
                    if (xmlNode.SelectSingleNode("hideMap") != null)
                        webSiteConfig1.hideMap = bool.Parse(xmlNode.SelectSingleNode("hideMap").InnerText.Trim());

                    break;
                }
            }

            XmlNode xmlNodeProject = doc.SelectSingleNode("configuration/project");
            if (xmlNodeProject != null)
            {
                webSiteConfig1.project = xmlNodeProject.Attributes["url"].Value;
            }
            #endregion

            #region targetGeometry           
            XmlNode xmlNodeViewpoint = doc.SelectSingleNode(@"/configuration/map");
            string targetGeometry = "";
            targetGeometry = xmlNodeViewpoint.Attributes["initialextent"].Value;
            if (!string.IsNullOrEmpty(targetGeometry))
            {
                string[] mapXY = targetGeometry.Split(' ');
                webSiteConfig1.mapsettings.viewpoint.targetGeometry = new TargetGeometry()
                {
                    xmin = Convert.ToDouble(mapXY[0]),
                    ymin = Convert.ToDouble(mapXY[1]),
                    xmax = Convert.ToDouble(mapXY[2]),
                    ymax = Convert.ToDouble(mapXY[3])
                };
            }
            #endregion

            #region areasettings
            XmlNode areasettingsNodes = doc.SelectSingleNode(@"/configuration/areasettings");
            if (areasettingsNodes != null)
            {
                webSiteConfig1.mapsettings.areasettings = new AreaSettings()
                {
                    boundColor = areasettingsNodes.Attributes["boundColor"].Value,
                    boundWidth = areasettingsNodes.Attributes["boundWidth"].Value,
                    backgroundColor = areasettingsNodes.Attributes["backgroundColor"].Value,
                    backgroundOpacity = areasettingsNodes.Attributes["backgroundOpacity"].Value,
                    areaName = areasettingsNodes.Attributes["areaName"].Value,
                    extent = areasettingsNodes.Attributes["extent"] == null ? "" : areasettingsNodes.Attributes["extent"].Value,
                    rings = areasettingsNodes.InnerText
                };
            }
            if (string.IsNullOrEmpty(departID) && !string.IsNullOrEmpty(token))
            {
                List<Flow_Groups> flow_Groups = await _groupRepository.GetListAsync(new Q_Group() { type = 1, Include = true, token = token });
                departID = (flow_Groups.FirstOrDefault()?.机构ID ?? 0).ToString();
            }
            if (!string.IsNullOrEmpty(departID))
            {
                // 机构有设置自定义复位范围，则用机构自定义配置覆盖通用配置
                List<Sys_Map_ResetRangeConfig> sys_Map_ResetRanges = await _sysMapSetRepository.GetListAsync(new Q_SysMapSet() { groupID = Convert.ToInt32(departID) });
                string _areaName = sys_Map_ResetRanges.FirstOrDefault()?.AreeName ?? "";
                string _extent = sys_Map_ResetRanges.FirstOrDefault()?.MapRange ?? "";

                if (!string.IsNullOrEmpty(_areaName))
                {
                    webSiteConfig1.mapsettings.areasettings.areaName = _areaName;
                }
                if (!string.IsNullOrEmpty(_extent))
                {
                    webSiteConfig1.mapsettings.areasettings.extent = _extent;
                }
            }
            #endregion

            if (!File.Exists(maplayerPath))
            {
                // 从原有的配置读取
                FromWebsiteConfig(webSiteConfig1, doc);
            }
            else
            {
                // 读取新版本配置文件 maplayer.json
              await FromMapLayer(webSiteConfig1, maplayerPath, token, client);
            }

            string sql;           

            List<Flow_Groups> groups = await _groupRepository.GetListAsync(new Q_Group() { type = 2, notEqualNames = new List<string>() { "站点_", "地图_" }, Include = true, token = token });
            List<SysMenu> menu = _menuRepository.GetList(new Q_Menu() { visible = client, isInclude = true });
            menu = menu.FindAll(x => x.Id0 != 0);
            groups = groups.FindAll(x => x.编码 != "");
            List<SysMenu> menuGroups = new List<SysMenu>();

            foreach(SysMenu menu1 in menu)
            {
                foreach(SysPurview s in menu1.Syspurviews)
                {
                    foreach (Flow_Groups groups1 in groups)
                    {
                        if (s.Rolecode.Contains(groups1.编码))
                            menuGroups.Add(menu1);
                    }
                }               
            }

            menuGroups = menuGroups.Distinct().OrderBy(x => x.Parentid).OrderBy(x => x.Orderid).ToList();

            int k = 0;

            if (webSiteConfig1.mode == "integration")
            {
                List<SysMenu> dtP = _menuRepository.GetList(new Q_Menu() { visible = client, parentIdEquals = -1 }).OrderBy(x=> x.Parentid).OrderBy(x => x.Orderid).ToList();
                List<SysMenu> drWigets = menuGroups.FindAll(x => x.Parentid > -2);//筛选出功能菜单
                for (int i = 0; i < dtP.Count; i++)
                {
                    Widgets group = new Widgets();

                    if (dtP[i].Pageurl.StartsWith("href:"))//子站
                    {
                        group.icon = dtP[i].Defaultimgurl;
                        group.label = dtP[i].Nodename;
                        group.url = dtP[i].Pageurl;

                        if (group.widgets.Count == 0)
                            group.widgets = null;
                        else
                            group.url = null;

                        if (!string.IsNullOrWhiteSpace(group.url) && string.IsNullOrWhiteSpace(group.product))
                            group.product = "civweb4";

                        webSiteConfig1.widgets.Add(group);
                        continue;
                    }

                    for (int j = 0; j < menuGroups.Count; j++)//查询具有关联关系的子站 菜单 菜单组
                    {
                        if (menuGroups[j].Parentid.ToString() == dtP[i].Nodeid.ToString())//菜单组
                        {
                            group.icon = dtP[i].Defaultimgurl;
                            group.label = dtP[i].Nodename;
                            group.url = null;
                            group.widgets.AddRange(GetMenuItem(dtP[i].Nodeid.ToString(), ref k, menuGroups, webSiteConfig1.client, drWigets));
                            webSiteConfig1.widgets.Add(group);
                            break;
                        }
                        else if (menuGroups[j].Nodeid.ToString() == dtP[i].Nodeid.ToString())//根节点下的功能菜单
                        {
                            group.icon = menuGroups[j].Defaultimgurl;
                            group.label = menuGroups[j].Nodename;
                            group.url = menuGroups[j].Pageurl;
                            group.config = menuGroups[j].Config;
                            group.widgets = null;

                            if (!string.IsNullOrWhiteSpace(group.url) && string.IsNullOrWhiteSpace(group.product))
                                group.product = "civweb4";
                            webSiteConfig1.widgets.Add(group);
                            break;
                        }
                    }
                }

                #region UIWigets
                menuGroups = _menuRepository.GetList(new Q_Menu() { visible = client, parentIdEquals = -2}).OrderBy(x => x.Orderid).ToList();
                for (int i = 0; i < menuGroups.Count; i++)
                {
                    UIWigets item = new UIWigets();
                    item.label = menuGroups[i].Nodename;
                    item.url = menuGroups[i].Pageurl.Substring("href:".Length);
                    item.config = menuGroups[i].Config;

                    if (menuGroups[i].Left != null && menuGroups[i].Left.HasValue)
                        item.left = menuGroups[i].Left.Value.ToString();
                    else
                        item.left = null;

                    if (menuGroups[i].Top != null && menuGroups[i].Top.HasValue)
                        item.top = menuGroups[i].Top.Value.ToString();
                    else
                        item.top = null;

                    if (menuGroups[i].Right != null && menuGroups[i].Right.HasValue)
                        item.right = menuGroups[i].Right.Value.ToString();
                    else
                        item.right = null;

                    if (menuGroups[i].Bottom != null && menuGroups[i].Bottom.HasValue)
                        item.bottom = menuGroups[i].Bottom.Value.ToString();
                    else
                        item.bottom = null;

                    webSiteConfig1.uiwidgets.Add(item);
                }
                #endregion
            }
            else
            {
                List<SysMenu> drWigets = menuGroups.FindAll(x => x.Parentid > -2);//筛选出功能菜单
                List<SysMenu> dr = menuGroups.FindAll(x => x.Parentid == -2);//地图组件

                #region Wigets

                if (drWigets != null)
                {
                    menuGroups = _menuRepository.GetList(new Q_Menu() { visible = client }).OrderBy(x => x.Orderid).ToList();

                    for (int i = 0; i < menuGroups.Count; i++)
                    {
                        if (menuGroups[i].Parentid.ToString() == "-1")
                        {
                            Widgets group = new Widgets();
                            group.icon = menuGroups[i].Defaultimgurl;
                            group.label = menuGroups[i].Nodename;
                            group.url = menuGroups[i].Pageurl;

                            group.shortName = menuGroups[i].Nodeshortname;

                            if (!string.IsNullOrWhiteSpace(group.url) && string.IsNullOrWhiteSpace(group.product))
                                group.product = "civweb4";

                            group.widgets.AddRange(GetMenuItem(menuGroups[i].Nodeid.ToString(), ref k, menuGroups, webSiteConfig1.client, drWigets));

                            if (!string.IsNullOrEmpty(group.url))
                            {
                                group.config = menuGroups[i].Config;
                            }

                            if (group.widgets.Count == 0)
                            {
                                group.widgets = null;

                                bool isexists = false;
                                for (int j = 0; j < drWigets.Count; j++)
                                {
                                    if (menuGroups[i].Nodeid.ToString() == drWigets[j].Nodeid.ToString())
                                    {
                                        isexists = true;
                                        break;
                                    }
                                }

                                if (!isexists)
                                    continue;
                            }
                            else
                                group.url = null;

                            webSiteConfig1.widgets.Add(group);
                        }
                    }
                }

                #endregion

                #region UIWigets          
                if (dr != null)
                {
                    for (int i = 0; i < dr.Count; i++)
                    {
                        UIWigets item = new UIWigets();
                        item.label = dr[i].Nodename;
                        item.url = dr[i].Pageurl.Substring("href:".Length);
                        item.config = dr[i].Config;

                        if (dr[i].Left != null && dr[i].Left.HasValue)
                            item.left = dr[i].Left.Value.ToString();
                        else
                            item.left = null;

                        if (dr[i].Top != null && dr[i].Top.HasValue)
                            item.top = dr[i].Top.Value.ToString();
                        else
                            item.top = null;

                        if (dr[i].Right != null && dr[i].Right.HasValue)
                            item.right = dr[i].Right.Value.ToString();
                        else
                            item.right = null;

                        if (dr[i].Bottom != null && dr[i].Bottom.HasValue)
                            item.bottom = dr[i].Bottom.Value.ToString();
                        else
                            item.bottom = null;

                        webSiteConfig1.uiwidgets.Add(item);
                    }
                }
                #endregion
            }

            return webSiteConfig1;
        }

        private static void FromWebsiteConfig(WebSiteConfig webSiteConfig1, XmlDocument doc)
        {
            #region Basemaps、BaseLayers
            XmlNodeList basemapNodes = doc.SelectNodes(@"/configuration/map/basemaps/layer");
            foreach (XmlNode basemapNode in basemapNodes)
            {
                Basemaps basemap = new Basemaps();
                basemap.id = basemapNode.Attributes["servicename"].Value;
                basemap.title = basemapNode.Attributes["label"].Value;
                basemap.thumbnailUrl = basemapNode.Attributes["icon"].Value;

                BaseLayers baseLayers = new BaseLayers();
                baseLayers.title = basemapNode.Attributes["label"].Value;
                baseLayers.icon = "";
                baseLayers.layerType = basemapNode.Attributes["type"].Value;
                if (string.IsNullOrEmpty(basemapNode.Attributes["url"].Value))
                {
                    basemap.id = basemapNode.Attributes["label"].Value;
                    baseLayers.url = basemapNode.Attributes["url"].Value;
                    if (basemapNode.Attributes["style"] != null)
                        baseLayers.style = basemapNode.Attributes["style"].Value;
                }
                else
                {
                    baseLayers.url = basemapNode.Attributes["url"].Value.Substring("http://{IP}/".Length);
                }
                baseLayers.opacity = Convert.ToDouble(basemapNode.Attributes["alpha"].Value);
                baseLayers.visible = Convert.ToBoolean(basemapNode.Attributes["visible"].Value);

                baseLayers.useProxy = false;
                baseLayers.proxyUrl = "";
                baseLayers.baseLayer = "";
                baseLayers.extent = "";
                baseLayers.levelStart = "";
                baseLayers.levelEnd = "";

                try
                {
                    if (!string.IsNullOrEmpty(basemapNode.Attributes["baseLayer"].Value))
                    {
                        baseLayers.baseLayer = basemapNode.Attributes["baseLayer"].Value;
                        baseLayers.proxyUrl = basemapNode.Attributes["proxyUrl"].Value;
                        baseLayers.levelStart = basemapNode.Attributes["levelStart"].Value;
                        baseLayers.levelEnd = basemapNode.Attributes["levelEnd"].Value;
                        baseLayers.resolution = basemapNode.Attributes["resolution"].Value;
                        baseLayers.origin = basemapNode.Attributes["origin"].Value;
                        baseLayers.tileMatrix = basemapNode.Attributes["tileMatrix"].Value;
                    }

                    if (!string.IsNullOrEmpty(basemapNode.Attributes["extent"].Value))
                    {
                        baseLayers.extent = basemapNode.Attributes["extent"].Value;
                    }
                }
                catch
                {

                }

                basemap.baseLayers.Add(baseLayers);
                webSiteConfig1.mapsettings.basemaps.Add(basemap);
            }
            #endregion

            #region Layers
            XmlNodeList layersNodes = doc.SelectNodes(@"/configuration/map/operationallayers/layer");
            foreach (XmlNode layerNode in layersNodes)
            {
                Layers layer = new Layers
                {
                    id = layerNode.Attributes["servicename"].Value,
                    title = layerNode.Attributes["label"].Value,
                    icon = "",
                    layerType = layerNode.Attributes["type"].Value
                };

                if (layerNode.Attributes["type"].Value == "civtiled")
                    layer.layerType = "MapImageLayer";

                if (layerNode.Attributes["type"].Value == "pipenet")
                    layer.layerType = "PipenetLayer";

                layer.url = layerNode.Attributes["url"].Value.Substring("http://{IP}/".Length);
                layer.opacity = Convert.ToDouble(layerNode.Attributes["alpha"].Value);
                layer.showLegend = true;
                layer.visible = Convert.ToBoolean(layerNode.Attributes["visible"].Value);
                layer.useProxy = true;
                layer.proxyUrl = "";

                if (layerNode.Attributes["baseLayer"] != null)
                    layer.baseLayer = layerNode.Attributes["baseLayer"].Value;

                if (layerNode.Attributes["levelStart"] != null)
                    layer.levelStart = layerNode.Attributes["levelStart"].Value;

                if (layerNode.Attributes["levelEnd"] != null)
                    layer.levelEnd = layerNode.Attributes["levelEnd"].Value;

                if (layerNode.Attributes["resolution"] != null)
                    layer.resolution = layerNode.Attributes["resolution"].Value;

                if (layerNode.Attributes["origin"] != null)
                    layer.resolution = layerNode.Attributes["origin"].Value;

                if (layerNode.Attributes["tileMatrix"] != null)
                    layer.tileMatrix = layerNode.Attributes["tileMatrix"].Value;

                if (layerNode.Attributes["extent"] != null)
                    layer.extent = layerNode.Attributes["extent"].Value;

                if (layerNode.Attributes["wmtsUrl"] != null)
                    layer.wmtsUrl = layerNode.Attributes["wmtsUrl"].Value;

                webSiteConfig1.mapsettings.layers.Add(layer);
            }
            #endregion
        }

        private async Task FromMapLayer(WebSiteConfig webSiteConfig1, string maplayerPath, string token, string client)
        {
            JObject maplayer = null;
            using (StreamReader file = File.OpenText(maplayerPath))
            {
                JsonTextReader reader = new JsonTextReader(file);
                maplayer = (JObject)JToken.ReadFrom(reader);
            }

            try
            {
                ProcessBasemaps();
                ProcessScheme();

                List<string> curUserRoles = new List<string>();
                if (!string.IsNullOrEmpty(token))
                {
                    List<Flow_Groups> flow_Groups = await _groupRepository.GetListAsync(new Q_Group() { type = 2, Include = true, token = token });

                    if(flow_Groups.Count > 0)
                    {
                        foreach(Flow_Groups item in flow_Groups)
                        {
                            curUserRoles.Add(item.机构ID.ToString());
                        }
                    }
                }

                // 非沙盒模式过滤一遍返回的 <方案> 数据
                if (client != "sandbox")
                {
                    var layers = webSiteConfig1.mapsettings.layers;
                    List<int> priority = new List<int>(layers.Count);
                    for (int i = 0; i < layers.Count; i++)
                    {
                        priority.Add(0);

                        string roles = layers[i].roles;
                        if (string.IsNullOrEmpty(roles))
                        {
                            // 没关联角色, 当作 "公共方案(所有人都可以用)" 处理.
                            priority[i] |= 1;
                        }
                        else
                        {
                            List<string> roleArr = roles.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList();
                            IEnumerable<string> intersects = curUserRoles.Intersect(roleArr);
                            if (intersects.Count() > 0)
                            {
                                priority[i] |= 1;
                            }
                            else
                            {
                                continue;
                            }
                        }

                        // 方案包含管网
                        if (!string.IsNullOrEmpty(layers[i].id) && !string.IsNullOrEmpty(layers[i].url))
                        {
                            priority[i] |= 2;
                        }

                        if (layers[i].layerType == "dynamic")
                        {
                            priority[i] |= 4;
                        }
                        else if (layers[i].layerType == "PipenetLayer")
                        {
                            priority[i] |= 8;
                        }
                    }

                    List<Layers> sortedLayers = new List<Layers>();
                    int curMax = 0;
                    // 根据计算出的优先级, 过滤并将优先级最高的放首位
                    for (int i = 0; i < priority.Count; i++)
                    {
                        if (priority[i] < 1)
                            continue;

                        if (priority[i] >= curMax)
                        {
                            curMax = priority[i];
                            sortedLayers.Insert(0, layers[i]);
                        }
                        else
                        {
                            sortedLayers.Add(layers[i]);
                        }
                    }

                    webSiteConfig1.mapsettings.layers = sortedLayers;
                }
            }
            catch (Exception)
            {
            }

            void ProcessBasemaps()
            {
                var baseMap = maplayer?["general"]?["baseMap"]?["layers"];
                if (baseMap == null)
                    throw new Exception("maplayer.json文件节点被修改");

                foreach (var item in baseMap)
                {
                    string servicename = item["servicename"]?.ToString();
                    string label = (((JValue)item["label"])?.Value ?? ((JValue)item["servicename"])?.Value)?.ToString();
                    Basemaps basemap = new Basemaps
                    {
                        id = servicename,
                        title = label,
                        thumbnailUrl = item["icon"]?.ToString()
                    };

                    BaseLayers baseLayers = new BaseLayers
                    {
                        title = label,
                        icon = "",
                        layerType = item["type"]?.ToString()
                    };
                    if (string.IsNullOrEmpty(item["url"]?.ToString()))
                    {
                        basemap.id = label;
                        baseLayers.url = item["url"]?.ToString();
                        if (item["style"] != null)
                            baseLayers.style = item["style"]?.ToString();
                    }
                    else
                    {
                        string url = item["url"]?.ToString();
                        if (url.Length > 12)
                        {
                            baseLayers.url = url.Substring("http://{IP}/".Length);
                        }
                    }

                    bool isValidAlpha = Double.TryParse(item["alpha"]?.ToString(), out double op);
                    baseLayers.opacity = isValidAlpha ? op : 1;
                    Boolean.TryParse(item["visible"]?.ToString(), out bool vi);
                    baseLayers.visible = vi;

                    baseLayers.useProxy = false;
                    baseLayers.proxyUrl = "";
                    baseLayers.baseLayer = "";
                    baseLayers.extent = "";
                    baseLayers.levelStart = "";
                    baseLayers.levelEnd = "";

                    if (!string.IsNullOrEmpty(item?["baseLayer"]?.ToString()))
                    {
                        baseLayers.baseLayer = item["baseLayer"]?.ToString();
                        baseLayers.proxyUrl = item["proxyUrl"]?.ToString();
                        baseLayers.levelStart = item["levelStart"]?.ToString();
                        baseLayers.levelEnd = item["levelEnd"]?.ToString();
                        baseLayers.resolution = item["resolution"]?.ToString();
                        baseLayers.origin = item["origin"]?.ToString();
                        baseLayers.tileMatrix = item["tileMatrix"]?.ToString();
                    }

                    if (!string.IsNullOrEmpty(item?["extent"]?.ToString()))
                    {
                        baseLayers.extent = item["extent"]?.ToString();
                    }

                    if (item?["type"].ToString() == "google-user")
                    {
                        baseLayers.extent = item?["extent"].ToString();
                        baseLayers.baseLayer = item?["baseLayer"].ToString();
                        baseLayers.proxyUrl = item?["proxyUrl"].ToString();
                        baseLayers.levelStart = item?["levelStart"].ToString();
                        baseLayers.levelEnd = item?["levelEnd"].ToString();
                        baseLayers.origin = item?["origin"].ToString();
                        baseLayers.resolution = item?["resolution"].ToString();
                        baseLayers.tileMatrix = item?["tileMatrix"].ToString();
                    }

                    basemap.baseLayers.Add(baseLayers);
                    webSiteConfig1.mapsettings.basemaps.Add(basemap);
                }
            }

            void ProcessScheme()
            {
                var optionalLayer = maplayer?["specific"]?["web"]?["optionalLayer"]?["layers"];
                if (optionalLayer == null)
                    throw new Exception("maplayer.json文件节点被修改");

                foreach (var item in optionalLayer)
                {
                    Layers layer = new Layers
                    {
                        id = item["servicename"].ToString(),
                        title = item["label"].ToString(),
                        icon = "",
                        layerType = item["type"].ToString()
                    };

                    if (item["type"].ToString() == "civtiled")
                        layer.layerType = "MapImageLayer";

                    if (item["type"].ToString() == "pipenet")
                        layer.layerType = "PipenetLayer";

                    string tmpUrl = item["url"].ToString();
                    layer.url = (string.IsNullOrEmpty(tmpUrl) || tmpUrl.Length < 13) ? tmpUrl : tmpUrl.Substring("http://{IP}/".Length);
                    string tmpAlpha = item["alpha"].ToString();
                    if (!string.IsNullOrEmpty(tmpAlpha))
                    {
                        layer.opacity = Convert.ToDouble(item["alpha"].ToString());
                    }
                    layer.showLegend = true;
                    layer.visible = Convert.ToBoolean(item["visible"].ToString());
                    layer.useProxy = true;
                    layer.proxyUrl = "";

                    if (item["baseLayer"] != null)
                        layer.baseLayer = item["baseLayer"].ToString();

                    if (item["levelStart"] != null)
                        layer.levelStart = item["levelStart"].ToString();

                    if (item["resolution"] != null)
                        layer.resolution = item["resolution"].ToString();

                    if (item["origin"] != null)
                        layer.resolution = item["origin"].ToString();

                    if (item["tileMatrix"] != null)
                        layer.tileMatrix = item["tileMatrix"].ToString();

                    if (item["extent"] != null)
                        layer.extent = item["extent"].ToString();

                    if (item["wmtsUrl"] != null)
                        layer.wmtsUrl = item["wmtsUrl"].ToString();

                    if (item["schemename"] != null)
                        layer.schemename = item["schemename"].ToString();

                    if (item["roles"] != null)
                        layer.roles = item["roles"].ToString();

                    if (item["areaName"] != null)
                        layer.areaName = item["areaName"].ToString();
                    if (string.IsNullOrEmpty(layer.areaName))
                    {
                        layer.areaName = webSiteConfig1.mapsettings.areasettings.areaName;
                    }

                    if (item["boundColor"] != null)
                        layer.boundColor = item["boundColor"].ToString();
                    if (string.IsNullOrEmpty(layer.boundColor))
                    {
                        layer.boundColor = webSiteConfig1.mapsettings.areasettings.boundColor;
                    }

                    if (item["backgroundColor"] != null)
                        layer.backgroundColor = item["backgroundColor"].ToString();
                    if (string.IsNullOrEmpty(layer.backgroundColor))
                    {
                        layer.backgroundColor = webSiteConfig1.mapsettings.areasettings.backgroundColor;
                    }

                    if (item["boundWidth"] != null)
                        layer.boundWidth = item["boundWidth"].ToString();
                    if (string.IsNullOrEmpty(layer.boundWidth))
                    {
                        layer.boundWidth = webSiteConfig1.mapsettings.areasettings.boundWidth;
                    }

                    if (item["backgroundOpacity"] != null)
                        layer.backgroundOpacity = item["backgroundOpacity"].ToString();
                    if (string.IsNullOrEmpty(layer.backgroundOpacity))
                    {
                        layer.backgroundOpacity = webSiteConfig1.mapsettings.areasettings.backgroundOpacity;
                    }

                    // 有方案的版本. layers 当方案使用, 可以包含底图信息
                    if (!string.IsNullOrEmpty(layer.schemename))
                    {
                        var schemes = maplayer?["specific"]?["scheme"]?["optionalLayer"]?["layers"];
                        if (schemes != null)
                        {
                            foreach (var it in schemes)
                            {
                                if (it["schemename"].ToString() != layer.schemename)
                                {
                                    continue;
                                }

                                int i = -1;
                                foreach (var bm in it?["baseMap"])
                                {
                                    i++;
                                    Basemaps bms = webSiteConfig1.mapsettings.basemaps.Find(b => b.id == bm.ToString());
                                    if (bms == null)
                                    {
                                        continue;
                                    }

                                    if (it["defaultBaseMap"].ToString() == i.ToString())
                                    {
                                        layer.basemaps.Insert(0, bms);
                                    }
                                    else
                                    {
                                        layer.basemaps.Add(bms);
                                    }
                                }
                            }
                        }
                    }

                    webSiteConfig1.mapsettings.layers.Add(layer);
                }
            }
        }

        private List<Widgets> GetMenuItem(string nodeId, ref int k, List<SysMenu> menuGroups, string client, List<SysMenu> dataRow)
        {
            List<Widgets> result = new List<Widgets>();
            for (int i = 0; i < menuGroups.Count; i++)
            {
                if (nodeId == menuGroups[i].Parentid.ToString())
                {
                    Widgets group = new Widgets();
                    group.icon = menuGroups[i].Defaultimgurl;
                    group.label = menuGroups[i].Nodename;
                    group.url = menuGroups[i].Pageurl;
                    group.product = menuGroups[i].Product;
                    if (string.IsNullOrWhiteSpace(group.product)) 
                        group.product = "civweb4";

                    int index = group.url.IndexOf("http");
                    if(index <= -1)
                    {
                        if (group.url.Contains('|'))
                            group.url += $"&widget={++k}";
                        else
                            group.url += $"|widget={++k}";
                    }

                    group.shortName = menuGroups[i].Nodeshortname;

                    group.widgets.AddRange(GetMenuItem(menuGroups[i].Nodeid.ToString(), ref k, menuGroups, client, dataRow));

                    if (group.widgets.Count == 0)
                    {
                        group.widgets = null;
                        group.config = menuGroups[i].Config;

                        bool isexists = false;
                        for (int j = 0; j < dataRow.Count; j++)//判断根节点，跳出循环
                        {
                            if (menuGroups[i].Nodeid.ToString() == dataRow[j].Nodeid.ToString())
                            {
                                isexists = true;
                                break;
                            }
                        }

                        if (!isexists)
                            continue;
                    }
                    else
                        group.url = null;

                    result.Add(group);
                }
            }

            return result;
        }
        #endregion
    }
}
