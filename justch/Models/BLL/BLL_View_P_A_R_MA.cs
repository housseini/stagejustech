using justch.Models.DAL;
using System.Data;

namespace justch.Models.BLL
{
    public class BLL_View_P_A_R_MA
    {

        public static DataTable Gets ( )
        {
            return DAL_View_P_A_R_MA.Gets();
        }
    }
}
