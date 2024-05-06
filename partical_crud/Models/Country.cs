using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace partical_crud.Models
{
    public class Country
    {

        [Key]
        public int Id { get; set; }
        public string? CountryName { get; set; }
    }

    public class State
    {
        public int Id { get; set; }
        public string? StateName { get; set; }

        [ForeignKey("CountryId")]
        public Country? Country { get; set; }
        public int CountryId { get; set; }
    }

    public class City
    {
        public int Id { get; set; }
        public string? CityName { get; set; }
        [ForeignKey("StateId")]
        public State? State { get; set; }
        public int StateId { get; set; }
    }
}
