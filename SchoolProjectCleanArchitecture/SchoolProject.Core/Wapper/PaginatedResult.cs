using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Wapper
{
    public class PaginatedResult<T>
    {
        public PaginatedResult(List<T> data)
        {
            Data=data;
        }

        public List<T> Data { get; set; }

        public PaginatedResult(bool succeeded, List<T> date = default, List<string> messages = null, int conut = 0, int page = 1, int pageSize = 10)
        {
            Data = date;  
            CurrentPage = page;
            Succeeded = succeeded;
            PageSize = pageSize;
            TotalPage = (int)Math.Ceiling(conut / (double)pageSize);
            TotalConut =conut;
           
   
        }


        public static PaginatedResult<T>Success(List<T> data , int count , int page,int pagesize)
        {
            return new(true, data,null,count,page,pagesize);
        }

      

        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }
        public int TotalConut {  get; set; }
        public int PageSize { get; set; }
        public object Mate { get; set; }
        public bool HasPerviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPage;
        public List<string> Messages { get; set; } = new();
        public bool Succeeded { get; set; }
       
    }
}
