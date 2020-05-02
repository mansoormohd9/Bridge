using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TeacherComputerRetrieval.Helpers;

namespace TeacherComputerRetrieval.Tests.Helpers
{
    [TestFixture]
    public class BuildSampleDataTests
    {
        private BuildSampleData _buildSampleData;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _buildSampleData = new BuildSampleData();
        }

        [Test]
        [Description("Valid: ComputeAdjacentAcademiesList with valid tuples")]
        public void ComputeAdjacentAcademiesListWithValidTuples()
        {
            var academiesTupleList = new List<string> {
                "AB5",
                "BC4",
                "AD5"
            };
            var actualOutput = _buildSampleData.ComputeAdjacentAcademiesList(academiesTupleList);
            var expectedOutput = new Dictionary<char, Dictionary<char, int>>{
                {
                    'A', new Dictionary<char, int> {
                        {
                            'B', 5
                        },
                        {
                            'D', 5
                        }
                    }
                },
                {
                    'B', new Dictionary<char, int> {
                        {
                            'C', 4
                        }
                    }
                }
            };

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
    }
}