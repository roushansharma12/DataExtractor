using CsvHelper;
using CsvHelper.Configuration;
using DataExtractor.Model;
using System;
using System.IO;
using System.Linq;

namespace DataExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int headerValuesAt = 1;
                string filePath = Path.GetFullPath(args[0]);
                string folderPath = Path.GetDirectoryName(filePath);
                string fileName = Path.GetFileNameWithoutExtension(filePath);
                string fileExt = Path.GetExtension(filePath);
                if (!string.IsNullOrWhiteSpace(args[1]))
                    headerValuesAt = int.Parse(args[1]);

                IFileModify<CsvReadColumns> csvModify = new CsvModify();
                var readedRecords = csvModify.Read(filePath, headerValuesAt);
                csvModify.Write(folderPath + "\\" + fileName + "_Output" + fileExt, readedRecords);
            }
            catch
            {
                Console.WriteLine("First parameter should be full file path and second parameter should be header row number if required.");
            }

            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }
    }
}
