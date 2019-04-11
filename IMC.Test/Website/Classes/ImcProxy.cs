using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using Website.Models;

namespace Website.Classes
{
    public static class ImcProxy
    {
        private const string MainUrl = "https://imc-hiring-test.azurewebsites.net";
        private const string GetCitiesExtension = "/Contact/Cities";
        private const string SaveExtension = "/Contact/Save";

        private static Dictionary<string, string> provinces = new Dictionary<string, string>() {
            { "Alberta", "AB" },
            { "British Columbia", "BC" },
            { "Manitoba", "MB" },
            { "New Brunswick", "NB" },
            { "Newfoundland and Labrador", "NL" },
            { "Northwest Territories", "NT" },
            { "Nova Scotia", "NS" },
            { "Nunavut", "NU" },
            { "Ontario", "ON" },
            { "Prince Edward Island", "PE" },
            { "Quebec", "QC" },
            { "Saskatchewan", "SK" },
            { "Yukon", "YT" }
        };

        public static List<string> GetCities(string province)
        {
            string url = MainUrl + GetCitiesExtension + "?province=" + provinces[province];

            string citiesJson = ImcWebRequest.Read(HttpUtility.HtmlEncode(url));

            CitiesRoot requestResult = Deserialize<CitiesRoot>(citiesJson);

            return requestResult.Items;
        }

        public static void Save(ContactUsModel model)
        {
            string rawUrl = MainUrl + SaveExtension;
            rawUrl += "?Name=" + model.FirstName + " " + model.LastName;
            rawUrl += "&Address =" + model.StreetAddress;
            rawUrl += "&City =" + model.City;
            rawUrl += "&Province =" + model.ProvinceTerritory;
            rawUrl += "&Email =" + model.Email;

            string url = HttpUtility.HtmlEncode(rawUrl);

            ImcWebRequest.Read(url);
        }

        private static T Deserialize<T>(string json)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            T result = js.Deserialize<T>(json);

            return result;
        }
    }
}