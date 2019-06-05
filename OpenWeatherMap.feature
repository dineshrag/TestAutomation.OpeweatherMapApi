Feature: OpenWeatherMap
As a weather enthusiast I would like to know the number of days in Sydney where the temperature is predicated to be above 20 degrees 
(at the time of calling the API) in the next 5 days, (from the current days date).
I would also like to know how many days it is predicted to be sunny in the same time period.


Scenario: WeatherPredictionsndValidation
	Given I have OpenWeatgerMap API Base url and app id
	And I would like to know weather forecast for country 'au' and city 'sydney'
	When I have executed get method
	Then I can see i recieved '200' status code
	And I have retrieved the number of days and dates where the temperature is predicated to be above '20' degree celsius
	And I also retrieved  how many days it is predicted to be 'Clouds' in the same time period

