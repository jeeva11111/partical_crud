using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace partical_crud.Models.CourseLearn
{
    public class PlanningCourse
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Process { get; set; }

        public byte[]? Data { get; set; }
        [NotMapped]
        public IFormFile? FormFile { get; set; }
        public string? ImageName { get; set; }
    }
}
