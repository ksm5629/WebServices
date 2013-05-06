using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{

    /// <summary> 
    /// This function is used to Encrypt a string using substitution
    /// cipher and the amount of disposition
    /// </summary>
    /// <param name="plainText">String sent by user to be encrypted</param>
    /// <param name="disposition">amount of disposition for each charachter</param>
    /// <returns>Encrypted String is returned to the user</returns> 

    public string EncryptCaeserCipher(string plainText, int disposition)
    {

        String outputString = "";
        char[] inchar = plainText.ToCharArray();
        // 97 - 122 small charachters // 65 TO 90 BIG
        for (int i = 0; i < inchar.Length; i++)
        {
            //inchar[i] = (char)(inchar[i] + disposition);
            int charachter = (int)inchar[i];
            int temp = disposition;
            if ((charachter >= 32 && charachter < 48) ||
                (charachter >= 58 && charachter < 65) ||
                (charachter >= 91 && charachter < 97) ||
                (charachter >= 123 && charachter < 127)) { }
            else
            {
                while (temp > 0)
                {
                    if (charachter == 122) { charachter = 97; temp--; }
                    else if (charachter == 90) { charachter = 65; temp--; }
                    else { charachter = charachter + 1; temp--; }
                }
                inchar[i] = (char)charachter;
            }
        }
        foreach (char a in inchar)
        {
            outputString += a;
        }
        return outputString;
    }

    /// <summary> 
    /// This function is used to Decrypt a string using substitution
    /// cipher and the amount of disposition
    /// </summary>
    /// <param name="plainText">String sent by user to be decrypted</param>
    /// <param name="disposition">amount of disposition for each charachter</param>
    /// <returns>Decrypted String is returned to the user</returns> 

    public string DecryptCaeserCipher(string cipherText, int disposition)
    {
        String outputString = "";
        char[] inchar = cipherText.ToCharArray();
        // 97 - 122 small charachters // 65 TO 90 BIG
        for (int i = 0; i < inchar.Length; i++)
        {
            int charachter = (int)inchar[i];
            int temp = disposition;
            if ((charachter >= 32 && charachter < 48) ||
                (charachter >= 58 && charachter < 65) ||
                (charachter >= 91 && charachter < 97) ||
                (charachter >= 123 && charachter < 127)) { }
            else
            {
                while (temp > 0)
                {
                    if (charachter == 122) { charachter = 97; temp--; }
                    else if (charachter == 90) { charachter = 65; temp--; }
                    else { charachter = charachter - 1; temp--; }
                }
                inchar[i] = (char)charachter;
            }
        }
        foreach (char a in inchar)
        {
            outputString += a;
        }
        return outputString;
    }

    /// <summary> 
    /// This function is used to Encrypt a string based on Affine Cipher
    /// </summary>
    /// <param name="plainText">String sent by user to be encrypted</param>
    /// <param name="a">value of 'a' supplied </param>
    /// <param name="b">value of 'b' supplied </param>
    /// <returns>Encrypted String is returned to the user</returns>

    public string EncryptAffineCipher(string plainText, int a, int b)
    {
        String outputString = "";
        char[] inchar = plainText.ToUpper().ToCharArray();
        // 97 - 122 small charachters // 65 TO 90 BIG
        for (int i = 0; i < inchar.Length; i++)
        {
            int charachter = (int)inchar[i];
            if ((charachter >= 32 && charachter < 48) ||
                (charachter >= 58 && charachter < 65) ||
                (charachter >= 91 && charachter < 97) ||
                (charachter >= 123 && charachter < 127)) { }
            else
            {
                int temp = 0;
                temp = charachter - 65;
                temp = temp * a;
                temp += b;
                temp = (temp % 26) + 65;
                inchar[i] = (char)temp;
            }
        }
        foreach (char m in inchar)
        {
            outputString += m;
        }
        return outputString;
    }

    /// <summary> 
    /// This function is used to Decrypt a string based on Affine Cipher
    /// </summary>
    /// <param name="plainText">String sent by user to be Dencrypted</param>
    /// <param name="a">value of 'a' supplied </param>
    /// <param name="b">value of 'b' supplied </param>
    /// <returns>Dencrypted String is returned to the user</returns>

    public string DecryptAffineCipher(string cipherText, int a, int b)
    {
        String outputString = "";
        char[] inchar = cipherText.ToUpper().ToCharArray();
        for (int i = 0; i < inchar.Length; i++)
        {
            int charachter = (int)inchar[i];
            if ((charachter >= 32 && charachter < 48) ||
                (charachter >= 58 && charachter < 65) ||
                (charachter >= 91 && charachter < 97) ||
                (charachter >= 123 && charachter < 127)) { }
            else
            {
                int ainv = 0;
                for (int k = 1; k <= 26; k++)
                {
                    if ((a * k) % 26 == 1)
                    {
                        ainv = k;
                    }
                    else {  }
                }

                int temp = 0;
                temp = charachter - 65;
                temp = temp - b;
                temp = temp * ainv;

                temp = (temp % 26);
                if (temp < 0)
                {
                    temp = temp + 26;

                }
                temp = temp + 65;

                inchar[i] = (char)temp;

            }
        }
        foreach (char c in inchar)
        {
            outputString += c;
        }
        return outputString;
    }
	
}
