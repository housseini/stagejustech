using justch.Models.DAL;
using justch.Models.ENTITIES;
using System.Collections.Generic;

namespace justch.Models.BLL
{
    public class BLL_Document
    {
        public static Message Add(Document d,int idpatient)
        {
            return DAL_Document.add(d,idpatient);

        }
        public static List<Document> getsBy(string Field, int value)
        {
            return DAL_Document.getsBy(Field, value);
        }
        public static List<Document> getsByIdDossier(int value)
        {
            return DAL_Document.getsByIdDossier(value);
        }
        public static Message Delete(int id)
        {
            return DAL_Document.Delete(id);
        }

        public static List<Document> getsBycode(string value) {
            return DAL_Document.getsBycode(value);
        
        }

        public static Document getsById(int id)
        {
            return DAL_Document.getsById(id);
        }

        public static Message update(Document document)
        {
            return DAL_Document.update(document);
        }
    }
}
