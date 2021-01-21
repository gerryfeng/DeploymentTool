using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Web.DTO;

namespace Web.Repository
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// 添加实体(单个)
        /// </summary>
        /// <param name="entity">实体对象</param>
        int Add(T entity);

        /// <summary>
        /// 批量插入实体(多个)
        /// </summary>
        /// <param name="list">实体列表</param>
        int AddRange(List<T> list);

        /// <summary>
        /// 删除实体(单个)
        /// </summary>
        /// <param name="entity"></param>
        int Remove(T entity);

        /// <summary>
        /// 批量删除实体(多个)
        /// </summary>
        /// <param name="list">实体列表</param>
        int RemoveRange(List<T> list);
        /// <summary>
        /// 获取所有 
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetAll();


        /// <summary>
        /// 获取实体（主键）
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns></returns>
        T GetModelById(object id);
        /// <summary>
        /// 获取实体（条件）
        /// </summary>
        /// <param name="predicate">条件表达式</param>
        /// <returns></returns>
        T GetModel(Expression<Func<T, bool>> predicate);
        /// <summary>
        /// 查询记录数
        /// </summary>
        /// <param name="predicate">条件表达式</param>
        /// <returns>记录数</returns>
        int Count(Expression<Func<T, bool>> predicate);
        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="anyLambda">查询表达式</param>
        /// <returns>布尔值</returns>
        bool Exist(Expression<Func<T, bool>> anyLambda);


        /// <summary>
        ///  分页查询
        /// </summary>
        /// <typeparam name="type"></typeparam>
        /// <param name="pageSize">每页条数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="isAsc">是否升序</param>
        /// <param name="orderByLambda">排序字段</param>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public IQueryable<T> GetModelsByPage<type>(int pageSize, int pageIndex, bool isAsc,
           Expression<Func<T, type>> orderByLambda, Expression<Func<T, bool>> whereLambda);
    }
}
