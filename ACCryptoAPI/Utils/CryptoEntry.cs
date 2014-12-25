
namespace ACLibrary.Crypto.Utils
{
    public class CryptoEntry
    {
        public static string Encrypt(ICryptoProvider icp, string otext, string psw)
        {
            return icp.EncryptString(otext, psw);
        }

        public static string Decrypt(ICryptoProvider icp, string otext, string psw)
        {
            return icp.DecryptString(otext, psw);
        }
    }
}
