using CsvHelper;
using DataExtractor.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Linq;
using CsvHelper.Configuration;

namespace DataExtractor
{
    public class CsvModify : IFileModify<CsvReadColumns>
    {
        public List<CsvReadColumns> Read(string path, int headerAt = 1)
        {
            var result = new List<CsvReadColumns>();
            try
            {
                using (var reader = new StreamReader(path))
                {
                    for (int i = 1; i < headerAt; i++)
                    {
                        reader.ReadLine();
                    }
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        return csv.GetRecords<CsvReadColumns>().ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return result;
            }
            
        }

        public void Write(string path, List<CsvReadColumns> listData)
        {
            try
            {
                var records = listData.Select(s => new CsvWriteColumns { ISIN = s.ISIN, CFICode = s.CFICode, Venue = s.Venue, ContractSize = ParseContractSize(s.AlgoParams) });
                using (var writer = new StreamWriter(path))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<CsvWriteColumnsMap>();
                    csv.WriteRecords(records);
                    Console.WriteLine("Cleaned: " + path);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        private double ParseContractSize(string inputVal)
        {
            double rtnVal = 0;
            double.TryParse(inputVal.Split("|;")?.FirstOrDefault(f => f.ToLower().Contains("PriceMultiplier".ToLower()))?.Split(":")[1], out rtnVal);
            return rtnVal;
        }
    }

    class CsvWriteColumnsMap : ClassMap<CsvWriteColumns>
    {
        public CsvWriteColumnsMap()
        {
            Map(m => m.ISIN).Index(0);
            Map(m => m.CFICode).Index(1);
            Map(m => m.Venue).Index(2);
            Map(m => m.ContractSize).Index(3);
        }
    }
}
