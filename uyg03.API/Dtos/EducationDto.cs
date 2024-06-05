using uyg03.Models;

namespace uyg03.Dtos
{
    public class EducationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public int CategoryId { get; set; }

        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        
    }
}
