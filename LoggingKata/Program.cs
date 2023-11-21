using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            // Objective: Find the two Taco Bells that are the furthest apart from one another.
            // Some of the TODO's are done for you to get you started. 

            logger.LogInfo("Log initialized");

            // Use File.ReadAllLines(path) to grab all the lines from your csv file. 
            // Optional: Log an error if you get 0 lines and a warning if you get 1 line
            var lines = File.ReadAllLines(csvPath);

            // This will display the first item in your lines array
            logger.LogInfo($"Lines: {lines[0]}");

            // Create a new instance of your TacoParser class
            var parser = new TacoParser();

            // Use the Select LINQ method to parse every line in lines collection
            var locations = lines.Select(parser.Parse).ToArray();

  
            // Complete Parse method in TacoParser class and then START BELOW ----------

            // TODO: Create two `ITrackable` variables with initial values of `null`. These will be used to store your two Taco Bells that are the furthest from each other.
            // TODO: Create a `double` variable to store the distance

            // TODO: Add the Geolocation library to enable location comparisons: using GeoCoordinatePortable;
            // Look up what methods you have access to within this library

            // NESTED LOOPS SECTION----------------------------
            
            // FIRST FOR LOOP - 
            // TO DO: Make a loop to iterate through your locations collection.  
            // This will allow you to grab each location as the "origin" location (naming suggestion for variable: `locA`)

            // TODO: Create a new Coordinate called `corA` with your locA's latitude and longitude

            // SECOND FOR LOOP - 
            // TODO: Now, create another loop to iterate through locations within the scope of your first loop, so you can grab the "destination" location (naming suggestion for variable: `locB`)

            // TODO: Create a new Coordinate with your locB's latitude and longitude

            // TODO: Now, still being inside the scope of the second for loop, compare the two locations using `.GetDistanceTo()` method, which returns a double
            // If the distance is greater than the currently saved distance, update the distance variable and the two `ITrackable` variables you set above

            // NESTED LOOPS SECTION COMPLETE ---------------------

            // Once you've looped through everything, you've found the two Taco Bells farthest away from each other.
            // Display these two Taco Bell locations to the console.


            
        }
    }
}
