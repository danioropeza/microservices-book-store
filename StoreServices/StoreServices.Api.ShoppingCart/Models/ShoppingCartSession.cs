namespace StoreServices.Api.ShoppingCart.Models
{
    public class ShoppingCartSession
    {
        public int ShoppingCartSessionId { get; set; }
        public DateTime? CreationDate { get; set; }
        public ICollection<ShoppingCartSessionDetail> ShoppingCartSessionDetails { get; set; }
    }
}
