using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TeacherComputerRetrieval.Models;
using TeacherComputerRetrieval.Services;
using TeacherComputerRetrieval.Tests.TestData;
using TeacherComputerRetrieval.Tests.TestUtils;

namespace TeacherComputerRetrieval.Tests.Services
{
    class DifferentRoutesServiceTests
    {
        private Dictionary<char, Dictionary<char, int>> _adjacentAcademyMap;
        private DifferentRoutesService _differentRoutesService;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _adjacentAcademyMap = new TestHelper().BuildSampleDataForTest();
            _differentRoutesService = new DifferentRoutesService(_adjacentAcademyMap);
        }

        [TestCaseSource(typeof(TestDataClass), nameof(TestDataClass.DifferentRoutesValidCases))]
        [Description("Valid: DifferentRoutesService valid cases wherein route exists")]
        public int TestDifferentRoutesServiceWithValidCases(char start, char end, RoutesFilter filters)
        {
            //Invoke and assert
            return _differentRoutesService.GetDifferentRoutesFromStartToEnd(start, end, filters);
        }
    }
}
