using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OMS.ApplicationCore
{
    [Serializable]
    public class PagedList<T>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="source">source</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        public PagedList(IQueryable<T> source, int pageIndex, int pageSize)
        {
            if (pageIndex == 0) pageIndex = 1;
            if (pageSize == 0) pageSize = 20;

            TotalCount = source.Count();
            TotalPages = TotalCount / pageSize;

            if (TotalCount % pageSize > 0)
                TotalPages++;

            PageSize = pageSize;
            PageIndex = pageIndex;
            pageIndex--;

            list.AddRange(source.Skip(pageIndex * pageSize).Take(pageSize));
        }

        /// <summary>
        /// 由list变为分页
        /// </summary>
        /// <param name="source"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <param name="totalPageSize"></param>
        public PagedList(List<T> source, int pageIndex, int pageSize, int total, int totalPages)
        {
            TotalCount = total;
            TotalPages = totalPages;
            PageSize = pageSize;
            PageIndex = pageIndex;
            list = source;
        }

       

        public int PageIndex { get;  set; }
        public int PageSize { get;  set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public bool HasPreviousPage
        {
            get { return (PageIndex > 0); }
        }
        public bool HasNextPage
        {
            get { return (PageIndex + 1 < TotalPages); }
        }

        public List<T> list { get; set; } = new List<T>();
        
       
    }
}
