using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalTaskManager.Models
{
    public class Page<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public List<T> Items { get; set; }
        public int TotalPages { get; private set; }

        public Page(List<T> Items, int PageNumber = 1, int PageSize = 10)
        {
            this.TotalPages = (int)Math.Ceiling((float)Items.Count / PageSize);
            this.PageNumber = PageNumber;
            this.PageSize = PageSize;
            this.Items = Items.Skip((PageNumber - 1) * PageSize).Take(PageSize).ToList();
        }
    }
}