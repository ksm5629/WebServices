using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
[ServiceContract]
public interface IService
{

    [OperationContract]
    string GetCategories(string key);

    [OperationContract]
    string GetVenues(String keywords, String location, String within, string key);

    [OperationContract]
    string GetEvents(String keywords, String location, String category, String within, String date, string key);

    [OperationContract]
    string GetKey();
    // TODO: Add your service operations here
}

// Use a data contract as illustrated in the sample below to add composite types to service operations.
