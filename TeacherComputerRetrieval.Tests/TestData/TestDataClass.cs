using System;
using System.Collections;
using NUnit.Framework;
using TeacherComputerRetrieval.Models;

namespace TeacherComputerRetrieval.Tests.TestData
{
    public class TestDataClass
    {
        public static IEnumerable DistanceCalculatorValidCases
        {
            get
            {
                yield return new TestCaseData("A-B-C").Returns(9);
                yield return new TestCaseData("A-E-B-C-D").Returns(22);
            }
        }

        public static IEnumerable DistanceCalculatorInValidCases
        {
            get
            {
                yield return new TestCaseData("A-E-D").Returns("NO SUCH ROUTE");
            }
        }

        public static IEnumerable ShortestRouteValidCases
        {
            get
            {
                yield return new TestCaseData('A', 'C').Returns(9);
                yield return new TestCaseData('B', 'B').Returns(9);
                yield return new TestCaseData('A', 'D').Returns(5);
            }
        }

        public static IEnumerable DifferentRoutesValidCases
        {
            get
            {
                yield return new TestCaseData('C', 'C', new RoutesFilter{ MaxStops = 3 }).Returns(2);
                yield return new TestCaseData('C', 'C', new RoutesFilter{ MaxStops = 4 }).Returns(3);
                yield return new TestCaseData('A', 'C', new RoutesFilter{ Stops = 4 }).Returns(3);
                yield return new TestCaseData('E', 'C', new RoutesFilter{ Distance = 7 }).Returns(1);
            }
        }
    }
}
