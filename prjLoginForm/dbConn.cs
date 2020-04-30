using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjLoginForm
{
    public static class Datenzugriff
    {
        static string conString = @"Data Source=DESKTOP-0S31MOV\SQLKURS;" +
                            "Initial Catalog=dbLagerVerwaltung;" +
                            "Integrated Security=sspi;";

        public static string strSQL = "SELECT Username, Password FROM tblLogin " +
                        "WHERE Username=@user AND Password=@pass";

        public static SqlConnection cn = new SqlConnection(conString);

    }
}
