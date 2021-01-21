
namespace Identity.ApplicationCore
{
    public interface IFlowUserService : IBaseRepository<Flow_Users>
    {

        Flow_Users GetUserByTypeId(string value, string type);
        Flow_Users GetUser(string name, string pwd);

        public bool ValidateCredentials(string name, string pwd);

        void GetGroupRoleList(string OUID, string Query, string start, string limit);
    }
}
