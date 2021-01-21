using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml;

namespace OMS.ApplicationCore
{
    public interface ISysMenuService
    {
        #region 网站配置
        /// <summary>
        /// 小程序菜单
        /// </summary>
        /// <param name="websiteType"></param>
        /// <param name="doc"></param>
        /// <returns></returns>
        Task<List<Web4ModuleTreeItem>> MobilGetMiniAppListAsync(string websiteType, XmlDocument doc);

        /// <summary>
        /// 删除小程序菜单和角色
        /// </summary>
        /// <param name="visible"></param>
        /// <returns></returns>
        public Task DeleteMiniMenu(string visible);

        /// <summary>
        /// web菜单
        /// </summary>
        /// <param name="websiteType"></param>
        /// <returns></returns>
        Task<List<Web4ModuleTreeItem>> Web4GetICStationListAsync(string websiteType, XmlDocument doc);

        /// <summary>
        /// 手持系统菜单
        /// </summary>
        /// <param name="userMode"></param>
        /// <param name="subSystemValue"></param>
        /// <returns></returns>
        Task<List<MobileModuleTreeItem>> GetMobileModuleTreeAsync(string userMode, string subSystemValue);

        /// <summary>
        /// 获取网站配置信息
        /// </summary>
        /// <param name="client"></param>
        /// <param name="token"></param>
        /// <param name="departID"></param>
        /// <returns></returns>
        Task<List<WebSiteConfig>> GetWebSiteConfigAsync(string client, string token, string departID, XmlDocument doc, string maplayerPath);
        #endregion
    }
}
