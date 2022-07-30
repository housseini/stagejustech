namespace justch.Models.ENTITIES
{
    public class Document
    {
        public int Id { get; set; }
        public int IdPatient  { get; set; }
        public string CodeDocumentType { get; set; }
        public int IdDossierMedical { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
    }
}
