using System.ComponentModel.DataAnnotations;

namespace justch.Models.ENTITIES
{
    public class TraitementCycle
    {
        public  int Id;
        [Required(ErrorMessage = "Name  TraitementCycle is Required", AllowEmptyStrings = false)]
      
        public string Name;
        [Required(ErrorMessage = "medical act is Required")]
        public int IdMedicalAct;

    }
}
