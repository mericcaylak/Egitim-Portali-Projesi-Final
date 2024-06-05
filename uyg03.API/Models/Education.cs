namespace uyg03.Models
{
    public class Education
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CategoryId { get; set; }
        public Category Categories { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
