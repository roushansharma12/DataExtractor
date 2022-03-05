namespace DataExtractor.Model
{
    public class CsvColumns
    {
        public string ISIN { get; set; }
        public string CFICode { get; set; }
        public string Venue { get; set; }
    }

    public class CsvReadColumns : CsvColumns
    {
        public string AlgoParams { get; set; }
    }

    public class CsvWriteColumns : CsvColumns
    {
        public double ContractSize { get; set; }
    }
}
