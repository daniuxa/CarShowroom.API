using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.Bll.Services
{
    /// <summary>
    /// Class for pagination meta data
    /// </summary>
    public class PaginationMetadata
    {
        /// <summary>
        /// Quantity of items
        /// </summary>
        public int TotalItemCount { get; set; }
        /// <summary>
        /// Quantity of pages
        /// </summary>
        public int TotalPageCount { get; set; }
        /// <summary>
        /// Quantity of items in one page
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// Which page was shown
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// Constructor of class
        /// </summary>
        /// <param name="totalItemCount">Quantity of items</param>
        /// <param name="pageSize">Quantity of items in one page</param>
        /// <param name="currentPage">Which page was shown</param>
        public PaginationMetadata(int totalItemCount, int pageSize, int currentPage)
        {
            TotalItemCount = totalItemCount;
            PageSize = pageSize;
            CurrentPage = currentPage;
            TotalPageCount = (int)Math.Ceiling(totalItemCount / (double)pageSize);
        }
    }
}
