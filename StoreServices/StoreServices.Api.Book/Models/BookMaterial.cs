namespace StoreServices.Api.Book.Models
{
    public class BookMaterial
    {
        public Guid? BookMaterialId { get; set; }
        public string Title { get; set; }
        public DateTime? PublicationDate { get; set; }
        public Guid? BookAuthor {  get; set; }
    }
}
