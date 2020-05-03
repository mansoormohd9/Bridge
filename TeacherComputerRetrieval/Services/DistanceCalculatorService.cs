using System.Collections.Generic;

namespace TeacherComputerRetrieval.Services
{
    public class DistanceCalculatorService
    {
        private Dictionary<char, Dictionary<char, int>> AdjacentAcademyMap { get; }

        public DistanceCalculatorService(Dictionary<char, Dictionary<char, int>> adjacentAcademyMap)
        {
            AdjacentAcademyMap = adjacentAcademyMap;
        }

        public int GetDistanceAlongRoute(List<char> routeList)
        {
            var result = 0;
            var routeExists = true;
            
            for (var routeIterator = 0; routeIterator < routeList.Count-1; routeIterator++)
            {
                var currentAcademy = routeList[routeIterator];
                var nextAcademy = routeList[routeIterator+1];
                if (AdjacentAcademyMap.ContainsKey(currentAcademy) &&
                    AdjacentAcademyMap[currentAcademy].ContainsKey(nextAcademy))
                {
                    result += AdjacentAcademyMap[currentAcademy][nextAcademy];
                }
                else
                {
                    routeExists = false;
                    break;
                }
            }

            return routeExists ? result : -1;
        }
    }
}
