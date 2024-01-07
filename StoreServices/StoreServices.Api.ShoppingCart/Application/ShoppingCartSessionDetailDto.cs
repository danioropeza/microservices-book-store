namespace StoreServices.Api.ShoppingCart.Application
{
    public class ShoppingCartSessionDetailDto
    {
        public Guid? BookId { get; set; }
        public string BookTitle { get; set; }
        public string BookAuthor { get; set; }
        public DateTime? PublicationDate { get; set; }
    }
}
