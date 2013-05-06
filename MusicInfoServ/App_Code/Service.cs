using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Net;
using System.IO;
using Newtonsoft;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
    /*
          static String key is the API key used to call the web service.
      */
    private static String key = "0306a279dcf01f196621c6ccca3b11a8";

    /// <summary> 
    /// This function is used to return the API key required to call the 
    /// the API
    /// </summary>
    /// <returns>Return API key.</returns> 
    public string GetKey()
    {
        return key;
    }


    /// <summary> 
    /// This function is used to find an instance of a single song
    /// </summary>
    /// <param name="query">Query submitted by the user to retrieve information</param>
    /// <param name="key">Api Key</param>
    /// <param name="fileFormat">the format of the Output i.e either JSON or XML</param>
    /// <returns> return the String format of the custom JSON or XML object created</returns> 

    public string singleSongSearch(string query, string key, string fileFormat)
    {
        String apiCall = "http://tinysong.com/a/" + query + "?format=json&key=" + key;
        String outputString = "";
        SingleSong singleSong = null;
        using (WebClient wc = new WebClient())
        {

            string json = wc.DownloadString(apiCall);
            singleSong = new SingleSong();
            singleSong.url = json;
        }
        String oupForm = fileFormat;
        oupForm = oupForm.ToUpper();
        if (oupForm.Equals("JSON"))
        {
            outputString = JsonConvert.SerializeObject(singleSong);
        }
        else if (oupForm.Equals("XML"))
        {
            outputString = JsonConvert.SerializeObject(singleSong);
            XmlDocument doc = (XmlDocument)JsonConvert.DeserializeXmlNode(outputString);
            StringWriter strWriter = new StringWriter();
            XmlTextWriter xmlWriter = new XmlTextWriter(strWriter);
            doc.WriteTo(xmlWriter);
            outputString = strWriter.ToString();
        }
        else
        {
            outputString = "Invalid File format requested";
        }
        return outputString;
    }


    /// <summary> 
    /// This function is used to find metadata about a song
    /// </summary>
    /// <param name="query">Query submitted by the user to retrieve information</param>
    /// <param name="key">Api Key</param>
    /// <param name="fileFormat">the format of the Output i.e either JSON or XML</param>
    /// <returns> return the String format of the custom JSON or XML object created</returns> 

    public string singleSongMetadataSearch(string query, string key, string fileFormat)
    {

        String apiCall = "http://tinysong.com/b/" + query + "?format=json&key=" + key;
        String outputString = "";
        SingleSongMetadata singleSongMetadata = null;
        using (WebClient wc = new WebClient())
        {

            string json = wc.DownloadString(apiCall);
            singleSongMetadata = JsonConvert.DeserializeObject<SingleSongMetadata>(json);
        }
        String oupForm = fileFormat;
        oupForm = oupForm.ToUpper();
        if (oupForm.Equals("JSON"))
        {
            outputString = JsonConvert.SerializeObject(singleSongMetadata);
        }
        else if (oupForm.Equals("XML"))
        {
            outputString = JsonConvert.SerializeObject(singleSongMetadata);
            //outputString.Insert
            //XmlDocument doc = (XmlDocument)JsonConvert.DeserializeXmlNode(outputString);
            //StringWriter strWriter = new StringWriter();
            //XmlTextWriter xmlWriter = new XmlTextWriter(strWriter);
            //doc.WriteTo(xmlWriter);
            //outputString = strWriter.ToString();
        }
        else
        {
            outputString = "Invalid File format requested";
        }
        return outputString;

    }


    /// <summary> 
    /// This function is used to find multiple instances of metadata
    /// about an artist and his/her songs
    /// </summary>
    /// <param name="query">Query submitted by the user to retrieve information</param>
    /// <param name="key">Api Key</param>
    /// <param name="fileFormat">the format of the Output i.e either JSON or XML</param>
    /// <returns> return the String format of the custom JSON or XML object created</returns> 

    public string multipleSongMetadataSearch(string query, string limit, string key, string fileFormat)
    {

        String apiCall = "http://tinysong.com/s/" + query + "?format=json&limit=" + limit + "&key=" + key;
        String outputString = "";
        int lim = Convert.ToInt32(limit);
        int temp = lim;
        MultipleSongMetadata multiplesongMetadata = new MultipleSongMetadata();
        SingleSongMetadata singleSongMetadata = null;
        using (WebClient wc = new WebClient())
        {

            string json = wc.DownloadString(apiCall);
            var jArray = JArray.Parse(json);
            foreach (var a in jArray)
            {
                singleSongMetadata = JsonConvert.DeserializeObject<SingleSongMetadata>(a.ToString());
                multiplesongMetadata.multipleSongMetadata.Add(singleSongMetadata);
            }

        }

        String oupForm = fileFormat;
        oupForm = oupForm.ToUpper();
        if (oupForm.Equals("JSON"))
        {
            outputString = JsonConvert.SerializeObject(multiplesongMetadata);
        }
        else if (oupForm.Equals("XML"))
        {
            outputString = JsonConvert.SerializeObject(multiplesongMetadata);
            ////outputString.Insert
            //XmlDocument doc = (XmlDocument)JsonConvert.DeserializeXmlNode(outputString);
            //StringWriter strWriter = new StringWriter();
            //XmlTextWriter xmlWriter = new XmlTextWriter(strWriter);
            //doc.WriteTo(xmlWriter);
            //outputString = strWriter.ToString();
        }
        else
        {
            outputString = "Invalid File format requested";
        }
        return outputString;

    }
}
