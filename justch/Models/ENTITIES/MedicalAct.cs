using System.ComponentModel.DataAnnotations;

namespace justch.Models.ENTITIES
{
    public class MedicalAct
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "MedicalActType is Required")]
        public string MedicalActType { get; set; }
        [Required(ErrorMessage = "Duration is Required")]
        public string Duration { get; set; }
        [Required(ErrorMessage = "Category is Required")]
        public string Category { get; set; }
        public int IdRoom { get; set; }



    }
}
