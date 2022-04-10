using System;

namespace WebApiApplication.Pagination
{
    public class PaginationMetadata
    {
        public PaginationMetadata(
            int totalCount, 
            int currentPage, 
            int itemsPerPage)
        {
            Totalcount = totalCount;
            CurrentPage = currentPage;
            TotalPages = (int)Math.Ceiling(totalCount/(double)itemsPerPage);
        }

        public int CurrentPage { get; private set; }
        public int Totalcount { get; private set; }
        public int TotalPages { get; private set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
    }
}
