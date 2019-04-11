using System;
using System.Net;
using System.IO;
using System.Text;

namespace Website.Classes
{
    public static class ImcWebRequest
    {
        public static string Read(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            string html;
            StringBuilder sb = new StringBuilder();

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        html = reader.ReadToEnd();
                        sb.Append(html);
                    }
                }
            }

            return sb.ToString();
        }
    }
}