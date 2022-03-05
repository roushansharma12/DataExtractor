using DataExtractor.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataExtractor
{
    public interface IFileModify<T>
    {
        public List<T> Read(string path, int headerAt = 1);
        public void Write(string path, List<CsvReadColumns> listData);
    }
}
