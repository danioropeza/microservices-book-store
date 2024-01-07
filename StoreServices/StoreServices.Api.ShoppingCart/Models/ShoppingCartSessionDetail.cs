namespace StoreServices.Api.ShoppingCart.Models
{
    public class ShoppingCartSessionDetail
    {
        public int ShoppingCartSessionDetailId { get; set; }
        public DateTime? CreationDate { get; set; }
        public string SelectedProduct {  get; set; }
        public int ShoppingCartSessionId { get; set; }
        public ShoppingCartSession ShoppingCartSession { get; set; }
    }
}
