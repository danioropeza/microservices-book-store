namespace StoreServices.Api.Author.Models
{
    public class BookAuthor
    {
        public int BookAuthorId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        public ICollection<AcademicDegree> academicDegrees { get; set; }

        public string BookAuthorGuid { get; set; }
    }
}
