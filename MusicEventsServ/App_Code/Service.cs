using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Net;
using Newtonsoft;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{

    /// <summary> 
    /// This function is used to get all the available
    /// categories of possible events
    /// </summary>
    /// <param name="key">Key required to make the API call</param>
    /// <returns>JSON in String Format containing all categories</returns> 

    public string GetCategories(string key)
    {
        String outputString = "";
        int count = 0;
        Category category = null;
        Categories categories = new Categories();
        using (WebClient wc = new WebClient())
        {

            string xml = wc.DownloadString("http://api.evdb.com/rest/categories/list?app_key=" + key);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            XmlNodeList root = doc.GetElementsByTagName("category");
            count = root.Count;
            string json = JsonConvert.SerializeXmlNode(doc);
            JObject obj = JObject.Parse(json);
            int temp = 0;
            while (temp < count)
            {
                category = new Category();
                category.categoryID = (string)obj["categories"]["category"][temp]["id"];
                category.categoryName = (string)obj["categories"]["category"][temp]["name"];
                categories.categories.Add(category);
                temp++;
            }
            outputString = JsonConvert.SerializeObject(categories);
        }
        return outputString;
    }

    /// <summary> 
    /// This function is used return the key used for the API call
    /// </summary>
    /// <returns>Key in String format </returns>

    public string GetKey()
    {
        return "rPwttTPbhzGmX99K";
    }

    /// <summary> 
    /// This function is used to search the venues in a particular
    /// location based on the given parameters
    /// </summary>
    /// <param name="keywords">The search criteria</param>
    /// <param name="location">Sets the geographical point of interest for the search</param>
    /// <param name="within">Sets a geographical radius for the search</param>
    /// <param name="key">key required to call the API</param>
    /// <returns>JSON in string format containg all the venues supplied as a result of the search</returns> 

    public string GetVenues(string keywords, String location, String within, string key)
    {
        //http://api.eventful.com/rest/venues/search?app_key=rPwttTPbhzGmX99K&keywords=Restaurant&location=San+Diego&within=20
        String apiCall = "http://api.eventful.com/rest/venues/search?app_key=" + key;
        string outputString = null;
        if (keywords != null)
        {
            apiCall = apiCall + "&keywords=" + keywords;
        }
        if (location != null)
        {
            apiCall = apiCall + "&location=" + location;
        }
        if (within != null)
        {
            apiCall = apiCall + "&within=" + within;
        }

        int count = 0;
        Venue venue = null;

        using (WebClient wc = new WebClient())
        {

            string xml = wc.DownloadString(apiCall);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            XmlNodeList root = doc.GetElementsByTagName("venue");
            Venues VenuesAll = new Venues();
            count = root.Count;
            string json = JsonConvert.SerializeXmlNode(doc);
            JObject obj = JObject.Parse(json);
            int temp = 0;
            while (temp < count)
            {
                venue = new Venue();
                venue.venueUrl = (string)obj["search"]["venues"]["venue"][temp]["url"];
                venue.venueName = (string)obj["search"]["venues"]["venue"][temp]["name"];
                venue.venueAddress = (string)obj["search"]["venues"]["venue"][temp]["address"];
                venue.venueCity = (string)obj["search"]["venues"]["venue"][temp]["city_name"];
                venue.venueState = (string)obj["search"]["venues"]["venue"][temp]["region_name"];
                venue.venueStateAbbr = (string)obj["search"]["venues"]["venue"][temp]["region_abbr"];
                venue.venueZip = (string)obj["search"]["venues"]["venue"][temp]["postal_code"];
                venue.venueCountry = (string)obj["search"]["venues"]["venue"][temp]["country_name"];
                venue.venueLongitude = (string)obj["search"]["venues"]["venue"][temp]["longitude"];
                venue.venueLatitude = (string)obj["search"]["venues"]["venue"][temp]["latitude"];
                VenuesAll.venues.Add(venue);
                temp++;
            }
            outputString = JsonConvert.SerializeObject(VenuesAll);
        }
        return outputString;
    }

    /// <summary> 
    /// This function is used to search the events in a particular
    /// location based on the given parameters
    /// </summary>
    /// <param name="keywords">The search criteria</param>
    /// <param name="category">the category of the search criteria</param>
    /// <param name="date">The date as a search criteria</param>
    /// <param name="location">Sets the geographical point of interest for the search</param>
    /// <param name="within">Sets a geographical radius for the search</param>
    /// <param name="key">key required to call the API</param>
    /// <returns>JSON in string format containg all the events supplied as a result of the search</returns> 

    public string GetEvents(string keywords, string location, string category, String within, string date, string key)
    {
        //http://api.eventful.com/rest/events/search?app_key=rPwttTPbhzGmX99K&keywords=books&location=San+Diego&date=Future
        String apiCall = "http://api.eventful.com/rest/events/search?app_key=" + key;
        string outputString = null;
        if (keywords != null)
        {
            apiCall = apiCall + "&keywords=" + keywords;
        }
        if (location != null)
        {
            apiCall = apiCall + "&location=" + location;
        }
        if (category != null)
        {
            apiCall = apiCall + "&category=" + category;
        }
        if (date != null)
        {
            apiCall = apiCall + "&date=" + date;
        }
        if (within != null)
        {
            apiCall = apiCall + "&within=" + within;
        }
        int count = 0;
        using (WebClient wc = new WebClient())
        {

            string xml = wc.DownloadString(apiCall);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            XmlNodeList root = doc.SelectNodes("/search/events/event");
            count = root.Count;
            string json = JsonConvert.SerializeXmlNode(doc);
            JObject obj = JObject.Parse(json);
            int temp = 0;
            int tempPerformer = 0;
            int tempPCount = 0;
            Event events = null;
            Events eventsAll = new Events();
            //http://api.eventful.com/rest/events/search?app_key=rPwttTPbhzGmX99K&keywords=rihanna&date=Future
            while (temp < count)
            {
                events = new Event();
                //obj["search"]["events"]["event"][temp]["image"]["medium"];
                events.eventID = (string)obj["search"]["events"]["event"][temp]["@id"];
                events.eventTitle = (string)obj["search"]["events"]["event"][temp]["title"];
                events.eventUrl = (string)obj["search"]["events"]["event"][temp]["url"];
                events.eventStartTime = (string)obj["search"]["events"]["event"][temp]["start_time"];
                events.eventStopTime = (string)obj["search"]["events"]["event"][temp]["stop_time"];
                events.venueUrl = (string)obj["search"]["events"]["event"][temp]["venue_url"];
                events.venueName = (string)obj["search"]["events"]["event"][temp]["venue_name"];
                events.venueAddress = (string)obj["search"]["events"]["event"][temp]["venue_address"];
                events.eventCityName = (string)obj["search"]["events"]["event"][temp]["city_name"];
                events.eventState = (string)obj["search"]["events"]["event"][temp]["region_name"];
                events.eventStateAbbr = (string)obj["search"]["events"]["event"][temp]["region_abbr"];
                events.eventPostalCode = (string)obj["search"]["events"]["event"][temp]["postal_code"];
                events.eventCountryName = (string)obj["search"]["events"]["event"][temp]["country_name"];
                events.eventCountryAbbr = (string)obj["search"]["events"]["event"][temp]["country_abbr"];
                events.eventLatitude = (string)obj["search"]["events"]["event"][temp]["latitude"];
                events.eventLongitude = (string)obj["search"]["events"]["event"][temp]["longitude"];

                JObject performerJSON = (JObject)obj["search"]["events"]["event"][temp]["performers"];
                tempPCount = performerJSON.Count;
                while (tempPerformer < tempPCount)
                {
                    Performer performer = new Performer();
                    performer.performerID = (string)performerJSON["performer"]["id"];
                    performer.performerName = (string)performerJSON["performer"]["name"];
                    performer.performerUrl = (string)performerJSON["performer"]["url"];
                    performer.performerBio = (string)performerJSON["performer"]["short_bio"];
                    events.performers.Add(performer);
                    tempPerformer++;
                }
                events.eventImageUrl = (string)obj["search"]["events"]["event"][temp]["image"]["medium"]["url"];
                eventsAll.events.Add(events);
                temp++;
            }
            outputString = JsonConvert.SerializeObject(eventsAll);
        }
        return outputString;
    }
}
