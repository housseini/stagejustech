using System.ComponentModel.DataAnnotations;

namespace justch.Models.ENTITIES
{
    public class TechnienEnbrylogiste
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Firsname is Required")]
        public string FirsName { get; set; }
        [Required(ErrorMessage = "LastName is Required")]
        public string LastName { get; set; }
    }
}
