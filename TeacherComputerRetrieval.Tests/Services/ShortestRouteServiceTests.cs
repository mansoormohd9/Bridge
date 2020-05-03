using System.Collections.Generic;
using NUnit.Framework;
using TeacherComputerRetrieval.Services;
using TeacherComputerRetrieval.Tests.TestData;
using TeacherComputerRetrieval.Tests.TestUtils;

namespace TeacherComputerRetrieval.Tests.Services
{
    [TestFixture]
    class ShortestRouteServiceTests
    {
        private Dictionary<char, Dictionary<char, int>> _adjacentAcademyMap;
        private ShortestRouteService _shortestRouteService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _adjacentAcademyMap = new TestHelper().BuildSampleDataForTest();
            _shortestRouteService = new ShortestRouteService(_adjacentAcademyMap);
        }

        [TestCaseSource(typeof(TestDataClass), nameof(TestDataClass.ShortestRouteValidCases))]
        [Description("Valid: ShortestRouteService valid cases wherein route exists")]
        public int TestShortestRouteServiceWithValidCases(char start, char end)
        {
            //Invoke and assert
            return _shortestRouteService.GetShortestRouteFromStartToEnd(start, end);
        }
    }
}
