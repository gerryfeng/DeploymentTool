using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using OMS.ApplicationCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;
using System.Xml;

namespace OMS.Web
{
    /// <summary>
    /// 平台中心
    /// </summary>
    public class PlatformCenterController:BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly ISysMenuService _menuService;
        private readonly IFlowGroupService _groupService;
        private readonly IWebHostEnvironment _environment;

        public PlatformCenterController(IMapper mapper, ISysMenuService menuService, IFlowGroupService groupService, IWebHostEnvironment environment)
        {
            _mapper = mapper;
            _menuService = menuService;
            _groupService = groupService;
            _environment = environment;
        }

        #region 网站配置
        /// <summary>
        /// 获取小程序配置，网站配置和菜单树
        /// </summary>
        /// <param name="userMode">登录模式</param>
        /// <remarks>
        /// userMode 必填  super 或 admin 或common
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<Web4ModuleTreeItem>> MiniAppModuleTree(
            [Required] string userMode)
        {
            List<Web4ModuleTreeItem> moduleTreeItems = new List<Web4ModuleTreeItem>();

            ConfigBridge.ConfigBridge config = new ConfigBridge.ConfigBridge(_environment.IsDevelopment());
            XmlDocument doc = config.GetWebXml();

            if (userMode == "admin" || userMode == "super")
            {
                Web4ModuleTreeItem item6 = new Web4ModuleTreeItem
                {
                    id = "MiniAppSite",
                    text = "小程序网站",
                    leaf = false,
                    iconCls = "civ-flag-blue",
                    clickType = "MiniAppSingleStationRoot",
                    menuType = "MiniAppSingleStationRoot",
                    children = await _menuService.MobilGetMiniAppListAsync("single", doc),
                    allowDrag = false,
                    allowDrop = true,
                    draggable = false,
                    isTarget = true,
                    expanded = false
                };
                if (item6.children.Count == 0)
                    item6.leaf = true;
                moduleTreeItems.Add(item6);
            }
            else if (userMode == "common")
            {
                Web4ModuleTreeItem item4 = new Web4ModuleTreeItem
                {
                    id = "MiniAppSite",
                    text = "小程序网站",
                    leaf = false,
                    iconCls = "civ-flag-blue",
                    clickType = "MiniAppSingleStationRoot",
                    menuType = "MiniAppSingleStationRoot",
                    expanded = false,
                    allowDrag = false,
                    allowDrop = true,
                    draggable = false,
                    isTarget = true
                };
                if (item4.children.Count == 0)
                    item4.leaf = true;
                item4.children = await  _menuService.MobilGetMiniAppListAsync("single", doc);
                moduleTreeItems.Add(item4);
            }
            return moduleTreeItems;
        }


        /// <summary>
        /// web配置
        /// </summary>
        /// <param name="userMode">登录模式</param>
        /// <remarks>
        /// userMode 必填  super 或 admin 或common
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<Web4ModuleTreeItem>> WebModuleTree(
            [Required] string userMode)
        {
            List < Web4ModuleTreeItem > moduleTreeItems = new List<Web4ModuleTreeItem>();
            ConfigBridge.ConfigBridge config = new ConfigBridge.ConfigBridge(_environment.IsDevelopment());
            XmlDocument doc = config.GetWebXml();

            if (userMode == "admin" || userMode == "super")
            {
                Web4ModuleTreeItem item3 = new Web4ModuleTreeItem
                {
                    id = "Web4IntegrateStation",
                    text = "集成网站",
                    leaf = false,
                    iconCls = "civ-flag-red",
                    clickType = "Web4IntegrationStationRoot",
                    menuType = "Web4IntegrationStationRoot",
                    children = await _menuService.Web4GetICStationListAsync("integration", doc),
                    expanded = false
                };
                if (item3.children.Count == 0)
                    item3.leaf = true;
                moduleTreeItems.Add(item3);

                Web4ModuleTreeItem item6 = new Web4ModuleTreeItem
                {
                    id = "Web4SingleStation",
                    text = "一般网站",
                    leaf = false,
                    iconCls = "civ-flag-blue",
                    clickType = "Web4SingleStationRoot",
                    menuType = "Web4SingleStationRoot",
                    children = await _menuService.Web4GetICStationListAsync("single", doc),
                    allowDrag = false,
                    allowDrop = true,
                    draggable = false,
                    isTarget = true,
                    expanded = false
                };
                if (item6.children.Count == 0)
                    item6.leaf = true;
                moduleTreeItems.Add(item6);
            }
            else if (userMode == "common")
            {
                Web4ModuleTreeItem item3 = new Web4ModuleTreeItem
                {
                    id = "Web4IntegrateStation",
                    text = "集成网站",
                    leaf = false,
                    iconCls = "civ-flag-red",
                    clickType = "Web4IntegrationStationRoot",
                    menuType = "Web4IntegrationStationRoot",
                    expanded = false
                };
                if (item3.children.Count == 0)
                    item3.leaf = true;
                item3.dragAttribute = "RoleRoot";

                item3.children = await  _menuService.Web4GetICStationListAsync("integration", doc);
                moduleTreeItems.Add(item3);

                Web4ModuleTreeItem item4 = new Web4ModuleTreeItem
                {
                    id = "Web4SingleStation",
                    text = "一般网站",
                    leaf = false,
                    iconCls = "civ-flag-blue",
                    clickType = "Web4SingleStationRoot",
                    menuType = "Web4SingleStationRoot",
                    expanded = false,
                    allowDrag = false,
                    allowDrop = true,
                    draggable = false,
                    isTarget = true
                };
                if (item4.children.Count == 0)
                    item4.leaf = true;
                item4.children = await _menuService.Web4GetICStationListAsync("single", doc);
                moduleTreeItems.Add(item4);
            }
            return moduleTreeItems; ;
        }


        /// <summary>
        /// 获取手持菜单配置
        /// </summary>
        /// <param name="userMode">登录模式</param>
        /// <param name="subSystemValue">菜单类型</param>
        /// <remarks>
        /// userMode 必填  super 或 admin 或common
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<MobileModuleTreeItem>> MobileModuleTree(
            [Required] string userMode,
            [Required] string subSystemValue)
        {
            return await _menuService.GetMobileModuleTreeAsync(userMode, subSystemValue);
        }

        /// <summary>
        /// 角色管理获取应用类别
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public Dictionary<string, string> GetWebConfigTypes()
        {
            ConfigBridge.ConfigBridge config = new ConfigBridge.ConfigBridge(_environment.IsDevelopment());
            XmlDocument doc = config.GetWebXml();

            Dictionary<string, string> dicTitle = new Dictionary<string, string>();
            XmlNodeList websiteList = doc.SelectNodes(@"/configuration/website");
            foreach (XmlNode xmlNode in websiteList)
            {
                if(xmlNode.SelectSingleNode("mode").InnerText.Trim() != "integrate")
                    dicTitle.Add(xmlNode.SelectSingleNode("client").InnerText.Trim(), xmlNode.SelectSingleNode("title").InnerText.Trim());
            }
            XmlNodeList mobileList = doc.SelectNodes(@"/configuration/MiniAPPSite");
            foreach (XmlNode xmlNode in mobileList)
            {
                dicTitle.Add(xmlNode.SelectSingleNode("client").InnerText.Trim(), xmlNode.SelectSingleNode("title").InnerText.Trim());
            }
            dicTitle.Add("手持系统", "手持系统");               
            return dicTitle;          
        }

        /// <summary>
        /// 删除小程序菜单和角色
        /// </summary>
        /// <param name="visible">类型</param>
        /// <returns></returns>
        [HttpGet]
        public async Task DeleteMiniMenu([Required] string visible)
        {
            await _menuService.DeleteMiniMenu(visible);
        }
        #endregion

        #region 系统菜单
        /// <summary>
        /// 获取网站配置信息
        /// </summary>
        /// <param name="client"></param>
        /// <param name="token"></param>
        /// <param name="departID"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<WebSiteConfig>> GetWebSiteConfig([Required] string client, string token, string departID)
        {
            List<WebSiteConfig> configList = new List<WebSiteConfig>();
            ConfigBridge.ConfigBridge config = new ConfigBridge.ConfigBridge(_environment.IsDevelopment());
            XmlDocument doc = config.GetWebXml();
            if(doc is null)
            {
                throw new Exception ("获取信息失败，不存在配置文件");
            }
            string maplayerPath = config.MapLayerPath;
            configList = await _menuService.GetWebSiteConfigAsync(client, token, departID, doc, maplayerPath);
            if (string.IsNullOrEmpty(configList[0].title) && client != "sandbox")
            {
                throw new Exception ("获取信息失败，文件 Web4Config 未找到匹配的client");
            }
            return configList;
        }

        /// <summary>
        /// 获取当前解决方案名称
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public Web4GetSolutionList GetSolutionList()
        {
            var data = new Web4GetSolutionList();
            ConfigBridge.ConfigBridge config = new ConfigBridge.ConfigBridge(_environment.IsDevelopment());
            config.DeserializeConnConfig();
            XmlDocument doc = config.GetWebXml();
            XmlNodeList xmlNodeList = doc.SelectNodes(@"/configuration/website");
            foreach (XmlNode xmlNode in xmlNodeList)
            {
                data.sites.Add(new website()
                {
                    title = xmlNode.SelectSingleNode("title").InnerText.Trim(),
                    product = xmlNode.SelectSingleNode("product") == null ? "": xmlNode.SelectSingleNode("product").InnerText.Trim()
                });
            }
               
            data.currentSolution = config.appconfiguration.solutionname;
            DirectoryInfo dir = new DirectoryInfo(config.ConfCenterPath + @"\");
            foreach (DirectoryInfo dChild in dir.GetDirectories())
            {
                if (!ConfigBridge.OMSPath.solutionNameExclusionList.Contains(dChild.Name) && dChild.Name != "default")
                    data.solutions.Add(dChild.Name);
            }
            return data;
        }
        #endregion
    }
}
