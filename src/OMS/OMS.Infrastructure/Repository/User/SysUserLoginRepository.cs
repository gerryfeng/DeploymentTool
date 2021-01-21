using Microsoft.EntityFrameworkCore;
using OMS.ApplicationCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMS.Infrastructure
{
    public class SysUserLoginRepository :BaseRepository<SysUserLogin>, ISysUserLoginRepository
    {

        private readonly BaseDBContext _dbContext;

        public SysUserLoginRepository(BaseDBContext dBContext) :base(dBContext)
        {
            _dbContext = dBContext;
        }

        public async Task<List<SysUserLogin>> GetListAsync(Q_Log where)
        {
            return await Query(where).OrderByDescending(x => x.LoginTime).ToListAsync();
        }

        public PagedList<SysUserLogin> GetPagedList(Q_Log where)
        {
            return new PagedList<SysUserLogin>(Query(where).OrderByDescending(x => x.LoginTime), where.PageIndex, where.PageSize);
        }

        public IQueryable<SysUserLogin> Query(Q_Log where)
        {
            IQueryable<SysUserLogin> query = _dbContext.SysUserLogin.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(where.DateFrom))
                query = query.Where(x => x.LoginTime >= DateTime.Parse(where.DateFrom));

            if (!string.IsNullOrWhiteSpace(where.DateTo))
                query = query.Where(x => x.LoginTime <= DateTime.Parse(where.DateTo));

            if (!string.IsNullOrWhiteSpace(where.IP))
                query = query.Where(x => x.IP == where.IP);

            if (!string.IsNullOrWhiteSpace(where.LoginName))
                query = query.Where(x => x.LoginName == where.LoginName);

            if (!string.IsNullOrWhiteSpace(where.UserName))
                query = query.Where(x => x.ShowName == where.UserName);


            return query;
        }
    }
}
