using System;
using System.Linq;

namespace TeacherComputerRetrieval.Helpers
{
    class BuildSampleData
    {
        public void GetSampleDataFromUser()
        {
            Console.WriteLine(@"Hey! Welcome to Teacher Computer Retreival Helper Module. Please provide sample input to continue with.
            The Input should be in format of comma separated ABC strings where A->Start Academy, B->End Academy, C->Distance between start 
            and end academies");

            var academiesTupleList = Console.ReadLine()
                .Split(',')
                .Select(x => x.Trim());
        }

        public void ComputeAcadamiesNeigbourMatrix()
        {
            
        }
    }
}