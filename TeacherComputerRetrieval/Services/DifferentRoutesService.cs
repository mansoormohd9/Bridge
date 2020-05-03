using System;
using System.Collections.Generic;
using System.Text;
using TeacherComputerRetrieval.Models;

namespace TeacherComputerRetrieval.Services
{
    public class DifferentRoutesService
    {
        private Dictionary<char, Dictionary<char, int>> AdjacentAcademyMap { get; }

        public DifferentRoutesService(Dictionary<char, Dictionary<char, int>> adjacentAcademyMap)
        {
            AdjacentAcademyMap = adjacentAcademyMap;
        }

        public int GetDifferentRoutesFromStartToEnd(char start, char end, RoutesFilter filters)
        {
            if (filters.MaxStops != 0)
            {
                return MaxStops(start, end, filters.MaxStops);
            } 
            
            if (filters.Stops != 0)
            {
                return Stops(start, end, filters.Stops);
            }

            if (filters.MaxDistance != 0)
            {
                return MaxDistance(start, end, filters.MaxDistance);
            }

            return Distance(start, end, filters.Distance);
        }

        private int MaxStops(char start, char end, int maxStops)
        {
            if (maxStops == 0)
            {
                return 0;
            }

            var adjacentAcademies = AdjacentAcademyMap[start];
            var result = 0;
            foreach (var academy in adjacentAcademies)
            {
                if (academy.Key != end)
                {
                    result = result + MaxStops(academy.Key, end, maxStops-1);
                }
                else
                {
                    result++;
                }
            }

            return result;
        }

        private int MaxDistance(char start, char end, int maxDistance)
        {
            if (maxDistance <= 0)
            {
                return 0;
            }

            var adjacentAcademies = AdjacentAcademyMap[start];
            var result = 0;
            foreach (var academy in adjacentAcademies)
            {
                var nextValue = maxDistance - academy.Value;
                if (academy.Key == end && nextValue > 0)
                {
                    result++;
                }
                result = result + MaxDistance(academy.Key, end, nextValue);
            }

            return result;
        }

        private int Stops(char start, char end, int stops)
        {
            if (stops < 0)
            {
                return 0;
            }

            var adjacentAcademies = AdjacentAcademyMap[start];
            var result = 0;
            foreach (var academy in adjacentAcademies)
            {
                if (academy.Key == end && stops == 0)
                {
                    result++;
                }
                else
                {
                    result = result + Stops(academy.Key, end, stops - 1);
                }
            }

            return result;
        }

        private int Distance(char start, char end, int distance)
        {
            if (distance < 0)
            {
                return 0;
            }

            var adjacentAcademies = AdjacentAcademyMap[start];
            var result = 0;
            foreach (var academy in adjacentAcademies)
            {
                var nextValue = distance - academy.Value;
                if (academy.Key == end && nextValue == 0)
                {
                    result++;
                }
                else
                {
                    result = result + Distance(academy.Key, end, nextValue);
                }
            }

            return result;
        }
    }
}
