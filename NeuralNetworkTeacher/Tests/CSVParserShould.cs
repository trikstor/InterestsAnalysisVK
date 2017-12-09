using System.Collections.Generic;
using System.IO;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace NeuralNetworkTeacher.Tests
{
    [TestFixture]
    public class CSVParserShould
    {
        private CSVParser Parser;
        [SetUp]
        public void SetUp()
        {
            Parser = new CSVParser();
        }
        
        [Test]
        public void GiveCorrectParsedData()
        {
            var expected = new Dictionary<string, IList<string>>
            {
                {"aaaa", new List<string>{"aaa;bbb", "aaa bbb", "cccddd"}},
                {"bbbb", new List<string>{"aaa;bbb1", "aaa bbb1", "cccddd1"}},
                {"cccc", new List<string>{"aaa;bbb2", "aaa bbb2", "cccddd2"}}
            };
            var path = Path.Combine("...test_interest.csv");
            Parser.Parse(path).Should().BeEquivalentTo(expected);
        }
    }
}