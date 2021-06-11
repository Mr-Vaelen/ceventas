using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceventas
{
    public static class Encoder
    {
        static Dictionary<String, String> codeDB = new Dictionary<String, String>();
        static Dictionary<String, String> urlDB = new Dictionary<String, String>();
        static String chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        private static string getCode()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("http://tinyurl.com/");
            for (int i = 0; i < 6; i++)
                builder.Append(chars[(int)new Random().Next(1, chars.Length)]);
            return builder.ToString();
        }

        public static string encode(String longUrl)
        {
            if (!CheckForProperlyDefinedLink(longUrl)) return "Please ensure that you send a properly defined url.";
            if (urlDB.ContainsKey(longUrl)) return urlDB[longUrl];
            String code = getCode();
            while (codeDB.ContainsKey(code)) code = getCode();
            codeDB.Add(code, longUrl);
            urlDB.Add(longUrl, code);
            return code;
        }

        public static string decode(String shortUrl)
        {
            if (!CheckForProperlyDefinedLink(shortUrl)) return "Please ensure that you send a properly defined url.";
            var returnVal = "";
            if (!codeDB.TryGetValue(shortUrl, out returnVal)) return "Provided link does not exist or is not the encoded link";            
            return returnVal;
        }
        private static bool CheckForProperlyDefinedLink(string link) => System.Uri.IsWellFormedUriString(link, UriKind.RelativeOrAbsolute) && !String.IsNullOrEmpty(link);
    }
}
