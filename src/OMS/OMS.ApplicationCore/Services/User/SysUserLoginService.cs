
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OMS.ApplicationCore
{
    public class SysUserLoginService
    {
        private readonly ISysUserLoginRepository _userLoginRepository;

        public SysUserLoginService(ISysUserLoginRepository userLoginRepository)
        {
            _userLoginRepository = userLoginRepository;
        }

        public async Task SaveAsync(SysUserLogin e)
        {
            await _userLoginRepository.AddAsync(e);
        }

        public async Task<List<SysUserLogin>> GetListAsync(Q_Log where)
        {
           return await _userLoginRepository.GetListAsync(where);
        }
    }
}
