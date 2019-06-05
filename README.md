# TestAutomation.OpeweatherMapApi

<b>Prerequisite:</b><br>
•	VisualStudio 2012/15/17/19.<br>
•	I have used Visual Studio 2017 Community Edition to develop the code.<br>
•	Installation Steps: https://visualstudio.microsoft.com/downloads/<br>

<b>Packages Installation Steps and guidelines:</b><br>
•	I have used Specflow, Nunit3, Newtonsoft.Json and Console Tables Packages to build the project.<br>
•	Follow Specflow Installation guidelines from https://www.nuget.org/packages/SpecFlow/<br>
•	Follow Nunit Installation guidelines from https://www.nuget.org/packages/NUnit/<br>
•	Follow Console Tables Installation guidelines from https://www.nuget.org/packages/ConsoleTables/<br>
•	Follow Newtonsoft.Json Installation guidelines from https://www.nuget.org/packages/Newtonsoft.Json/<br>

Please add reference "System.Net.Http" Reference to the project (if not already added into the project).<br>

<b>Deep Insights into Project and Test Scenario:</b><br>
<b>Feature to automate:</b><br>
As a weather enthusiast, I would like to know the number of days in Sydney where the temperature is predicted to be above 20 degrees (at the time of calling the API) in the next 5 days, (from the current days date).<br>
I would also like to know how many days it is predicted to be sunny in the same time period.<br>

<b>Solution:</b><br>
•	I have used Specflow to write test steps in BDD fashion so that it is easily understandable to everyone.<br>
•	App.config used to set base url and appid. Config file is handy and easy to modify if any changes occured.<br>
•	Weather forecast for City, country is not hardcoded so it is dynamic to handle any request (any city, country).<br>
•	As temperature and weather type parameterized from, Specflow, User can easily modify values and get accurate responses from API.<br>
•	User has the flexibility to enter the temperature in Celsius rather in kelvin format (API will always return in Kelvin format).<br> 

<b>Results:</b><br>
•	The test is working as expected and added dynamic classes for a more generalized solution.
•	I have attached the Results.txt in the same repository. 

<b>Walking through the Results.txt:</b><br>

1)  It will print console output for each executed step.<br>
2)  API response verification (status code) can be done and validated against the user expectation by using Assertions.<br>
3)  When the user reaches the step "I have retrieved the number of days and dates where the temperature is predicted to be above '20' degree Celsius"
    i) Firstly, it will display all records with S.No, Country, City, DateTime and Temperature
    ii) Secondly, it will display only records which meet users criteria (for eg >= 20 deg Celsius). It is easy for the user to validate what data is coming from the API and what data filtered out.<br>
4)  when a user reaches "I also retrieved how many days it is predicted to be 'Clouds' in the same time period"
    i) Firstly, it will display all records with S.No, Country, City, DateTime and Weather Condition
    ii) Secondly, it will display only records which meet users criteria (for eg == Clear). It is easy for the user to validate what data is coming from the API and what data filtered out.<br>
5)  Similarly, it will give a count for #How many days are going to be Clouds (user-defined weather condition it can be Clear, Clouds, Rain etc) 17 and #Number of days the city temperature is greater than or equal to 20 (user-defined value in Celsius) is 3.<br>
