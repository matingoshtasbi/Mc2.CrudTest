using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Core.DTOs
{
    public class PageResult<T>
    {
        public List<T> Results { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages
        {
            get
            {
                int remainder;
                int quotient = Math.DivRem(TotalCount, PageSize, out remainder);
                return remainder == 0 ? quotient : quotient + 1; ;
            }
        }
        public bool HasNext
        {
            get
            {
                return PageIndex < PageSize;
            }
        }
        public bool HasPrev
        {
            get
            {
                return PageIndex > 1;
            }
        }
    }
}
