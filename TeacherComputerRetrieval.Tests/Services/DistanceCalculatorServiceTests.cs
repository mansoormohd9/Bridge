using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TeacherComputerRetrieval.Services;
using TeacherComputerRetrieval.Tests.TestData;
using TeacherComputerRetrieval.Tests.TestUtils;

namespace TeacherComputerRetrieval.Tests.Services
{
    [TestFixture]
    class DistanceCalculatorServiceTests
    {
        private Dictionary<char, Dictionary<char, int>> _adjacentAcademyMap;
        private DistanceCalculatorService _distanceCalculatorService;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _adjacentAcademyMap = new TestHelper().BuildSampleDataForTest();
            _distanceCalculatorService = new DistanceCalculatorService(_adjacentAcademyMap);
        }

        [TestCaseSource(typeof(TestDataClass), nameof(TestDataClass.DistanceCalculatorValidCases))]
        [Description("Valid: DistanceCalculatorService valid cases wherein route exists")]
        public int TestDistanceCalculatorServiceWithValidCases(string route)
        {
            //Setup
            var routeList = route.Split('-').Select(x => x.Trim()[0]).ToList();

            //Invoke and assert
            return _distanceCalculatorService.GetDistanceAlongRoute(routeList);
        }

        [TestCaseSource(typeof(TestDataClass), nameof(TestDataClass.DistanceCalculatorInValidCases))]
        [Description("InValid: DistanceCalculatorService valid cases wherein route doesn't exists")]
        public string TestDistanceCalculatorServiceWithInvalidCases(string route)
        {
            //Setup
            var routeList = route.Split('-').Select(x => x.Trim()[0]).ToList();

            //Invoke and assert
            return _distanceCalculatorService.GetDistanceAlongRoute(routeList) == -1 ? "NO SUCH ROUTE" : "Wrong Result";
        }
    }
}
