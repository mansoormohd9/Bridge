using System;
using TeacherComputerRetrieval.Helpers;

namespace TeacherComputerRetrieval
{
    class Program
    {
        static void Main(string[] args)
        {
            var sampleDataBuilder = new BuildSampleData();
            //Get sample data from user and computing neighbour matrix
            sampleDataBuilder.GetSampleDataFromUser();

            var userInputHelper = new UserInputHelper();
            //Lets user choose appropriate module and helps him out with his selection.
            userInputHelper.ModuleChooser();
        }
    }
}
