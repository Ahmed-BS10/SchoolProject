using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Wapper
{
    public static class QueryableExtensions 
    {
        public static async Task<PaginatedResult<T>> ToPaginateListAsync<T>(this IQueryable<T> sourcse , int pageNumber , int pageSize ) where T : class
        {
            if (sourcse == null) throw new Exception("Empty");

            pageNumber = pageNumber == 0 ? 1 : pageNumber;
            pageSize = pageSize == 0 ? 10 : pageSize;
            int count = await sourcse.AsNoTracking().CountAsync();
            if (count == 0) return PaginatedResult<T>.Success(new List<T>(), count, pageNumber, pageSize);
            var item = sourcse.Skip((pageNumber - 1 ) * pageSize).Take(pageSize).ToList();
            return PaginatedResult<T>.Success(item, count, pageNumber, pageSize);
        }
    }
}
