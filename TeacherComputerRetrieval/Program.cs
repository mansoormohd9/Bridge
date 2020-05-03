using System;
using TeacherComputerRetrieval.Helpers;

namespace TeacherComputerRetrieval
{
    class Program
    {
        static void Main(string[] args)
        {
            var sampleDataBuilder = new BuildSampleData();
            //Get sample data from user and computing neighbor matrix
            var adjacentAcademyMap = sampleDataBuilder.GetSampleDataFromUser();

            var userInputHelper = new UserInputHelper(adjacentAcademyMap);
            //Lets user choose appropriate module and helps him out with his selection.
            userInputHelper.ModuleChooser();
        }
    }
}
