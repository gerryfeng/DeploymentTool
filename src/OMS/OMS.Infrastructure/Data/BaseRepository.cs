using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OMS.Infrastructure
{
    public class BaseRepository<T> where T : class
    {
        private readonly BaseDBContext _dbContext;
        private DbSet<T> _entity;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbContext"></param>
        public BaseRepository(BaseDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        private DbSet<T> Entity => _entity ?? (_entity = _dbContext.Set<T>());

        /// <summary>
        /// 添加实体(单个)
        /// </summary>
        /// <param name="entity">实体对象</param>
        public async Task<int> AddAsync(T entity)
        {
            await Entity.AddAsync(entity);
            return await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// 修改实体(单个)
        /// </summary>
        /// <param name="entity">实体对象</param>
        public int Update(T entity)
        {
            Entity.Update(entity);
            return  _dbContext.SaveChanges();
        }

        /// <summary>
        /// 修改实体(多个)
        /// </summary>
        /// <param name="entity">实体对象</param>
        public int Update(List<T> list)
        {
            Entity.UpdateRange(list);
            return _dbContext.SaveChanges();
        }

        /// <summary>
        /// 批量插入实体(多个)
        /// </summary>
        /// <param name="list">实体列表</param>
        public async Task<int> AddRangeAsync(List<T> list)
        {
            await Entity.AddRangeAsync(list);
            return await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// 删除实体(单个)
        /// </summary>
        /// <param name="entity"></param>
        public int Remove(T entity)
        {
            Entity.Remove(entity);
            return _dbContext.SaveChanges();
        }

        /// <summary>
        /// 批量删除实体(多个)
        /// </summary>
        /// <param name="list">实体列表</param>
        public int RemoveRange(List<T> list)
        {
            Entity.RemoveRange(list);
            return _dbContext.SaveChanges();
        }

        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GetAll()
        {
            return Entity.AsQueryable().AsNoTracking();
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns></returns>
        public T GetModelById(object id)
        {
            return Entity.Find(id);
        }

        /// <summary>
        /// 获取实体（条件）
        /// </summary>
        /// <param name="predicate">条件表达式</param>
        /// <returns></returns>
        public T GetModel(Expression<Func<T, bool>> predicate)
        {
            return Entity.FirstOrDefault(predicate);
        }

        /// <summary>
        /// 查询记录数
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public int Count(Expression<Func<T, bool>> predicate)
        {
            return predicate != null ? Entity.Where(predicate).Count() : Entity.Count();
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="anyLambda"></param>
        /// <returns></returns>
        public bool Exist(Expression<Func<T, bool>> anyLambda)
        {
            return Entity.Any(anyLambda);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="type"></typeparam>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="isAsc">是否排序</param>
        /// <param name="orderByLambda"></param>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public IQueryable<T> GetModelsByPage<type>(int pageSize, int pageIndex, bool isAsc,
           Expression<Func<T, type>> orderByLambda, Expression<Func<T, bool>> whereLambda)
        {
            //是否升序
            if (isAsc)
            {
                return _dbContext.Set<T>().Where(whereLambda).OrderBy(orderByLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            else
            {
                return _dbContext.Set<T>().Where(whereLambda).OrderByDescending(orderByLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
        }
    }
}
