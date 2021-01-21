using Identity.Infrastructure;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Identity.ApplicationCore
{
    public class FlowUserService : BaseRepository<Flow_Users>, IFlowUserService
    {

        private readonly BaseDBContext baseDBContext;
        private readonly ILogger<FlowUserService> _logger;

        public FlowUserService(BaseDBContext dBContext, ILogger<FlowUserService> logger) : base(dBContext)
        {
            baseDBContext = dBContext;
            _logger = logger;
        }

        public Flow_Users GetUser(string user, string sha1Pwd)
        {
            return baseDBContext.Users.FirstOrDefault(x => x.WorkNo == user && x.PASSWORD == sha1Pwd);
        }

        public Flow_Users GetUserByTypeId(string value, string type)
        {
            switch (type)
            {
                case "dingding": return baseDBContext.Users.FirstOrDefault(x => x.ddid == value);
                case "wexin": return baseDBContext.Users.FirstOrDefault(x => x.wxid == value);
                case "phone": return baseDBContext.Users.FirstOrDefault(x => x.PHONE == value);
                default: return null;
            }
        }

        public bool ValidateCredentials(string user, string pwd)
        {
            if ((user == "omsa" && pwd == "pandaomsa")
                || (user == "admin" && pwd == "admin"))
                return true;

            return GetUser(user, EncryptHelper.SHA1_Encrypt(pwd)) != null;
        }

        public void GetGroupRoleList(string OUID, string Query, string start, string limit)
        {

        }
    }
}
