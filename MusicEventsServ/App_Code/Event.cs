using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


    public class Event
    {
      public  String eventID;
     public   String eventTitle;
     public   String eventUrl;
     public String eventStartTime;
     public String eventStopTime;
     public String venueUrl;
     public String venueName;
     public String venueAddress;
     public String eventCityName;
     public String eventState;
     public String eventStateAbbr;
     public String eventPostalCode;
     public String eventCountryName;
     public String eventCountryAbbr;
     public String eventLongitude;
     public String eventLatitude;
     public String eventImageUrl;
     public List<Performer> performers = new List<Performer>();

        public Event() { }
    }
