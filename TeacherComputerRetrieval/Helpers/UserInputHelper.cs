using System;
using System.Collections.Generic;
using System.Linq;
using TeacherComputerRetrieval.Models;
using TeacherComputerRetrieval.Services;

namespace TeacherComputerRetrieval.Helpers
{
    class UserInputHelper
    {
        private Dictionary<char, Dictionary<char, int>> AdjacentAcademyMap { get; }

        public UserInputHelper(Dictionary<char, Dictionary<char, int>> adjacentAcademyMap)
        {
            AdjacentAcademyMap = adjacentAcademyMap;
        }
        public void ModuleChooser()
        {
            Console.WriteLine(@"Please choose an appropriate module from below to continue
                            1.Distance along certain routes.
                            2.Number of different routes between two academies.
                            3.Shortest route between two academies.");
            
            var userSelection = Console.ReadLine();
            switch(userSelection){
                case "1":
                    HandleDistanceCalculatorModule();
                    break;
                case "2":
                    HandleDifferentRoutesModule();
                    break;
                case "3":
                    HandleShortestRouteModule();
                    break;
                default:
                    Console.WriteLine("Invalid Selection. Please try again.");
                    break;
            }
        }

        public void HandleDistanceCalculatorModule()
        {
            Console.WriteLine("Please provide hyphen separated academies. A-B-C for an example");
            var userInput = Console.ReadLine();
            var academiesRoute = userInput.Split('-').Select(x => x.Trim()[0]).ToList();

            var distanceAlongRoute = new DistanceCalculatorService(AdjacentAcademyMap).GetDistanceAlongRoute(academiesRoute);

            Console.WriteLine($"Distance of the route {userInput} is {(distanceAlongRoute == -1 ? "NO SUCH ROUTE" : distanceAlongRoute.ToString())}");
        }

        public void HandleDifferentRoutesModule()
        {
            Console.WriteLine("Please enter start academy");
            var start = Console.ReadLine();
            Console.WriteLine("Please enter end academy");
            var end = Console.ReadLine();
            Console.WriteLine(@"Would you like to provide any filter from following? Press Enter to continue without filter:
                    1.Max Stops
                    2.Stops
                    3.Max Distance
                    4.Distance");
            var userFilter = Console.ReadLine();
            var routesFilter = new RoutesFilter();
            if (userFilter != "")
            {
                int filterValue;
                switch (userFilter)
                {
                    case "1":
                        Console.WriteLine("Please enter MaxStops required:");
                        filterValue = Convert.ToInt32(Console.ReadLine());
                        routesFilter.MaxStops = filterValue;
                        break;
                    case "2":
                        Console.WriteLine("Please enter exact stops required");
                        filterValue = Convert.ToInt32(Console.ReadLine());
                        routesFilter.Stops = filterValue;
                        break;
                    case "3":
                        Console.WriteLine("Please enter MaxDistance required:");
                        filterValue = Convert.ToInt32(Console.ReadLine());
                        routesFilter.MaxDistance = filterValue;
                        break;
                    case "4":
                        Console.WriteLine("Please enter exact distance required:");
                        filterValue = Convert.ToInt32(Console.ReadLine());
                        routesFilter.Distance = filterValue;
                        break;
                    default:
                        Console.WriteLine("Invalid Selection.Please try again.");
                        break;
                }
            }

            var differentRoutes = new DifferentRoutesService(AdjacentAcademyMap).GetDifferentRoutesFromStartToEnd(start[0], end[0], routesFilter);

            Console.WriteLine($"Different possible routes from {start} to {end} is {(differentRoutes == -1 ? "NO SUCH ROUTE" : differentRoutes.ToString())}");
        }

        public void HandleShortestRouteModule()
        {
            Console.WriteLine("Please enter start academy");
            var start = Console.ReadLine()[0];
            Console.WriteLine("Please enter end academy");
            var end = Console.ReadLine()[0];

            var shortestPath = new ShortestRouteService(AdjacentAcademyMap).GetShortestRouteFromStartToEnd(start, end);

            Console.WriteLine($"Shortest Path from {start} to {end} is {(shortestPath == -1 ? "NO SUCH ROUTE" : shortestPath.ToString())}");
        }
    }
}