# TestAutomation.OpeweatherMapApi

<b>Prerequesite:</b><br>
•	VisualStudio 2012/15/17/19.
•	I have used Visual Studio 2017 Community Edition to develop the code.
•	Installation Steps : https://visualstudio.microsoft.com/downloads/

<b>Pacakges Installation Steps and guidelines:</b>
•	I have used Specflow, Nunit3, Newtonsoft.Json and Console Tables Packages to build the project.<br>
•	Follow Specflow Installation guidelines from : https://www.nuget.org/packages/SpecFlow/<br>
•	Follow Nunit Installation guidelines from : https://www.nuget.org/packages/NUnit/<br>
•	Folllow Console Tables Indtallation guidelines from : https://www.nuget.org/packages/ConsoleTables/<br>
•	Folllow Newtonsoft.Json Indtallation guidelines from : https://www.nuget.org/packages/Newtonsoft.Json/<br>

Please add reference "System.Net.Http" Reference to the project (if not already added into the project).

<b>Deep Insughts into Project and Test Scenario:</b>
<b>Feature to automate:</b>
As a weather enthusiast I would like to know the number of days in Sydney where the temperature is predicated to be above 20 degrees 
(at the time of calling the API) in the next 5 days, (from the current days date).<br>
I would also like to know how many days it is predicted to be sunny in the same time period.<br>

<b>Solution:</b><br>
•	I have used Specflow to write test steps in BDD fashion so that it is easily understandable to everyone.<br>
•	App.config used to set base url and appid. Config file is handy and easy to modify if any changes occured.<br>
•	Weather forecast for City, country is not hard coded so it is dynamic to handle any request (any city, country).<br>
•	As temperature and weather type parameterized frp, Specflow, User can easily modify values and get accurate responses from API.<br>
•	User has the flexibility to enter temperature in cesius rather in kelvin format (API will always return in Kelvin format). <br>

<b>Results:</b><br>
•	The test is working as expected and added dynamic classes for more generalized solution.<br>
•	I have attached the Results.txt in the same repository. <br>

<b>Walking through the Results.txt:</b><br>
1) It will print console output for each executed step.<br>
2) API response verification (status code) can be done and validated against the user expectation by using Assetions.<br>
3) When user reaches to the step "I have retrieved the number of days and dates where the temperature is predicated to be above '20' degree celsius"<br>
    i) Firstly, it will displays all records with S.No, Country, City, DateTime and Temperature<br>
    ii) Secondly, it will display only records which meets users criteria (for eg >= 20 deg celsius). It is easy for user to validate what data is comimg from the API and what data filtered out.<br>
4) when user reaches to "I also retrieved  how many days it is predicted to be 'Clouds' in the same time period"<br>
    i) Firstly, it will displays all records with S.No, Country, City, DateTime and Weather Condition<br>
    ii) Secondly, it will display only records which meets users criteria (for eg == Clear). It is easy for user to validate what data is comimg from the API and what data filtered out.<br>
5) Similarly, it will give count for #How many days are going to be Clouds (user defined weather condition it can be Clear, Clouds, Rain etc) 17 and #Number of days the city temperature is greater than or equal to 20 (user defined value in celsius) is 3.<br>

