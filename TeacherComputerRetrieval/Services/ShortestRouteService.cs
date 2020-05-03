using System.Collections.Generic;

namespace TeacherComputerRetrieval.Services
{
    public class ShortestRouteService
    {
        private Dictionary<char, Dictionary<char, int>> AdjacentAcademyMap { get; }
        private HashSet<char> _selectedAcademiesMap;
        private Dictionary<char, int> _distanceFromSelectedAcademy;

        public ShortestRouteService(Dictionary<char, Dictionary<char, int>> adjacentAcademyMap)
        {
            AdjacentAcademyMap = adjacentAcademyMap;
        }

        //Dijkstra Algorithm
        public int GetShortestRouteFromStartToEnd(char start, char end)
        {
            _selectedAcademiesMap = new HashSet<char>();
            _distanceFromSelectedAcademy = new Dictionary<char, int>();

            //setting up initial data required
            var academiesList = AdjacentAcademyMap.Keys;
            var selectedAcademy = start;
            _selectedAcademiesMap.Add(start);
            foreach (var academy in academiesList)
            {
                _distanceFromSelectedAcademy.Add(academy,
                    AdjacentAcademyMap[selectedAcademy].ContainsKey(academy)
                        ? AdjacentAcademyMap[selectedAcademy][academy]
                        : int.MaxValue);
            }
            var shortestDistance = GetShortestRoute(GetNextSelectedAcademy(), end);
            if (shortestDistance == -1 && start == end)//Handling same start and end
            {
                return GetShortestDistanceForSameStartAndEnd(end);
            }

            return shortestDistance;
        }

        private int GetShortestDistanceForSameStartAndEnd(char end)
        {
            int min = int.MaxValue;

            foreach (var academy in _selectedAcademiesMap)
            {
                if (AdjacentAcademyMap[academy].ContainsKey(end) && academy != end &&
                    _distanceFromSelectedAcademy[academy] + AdjacentAcademyMap[academy][end] < min)
                {
                    min = _distanceFromSelectedAcademy[academy] + AdjacentAcademyMap[academy][end];
                }
            }

            return min;
        }

        private char GetNextSelectedAcademy()
        {
            var min = int.MaxValue;
            char nextAcademy = '\0';

            foreach (var academy in _distanceFromSelectedAcademy)
            {
                if (!_selectedAcademiesMap.Contains(academy.Key) && academy.Value < min)
                {
                    min = academy.Value;
                    nextAcademy = academy.Key;
                }
            }

            return nextAcademy;
        }

        private int GetShortestRoute(char start, char end)
        {
            if (start == end)
            {
                return _distanceFromSelectedAcademy[start];
            }
            _selectedAcademiesMap.Add(start);

            var adjacentAcademies = AdjacentAcademyMap[start];

            foreach (var academy in adjacentAcademies)
            {
                var curDistance = _distanceFromSelectedAcademy[academy.Key];
                var distanceFromCurSelAcademy = _distanceFromSelectedAcademy[start] + academy.Value;
                if (!_selectedAcademiesMap.Contains(academy.Key) && distanceFromCurSelAcademy < curDistance)
                {
                    _distanceFromSelectedAcademy[academy.Key] = distanceFromCurSelAcademy;
                }
            }

            var nextAcademy = GetNextSelectedAcademy();
            if (nextAcademy == '\0')
            {
                return -1;
            }
            return GetShortestRoute(GetNextSelectedAcademy(), end);
        }
    }
}
