using System;

namespace TeacherComputerRetrieval.Helpers
{
    class UserInputHelper
    {
        public void ModuleChooser()
        {
            Console.WriteLine(@"Please choose an appropriate module from below to continue
                            1.Distance along certain routes.
                            2.Number of different routes between two academies.
                            3.Shortest route between two academies.");
            
            var userSelection = Console.ReadLine();
            switch(userSelection){
                case "1":
                    Console.WriteLine("Please provide hyphen seperated academies. A-B-C for an example");
                    var academiesRoute = Console.ReadLine();
                    break;
                case "2":
                    Console.WriteLine("Please enter start academy");
                    var start = Console.ReadLine();
                    Console.WriteLine("Please enter end academy");
                    var end = Console.ReadLine();
                    Console.WriteLine(@"Would you like to provide any filter from following:
                    1.Min Stops
                    2.Max Stops
                    3.Stops
                    4.Min Distance
                    5.Max Distance
                    6.Distance");
                    var userFilter = Console.ReadLine();
                    break;
                case "3":
                    //do
                    break;
                default:
                    Console.WriteLine("Invalid Selection. Please try again.");
                    break;
            }
        }

        public void DistanceCalculator()
        {

        }

        public void GetDifferentRoutes()
        {

        }

        public void GetShortestRoute()
        {
            
        }
    }
}