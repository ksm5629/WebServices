using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using LumenWorks.Framework.IO.Csv;
using System.Data.Sql;
using System.Data.SqlClient;
using Newtonsoft;
using Newtonsoft.Json;
using MySql.Data.MySqlClient;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
    String server = "localhost";
    String database = "mcdonalds";
    String uid = "root";
    String password = "root";
    String connectionString;
    MySqlConnection conn;
    MySqlDataReader myReader;
    MySqlCommand myCommand;

	public string GetMcDwithZipandState(string parameter)
	{
        try
        {
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            conn = new MySqlConnection(connectionString);
            
            //conn.Open();

            myCommand = conn.CreateCommand();
            myCommand.CommandText = "select * from McDonaldsData where ZipandState='" + parameter + "';";
           // sqC.Parameters.AddWithValue("@ZipandState", parameter);
            conn.Open();
            myReader = myCommand.ExecuteReader();
            McDonaldsInstance mcD = null;
            MultipleMcDInstance mulMcD = new MultipleMcDInstance();
            while (myReader.Read())
            {
                mcD = new McDonaldsInstance();
                mcD.All = (string)myReader["all_"];
                mcD.BgLat = (string)myReader["BgLat"];
                mcD.BgLong = (string)myReader["BgLong"];
                mcD.City = (string)myReader["City"];
                mcD.Address = (string)myReader["address"];
                mcD.Latitute = (string)myReader["latitude"];
                mcD.Longitude = (string)myReader["longitude"];
                mcD.ZipandState = (string)myReader["ZipandState"];
                mulMcD.multipleMcDIns.Add(mcD);
                //a += k;
            }

            string outputString = JsonConvert.SerializeObject(mulMcD);
            conn.Close();
            return outputString;
        }
        catch (Exception e)
        {
            return e.Message.ToString();
        }
    }
    
    public string GetMcDwithCity(string parameter)
    {
      try
        {
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            conn = new MySqlConnection(connectionString);
            //conn.Open();

            myCommand = conn.CreateCommand();
            myCommand.CommandText = "select * from mcdonaldsdata where City=' " + parameter + "';";
           // sqC.Parameters.AddWithValue("@ZipandState", parameter);
            conn.Open();
            myReader = myCommand.ExecuteReader();
            McDonaldsInstance mcD = null;
            MultipleMcDInstance mulMcD = new MultipleMcDInstance();
            while (myReader.Read())
            {
                mcD = new McDonaldsInstance();
                mcD.All = (string)myReader["all_"];
                mcD.BgLat = (string)myReader["BgLat"];
                mcD.BgLong = (string)myReader["BgLong"];
                mcD.City = (string)myReader["City"];
                mcD.Address = (string)myReader["address"];
                mcD.Latitute = (string)myReader["latitude"];
                mcD.Longitude = (string)myReader["longitude"];
                mcD.ZipandState = (string)myReader["ZipandState"];
                mulMcD.multipleMcDIns.Add(mcD);
                //a += k;
            }

            string outputString = JsonConvert.SerializeObject(mulMcD);
            conn.Close();
            return outputString;
        }
        catch (Exception e)
        {
            return e.Message.ToString();
        }
    }

    private SqlDataReader executeQueryinDB(String query) 
    {
       
        string connectionstring=@"Data Source=(LocalDB)\v11.0;AttachDbFilename="+@"C:\Users\Karan Moodbidri\Documents\Visual Studio 2012\WebSites\TryMeOutDB\App_Data\McData.mdf"+";Integrated Security=True";
        SqlConnection sq = new SqlConnection(connectionstring);

        SqlCommand sqC = sq.CreateCommand();
        sqC.CommandText = query;
        sq.Open();
        SqlDataReader dr = sqC.ExecuteReader();
        return dr;
    }
}
