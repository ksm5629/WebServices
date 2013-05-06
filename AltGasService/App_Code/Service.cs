using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.Sql;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using Newtonsoft;
using Newtonsoft.Json;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
    String server = "localhost";
    String database = "altgasfuel";
    String uid = "root";
    String password = "root";
    String connectionString;
    MySqlConnection conn;
    MySqlDataReader dr;
    MySqlCommand myCommand;
	public string GetGasStationswithState(string parameter)
	{
        try
        {
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
             database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            conn = new MySqlConnection(connectionString);

            //conn.Open();

            myCommand = conn.CreateCommand();

            myCommand.CommandText = "select * from GasDataTable where state='" + parameter + "';";
     //       myCommand.Parameters.AddWithValue("@ZState", parameter);
            conn.Open();
            dr = myCommand.ExecuteReader();
            GasDataInstance gasS = null;
            MultipleGasInstance mulGs = new MultipleGasInstance();
            while (dr.Read())
            {
                gasS = new GasDataInstance();
                gasS.fuelTypeCode = (string)dr["fueltypecode"];
                gasS.stationName = (string)dr["stationname"];
               gasS.streetAddress = (string)dr["streetaddress"];
               gasS.intersectionDirections= (string)dr["intersectiondirections"];
               gasS.city = (string)dr["city"];
               gasS.state = (string)dr["state"];
               gasS.Zip = (string)dr["zip"];
               gasS.phone = (string)dr["stationphone"];
               gasS.accessDayTime = (string)dr["accessdaystime"];
               gasS.cardsAccepted = (string)dr["cardsaccepted"];
               gasS.geocodeStatus = (string)dr["geocodestatus"];

                gasS.latitude = (string)dr["latitude"];
                gasS.longitude = (string)dr["longitude"];
                gasS.updatedAt = (string)dr["updatedat"];
                gasS.openDate = (string)dr["opendate"];
                mulGs.multGasInst.Add(gasS);
                //a += k;
            }
            conn.Close();
            string outputString = JsonConvert.SerializeObject(mulGs);
            return outputString;
        }
        catch (Exception e)
        {
            return e.Message.ToString();
        }
	}

   public string GetGasStationswithCity(string parameter)
    {
        try
        {
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
           database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            conn = new MySqlConnection(connectionString);

            //conn.Open();

            myCommand = conn.CreateCommand();

            myCommand.CommandText = "select * from GasDataTable where city= '"+parameter+"';";
       //     myCommand.Parameters.AddWithValue("@ZState", parameter);
            conn.Open();
            dr = myCommand.ExecuteReader();
            GasDataInstance gasS = null;
            MultipleGasInstance mulGs = new MultipleGasInstance();
            while (dr.Read())
            {
                gasS = new GasDataInstance();
                gasS.fuelTypeCode = (string)dr["fueltypecode"];
                gasS.stationName = (string)dr["stationname"];
                gasS.streetAddress = (string)dr["streetaddress"];
                gasS.intersectionDirections = (string)dr["intersectiondirections"];
                gasS.city = (string)dr["city"];
                gasS.state = (string)dr["state"];
                gasS.Zip = (string)dr["zip"];
                gasS.phone = (string)dr["stationphone"];
                gasS.accessDayTime = (string)dr["accessdaystime"];
                gasS.cardsAccepted = (string)dr["cardsaccepted"];
                gasS.geocodeStatus = (string)dr["geocodestatus"];

                gasS.latitude = (string)dr["latitude"];
                gasS.longitude = (string)dr["longitude"];
                gasS.updatedAt = (string)dr["updatedat"];
                gasS.openDate = (string)dr["opendate"];
                mulGs.multGasInst.Add(gasS);
                //a += k;
            }
            conn.Close();
            string outputString = JsonConvert.SerializeObject(mulGs);
            return outputString;
        }
        catch (Exception e)
        {
            return e.Message.ToString();
        }
    }
}
