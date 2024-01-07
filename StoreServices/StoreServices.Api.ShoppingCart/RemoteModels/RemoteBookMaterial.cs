namespace StoreServices.Api.ShoppingCart.RemoteModels
{
    public class RemoteBookMaterial
    {
        public Guid? BookMaterialId { get; set; }
        public string Title { get; set; }
        public DateTime? PublicationDate { get; set; }
        public Guid? BookAuthor { get; set; }
    }
}
