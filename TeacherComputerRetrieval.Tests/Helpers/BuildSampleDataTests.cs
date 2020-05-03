using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TeacherComputerRetrieval.Helpers;
using TeacherComputerRetrieval.Tests.TestUtils;

namespace TeacherComputerRetrieval.Tests.Helpers
{
    [TestFixture]
    public class BuildSampleDataTests
    {
        private BuildSampleData _buildSampleData;
        private TestHelper _testHelper;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _buildSampleData = new BuildSampleData();
            _testHelper = new TestHelper();
        }

        [Test]
        [Description("Valid: ComputeAdjacentAcademiesList with valid tuples")]
        public void ComputeAdjacentAcademiesListWithValidTuples()
        {
            //Setup
            var academiesTupleList = new List<string> {
                "AB5", "BC4", "CD8", "DC8", "DE6", "AD5", "CE2", "EB3", "AE7"
            };
            var expectedOutput = _testHelper.BuildSampleDataForTest();

            //Invoke
            var actualOutput = _buildSampleData.ComputeAdjacentAcademiesList(academiesTupleList);

            //Assert
            Assert.That(actualOutput.Keys.Count, Is.EqualTo(expectedOutput.Keys.Count));
            Console.WriteLine(expectedOutput);
            CompareData(actualOutput, expectedOutput);
        }

        private void CompareData(Dictionary<char, Dictionary<char, int>> actOutput, Dictionary<char, Dictionary<char, int>> expOutput)
        {
            foreach(var dictKey in actOutput)
            {
                CollectionAssert.AreEqual(actOutput[dictKey.Key], expOutput[dictKey.Key]);
            }
        }

        [Test]
        [Description("Invalid: ComputeAdjacentAcademiesList with duplicate tuples")]
        public void ComputeAdjacentAcademiesListWithDuplicateTuples()
        {
            //Setup
            var academiesTupleList = new List<string> {
                "AB5", "BC4", "AB8", "DC8", "DE6", "AD5", "CE2", "EB3", "AE7"
            };
            
            //Assert
            Assert.Throws<Exception>(() => _buildSampleData.ComputeAdjacentAcademiesList(academiesTupleList));
        }
    }
}