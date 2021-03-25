using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OracleClient;
/// <summary>
/// Summary description for Connection
/// </summary>
public class Connection
{
    public static string con_str_oracle_cicl = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
                                "(HOST=CICCO-SCAN)(PORT=1521)))(CONNECT_DATA=(SERVER=CICL)(SID=CICL2))); " +
                                " User ID=IIS_220;Password=M;";

    public static string con_str_oracle_cicco = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
                                "(HOST=CICCO-SCAN)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME = CICCO))); " +
                                " User ID=IIS_220;Password=M;";

    //****************test database connection string********************************
    public static String con_str_oracle_ceyt = "Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP) " +
                                "(HOST =10.10.1.13)(PORT =1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = CEYT.ceyins.lk))); " +
                                               " User ID=cicl;Password=cicl;";

    public static String con_str_oracle_ciclt = "Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)" +
                                "(HOST =10.10.5.231)(PORT =1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = CICLT.ceyins.lk)));" +
                                "User ID=cicl;Password=cicl;";

    public static string con_str_oracle_eceyt = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
    "(HOST=CICCO-SCAN)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME = CEYT))); " +
    " User ID=cicl;Password=cicl;";

    public static string con_str_oracle = "";
	
    private OracleConnection con = null;

    public Connection()
    {
        ////
        //// TODO: Add constructor logic here
        //string con_eceyt = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
        //                    "(HOST=CICCO-SCAN)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME = CEYT))); " +
        //                    " User ID=cicl;Password=cicl;";

        con = new OracleConnection(con_str_oracle_cicco);
        //con = new OracleConnection(con_eceyt);

    }

    public OracleConnection GetConnection
    {

        get { return con; }

    }

}
