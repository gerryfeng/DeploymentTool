
namespace Identity.ApplicationCore
{
    public interface IDBService
    {
        bool ConnectionTest(string ip, string dbName, string userName, string password, out string errMsg);
    }
}
