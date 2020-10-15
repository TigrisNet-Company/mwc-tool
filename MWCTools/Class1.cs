using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


public class Aesendec
{
    // private static string IV = "@TiGr!$n£TtT2020";//16 char
    private static string key = "af42b5d34a1139511cb3ffcc17775ef8"; //32


    public static string Encrypt(string decrypted, string app)
    {
        //decrypted = decrypted.Replace("-", "");
        byte[] textBytes = ASCIIEncoding.ASCII.GetBytes(decrypted);
        AesCryptoServiceProvider encDec = new AesCryptoServiceProvider();
        encDec.BlockSize = 128;
        encDec.KeySize = 256;

        encDec.Key = ASCIIEncoding.ASCII.GetBytes(key);
        encDec.IV = ASCIIEncoding.ASCII.GetBytes(app);
        encDec.Padding = PaddingMode.PKCS7;
        encDec.Mode = CipherMode.CBC;
        ICryptoTransform icrypt = encDec.CreateEncryptor(encDec.Key, encDec.IV);

        byte[] enc = icrypt.TransformFinalBlock(textBytes, 0, textBytes.Length);
        icrypt.Dispose();
        return Convert.ToBase64String(enc);


    }
    public static string Decrypt(string encrypted, string app)
    {
        byte[] encBytes = Convert.FromBase64String(encrypted);
        AesCryptoServiceProvider encDec = new AesCryptoServiceProvider();
        encDec.BlockSize = 128;
        encDec.KeySize = 256;
        encrypted = encrypted.Replace("-", "");
        encDec.Key = ASCIIEncoding.ASCII.GetBytes(key);
        encDec.IV = ASCIIEncoding.ASCII.GetBytes(app);
        encDec.Padding = PaddingMode.PKCS7;
        encDec.Mode = CipherMode.CBC;
        ICryptoTransform icrypt = encDec.CreateDecryptor(encDec.Key, encDec.IV);

        byte[] dec = icrypt.TransformFinalBlock(encBytes, 0, encBytes.Length);
        icrypt.Dispose();
        return ASCIIEncoding.ASCII.GetString(dec);
    }
}


