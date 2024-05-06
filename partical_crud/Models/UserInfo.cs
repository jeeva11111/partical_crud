using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace partical_crud.Models
{
    public class UserInfo
    {

        [Key]
        public int Id { get; set; }
        [Required, Display(Name = "UserName"), MaxLength(30)]
  

        public string? UserName { get; set; }
        [Required, Display(Name = "LastName"), MaxLength(30)]

        public string? LastName { get; set; }
        [Required, Display(Name = "Qualification"), MaxLength(30)]

        public string? Qualification { get; set; }
        [Required, Display(Name = "Email"), MaxLength(30), DataType(DataType.EmailAddress)]

        public string? Email { get; set; }


        [Required, Display(Name = "Phone")]

        public string? Phone { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime SpeakingDate { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Time")]
        public DateTime SpeakingTime { get; set; }

        [NotMapped]
        public IFormFile? UserImage { get; set; }

        public string? UserFileName { get; set; }


        public int ZipCode { get; set; }
        public string? Address { get; set; }

        public Country? Country { get; set; }
        public State? State { get; set; }
        public City? City { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
    }
}
