using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data.OracleClient;

/// <summary>
/// Summary description for Common
/// </summary>
public class Common
{
	public Common()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static void FillLOV(DropDownList list, string sql)
    {
        try
        {
            OracleConnection oracon = new OracleConnection(Connection.con_str_oracle_cicco);
            oracon.Open();
            OracleCommand cmd = new OracleCommand(sql, oracon);
            OracleDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                ListItem list_values = new ListItem();
                list_values.Text = rd[0].ToString();//description
                list_values.Value = rd[1].ToString();//value

                list.Items.Add(list_values);
            }
            oracon.Close();
        }
        catch (Exception ex)
        {
            
        }
    }

    public static int Save(string sql)
    {
        int message = 0;
        OracleConnection oracon = new OracleConnection(Connection.con_str_oracle_cicco);
        try
        {
            oracon.Open();
            OracleCommand cmd = new OracleCommand(sql, oracon);

            cmd.ExecuteNonQuery();
            cmd.Dispose();
            message = 1;
        }
        catch (OracleException ex)
        {
            message = 0;
        }
        finally
        {
            oracon.Close();
        }

        return message;
    }

    public static string GenerateId(string sql)
    {
        string id = "";
        try
        {
            OracleConnection oracon = new OracleConnection(Connection.con_str_oracle_cicco);
            oracon.Open();
            OracleCommand cmd = new OracleCommand(sql, oracon);
            OracleDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {                
                id = rd[0].ToString();
            }
            oracon.Close();
        }
        catch (Exception ex)
        {
            id = ex.Message;
        }

        return id;
    }

}