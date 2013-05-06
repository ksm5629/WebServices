using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using TweetSharp;
using Newtonsoft;
using Newtonsoft.Json;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
    private static string consumerKey="oOHvEi5Hp7hNHzG7AcC7kA";
    private static string consumerSecret = "x2ZX98qpG97tmvX31CrVfhMdAxpRAYLSDTBDDp0Rf1E";
    private static string accessToken ="535438847-RQtdzEJBQYB4B8oKRRGSgcYg9Y6uEHgXF5W5uKjU";
    private static string accessTokenSecret = "QeUAUGLuTBYt9z0RUPyMVNwxHwJPmKCtrtyYlJsVFT4";

    public string GetTweetsOnHashTags(string hashTags)
	{
        var service = new TwitterService(consumerKey, consumerSecret);
        service.AuthenticateWith(accessToken, accessTokenSecret);
        SearchOptions so = new SearchOptions();
        so.Q = "#"+hashTags;
        
        so.Count = 100;
        var tweeting = service.Search(so);
        IEnumerable<TwitterStatus> returnValue = tweeting.Statuses;
        TweetsInst tweets = null;
        MulTweetInstance multweets = new MulTweetInstance();
        foreach (var twt in returnValue)
        {
            tweets = new TweetsInst();
            if (twt.Author.ScreenName != null)
            {
                tweets.author = twt.Author.ScreenName;
            }
            else { tweets.author = ""; }
            if (twt.Author.ProfileImageUrl != null)
            {
                tweets.UserImage = twt.Author.ProfileImageUrl;
            }
            else { tweets.UserImage = ""; }
            if (twt.User != null)
            {
                tweets.User_ID = Convert.ToString(twt.User.Id);
            }
            else { tweets.User_ID = null; }
            if (twt.Text != null)
            {
                tweets.tweet = twt.Text;
            }
            else { tweets.tweet = ""; }
            if (twt.Location != null)
            {
                tweets.latitude = Convert.ToString(twt.Location.Coordinates.Latitude);
            }
            else { tweets.latitude = ""; }
            if (twt.Location != null)
            {
                tweets.longitude = Convert.ToString(twt.Location.Coordinates.Longitude);
            }
            else { tweets.longitude = null; }
            if (twt.Place != null)
            {
                tweets.country = twt.Place.Country;
            }
            else { tweets.country = ""; }
                multweets.mulTweet.Add(tweets);
        }
        string output = JsonConvert.SerializeObject(multweets);
        return output;
	}

    public string GetTweetsFromPhrase(String phrase)    {
        var service = new TwitterService(consumerKey, consumerSecret);
        service.AuthenticateWith(accessToken, accessTokenSecret);
        SearchOptions so = new SearchOptions();
        so.Q = phrase;
        so.Count = 100;
        var tweeting = service.Search(so);
        IEnumerable<TwitterStatus> returnValue = tweeting.Statuses;
        TweetsInst tweets = null;
        MulTweetInstance multweets = new MulTweetInstance();
        foreach (var twt in returnValue)
        {
            tweets = new TweetsInst();
            if (twt.Author.ScreenName != null)
            {
                tweets.author = twt.Author.ScreenName;
            }
            else { tweets.author = ""; }
            if (twt.Author.ProfileImageUrl != null)
            {
                tweets.UserImage = twt.Author.ProfileImageUrl;
            }
            else { tweets.UserImage = ""; }
            if (twt.User != null)
            {
                tweets.User_ID = Convert.ToString(twt.User.Id);
            }
            else { tweets.User_ID = null; }
            if (twt.Text != null)
            {
                tweets.tweet = twt.Text;
            }
            else { tweets.tweet = ""; }
            if (twt.Location != null)
            {
                tweets.latitude = Convert.ToString(twt.Location.Coordinates.Latitude);
            }
            else { tweets.latitude = ""; }
            if (twt.Location != null)
            {
                tweets.longitude = Convert.ToString(twt.Location.Coordinates.Longitude);
            }
            else { tweets.longitude = null; }
            if (twt.Place != null)
            {
                tweets.country = twt.Place.Country;
            }
            else { tweets.country = ""; }
            multweets.mulTweet.Add(tweets);
        }
        string output = JsonConvert.SerializeObject(multweets);
        return output;
    }

	
}
