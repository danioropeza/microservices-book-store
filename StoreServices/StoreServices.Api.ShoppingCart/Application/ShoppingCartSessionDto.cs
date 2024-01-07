namespace StoreServices.Api.ShoppingCart.Application
{
    public class ShoppingCartSessionDto
    {
        public int ShoppingCartSessionId { get; set; }
        public DateTime? SessionCreationDate { get; set; }
        public List<ShoppingCartSessionDetailDto> Products { get; set; }
    }
}
