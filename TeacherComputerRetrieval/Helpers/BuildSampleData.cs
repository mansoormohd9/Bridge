using System;
using System.Collections.Generic;
using System.Linq;

namespace TeacherComputerRetrieval.Helpers
{
    public class BuildSampleData
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

        public Dictionary<char, Dictionary<char, int>> ComputeAdjacentAcademiesList(List<string> academiesTupleList)
        {
            var adjacentAcademiesDict = new Dictionary<char, Dictionary<char, int>>();
            foreach(var academyTuple in academiesTupleList) {
                var start = academyTuple[0];
                var end = academyTuple[1];
                var distance = academyTuple[2];
                if(adjacentAcademiesDict.ContainsKey(start)) {
                    if(adjacentAcademiesDict[start].ContainsKey(end)) {
                        throw new Exception("Duplicate tuple found");
                    } else {
                        adjacentAcademiesDict[start].Add(end, distance);
                    }
                } else {
                    adjacentAcademiesDict.Add(start, new Dictionary<char, int>{{ end, distance}});
                }
            }
            return adjacentAcademiesDict;
        }
    }
}