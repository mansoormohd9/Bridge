using System;

namespace TeacherComputerRetrieval
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"Please make an appropriate selection from below to continue
                            1.Distance along certain routes.
                            2.Number of different routes between two academies.
                            3.Shortest route between two academies.");
            
            var userSelection = Console.ReadLine();
            switch(userSelection){
                case "1":
                    //do
                    break;
                case "2":
                    //do
                    break;
                case "3":
                    //do
                    break;
                default:
                    Console.WriteLine("Invalid Selection. Please try again.");
                    break;
            }
        }
    }
}
