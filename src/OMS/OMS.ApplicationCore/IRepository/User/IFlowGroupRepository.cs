using System.Collections.Generic;
using System.Threading.Tasks;

namespace OMS.ApplicationCore
{
    public interface IFlowGroupRepository : IBaseRepository<Flow_Groups>
    {
        Task<List<Flow_Groups>> GetListAsync(Q_Group where);

        Flow_Groups GetById(int groupId, bool isInclue = false);

        /// <summary>
        /// 通过用户id获取结构id
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        List<Flow_Groups> GetGroupIdByUserId(string userID, string connStr, bool WebGIS = false);

        PagedList<Flow_Groups> GetPagingList(Q_Group where);
    }
}
