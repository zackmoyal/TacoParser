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
        const double MetersToMiles = 0.00062137;

        static void Main(string[] args)
        {
            // Objective: Find the two Taco Bells that are the farthest apart from one another.
            // Some of the TODO's are done for you to get you started. 

            logger.LogInfo("Log initialized. . .");

            // Use File.ReadAllLines(path) to grab all the lines from your csv file. 
            // Optional: Log an error if you get 0 lines and a warning if you get 1 line
            var lines = File.ReadAllLines(csvPath);
            if (lines.Length == 0)
            {
                logger.LogError("File has no input.");
            }

            if(lines.Length == 1)
            {
                logger.LogWarning("File only has one line of input.");
            }

            // This will display the first item in your lines array
            logger.LogInfo($"Lines: {lines[0]}");

            // Create a new instance of your TacoParser class
            var parser = new TacoParser();

            // Use the Select LINQ method to parse every line in lines collection
            var locations = lines.Select(line => parser.Parse(line)).ToArray();

            // Complete the Parse method in TacoParser class first and then START BELOW ----------

            // TODO -- DONE: Create two `ITrackable` variables with initial values of `null`. 
            // These will be used to store your two Taco Bells that are the farthest from each other.
            ITrackable tacoBell1 = null;
            ITrackable tacoBell2 = null;

            // TODO -- DONE: Create a `double` variable to store the distance
            double finalDistance = 0;

            // TODO -- DONE: Add the Geolocation library to enable location comparisons: using GeoCoordinatePortable;
            // Look up what methods you have access to within this library.

            // NESTED LOOPS SECTION----------------------------
            
            // FIRST FOR LOOP -
            // TODO -- DONE: Create a loop to go through each item in your collection of locations.
            // This loop will let you select one location at a time to act as the "starting point" or "origin" location.
            // Naming suggestion for variable: `locA`
            for (int i = 0; i < locations.Length; i++)
            {
                var locA = locations[i];

                // TODO -- DONE: Once you have locA, create a new Coordinate object called `corA` with your locA's latitude and longitude.
                var corA = new GeoCoordinate();
                corA.Latitude = locA.Location.Latitude;
                corA.Longitude = locA.Location.Longitude;

                // SECOND FOR LOOP -
                // TODO -- DONE: Now, Inside the scope of your first loop, create another loop to iterate through locations again.
                // This allows you to pick a "destination" location for each "origin" location from the first loop. 
                // Naming suggestion for variable: `locB`
                for (int j = 0; j < locations.Length; j++)
                {
                    var locB = locations[j];
                    var corB = new GeoCoordinate();

                    // TODO -- DONE: Once you have locB, create a new Coordinate object called `corB` with your locB's latitude and longitude.
                    corB.Latitude = locB.Location.Latitude;
                    corB.Longitude = locB.Location.Longitude;

                    // TODO -- DONE: Now, still being inside the scope of the second for loop, compare the two locations using `.GetDistanceTo()` method, which returns a double.
                    // If the distance is greater than the currently saved distance, update the distance variable and the two `ITrackable` variables you set above.
                    var testDistance = corA.GetDistanceTo(corB);

                    if (testDistance > finalDistance)
                    {
                        finalDistance = corA.GetDistanceTo(corB);
                        tacoBell1 = locA;
                        tacoBell2 = locB;
                    }
                }
            }

            // NESTED LOOPS SECTION COMPLETE ---------------------

            // Once you've looped through everything, you've found the two Taco Bells farthest away from each other.
            // TODO -- DONE: Display these two Taco Bell locations to the console.
            logger.LogInfo($"{tacoBell1.Name} and {tacoBell2.Name} are the furthest apart.");
            Console.WriteLine($"The total distance is {Math.Round((finalDistance * MetersToMiles), 2)} miles.");

        }
    }
}
