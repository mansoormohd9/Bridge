using System.Collections.Generic;

namespace TeacherComputerRetrieval.Tests.TestUtils
{
    public class TestHelper
    {
        public Dictionary<char, Dictionary<char, int>> BuildSampleDataForTest()
        {
            var sampleData = new Dictionary<char, Dictionary<char, int>>{
                {
                    'A', new Dictionary<char, int> {
                        {
                            'B', 5
                        },
                        {
                            'E', 7
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
                },
                {
                    'C', new Dictionary<char, int> {
                        {
                            'E', 2
                        },
                        {
                            'D', 8
                        }
                    }
                },
                {
                    'D', new Dictionary<char, int> {
                        {
                            'C', 8
                        },
                        {
                            'E', 6
                        }
                    }
                },
                {
                    'E', new Dictionary<char, int> {
                        {
                            'B', 3
                        }
                    }
                }
            };

            return sampleData;
        }
    }
}
