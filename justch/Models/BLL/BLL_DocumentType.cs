using justch.Models.DAL;
using justch.Models.ENTITIES;
using System.Collections.Generic;

namespace justch.Models.BLL
{
    public class BLL_DocumentType
    {
        public static Message add(DocumentType documentType)
        {
            return DAL_DocumentType.add(documentType);
        }
        public static List<DocumentType>gets()
            
        {
            DalMigration.create_table_Document();

            DalMigration.create_table_DocumentType();
            return DAL_DocumentType.gets();
        }

        public static DocumentType getByCode(string Code)
        {
            return DAL_DocumentType.getByCode(Code);
        }
        public static Message update(DocumentType documentType, string code)
        {
            return DAL_DocumentType.update(documentType,code);
        }
        public static Message delete(string code)
        {
            return DAL_DocumentType.delete(code);
        }

    }
}
