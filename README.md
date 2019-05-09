# CityWeatherReport

Open the solution in VS.

The solution contains two project WeatherService and WeatherService.UnitTest

Build the solution

Run the WeatherService project

~http://localhost:portNumber/api/Weather/City/cityId

eg: ~http://localhost:portNumber/api/Weather/City/2988507

cityId could be any of the below given id:
2643741=City of London

2988507=Paris

2964574=Dublin

4229546=Washington

5128581=New York

1273294=Delhi

1275339=Mumbai

6539761=Rome

2950159=Berlin

292223=Dubai

As in the above eg. mentioned,by surfing through the above url, weather report related to city=Paris will be stored in the outputfolder with name WeatherReport_Paris_{Today's date}.
For different Id's the outputfolders will be different.
With the date in the outputfile we acn maintain the historic data as well.

