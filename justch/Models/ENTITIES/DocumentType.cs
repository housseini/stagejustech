using System.ComponentModel.DataAnnotations;

namespace justch.Models.ENTITIES
{
    public class DocumentType
    {
        [Required(ErrorMessage = "Code is Required")]
        public string Code { get; set; } 
        [Required(ErrorMessage ="Label is Required")]
        public string Label { get; set; }

    }
}
