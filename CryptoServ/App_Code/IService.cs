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
    String EncryptCaeserCipher(String plainText, int disposition);

    [OperationContract]
    String DecryptCaeserCipher(String cipherText, int disposition);

    [OperationContract]
    String EncryptAffineCipher(String plainText, int a, int b);

    [OperationContract]
    String DecryptAffineCipher(String cipherText, int a, int b);

	// TODO: Add your service operations here
}

// Use a data contract as illustrated in the sample below to add composite types to service operations.
