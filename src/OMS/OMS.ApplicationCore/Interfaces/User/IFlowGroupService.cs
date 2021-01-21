using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml;

namespace OMS.ApplicationCore
{
    public interface IFlowGroupService 
    {
        Task<GroupUser> GetGroupUser(int groupId);

        /// <summary>
        /// 获取角色列表根据产品分组
        /// </summary>
        /// <param name="userID">用户id</param>
        /// <param name="doc"></param>
        /// <param name="subSystems"></param>
        /// <param name="rootPath">CityWebService跟路径</param>
        /// <param name="connStr"></param>
        /// <param name="WebGIS"></param>
        /// <returns></returns>
        Task<RoleGroupResult> GetUserRelationAsync(string userID, XmlDocument doc, List<SubSystemModel> subSystems, string rootPath, string connStr, bool WebGIS = false);


        /// <summary>
        /// 获取某个机构下所有用户列表
        /// </summary>
        /// <param name="groupId">机构id</param>
        /// <param name="stationId">站点id</param>
        /// <returns></returns>
        Task<List<UserItem>> GetStationUserList(int groupId, int stationId);


        /// <summary>
        /// 获取机构用户分页列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        PagedList<GroupUserModel> GroupUserPagingList(Q_Group where);

    }
}
