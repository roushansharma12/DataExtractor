using DataExtractor;
using DataExtractor.Model;
using NUnit.Framework;

namespace NUnitTestDataExtractor
{
    public class Tests
    {
        private IFileModify<CsvReadColumns> csvModify;
        [SetUp]
        public void Setup()
        {
            csvModify = new CsvModify();
        }

        [Test]
        public void ReadCsvTest()
        {
            var readedRecords = csvModify.Read("C:\\Users\\Administrator\\Documents\\ISS_Mumbai__C#,_.Net_Developer_-_Mumbai_(JR_1488)\\DataExtractor_Example_Input.csv", 2);
            Assert.That(readedRecords.Count > 0);
        }
    }
}