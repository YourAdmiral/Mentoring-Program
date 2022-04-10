namespace WebApiApplication.Pagination
{
    public class PaginationParams
    {
        private const int _maxItemsPerPage = 50;
        private int _itemsPerPage;

        public int Page { get; set; } = 1;

        public int ItemsPerPage
        {
            get => _itemsPerPage;
            set => _itemsPerPage = value > _maxItemsPerPage ? _maxItemsPerPage : value;
        }
    }
}
