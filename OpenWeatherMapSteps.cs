using ConsoleTables;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace OpenWeatherMap.RIT
{
    [Binding]
    class OpenWeatherMapSteps
    {
        protected string _baseurl;
        protected string _appId;

        protected string url;

        private JObject jobject;

        [Given(@"I have OpenWeatgerMap API Base url and app id")]
        public void GivenIHaveOpenWeatgerMapAPIBaseUrlAndAppId()
        {
            _baseurl = System.Configuration.ConfigurationManager.AppSettings["baseurl"];
            _appId = System.Configuration.ConfigurationManager.AppSettings["appid"];
        }

        [Given(@"I would like to know weather forecast for country '(.*)' and city '(.*)'")]
        public void GivenIWouldLikeToKnowWeatherForecastForCountryAndCity(string country, string city)
        {
            url = _baseurl + "?q=" + city + "," + country + "&APPID=" + _appId;
            ScenarioContext.Current.Add("city", city);
            ScenarioContext.Current.Add("country", country);
        }

        [When(@"I have executed get method")]
        [Obsolete]
        public void WhenIHaveExecutedGetMethod()
        {
            var task = Task.Run(() => APIRequest.Request("get", new Uri(url)));
            task.Wait();
            ScenarioContext.Current.Add("response", task.Result);
        }

        [Then(@"I can see i recieved '(.*)' status code")]
        [Obsolete]
        public void ThenICanSeeIRecievedStatusCode(int statuscode)
        {
            jobject = JObject.Parse(ScenarioContext.Current["response"].ToString());
            Assert.That(statuscode, Is.EqualTo((Int16)jobject.SelectToken("cod")));
        }

        [Then(@"I have retrieved the number of days and dates where the temperature is predicated to be above '(.*)' degree celsius")]
        public void ThenIHaveRetrievedTheNumberOfDaysAndDatesWhereTheTemperatureIsPredicatedToBeAboveDegreeCelsius(int temperaure)
        {
            var table = new ConsoleTable("S.No", "Country", "City", "DateTime", "Temperature");

            Console.WriteLine("*********Conutry and City Temperature with DateTimeStamp*********");
            int count = 1;
            foreach (var item in jobject.SelectTokens("$..list[?(@main.temp)]"))
            {
                table.AddRow(count, 
                    ScenarioContext.Current["country"].ToString(), 
                    ScenarioContext.Current["city"].ToString(), 
                    item.Value<DateTime?>("dt_txt"),
                    Math.Round((double)item
                    .SelectToken("main.temp") - 273.15, 2) + "celsius");
                count++;
            }
            table.Write();
            Console.WriteLine();
            count = 1;

            var table1 = new ConsoleTable("S.No", "Country", "City", "DateTime", "Temperature");

            Console.WriteLine("*********Conutry and City Temperature with more or equal to "+ 
                temperaure + 
                " with DateTimeStamp*********");

            Console.WriteLine("#Number of days the city temperature is greater than or equal to "+ 
                temperaure + 
                " is "+ jobject.SelectTokens("$..list[?(@main.temp >= " + (Convert.ToDouble(temperaure) + 273.15) + ")]").Count());

            foreach (var item in jobject.SelectTokens("$..list[?(@main.temp >= " + (Convert.ToDouble(temperaure) + 273.15) + ")]"))
            {
                table1.AddRow(count, 
                    ScenarioContext.Current["country"].ToString(), 
                    ScenarioContext.Current["city"].ToString(), 
                    item.Value<DateTime?>("dt_txt"),
                    Math.Round((double)item
                    .SelectToken("main.temp") - 273.15, 2) + "celsius");
                count++;
            }
            table1.Write();
            Console.WriteLine();
        }

        [Then(@"I also retrieved  how many days it is predicted to be '(.*)' in the same time period")]
        public void ThenIAlsoRetrievedHowManyDaysItIsPredictedToBeInTheSameTimePeriod(string prediction)
        {
            var table2 = new ConsoleTable("S.No", "Country", "City", "DateTime", "Weather Condition");

            Console.WriteLine("*********Conutry and City Weather Prediction with DateTimeStamp*********");
            int count = 1;
            foreach (var item in jobject.SelectTokens("$..list[?(@weather[?(@.main)])]"))
            {
                table2.AddRow(count, ScenarioContext.Current["country"].ToString(), 
                    ScenarioContext.Current["city"].ToString(), 
                    item.Value<DateTime?>("dt_txt"),
                    item
                    .SelectToken("$..weather[?(@main)]")
                    .SelectToken(".main")
                    .ToString());
                count++;
            }
            table2.Write();
            Console.WriteLine();
            count = 1;

            var table3 = new ConsoleTable("S.No", "Country", "City", "DateTime", "Weather Condition");

            Console.WriteLine("*********Conutry and City Weather Prediction "
                +prediction+
                " with DateTimeStamp*********");

            Console.WriteLine("#How many days are going to be " 
                + prediction + 
                " "+ jobject.SelectTokens("$..list[?(@weather[?(@.main == '" + prediction + "')])]").Count());

            foreach (var item in jobject.SelectTokens("$..list[?(@weather[?(@.main == '" + prediction + "')])]"))
            {
                table3.AddRow(count, 
                    ScenarioContext.Current["country"].ToString(), 
                    ScenarioContext.Current["city"].ToString(), 
                    item.Value<DateTime?>("dt_txt"), item
                    .SelectToken("$..weather[?(@main)]")
                    .SelectToken(".main")
                    .ToString());
                count++;
            }
            table3.Write();
            Console.WriteLine();
        }

    }
}
