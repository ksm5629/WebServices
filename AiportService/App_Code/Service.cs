using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Newtonsoft;
using Newtonsoft.Json;
using MySql.Data.MySqlClient;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
    String server = "localhost";
    String database = "airports";
    String uid = "root";
    String password = "root";
    String connectionString;
    MySqlConnection conn;
    MySqlDataReader dr;
    MySqlCommand myCommand;

	public string GetAirportswithCity(string value , int count)
	{
        connectionString = "SERVER=" + server + ";" + "DATABASE=" +
           database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
        conn = new MySqlConnection(connectionString);

        //conn.Open();

        myCommand = conn.CreateCommand();
        myCommand.CommandText = "select * from airportdata where city='" + value + "';";
        // sqC.Parameters.AddWithValue("@ZipandState", parameter);
        conn.Open();
        dr = myCommand.ExecuteReader();
        AirportInstance apInst = null;
        int tempCount = 0;
        MultipleAirportInstance mulAPInst = new MultipleAirportInstance();
        while (dr.Read())
        {
            if (tempCount == count - 1)
            {
                break;
            }
            apInst = new AirportInstance();
            apInst.airportabbr1 = (string)dr["airportabbr1"];
            apInst.airportabbr2 = (string)dr["airportabbr2"];
            apInst.airportname = (string)dr["airportname"];
            apInst.city = (string)dr["city"];
            apInst.code1 = (string)dr["code1"];
            apInst.code2 = (string)dr["code2"];
            apInst.code3 = (string)dr["code3"];
            apInst.country = (string)dr["country"];
            apInst.id = Convert.ToString(dr["id"]);
            apInst.longitude = (string)dr["latitude"];
            apInst.latitude = (string)dr["longitude"];
            mulAPInst.mulAirInst.Add(apInst);
            tempCount++;
        }

        string outputString = JsonConvert.SerializeObject(mulAPInst);
        conn.Close();
        return outputString;
	}

    public string GetAirportswithCountry(string value, int count)
    {
        connectionString = "SERVER=" + server + ";" + "DATABASE=" +
           database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
        conn = new MySqlConnection(connectionString);

        //conn.Open();

        myCommand = conn.CreateCommand();
        myCommand.CommandText = "select * from airportdata where country='" + value + "';";
        // sqC.Parameters.AddWithValue("@ZipandState", parameter);
        conn.Open();
        int tempCount = 0;
        dr = myCommand.ExecuteReader();
        AirportInstance apInst = null;
        MultipleAirportInstance mulAPInst = new MultipleAirportInstance();
        while (dr.Read())
        {
            if (tempCount == count - 1)
            {
                break;
            }
            apInst = new AirportInstance();
            apInst.airportabbr1 = (string)dr["airportabbr1"];
            apInst.airportabbr2 = (string)dr["airportabbr2"];
            apInst.airportname = (string)dr["airportname"];
            apInst.city = (string)dr["city"];
            apInst.code1 = (string)dr["code1"];
            apInst.code2 = (string)dr["code2"];
            apInst.code3 = (string)dr["code3"];
            apInst.country = (string)dr["country"];
            apInst.id = Convert.ToString(dr["id"]);
            apInst.longitude = (string)dr["latitude"];
            apInst.latitude = (string)dr["longitude"];
            mulAPInst.mulAirInst.Add(apInst);
            tempCount++;
        }

        string outputString = JsonConvert.SerializeObject(mulAPInst);
        conn.Close();
        return outputString;
    }


}
